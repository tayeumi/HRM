namespace HRM.Forms
{
    partial class frmQuaTrinhLamViec_ChucVu_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuaTrinhLamViec_ChucVu_Update));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboOldGroup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOldGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboOldDepartment = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOldDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboOldBranch = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOldBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtOldPosition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNewPosition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboNewBranch = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboNewGroup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboNewDepartment = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtReason = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDecideNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPerson = new DevExpress.XtraEditors.TextEdit();
            this.txtPositionID = new DevExpress.XtraEditors.TextEdit();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboOldGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOldDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOldBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPosition.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNewBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNewGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNewDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecideNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPositionID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageIndex = 1;
            this.btnClose.ImageList = this.imageCollection1;
            this.btnClose.Location = new System.Drawing.Point(388, 223);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 29);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "save.gif");
            this.imageCollection1.Images.SetKeyName(1, "ProgramOff.bmp");
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageIndex = 0;
            this.btnUpdate.ImageList = this.imageCollection1;
            this.btnUpdate.Location = new System.Drawing.Point(296, 223);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 29);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Lưu && Đóng";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboOldGroup);
            this.groupBox1.Controls.Add(this.cboOldDepartment);
            this.groupBox1.Controls.Add(this.cboOldBranch);
            this.groupBox1.Controls.Add(this.txtOldPosition);
            this.groupBox1.Location = new System.Drawing.Point(11, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 146);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cũ";
            // 
            // cboOldGroup
            // 
            this.cboOldGroup.Location = new System.Drawing.Point(20, 81);
            this.cboOldGroup.Name = "cboOldGroup";
            this.cboOldGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "del", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.cboOldGroup.Properties.NullText = "[Chọn tổ, nhóm]";
            this.cboOldGroup.Properties.View = this.gridView2;
            this.cboOldGroup.Size = new System.Drawing.Size(187, 20);
            this.cboOldGroup.TabIndex = 34;
            this.cboOldGroup.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboOldGroup_ButtonClick);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOldGroupName});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colOldGroupName
            // 
            this.colOldGroupName.Caption = "Tổ, Nhóm";
            this.colOldGroupName.FieldName = "GroupName";
            this.colOldGroupName.Name = "colOldGroupName";
            this.colOldGroupName.Visible = true;
            this.colOldGroupName.VisibleIndex = 0;
            // 
            // cboOldDepartment
            // 
            this.cboOldDepartment.Location = new System.Drawing.Point(20, 51);
            this.cboOldDepartment.Name = "cboOldDepartment";
            this.cboOldDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOldDepartment.Properties.NullText = "[Chọn phòng ban làm việc]";
            this.cboOldDepartment.Properties.View = this.gridView1;
            this.cboOldDepartment.Size = new System.Drawing.Size(187, 20);
            this.cboOldDepartment.TabIndex = 34;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOldDepartmentName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colOldDepartmentName
            // 
            this.colOldDepartmentName.Caption = "Phòng ban";
            this.colOldDepartmentName.FieldName = "DepartmentName";
            this.colOldDepartmentName.Name = "colOldDepartmentName";
            this.colOldDepartmentName.Visible = true;
            this.colOldDepartmentName.VisibleIndex = 0;
            // 
            // cboOldBranch
            // 
            this.cboOldBranch.Location = new System.Drawing.Point(20, 22);
            this.cboOldBranch.Name = "cboOldBranch";
            this.cboOldBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOldBranch.Properties.NullText = "[Chọn văn phòng làm việc]";
            this.cboOldBranch.Properties.View = this.gridLookUpEdit1View;
            this.cboOldBranch.Size = new System.Drawing.Size(187, 20);
            this.cboOldBranch.TabIndex = 34;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOldBranchName});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colOldBranchName
            // 
            this.colOldBranchName.Caption = "Chi Nhánh";
            this.colOldBranchName.FieldName = "BranchName";
            this.colOldBranchName.Name = "colOldBranchName";
            this.colOldBranchName.Visible = true;
            this.colOldBranchName.VisibleIndex = 0;
            // 
            // txtOldPosition
            // 
            this.txtOldPosition.Location = new System.Drawing.Point(20, 110);
            this.txtOldPosition.Name = "txtOldPosition";
            this.txtOldPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOldPosition.Size = new System.Drawing.Size(186, 20);
            this.txtOldPosition.TabIndex = 35;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNewPosition);
            this.groupBox2.Controls.Add(this.cboNewBranch);
            this.groupBox2.Controls.Add(this.cboNewGroup);
            this.groupBox2.Controls.Add(this.cboNewDepartment);
            this.groupBox2.Location = new System.Drawing.Point(250, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 146);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mới";
            // 
            // txtNewPosition
            // 
            this.txtNewPosition.Location = new System.Drawing.Point(23, 109);
            this.txtNewPosition.Name = "txtNewPosition";
            this.txtNewPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNewPosition.Properties.NullText = "[Chọn chức vụ mới]";
            this.txtNewPosition.Size = new System.Drawing.Size(187, 20);
            this.txtNewPosition.TabIndex = 3;
            // 
            // cboNewBranch
            // 
            this.cboNewBranch.Location = new System.Drawing.Point(23, 22);
            this.cboNewBranch.Name = "cboNewBranch";
            this.cboNewBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNewBranch.Properties.NullText = "[Chọn văn phòng làm việc]";
            this.cboNewBranch.Properties.View = this.gridView3;
            this.cboNewBranch.Size = new System.Drawing.Size(187, 20);
            this.cboNewBranch.TabIndex = 0;
            this.cboNewBranch.EditValueChanged += new System.EventHandler(this.cboNewBranch_EditValueChanged);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBranchName});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // colBranchName
            // 
            this.colBranchName.Caption = "Tên Chi nhánh";
            this.colBranchName.FieldName = "BranchName";
            this.colBranchName.Name = "colBranchName";
            this.colBranchName.Visible = true;
            this.colBranchName.VisibleIndex = 0;
            // 
            // cboNewGroup
            // 
            this.cboNewGroup.EditValue = "";
            this.cboNewGroup.Location = new System.Drawing.Point(23, 81);
            this.cboNewGroup.Name = "cboNewGroup";
            this.cboNewGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Del", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.cboNewGroup.Properties.NullText = "";
            this.cboNewGroup.Properties.View = this.gridView5;
            this.cboNewGroup.Size = new System.Drawing.Size(187, 20);
            this.cboNewGroup.TabIndex = 2;
            this.cboNewGroup.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboNewGroup_ButtonClick);
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroupName});
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // colGroupName
            // 
            this.colGroupName.Caption = "Tổ, nhóm";
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 0;
            // 
            // cboNewDepartment
            // 
            this.cboNewDepartment.Location = new System.Drawing.Point(23, 51);
            this.cboNewDepartment.Name = "cboNewDepartment";
            this.cboNewDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNewDepartment.Properties.NullText = "[Chọn phòng ban làm việc]";
            this.cboNewDepartment.Properties.View = this.gridView4;
            this.cboNewDepartment.Size = new System.Drawing.Size(187, 20);
            this.cboNewDepartment.TabIndex = 1;
            this.cboNewDepartment.EditValueChanged += new System.EventHandler(this.cboNewDepartment_EditValueChanged);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDepartmentName});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Caption = "Phòng ban";
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 165);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Lý do thay đổi";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(84, 162);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(397, 20);
            this.txtReason.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 193);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "Số quyết định";
            // 
            // txtDecideNumber
            // 
            this.txtDecideNumber.Location = new System.Drawing.Point(84, 190);
            this.txtDecideNumber.Name = "txtDecideNumber";
            this.txtDecideNumber.Size = new System.Drawing.Size(35, 20);
            this.txtDecideNumber.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(123, 194);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 13);
            this.labelControl3.TabIndex = 34;
            this.labelControl3.Text = "Ngày ban hành";
            // 
            // dateDate
            // 
            this.dateDate.EditValue = null;
            this.dateDate.Location = new System.Drawing.Point(199, 190);
            this.dateDate.Name = "dateDate";
            this.dateDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateDate.Size = new System.Drawing.Size(82, 20);
            this.dateDate.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(285, 194);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 34;
            this.labelControl4.Text = "Người ban hành";
            // 
            // txtPerson
            // 
            this.txtPerson.Location = new System.Drawing.Point(363, 190);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(118, 20);
            this.txtPerson.TabIndex = 3;
            // 
            // txtPositionID
            // 
            this.txtPositionID.Location = new System.Drawing.Point(26, 286);
            this.txtPositionID.Name = "txtPositionID";
            this.txtPositionID.Size = new System.Drawing.Size(155, 20);
            this.txtPositionID.TabIndex = 35;
            this.txtPositionID.Visible = false;
            // 
            // alertControl
            // 
            this.alertControl.AllowHtmlText = true;
            this.alertControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.alertControl.AppearanceCaption.Options.UseForeColor = true;
            this.alertControl.AppearanceText.ForeColor = System.Drawing.Color.Blue;
            this.alertControl.AppearanceText.Options.UseForeColor = true;
            this.alertControl.AutoFormDelay = 5000;
            this.alertControl.AutoHeight = true;
            // 
            // frmQuaTrinhLamViec_ChucVu_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(498, 264);
            this.Controls.Add(this.txtPositionID);
            this.Controls.Add(this.txtPerson);
            this.Controls.Add(this.dateDate);
            this.Controls.Add(this.txtDecideNumber);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuaTrinhLamViec_ChucVu_Update";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmQuaTrinhLamViec_ChucVu_Update";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboOldGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOldDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOldBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPosition.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNewBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNewGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNewDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecideNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPositionID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.GridLookUpEdit cboOldGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.GridLookUpEdit cboOldDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GridLookUpEdit cboOldBranch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.GridLookUpEdit cboNewBranch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.GridLookUpEdit cboNewGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.GridLookUpEdit cboNewDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtReason;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDecideNumber;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPerson;
        private DevExpress.XtraEditors.TextEdit txtPositionID;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraEditors.ComboBoxEdit txtNewPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colOldGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colOldDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colOldBranchName;
        private DevExpress.XtraEditors.ComboBoxEdit txtOldPosition;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
    }
}