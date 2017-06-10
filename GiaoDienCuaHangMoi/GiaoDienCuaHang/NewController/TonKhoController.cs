using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GiaoDienCuaHang.DataLayer;
using DevComponents.Editors.DateTimeAdv;

namespace GiaoDienCuaHang.NewController
{
    public class TonKhoController
    {
        TonKhoData data = new TonKhoData();
        public void HienThiDataGridView(DateTimeInput dateTime, ComboBox cmbMSP, TextBox txtSLT, DataGridView dgv)
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
        }
        public void Update()
        {
            data.Update();
        }
    }
}
