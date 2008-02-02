using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cn.edu.bhu.top.desktopWidgets.form
{
    public partial class UrlLoadDialog : Form
    {
        public String Url
        {
            get
            {
                return this.urlBox.Text;
            }
        }

        public UrlLoadDialog()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}