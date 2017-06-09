using System;
using System.Collections.Generic;
using System.Text;
using GiaoDienCuaHang.DataLayer;
using System.Windows.Forms;
using System.Data;

namespace GiaoDienCuaHang.NewController
{
    public class NhaCungCapController
    {
        NhaCungCapData data = new NhaCungCapData();
        public void HienThi(DataGridView dg)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSNhaCungCap();
            dg.DataSource = bs;
        }

        string strTenNhaCungCap;
        public ListViewItem.ListViewSubItem LoadListViewSubItemNhaCungCap(string str)
        {
            ListViewItem.ListViewSubItem subI = new ListViewItem.ListViewSubItem();
            System.Data.DataTable dt = data.LayDSNhaCungCap();
            subI.Tag = dt;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MANCC"].ToString() == str)
                    strTenNhaCungCap = dr["TENNCC"].ToString();

            }
            subI.Text = strTenNhaCungCap;
            return subI;
        }
        public void LoadComboBoxNhaCungCap(ComboBox cmb)
        {
            cmb.DataSource = data.LayDSNhaCungCap();
            cmb.DisplayMember = "TENNCC";
            cmb.ValueMember = "MANCC";
            cmb.SelectedValue = "MANCC";
        }
        public void TimKiemNhaCungCap(TextBox txtTenNCC, ComboBox cmbchonDCHI, TextBox txtDC, ComboBox cmbchonDT, TextBox txtDT, DataGridView dg)
        {
            DataTable tbl = data.TKNhaCungCap(txtTenNCC.Text, cmbchonDCHI.Text, txtDC.Text, cmbchonDT.Text, txtDT.Text);
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Tìm không thấy trong danh sách NHÀ CUNG CẤP.Vui lòng kiểm tra lại các thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dg.DataSource = tbl;

        }
        public void Update()
        {
            data.Update();
        }

        public void AddNewRow()
        {
            data.AddNewRow();
        }

        public BindingSource DataNhaCungCap(string textID, string textName, string textAddress, string textNumber)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.DataNhaCungCap(textID, textName, textAddress, textNumber);
            return bs;
        }

        public void Update_to_database(System.Windows.Forms.DataGridView bindingSource1)
        {
            data.Update_to_database(bindingSource1);
        }
    }
}
