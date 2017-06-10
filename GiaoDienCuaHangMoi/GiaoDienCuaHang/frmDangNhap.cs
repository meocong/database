using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace GiaoDienCuaHang
{
    public partial class frmDangNhap : Office2007RibbonForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void labelusername_Click(object sender, EventArgs e)
        {

        }

        private void buttonHB_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDN_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}