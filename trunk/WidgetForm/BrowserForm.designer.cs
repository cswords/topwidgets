namespace cn.edu.bhu.top.desktopWidgets.form
{
    partial class BrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.WidgetPageBrowser = new System.Windows.Forms.WebBrowser();
            this.BrowserPanel = new System.Windows.Forms.Panel();
            this.opacityBar = new System.Windows.Forms.TrackBar();
            this.browserMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideTitleBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHtmlDialog = new System.Windows.Forms.OpenFileDialog();
            this.autoDockManager = new QQClient.QQ.QQBuddy.Components.AutoDockManage(this.components);
            this.BrowserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).BeginInit();
            this.browserMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // WidgetPageBrowser
            // 
            this.WidgetPageBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WidgetPageBrowser.Location = new System.Drawing.Point(0, 0);
            this.WidgetPageBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WidgetPageBrowser.Name = "WidgetPageBrowser";
            this.WidgetPageBrowser.ScriptErrorsSuppressed = true;
            this.WidgetPageBrowser.ScrollBarsEnabled = false;
            this.WidgetPageBrowser.Size = new System.Drawing.Size(292, 249);
            this.WidgetPageBrowser.TabIndex = 0;
            // 
            // BrowserPanel
            // 
            this.BrowserPanel.Controls.Add(this.opacityBar);
            this.BrowserPanel.Controls.Add(this.WidgetPageBrowser);
            this.BrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserPanel.Location = new System.Drawing.Point(0, 24);
            this.BrowserPanel.Name = "BrowserPanel";
            this.BrowserPanel.Size = new System.Drawing.Size(292, 249);
            this.BrowserPanel.TabIndex = 1;
            // 
            // opacityBar
            // 
            this.opacityBar.AutoSize = false;
            this.opacityBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.opacityBar.Location = new System.Drawing.Point(89, 0);
            this.opacityBar.Maximum = 100;
            this.opacityBar.Name = "opacityBar";
            this.opacityBar.Size = new System.Drawing.Size(203, 26);
            this.opacityBar.TabIndex = 3;
            this.opacityBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.opacityBar.Value = 100;
            this.opacityBar.Visible = false;
            this.opacityBar.Scroll += new System.EventHandler(this.opacityBar_Scroll);
            // 
            // browserMenuStrip
            // 
            this.browserMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.hideTitleBarToolStripMenuItem,
            this.topMostToolStripMenuItem,
            this.opacityToolStripMenuItem});
            this.browserMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.browserMenuStrip.Name = "browserMenuStrip";
            this.browserMenuStrip.Size = new System.Drawing.Size(292, 24);
            this.browserMenuStrip.TabIndex = 2;
            this.browserMenuStrip.Text = "browser MenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.uRLToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fileToolStripMenuItem.Text = "Open";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.openToolStripMenuItem.Text = "File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // uRLToolStripMenuItem
            // 
            this.uRLToolStripMenuItem.Name = "uRLToolStripMenuItem";
            this.uRLToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.uRLToolStripMenuItem.Text = "URL";
            this.uRLToolStripMenuItem.Click += new System.EventHandler(this.uRLToolStripMenuItem_Click);
            // 
            // hideTitleBarToolStripMenuItem
            // 
            this.hideTitleBarToolStripMenuItem.Name = "hideTitleBarToolStripMenuItem";
            this.hideTitleBarToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.hideTitleBarToolStripMenuItem.Text = "Hide Frame";
            this.hideTitleBarToolStripMenuItem.Click += new System.EventHandler(this.hideTitleBarToolStripMenuItem_Click);
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.AutoToolTip = true;
            this.topMostToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.topMostToolStripMenuItem.Text = "Top/Hide";
            this.topMostToolStripMenuItem.ToolTipText = "off";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.opacityToolStripMenuItem.Text = "100%";
            this.opacityToolStripMenuItem.Click += new System.EventHandler(this.opacityToolStripMenuItem_Click);
            // 
            // openHtmlDialog
            // 
            this.openHtmlDialog.Filter = "HTML Files|*.html;*.htm|All Files|*.*";
            // 
            // autoDockManager
            // 
            this.autoDockManager.DockForm = this;
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.BrowserPanel);
            this.Controls.Add(this.browserMenuStrip);
            this.Name = "BrowserForm";
            this.ShowInTaskbar = false;
            this.Text = "Top Desktop Widget Browser";
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.BrowserPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).EndInit();
            this.browserMenuStrip.ResumeLayout(false);
            this.browserMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.TopMost = false;

        }

        #endregion

        private System.Windows.Forms.WebBrowser WidgetPageBrowser;
        private System.Windows.Forms.Panel BrowserPanel;
        private System.Windows.Forms.MenuStrip browserMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideTitleBarToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openHtmlDialog;
        private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
        private System.Windows.Forms.TrackBar opacityBar;
        public QQClient.QQ.QQBuddy.Components.AutoDockManage autoDockManager;
        private System.Windows.Forms.ToolStripMenuItem uRLToolStripMenuItem;

    }
}

