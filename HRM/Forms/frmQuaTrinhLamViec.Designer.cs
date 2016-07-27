namespace HRM.Forms
{
    partial class frmQuaTrinhLamViec
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
            this.Photo = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmployeeCode = new DevExpress.XtraEditors.TextEdit();
            this.checkSex = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtBranchName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPosition = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepartmentName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtGroupName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtCellPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtContactAddress = new DevExpress.XtraEditors.TextEdit();
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            this.TabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.TabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.TabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.TabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.TabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.tCBoEmployeeCode = new DevExpress.XtraBars.BarEditItem();
            this.cboEmployeeCode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridEmployeeCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barFullName = new DevExpress.XtraBars.BarEditItem();
            this.txtFulNameBar = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dateBirthday = new DevExpress.XtraEditors.DateEdit();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HRM.frmWaiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.Photo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCellPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.TabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFulNameBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthday.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthday.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Photo
            // 
            this.Photo.Location = new System.Drawing.Point(9, 33);
            this.Photo.Name = "Photo";
            this.Photo.Properties.NullText = "[Chưa có hình]";
            this.Photo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.Photo.Size = new System.Drawing.Size(90, 101);
            this.Photo.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(105, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Mã nhân viên";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(183, 33);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Properties.ReadOnly = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(90, 20);
            this.txtEmployeeCode.TabIndex = 6;
            // 
            // checkSex
            // 
            this.checkSex.Location = new System.Drawing.Point(280, 34);
            this.checkSex.Name = "checkSex";
            this.checkSex.Properties.Caption = "Nam";
            this.checkSex.Size = new System.Drawing.Size(49, 19);
            this.checkSex.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(101, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Tên nhân viên";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(183, 57);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Properties.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(184, 20);
            this.txtFullName.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(373, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Ngày sinh";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(541, 61);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Văn phòng";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(598, 57);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Properties.ReadOnly = true;
            this.txtBranchName.Size = new System.Drawing.Size(183, 20);
            this.txtBranchName.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(502, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(90, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Chức danh hiện tại";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(598, 33);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Properties.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(183, 20);
            this.txtPosition.TabIndex = 6;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(541, 86);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(51, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Phòng ban";
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(598, 82);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Properties.ReadOnly = true;
            this.txtDepartmentName.Size = new System.Drawing.Size(183, 20);
            this.txtDepartmentName.TabIndex = 6;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(565, 110);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(27, 13);
            this.labelControl7.TabIndex = 5;
            this.labelControl7.Text = "Nhóm";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(598, 106);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Properties.ReadOnly = true;
            this.txtGroupName.Size = new System.Drawing.Size(183, 20);
            this.txtGroupName.TabIndex = 6;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(107, 86);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 13);
            this.labelControl8.TabIndex = 5;
            this.labelControl8.Text = "Số điện thoại";
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Location = new System.Drawing.Point(183, 82);
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Properties.ReadOnly = true;
            this.txtCellPhone.Size = new System.Drawing.Size(90, 20);
            this.txtCellPhone.TabIndex = 6;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(278, 86);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(24, 13);
            this.labelControl9.TabIndex = 5;
            this.labelControl9.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(308, 82);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(205, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(137, 110);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(32, 13);
            this.labelControl10.TabIndex = 5;
            this.labelControl10.Text = "Địa chỉ";
            // 
            // txtContactAddress
            // 
            this.txtContactAddress.Location = new System.Drawing.Point(183, 106);
            this.txtContactAddress.Name = "txtContactAddress";
            this.txtContactAddress.Properties.ReadOnly = true;
            this.txtContactAddress.Size = new System.Drawing.Size(330, 20);
            this.txtContactAddress.TabIndex = 6;
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Location = new System.Drawing.Point(2, 146);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedTabPage = this.TabPage1;
            this.TabControl.Size = new System.Drawing.Size(786, 357);
            this.TabControl.TabIndex = 9;
            this.TabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPage1,
            this.TabPage2,
            this.TabPage3,
            this.TabPage4,
            this.TabPage5});
            // 
            // TabPage1
            // 
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Size = new System.Drawing.Size(780, 329);
            this.TabPage1.Text = "Khen thưởng";
            // 
            // TabPage2
            // 
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Size = new System.Drawing.Size(780, 329);
            this.TabPage2.Text = "Kỷ luật";
            // 
            // TabPage3
            // 
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(780, 329);
            this.TabPage3.Text = "Quá trình đào tạo";
            // 
            // TabPage4
            // 
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.PageVisible = false;
            this.TabPage4.Size = new System.Drawing.Size(780, 329);
            this.TabPage4.Text = "Kinh nghiệm làm việc";
            // 
            // TabPage5
            // 
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Size = new System.Drawing.Size(780, 329);
            this.TabPage5.Text = "Thay đổi chức vụ - phòng ban";
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
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.tCBoEmployeeCode,
            this.barFullName});
            this.barManager1.MaxItemId = 5;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboEmployeeCode,
            this.txtFulNameBar});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.tCBoEmployeeCode, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barFullName)});
            this.bar1.Text = "Tools";
            // 
            // tCBoEmployeeCode
            // 
            this.tCBoEmployeeCode.Caption = "Lọc theo nhân viên";
            this.tCBoEmployeeCode.Edit = this.cboEmployeeCode;
            this.tCBoEmployeeCode.Id = 0;
            this.tCBoEmployeeCode.Name = "tCBoEmployeeCode";
            this.tCBoEmployeeCode.Width = 121;
            this.tCBoEmployeeCode.EditValueChanged += new System.EventHandler(this.txtEmployeeCode_EditValueChanged);
            // 
            // cboEmployeeCode
            // 
            this.cboEmployeeCode.AutoHeight = false;
            this.cboEmployeeCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmployeeCode.Name = "cboEmployeeCode";
            this.cboEmployeeCode.NullText = "[Chọn nhân viên]";
            this.cboEmployeeCode.View = this.gridEmployeeCode;
            // 
            // gridEmployeeCode
            // 
            this.gridEmployeeCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLastName,
            this.colFirstName,
            this.colEmployeeCode});
            this.gridEmployeeCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridEmployeeCode.Name = "gridEmployeeCode";
            this.gridEmployeeCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridEmployeeCode.OptionsView.ShowAutoFilterRow = true;
            this.gridEmployeeCode.OptionsView.ShowGroupPanel = false;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Tên";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            this.colLastName.Width = 345;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Họ lót";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 1;
            this.colFirstName.Width = 339;
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Caption = "Mã nhân viên";
            this.colEmployeeCode.FieldName = "EmployeeCode";
            this.colEmployeeCode.Name = "colEmployeeCode";
            this.colEmployeeCode.Visible = true;
            this.colEmployeeCode.VisibleIndex = 0;
            this.colEmployeeCode.Width = 339;
            // 
            // barFullName
            // 
            this.barFullName.Caption = "Họ và tên";
            this.barFullName.Edit = this.txtFulNameBar;
            this.barFullName.EditValue = "";
            this.barFullName.Id = 4;
            this.barFullName.Name = "barFullName";
            this.barFullName.Width = 165;
            // 
            // txtFulNameBar
            // 
            this.txtFulNameBar.AutoHeight = false;
            this.txtFulNameBar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFulNameBar.Name = "txtFulNameBar";
            this.txtFulNameBar.ReadOnly = true;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(788, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 507);
            this.barDockControlBottom.Size = new System.Drawing.Size(788, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 478);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(788, 29);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 478);
            // 
            // dateBirthday
            // 
            this.dateBirthday.EditValue = null;
            this.dateBirthday.Location = new System.Drawing.Point(426, 56);
            this.dateBirthday.MenuManager = this.barManager1;
            this.dateBirthday.Name = "dateBirthday";
            this.dateBirthday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirthday.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateBirthday.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBirthday.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateBirthday.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBirthday.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateBirthday.Properties.ReadOnly = true;
            this.dateBirthday.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateBirthday.Size = new System.Drawing.Size(87, 20);
            this.dateBirthday.TabIndex = 14;
            // 
            // frmQuaTrinhLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 507);
            this.Controls.Add(this.dateBirthday);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.checkSex);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.txtDepartmentName);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.txtCellPhone);
            this.Controls.Add(this.txtContactAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Photo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmQuaTrinhLamViec";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quá trình làm việc";
            this.Activated += new System.EventHandler(this.frmQuaTrinhLamViec_Activated);
            this.Load += new System.EventHandler(this.frmQuaTrinhLamViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Photo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCellPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFulNameBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthday.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirthday.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit Photo;
        private DevExpress.XtraEditors.CheckEdit checkSex;
        private DevExpress.XtraEditors.TextEdit txtPosition;
        private DevExpress.XtraEditors.TextEdit txtBranchName;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtEmployeeCode;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtGroupName;
        private DevExpress.XtraEditors.TextEdit txtDepartmentName;
        private DevExpress.XtraEditors.TextEdit txtCellPhone;
        private DevExpress.XtraEditors.TextEdit txtContactAddress;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraTab.XtraTabControl TabControl;
        private DevExpress.XtraTab.XtraTabPage TabPage1;
        private DevExpress.XtraTab.XtraTabPage TabPage2;
        private DevExpress.XtraTab.XtraTabPage TabPage3;
        private DevExpress.XtraTab.XtraTabPage TabPage4;
        private DevExpress.XtraTab.XtraTabPage TabPage5;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem tCBoEmployeeCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cboEmployeeCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridEmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeCode;
        private DevExpress.XtraBars.BarEditItem barFullName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox txtFulNameBar;
        private DevExpress.XtraEditors.DateEdit dateBirthday;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}