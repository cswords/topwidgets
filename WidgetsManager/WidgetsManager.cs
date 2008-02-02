using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.Drawing;
using cn.edu.bhu.top.desktopWidgets.form;
using cn.edu.bhu.top.desktopWidgets.plugins;

namespace cn.edu.bhu.top.desktopWidgets.manager
{
    public partial class WidgetsManager : System.ComponentModel.Component
    {
        private static WidgetsManager widgetsManager = null;

        private WidgetsManager(String url)
        {
            this.InitializeComponent();
            this.initMenu();
        }

        public static WidgetsManager getWidgetManager(String url)
        {
            if (widgetsManager == null)
            {
                widgetsManager = new WidgetsManager(url);
            }
            PluginManager.loadPlugins(url);
            return widgetsManager;
        }

        public static void addMenuItem(ToolStripItem item)
        {
            if (widgetsManager != null)
            {
                widgetsManager.menu.Items.Insert(0, item);
            }
        }

        public void initMenu()
        {
            this.exit.Click+=new EventHandler(exitApp);
            this.open.Click+=new EventHandler(openWidget);
        }

        private void exitApp(object sender, EventArgs e)
        {
            PluginManager.disposePlugins();
            Application.Exit();
        }

        private void openWidget(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(formThread));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void formThread()
        {
            BrowserForm bf = new BrowserForm();
            bf.Load+=new EventHandler(bf_Load);
            (bf).ShowDialog();
        }

        private void bf_Load(object sender, EventArgs e)
        {
            BrowserForm bf = (BrowserForm)sender;
            WidgetMenuItem wmi=new WidgetMenuItem(bf,this);
            this.menu.Items.Insert(0,wmi);
        }
    }
}
