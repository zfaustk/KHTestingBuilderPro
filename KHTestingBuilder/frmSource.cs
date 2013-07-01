using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KHTestingBuilder
{
    public partial class frmSource : Form
    {
        public frmSource()
        {
            InitializeComponent();
        }

        public string Value
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public void Unable()
        {
            this.btnOK.Visible = false;
            this.txtInput.ReadOnly = true;
            this.txtInput.Cursor = Cursors.Arrow;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;
        }



    }
}
