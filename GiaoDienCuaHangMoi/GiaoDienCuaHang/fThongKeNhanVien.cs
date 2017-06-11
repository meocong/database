using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiaoDienCuaHang
{
    public partial class fThongKeNhanVien : Form
    {
        public fThongKeNhanVien()
        {
            InitializeComponent();
        }

        private void frmThongKeNhanVien_Shown(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.NhanVienData nv = new GiaoDienCuaHang.DataLayer.NhanVienData();
            DataTable tbl = nv.LayDSNhanVien();
            CrystalReportNhanVien report = new CrystalReportNhanVien();
            report.SetDataSource(tbl);
            crystalReportViewer1.ReportSource = report;
        }

    }
}