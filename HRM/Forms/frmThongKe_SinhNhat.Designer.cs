namespace HRM.Forms
{
    partial class frmThongKe_SinhNhat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe_SinhNhat));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colEmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateItem = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colBirthPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCellPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMainAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDCardDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDCardPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnToExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Trạng Thái";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 60;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn tháng";
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(81, 7);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMonth.Properties.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.txtMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtMonth.Size = new System.Drawing.Size(60, 20);
            this.txtMonth.TabIndex = 1;
            // 
            // btnShow
            // 
            this.btnShow.ImageIndex = 1;
            this.btnShow.ImageList = this.imageCollection1;
            this.btnShow.Location = new System.Drawing.Point(147, 5);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(61, 24);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Xem";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Action_Export_ToExcel_32x32.png");
            this.imageCollection1.Images.SetKeyName(1, "Action_Printing_Preview_32x32.png");
            // 
            // gridItem
            // 
            this.gridItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItem.Location = new System.Drawing.Point(1, 36);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien,
            this.dateItem});
            this.gridItem.Size = new System.Drawing.Size(628, 292);
            this.gridItem.TabIndex = 3;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBranchName,
            this.colDepartmentName,
            this.colPhoTo,
            this.colEmployeeCode,
            this.colFirstName,
            this.colLastName,
            this.colSex,
            this.colBirthday,
            this.colBirthPlace,
            this.colCellPhone,
            this.colMainAddress,
            this.colIDCard,
            this.colIDCardDate,
            this.colIDCardPlace,
            this.colStatus,
            this.colEmail,
            this.colPosition,
            this.colGroupName,
            this.colContactAddress,
            this.colAge,
            this.colDay});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colStatus;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "2";
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colStatus;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "3";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.IndicatorWidth = 40;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsDetail.EnableDetailToolTip = true;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            // 
            // colBranchName
            // 
            this.colBranchName.Caption = "Văn phòng";
            this.colBranchName.FieldName = "BranchName";
            this.colBranchName.Name = "colBranchName";
            this.colBranchName.ShowUnboundExpressionMenu = true;
            this.colBranchName.Visible = true;
            this.colBranchName.VisibleIndex = 17;
            this.colBranchName.Width = 457;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Caption = "Phòng Ban";
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 3;
            this.colDepartmentName.Width = 115;
            // 
            // colPhoTo
            // 
            this.colPhoTo.Caption = "Hình Ảnh";
            this.colPhoTo.ColumnEdit = this.PicNhanVien;
            this.colPhoTo.FieldName = "Photo";
            this.colPhoTo.MaxWidth = 80;
            this.colPhoTo.Name = "colPhoTo";
            this.colPhoTo.OptionsColumn.FixedWidth = true;
            this.colPhoTo.Width = 80;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PicNhanVien.CustomHeight = 90;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Caption = "Mã Nhân Viên";
            this.colEmployeeCode.FieldName = "EmployeeCode";
            this.colEmployeeCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colEmployeeCode.Name = "colEmployeeCode";
            this.colEmployeeCode.Visible = true;
            this.colEmployeeCode.VisibleIndex = 0;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Họ lót";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 1;
            this.colFirstName.Width = 100;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Tên";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            this.colLastName.Width = 59;
            // 
            // colSex
            // 
            this.colSex.Caption = "Nam(x)";
            this.colSex.FieldName = "Sex";
            this.colSex.Name = "colSex";
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 5;
            this.colSex.Width = 54;
            // 
            // colBirthday
            // 
            this.colBirthday.Caption = "Ngày sinh";
            this.colBirthday.ColumnEdit = this.dateItem;
            this.colBirthday.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colBirthday.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBirthday.FieldName = "Birthday";
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.Visible = true;
            this.colBirthday.VisibleIndex = 6;
            this.colBirthday.Width = 104;
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
            // colBirthPlace
            // 
            this.colBirthPlace.Caption = "Nơi Sinh";
            this.colBirthPlace.FieldName = "BirthPlace";
            this.colBirthPlace.Name = "colBirthPlace";
            this.colBirthPlace.Visible = true;
            this.colBirthPlace.VisibleIndex = 7;
            this.colBirthPlace.Width = 153;
            // 
            // colCellPhone
            // 
            this.colCellPhone.Caption = "Điện Thoại";
            this.colCellPhone.FieldName = "CellPhone";
            this.colCellPhone.Name = "colCellPhone";
            this.colCellPhone.Visible = true;
            this.colCellPhone.VisibleIndex = 13;
            this.colCellPhone.Width = 99;
            // 
            // colMainAddress
            // 
            this.colMainAddress.Caption = "Địa chỉ thường trú";
            this.colMainAddress.FieldName = "MainAddress";
            this.colMainAddress.Name = "colMainAddress";
            this.colMainAddress.Visible = true;
            this.colMainAddress.VisibleIndex = 11;
            this.colMainAddress.Width = 162;
            // 
            // colIDCard
            // 
            this.colIDCard.Caption = "CMND";
            this.colIDCard.FieldName = "IDCard";
            this.colIDCard.Name = "colIDCard";
            this.colIDCard.Visible = true;
            this.colIDCard.VisibleIndex = 8;
            this.colIDCard.Width = 86;
            // 
            // colIDCardDate
            // 
            this.colIDCardDate.Caption = "Ngày cấp";
            this.colIDCardDate.ColumnEdit = this.dateItem;
            this.colIDCardDate.FieldName = "IDCardDate";
            this.colIDCardDate.Name = "colIDCardDate";
            this.colIDCardDate.Visible = true;
            this.colIDCardDate.VisibleIndex = 9;
            this.colIDCardDate.Width = 129;
            // 
            // colIDCardPlace
            // 
            this.colIDCardPlace.Caption = "Nơi Cấp";
            this.colIDCardPlace.FieldName = "IDCardPlace";
            this.colIDCardPlace.Name = "colIDCardPlace";
            this.colIDCardPlace.Visible = true;
            this.colIDCardPlace.VisibleIndex = 10;
            this.colIDCardPlace.Width = 131;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 14;
            this.colEmail.Width = 117;
            // 
            // colPosition
            // 
            this.colPosition.Caption = "Chức vụ";
            this.colPosition.FieldName = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.Visible = true;
            this.colPosition.VisibleIndex = 4;
            this.colPosition.Width = 101;
            // 
            // colGroupName
            // 
            this.colGroupName.Caption = "Tổ nhóm";
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Width = 113;
            // 
            // colContactAddress
            // 
            this.colContactAddress.Caption = "Địa chỉ tạm trú";
            this.colContactAddress.FieldName = "ContactAddress";
            this.colContactAddress.Name = "colContactAddress";
            this.colContactAddress.Visible = true;
            this.colContactAddress.VisibleIndex = 12;
            this.colContactAddress.Width = 144;
            // 
            // colAge
            // 
            this.colAge.Caption = "Tuổi";
            this.colAge.FieldName = "Age";
            this.colAge.Name = "colAge";
            this.colAge.Visible = true;
            this.colAge.VisibleIndex = 16;
            // 
            // colDay
            // 
            this.colDay.Caption = "Ngày";
            this.colDay.FieldName = "Day";
            this.colDay.Name = "colDay";
            this.colDay.Visible = true;
            this.colDay.VisibleIndex = 15;
            // 
            // btnToExcel
            // 
            this.btnToExcel.ImageIndex = 0;
            this.btnToExcel.ImageList = this.imageCollection1;
            this.btnToExcel.Location = new System.Drawing.Point(213, 5);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(68, 24);
            this.btnToExcel.TabIndex = 4;
            this.btnToExcel.Text = "Xuất";
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // frmThongKe_SinhNhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 328);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.gridItem);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKe_SinhNhat";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmThongKe_SinhNhat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmThongKe_SinhNhat_FormClosed);
            this.Load += new System.EventHandler(this.frmThongKe_SinhNhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit txtMonth;
        private DevExpress.XtraEditors.SimpleButton btnShow;
        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthday;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateItem;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colCellPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colMainAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colIDCard;
        private DevExpress.XtraGrid.Columns.GridColumn colIDCardDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIDCardPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colContactAddress;
        private DevExpress.XtraEditors.SimpleButton btnToExcel;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colDay;
        private DevExpress.XtraGrid.Columns.GridColumn colAge;
    }
}