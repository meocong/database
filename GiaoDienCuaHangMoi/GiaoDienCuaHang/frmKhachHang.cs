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
        KhachHangData data = new KhachHangData();
        private BindingSource dataSource = new BindingSource();

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridView1);
            updateDataSource();
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
            
            dataSource.DataSource = dataGridView1.DataSource;
            this.textBox1.DataBindings.Add("Text", dataSource.DataSource, "MAKH");
            this.textBox1.Enabled = false;
            this.textBox2.DataBindings.Add("Text", dataSource.DataSource, "HOTEN");
            this.textBox3.DataBindings.Add("Text", dataSource.DataSource, "DIACHI");
            this.textBox4.DataBindings.Add("Text", dataSource.DataSource, "DIENTHOAI");
        }

        private void buttonDeleting_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                {
                    if (oneCell.Selected)
                        dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
        }

        private void buttonAdding_Click(object sender, EventArgs e)
        {
            data.AddNewRow();
            finding("", "", "", "");

            //dataGridView1.Rows[dataGridView1.RowCount-1].Selected = true;
            //foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            //{
            //   cell.Selected = false;
            //}

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

        private void finding(string textID, string textName, string textAddress, string textNumber)
        {
            dataGridView1.DataSource = data.DataKhachHang(textID, textName, textAddress, textNumber);
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

        private void buttonSaving_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            ctrl.Update();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}