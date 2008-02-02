using System;
using System.Collections.Generic;
using System.Text;
using cn.edu.bhu.top.desktopWidgets.form;

namespace cn.edu.bhu.top.desktopWidgets.manager
{
    class WidgetMenuItem:System.Windows.Forms.ToolStripMenuItem
    {
        public BrowserForm wform;
        public WidgetsManager wmanager;
        
        public WidgetMenuItem(BrowserForm form, WidgetsManager wm)
        {
            this.wform = form;
            this.wmanager = wm;
            this.Click += new EventHandler(onclick);
            this.wform.FormClosed+=new System.Windows.Forms.FormClosedEventHandler(wform_Disposed);
            this.wform.TextChanged += new EventHandler(wform_TextChanged);
            this.Text = wform.Text;
        }

        void wform_TextChanged(object sender, EventArgs e)
        {
            this.Text = wform.Text;
        }

        public void onclick(object sender, EventArgs e)
        {
            wform.showTitle();
        }


        private void wform_Disposed(object sender, EventArgs e)
        {
            this.wmanager.menu.Items.Remove(this);
        }

    }
}
