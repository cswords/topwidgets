using System;
using System.Collections.Generic;
using System.Text;

namespace cn.edu.bhu.top.desktopWidgets.plugins
{
    public interface IPlugin
    {
        IPlugin register(IDictionary<String,IPlugin> plugins, System.Xml.XmlNode pluginNode);
        void run();
        void dispose();
    }
}
