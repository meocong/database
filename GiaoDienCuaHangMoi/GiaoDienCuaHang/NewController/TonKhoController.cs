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
        public void HienThiDataGridView(DateTimeInput dateTime, ComboBox cmbMSP, TextBox txtSLT, ComboBoxEx cmbMSPFind, DataGridView dgv, bool kt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSTonKho();
            dgv.DataSource = bs;

            if (kt == true)
            {
                return;
            }

            try
            {

                dateTime.DataBindings.RemoveAt(0);
                cmbMSP.DataBindings.RemoveAt(0);
                txtSLT.DataBindings.RemoveAt(0);
            }
            catch
            {

            }

            dateTime.DataBindings.Add("Text", dgv.DataSource, "THOIGIAN");
            cmbMSP.DataBindings.Add("SelectedValue", dgv.DataSource, "MAHH");
            txtSLT.DataBindings.Add("Text", dgv.DataSource, "SLTON");

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

        public void TimKiemTonKho(string v1, string v2, DataGridViewX dataGridView1)
        {
            System.Data.DataTable tbl = data.TimKiemTonKho(v1, v2);

            dataGridView1.DataSource = tbl;
        }

        public void TimKiemTonKho(string v1, DataGridViewX dataGridView1)
        {
            System.Data.DataTable tbl = data.TimKiemTonKho(v1);

            dataGridView1.DataSource = tbl;
        }

        public void Reload_bindings(DateTimeInput dateTimePicker1, ComboBoxEx comboBox1, TextBoxX textBox1, DataGridViewX dataGridView1)
        {
            try
            {
                dateTimePicker1.DataBindings.RemoveAt(0);
                comboBox1.DataBindings.RemoveAt(0);
                textBox1.DataBindings.RemoveAt(0);
            }
            catch
            {

            }


            dateTimePicker1.DataBindings.Add("Text", dataGridView1.DataSource, "THOIGIAN");
            comboBox1.DataBindings.Add("SelectedValue", dataGridView1.DataSource, "MAHH");
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "SLTON");
        }

        public void AddNewRow()
        {
            data.AddNewRow();
        }


        public void Update_to_database(System.Windows.Forms.DataGridView bindingSource1)
        {
            data.Update_to_database(bindingSource1);
        }
    }
}
