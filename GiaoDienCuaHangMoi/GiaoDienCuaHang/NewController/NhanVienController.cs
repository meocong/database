using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GiaoDienCuaHang.DataLayer;
using GiaoDienCuaHang.BusinessLayer;
using DevComponents.Editors.DateTimeAdv;
using DevComponents.DotNetBar.Controls;

namespace GiaoDienCuaHang.NewController
{
    class NhanVienController
    {
        NhanVienData data = new NhanVienData();

        public void HienThi(TextBox txtMNV, TextBox txtHT, TextBox txtDC, DateTimeInput dtngaysinh, TextBox txtDT, ComboBox cmbLoaiNV, ComboBox cmbGT, 
            TextBox txtUSER, TextBox txtPASS, ComboBoxEx cmbLoaiNvFind, ComboBoxEx cmbGTFind, DataGridView dgv)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = data.LayDSNhanVien();
            dgv.DataSource = bs;

            /*DataGridViewComboBoxColumn colLoaiNV = new DataGridViewComboBoxColumn();
             colLoaiNV.Items.Add("QUAN LY");
             colLoaiNV.Items.Add("BAN HANG");
             colLoaiNV.DataPropertyName = "LOAINV";
             colLoaiNV.HeaderText = "Loại Nhân Viên";
             dgv.Columns.Add(colLoaiNV);*/

            txtMNV.DataBindings.Add("Text", dgv.DataSource, "MANV");
            txtHT.DataBindings.Add("Text", dgv.DataSource, "HOTEN");
            txtDC.DataBindings.Add("Text", dgv.DataSource, "DIACHI");
            dtngaysinh.DataBindings.Add("Text", dgv.DataSource, "NGAYSINH");
            txtDT.DataBindings.Add("Text", dgv.DataSource, "DIENTHOAI");
            cmbLoaiNV.DataBindings.Add("SelectedValue", dgv.DataSource, "MALOAINV");
            cmbGT.DataBindings.Add("SelectedValue", dgv.DataSource, "GIOITINH");
            txtUSER.DataBindings.Add("Text", dgv.DataSource, "USERNAME");
            txtPASS.DataBindings.Add("Text", dgv.DataSource, "PASSWORDS");
            LoaiNhanVienController ctrlloainv = new LoaiNhanVienController();
            dgv.Columns.Add(ctrlloainv.LoadComboBoxColumn());
            //dgv.Columns.Remove("Loại Nhân viên");

            GioiTinhController ctrlgt = new GioiTinhController();
            dgv.Columns.Add(ctrlgt.LoadComboBoxColumn());
            //dgv.Columns.Remove("Colgioitinh");
            // Xoá cột Username,Passwords trong cơ sở dữ liệu khi hiện lên dataGridView
            dgv.Columns.Remove("USERNAME");
            dgv.Columns.Remove("PASSWORDS");
            dgv.Columns[7].Visible = false;


            ctrlloainv.LoadComboBoxLoaiNV(cmbLoaiNV);
            ctrlgt.LoadComboBoxGioiTinh(cmbGT);

            LoaiNhanVienController ctrlloainvFind = new LoaiNhanVienController();
            GioiTinhController ctrlgtFind = new GioiTinhController();
            ctrlloainvFind.LoadComboBoxLoaiNV(cmbLoaiNvFind);
            ctrlgtFind.LoadComboBoxGioiTinh(cmbGTFind);
        }

        public void Reload_bindings(TextBox txtMNV, TextBox txtHT, TextBox txtDC, DateTimeInput dtngaysinh, TextBox txtDT, ComboBox cmbLoaiNV, ComboBox cmbGT,
            TextBox txtUSER, TextBox txtPASS, ComboBoxEx cmbLoaiNvFind, ComboBoxEx cmbGTFind, DataGridView dgv)
        {
            try
            {
                txtMNV.DataBindings.RemoveAt(0);
                txtHT.DataBindings.RemoveAt(0);
                txtDC.DataBindings.RemoveAt(0);
                dtngaysinh.DataBindings.RemoveAt(0);
                txtDT.DataBindings.RemoveAt(0);
                cmbLoaiNV.DataBindings.RemoveAt(0);
                cmbGT.DataBindings.RemoveAt(0);
                txtUSER.DataBindings.RemoveAt(0);
                txtPASS.DataBindings.RemoveAt(0);
            }
            catch
            {

            }

            txtMNV.DataBindings.Add("Text", dgv.DataSource, "MANV");
            txtHT.DataBindings.Add("Text", dgv.DataSource, "HOTEN");
            txtDC.DataBindings.Add("Text", dgv.DataSource, "DIACHI");
            dtngaysinh.DataBindings.Add("Text", dgv.DataSource, "NGAYSINH");
            txtDT.DataBindings.Add("Text", dgv.DataSource, "DIENTHOAI");
            cmbLoaiNV.DataBindings.Add("SelectedValue", dgv.DataSource, "MALOAINV");
            cmbGT.DataBindings.Add("SelectedValue", dgv.DataSource, "GIOITINH");
            txtUSER.DataBindings.Add("Text", dgv.DataSource, "USERNAME");
            txtPASS.DataBindings.Add("Text", dgv.DataSource, "PASSWORDS");
            //LoaiNhanVienController ctrlloainv = new LoaiNhanVienController();
            //dgv.Columns.Add(ctrlloainv.LoadComboBoxColumn());
            //dgv.Columns.Remove("Loại Nhân viên");

            //GioiTinhController ctrlgt = new GioiTinhController();
            //dgv.Columns.Add(ctrlgt.LoadComboBoxColumn());
            //dgv.Columns.Remove("Colgioitinh");
            // Xoá cột Username,Passwords trong cơ sở dữ liệu khi hiện lên dataGridView
            //dgv.Columns.Remove("USERNAME");
            //dgv.Columns.Remove("PASSWORDS");
            //dgv.Columns[7].Visible = false;


            //ctrlloainv.LoadComboBoxLoaiNV(cmbLoaiNV);
            //ctrlgt.LoadComboBoxGioiTinh(cmbGT);

            //LoaiNhanVienController ctrlloainvFind = new LoaiNhanVienController();
            //GioiTinhController ctrlgtFind = new GioiTinhController();
            //ctrlloainvFind.LoadComboBoxLoaiNV(cmbLoaiNvFind);
            //ctrlgtFind.LoadComboBoxGioiTinh(cmbGTFind);
        }

        public void TimKiemNV(string text1, string text2, string text3, string text4, string selectedValue1, string selectedValue2, DataGridViewX dataGridView1)
        {
            DataTable tbl = data.TimKiemNhanVienNew(text1, text2, text3, text4, selectedValue1, selectedValue2);

            dataGridView1.DataSource = tbl;
        }

        public void AddNewRow()
        {
            data.AddNewRow();
        }

        string strTenNhanVien;

        public ListViewItem.ListViewSubItem LoadListViewSubItemNhanVien(string str)
        {
            ListViewItem.ListViewSubItem subI = new ListViewItem.ListViewSubItem();
            DataTable datatb = data.LayDSNhanVien();
            subI.Tag = datatb;
            foreach (DataRow dataR in datatb.Rows)
            {
                if (dataR["MANV"].ToString() == str)
                    strTenNhanVien = dataR["HOTEN"].ToString();
            }
            subI.Text = strTenNhanVien;
            return subI;
        }

        public void Update_to_database(System.Windows.Forms.DataGridView bindingSource1)
        {
            data.Update_to_database(bindingSource1);
        }

        public void LoadComboBoxNhanVien(ComboBox cmb)
        {
            cmb.DataSource = data.LayDSNhanVien();
            cmb.DisplayMember = "HOTEN";
            cmb.ValueMember = "MANV";
            cmb.SelectedValue = "MANV";
        }
        public int Dangnhap(String username, String password)
        {
            DataTable nd = data.LayNhanvien(username);
            if (nd.Rows.Count == 0)
                return 0;//Khong ton tai nguoi dung nay

            String matkhau_hethong = nd.Rows[0]["PASSWORDS"].ToString();//MNat khau trong CSDL

            if (matkhau_hethong != password)
            {
                return 1;//Sai mat khau
            }
            else
            {
                NhanVienInfo NV = new NhanVienInfo();
                NV.Username = nd.Rows[0]["USERNAME"].ToString();
                NV.Passwords = nd.Rows[0]["PASSWORDS"].ToString();
                LoaiNhanVienInfo lnv = new LoaiNhanVienInfo();
                lnv.MaloaiNV = nd.Rows[0]["MALOAINV"].ToString();
                NV.loainv = lnv;
                Utilities.nhanvien = NV;
                return 2;//Dang nhap thanh cong

            }
        }
        public void Update()
        {
            data.Update();
        }
    }
}
