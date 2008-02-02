using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using QQClient.QQ.QQBuddy.Components;

namespace cn.edu.bhu.top.desktopWidgets.form
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
        {
            InitializeComponent();
        }

        private String url = "";

        public BrowserForm(String url)
        {
            this.url=url;
            InitializeComponent();
        }

        //can not resize after hidetitle
        #region show&hide the title bar
        public void hideTitle()
        {
            GraphicsPath gPath = new GraphicsPath();
            int bw = (this.Width - this.BrowserPanel.Width)/2;
            int top = this.Height - bw - this.BrowserPanel.Height;            
            gPath.AddRectangle(new RectangleF(bw, top, this.BrowserPanel.Width, this.BrowserPanel.Height));
            this.Region = new System.Drawing.Region(gPath);
            this.opacityBar.Visible = false;
        }

        public void showTitle()
        {
            /*
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddRectangle(new RectangleF(0, 0, this.Width, this.Height));
            this.Region = new System.Drawing.Region(gPath);*/
            this.Region = null;
            this.opacityBar.Value = 100;
            this.Opacity = 1;
            this.opacityToolStripMenuItem.Text = "100%";
        }
        #endregion

        #region EventsHandler
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFile();
        }

        private void hideTitleBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hideTitle();
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.topMostToolStripMenuItem.ForeColor==System.Drawing.Color.Black)
            {
                this.topMostToolStripMenuItem.ForeColor = System.Drawing.Color.SeaGreen;
                this.TopMost = true;
                this.autoDockManager.sure = true;
            }
            else
            {
                this.topMostToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
                this.TopMost = false;
                this.autoDockManager.sure = false;
            }
        }

        private void opacityBar_Scroll(object sender, EventArgs e)
        {
            this.Opacity = ((double)this.opacityBar.Value)/100;
            this.opacityToolStripMenuItem.Text = (this.opacityBar.Value).ToString()+"%";
        }

        private void opacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.opacityBar.Visible = !this.opacityBar.Visible;
        }

        #endregion

        #region functions
        private void showOnTop()
        {
            this.BringToFront();
            this.Opacity = 1;
        }

        private void openFile()
        {
            if (this.openHtmlDialog.ShowDialog() == DialogResult.OK)
            {
                this.Text = this.openHtmlDialog.FileName;
                this.WidgetPageBrowser.Navigate(this.Text);
            }
            this.showOnTop();      
        }
        #endregion

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            if (this.url.Length != 0)
            {
                this.WidgetPageBrowser.Navigate(this.url);
                this.Text = url;
            }
            else
            {
                this.openFile();
            }
            this.showOnTop();
        }

        private UrlLoadDialog urlLoadDialog = new UrlLoadDialog();

        private void uRLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.urlLoadDialog.ShowDialog() == DialogResult.OK)
            {
                this.Text = this.urlLoadDialog.Url;
                this.WidgetPageBrowser.Navigate(this.Text);
            }
            this.showOnTop();      
        }
    }
}