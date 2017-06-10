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
    public partial class frmDonViTinh : DevComponents.DotNetBar.OfficeForm
    {
        DonViTinhController ctrl = new DonViTinhController();
        public frmDonViTinh()
        {
            InitializeComponent();
        }

        private void frmDonViTinh_Load_1(object sender, EventArgs e)
        {
            ctrl.HienThi(dataGridView1);
            updateDataSource();

            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;

            textBoxX1.CharacterCasing = CharacterCasing.Upper;
            textBoxX2.CharacterCasing = CharacterCasing.Upper;
            textBox2.Focus();
        }

        private void updateDataSource()
        {
            try
            {
                this.textBox1.DataBindings.RemoveAt(0);
                this.textBox2.DataBindings.RemoveAt(0);
            }
            catch
            {

            }

            this.textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "MADVT", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBox1.Enabled = false;
            this.textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "TENDVT", false, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTimKiemDVT tdvt = new frmTimKiemDVT();
            tdvt.Show();
        }

        private void finding(string textID, string textName)
        {
            dataGridView1.DataSource = ctrl.DataDonViTinh(textID, textName).DataSource;
            updateDataSource();
        }

        private void buttonAdding_Click(object sender, EventArgs e)
        {
            ctrl.AddNewRow();
            finding("", "");

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
            bool check = false;

            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Bạn không còn gì để xóa!");
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Đơn Vị Tính", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                {
                    try
                    {
                        if (Int32.Parse(dataGridView1.Rows[oneCell.RowIndex].Cells[0].Value.ToString().Substring(3, 3)) < 6)
                        {
                            if (check == false)
                            {
                                check = true;
                                MessageBox.Show("Bạn không thể xóa đơn vị tính mặc định!");
                            }
                            continue;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                    
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

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            finding(this.textBoxX1.Text, this.textBoxX2.Text);
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            finding(this.textBoxX1.Text, this.textBoxX2.Text);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Focus();
        }
    }
}
