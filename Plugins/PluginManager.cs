using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.IO;

namespace cn.edu.bhu.top.desktopWidgets.plugins
{
    public class PluginManager
    {
        IDictionary<String, IPlugin> pluginDictionary;

        IDictionary<String,Assembly> dllDictionary;

        XmlDocument xmlDoc;

        static XmlNodeList plugins = null;
        static XmlNodeList disposeList = null;
        static XmlNodeList runList = null;

        private PluginManager()
        {
            this.pluginDictionary = new Dictionary<string, IPlugin>();
            this.dllDictionary = new Dictionary<string, Assembly>();
            this.xmlDoc = new XmlDocument();
        }

        private static PluginManager pluginManager = null;

        public static void loadPlugins(String xmlPath)
        {
            if (pluginManager == null)
            {
                pluginManager = new PluginManager();
            }
            try
            {
                pluginManager.xmlDoc.Load(xmlPath);
            }
            catch (Exception e)
            {
                throw new PluginException("file path error.\n" + e.Message);
            }
            /*
             * <widgets>
             *  
             *  <plugins>
             *  ...
             *  </plugins>
             *  <runList>
             *  ...
             *  </runList>
             *  <disposeList>
             *  ...
             *  </disposeList>
             * </widgets>
             */
            XmlDocument xmlDoc = pluginManager.xmlDoc;

            //check the xml file;
            if (xmlDoc.GetElementsByTagName("widgets").Count == 0)
                throw new PluginException("No widgets node found.");

            if (xmlDoc.GetElementsByTagName("plugins").Count == 0)
                throw new PluginException("No plugins node found.");
            else
                plugins = xmlDoc.GetElementsByTagName("plugins")[0].ChildNodes;

            if (xmlDoc.GetElementsByTagName("runList").Count == 0)
                throw new PluginException("No runList node found.");
            else
                runList = xmlDoc.GetElementsByTagName("runList")[0].ChildNodes;

            if (xmlDoc.GetElementsByTagName("disposeList").Count == 0)
                throw new PluginException("No disposeList node found.");
            else
                disposeList = xmlDoc.GetElementsByTagName("disposeList")[0].ChildNodes;

            pluginManager.registerPlugins(plugins);
            pluginManager.runPlugins(runList);
        }

        private void registerPlugins(System.Xml.XmlNodeList plugins)
        {
            /*
             * <plugins>
             *  <assemble dll=.../>
             * ......
             *  <plugin id=....../>
             * ......
             * </plugins>
             */
            for (int i = 0; i < plugins.Count; i++)
            {
                if (plugins[i].Name == "assemble")
                {
                    this.assemble(plugins[i]);
                }
                if (plugins[i].Name == "plugin")
                {
                    this.registerPlugin(plugins[i]);
                }
            }
        }

        private void assemble(System.Xml.XmlNode dllNode)
        {
            //<assemble dll="file name/*.dll" name="dll key class name" address="source path/..../"/>
            String fileName = null;
            if (dllNode.Attributes["dll"] == null)
                throw new PluginException("assemble node attribute dll error:\n" + dllNode.OuterXml);
            else
                fileName = dllNode.Attributes["dll"].Value;

            String dllKey = null;
            if (dllNode.Attributes["name"] == null)
                throw new PluginException("assemble node attribute name error:\n" + dllNode.OuterXml);
            else
                dllKey = dllNode.Attributes["name"].Value;

            if (!System.IO.File.Exists("./plugins/" + fileName))
            {
                String source = null;
                if (dllNode.Attributes["address"] == null)
                    throw new PluginException("assemble node attribute address error:\n" + dllNode.OuterXml);
                else
                    source = dllNode.Attributes["address"].Value;

                if (!Directory.Exists("./plugins")) Directory.CreateDirectory("./plugins");

                try
                {
                    File.Copy(source + fileName, "./plugins/" + fileName, true);
                }
                catch (IOException e)
                {
                    throw new PluginException("upgrade plugin error.\n" + e.StackTrace);
                }

            }
            System.Reflection.Assembly dll = System.Reflection.Assembly.LoadFrom("./plugins/" + fileName);

            this.dllDictionary.Add(dllKey, dll);
        }

        private void registerPlugin(System.Xml.XmlNode pluginNode)
        {
            /*
             * <plugin id="plugin key" name="dll key">
             *  ...
             * </plugin>
             */
            IPlugin plugin = null;

            String id;
            if(pluginNode.Attributes["id"]==null)
                throw new PluginException("plugin node attribute id error:\n" + pluginNode.OuterXml);
            else
                id=pluginNode.Attributes["id"].Value;

            String dllKey;
            if(pluginNode.Attributes["name"]==null)
                throw new PluginException("plugin node attribute name error:\n" + pluginNode.OuterXml);
            else
                dllKey=pluginNode.Attributes["name"].Value;

            System.Reflection.Assembly dll = this.dllDictionary[dllKey];
            if (dll == null) throw new PluginException("no " + dllKey + " assembled found.");

            Type t = dll.GetType(dllKey);
            if (t == null) throw new PluginException("no " + dllKey + " class found.");
            Type tt=dll.GetType("cn.edu.bhu.top.desktopWidgets.plugins.IPlugin");

            object obj = Activator.CreateInstance(t);
            if(obj is IPlugin)
                plugin = (IPlugin)obj;
            else
                throw new PluginException("no " + dllKey + " plugin found.");

            plugin.register(this.pluginDictionary, pluginNode);
            this.pluginDictionary.Add(id, plugin);
        }

        private void runPlugins(System.Xml.XmlNodeList runList)
        {
            /*
             * <runList>
             *  <run pluginId="plugin key"/>
             * ......
             * </runList>
             */
            for (int i = 0; i < runList.Count; i++)
            {
                if (runList[i].Name == "run")
                {
                    String pluginKey;
                    if (runList[i].Attributes["pluginId"] == null)
                        throw new PluginException("run node attribute pluginId error:\n" + runList[i].OuterXml);
                    else
                        pluginKey = runList[i].Attributes["pluginId"].Value;

                    this.pluginDictionary[pluginKey].run();
                }
            }
        }

        private void dispose(System.Xml.XmlNodeList disposeList)
        {
            /*
             * <disposeList>
             *  <dispose pluginId="plugin key"/>
             * ......
             * </disposeList>
             */
            for (int i = 0; i < disposeList.Count; i++)
            {
                if (disposeList[i].Name == "dispose")
                {
                    String pluginKey;
                    if (disposeList[i].Attributes["pluginId"] == null)
                        throw new PluginException("dispose node attribute pluginId error:\n" + disposeList[i].OuterXml);
                    else
                        pluginKey = disposeList[i].Attributes["pluginId"].Value;

                    this.pluginDictionary[pluginKey].dispose();
                }
            }
        }

        public static void disposePlugins()
        {
            if (pluginManager != null)
            {
                pluginManager.dispose(disposeList);
                pluginManager = null;
            }
        }

        public class PluginException : Exception
        {
            private string message;

            public PluginException(string message)
            {
                this.message = message;
            }

            public override String Message
            {
                get
                {
                    return this.message;
                }
            }
        }
    }
}
