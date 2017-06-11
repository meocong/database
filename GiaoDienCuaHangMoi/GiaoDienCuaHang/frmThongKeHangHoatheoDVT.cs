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
    public partial class frmThongKeHangHoatheoDVT : DevComponents.DotNetBar.OfficeForm
    {
        public frmThongKeHangHoatheoDVT()
        {
            InitializeComponent();
        }

        private void buttonchon_Click_1(object sender, EventArgs e)
        {
            String dvt = comboBox1.SelectedValue.ToString();
            GiaoDienCuaHang.DataLayer.HangHoaData hh = new GiaoDienCuaHang.DataLayer.HangHoaData();
            CRHangHoa report = new CRHangHoa();
            report.SetDataSource(hh.Lay_vw_DVTcodk(dvt));
            report.SetParameterValue("donvitinh", comboBox1.Text);
            crystalReportViewer1.ReportSource = report;
        }

        private void frmThongKeHangHoatheoDVT_Load_1(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.DonViTinhData dvtdata = new GiaoDienCuaHang.DataLayer.DonViTinhData();
            comboBox1.DataSource = dvtdata.LayDSDonViTinh();
            comboBox1.DisplayMember = "TENDVT";
            comboBox1.ValueMember = "MADVT";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            String dvt = comboBox1.SelectedValue.ToString();
            GiaoDienCuaHang.DataLayer.HangHoaData hh = new GiaoDienCuaHang.DataLayer.HangHoaData();
            CRHangHoa report = new CRHangHoa();
            report.SetDataSource(hh.Lay_vw_DVTcodk(dvt));
            report.SetParameterValue("dvt", comboBox1.Text);
            crystalReportViewer1.ReportSource = report;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            String dvt = comboBox1.SelectedValue.ToString();
            GiaoDienCuaHang.DataLayer.HangHoaData hh = new GiaoDienCuaHang.DataLayer.HangHoaData();
            CRHangHoaCopy report = new CRHangHoaCopy();
            report.SetDataSource(hh.Lay_vw_DVT());
            crystalReportViewer1.ReportSource = report;
        }
    }
}