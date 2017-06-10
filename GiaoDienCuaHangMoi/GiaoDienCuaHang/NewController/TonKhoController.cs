using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GiaoDienCuaHang.DataLayer;
using DevComponents.Editors.DateTimeAdv;
using DevComponents.DotNetBar.Controls;

namespace GiaoDienCuaHang.NewController
{
    public class TonKhoController
    {
        TonKhoData data = new TonKhoData();
        public void HienThiDataGridView(DateTimeInput dateTime, ComboBox cmbMSP, TextBox txtSLT, ComboBoxEx cmbMSPFind, DataGridView dgv)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSTonKho();
            dgv.DataSource = bs;
 
            dateTime.DataBindings.Add("Text", bs, "THOIGIAN");
            cmbMSP.DataBindings.Add("SelectedValue", bs, "MAHH");
            txtSLT.DataBindings.Add("Text", bs, "SLTON");

            HangHoaController hhCtrl = new HangHoaController();
            dgv.Columns.Add(hhCtrl.LoadComboBoxColumn());
            dgv.Columns.Remove("MAHH");

            hhCtrl.LoadComboBoxHangHoa(cmbMSP);

            HangHoaController hhCtrl1 = new HangHoaController();
            hhCtrl1.LoadComboBoxHangHoa(cmbMSPFind);
        }
        public void Update()
        {
            data.Update();
        }
    }
}
