﻿using System;
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
            ctrl.HienThiDataGridView(dateTimePicker1, comboBox1, textBox1, dataGridView1);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ctrl.Update();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}