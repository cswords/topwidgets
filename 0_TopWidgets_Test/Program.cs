using System;
using System.Windows.Forms;
using cn.edu.bhu.top.desktopWidgets.manager;

namespace __TopWidgets_Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String url = @".\XML\TopWidgetsConfigure.xml";
            if (System.IO.File.Exists(url))
            {
                WidgetsManager wm = WidgetsManager.getWidgetManager(url);
            }
            Application.Run();
        }

        static void copyPlugins()
        {

        }
    }
}
