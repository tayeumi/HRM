namespace HRM.Forms
{
    partial class frmDanhSachNhanVien_Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachNhanVien_Import));
            this.colKiemTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDuongDan = new DevExpress.XtraEditors.TextEdit();
            this.btnChon = new DevExpress.XtraEditors.SimpleButton();
            this.btnDocFile = new DevExpress.XtraEditors.SimpleButton();
            this.linkFile = new DevExpress.XtraEditors.HyperLinkEdit();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.btnKiemTraDuLieu = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaDuLieu = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.checkAll = new DevExpress.XtraEditors.CheckEdit();
            this.checkStatus = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuongDan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colKiemTra
            // 
            this.colKiemTra.Caption = "kiểm tra";
            this.colKiemTra.FieldName = "KiemTra";
            this.colKiemTra.Name = "colKiemTra";
            this.colKiemTra.OptionsColumn.AllowEdit = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Đường dẫn";
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Enabled = false;
            this.txtDuongDan.Location = new System.Drawing.Point(77, 9);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.Size = new System.Drawing.Size(355, 20);
            this.txtDuongDan.TabIndex = 1;
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(439, 4);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(53, 28);
            this.btnChon.TabIndex = 2;
            this.btnChon.Text = "(1) Chọn";
            this.btnChon.ToolTip = "Chọn File Import";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnDocFile
            // 
            this.btnDocFile.Enabled = false;
            this.btnDocFile.Location = new System.Drawing.Point(495, 4);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(87, 28);
            this.btnDocFile.TabIndex = 2;
            this.btnDocFile.Text = "(2) Đọc file";
            this.btnDocFile.ToolTip = "Lưu ý: Chuyển định dạng ngày tháng theo: dd/mm/yyyy";
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // linkFile
            // 
            this.linkFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkFile.EditValue = "File mẫu:";
            this.linkFile.Location = new System.Drawing.Point(12, 423);
            this.linkFile.Name = "linkFile";
            this.linkFile.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.linkFile.Properties.Appearance.Options.UseBackColor = true;
            this.linkFile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.linkFile.Size = new System.Drawing.Size(395, 18);
            this.linkFile.TabIndex = 3;
            this.linkFile.ToolTip = "Sử dụng Hàm: TEXT(value,format)\r\n trong Excel để chuyển Dữ liệu ngày tháng sang đ" +
                "ịnh dạng text dd/mm/yyyy\r\n trước khi đọc file";
            this.linkFile.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.linkFile_OpenLink);
            // 
            // gridItem
            // 
            this.gridItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItem.Location = new System.Drawing.Point(2, 38);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien,
            this.dateItem});
            this.gridItem.Size = new System.Drawing.Size(742, 379);
            this.gridItem.TabIndex = 4;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.colKiemTra,
            this.colChon});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colKiemTra;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "1";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.IndicatorWidth = 40;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridItemDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridItemDetail_CustomDrawRowIndicator);
            this.gridItemDetail.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridItemDetail_CellValueChanging);
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Caption = "Mã Nhân Viên";
            this.colEmployeeCode.FieldName = "EmployeeCode";
            this.colEmployeeCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colEmployeeCode.Name = "colEmployeeCode";
            this.colEmployeeCode.OptionsColumn.AllowEdit = false;
            this.colEmployeeCode.Visible = true;
            this.colEmployeeCode.VisibleIndex = 0;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Họ lót";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.OptionsColumn.AllowEdit = false;
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
            this.colLastName.OptionsColumn.AllowEdit = false;
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            this.colLastName.Width = 59;
            // 
            // colSex
            // 
            this.colSex.Caption = "Giới tính";
            this.colSex.FieldName = "Sex";
            this.colSex.Name = "colSex";
            this.colSex.OptionsColumn.AllowEdit = false;
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 5;
            this.colSex.Width = 69;
            // 
            // colBirthday
            // 
            this.colBirthday.Caption = "Ngày sinh";
            this.colBirthday.ColumnEdit = this.dateItem;
            this.colBirthday.FieldName = "Birthday";
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.OptionsColumn.AllowEdit = false;
            this.colBirthday.Visible = true;
            this.colBirthday.VisibleIndex = 3;
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
            this.colBirthPlace.OptionsColumn.AllowEdit = false;
            this.colBirthPlace.Visible = true;
            this.colBirthPlace.VisibleIndex = 4;
            this.colBirthPlace.Width = 153;
            // 
            // colCellPhone
            // 
            this.colCellPhone.Caption = "Điện Thoại di động";
            this.colCellPhone.FieldName = "CellPhone";
            this.colCellPhone.Name = "colCellPhone";
            this.colCellPhone.OptionsColumn.AllowEdit = false;
            this.colCellPhone.Visible = true;
            this.colCellPhone.VisibleIndex = 6;
            this.colCellPhone.Width = 99;
            // 
            // colMainAddress
            // 
            this.colMainAddress.Caption = "Địa chỉ thường trú";
            this.colMainAddress.FieldName = "MainAddress";
            this.colMainAddress.Name = "colMainAddress";
            this.colMainAddress.OptionsColumn.AllowEdit = false;
            this.colMainAddress.Visible = true;
            this.colMainAddress.VisibleIndex = 7;
            this.colMainAddress.Width = 162;
            // 
            // colIDCard
            // 
            this.colIDCard.Caption = "CMND";
            this.colIDCard.FieldName = "IDCard";
            this.colIDCard.Name = "colIDCard";
            this.colIDCard.OptionsColumn.AllowEdit = false;
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
            this.colIDCardDate.OptionsColumn.AllowEdit = false;
            this.colIDCardDate.Visible = true;
            this.colIDCardDate.VisibleIndex = 9;
            this.colIDCardDate.Width = 129;
            // 
            // colIDCardPlace
            // 
            this.colIDCardPlace.Caption = "Nơi Cấp";
            this.colIDCardPlace.FieldName = "IDCardPlace";
            this.colIDCardPlace.Name = "colIDCardPlace";
            this.colIDCardPlace.OptionsColumn.AllowEdit = false;
            this.colIDCardPlace.Visible = true;
            this.colIDCardPlace.VisibleIndex = 10;
            this.colIDCardPlace.Width = 131;
            // 
            // colChon
            // 
            this.colChon.Caption = "Chọn";
            this.colChon.FieldName = "Chon";
            this.colChon.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 11;
            this.colChon.Width = 37;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PicNhanVien.CustomHeight = 70;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // btnKiemTraDuLieu
            // 
            this.btnKiemTraDuLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKiemTraDuLieu.Enabled = false;
            this.btnKiemTraDuLieu.Location = new System.Drawing.Point(564, 421);
            this.btnKiemTraDuLieu.Name = "btnKiemTraDuLieu";
            this.btnKiemTraDuLieu.Size = new System.Drawing.Size(105, 27);
            this.btnKiemTraDuLieu.TabIndex = 2;
            this.btnKiemTraDuLieu.Text = "(3) Kiểm tra dữ liệu";
            this.btnKiemTraDuLieu.Click += new System.EventHandler(this.btnKiemTraDuLieu_Click);
            // 
            // btnXoaDuLieu
            // 
            this.btnXoaDuLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaDuLieu.Location = new System.Drawing.Point(489, 421);
            this.btnXoaDuLieu.Name = "btnXoaDuLieu";
            this.btnXoaDuLieu.Size = new System.Drawing.Size(69, 27);
            this.btnXoaDuLieu.TabIndex = 2;
            this.btnXoaDuLieu.Text = "Clear All";
            this.btnXoaDuLieu.Click += new System.EventHandler(this.btnXoaDuLieu_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(673, 421);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(71, 27);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "(4) Thêm";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // checkAll
            // 
            this.checkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAll.EditValue = true;
            this.checkAll.Location = new System.Drawing.Point(413, 425);
            this.checkAll.Name = "checkAll";
            this.checkAll.Properties.Caption = "Chọn hết";
            this.checkAll.Size = new System.Drawing.Size(70, 19);
            this.checkAll.TabIndex = 9;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // checkStatus
            // 
            this.checkStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkStatus.EditValue = true;
            this.checkStatus.Location = new System.Drawing.Point(588, 9);
            this.checkStatus.Name = "checkStatus";
            this.checkStatus.Properties.Caption = "Nhân viên còn hoạt động";
            this.checkStatus.Size = new System.Drawing.Size(146, 19);
            this.checkStatus.TabIndex = 10;
            // 
            // frmDanhSachNhanVien_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 453);
            this.Controls.Add(this.checkStatus);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.gridItem);
            this.Controls.Add(this.linkFile);
            this.Controls.Add(this.btnDocFile);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnXoaDuLieu);
            this.Controls.Add(this.btnKiemTraDuLieu);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhSachNhanVien_Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nạp danh sách nhân viên từ file Excel";
            this.Load += new System.EventHandler(this.frmDanhSachNhanVien_Import_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDuongDan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDuongDan;
        private DevExpress.XtraEditors.SimpleButton btnChon;
        private DevExpress.XtraEditors.SimpleButton btnDocFile;
        private DevExpress.XtraEditors.HyperLinkEdit linkFile;
        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
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
        private DevExpress.XtraEditors.SimpleButton btnKiemTraDuLieu;
        private DevExpress.XtraEditors.SimpleButton btnXoaDuLieu;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraGrid.Columns.GridColumn colKiemTra;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
        private DevExpress.XtraEditors.CheckEdit checkAll;
        private DevExpress.XtraEditors.CheckEdit checkStatus;
    }
}