using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GiaoDienCuaHang.DataLayer;
using System.Data;

namespace GiaoDienCuaHang.NewController
{
    public class DonViTinhController
    {
        DonViTinhData data = new DonViTinhData();
        public void HienThi(DataGridView dg)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSDonViTinh();
            dg.DataSource = bs;
        }
        public DataGridViewComboBoxColumn LoadComboBoxColumn()
        {
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataSource = data.LayDSDonViTinh();
            col.DisplayMember = "TENDVT";
            col.ValueMember = "MADVT";
            col.HeaderText = "Đơn Vị Tính";
            col.DataPropertyName = "MADVT";
            return col;
        }
        //Load du lieu vao o combobox Don Vi Tinh
        public void LoadComboBoxDVT(ComboBox cbDVT)
        {
            DonViTinhData dvtdata = new DonViTinhData();
            cbDVT.DataSource = dvtdata.LayDSDonViTinh();
            cbDVT.DisplayMember = "TENDVT";
            cbDVT.ValueMember = "MADVT";
            cbDVT.SelectedValue = "MADVT";

        }
        public void TK(TextBox txtten, DataGridView dg)
        {

            DataTable T = data.TimKiemDVT(txtten.Text);
            {
                if (T.Rows.Count == 0)
                {
                    MessageBox.Show("Tìm không thấy trong danh sách ĐƠN VỊ TÍNH.Vui lòng kiểm tra lại các thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            dg.DataSource = T;

        }
        public void Update()
        {
            data.Update();
        }

        public void AddNewRow()
        {
            data.AddNewRow();
        }

        public BindingSource DataDonViTinh(string textID, string textName)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.DataDonViTinh(textID, textName);
            return bs;
        }

        public void Update_to_database(System.Windows.Forms.DataGridView bindingSource1)
        {
            data.Update_to_database(bindingSource1);
        }
    }
}
