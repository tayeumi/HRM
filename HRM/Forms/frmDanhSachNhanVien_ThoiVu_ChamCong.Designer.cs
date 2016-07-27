namespace HRM.Forms
{
    partial class frmDanhSachNhanVien_ThoiVu_ChamCong
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HRM.frmWaiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEndOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBeginOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEndIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBeginIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTHFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
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
            // gridItem
            // 
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien});
            this.gridItem.Size = new System.Drawing.Size(504, 483);
            this.gridItem.TabIndex = 1;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
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
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup2;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup2});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 219;
            this.navBarControl1.Size = new System.Drawing.Size(219, 483);
            this.navBarControl1.TabIndex = 3;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Tổng hợp";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupClientHeight = 240;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
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
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(211, 233);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // timeEndOut
            // 
            this.timeEndOut.EditValue = new System.DateTime(2012, 10, 6, 23, 59, 0, 0);
            this.timeEndOut.EnterMoveNextControl = true;
            this.timeEndOut.Location = new System.Drawing.Point(84, 148);
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
            this.timeBeginOut.EnterMoveNextControl = true;
            this.timeBeginOut.Location = new System.Drawing.Point(84, 121);
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
            this.timeEndIn.EnterMoveNextControl = true;
            this.timeEndIn.Location = new System.Drawing.Point(84, 86);
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
            this.dateTHTo.Location = new System.Drawing.Point(84, 34);
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
            this.timeBeginIn.EnterMoveNextControl = true;
            this.timeBeginIn.Location = new System.Drawing.Point(84, 60);
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
            this.dateTHFrom.Location = new System.Drawing.Point(84, 6);
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
            this.btnTongHopXuat.Location = new System.Drawing.Point(126, 177);
            this.btnTongHopXuat.Name = "btnTongHopXuat";
            this.btnTongHopXuat.Size = new System.Drawing.Size(57, 28);
            this.btnTongHopXuat.TabIndex = 7;
            this.btnTongHopXuat.Text = "Xuất";
            this.btnTongHopXuat.Click += new System.EventHandler(this.btnTongHopXuat_Click);
            // 
            // btnTongHopXem
            // 
            this.btnTongHopXem.ImageIndex = 3;
            this.btnTongHopXem.Location = new System.Drawing.Point(57, 177);
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridItem);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(728, 483);
            this.splitContainerControl1.SplitterPosition = 219;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmDanhSachNhanVien_ThoiVu_ChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 483);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmDanhSachNhanVien_ThoiVu_ChamCong";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Bảng chấm công nhân viên thời vụ";
            this.Load += new System.EventHandler(this.frmDanhSachNhanVien_ThoiVu_ChamCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colInOutCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colInOutMode;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeStr;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeOut;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeIn;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colDayStr;
        private DevExpress.XtraGrid.Columns.GridColumn colDateStr;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colEnrollNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraEditors.TimeEdit timeEndOut;
        private DevExpress.XtraEditors.TimeEdit timeBeginOut;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TimeEdit timeEndIn;
        private DevExpress.XtraEditors.DateEdit dateTHTo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TimeEdit timeBeginIn;
        private DevExpress.XtraEditors.DateEdit dateTHFrom;
        private DevExpress.XtraEditors.SimpleButton btnTongHopXuat;
        private DevExpress.XtraEditors.SimpleButton btnTongHopXem;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}