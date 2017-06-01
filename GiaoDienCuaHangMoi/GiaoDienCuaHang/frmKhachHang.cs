using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GiaoDienCuaHang.NewController;
using System.Collections;

namespace GiaoDienCuaHang
{
    public partial class frmKhachHang : DevComponents.DotNetBar.OfficeForm
    {
        KhachHangController ctrl = new KhachHangController();

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(textBox1, textBox2, textBox3, textBox4, dataGridView1);
        }

        private void buttonDeleting_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                IEnumerator ie = dataGridView1.SelectedRows.GetEnumerator();

                while (ie.MoveNext())
                {
                    DataGridViewRow row = (DataGridViewRow)ie.Current;
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        private void buttonAdding_Click(object sender, EventArgs e)
        {
            
        }
    }
}