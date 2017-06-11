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
    public partial class frmThongKeNhanVien : DevComponents.DotNetBar.OfficeForm
    {
        public frmThongKeNhanVien()
        {
            InitializeComponent();
        }

        private void frmThongKeNhanVien_Shown(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.NhanVienData nv = new GiaoDienCuaHang.DataLayer.NhanVienData();
            DataTable tbl = nv.LayDSNhanVien();
            CRNhanVien report = new CRNhanVien();
            report.SetDataSource(tbl);
            crystalReportViewer1.ReportSource = report;
        }
    }
}