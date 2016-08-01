namespace HRM.Forms
{
    partial class frmDanhSachHopDong
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachHopDong));
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCallThemHD = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCallCapNhatHD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCallPrintThuViec = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCallPrintThuMoi = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCallPrintPhuLucHopDong = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToKhaiBH = new System.Windows.Forms.ToolStripMenuItem();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateItem = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colFromDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSigner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignerPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.cboTrangThai = new DevExpress.XtraBars.BarEditItem();
            this.cboListTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnAddHD = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListCoCauToChuc = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageTreelist = new DevExpress.Utils.ImageCollection(this.components);
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HRM.frmWaiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboListTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListCoCauToChuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreelist)).BeginInit();
            this.SuspendLayout();
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // gridItem
            // 
            this.gridItem.ContextMenuStrip = this.contextMenuStrip1;
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.dateItem});
            this.gridItem.Size = new System.Drawing.Size(620, 362);
            this.gridItem.TabIndex = 0;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            this.gridItem.DataSourceChanged += new System.EventHandler(this.gridItem_DataSourceChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCallThemHD,
            this.btnCallCapNhatHD,
            this.toolStripMenuItem1,
            this.inToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 98);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btnCallThemHD
            // 
            this.btnCallThemHD.Image = global::HRM.Properties.Resources.add;
            this.btnCallThemHD.Name = "btnCallThemHD";
            this.btnCallThemHD.Size = new System.Drawing.Size(177, 22);
            this.btnCallThemHD.Tag = "QLHD_Them";
            this.btnCallThemHD.Text = "Thêm hợp đồng";
            this.btnCallThemHD.Click += new System.EventHandler(this.btnCallThemHD_Click);
            // 
            // btnCallCapNhatHD
            // 
            this.btnCallCapNhatHD.Image = global::HRM.Properties.Resources.Edit;
            this.btnCallCapNhatHD.Name = "btnCallCapNhatHD";
            this.btnCallCapNhatHD.Size = new System.Drawing.Size(177, 22);
            this.btnCallCapNhatHD.Tag = "QLHD_Sua";
            this.btnCallCapNhatHD.Text = "Cập nhật hợp đồng";
            this.btnCallCapNhatHD.Click += new System.EventHandler(this.btnCallCapNhatHD_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // inToolStripMenuItem
            // 
            this.inToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCallPrintThuViec,
            this.btnCallPrintThuMoi,
            this.btnCallPrintPhuLucHopDong,
            this.btnToKhaiBH});
            this.inToolStripMenuItem.Image = global::HRM.Properties.Resources.Printer;
            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
            this.inToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.inToolStripMenuItem.Tag = "QLHD_In";
            this.inToolStripMenuItem.Text = "In";
            // 
            // btnCallPrintThuViec
            // 
            this.btnCallPrintThuViec.Image = global::HRM.Properties.Resources.Action_Chart_Printing_Preview;
            this.btnCallPrintThuViec.Name = "btnCallPrintThuViec";
            this.btnCallPrintThuViec.Size = new System.Drawing.Size(216, 22);
            this.btnCallPrintThuViec.Text = "Thỏa thuận thử việc";
            this.btnCallPrintThuViec.Click += new System.EventHandler(this.btnCallPrintThuViec_Click);
            // 
            // btnCallPrintThuMoi
            // 
            this.btnCallPrintThuMoi.Image = global::HRM.Properties.Resources.Action_Chart_Printing_Preview;
            this.btnCallPrintThuMoi.Name = "btnCallPrintThuMoi";
            this.btnCallPrintThuMoi.Size = new System.Drawing.Size(216, 22);
            this.btnCallPrintThuMoi.Text = "Thư mời làm việc";
            this.btnCallPrintThuMoi.Visible = false;
            this.btnCallPrintThuMoi.Click += new System.EventHandler(this.btnCallPrintThuMoi_Click);
            // 
            // btnCallPrintPhuLucHopDong
            // 
            this.btnCallPrintPhuLucHopDong.Image = global::HRM.Properties.Resources.Action_Chart_Printing_Preview;
            this.btnCallPrintPhuLucHopDong.Name = "btnCallPrintPhuLucHopDong";
            this.btnCallPrintPhuLucHopDong.Size = new System.Drawing.Size(216, 22);
            this.btnCallPrintPhuLucHopDong.Text = "Phụ lục Hợp đồng";
            this.btnCallPrintPhuLucHopDong.Click += new System.EventHandler(this.btnCallPrintPhuLucHopDong_Click);
            // 
            // btnToKhaiBH
            // 
            this.btnToKhaiBH.Image = global::HRM.Properties.Resources.Action_Chart_Printing_Preview;
            this.btnToKhaiBH.Name = "btnToKhaiBH";
            this.btnToKhaiBH.Size = new System.Drawing.Size(216, 22);
            this.btnToKhaiBH.Text = "Tờ khai tham gia bảo hiểm";
            this.btnToKhaiBH.Click += new System.EventHandler(this.btnToKhaiBH_Click);
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractCode,
            this.colEmployeeCode,
            this.colFirstName,
            this.colLastName,
            this.colContractTime,
            this.colSignDate,
            this.colFromDate,
            this.colToDate,
            this.colSigner,
            this.colSignerPosition,
            this.colContractType,
            this.colDescription,
            this.colContractYear,
            this.colStatus,
            this.colDepartmentName,
            this.colPosition});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colStatus;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = " [Status]> 1";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.IndicatorWidth = 50;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsSelection.MultiSelect = true;
            this.gridItemDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.OptionsView.ShowFooter = true;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridItemDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridItemDetail_CustomDrawRowIndicator);
            this.gridItemDetail.Click += new System.EventHandler(this.gridItemDetail_Click);
            this.gridItemDetail.DoubleClick += new System.EventHandler(this.gridItemDetail_DoubleClick);
            // 
            // colContractCode
            // 
            this.colContractCode.Caption = "Mã hợp đồng";
            this.colContractCode.FieldName = "ContractCode";
            this.colContractCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colContractCode.Name = "colContractCode";
            this.colContractCode.Visible = true;
            this.colContractCode.VisibleIndex = 0;
            this.colContractCode.Width = 109;
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Caption = "Mã Nhân Viên";
            this.colEmployeeCode.FieldName = "EmployeeCode";
            this.colEmployeeCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colEmployeeCode.Name = "colEmployeeCode";
            this.colEmployeeCode.Visible = true;
            this.colEmployeeCode.VisibleIndex = 1;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Họ lót";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 2;
            this.colFirstName.Width = 100;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Tên";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 3;
            this.colLastName.Width = 59;
            // 
            // colContractTime
            // 
            this.colContractTime.Caption = "Thời gian";
            this.colContractTime.FieldName = "ContractTime";
            this.colContractTime.Name = "colContractTime";
            this.colContractTime.Visible = true;
            this.colContractTime.VisibleIndex = 5;
            this.colContractTime.Width = 74;
            // 
            // colSignDate
            // 
            this.colSignDate.Caption = "Ngày ký";
            this.colSignDate.ColumnEdit = this.dateItem;
            this.colSignDate.FieldName = "SignDate";
            this.colSignDate.Name = "colSignDate";
            this.colSignDate.Visible = true;
            this.colSignDate.VisibleIndex = 6;
            this.colSignDate.Width = 83;
            // 
            // dateItem
            // 
            this.dateItem.AutoHeight = false;
            this.dateItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateItem.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateItem.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateItem.Mask.EditMask = "dd/MM/yyyy";
            this.dateItem.Name = "dateItem";
            this.dateItem.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colFromDate
            // 
            this.colFromDate.Caption = "Từ ngày";
            this.colFromDate.ColumnEdit = this.dateItem;
            this.colFromDate.FieldName = "FromDate";
            this.colFromDate.Name = "colFromDate";
            this.colFromDate.Visible = true;
            this.colFromDate.VisibleIndex = 7;
            this.colFromDate.Width = 90;
            // 
            // colToDate
            // 
            this.colToDate.Caption = "Đến ngày";
            this.colToDate.ColumnEdit = this.dateItem;
            this.colToDate.FieldName = "ToDate";
            this.colToDate.Name = "colToDate";
            this.colToDate.Visible = true;
            this.colToDate.VisibleIndex = 8;
            this.colToDate.Width = 92;
            // 
            // colSigner
            // 
            this.colSigner.Caption = "Người ký";
            this.colSigner.FieldName = "Signer";
            this.colSigner.Name = "colSigner";
            this.colSigner.Visible = true;
            this.colSigner.VisibleIndex = 9;
            this.colSigner.Width = 128;
            // 
            // colSignerPosition
            // 
            this.colSignerPosition.Caption = "Chức vụ người ký";
            this.colSignerPosition.FieldName = "SignerPosition";
            this.colSignerPosition.Name = "colSignerPosition";
            this.colSignerPosition.Visible = true;
            this.colSignerPosition.VisibleIndex = 10;
            this.colSignerPosition.Width = 151;
            // 
            // colContractType
            // 
            this.colContractType.Caption = "Loại hợp đồng";
            this.colContractType.FieldName = "ContractType";
            this.colContractType.Name = "colContractType";
            this.colContractType.Visible = true;
            this.colContractType.VisibleIndex = 4;
            this.colContractType.Width = 139;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Ghi chú";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 12;
            this.colDescription.Width = 234;
            // 
            // colContractYear
            // 
            this.colContractYear.Caption = "HĐ năm";
            this.colContractYear.FieldName = "ContractYear";
            this.colContractYear.Name = "colContractYear";
            this.colContractYear.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ContractYear", "Số lượng: {0}")});
            this.colContractYear.Visible = true;
            this.colContractYear.VisibleIndex = 11;
            this.colContractYear.Width = 98;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Caption = "Phòng ban";
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 13;
            // 
            // colPosition
            // 
            this.colPosition.Caption = "Chức vụ";
            this.colPosition.FieldName = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.Visible = true;
            this.colPosition.VisibleIndex = 14;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "hotel.png");
            this.imageCollection1.Images.SetKeyName(1, "CN.png");
            this.imageCollection1.Images.SetKeyName(2, "home.png");
            this.imageCollection1.Images.SetKeyName(3, "add.gif");
            this.imageCollection1.Images.SetKeyName(4, "add_mode.png");
            this.imageCollection1.Images.SetKeyName(5, "del_mode.png");
            this.imageCollection1.Images.SetKeyName(6, "edit_mode.png");
            this.imageCollection1.Images.SetKeyName(7, "Excel.bmp");
            this.imageCollection1.Images.SetKeyName(8, "printer2.png");
            this.imageCollection1.Images.SetKeyName(9, "ProgramOff.bmp");
            this.imageCollection1.Images.SetKeyName(10, "save.gif");
            this.imageCollection1.Images.SetKeyName(11, "user_group.png");
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.btnAddHD,
            this.btnEdit,
            this.btnDel,
            this.btnPrint,
            this.btnExport,
            this.btnClose,
            this.cboTrangThai,
            this.barStaticItem1});
            this.barManager1.MaxItemId = 22;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboListTrangThai});
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.bar1.BarAppearance.Normal.Options.UseFont = true;
            this.bar1.BarName = "Control";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.cboTrangThai),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddHD, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose, true)});
            this.bar1.OptionsBar.AllowRename = true;
            this.bar1.Text = "Control";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Lọc dữ liệu theo";
            this.barStaticItem1.Id = 21;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Edit = this.cboListTrangThai;
            this.cboTrangThai.Id = 15;
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Width = 222;
            this.cboTrangThai.EditValueChanged += new System.EventHandler(this.cboTrangThai_EditValueChanged);
            // 
            // cboListTrangThai
            // 
            this.cboListTrangThai.AutoHeight = false;
            this.cboListTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboListTrangThai.Items.AddRange(new object[] {
            "[Tất cả]",
            "[Danh sách hợp đồng hiện tại]",
            "[Danh sách hợp đồng sắp hết hạn (30 Ngày)]",
            "[Danh sách hợp đồng đã hết hạn]"});
            this.cboListTrangThai.Name = "cboListTrangThai";
            this.cboListTrangThai.NullText = "[Tất cả]";
            this.cboListTrangThai.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnAddHD
            // 
            this.btnAddHD.Caption = "Thêm Hợp đồng";
            this.btnAddHD.Id = 9;
            this.btnAddHD.ImageIndex = 3;
            this.btnAddHD.Name = "btnAddHD";
            this.btnAddHD.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAddHD.Tag = "QLHD_Them";
            this.btnAddHD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddHD_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 10;
            this.btnEdit.ImageIndex = 6;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEdit.Tag = "QLHD_Sua";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDel
            // 
            this.btnDel.Caption = "Xóa";
            this.btnDel.Id = 11;
            this.btnDel.ImageIndex = 5;
            this.btnDel.Name = "btnDel";
            this.btnDel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDel.Tag = "QLHD_Xoa";
            this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 12;
            this.btnPrint.ImageIndex = 8;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPrint.Tag = "QLHD_In";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Xuất";
            this.btnExport.Id = 13;
            this.btnExport.ImageIndex = 7;
            this.btnExport.Name = "btnExport";
            this.btnExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExport.Tag = "QLHD_Export";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Id = 14;
            this.btnClose.ImageIndex = 9;
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(884, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 393);
            this.barDockControlBottom.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 362);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(884, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 362);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm Tổ Nhóm";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thêm Chi Nhánh";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Thêm Phòng Ban";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Thêm Nhân Viên";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Sửa";
            this.barButtonItem6.Id = 5;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Xóa";
            this.barButtonItem7.Id = 6;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 31);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeListCoCauToChuc);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridItem);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(884, 362);
            this.splitContainerControl1.SplitterPosition = 259;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeListCoCauToChuc
            // 
            this.treeListCoCauToChuc.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeListCoCauToChuc.CustomizationFormBounds = new System.Drawing.Rectangle(1055, 487, 216, 178);
            this.treeListCoCauToChuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListCoCauToChuc.KeyFieldName = "";
            this.treeListCoCauToChuc.Location = new System.Drawing.Point(0, 0);
            this.treeListCoCauToChuc.Name = "treeListCoCauToChuc";
            this.treeListCoCauToChuc.BeginUnboundLoad();
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Công ty CP TT Băng Rộng Cuộc Sống LBC",
            "aaa"}, -1, 0, 0, 0);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Chi Nhanh 1",
            null}, 0, 0, 0, 1);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "PB1",
            null}, 1, 0, 0, 2);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "PB2",
            null}, 1, 0, 0, 2);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "PB3",
            null}, 1, 0, 0, 2);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Nhom 3",
            null}, 4);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Nhan vien 3,1",
            null}, 5);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "PB4",
            null}, 1, 0, 0, 2);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Nhom 1",
            null}, 7, 0, 0, 11);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Nhan vien 1",
            null}, 8);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Nhan vien 2",
            null}, 8);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Nhóm 1-2",
            null}, 7, 0, 0, 11);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Chi Nhanh 2",
            null}, 0, 0, 0, 1);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "PB5",
            null}, 12, 0, 0, 2);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Nhom 2",
            null}, 13, 0, 0, 11);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "PB6",
            null}, 12, 0, 0, 2);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "PB7",
            null}, 12, 0, 0, 2);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Chi Nhanh 3",
            null}, 0, 0, 0, 1);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "PB8",
            null}, 17, 0, 0, 2);
            this.treeListCoCauToChuc.AppendNode(new object[] {
            "Nhom 3",
            null}, 18, 0, 0, 11);
            this.treeListCoCauToChuc.EndUnboundLoad();
            this.treeListCoCauToChuc.OptionsBehavior.Editable = false;
            this.treeListCoCauToChuc.OptionsBehavior.PopulateServiceColumns = true;
            this.treeListCoCauToChuc.OptionsLayout.AddNewColumns = false;
            this.treeListCoCauToChuc.OptionsSelection.InvertSelection = true;
            this.treeListCoCauToChuc.OptionsView.ShowColumns = false;
            this.treeListCoCauToChuc.OptionsView.ShowHorzLines = false;
            this.treeListCoCauToChuc.OptionsView.ShowIndicator = false;
            this.treeListCoCauToChuc.OptionsView.ShowVertLines = false;
            this.treeListCoCauToChuc.ParentFieldName = "";
            this.treeListCoCauToChuc.RootValue = null;
            this.treeListCoCauToChuc.Size = new System.Drawing.Size(259, 362);
            this.treeListCoCauToChuc.StateImageList = this.imageTreelist;
            this.treeListCoCauToChuc.TabIndex = 0;
            this.treeListCoCauToChuc.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListCoCauToChuc_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Cơ cấu tổ chức";
            this.treeListColumn1.FieldName = "Cơ cấu tổ chức";
            this.treeListColumn1.MinWidth = 125;
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
            // imageTreelist
            // 
            this.imageTreelist.ImageSize = new System.Drawing.Size(18, 18);
            this.imageTreelist.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageTreelist.ImageStream")));
            this.imageTreelist.Images.SetKeyName(0, "hotel.png");
            this.imageTreelist.Images.SetKeyName(1, "CN.png");
            this.imageTreelist.Images.SetKeyName(2, "home.png");
            this.imageTreelist.Images.SetKeyName(3, "user_group.png");
            this.imageTreelist.Images.SetKeyName(4, "male.png");
            this.imageTreelist.Images.SetKeyName(5, "female.png");
            // 
            // frmDanhSachHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 393);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDanhSachHopDong";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách hợp đồng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDanhSachHopDong_FormClosed);
            this.Load += new System.EventHandler(this.frmDanhSachHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboListTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListCoCauToChuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreelist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateItem;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnAddHD;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarEditItem cboTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboListTrangThai;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeListCoCauToChuc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.Utils.ImageCollection imageTreelist;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colContractCode;
        private DevExpress.XtraGrid.Columns.GridColumn colContractTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSignDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFromDate;
        private DevExpress.XtraGrid.Columns.GridColumn colToDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSigner;
        private DevExpress.XtraGrid.Columns.GridColumn colSignerPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colContractType;
        private DevExpress.XtraGrid.Columns.GridColumn colContractYear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCallThemHD;
        private System.Windows.Forms.ToolStripMenuItem btnCallCapNhatHD;
        private System.Windows.Forms.ToolStripMenuItem inToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnCallPrintThuViec;
        private System.Windows.Forms.ToolStripMenuItem btnCallPrintThuMoi;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnCallPrintPhuLucHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private System.Windows.Forms.ToolStripMenuItem btnToKhaiBH;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}