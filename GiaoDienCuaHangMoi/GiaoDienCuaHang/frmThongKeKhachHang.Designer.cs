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
            ((System.ComponentModel.ISupportInitialize)(this.qLCHmoiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHACHHANGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1151, 584);
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
            // frmThongKeKhachHang
            // 
            this.ClientSize = new System.Drawing.Size(1151, 584);
            this.Controls.Add(this.crystalReportViewer1);
            this.DoubleBuffered = true;
            this.Name = "frmThongKeKhachHang";
            this.Text = "frmThongKeKhachHang";
            this.Load += new System.EventHandler(this.frmThongKeKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLCHmoiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHACHHANGBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private QLCHmoiDataSet qLCHmoiDataSet;
        private System.Windows.Forms.BindingSource kHACHHANGBindingSource;
        private QLCHmoiDataSetTableAdapters.KHACHHANGTableAdapter kHACHHANGTableAdapter;
    }
}