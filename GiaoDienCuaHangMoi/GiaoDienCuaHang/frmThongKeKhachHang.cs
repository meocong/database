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
    public partial class frmThongKeKhachHang : DevComponents.DotNetBar.OfficeForm
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

        private void frmThongKeKhachHang_Shown(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.KhachHangData kh = new GiaoDienCuaHang.DataLayer.KhachHangData();
            DataTable tbl = kh.LayDSKhachHang("");
            CRKhachHang report = new CRKhachHang();
            report.SetDataSource(tbl);
            crystalReportViewer1.ReportSource = report;
        }


    }
}