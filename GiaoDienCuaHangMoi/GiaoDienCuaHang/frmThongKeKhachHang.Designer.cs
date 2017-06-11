namespace GiaoDienCuaHang
{
    partial class frmThongKeKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.qLCHmoiDataSet = new GiaoDienCuaHang.QLCHmoiDataSet();
            this.kHACHHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kHACHHANGTableAdapter = new GiaoDienCuaHang.QLCHmoiDataSetTableAdapters.KHACHHANGTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.bttXemBaoCao = new System.Windows.Forms.Button();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.qLCHmoiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHACHHANGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1151, 449);
            this.crystalReportViewer1.TabIndex = 8;
            // 
            // qLCHmoiDataSet
            // 
            this.qLCHmoiDataSet.DataSetName = "QLCHmoiDataSet";
            this.qLCHmoiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kHACHHANGBindingSource
            // 
            this.kHACHHANGBindingSource.DataMember = "KHACHHANG";
            this.kHACHHANGBindingSource.DataSource = this.qLCHmoiDataSet;
            // 
            // kHACHHANGTableAdapter
            // 
            this.kHACHHANGTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 542);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // bttXemBaoCao
            // 
            this.bttXemBaoCao.Location = new System.Drawing.Point(477, 542);
            this.bttXemBaoCao.Name = "bttXemBaoCao";
            this.bttXemBaoCao.Size = new System.Drawing.Size(130, 23);
            this.bttXemBaoCao.TabIndex = 6;
            this.bttXemBaoCao.Text = "Xem Bao Cao";
            this.bttXemBaoCao.UseVisualStyleBackColor = true;
            this.bttXemBaoCao.Click += new System.EventHandler(this.bttXemBaoCao_Click);
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(317, 542);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(154, 20);
            this.txtMaKH.TabIndex = 5;
            // 
            // frmThongKeKhachHang
            // 
            this.ClientSize = new System.Drawing.Size(1151, 584);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttXemBaoCao);
            this.Controls.Add(this.txtMaKH);
            this.DoubleBuffered = true;
            this.Name = "frmThongKeKhachHang";
            this.Text = "frmThongKeKhachHang";
            this.Load += new System.EventHandler(this.frmThongKeKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLCHmoiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHACHHANGBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private QLCHmoiDataSet qLCHmoiDataSet;
        private System.Windows.Forms.BindingSource kHACHHANGBindingSource;
        private QLCHmoiDataSetTableAdapters.KHACHHANGTableAdapter kHACHHANGTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttXemBaoCao;
        private System.Windows.Forms.TextBox txtMaKH;
    }
}