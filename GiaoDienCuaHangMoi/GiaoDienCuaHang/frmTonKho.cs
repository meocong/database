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
    public partial class frmTonKho : DevComponents.DotNetBar.OfficeForm
    {
        TonKhoController ctrl = new TonKhoController();

        public frmTonKho()
        {
            InitializeComponent();
        }

        private void frmTonKho_Load_1(object sender, EventArgs e)
        {
            ctrl.HienThiDataGridView(dateTimePicker1, comboBox1, textBox1, comboBoxEx1, dataGridView1);
        }

        private void buttonDeleting_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Bạn không còn gì để xóa!");
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                {
                    if (oneCell.Selected)
                        dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //ctrl.TimKiemTonKho(textMonth, textYear, dataGridView1);
            //ctrl.Reload_bindings
        }

        private void comboBoxEx1_TextChanged(object sender, EventArgs e)
        {
            //string temp = comboBoxEx1.SelectedValue.ToString();
            //ctrl.TimKiemTonKho(textMonth, textYear, dataGridView1);
            //ctrl.Reload_bindings
        }
    }
}