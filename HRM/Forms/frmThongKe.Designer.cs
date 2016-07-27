namespace HRM.Forms
{
    partial class frmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnCallThongKeNhanSu = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallThongKeNgayNghi = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallSinhNhatNhanVienTheoThang = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnCallTinhHinhChamCong = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.pControls = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pControls)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup3,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnCallThongKeNhanSu,
            this.btnCallThongKeNgayNghi,
            this.btnCallSinhNhatNhanVienTheoThang,
            this.btnCallTinhHinhChamCong});
            this.navBarControl1.LargeImages = this.imageCollection1;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 223;
            this.navBarControl1.Size = new System.Drawing.Size(223, 593);
            this.navBarControl1.SmallImages = this.imageCollection2;
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "Thống kê";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Tình hình nhân sự";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallThongKeNhanSu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallThongKeNgayNghi),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallSinhNhatNhanVienTheoThang)});
            this.navBarGroup1.LargeImageIndex = 0;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnCallThongKeNhanSu
            // 
            this.btnCallThongKeNhanSu.Caption = "Biểu đồ thống kê tình hình nhân sự";
            this.btnCallThongKeNhanSu.LargeImageIndex = 1;
            this.btnCallThongKeNhanSu.Name = "btnCallThongKeNhanSu";
            this.btnCallThongKeNhanSu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallThongKeNhanSu_LinkClicked);
            // 
            // btnCallThongKeNgayNghi
            // 
            this.btnCallThongKeNgayNghi.Caption = "Thống kê Ngày nghỉ phép năm";
            this.btnCallThongKeNgayNghi.LargeImageIndex = 2;
            this.btnCallThongKeNgayNghi.Name = "btnCallThongKeNgayNghi";
            this.btnCallThongKeNgayNghi.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallThongKeNgayNghi_LinkClicked);
            // 
            // btnCallSinhNhatNhanVienTheoThang
            // 
            this.btnCallSinhNhatNhanVienTheoThang.Caption = "Sinh nhật nhân viên theo tháng";
            this.btnCallSinhNhatNhanVienTheoThang.LargeImageIndex = 4;
            this.btnCallSinhNhatNhanVienTheoThang.Name = "btnCallSinhNhatNhanVienTheoThang";
            this.btnCallSinhNhatNhanVienTheoThang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallSinhNhatNhanVienTheoThang_LinkClicked);
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.gridItem);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(203, 181);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // gridItem
            // 
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.Size = new System.Drawing.Size(203, 181);
            this.gridItem.TabIndex = 0;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTK,
            this.colSL});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.ShowColumnHeaders = false;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.OptionsView.ShowIndicator = false;
            // 
            // colTK
            // 
            this.colTK.FieldName = "Name";
            this.colTK.Name = "colTK";
            this.colTK.Visible = true;
            this.colTK.VisibleIndex = 0;
            this.colTK.Width = 177;
            // 
            // colSL
            // 
            this.colSL.FieldName = "Value";
            this.colSL.Name = "colSL";
            this.colSL.Visible = true;
            this.colSL.VisibleIndex = 1;
            this.colSL.Width = 34;
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Tình hình chấm công";
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallTinhHinhChamCong)});
            this.navBarGroup3.LargeImageIndex = 5;
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // btnCallTinhHinhChamCong
            // 
            this.btnCallTinhHinhChamCong.Caption = "Thống kê đi trễ về sớm";
            this.btnCallTinhHinhChamCong.Name = "btnCallTinhHinhChamCong";
            this.btnCallTinhHinhChamCong.SmallImageIndex = 0;
            this.btnCallTinhHinhChamCong.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallTinhHinhChamCong_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Thống kê số liệu";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup2.GroupClientHeight = 181;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.LargeImageIndex = 3;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(40, 40);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "stats.png");
            this.imageCollection1.Images.SetKeyName(1, "line_chart.png");
            this.imageCollection1.Images.SetKeyName(2, "pie_chart.png");
            this.imageCollection1.Images.SetKeyName(3, "pie_chart (1).png");
            this.imageCollection1.Images.SetKeyName(4, "cookie.png");
            this.imageCollection1.Images.SetKeyName(5, "Action_Chart_ShowDesigner_32x32.png");
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageSize = new System.Drawing.Size(25, 25);
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "Navigation_Item_PivotChart_32x32.png");
            // 
            // pControls
            // 
            this.pControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pControls.Location = new System.Drawing.Point(223, 0);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(518, 593);
            this.pControls.TabIndex = 1;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 593);
            this.Controls.Add(this.pControls);
            this.Controls.Add(this.navBarControl1);
            this.Name = "frmThongKe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem btnCallThongKeNhanSu;
        private DevExpress.XtraEditors.PanelControl pControls;
        private DevExpress.XtraNavBar.NavBarItem btnCallThongKeNgayNghi;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colTK;
        private DevExpress.XtraGrid.Columns.GridColumn colSL;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem btnCallSinhNhatNhanVienTheoThang;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem btnCallTinhHinhChamCong;
        private DevExpress.Utils.ImageCollection imageCollection2;
    }
}