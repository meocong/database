using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GiaoDienCuaHang.NewController;
using DevComponents.DotNetBar;

namespace GiaoDienCuaHang
{
    public partial class frmLoaiNhanVien : DevComponents.DotNetBar.OfficeForm
    {
        LoaiNhanVienController ctrl = new LoaiNhanVienController();

        public frmLoaiNhanVien()
        {
            InitializeComponent();
        }

        private void frmLoaiNhanVien_Load(object sender, EventArgs e)
        {
            ctrl.HienThi(textBox1, textBox2, dataGridView1);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
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
                        if (Int32.Parse(dataGridView1.Rows[oneCell.RowIndex].Cells[1].Value.ToString().Substring(2, 3)) <= 2)
                        {
                            if (check == false)
                            {
                                check = true;
                                MessageBox.Show("Bạn không thể xóa loại nhân viên gốc!");
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
            if (!textBox1.Text.Substring(0, 3).Equals("MNV"))
            {
                MessageBox.Show("Mã loại nhân viên bị sai. Phải nhập MNV ở đầu mã loại!!!!!!!");
                e.Cancel = true;
            }
        }
    }
}