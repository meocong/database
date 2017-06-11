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
    public partial class frmThongKePhieuDatHang : DevComponents.DotNetBar.OfficeForm
    {
        public frmThongKePhieuDatHang()
        {
            InitializeComponent();
        }

        //private void buttonhienthi_Click(object sender, EventArgs e)
        //{
        //    String nv = comboBox1.SelectedValue.ToString();
        //    GiaoDienCuaHang.DataLayer.PhieuDatHangData pdh1 = new GiaoDienCuaHang.DataLayer.PhieuDatHangData();
        //    CrystalReportPhieudathang report = new CrystalReportPhieudathang();

        //    report.SetDataSource(pdh1.LayDS_PDH(nv));
        //    report.SetParameterValue("tennv", comboBox1.Text);


        //    crystalReportViewer1.ReportSource = report;
        //}

        private void frmThongKePhieuDatHang_Load(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.NhaCungCapData nccdata = new GiaoDienCuaHang.DataLayer.NhaCungCapData();
            comboBox1.DataSource = nccdata.LayDSNhaCungCap();
            comboBox1.DisplayMember = "TENNCC";
            comboBox1.ValueMember = "MANCC";

        }




        private void buttonX2_Click(object sender, EventArgs e)
        {
            String cc = comboBox1.SelectedValue.ToString();
            GiaoDienCuaHang.DataLayer.PhieuDatHangData pdh1 = new GiaoDienCuaHang.DataLayer.PhieuDatHangData();
            CRPhieuDatHangCopy parameter = new CRPhieuDatHangCopy();
            parameter.SetDataSource(pdh1.LayDS_PDHkhongdk());
            crystalReportViewer1.ReportSource = parameter;
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            String cc = comboBox1.SelectedValue.ToString();
            GiaoDienCuaHang.DataLayer.PhieuDatHangData pdh1 = new GiaoDienCuaHang.DataLayer.PhieuDatHangData();
            CRPhieuDatHang parameter = new CRPhieuDatHang();
            parameter.SetDataSource(pdh1.LayDS_PDH(cc));
            parameter.SetParameterValue("nhacc", comboBox1.Text);
            crystalReportViewer1.ReportSource = parameter;

        }
    }
}