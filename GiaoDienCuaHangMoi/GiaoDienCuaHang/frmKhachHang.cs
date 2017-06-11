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
using GiaoDienCuaHang.DataLayer;

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
            ctrl.HienThi(dataGridView1);
            updateDataSource();

            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox4.CharacterCasing = CharacterCasing.Upper;

            textBoxX1.CharacterCasing = CharacterCasing.Upper;
            textBoxX2.CharacterCasing = CharacterCasing.Upper;
            textBoxX3.CharacterCasing = CharacterCasing.Upper;
            textBoxX4.CharacterCasing = CharacterCasing.Upper;
            //textBox2.Focus();
        }

        private void updateDataSource()
        {
            try
            {
                this.textBox1.DataBindings.RemoveAt(0);
                this.textBox2.DataBindings.RemoveAt(0);
                this.textBox3.DataBindings.RemoveAt(0);
                this.textBox4.DataBindings.RemoveAt(0);
            }
            catch
            {

            }

            this.textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "MAKH", true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox1.Enabled = false;
            this.textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "HOTEN", true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "DIACHI", true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "DIENTHOAI", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void buttonDeleting_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count == 1)
            //{
            //    MessageBox.Show("Bạn không còn gì để xóa!");
            //    return;
            //}
            //if (MessageBox.Show("Bạn chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            //    {
            //        if (oneCell.RowIndex == dataGridView1.Rows.Count - 1)
            //        {
            //            continue;
            //        }
            //        if (oneCell.Selected)
            //            dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
            //    }
            //}

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
                        if (Int32.Parse(dataGridView1.Rows[oneCell.RowIndex].Cells[0].Value.ToString().Substring(2, 3)) == 1)
                        {
                            if (check == false)
                            {
                                check = true;
                                MessageBox.Show("Bạn không thể xóa khách hàng mặc định!");
                            }
                            continue;
                        }
                    }
                    catch
                    {
                        //MessageBox.Show(Ex.Message);
                        continue;
                    }

                    if (oneCell.Selected)
                        dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
            //textBox2.Focus();
        }

        private void buttonAdding_Click(object sender, EventArgs e)
        {
            ctrl.AddNewRow();
            finding("", "", "", "");

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

        private void finding(string textID, string textName, string textAddress, string textNumber)
        {
            dataGridView1.DataSource = ctrl.DataKhachHang(textID, textName, textAddress, textNumber).DataSource;
            updateDataSource();
            //textBox2.Focus();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            finding(this.textBoxX1.Text, this.textBoxX2.Text, this.textBoxX3.Text, this.textBoxX4.Text);
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            finding(this.textBoxX1.Text, this.textBoxX2.Text, this.textBoxX3.Text, this.textBoxX4.Text);
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            finding(this.textBoxX1.Text, this.textBoxX2.Text, this.textBoxX3.Text, this.textBoxX4.Text);
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            finding(this.textBoxX1.Text, this.textBoxX2.Text, this.textBoxX3.Text, this.textBoxX4.Text);
        }

        private void buttonSaving_Click(object sender, EventArgs e)
        {
            //dataGridView1.EndEdit();

            //int rowSelected = dataGridView1.SelectedCells[0].RowIndex;
            //int colSelected = dataGridView1.SelectedCells[0].ColumnIndex;

            //dataGridView1.MultiSelect = false;
            //dataGridView1.Rows[0].Selected = true;
            //dataGridView1.Rows[0].Cells[0].Selected = true;

            ctrl.Update();
            ctrl.Update_to_database(this.dataGridView1);
            dataGridView1.Update();
            dataGridView1.Refresh();

            //dataGridView1.Rows[rowSelected].Selected = true;
            //dataGridView1.Rows[rowSelected].Cells[colSelected].Selected = true;
            //dataGridView1.Rows[0].Selected = false;
            //dataGridView1.Rows[0].Cells[0].Selected = false;
            //dataGridView1.MultiSelect = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value = textBox2.Text;
            //dataGridView1.Update();
            //dataGridView1.Refresh();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value = textBox3.Text;
            //dataGridView1.Update();
            //dataGridView1.Refresh();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = textBox4.Text;
            //dataGridView1.Update();
            //dataGridView1.Refresh();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Focus();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }
    }
}