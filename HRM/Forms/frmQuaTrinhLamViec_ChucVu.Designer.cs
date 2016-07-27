namespace HRM.Forms
{
    partial class frmQuaTrinhLamViec_ChucVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuaTrinhLamViec_ChucVu));
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNewBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Reason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPositionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnDel
            // 
            this.btnDel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnDel.Caption = "Xóa";
            this.btnDel.Id = 3;
            this.btnDel.ImageIndex = 1;
            this.btnDel.Name = "btnDel";
            this.btnDel.Tag = "QTLV_CV_Xoa";
            this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMenu});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.btnAdd,
            this.btnEdit,
            this.btnDel});
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.barMenu;
            // 
            // barMenu
            // 
            this.barMenu.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.barMenu.BarAppearance.Normal.Options.UseFont = true;
            this.barMenu.BarName = "Status bar";
            this.barMenu.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.DrawDragBorder = false;
            this.barMenu.OptionsBar.MultiLine = true;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Status bar";
            // 
            // btnAdd
            // 
            this.btnAdd.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnAdd.Caption = "Thêm";
            this.btnAdd.Id = 1;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Tag = "QTLV_CV_Them";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 2;
            this.btnEdit.ImageIndex = 2;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Tag = "QTLV_CV_Sua";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(542, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 235);
            this.barDockControlBottom.Size = new System.Drawing.Size(542, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 235);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(542, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 235);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "add_mode.png");
            this.imageCollection1.Images.SetKeyName(1, "del_mode.png");
            this.imageCollection1.Images.SetKeyName(2, "edit_mode.png");
            // 
            // gridItem
            // 
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.Size = new System.Drawing.Size(542, 235);
            this.gridItem.TabIndex = 7;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNewBranch,
            this.colNewDepartment,
            this.colNewGroup,
            this.colNewPosition,
            this.colDate,
            this.Reason,
            this.colPerson,
            this.colPositionID,
            this.colOldBranch,
            this.colOldDepartment,
            this.colOldGroup,
            this.colOldPosition});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridItemDetail.DoubleClick += new System.EventHandler(this.gridItemDetail_DoubleClick);
            this.gridItemDetail.RowCountChanged += new System.EventHandler(this.gridItemDetail_RowCountChanged);
            // 
            // colNewBranch
            // 
            this.colNewBranch.Caption = "Chi nhánh mới";
            this.colNewBranch.FieldName = "NewBranchName";
            this.colNewBranch.Name = "colNewBranch";
            this.colNewBranch.Visible = true;
            this.colNewBranch.VisibleIndex = 4;
            this.colNewBranch.Width = 156;
            // 
            // colNewDepartment
            // 
            this.colNewDepartment.Caption = "Phòng ban mới";
            this.colNewDepartment.FieldName = "NewDepartmentName";
            this.colNewDepartment.Name = "colNewDepartment";
            this.colNewDepartment.Visible = true;
            this.colNewDepartment.VisibleIndex = 5;
            this.colNewDepartment.Width = 115;
            // 
            // colNewGroup
            // 
            this.colNewGroup.Caption = "Nhóm mới";
            this.colNewGroup.FieldName = "NewGroupName";
            this.colNewGroup.Name = "colNewGroup";
            this.colNewGroup.Visible = true;
            this.colNewGroup.VisibleIndex = 6;
            this.colNewGroup.Width = 109;
            // 
            // colNewPosition
            // 
            this.colNewPosition.Caption = "Chức vụ mới";
            this.colNewPosition.FieldName = "NewPosition";
            this.colNewPosition.Name = "colNewPosition";
            this.colNewPosition.Visible = true;
            this.colNewPosition.VisibleIndex = 7;
            this.colNewPosition.Width = 125;
            // 
            // colDate
            // 
            this.colDate.Caption = "Ngày áp dụng";
            this.colDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 8;
            this.colDate.Width = 83;
            // 
            // Reason
            // 
            this.Reason.Caption = "Lý do";
            this.Reason.FieldName = "Reason";
            this.Reason.Name = "Reason";
            this.Reason.Visible = true;
            this.Reason.VisibleIndex = 9;
            this.Reason.Width = 126;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Người quyết định";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 10;
            this.colPerson.Width = 103;
            // 
            // colPositionID
            // 
            this.colPositionID.Caption = "PositionID";
            this.colPositionID.FieldName = "PositionID";
            this.colPositionID.Name = "colPositionID";
            // 
            // colOldBranch
            // 
            this.colOldBranch.Caption = "Chi nhánh cũ";
            this.colOldBranch.FieldName = "OldBranchName";
            this.colOldBranch.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colOldBranch.Name = "colOldBranch";
            this.colOldBranch.Visible = true;
            this.colOldBranch.VisibleIndex = 0;
            this.colOldBranch.Width = 150;
            // 
            // colOldDepartment
            // 
            this.colOldDepartment.Caption = "Phòng ban cũ";
            this.colOldDepartment.FieldName = "OldDepartmentName";
            this.colOldDepartment.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colOldDepartment.Name = "colOldDepartment";
            this.colOldDepartment.Visible = true;
            this.colOldDepartment.VisibleIndex = 1;
            this.colOldDepartment.Width = 110;
            // 
            // colOldGroup
            // 
            this.colOldGroup.Caption = "Tổ, nhóm cũ";
            this.colOldGroup.FieldName = "OldGroupName";
            this.colOldGroup.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colOldGroup.Name = "colOldGroup";
            this.colOldGroup.Visible = true;
            this.colOldGroup.VisibleIndex = 2;
            this.colOldGroup.Width = 81;
            // 
            // colOldPosition
            // 
            this.colOldPosition.Caption = "chức vụ cũ";
            this.colOldPosition.FieldName = "OldPosition";
            this.colOldPosition.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colOldPosition.Name = "colOldPosition";
            this.colOldPosition.Visible = true;
            this.colOldPosition.VisibleIndex = 3;
            this.colOldPosition.Width = 84;
            // 
            // frmQuaTrinhLamViec_ChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 262);
            this.Controls.Add(this.gridItem);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuaTrinhLamViec_ChucVu";
            this.Text = "frmQuaTrinhLamViec_ChucVu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuaTrinhLamViec_ChucVu_FormClosed);
            this.Load += new System.EventHandler(this.frmQuaTrinhLamViec_ChucVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colNewBranch;
        private DevExpress.XtraGrid.Columns.GridColumn colNewDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colNewGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colNewPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colPositionID;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn Reason;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colOldBranch;
        private DevExpress.XtraGrid.Columns.GridColumn colOldDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colOldGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colOldPosition;
    }
}