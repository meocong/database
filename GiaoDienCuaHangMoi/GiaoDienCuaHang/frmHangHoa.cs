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
    public partial class frmHangHoa : DevComponents.DotNetBar.OfficeForm
    {
        HangHoaController ctrl = new HangHoaController();
        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            ctrl.HienThiDataGridView(textBox1, textBox2, textBox3, comboBox1, dateTimePicker1, textBox4, textBox5, dataGridView1);

            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox4.CharacterCasing = CharacterCasing.Upper;
            textBox5.CharacterCasing = CharacterCasing.Upper;

            textBoxX1.CharacterCasing = CharacterCasing.Upper;
            textBoxX2.CharacterCasing = CharacterCasing.Upper;
            textBox2.Focus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ctrl.Update();
        }


        private void buttonReportHH_Click(object sender, EventArgs e)
        {
            frmThongKeHangHoatheoDVT tkhh2 = new frmThongKeHangHoatheoDVT();
            tkhh2.Show();
        }

        public void Finding()
        {
            ctrl.TimKiemHH(textBoxX1.Text, textBoxX2.Text, dateTimeInput1, dateTimeInput3, (Int32)numericUpDown1.Value, (Int32)numericUpDown2.Value, dataGridView1);
            ctrl.Reload_bindings(textBox1, textBox2, textBox3, comboBox1, dateTimePicker1, textBox4, textBox5, dataGridView1);
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            Finding();
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            Finding();
        }

        private void dateTimeInput1_TextChanged(object sender, EventArgs e)
        {
            Finding();
        }

        private void dateTimeInput3_TextChanged(object sender, EventArgs e)
        {
            Finding();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Finding();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Finding();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Focus();
        }

        private void buttonAdding_Click(object sender, EventArgs e)
        {
            ctrl.AddNewRow();
            Finding();

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
            textBox2.Focus();
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
            textBox2.Focus();
        }

        private void buttonSaving_Click(object sender, EventArgs e)
        {
            ctrl.Update();
            ctrl.Update_to_database(this.dataGridView1);
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}