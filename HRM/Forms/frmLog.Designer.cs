namespace HRM.Forms
{
    partial class frmLog
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
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCallHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCallClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPLan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // gridItem
            // 
            this.gridItem.ContextMenuStrip = this.contextMenuStrip1;
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien});
            this.gridItem.Size = new System.Drawing.Size(561, 365);
            this.gridItem.TabIndex = 2;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCallHistory,
            this.toolStripMenuItem1,
            this.btnCallClose});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 54);
            // 
            // btnCallHistory
            // 
            this.btnCallHistory.Name = "btnCallHistory";
            this.btnCallHistory.Size = new System.Drawing.Size(115, 22);
            this.btnCallHistory.Text = "Load lại";
            this.btnCallHistory.Click += new System.EventHandler(this.btnCallHistory_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(112, 6);
            // 
            // btnCallClose
            // 
            this.btnCallClose.Name = "btnCallClose";
            this.btnCallClose.Size = new System.Drawing.Size(115, 22);
            this.btnCallClose.Text = "Thoát";
            this.btnCallClose.Click += new System.EventHandler(this.btnCallClose_Click);
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colCreated,
            this.colModule,
            this.colIPLan,
            this.colPCName,
            this.colDescription});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.GroupCount = 1;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridItemDetail.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Tài Khoản";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            this.colUserName.Width = 172;
            // 
            // colCreated
            // 
            this.colCreated.Caption = "Ngày Thực hiện";
            this.colCreated.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreated.FieldName = "Created";
            this.colCreated.Name = "colCreated";
            this.colCreated.Visible = true;
            this.colCreated.VisibleIndex = 0;
            this.colCreated.Width = 100;
            // 
            // colModule
            // 
            this.colModule.Caption = "Module";
            this.colModule.FieldName = "Module";
            this.colModule.Name = "colModule";
            this.colModule.Visible = true;
            this.colModule.VisibleIndex = 1;
            this.colModule.Width = 164;
            // 
            // colIPLan
            // 
            this.colIPLan.Caption = "IPLan";
            this.colIPLan.FieldName = "IPLan";
            this.colIPLan.Name = "colIPLan";
            this.colIPLan.Visible = true;
            this.colIPLan.VisibleIndex = 2;
            this.colIPLan.Width = 137;
            // 
            // colPCName
            // 
            this.colPCName.Caption = "PCName";
            this.colPCName.FieldName = "PCName";
            this.colPCName.Name = "colPCName";
            this.colPCName.Visible = true;
            this.colPCName.VisibleIndex = 3;
            this.colPCName.Width = 214;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Thao tác";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 488;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.CustomHeight = 105;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 365);
            this.Controls.Add(this.gridItem);
            this.Name = "frmLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Nhật ký hệ thống";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLog_FormClosed);
            this.Load += new System.EventHandler(this.frmLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreated;
        private DevExpress.XtraGrid.Columns.GridColumn colModule;
        private DevExpress.XtraGrid.Columns.GridColumn colIPLan;
        private DevExpress.XtraGrid.Columns.GridColumn colPCName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCallHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnCallClose;
    }
}