using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace GiaoDienCuaHang
{
    public partial class frmThongKeTonKho : DevComponents.DotNetBar.OfficeForm
    {
        public frmThongKeTonKho()
        {
            InitializeComponent();
        }

        private void buttonhienthi_Click(object sender, EventArgs e)
        {
            String hh = comboBox1.SelectedValue.ToString();
            GiaoDienCuaHang.DataLayer.TonKhoData tk = new GiaoDienCuaHang.DataLayer.TonKhoData();
            CRTonKho parameter = new CRTonKho();
            parameter.SetDataSource(tk.Lay_vw_TK_TonKho_coDK(hh));
            parameter.SetParameterValue("tenhanghoa", comboBox1.Text);
            crystalReportViewer1.ReportSource = parameter;
        }

        private void frmThongKeTonKho_Load(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.HangHoaData hhdata = new GiaoDienCuaHang.DataLayer.HangHoaData();
            comboBox1.DataSource = hhdata.LayDSHangHoa();
            comboBox1.DisplayMember = "TENHH";
            comboBox1.ValueMember = "MAHH";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.TonKhoData tk = new GiaoDienCuaHang.DataLayer.TonKhoData();
            CRTonKhoCopy parameter = new CRTonKhoCopy();
            parameter.SetDataSource(tk.Lay_vw_TK_TonKho());
            crystalReportViewer1.ReportSource = parameter;
        }
    }
}