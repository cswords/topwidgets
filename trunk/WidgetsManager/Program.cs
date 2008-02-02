using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cn.edu.bhu.top.desktopWidgets.manager
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
            String url="D:\\cswords\\Projects\\TopWidgetsSLN\\WidgetsManager\\XML\\TopWidgetsConfigure.xml";
            WidgetsManager wm = WidgetsManager.getWidgetManager(url);
            Application.Run();
        }
    }
}
