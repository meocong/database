﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GiaoDienCuaHang.NewController;

namespace GiaoDienCuaHang
{
    public partial class frmNhanVien : DevComponents.DotNetBar.OfficeForm
    {
        NhanVienController ctrl = new NhanVienController();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(textBox1, textBox2, textBox3, dateTimePicker1, textBox4, comboBox1, comboBox2, textBox7, textBox7, dataGridView1);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
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

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            ctrl.Update();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!textBox1.Text.Substring(0, 2).Equals("NV"))
            {
                MessageBox.Show("Mã nhân viên bị sai. Phải nhập NV đầu!!!!!!!");
                e.Cancel = true;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}