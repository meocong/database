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
    public partial class frmThongKePhieuSuCo : DevComponents.DotNetBar.OfficeForm
    {
        public frmThongKePhieuSuCo()
        {
            InitializeComponent();
        }


        private void frmThongKePhieuSuCo_Load(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.HangHoaData hhdata = new GiaoDienCuaHang.DataLayer.HangHoaData();
            comboBox1.DataSource = hhdata.LayDSHangHoa();
            comboBox1.DisplayMember = "TENHH";
            comboBox1.ValueMember = "MAHH";

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            String hh = comboBox1.SelectedValue.ToString();
            GiaoDienCuaHang.DataLayer.PhieuSuCoData psc = new GiaoDienCuaHang.DataLayer.PhieuSuCoData();
            CRPhieuSuCo parameter = new CRPhieuSuCo();
            parameter.SetDataSource(psc.LayDS_PhieuSuCo(hh));
            parameter.SetParameterValue("tenhh", comboBox1.Text);
            crystalReportViewer1.ReportSource = parameter;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            String hh = comboBox1.SelectedValue.ToString();
            GiaoDienCuaHang.DataLayer.PhieuSuCoData psc = new GiaoDienCuaHang.DataLayer.PhieuSuCoData();
            CRPhieuSuCoCopy parameter = new CRPhieuSuCoCopy();
            parameter.SetDataSource(psc.LayDS_PhieuSuCokhongdk());
            crystalReportViewer1.ReportSource = parameter;
        }
    }
}