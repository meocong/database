using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GiaoDienCuaHang.NewController;

namespace GiaoDienCuaHang
{
    public partial class frmDanhSachHangHoaSapHetHan : DevComponents.DotNetBar.OfficeForm
    {
        HangHoaController ctrl = new HangHoaController();

        public frmDanhSachHangHoaSapHetHan()
        {
            InitializeComponent();
        }

        private void frmDanhSachHangHoaSapHetHan_Load(object sender, EventArgs e)
        {
            ctrl.HienThiDataGridViewHHsaphethan(dataGridView1, (int)numericUpDown1.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ctrl.HienThiDataGridViewHHsaphethan(dataGridView1, (int)numericUpDown1.Value);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}