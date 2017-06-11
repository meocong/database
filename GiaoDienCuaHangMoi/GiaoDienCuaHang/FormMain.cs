using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GiaoDienCuaHang.Controller;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;

namespace GiaoDienCuaHang
{
    public partial class FormMain : Office2007RibbonForm
    {
        frmTonKho tonk = null;

        frmThongKeDonViTinh thongkedvt = null;
        frmThongKeHangHoatheoDVT thongkehhtdvt = null;
        frmThongKeKhachHang thongkekh = null;
        frmThongKeNhaCungCap thongkencc = null;
        frmThongKeNhanVien thongkenv = null;
        frmThongKePhieuBanHang thongkepbh = null;
        frmThongKePhieuDatHang thongkepdh = null;
        frmThongKePhieuNhanHang thongkepnh = null;
        frmThongKePhieuSuCo thongkepsc = null;
        frmThongKeTonKho thongketkho = null;

        frmKhachHang kh = null;
        frmNhaCungCap ncc = null;
        frmHangHoa hh = null;
        frmDonViTinh dvt = null;
        frmLapPhieuBanHang pbh = null;
        frmPhieuDatHang pdh = null;
        frmPhieuNhanHang pnh = null;
        fLapPhieuSuCo psc = null;
        frmTimKiemKhachHang tkkh = null;
        frmTimKiemNhaCungCap tkncc = null;
        frmTimKiemHangHoa tkhh = null;
        frmTimKiemDVT tkdvt = null;
        frmTimKiemPhieuBanHang tkpbh = null;
        frmTimKiemPhieuDatHang tkpdh = null;
        frmTimKiemPhieuNhanHang tkpnh = null;
        frmNhanVien nv = null;
        frmLoaiNhanVien loainv = null;
        frmDanhSachHangHoaSapHetHan hethan = null;


        public FormMain()
        {
            InitializeComponent();
        }

        #region Change display
        private void buttonItem14_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Blue;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Black;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Black;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Silver;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.VisualStudio2012Dark;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Windows7Blue;
            _base_Color = styleManager1.ManagerColorTint;

        }

        private Color _base_Color = Color.Blue;
        private bool _color_Selected = false;

        private void colorPickerDropDown1_SelectedColorChanged(object sender, EventArgs e)
        {
            _color_Selected = true;
            _base_Color = colorPickerDropDown1.SelectedColor;
        }

        private void colorPickerDropDown1_ExpandChange(object sender, EventArgs e)
        {
            if (_color_Selected)
            {
                _base_Color = colorPickerDropDown1.SelectedColor;

            }

            styleManager1.ManagerColorTint = _base_Color;
            styleManager1.MetroColorParameters = new MetroColorGeneratorParameters(_base_Color, _base_Color);
            _color_Selected = false;
        }

        private void colorPickerDropDown1_ColorPreview(object sender, ColorPreviewEventArgs e)
        {
            styleManager1.MetroColorParameters = new MetroColorGeneratorParameters(e.Color, e.Color);
            styleManager1.ManagerColorTint = e.Color;
        }
        #endregion

        private void disable_menu()
        {
            //foreach (ToolStripMenuItem menuitem in menuStrip1.Items)
            //{

            //    if (i == 1 || i == 2 || i == 3 || i == 5 || i == 4 || i == 6)
            //        menuitem.Enabled = false;
            //    else
            //        menuitem.Enabled = true;
            //    i++;
            //}
            foreach (ButtonItem item in ribbonBar2.Items)
            {
                item.Enabled = false;
            }
            //i = 0;
            //foreach (ToolStripMenuItem mnuitem in ToolStripMenuItemCT.DropDownItems)
            //{

            //    if (i == 0)
            //        mnuitem.Enabled = true;
            //    else
            //        mnuitem.Enabled = false;
            //    i++;
            //}
            ribbonPanel2.Enabled = false;
            ribbonPanel3.Enabled = false;
            ribbonPanel6.Enabled = false;
            buttonItem9.Enabled = false;
            buttonItem6.Enabled = false;
            buttonItem7.Enabled = false;
            buttonItem8.Enabled = false;
            buttonItem10.Enabled = false;
        }

        private void LogIn()
        {
            frmDangNhap dangnhap = new frmDangNhap();
            dangnhap.textBoxU.Text = "";
            dangnhap.textBoxP.Text = "";
            if (dangnhap.ShowDialog() == DialogResult.OK)
            {
                string username = dangnhap.textBoxU.Text;
                string password = dangnhap.textBoxP.Text;
                NhanVienController nv = new NhanVienController();
                int ketqua = nv.Dangnhap(username, password);
                if (ketqua == 0)
                {
                    MessageBox.Show("Không tồn tại người dùng này!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    disable_menu();

                }
                else
                {
                    if (ketqua == 1)
                    {
                        MessageBox.Show("Sai mật khẩu!");
                        disable_menu();
                    }
                    else
                    {
                        phanquyen(Utilities.nhanvien.loainv.MaloaiNV);
                        buttonItem20.Enabled = false;
                        //dangnhap.Dispose();

                        if (hethan == null || hethan.IsDisposed)
                        {
                            hethan = new frmDanhSachHangHoaSapHetHan();
                            hethan.MdiParent = this;
                        }
                        hethan.Show();

                        if (hethan.dataGridView1.Rows.Count < 2)
                        {
                            hethan.Close();
                        }
                    }
                }
            }
            else
            {
                disable_menu();
                buttonItem20.Enabled = true;
                buttonItem2.Enabled = false;
            }
        }

        private void DisableAll()
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.LogIn();
        }


        private void DNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LogIn();
        }


        private void DXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disable_menu();
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kh == null || kh.IsDisposed)
                kh = new frmKhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void NCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ncc == null || ncc.IsDisposed)
                ncc = new frmNhaCungCap();
            ncc.MdiParent = this;
            ncc.Show();
        }

        private void HHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hh == null || hh.IsDisposed)
                hh = new frmHangHoa();
            hh.MdiParent = this;
            hh.Show();
        }

        private void DVTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dvt == null || dvt.IsDisposed)
                dvt = new frmDonViTinh();
            dvt.MdiParent = this;
            dvt.Show();
        }

        private void toolStripButtonKH_Click(object sender, EventArgs e)
        {
            if (kh == null || kh.IsDisposed)
                kh = new frmKhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void toolStripButtonNCC_Click(object sender, EventArgs e)
        {
            if (ncc == null || ncc.IsDisposed)
                ncc = new frmNhaCungCap();
            ncc.MdiParent = this;
            ncc.Show();
        }

        private void toolStripButtonHH_Click(object sender, EventArgs e)
        {
            if (hh == null || hh.IsDisposed)
                hh = new frmHangHoa();
            hh.MdiParent = this;
            hh.Show();
        }

        private void taskItemKH_Click(object sender, EventArgs e)
        {
            if (kh == null || kh.IsDisposed)
                kh = new frmKhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void taskItemNCC_Click(object sender, EventArgs e)
        {
            if (ncc == null || ncc.IsDisposed)
                ncc = new frmNhaCungCap();
            ncc.MdiParent = this;
            ncc.Show();
        }

        private void taskItemHH_Click(object sender, EventArgs e)
        {
            if (hh == null || hh.IsDisposed)
                hh = new frmHangHoa();
            hh.MdiParent = this;
            hh.Show();
        }

        private void taskItemDVT_Click(object sender, EventArgs e)
        {
            if (dvt == null || dvt.IsDisposed)
                dvt = new frmDonViTinh();
            dvt.MdiParent = this;
            dvt.Show();
        }

        private void BHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbh == null || pbh.IsDisposed)
                pbh = new frmLapPhieuBanHang();
            pbh.MdiParent = this;
            pbh.Show();
        }

        private void DHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pdh == null || pdh.IsDisposed)
                pdh = new frmPhieuDatHang();
            pdh.MdiParent = this;
            pdh.Show();
        }

        private void NHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnh == null || pnh.IsDisposed)
                pnh = new frmPhieuNhanHang();
            pnh.MdiParent = this;
            pnh.Show();
        }

        private void SCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (psc == null || psc.IsDisposed)
                psc = new fLapPhieuSuCo();
            psc.MdiParent = this;
            psc.Show();
        }

        private void toolStripButtonPBH_Click(object sender, EventArgs e)
        {
            if (pbh == null || pbh.IsDisposed)
                pbh = new frmLapPhieuBanHang();
            pbh.MdiParent = this;
            pbh.Show();
        }

        private void toolStripButtonPDH_Click(object sender, EventArgs e)
        {
            if (pdh == null || pdh.IsDisposed)
                pdh = new frmPhieuDatHang();
            pdh.MdiParent = this;
            pdh.Show();
        }

        private void toolStripButtonPNH_Click(object sender, EventArgs e)
        {
            if (pnh == null || pnh.IsDisposed)
                pnh = new frmPhieuNhanHang();
            pnh.MdiParent = this;
            pnh.Show();
        }

        private void taskItemBH_Click(object sender, EventArgs e)
        {
            if (pbh == null || pbh.IsDisposed)
                pbh = new frmLapPhieuBanHang();
            pbh.MdiParent = this;
            pbh.Show();
        }

        private void taskItemDH_Click(object sender, EventArgs e)
        {
            if (pdh == null || pdh.IsDisposed)
                pdh = new frmPhieuDatHang();
            pdh.MdiParent = this;
            pdh.Show();
        }

        private void taskItemNH_Click(object sender, EventArgs e)
        {
            if (pnh == null || pnh.IsDisposed)
                pnh = new frmPhieuNhanHang();
            pnh.MdiParent = this;
            pnh.Show();
        }

        private void taskItemSC_Click(object sender, EventArgs e)
        {
            if (psc == null || psc.IsDisposed)
                psc = new fLapPhieuSuCo();
            psc.MdiParent = this;
            psc.Show();
        }



        private void TKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tkkh == null || tkkh.IsDisposed)
                tkkh = new frmTimKiemKhachHang();
            tkkh.MdiParent = this;
            tkkh.Show();
        }

        private void TNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tkncc == null || tkncc.IsDisposed)
                tkncc = new frmTimKiemNhaCungCap();
            tkncc.MdiParent = this;
            tkncc.Show();
        }

        private void THHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tkhh == null || tkhh.IsDisposed)
                tkhh = new frmTimKiemHangHoa();
            tkhh.MdiParent = this;
            tkhh.Show();
        }

        private void TDVTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tkdvt == null || tkdvt.IsDisposed)
                tkdvt = new frmTimKiemDVT();
            tkdvt.MdiParent = this;
            tkdvt.Show();
        }

        private void TPBHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tkpbh == null || tkpbh.IsDisposed)
                tkpbh = new frmTimKiemPhieuBanHang();
            tkpbh.MdiParent = this;
            tkpbh.Show();
        }

        private void TPDHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tkpdh == null || tkpdh.IsDisposed)
                tkpdh = new frmTimKiemPhieuDatHang();
            tkpdh.MdiParent = this;
            tkpdh.Show();
        }

        private void TPNHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tkpnh == null || tkpnh.IsDisposed)
                tkpnh = new frmTimKiemPhieuNhanHang();
            tkpnh.MdiParent = this;
            tkpnh.Show();
        }

        private void toolStripButtonTKH_Click(object sender, EventArgs e)
        {
            if (tkkh == null || tkkh.IsDisposed)
                tkkh = new frmTimKiemKhachHang();
            tkkh.MdiParent = this;
            tkkh.Show();
        }

        private void toolStripButtonTNCC_Click(object sender, EventArgs e)
        {
            if (tkncc == null || tkncc.IsDisposed)
                tkncc = new frmTimKiemNhaCungCap();
            tkncc.MdiParent = this;
            tkncc.Show();
        }


        private void thongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkekh == null || thongkekh.IsDisposed)
                thongkekh = new frmThongKeKhachHang();
            thongkekh.MdiParent = this;
            thongkekh.Show();
        }

        private void TKHHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkehhtdvt == null || thongkehhtdvt.IsDisposed)
                thongkehhtdvt = new frmThongKeHangHoatheoDVT();
            thongkehhtdvt.MdiParent = this;
            thongkehhtdvt.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nv == null || nv.IsDisposed)
                nv = new frmNhanVien();
            nv.MdiParent = this;
            nv.Show();
        }


        private void phanquyen(string Phanquyen)
        {
            switch (Phanquyen)
            {
                case "MNV001":
                    QUANLY();
                    break;
                case "MNV002":
                    BANHANG();
                    break;
                default:
                    disable_menu();
                    break;
            }
        }

        private void BANHANG()
        {

            int i = 0;
            //foreach (ToolStripMenuItem mnuitem in menuStrip1.Items)
            //{


            //    if (i == 4)
            //        mnuitem.Enabled = false;
            //    else
            //        mnuitem.Enabled = true;
            //    i++;


            //}
            //i = 0;
            //foreach (ToolStripMenuItem mnuitem in TTToolStripMenuItem.DropDownItems)
            //{

            //    if (i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16)
            //        mnuitem.Enabled = false;
            //    else
            //        mnuitem.Enabled = true;
            //    i++;
            //}
            //i = 0;
            //foreach (ToolStripMenuItem mnuitem in QLToolStripMenuItem.DropDownItems)
            //{

            //    if (i == 1 || i == 2 || i == 4||i==5)
            //        mnuitem.Enabled = false;
            //    else
            //        mnuitem.Enabled = true;
            //    i++;
            //}
            //i = 0;
            //foreach (ToolStripMenuItem mnuitem in LPToolStripMenuItem.DropDownItems)
            //{

            //    if (i == 1 || i == 2)
            //        mnuitem.Enabled = false;
            //    else
            //        mnuitem.Enabled = true;
            //    i++;
            //}
            //i = 0;
            //foreach (ToolStripMenuItem mnuitem in ToolStripMenuItemCT.DropDownItems)
            //{

            //    if (i == 1||i==4)
            //        mnuitem.Enabled = true;
            //    else
            //        mnuitem.Enabled = false;
            //    i++;
            //}


            i = 0;
            foreach (ButtonItem item in ribbonBar2.Items)
            {
                if (i == 0 || i == 1 || i == 2)
                {
                    item.Enabled = false;
                }
                else
                    item.Enabled = true;
                i++;
            }
            i = 0;
            ribbonPanel3.Enabled = true;
            buttonItem9.Enabled = false;
            buttonItem6.Enabled = true;
            buttonItem7.Enabled = true;
            buttonItem8.Enabled = true;
            buttonItem10.Enabled = true;
        }

        private void QUANLY()
        {
            //foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
            //{
            //    menuItem.Enabled = true;

            //}
            //int i = 0;
            //foreach (ToolStripMenuItem mnuitem in ToolStripMenuItemCT.DropDownItems)
            //{

            //    if (i == 0)
            //        mnuitem.Enabled = false;
            //    else
            //        mnuitem.Enabled = true;
            //    i++;
            //}
            foreach (ButtonItem item in ribbonBar2.Items)
            {
                item.Enabled = true;

            }
            ribbonPanel2.Enabled = true;
            ribbonPanel3.Enabled = true;
            ribbonPanel6.Enabled = true;
            buttonItem9.Enabled = true;
            buttonItem6.Enabled = true;
            buttonItem7.Enabled = true;
            buttonItem8.Enabled = true;
            buttonItem10.Enabled = true;
        }

        private void tknvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkenv == null || thongkenv.IsDisposed)
                thongkenv = new frmThongKeNhanVien();
            thongkenv.MdiParent = this;
            thongkenv.Show();
        }

        private void TKNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkencc == null || thongkencc.IsDisposed)
                thongkencc = new frmThongKeNhaCungCap();
            thongkencc.MdiParent = this;
            thongkencc.Show();
        }

        private void TKTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongketkho == null || thongketkho.IsDisposed)
                thongketkho = new frmThongKeTonKho();
            thongketkho.MdiParent = this;
            thongketkho.Show();
        }

        private void thốngKêĐơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkedvt == null || thongkedvt.IsDisposed)
                thongkedvt = new frmThongKeDonViTinh();
            thongkedvt.MdiParent = this;
            thongkedvt.Show();
        }

        private void thốngKêPhiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkepbh == null || thongkepbh.IsDisposed)
                thongkepbh = new frmThongKePhieuBanHang();
            thongkepbh.MdiParent = this;
            thongkepbh.Show();
        }

        private void thốngKêPhiếuNhậnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkepnh == null || thongkepnh.IsDisposed)
                thongkepnh = new frmThongKePhieuNhanHang();
            thongkepnh.MdiParent = this;
            thongkepnh.Show();
        }

        private void thốngKêPhiếuĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkepdh == null || thongkepdh.IsDisposed)
                thongkepdh = new frmThongKePhieuDatHang();
            thongkepdh.MdiParent = this;
            thongkepdh.Show();
        }

        private void thốngKêPhiếuSựCốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thongkepsc == null || thongkepsc.IsDisposed)
                thongkepsc = new frmThongKePhieuSuCo();
            thongkepsc.MdiParent = this;
            thongkepsc.Show();
        }

        private void saoChépDựPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK)
            {

                string sql = " backup database QLCHmoi to disk='" + s.FileName.ToString() + "'";
                DataService dt = new DataService();
                SqlCommand cm = new SqlCommand(sql);
                dt.Load(cm);
                MessageBox.Show("Sao Lưu thành công");
            }
        }

        private void khôiPhụcDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                string sql = " use master restore database QLCHmoi from disk='" + op.FileName.ToString() + "'";
                DataService dt = new DataService();
                SqlCommand cm = new SqlCommand(sql);
                dt.Load(cm);
                MessageBox.Show("Phục hồi dữ liệu thành công");
            }
        }

        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tonk == null || tonk.IsDisposed)
                tonk = new frmTonKho();
            tonk.MdiParent = this;
            tonk.Show();
        }

        private void HDSDToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }

        private void TGToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap();
            dangnhap.textBoxU.Text = "";
            dangnhap.textBoxP.Text = "";
            if (dangnhap.ShowDialog() == DialogResult.OK)
            {
                string username = dangnhap.textBoxU.Text;
                string password = dangnhap.textBoxP.Text;
                NhanVienController nv = new NhanVienController();
                int ketqua = nv.Dangnhap(username, password);
                if (ketqua == 0)
                {
                    MessageBox.Show("Không tồn tại người dùng này!");
                    disable_menu();
                    buttonItem20.Enabled = true;
                    buttonItem2.Enabled = false;
                }
                else
                {
                    if (ketqua == 1)
                    {
                        MessageBox.Show("Sai mật khẩu!");
                        disable_menu();
                        buttonItem20.Enabled = true;
                        buttonItem2.Enabled = false;
                    }
                    else
                    {
                        phanquyen(Utilities.nhanvien.loainv.MaloaiNV);
                        buttonItem20.Enabled = false;
                        buttonItem2.Enabled = true;

                    }
                }
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            disable_menu();
            buttonItem20.Enabled = true;
            buttonItem2.Enabled = false;
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (kh == null || kh.IsDisposed)
                kh = new frmKhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (ncc == null || ncc.IsDisposed)
                ncc = new frmNhaCungCap();
            ncc.MdiParent = this;
            ncc.Show();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (hh == null || hh.IsDisposed)
                hh = new frmHangHoa();
            hh.MdiParent = this;
            hh.Show();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            if (pbh == null || pbh.IsDisposed)
                pbh = new frmLapPhieuBanHang();
            pbh.MdiParent = this;
            pbh.Show();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            if (pdh == null || pdh.IsDisposed)
                pdh = new frmPhieuDatHang();
            pdh.MdiParent = this;
            pdh.Show();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (pnh == null || pnh.IsDisposed)
                pnh = new frmPhieuNhanHang();
            pnh.MdiParent = this;
            pnh.Show();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            if (tkncc == null || tkncc.IsDisposed)
                tkncc = new frmTimKiemNhaCungCap();
            tkncc.MdiParent = this;
            tkncc.Show();
        }

        private void buttonItem11_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            if (psc == null || psc.IsDisposed)
                psc = new fLapPhieuSuCo();
            psc.MdiParent = this;
            psc.Show();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            if (kh == null || kh.IsDisposed)
                kh = new frmKhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            if (ncc == null || ncc.IsDisposed)
                ncc = new frmNhaCungCap();
            ncc.MdiParent = this;
            ncc.Show();
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            if (hh == null || hh.IsDisposed)
                hh = new frmHangHoa();
            hh.MdiParent = this;
            hh.Show();
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            if (dvt == null || dvt.IsDisposed)
                dvt = new frmDonViTinh();
            dvt.MdiParent = this;
            dvt.Show();
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            if (nv == null || nv.IsDisposed)
                nv = new frmNhanVien();
            nv.MdiParent = this;
            nv.Show();
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            if (tonk == null || tonk.IsDisposed)
                tonk = new frmTonKho();
            tonk.MdiParent = this;
            tonk.Show();
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK)
            {

                string sql = " backup database QLCHmoi to disk='" + s.FileName.ToString() + "'";
                DataService dt = new DataService();
                SqlCommand cm = new SqlCommand(sql);
                dt.Load(cm);
                MessageBox.Show("Sao Lưu thành công");
            }
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                string sql = " use master restore database QLCHmoi from disk='" + op.FileName.ToString() + "'";
                DataService dt = new DataService();
                SqlCommand cm = new SqlCommand(sql);
                dt.Load(cm);
                MessageBox.Show("Phục hồi dữ liệu thành công");
            }
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            if (pbh == null || pbh.IsDisposed)
                pbh = new frmLapPhieuBanHang();
            pbh.MdiParent = this;
            pbh.Show();
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            if (pdh == null || pdh.IsDisposed)
                pdh = new frmPhieuDatHang();
            pdh.MdiParent = this;
            pdh.Show();
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            if (pnh == null || pnh.IsDisposed)
                pnh = new frmPhieuNhanHang();
            pnh.MdiParent = this;
            pnh.Show();
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            if (psc == null || psc.IsDisposed)
                psc = new fLapPhieuSuCo();
            psc.MdiParent = this;
            psc.Show();
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            if (thongkencc == null || thongkencc.IsDisposed)
                thongkencc = new frmThongKeNhaCungCap();
            thongkencc.MdiParent = this;
            thongkencc.Show();
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            if (thongkehhtdvt == null || thongkehhtdvt.IsDisposed)
                thongkehhtdvt = new frmThongKeHangHoatheoDVT();
            thongkehhtdvt.MdiParent = this;
            thongkehhtdvt.Show();
        }

        private void buttonItem36_Click(object sender, EventArgs e)
        {
            if (thongketkho == null || thongketkho.IsDisposed)
                thongketkho = new frmThongKeTonKho();
            thongketkho.MdiParent = this;
            thongketkho.Show();
        }

        private void buttonItem37_Click(object sender, EventArgs e)
        {
            if (thongkekh == null || thongkekh.IsDisposed)
                thongkekh = new frmThongKeKhachHang();
            thongkekh.MdiParent = this;
            thongkekh.Show();
        }

        private void buttonItem41_Click(object sender, EventArgs e)
        {
            if (thongkedvt == null || thongkedvt.IsDisposed)
                thongkedvt = new frmThongKeDonViTinh();
            thongkedvt.MdiParent = this;
            thongkedvt.Show();
        }

        private void buttonItem38_Click(object sender, EventArgs e)
        {
            if (thongkenv == null || thongkenv.IsDisposed)
                thongkenv = new frmThongKeNhanVien();
            thongkenv.MdiParent = this;
            thongkenv.Show();
        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            if (thongkepbh == null || thongkepbh.IsDisposed)
                thongkepbh = new frmThongKePhieuBanHang();
            thongkepbh.MdiParent = this;
            thongkepbh.Show();
        }

        private void buttonItem40_Click(object sender, EventArgs e)
        {
            if (thongkepdh == null || thongkepdh.IsDisposed)
                thongkepdh = new frmThongKePhieuDatHang();
            thongkepdh.MdiParent = this;
            thongkepdh.Show();
        }

        private void buttonItem42_Click(object sender, EventArgs e)
        {
            if (thongkepnh == null || thongkepnh.IsDisposed)
                thongkepnh = new frmThongKePhieuNhanHang();
            thongkepnh.MdiParent = this;
            thongkepnh.Show();
        }

        private void buttonItem43_Click(object sender, EventArgs e)
        {
            if (thongkepsc == null || thongkepsc.IsDisposed)
                thongkepsc = new frmThongKePhieuSuCo();
            thongkepsc.MdiParent = this;
            thongkepsc.Show();
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.Show();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            if (tkkh == null || tkkh.IsDisposed)
                tkkh = new frmTimKiemKhachHang();
            tkkh.MdiParent = this;
            tkkh.Show();
        }

        private void buttonItem11_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonItem9_Click_1(object sender, EventArgs e)
        {
            if (loainv == null || loainv.IsDisposed)
                loainv = new frmLoaiNhanVien();
            loainv.MdiParent = this;
            loainv.Show();

        }

        private void buttonItem10_Click_1(object sender, EventArgs e)
        {
            if (hethan == null || hethan.IsDisposed)
            {
                hethan = new frmDanhSachHangHoaSapHetHan();
            }
            hethan.MdiParent = this;
            hethan.Show();
        }
    }
}