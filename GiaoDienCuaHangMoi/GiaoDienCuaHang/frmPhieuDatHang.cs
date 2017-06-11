using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using GiaoDienCuaHang.Controller;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace GiaoDienCuaHang
{
    public partial class frmPhieuDatHang : OfficeForm
    {
        ChiTietPhieuDatHangController CTRLpdh = new ChiTietPhieuDatHangController();
        PhieuDatHangController Ctrl = new PhieuDatHangController();
        int dem = 6;

        public frmPhieuDatHang()
        {
            InitializeComponent();
        }
        private void frmLapPhieuDatHang_Load(object sender, EventArgs e)
        {
            Ctrl.HienThiListView(listView2);
            Ctrl.HienThiComboBox(comboBoxMNCC, comboBoxMNV, comboBoxMSP);


            //Load combobox Tim Kiem
            PhieuDatHangController temp = new PhieuDatHangController();
            temp.HienThiComboBoxNCC(comboBox1);

            //Load combobox Nhan Vien
            PhieuDatHangController temp1 = new PhieuDatHangController();
            temp.HienThiComboBoxNV(comboBox4);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerator ie = listView1.SelectedItems.GetEnumerator();
            if (ie.MoveNext())
            {
                ListViewItem item = (ListViewItem)ie.Current;
                textBoxCTMPDH.Text = item.SubItems[1].Text;
                comboBoxMSP.Text = item.SubItems[2].Text;
                textBoxSL.Text = item.SubItems[3].Text;
                
            }
        }

        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            IEnumerator ie = listView2.SelectedItems.GetEnumerator();
           
            if (ie.MoveNext())
            {
                ListViewItem item = (ListViewItem)ie.Current;

                textBoxMPDH.Text = item.SubItems[1].Text;
                comboBoxMNCC.Text = item.SubItems[2].Text;
                comboBoxMNV.Text = item.SubItems[3].Text;
                dateTimePicker1.Text = item.SubItems[4].Text;
             
                CTRLpdh.HienThiListView(listView1,item.SubItems[1].Text);
            }

        }

        private void buttonThemCT_Click(object sender, EventArgs e)
        {
            //if(textBoxCTMPDH.Text!="" && comboBoxMSP.Text!="")
            //{
            //    if(Ctrl.KiemTraTTChiTietPhieuDatHang(listView1,textBoxCTMPDH.Text,comboBoxMSP.Text))
            //    {
            //        ListViewItem item = new ListViewItem();

            //        int i = listView1.Items.Count;
            //        i++;
            //        item.Text = i.ToString();
            //        item.SubItems.Add(textBoxCTMPDH.Text);
            //        item.SubItems.Add(comboBoxMSP.Text);
            //        item.SubItems.Add(textBoxSL.Text);
            //        item.SubItems.Add(comboBoxMSP.SelectedValue.ToString());
                    
            //        listView1.Items.Add(item);
            //    }
            //    this.comboBoxMSP.Text = "";
            //    this.textBoxSL.Text = "";
            //    this.textBoxSL.Focus();
            //}
            //else MessageBox.Show("Bạn chưa chọn mã phiếu và mã sản phẩm hoặc chưa chọn mã phiếu hoặc chưa chọn mã sản phẩm. Vui lòng chọn lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            if (textBoxMPDH.Text != "")
            {
                Ctrl.AddNewDetailOrders(textBoxMPDH.Text);
                Finding();

                this.comboBoxMSP.Text = "";
                this.textBoxSL.Text = "";
                //this.textBoxSL.Focus();
            }
            else MessageBox.Show("Bạn chưa chọn mã phiếu. Vui lòng chọn lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            Ctrl.AddNewOrders();
            Finding();

            this.textBoxMPDH.Text = "";
            this.comboBoxMNCC.Text = "";
            this.comboBoxMNV.Text = "";
        }

        private void buttonXoaCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                IEnumerator ie = listView1.SelectedItems.GetEnumerator();

                while (ie.MoveNext())
                {
                    ListViewItem item = (ListViewItem)ie.Current;
                    listView1.Items.Remove(item);
                }
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                IEnumerator ie = listView2.SelectedItems.GetEnumerator();

                while (ie.MoveNext())
                {
                    ListViewItem item = (ListViewItem)ie.Current;
                    listView2.Items.Remove(item);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn lưu thông tin này phải không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Ctrl.Luu_PhieuDatHang(textBoxMPDH, comboBoxMNCC, comboBoxMNV, dateTimePicker1);
                Ctrl.Luu_CTPhieuDatHang(listView1);
                Ctrl.HienThiListView(listView2);
                
            }
           
        }

       private void button4_Click(object sender, EventArgs e)
        {
            frmTimKiemPhieuDatHang tpdh = new frmTimKiemPhieuDatHang();
            tpdh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            //print.ShowDialog();

            if (print.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void textBoxCTMPDH_Validating(object sender, CancelEventArgs e)
        {
            if (this.textBoxMPDH.Text != this.textBoxCTMPDH.Text)
            {
                MessageBox.Show("Mã phiếu không hợp lệ");
                this.textBoxCTMPDH.Focus();
            }
        }

        private void textBoxMPDH_Validating(object sender, CancelEventArgs e)
        {
            this.textBoxCTMPDH.Text = this.textBoxMPDH.Text;
        }

        private void Finding()
        {
            if (dem > 0)
            {
                dem--;
                return;
            }

            string tempNCC = "";
            try
            {
                tempNCC = comboBox1.SelectedValue.ToString();
            }
            catch
            {

            }

            string tempNV = "";
            try
            {
                tempNV = comboBox4.SelectedValue.ToString();
            }
            catch
            {

            }
            Ctrl.FindingPDH(listView2, tempNCC, dateTimePicker3.Value.Date, dateTimePicker2.Value.Date, tempNV);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Finding();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            Finding();
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            Finding();
        }
    }
}