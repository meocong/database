using System;
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
        int n_change = 6;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(textBox1, textBox2, textBox3, dateTimePicker1, textBox4, comboBox1, comboBox2, textBox6, textBox7, comboBoxEx2, comboBoxEx3, dataGridView1);

            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox4.CharacterCasing = CharacterCasing.Upper;
            textBox6.CharacterCasing = CharacterCasing.Upper;
            textBox7.CharacterCasing = CharacterCasing.Upper;

            textBoxX1.CharacterCasing = CharacterCasing.Upper;
            textBoxX2.CharacterCasing = CharacterCasing.Upper;
            textBoxX3.CharacterCasing = CharacterCasing.Upper;
            textBoxX4.CharacterCasing = CharacterCasing.Upper;

            textBox1.Enabled = false;
            textBox2.Focus();
        }

        private void buttonDeleting_Click(object sender, EventArgs e)
        {
            bool check = false;

            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Bạn không còn gì để xóa!");
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                {
                    if (oneCell.RowIndex == dataGridView1.Rows.Count - 1)
                    {
                        continue;
                    }

                    try
                    {
                        if (Int32.Parse(dataGridView1.Rows[oneCell.RowIndex].Cells[1].Value.ToString().Substring(2, 3)) == 1)
                        {
                            if (check == false)
                            {
                                check = true;
                                MessageBox.Show("Bạn không thể xóa thành viên quản lý gốc!");
                            }
                            continue;
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                    
                    if (oneCell.Selected)
                        dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
            textBox2.Focus();
        }

        private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        public void Finding()
        {
            string selectedValue1 = "", selectedValue2 = "";
            try
            {
                selectedValue1 = comboBoxEx2.SelectedValue.ToString();
            }
            catch
            {

            }
            try
            {
                selectedValue2 = comboBoxEx3.SelectedValue.ToString();
            }
            catch
            {

            }
            ctrl.TimKiemNV(textBoxX1.Text, textBoxX2.Text, textBoxX3.Text, textBoxX4.Text, selectedValue1, selectedValue2, dataGridView1);

            ctrl.Reload_bindings(textBox1, textBox2, textBox3, dateTimePicker1, textBox4, comboBox1, comboBox2, textBox6, textBox7, comboBoxEx2, comboBoxEx3, dataGridView1);
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

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (n_change > 0)
            {
                n_change--;
            }
            else
            {
                Finding();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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