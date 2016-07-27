namespace HRM.Forms
{
    partial class frmPhanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanQuyen));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeAccount = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridNotUse = new DevExpress.XtraGrid.GridControl();
            this.contextMenuAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThemQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChonTatCaAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBoChonTatCaAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.bandedgridNotUse = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colChecUsekAll = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.checkValue = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridNotUseDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObject_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObject_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridIsUse = new DevExpress.XtraGrid.GridControl();
            this.contextMenuRemove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnXoaQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChonTatCaRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBoChonTatCaRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaoChepQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.bandedgirdIsUse = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCheckAllNotUse = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.checkValueNotUse = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsObject_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIsObject_Name = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIsObject_Description = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeAccount)).BeginInit();
            this.contextMenuCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotUse)).BeginInit();
            this.contextMenuAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bandedgridNotUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotUseDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIsUse)).BeginInit();
            this.contextMenuRemove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bandedgirdIsUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkValueNotUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeAccount);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(772, 427);
            this.splitContainerControl1.SplitterPosition = 147;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeAccount
            // 
            this.treeAccount.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeAccount.ContextMenuStrip = this.contextMenuCopy;
            this.treeAccount.CustomizationFormBounds = new System.Drawing.Rectangle(1055, 487, 216, 178);
            this.treeAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAccount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeAccount.KeyFieldName = "";
            this.treeAccount.Location = new System.Drawing.Point(0, 0);
            this.treeAccount.Name = "treeAccount";
            this.treeAccount.OptionsBehavior.Editable = false;
            this.treeAccount.OptionsBehavior.PopulateServiceColumns = true;
            this.treeAccount.OptionsLayout.AddNewColumns = false;
            this.treeAccount.OptionsSelection.InvertSelection = true;
            this.treeAccount.OptionsView.ShowColumns = false;
            this.treeAccount.OptionsView.ShowHorzLines = false;
            this.treeAccount.OptionsView.ShowIndicator = false;
            this.treeAccount.OptionsView.ShowVertLines = false;
            this.treeAccount.ParentFieldName = "";
            this.treeAccount.RootValue = null;
            this.treeAccount.SelectImageList = this.imageCollection1;
            this.treeAccount.Size = new System.Drawing.Size(147, 427);
            this.treeAccount.TabIndex = 1;
            this.treeAccount.Click += new System.EventHandler(this.treeAccount_Click);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "tài khoản";
            this.treeListColumn1.FieldName = "tài khoản";
            this.treeListColumn1.MinWidth = 114;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 114;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Value";
            this.treeListColumn2.FieldName = "Value";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDanQuyen});
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.Size = new System.Drawing.Size(153, 48);
            this.contextMenuCopy.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuCopy_Opening);
            // 
            // btnDanQuyen
            // 
            this.btnDanQuyen.Name = "btnDanQuyen";
            this.btnDanQuyen.Size = new System.Drawing.Size(152, 22);
            this.btnDanQuyen.Text = "Paste Quyền";
            this.btnDanQuyen.Click += new System.EventHandler(this.btnDanQuyen_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(22, 22);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "user_red_edit.png");
            this.imageCollection1.Images.SetKeyName(1, "notes.png");
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.gridNotUse);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gridIsUse);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(620, 427);
            this.splitContainerControl2.SplitterPosition = 306;
            this.splitContainerControl2.TabIndex = 3;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // gridNotUse
            // 
            this.gridNotUse.ContextMenuStrip = this.contextMenuAdd;
            this.gridNotUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNotUse.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridNotUse.Location = new System.Drawing.Point(0, 0);
            this.gridNotUse.MainView = this.bandedgridNotUse;
            this.gridNotUse.Name = "gridNotUse";
            this.gridNotUse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien,
            this.checkValue});
            this.gridNotUse.Size = new System.Drawing.Size(306, 427);
            this.gridNotUse.TabIndex = 2;
            this.gridNotUse.UseEmbeddedNavigator = true;
            this.gridNotUse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedgridNotUse,
            this.gridNotUseDetail});
            // 
            // contextMenuAdd
            // 
            this.contextMenuAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemQuyen,
            this.toolStripMenuItem1,
            this.btnChonTatCaAdd,
            this.btnBoChonTatCaAdd});
            this.contextMenuAdd.Name = "contextMenuAdd";
            this.contextMenuAdd.Size = new System.Drawing.Size(151, 76);
            this.contextMenuAdd.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuAdd_Opening);
            // 
            // btnThemQuyen
            // 
            this.btnThemQuyen.Name = "btnThemQuyen";
            this.btnThemQuyen.Size = new System.Drawing.Size(150, 22);
            this.btnThemQuyen.Text = "Thêm quyền";
            this.btnThemQuyen.Click += new System.EventHandler(this.btnThemQuyen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // btnChonTatCaAdd
            // 
            this.btnChonTatCaAdd.Name = "btnChonTatCaAdd";
            this.btnChonTatCaAdd.Size = new System.Drawing.Size(150, 22);
            this.btnChonTatCaAdd.Text = "Chọn tất cả";
            this.btnChonTatCaAdd.Click += new System.EventHandler(this.btnChonTatCaAdd_Click);
            // 
            // btnBoChonTatCaAdd
            // 
            this.btnBoChonTatCaAdd.Name = "btnBoChonTatCaAdd";
            this.btnBoChonTatCaAdd.Size = new System.Drawing.Size(150, 22);
            this.btnBoChonTatCaAdd.Text = "Bỏ chọn tất cả";
            this.btnBoChonTatCaAdd.Click += new System.EventHandler(this.btnBoChonTatCaAdd_Click);
            // 
            // bandedgridNotUse
            // 
            this.bandedgridNotUse.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedgridNotUse.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colChecUsekAll,
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4});
            this.bandedgridNotUse.CustomizationFormBounds = new System.Drawing.Rectangle(532, 384, 222, 212);
            this.bandedgridNotUse.GridControl = this.gridNotUse;
            this.bandedgridNotUse.GroupCount = 1;
            this.bandedgridNotUse.Name = "bandedgridNotUse";
            this.bandedgridNotUse.OptionsCustomization.AllowRowSizing = true;
            this.bandedgridNotUse.OptionsView.RowAutoHeight = true;
            this.bandedgridNotUse.OptionsView.ShowAutoFilterRow = true;
            this.bandedgridNotUse.OptionsView.ShowGroupPanel = false;
            this.bandedgridNotUse.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.bandedgridNotUse.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.bandedGridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.bandedgridNotUse.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.bandedgridNotUse_CellValueChanging);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Phân Quyền Chưa Cấp";
            this.gridBand1.Columns.Add(this.colChecUsekAll);
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Columns.Add(this.bandedGridColumn3);
            this.gridBand1.Columns.Add(this.bandedGridColumn4);
            this.gridBand1.MinWidth = 20;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 660;
            // 
            // colChecUsekAll
            // 
            this.colChecUsekAll.ColumnEdit = this.checkValue;
            this.colChecUsekAll.FieldName = "selectvalue";
            this.colChecUsekAll.Name = "colChecUsekAll";
            this.colChecUsekAll.OptionsColumn.ShowCaption = false;
            this.colChecUsekAll.Visible = true;
            this.colChecUsekAll.Width = 41;
            // 
            // checkValue
            // 
            this.checkValue.AutoHeight = false;
            this.checkValue.Name = "checkValue";
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Object_ID";
            this.bandedGridColumn2.FieldName = "Object_ID";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn2.OptionsColumn.FixedWidth = true;
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 134;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Object_Name";
            this.bandedGridColumn3.FieldName = "Object_Name";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 314;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Nhóm Quyền";
            this.bandedGridColumn4.FieldName = "Description";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 171;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "ID";
            this.bandedGridColumn1.FieldName = "ID";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 277;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.CustomHeight = 105;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // gridNotUseDetail
            // 
            this.gridNotUseDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colObject_ID,
            this.colObject_Name,
            this.colDescription});
            this.gridNotUseDetail.GridControl = this.gridNotUse;
            this.gridNotUseDetail.Name = "gridNotUseDetail";
            this.gridNotUseDetail.OptionsBehavior.Editable = false;
            this.gridNotUseDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridNotUseDetail.OptionsView.RowAutoHeight = true;
            this.gridNotUseDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridNotUseDetail.OptionsView.ShowGroupPanel = false;
            this.gridNotUseDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 277;
            // 
            // colObject_ID
            // 
            this.colObject_ID.Caption = "Object_ID";
            this.colObject_ID.FieldName = "Object_ID";
            this.colObject_ID.Name = "colObject_ID";
            this.colObject_ID.Visible = true;
            this.colObject_ID.VisibleIndex = 0;
            this.colObject_ID.Width = 132;
            // 
            // colObject_Name
            // 
            this.colObject_Name.Caption = "Object_Name";
            this.colObject_Name.FieldName = "Object_Name";
            this.colObject_Name.Name = "colObject_Name";
            this.colObject_Name.Visible = true;
            this.colObject_Name.VisibleIndex = 1;
            this.colObject_Name.Width = 946;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 636;
            // 
            // gridIsUse
            // 
            this.gridIsUse.ContextMenuStrip = this.contextMenuRemove;
            this.gridIsUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIsUse.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridIsUse.Location = new System.Drawing.Point(0, 0);
            this.gridIsUse.MainView = this.bandedgirdIsUse;
            this.gridIsUse.Name = "gridIsUse";
            this.gridIsUse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.checkValueNotUse});
            this.gridIsUse.Size = new System.Drawing.Size(309, 427);
            this.gridIsUse.TabIndex = 2;
            this.gridIsUse.UseEmbeddedNavigator = true;
            this.gridIsUse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedgirdIsUse});
            // 
            // contextMenuRemove
            // 
            this.contextMenuRemove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnXoaQuyen,
            this.toolStripMenuItem2,
            this.btnChonTatCaRemove,
            this.btnBoChonTatCaRemove,
            this.toolStripMenuItem3,
            this.btnSaoChepQuyen});
            this.contextMenuRemove.Name = "contextMenuRemove";
            this.contextMenuRemove.Size = new System.Drawing.Size(151, 104);
            this.contextMenuRemove.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuRemove_Opening);
            // 
            // btnXoaQuyen
            // 
            this.btnXoaQuyen.Name = "btnXoaQuyen";
            this.btnXoaQuyen.Size = new System.Drawing.Size(150, 22);
            this.btnXoaQuyen.Text = "Xóa Quyền";
            this.btnXoaQuyen.Click += new System.EventHandler(this.btnXoaQuyen_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 6);
            // 
            // btnChonTatCaRemove
            // 
            this.btnChonTatCaRemove.Name = "btnChonTatCaRemove";
            this.btnChonTatCaRemove.Size = new System.Drawing.Size(150, 22);
            this.btnChonTatCaRemove.Text = "Chọn tất cả";
            this.btnChonTatCaRemove.Click += new System.EventHandler(this.btnChonTatCaRemove_Click);
            // 
            // btnBoChonTatCaRemove
            // 
            this.btnBoChonTatCaRemove.Name = "btnBoChonTatCaRemove";
            this.btnBoChonTatCaRemove.Size = new System.Drawing.Size(150, 22);
            this.btnBoChonTatCaRemove.Text = "Bỏ chọn tất cả";
            this.btnBoChonTatCaRemove.Click += new System.EventHandler(this.btnBoChonTatCaRemove_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(147, 6);
            // 
            // btnSaoChepQuyen
            // 
            this.btnSaoChepQuyen.Name = "btnSaoChepQuyen";
            this.btnSaoChepQuyen.Size = new System.Drawing.Size(150, 22);
            this.btnSaoChepQuyen.Text = "Copy quyền";
            this.btnSaoChepQuyen.Click += new System.EventHandler(this.btnSaoChepQuyen_Click);
            // 
            // bandedgirdIsUse
            // 
            this.bandedgirdIsUse.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.bandedgirdIsUse.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colCheckAllNotUse,
            this.colIsObject_ID,
            this.colIsObject_Name,
            this.colIsObject_Description});
            this.bandedgirdIsUse.GridControl = this.gridIsUse;
            this.bandedgirdIsUse.GroupCount = 1;
            this.bandedgirdIsUse.Name = "bandedgirdIsUse";
            this.bandedgirdIsUse.OptionsCustomization.AllowRowSizing = true;
            this.bandedgirdIsUse.OptionsView.RowAutoHeight = true;
            this.bandedgirdIsUse.OptionsView.ShowAutoFilterRow = true;
            this.bandedgirdIsUse.OptionsView.ShowGroupPanel = false;
            this.bandedgirdIsUse.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.bandedgirdIsUse.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colIsObject_Description, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.bandedgirdIsUse.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.bandedgirdIsUse_CellValueChanging);
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Phân Quyền Đã Cấp";
            this.gridBand2.Columns.Add(this.colCheckAllNotUse);
            this.gridBand2.Columns.Add(this.colIsObject_ID);
            this.gridBand2.Columns.Add(this.colIsObject_Name);
            this.gridBand2.Columns.Add(this.colIsObject_Description);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 663;
            // 
            // colCheckAllNotUse
            // 
            this.colCheckAllNotUse.ColumnEdit = this.checkValueNotUse;
            this.colCheckAllNotUse.FieldName = "selectvalue";
            this.colCheckAllNotUse.Name = "colCheckAllNotUse";
            this.colCheckAllNotUse.OptionsColumn.ShowCaption = false;
            this.colCheckAllNotUse.Visible = true;
            this.colCheckAllNotUse.Width = 49;
            // 
            // checkValueNotUse
            // 
            this.checkValueNotUse.AutoHeight = false;
            this.checkValueNotUse.Name = "checkValueNotUse";
            // 
            // colIsObject_ID
            // 
            this.colIsObject_ID.Caption = "Object_ID";
            this.colIsObject_ID.FieldName = "Object_ID";
            this.colIsObject_ID.Name = "colIsObject_ID";
            this.colIsObject_ID.OptionsColumn.AllowEdit = false;
            this.colIsObject_ID.OptionsColumn.FixedWidth = true;
            this.colIsObject_ID.Visible = true;
            this.colIsObject_ID.Width = 239;
            // 
            // colIsObject_Name
            // 
            this.colIsObject_Name.Caption = "Object_Name";
            this.colIsObject_Name.FieldName = "Object_Name";
            this.colIsObject_Name.Name = "colIsObject_Name";
            this.colIsObject_Name.OptionsColumn.AllowEdit = false;
            this.colIsObject_Name.Visible = true;
            this.colIsObject_Name.Width = 284;
            // 
            // colIsObject_Description
            // 
            this.colIsObject_Description.Caption = "Nhóm Quyền";
            this.colIsObject_Description.FieldName = "Description";
            this.colIsObject_Description.Name = "colIsObject_Description";
            this.colIsObject_Description.Visible = true;
            this.colIsObject_Description.Width = 91;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 105;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.NullText = "[Chưa có hình]";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 427);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmPhanQuyen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Bảng Phân Quyền";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeAccount)).EndInit();
            this.contextMenuCopy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNotUse)).EndInit();
            this.contextMenuAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bandedgridNotUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotUseDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIsUse)).EndInit();
            this.contextMenuRemove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bandedgirdIsUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkValueNotUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeAccount;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraGrid.GridControl gridNotUse;
        private DevExpress.XtraGrid.Views.Grid.GridView gridNotUseDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colObject_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colObject_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private DevExpress.XtraGrid.GridControl gridIsUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedgridNotUse;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedgirdIsUse;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIsObject_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIsObject_Name;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colChecUsekAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkValue;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCheckAllNotUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkValueNotUse;
        private System.Windows.Forms.ContextMenuStrip contextMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem btnThemQuyen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnChonTatCaAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuRemove;
        private System.Windows.Forms.ToolStripMenuItem btnXoaQuyen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem btnChonTatCaRemove;
        private System.Windows.Forms.ToolStripMenuItem btnBoChonTatCaAdd;
        private System.Windows.Forms.ToolStripMenuItem btnBoChonTatCaRemove;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIsObject_Description;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem btnSaoChepQuyen;
        private System.Windows.Forms.ContextMenuStrip contextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem btnDanQuyen;

    }
}