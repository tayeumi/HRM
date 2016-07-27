namespace HRM.Forms
{
    partial class frmDanhSachHopDong_In
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
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImages = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnShowAll = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmployeeCode = new DevExpress.XtraEditors.TextEdit();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.ImageHD = new DevExpress.XtraEditors.PictureEdit();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HRM.frmWaiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridItem
            // 
            this.gridItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItem.Location = new System.Drawing.Point(0, 38);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.Size = new System.Drawing.Size(436, 358);
            this.gridItem.TabIndex = 0;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractCode,
            this.colEmployeeCode,
            this.colDateTime,
            this.colUserPrint,
            this.colImages});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridItemDetail_FocusedRowChanged);
            // 
            // colContractCode
            // 
            this.colContractCode.Caption = "ContractCode";
            this.colContractCode.FieldName = "ContractCode";
            this.colContractCode.Name = "colContractCode";
            this.colContractCode.Visible = true;
            this.colContractCode.VisibleIndex = 0;
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Caption = "EmployeeCode";
            this.colEmployeeCode.FieldName = "EmployeeCode";
            this.colEmployeeCode.Name = "colEmployeeCode";
            this.colEmployeeCode.Visible = true;
            this.colEmployeeCode.VisibleIndex = 1;
            // 
            // colDateTime
            // 
            this.colDateTime.Caption = "DateTime";
            this.colDateTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:MM:ss";
            this.colDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateTime.FieldName = "DateTime";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.Visible = true;
            this.colDateTime.VisibleIndex = 2;
            // 
            // colUserPrint
            // 
            this.colUserPrint.Caption = "UserPrint";
            this.colUserPrint.FieldName = "UserPrint";
            this.colUserPrint.Name = "colUserPrint";
            this.colUserPrint.Visible = true;
            this.colUserPrint.VisibleIndex = 3;
            // 
            // colImages
            // 
            this.colImages.Caption = "Images";
            this.colImages.FieldName = "Images";
            this.colImages.Name = "colImages";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnShowAll);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtEmployeeCode);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnFind);
            this.splitContainerControl1.Panel1.Controls.Add(this.gridItem);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageHD);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(533, 396);
            this.splitContainerControl1.SplitterPosition = 437;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(332, 5);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(74, 29);
            this.btnShowAll.TabIndex = 4;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Mã Nhân Viên";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(87, 10);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(131, 20);
            this.txtEmployeeCode.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(224, 5);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(101, 30);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Xem";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ImageHD
            // 
            this.ImageHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageHD.Location = new System.Drawing.Point(0, 0);
            this.ImageHD.Name = "ImageHD";
            this.ImageHD.Properties.ShowScrollBars = true;
            this.ImageHD.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.ImageHD.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.ImageHD.Size = new System.Drawing.Size(91, 396);
            this.ImageHD.TabIndex = 0;
            this.ImageHD.DoubleClick += new System.EventHandler(this.ImageHD_DoubleClick);
            // 
            // frmDanhSachHopDong_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 396);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmDanhSachHopDong_In";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách HĐ đã in ký";
            this.Load += new System.EventHandler(this.frmDanhSachHopDong_In_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHD.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colContractCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUserPrint;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PictureEdit ImageHD;
        private DevExpress.XtraGrid.Columns.GridColumn colImages;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEmployeeCode;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.SimpleButton btnShowAll;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}