namespace HRM.Forms
{
    partial class frmChamCong_KetNoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChamCong_KetNoi));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.cboDeivice = new DevExpress.XtraBars.BarEditItem();
            this.cboListDevice = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnConnect = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisconnect = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoadData = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HRM.frmWaiting), true, true);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.btnToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.timeEndOut = new DevExpress.XtraEditors.TimeEdit();
            this.timeBeginOut = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.timeEndIn = new DevExpress.XtraEditors.TimeEdit();
            this.dateTHTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.timeBeginIn = new DevExpress.XtraEditors.TimeEdit();
            this.dateTHFrom = new DevExpress.XtraEditors.DateEdit();
            this.btnTongHopXuat = new DevExpress.XtraEditors.SimpleButton();
            this.btnTongHopXem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnExportExcelTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportExcelTemplateByGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInOutCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInOutMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDayStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnrollNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboListDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEndOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBeginOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEndIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBeginIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // colTimeIn
            // 
            this.colTimeIn.Caption = "Giờ vào";
            this.colTimeIn.DisplayFormat.FormatString = "HH:mm:ss";
            this.colTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimeIn.FieldName = "TimeIn";
            this.colTimeIn.Name = "colTimeIn";
            this.colTimeIn.Visible = true;
            this.colTimeIn.VisibleIndex = 9;
            this.colTimeIn.Width = 55;
            // 
            // colTimeOut
            // 
            this.colTimeOut.Caption = "Giờ ra";
            this.colTimeOut.DisplayFormat.FormatString = "HH:mm:ss";
            this.colTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimeOut.FieldName = "TimeOut";
            this.colTimeOut.Name = "colTimeOut";
            this.colTimeOut.Visible = true;
            this.colTimeOut.VisibleIndex = 10;
            this.colTimeOut.Width = 52;
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
            this.cboDeivice,
            this.btnConnect,
            this.btnDisconnect,
            this.btnLoadData});
            this.barManager1.LargeImages = this.imageCollection1;
            this.barManager1.MaxItemId = 4;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboListDevice});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboDeivice, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnConnect, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDisconnect, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLoadData, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // cboDeivice
            // 
            this.cboDeivice.Caption = "Chọn thiết bị";
            this.cboDeivice.Edit = this.cboListDevice;
            this.cboDeivice.Id = 0;
            this.cboDeivice.Name = "cboDeivice";
            this.cboDeivice.Width = 124;
            // 
            // cboListDevice
            // 
            this.cboListDevice.AutoHeight = false;
            this.cboListDevice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboListDevice.Name = "cboListDevice";
            this.cboListDevice.NullText = "[Chọn 1 thiết bị]";
            this.cboListDevice.View = this.gridDevice;
            // 
            // gridDevice
            // 
            this.gridDevice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachineName,
            this.colMachineCode});
            this.gridDevice.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridDevice.Name = "gridDevice";
            this.gridDevice.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridDevice.OptionsView.ShowGroupPanel = false;
            // 
            // colMachineName
            // 
            this.colMachineName.Caption = "Tên máy";
            this.colMachineName.FieldName = "MachineName";
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 1;
            this.colMachineName.Width = 956;
            // 
            // colMachineCode
            // 
            this.colMachineCode.Caption = "Mã";
            this.colMachineCode.FieldName = "MachineCode";
            this.colMachineCode.Name = "colMachineCode";
            this.colMachineCode.Visible = true;
            this.colMachineCode.VisibleIndex = 0;
            this.colMachineCode.Width = 122;
            // 
            // btnConnect
            // 
            this.btnConnect.Caption = "Kết nối";
            this.btnConnect.Id = 1;
            this.btnConnect.ImageIndex = 0;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnect_ItemClick);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Caption = "Ngưng kết nối";
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Id = 2;
            this.btnDisconnect.ImageIndex = 1;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDisconnect_ItemClick);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Caption = "Tải dữ liệu";
            this.btnLoadData.Enabled = false;
            this.btnLoadData.Id = 3;
            this.btnLoadData.ImageIndex = 2;
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadData_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(806, 37);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 604);
            this.barDockControlBottom.Size = new System.Drawing.Size(806, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 37);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 567);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(806, 37);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 567);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(22, 22);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "connect.png");
            this.imageCollection1.Images.SetKeyName(1, "ProgramOff.bmp");
            this.imageCollection1.Images.SetKeyName(2, "Action_Navigation_Next_Object_32x32.png");
            this.imageCollection1.Images.SetKeyName(3, "Action_Printing_Preview_32x32.png");
            this.imageCollection1.Images.SetKeyName(4, "Action_Export_ToExcel_32x32.png");
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 37);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridItem);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(806, 567);
            this.splitContainerControl1.SplitterPosition = 223;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.LargeImages = this.imageCollection1;
            this.navBarControl1.Location = new System.Drawing.Point(1, 53);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 223;
            this.navBarControl1.Size = new System.Drawing.Size(223, 514);
            this.navBarControl1.TabIndex = 2;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Xem nhanh";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 140;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.btnToExcel);
            this.navBarGroupControlContainer1.Controls.Add(this.btnView);
            this.navBarGroupControlContainer1.Controls.Add(this.labelControl1);
            this.navBarGroupControlContainer1.Controls.Add(this.dateTo);
            this.navBarGroupControlContainer1.Controls.Add(this.labelControl2);
            this.navBarGroupControlContainer1.Controls.Add(this.dateFrom);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(215, 133);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // btnToExcel
            // 
            this.btnToExcel.ImageIndex = 4;
            this.btnToExcel.ImageList = this.imageCollection1;
            this.btnToExcel.Location = new System.Drawing.Point(148, 61);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(57, 28);
            this.btnToExcel.TabIndex = 3;
            this.btnToExcel.Text = "Xuất";
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnView
            // 
            this.btnView.ImageIndex = 3;
            this.btnView.ImageList = this.imageCollection1;
            this.btnView.Location = new System.Drawing.Point(85, 61);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(61, 28);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "Xem";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.EnterMoveNextControl = true;
            this.dateTo.Location = new System.Drawing.Point(87, 34);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTo.Size = new System.Drawing.Size(118, 20);
            this.dateTo.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Đến ngày";
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.EnterMoveNextControl = true;
            this.dateFrom.Location = new System.Drawing.Point(87, 6);
            this.dateFrom.MenuManager = this.barManager1;
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateFrom.Size = new System.Drawing.Size(118, 20);
            this.dateFrom.TabIndex = 0;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.timeEndOut);
            this.navBarGroupControlContainer2.Controls.Add(this.timeBeginOut);
            this.navBarGroupControlContainer2.Controls.Add(this.labelControl8);
            this.navBarGroupControlContainer2.Controls.Add(this.timeEndIn);
            this.navBarGroupControlContainer2.Controls.Add(this.dateTHTo);
            this.navBarGroupControlContainer2.Controls.Add(this.labelControl7);
            this.navBarGroupControlContainer2.Controls.Add(this.timeBeginIn);
            this.navBarGroupControlContainer2.Controls.Add(this.dateTHFrom);
            this.navBarGroupControlContainer2.Controls.Add(this.btnTongHopXuat);
            this.navBarGroupControlContainer2.Controls.Add(this.btnTongHopXem);
            this.navBarGroupControlContainer2.Controls.Add(this.labelControl6);
            this.navBarGroupControlContainer2.Controls.Add(this.labelControl4);
            this.navBarGroupControlContainer2.Controls.Add(this.labelControl5);
            this.navBarGroupControlContainer2.Controls.Add(this.labelControl3);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(215, 335);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // timeEndOut
            // 
            this.timeEndOut.EditValue = new System.DateTime(2012, 10, 6, 23, 59, 0, 0);
            this.timeEndOut.Enabled = false;
            this.timeEndOut.EnterMoveNextControl = true;
            this.timeEndOut.Location = new System.Drawing.Point(101, 148);
            this.timeEndOut.Name = "timeEndOut";
            this.timeEndOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEndOut.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEndOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEndOut.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEndOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEndOut.Properties.Mask.EditMask = "HH:mm";
            this.timeEndOut.Size = new System.Drawing.Size(99, 20);
            this.timeEndOut.TabIndex = 5;
            // 
            // timeBeginOut
            // 
            this.timeBeginOut.EditValue = new System.DateTime(2012, 10, 6, 13, 0, 0, 0);
            this.timeBeginOut.Enabled = false;
            this.timeBeginOut.EnterMoveNextControl = true;
            this.timeBeginOut.Location = new System.Drawing.Point(101, 121);
            this.timeBeginOut.Name = "timeBeginOut";
            this.timeBeginOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeBeginOut.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeBeginOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeBeginOut.Properties.EditFormat.FormatString = "HH:mm";
            this.timeBeginOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeBeginOut.Properties.Mask.EditMask = "HH:mm";
            this.timeBeginOut.Size = new System.Drawing.Size(99, 20);
            this.timeBeginOut.TabIndex = 4;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(26, 9);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(40, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Từ ngày";
            // 
            // timeEndIn
            // 
            this.timeEndIn.EditValue = new System.DateTime(2012, 10, 6, 12, 59, 0, 0);
            this.timeEndIn.Enabled = false;
            this.timeEndIn.EnterMoveNextControl = true;
            this.timeEndIn.Location = new System.Drawing.Point(101, 86);
            this.timeEndIn.Name = "timeEndIn";
            this.timeEndIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEndIn.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEndIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEndIn.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEndIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEndIn.Properties.Mask.EditMask = "HH:mm";
            this.timeEndIn.Size = new System.Drawing.Size(99, 20);
            this.timeEndIn.TabIndex = 3;
            // 
            // dateTHTo
            // 
            this.dateTHTo.EditValue = null;
            this.dateTHTo.EnterMoveNextControl = true;
            this.dateTHTo.Location = new System.Drawing.Point(101, 34);
            this.dateTHTo.Name = "dateTHTo";
            this.dateTHTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTHTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateTHTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTHTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateTHTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTHTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateTHTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTHTo.Size = new System.Drawing.Size(99, 20);
            this.dateTHTo.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(19, 38);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(47, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Đến ngày";
            // 
            // timeBeginIn
            // 
            this.timeBeginIn.EditValue = new System.DateTime(2012, 10, 6, 6, 0, 0, 0);
            this.timeBeginIn.Enabled = false;
            this.timeBeginIn.EnterMoveNextControl = true;
            this.timeBeginIn.Location = new System.Drawing.Point(101, 60);
            this.timeBeginIn.MenuManager = this.barManager1;
            this.timeBeginIn.Name = "timeBeginIn";
            this.timeBeginIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeBeginIn.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeBeginIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeBeginIn.Properties.EditFormat.FormatString = "HH:mm";
            this.timeBeginIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeBeginIn.Properties.Mask.EditMask = "HH:mm";
            this.timeBeginIn.Size = new System.Drawing.Size(99, 20);
            this.timeBeginIn.TabIndex = 2;
            // 
            // dateTHFrom
            // 
            this.dateTHFrom.EditValue = null;
            this.dateTHFrom.EnterMoveNextControl = true;
            this.dateTHFrom.Location = new System.Drawing.Point(101, 6);
            this.dateTHFrom.Name = "dateTHFrom";
            this.dateTHFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTHFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateTHFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTHFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateTHFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTHFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateTHFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTHFrom.Size = new System.Drawing.Size(99, 20);
            this.dateTHFrom.TabIndex = 0;
            // 
            // btnTongHopXuat
            // 
            this.btnTongHopXuat.ImageIndex = 4;
            this.btnTongHopXuat.ImageList = this.imageCollection1;
            this.btnTongHopXuat.Location = new System.Drawing.Point(157, 177);
            this.btnTongHopXuat.Name = "btnTongHopXuat";
            this.btnTongHopXuat.Size = new System.Drawing.Size(57, 28);
            this.btnTongHopXuat.TabIndex = 7;
            this.btnTongHopXuat.Text = "Xuất";
            this.btnTongHopXuat.Click += new System.EventHandler(this.btnTongHopXuat_Click);
            // 
            // btnTongHopXem
            // 
            this.btnTongHopXem.ImageIndex = 3;
            this.btnTongHopXem.ImageList = this.imageCollection1;
            this.btnTongHopXem.Location = new System.Drawing.Point(88, 177);
            this.btnTongHopXem.Name = "btnTongHopXem";
            this.btnTongHopXem.Size = new System.Drawing.Size(67, 28);
            this.btnTongHopXem.TabIndex = 6;
            this.btnTongHopXem.Text = "Xem";
            this.btnTongHopXem.Click += new System.EventHandler(this.btnTongHopXem_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 152);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Kết thúc ra";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 89);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Kết thúc vào";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 124);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(50, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Bắt đầu ra";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Bắt đầu vào";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Tổng hợp";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupClientHeight = 342;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // lblStatus
            // 
            this.lblStatus.AllowHtmlString = true;
            this.lblStatus.HtmlImages = this.imageCollection2;
            this.lblStatus.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblStatus.Location = new System.Drawing.Point(27, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(109, 48);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "<image=State_Validation_Invalid_48x48.png>Chưa kết nối";
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "State_Validation_Invalid_48x48.png");
            this.imageCollection2.Images.SetKeyName(1, "State_Validation_Valid_48x48.png");
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
            this.gridItem.Size = new System.Drawing.Size(578, 567);
            this.gridItem.TabIndex = 0;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportExcelTemplate,
            this.btnExportExcelTemplateByGroup});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 48);
            // 
            // btnExportExcelTemplate
            // 
            this.btnExportExcelTemplate.Enabled = false;
            this.btnExportExcelTemplate.Image = global::HRM.Properties.Resources.Excel;
            this.btnExportExcelTemplate.Name = "btnExportExcelTemplate";
            this.btnExportExcelTemplate.Size = new System.Drawing.Size(232, 22);
            this.btnExportExcelTemplate.Text = "Xuất Excel Template";
            this.btnExportExcelTemplate.Click += new System.EventHandler(this.btnExportExcelTemplate_Click);
            // 
            // btnExportExcelTemplateByGroup
            // 
            this.btnExportExcelTemplateByGroup.Enabled = false;
            this.btnExportExcelTemplateByGroup.Image = global::HRM.Properties.Resources.Excel;
            this.btnExportExcelTemplateByGroup.Name = "btnExportExcelTemplateByGroup";
            this.btnExportExcelTemplateByGroup.Size = new System.Drawing.Size(232, 22);
            this.btnExportExcelTemplateByGroup.Text = "Xuất Excel Template by Group";
            this.btnExportExcelTemplateByGroup.Click += new System.EventHandler(this.btnExportExcelTemplateByGroup_Click);
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInOutCode,
            this.colMachineNumber,
            this.colInOutMode,
            this.colTimeStr,
            this.colFirstName,
            this.colLastName,
            this.colEmployeeCode,
            this.colTimeOut,
            this.colTimeIn,
            this.colDepartmentName,
            this.colDayStr,
            this.colDateStr,
            this.colGroupName,
            this.colIndex,
            this.colEnrollNumber});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Column = this.colTimeIn;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value2 = "";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Column = this.colTimeOut;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value2 = "";
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition3.Appearance.BackColor2 = System.Drawing.Color.White;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.Column = this.colTimeOut;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition4.Appearance.BackColor2 = System.Drawing.Color.White;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.Column = this.colTimeIn;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition4.Value1 = "";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.IndicatorWidth = 55;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsSelection.MultiSelect = true;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridItemDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridItemDetail_CustomDrawRowIndicator);
            // 
            // colInOutCode
            // 
            this.colInOutCode.Caption = "ID";
            this.colInOutCode.FieldName = "InOutCode";
            this.colInOutCode.Name = "colInOutCode";
            this.colInOutCode.Width = 149;
            // 
            // colMachineNumber
            // 
            this.colMachineNumber.Caption = "ID Máy";
            this.colMachineNumber.FieldName = "MachineNumber";
            this.colMachineNumber.Name = "colMachineNumber";
            this.colMachineNumber.Visible = true;
            this.colMachineNumber.VisibleIndex = 1;
            this.colMachineNumber.Width = 65;
            // 
            // colInOutMode
            // 
            this.colInOutMode.Caption = "InOutMode";
            this.colInOutMode.FieldName = "InOutMode";
            this.colInOutMode.Name = "colInOutMode";
            this.colInOutMode.Width = 71;
            // 
            // colTimeStr
            // 
            this.colTimeStr.Caption = "Thời gian";
            this.colTimeStr.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colTimeStr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimeStr.FieldName = "TimeStr";
            this.colTimeStr.Name = "colTimeStr";
            this.colTimeStr.Visible = true;
            this.colTimeStr.VisibleIndex = 6;
            this.colTimeStr.Width = 144;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Họ lót";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 4;
            this.colFirstName.Width = 108;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Tên";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 5;
            this.colLastName.Width = 56;
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Caption = "Mã nhân viên";
            this.colEmployeeCode.FieldName = "EmployeeCode";
            this.colEmployeeCode.Name = "colEmployeeCode";
            this.colEmployeeCode.Visible = true;
            this.colEmployeeCode.VisibleIndex = 3;
            this.colEmployeeCode.Width = 94;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Caption = "Phòng";
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 11;
            this.colDepartmentName.Width = 92;
            // 
            // colDayStr
            // 
            this.colDayStr.Caption = "Ngày";
            this.colDayStr.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDayStr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDayStr.FieldName = "DayStr";
            this.colDayStr.Name = "colDayStr";
            this.colDayStr.Visible = true;
            this.colDayStr.VisibleIndex = 7;
            this.colDayStr.Width = 59;
            // 
            // colDateStr
            // 
            this.colDateStr.Caption = "Thứ";
            this.colDateStr.FieldName = "DateStr";
            this.colDateStr.Name = "colDateStr";
            this.colDateStr.Visible = true;
            this.colDateStr.VisibleIndex = 8;
            this.colDateStr.Width = 59;
            // 
            // colGroupName
            // 
            this.colGroupName.Caption = "Nhóm";
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 12;
            this.colGroupName.Width = 71;
            // 
            // colIndex
            // 
            this.colIndex.Caption = "STT";
            this.colIndex.FieldName = "Index";
            this.colIndex.Name = "colIndex";
            this.colIndex.Visible = true;
            this.colIndex.VisibleIndex = 0;
            this.colIndex.Width = 33;
            // 
            // colEnrollNumber
            // 
            this.colEnrollNumber.Caption = "Mã Chấm Công";
            this.colEnrollNumber.FieldName = "EnrollNumber";
            this.colEnrollNumber.Name = "colEnrollNumber";
            this.colEnrollNumber.Visible = true;
            this.colEnrollNumber.VisibleIndex = 2;
            this.colEnrollNumber.Width = 96;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.CustomHeight = 105;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // frmChamCong_KetNoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 604);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmChamCong_KetNoi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Kết nối máy chấm công";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChamCong_KetNoi_FormClosed);
            this.Load += new System.EventHandler(this.frmChamCong_KetNoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboListDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.navBarGroupControlContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            this.navBarGroupControlContainer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEndOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBeginOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEndIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBeginIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarEditItem cboDeivice;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cboListDevice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDevice;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnConnect;
        private DevExpress.XtraBars.BarButtonItem btnDisconnect;
        private DevExpress.XtraBars.BarButtonItem btnLoadData;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineCode;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colInOutCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colInOutMode;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeStr;
        private DevExpress.XtraGrid.Columns.GridColumn colEnrollNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeCode;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.SimpleButton btnToExcel;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraEditors.SimpleButton btnTongHopXem;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TimeEdit timeBeginIn;
        private DevExpress.XtraEditors.TimeEdit timeEndOut;
        private DevExpress.XtraEditors.TimeEdit timeBeginOut;
        private DevExpress.XtraEditors.TimeEdit timeEndIn;
        private DevExpress.XtraEditors.SimpleButton btnTongHopXuat;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit dateTHTo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DateEdit dateTHFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeOut;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeIn;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colDayStr;
        private DevExpress.XtraGrid.Columns.GridColumn colDateStr;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnExportExcelTemplate;
        private System.Windows.Forms.ToolStripMenuItem btnExportExcelTemplateByGroup;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}