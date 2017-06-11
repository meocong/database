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
    public partial class frmThongKeNhaCungCap : DevComponents.DotNetBar.OfficeForm
    {
        public frmThongKeNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmThongKeNhaCungCap_Shown(object sender, EventArgs e)
        {
            GiaoDienCuaHang.DataLayer.NhaCungCapData ncc = new GiaoDienCuaHang.DataLayer.NhaCungCapData();
            DataTable TBL = ncc.LayDSNhaCungCap();
            CrystalReportNhaCungCap report = new CrystalReportNhaCungCap();
            report.SetDataSource(TBL);
            crystalReportViewer1.ReportSource = report;
        }

    }
}