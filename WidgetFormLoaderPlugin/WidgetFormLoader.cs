using System;
using System.Collections.Generic;
using System.Text;
using cn.edu.bhu.top.desktopWidgets.plugins;
using cn.edu.bhu.top.desktopWidgets.form;
using System.Windows.Forms;
using cn.edu.bhu.top.desktopWidgets.manager;

namespace cn.edu.bhu.top.desktopWidgets.form.plugin
{
    class WidgetFormLoader:IPlugin
    {
        /*
         * <assemble dll="WidgetFormLoaderPlugin.dll" 
         *      name="cn.edu.bhu.top.desktopWidgets.form.plugin.WidgetFormLoader" 
         *      address="D:\cswords\Projects\TopWidgetsSLN\WidgetFormLoaderPlugin\bin\debug\"/>
         * <plugin id="FormLoader1" name="cn.edu.bhu.top.desktopWidgets.form.plugin.WidgetFormLoader">
         *  <menuItem text=""/>
         *  <page url=""/>
         *  <form align="" head="none" width="" height=""/>
         * </plugin>
         */

        #region IPlugin 成员

        public IPlugin register(IDictionary<string, IPlugin> plugins, System.Xml.XmlNode pluginNode)
        {
            for (int i = 0; i < pluginNode.ChildNodes.Count; i++)
            {
                if (pluginNode.ChildNodes[i].Name == "menuItem")
                    this.menuItemNode = pluginNode.ChildNodes[i];
                if (pluginNode.ChildNodes[i].Name == "page")
                    this.pageNode = pluginNode.ChildNodes[i];
                if (pluginNode.ChildNodes[i].Name == "form")
                    this.formNode = pluginNode.ChildNodes[i];
            }
            this.setMenuItem();
            return this;
        }

        public void run()
        {
            BrowserForm browserForm = null;
            MessageBox.Show("run loader");
            if (pageNode != null
                && pageNode.Attributes["url"] != null)
            {
                browserForm = new BrowserForm(pageNode.Attributes["url"].Value);
                this.setForm(browserForm);
            }
            else
            {
                browserForm = new BrowserForm();
                this.setForm(browserForm);
            }
            browserForm.ShowDialog();
        }

        public void dispose()
        {
            MessageBox.Show("dispose loader");
        }

        #endregion

        private System.Xml.XmlNode menuItemNode = null;

        private void setMenuItem()
        {
            ToolStripMenuItem tsi = new ToolStripMenuItem();
            tsi.Click += new EventHandler(tsi_Click);
            if (menuItemNode != null
                && menuItemNode.Attributes["text"] != null)
            {
                tsi.Text = menuItemNode.Attributes["text"].Value;
            }
            else
            {
                throw new PluginManager.PluginException(
                    "some thing wrong with menuItem node");
            }
            WidgetsManager.addMenuItem(tsi);
        }

        void tsi_Click(object sender, EventArgs e)
        {
            this.run();
        }

        private System.Xml.XmlNode pageNode = null;

        private System.Xml.XmlNode formNode = null;

        private void setForm(BrowserForm browserForm)
        {
            if (formNode == null)
                return;
            else
            {
                if (formNode.Attributes["align"] != null)
                {
                    MessageBox.Show("align,sorry");
                }
                if (formNode.Attributes["width"] != null)
                {
                    browserForm.Width = Int32.Parse(formNode.Attributes["width"].Value);
                }
                if (formNode.Attributes["height"] != null)
                {
                    browserForm.Height = Int32.Parse(formNode.Attributes["height"].Value);
                }
                if (formNode.Attributes["head"] != null
                    && formNode.Attributes["head"].Value=="none")
                {
                    browserForm.hideTitle();
                }
            }
        }
    }
}
