using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using GiaoDienCuaHang.DataLayer;
using DevComponents.Editors.DateTimeAdv;
using DevComponents.DotNetBar.Controls;

namespace GiaoDienCuaHang.NewController
{
    public class HangHoaController
    {
        HangHoaData data = new HangHoaData();
        public void HienThiDataGridView(TextBox txtMHH, TextBox txtTHH, TextBox txtSL, ComboBox cmbMDVT, DateTimeInput dt, TextBox txtSLG, TextBox txtTLG, DataGridView dgv)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSHangHoa();
            dgv.DataSource = bs;
            txtMHH.DataBindings.Add("Text", dgv.DataSource, "MAHH", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTHH.DataBindings.Add("Text", dgv.DataSource, "TENHH", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSL.DataBindings.Add("Text", dgv.DataSource, "SOLUONG", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbMDVT.DataBindings.Add("SelectedValue", dgv.DataSource, "MADVT", false, DataSourceUpdateMode.OnPropertyChanged);
            dt.DataBindings.Add("Text", dgv.DataSource, "NGAYHETHAN", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSLG.DataBindings.Add("Text", dgv.DataSource, "SOLUONGGIAM", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTLG.DataBindings.Add("Text", dgv.DataSource, "TILEGIAM", false, DataSourceUpdateMode.OnPropertyChanged);

            DonViTinhController dvtctrl = new DonViTinhController();
            dgv.Columns.Add(dvtctrl.LoadComboBoxColumn());
            dgv.Columns.Remove("MADVT");

            dvtctrl.LoadComboBoxDVT(cmbMDVT);
        }

        public void HienThiDataGridViewHHsaphethan(DataGridView dgv, int month)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSHHsaphethan(month);
            dgv.DataSource = bs;
        }

        public void LoadComboBoxHangHoa(ComboBox cmb)
        {
            cmb.DataSource = data.LayDSHangHoa();
            cmb.DisplayMember = "TENHH";
            cmb.ValueMember = "MAHH";
            //cmb.SelectedValue = "MAHH";
        }

        internal void Reload_bindings(TextBox txtMHH, TextBox txtTHH, TextBox txtSL, ComboBox cmbMDVT, DateTimeInput dt, TextBox txtSLG, TextBox txtTLG, DataGridView dgv)
        {
            try
            {
                txtMHH.DataBindings.RemoveAt(0);
                txtTHH.DataBindings.RemoveAt(0);
                txtSL.DataBindings.RemoveAt(0);
                cmbMDVT.DataBindings.RemoveAt(0);
                dt.DataBindings.RemoveAt(0);
                txtSLG.DataBindings.RemoveAt(0);
                txtTLG.DataBindings.RemoveAt(0);
            }
            catch
            {

            }

            txtMHH.DataBindings.Add("Text", dgv.DataSource, "MAHH", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTHH.DataBindings.Add("Text", dgv.DataSource, "TENHH", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSL.DataBindings.Add("Text", dgv.DataSource, "SOLUONG", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbMDVT.DataBindings.Add("SelectedValue", dgv.DataSource, "MADVT", false, DataSourceUpdateMode.OnPropertyChanged);
            dt.DataBindings.Add("Text", dgv.DataSource, "NGAYHETHAN", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSLG.DataBindings.Add("Text", dgv.DataSource, "SOLUONGGIAM", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTLG.DataBindings.Add("Text", dgv.DataSource, "TILEGIAM", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public DataGridViewComboBoxColumn LoadComboBoxColumn()
        {
            DataGridViewComboBoxColumn colma = new DataGridViewComboBoxColumn();
            colma.DataSource = data.LayDSHangHoa();
            colma.DisplayMember = "TENHH";
            colma.ValueMember = "MAHH";
            colma.HeaderText = "Mã sản phẩm";
            colma.DataPropertyName = "MAHH"; //Cot MASP trong bang TONKHO
            return colma;
        }
        string strTenHangHoa;

        public ListViewItem.ListViewSubItem LoadListViewSubItemHangHoa(string str)
        {
            ListViewItem.ListViewSubItem subI = new ListViewItem.ListViewSubItem();
            DataTable dt = data.LayDSHangHoa();
            subI.Tag = dt;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MAHH"].ToString() == str)
                    strTenHangHoa = dr["TENHH"].ToString();

            }
            subI.Text = strTenHangHoa;
            return subI;
        }

        public void AddNewRow()
        {
            data.AddNewRow();
        }

        public void TimKiemHH(string MaHH, string tenHH, DateTimeInput start, DateTimeInput end, Int32 beginCount, Int32 EndCount, DataGridView dg)
        {
            DataTable tbl = data.TimKiemHangHoaNew(MaHH, tenHH, start.Value.Date, end.Value.Date, beginCount, EndCount);

            dg.DataSource = tbl;

        }
        /*   string strdon_gia;
           public string LayDonGia(string tenhang)
           {
               DataTable dtb = data.LayDSHangHoa();
               foreach (DataRow dtr in dtb.Rows)
               {
                   if (dtr["TENHH"].ToString() == tenhang)
                   {
                       strdon_gia = dtr["DONGIA"].ToString();
                       break;
                   }
               }
               return strDonGia;
           }*/
        public void Update()
        {
            data.Update();
        }

        public void Update_to_database(System.Windows.Forms.DataGridView bindingSource1)
        {
            data.Update_to_database(bindingSource1);
        }
    }
}
