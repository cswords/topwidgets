using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace cn.edu.bhu.top.desktopWidgets.plugins
{
    public class DemoPlugin:IPlugin
    {
        #region IPlugin 成员

        public IPlugin register(IDictionary<string, IPlugin> plugins, System.Xml.XmlNode pluginNode)
        {
            //throw new NotImplementedException();
            Console.WriteLine("register demo");
            if (plugins.Count == 1 && plugins.Values.Contains((IPlugin)this))
                Console.WriteLine("found demo and directory good");
            Console.WriteLine(pluginNode.OuterXml);
            Console.ReadLine();
            MessageBox.Show(pluginNode.OuterXml, "register demo");
            return this;
        }

        public void run()
        {
            //throw new NotImplementedException();
            Console.WriteLine("run demo");
            MessageBox.Show("run demo");
            Console.ReadLine();
        }

        public void dispose()
        {
            //throw new NotImplementedException();
            Console.WriteLine("dispose demo");
            MessageBox.Show("dispose demo");
            Console.ReadLine();
        }

        #endregion
    }
}
