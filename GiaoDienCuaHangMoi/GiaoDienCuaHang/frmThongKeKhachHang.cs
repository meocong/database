using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiaoDienCuaHang
{
    public partial class frmThongKeKhachHang : Form
    {
        public frmThongKeKhachHang()
        {
            InitializeComponent();
        }

      

        private void frmThongKeKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLCHmoiDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            GiaoDienCuaHang.DataLayer.KhachHangData kh = new GiaoDienCuaHang.DataLayer.KhachHangData();
            DataTable tbl = kh.LayDSKhachHang("");
            CRKhachHang report = new CRKhachHang();
            report.SetDataSource(tbl);
            crystalReportViewer1.ReportSource = report;

        }

        /*private void frmThongKeKhachHang_Shown(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.KhachHangData kh = new GiaoDienCuaHang.DataLayer.KhachHangData();
            DataTable tbl = kh.LayDSKhachHang();
            CrystalReportKhachHang report = new CrystalReportKhachHang();
            report.SetDataSource(tbl);
            crystalReportViewer1.ReportSource = report;
        }*/


        private void bttXemBaoCao_Click(object sender, EventArgs e)
        {
            if(txtMaKH.Text == "")
            {
                GiaoDienCuaHang.DataLayer.KhachHangData kh = new GiaoDienCuaHang.DataLayer.KhachHangData();
                DataTable tbl = kh.LayDSKhachHang("");
                CrystalReportKhachHang report = new CrystalReportKhachHang();
                report.SetDataSource(tbl);
                crystalReportViewer1.ReportSource = report;
            }
            else
            {
                GiaoDienCuaHang.DataLayer.KhachHangData kh = new GiaoDienCuaHang.DataLayer.KhachHangData();
                DataTable tbl = kh.LayDSKhachHang(txtMaKH.Text);
                CrystalReportKhachHang report = new CrystalReportKhachHang();
                report.SetDataSource(tbl);
                crystalReportViewer1.ReportSource = report;
            }
        }


    }


    
}