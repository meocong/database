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
    public partial class frmNhaCungCap : DevComponents.DotNetBar.OfficeForm
    {
        NhaCungCapController ctrl = new NhaCungCapController();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
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
            textBox2.Focus();
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
     
            this.textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "MANCC", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox1.Enabled = false;
            this.textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "TENNCC", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "DIACHI", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "DIENTHOAI", false, DataSourceUpdateMode.OnPropertyChanged);
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

        private void finding(string textID, string textName, string textAddress, string textNumber)
        {
            dataGridView1.DataSource = ctrl.DataNhaCungCap(textID, textName, textAddress, textNumber).DataSource;
            updateDataSource();
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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Focus();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
