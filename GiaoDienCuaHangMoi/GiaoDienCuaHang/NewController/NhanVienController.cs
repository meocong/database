﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GiaoDienCuaHang.DataLayer;
using GiaoDienCuaHang.BusinessLayer;
using DevComponents.Editors.DateTimeAdv;

namespace GiaoDienCuaHang.NewController
{
    class NhanVienController
    {
        NhanVienData data = new NhanVienData();

        public void HienThi(TextBox txtMNV, TextBox txtHT, TextBox txtDC, DateTimeInput dtngaysinh, TextBox txtDT, ComboBox cmbLoaiNV, ComboBox cmbGT, TextBox txtUSER, TextBox txtPASS, DataGridView dgv)
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
            dgv.Columns.Remove("Colloainv");

            GioiTinhController ctrlgt = new GioiTinhController();
            dgv.Columns.Add(ctrlgt.LoadComboBoxColumn());
            dgv.Columns.Remove("Colgioitinh");
            // Xoá cột Username,Passwords trong cơ sở dữ liệu khi hiện lên dataGridView
            dgv.Columns.Remove("USERNAME");
            dgv.Columns.Remove("PASSWORDS");


            ctrlloainv.LoadComboBoxLoaiNV(cmbLoaiNV);
            ctrlgt.LoadComboBoxGioiTinh(cmbGT);
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