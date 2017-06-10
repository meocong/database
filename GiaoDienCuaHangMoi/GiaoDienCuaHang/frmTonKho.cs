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
        int check = 2;

        public frmTonKho()
        {
            InitializeComponent();
        }

        private void frmTonKho_Load_1(object sender, EventArgs e)
        {
            ctrl.HienThiDataGridView(dateTimePicker1, comboBox1, textBox1, comboBoxEx1, dataGridView1, false);
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
                    if (oneCell.RowIndex == dataGridView1.Rows.Count - 1)
                    {
                        continue;
                    }
                    if (oneCell.Selected)
                        dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (check > 0)
            {
                check--;
            }
            else
            {
                ctrl.TimKiemTonKho(numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString(), dataGridView1);
                ctrl.Reload_bindings(dateTimePicker1, comboBox1, textBox1, dataGridView1);
            }
        }

        private void comboBoxEx1_TextChanged(object sender, EventArgs e)
        {
            if (check > 0)
            {
                check--;
            }
            else
            {
                string temp = comboBoxEx1.SelectedValue.ToString();
                ctrl.TimKiemTonKho(temp, dataGridView1);
                ctrl.Reload_bindings(dateTimePicker1, comboBox1, textBox1, dataGridView1);
            }
        }

        private void buttonAdding_Click(object sender, EventArgs e)
        {
            ctrl.AddNewRow();
            ctrl.HienThiDataGridView(dateTimePicker1, comboBox1, textBox1, comboBoxEx1, dataGridView1, true);
            ctrl.Reload_bindings(dateTimePicker1, comboBox1, textBox1, dataGridView1);

            dataGridView1.ClearSelection();//If you want

            int nRowIndex = dataGridView1.Rows.Count - 2;
            int nColumnIndex = 1;

            dataGridView1.MultiSelect = false;
            dataGridView1.Rows[nRowIndex].Selected = true;
            dataGridView1.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            //In case if you want to scroll down as well.
            dataGridView1.FirstDisplayedScrollingRowIndex = nRowIndex;
            dataGridView1.MultiSelect = true;
            dataGridView1.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
        }

        private void buttonSaving_Click(object sender, EventArgs e)
        {
            ctrl.Update();
            ctrl.Update_to_database(this.dataGridView1);
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ctrl.HienThiDataGridView(dateTimePicker1, comboBox1, textBox1, comboBoxEx1, dataGridView1, true);
            ctrl.Reload_bindings(dateTimePicker1, comboBox1, textBox1, dataGridView1);
        }
    }
}