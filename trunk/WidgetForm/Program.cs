using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace cn.edu.bhu.top.desktopWidgets.form
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new BrowserForm());
            //WidgetsManager.createWidgetManager(widgetsManager);
            //Application.Run();
            BrowserForm a = new BrowserForm();
            a.Width = 500;
            a.Height=600;
            Application.Run(a);
        }

        //static WidgetsManager widgetsManager = null;
    }
}