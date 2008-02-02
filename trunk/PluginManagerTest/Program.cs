using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cn.edu.bhu.top.desktopWidgets.plugins;

namespace PluginManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginManager.loadPlugins("D:\\cswords\\Projects\\TopWidgetsSLN\\PluginManagerTest\\XMLTest\\TopWidgetsConfigure.xml");
            PluginManager.disposePlugins();
        }
    }
}
