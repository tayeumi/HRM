namespace HRM.Forms
{
    partial class frmDanhMucChuongTrinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucChuongTrinh));
            this.navBarMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnCallDanhMucChucVu = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucChuyenMon = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucBangCap = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucQuocTich = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucDanToc = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucTonGiao = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucQuanHeGiaDinh = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucHocVan = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucTinHoc = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucNgoaiNgu = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhMucKyNang = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnCallDanhSachChiNhanh = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhSachPhongBan = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallDanhSachNhom = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnCallCaLamViec = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallKyHieuChamCong = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCallThietBiChamCong = new DevExpress.XtraNavBar.NavBarItem();
            this.imageLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.imageSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.pControls = new DevExpress.XtraEditors.PanelControl();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HRM.frmWaiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.navBarMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pControls)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarMenu
            // 
            this.navBarMenu.ActiveGroup = this.navBarGroup1;
            this.navBarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarMenu.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3});
            this.navBarMenu.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnCallDanhMucChucVu,
            this.btnCallDanhMucChuyenMon,
            this.btnCallDanhMucBangCap,
            this.btnCallDanhMucQuocTich,
            this.btnCallDanhMucDanToc,
            this.btnCallDanhMucTonGiao,
            this.btnCallDanhMucQuanHeGiaDinh,
            this.btnCallDanhMucTinHoc,
            this.btnCallDanhMucNgoaiNgu,
            this.btnCallDanhMucKyNang,
            this.btnCallDanhSachPhongBan,
            this.btnCallDanhMucHocVan,
            this.btnCallDanhSachChiNhanh,
            this.btnCallDanhSachNhom,
            this.btnCallCaLamViec,
            this.btnCallKyHieuChamCong,
            this.btnCallThietBiChamCong});
            this.navBarMenu.LargeImages = this.imageLarge;
            this.navBarMenu.Location = new System.Drawing.Point(0, 0);
            this.navBarMenu.Name = "navBarMenu";
            this.navBarMenu.OptionsNavPane.ExpandedWidth = 166;
            this.navBarMenu.Size = new System.Drawing.Size(208, 443);
            this.navBarMenu.SmallImages = this.imageSmall;
            this.navBarMenu.TabIndex = 0;
            this.navBarMenu.Text = "Danh mục nhân sự";
            this.navBarMenu.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarGroup1.Appearance.Options.UseFont = true;
            this.navBarGroup1.AppearanceBackground.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarGroup1.AppearanceBackground.Options.UseFont = true;
            this.navBarGroup1.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarGroup1.AppearanceHotTracked.Options.UseFont = true;
            this.navBarGroup1.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarGroup1.AppearancePressed.Options.UseFont = true;
            this.navBarGroup1.Caption = "Danh mục nhân sự";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucChucVu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucChuyenMon),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucBangCap),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucQuocTich),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucDanToc),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucTonGiao),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucQuanHeGiaDinh),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucHocVan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucTinHoc),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucNgoaiNgu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhMucKyNang)});
            this.navBarGroup1.LargeImageIndex = 1;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.TopVisibleLinkIndex = 5;
            // 
            // btnCallDanhMucChucVu
            // 
            this.btnCallDanhMucChucVu.Caption = "1.Chức vụ";
            this.btnCallDanhMucChucVu.Name = "btnCallDanhMucChucVu";
            this.btnCallDanhMucChucVu.SmallImageIndex = 1;
            this.btnCallDanhMucChucVu.Tag = "DMCT_CV_Xem";
            this.btnCallDanhMucChucVu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucChucVu_LinkClicked);
            // 
            // btnCallDanhMucChuyenMon
            // 
            this.btnCallDanhMucChuyenMon.Caption = "2.Chuyên môn";
            this.btnCallDanhMucChuyenMon.Name = "btnCallDanhMucChuyenMon";
            this.btnCallDanhMucChuyenMon.SmallImageIndex = 1;
            this.btnCallDanhMucChuyenMon.Tag = "DMCT_CM_Xem";
            this.btnCallDanhMucChuyenMon.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucChuyenMon_LinkClicked);
            // 
            // btnCallDanhMucBangCap
            // 
            this.btnCallDanhMucBangCap.Caption = "3.Bằng cấp";
            this.btnCallDanhMucBangCap.Name = "btnCallDanhMucBangCap";
            this.btnCallDanhMucBangCap.SmallImageIndex = 1;
            this.btnCallDanhMucBangCap.Tag = "DMCT_BC_Xem";
            this.btnCallDanhMucBangCap.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucBangCap_LinkClicked);
            // 
            // btnCallDanhMucQuocTich
            // 
            this.btnCallDanhMucQuocTich.Caption = "4.Quốc tịch";
            this.btnCallDanhMucQuocTich.Name = "btnCallDanhMucQuocTich";
            this.btnCallDanhMucQuocTich.SmallImageIndex = 1;
            this.btnCallDanhMucQuocTich.Tag = "DMCT_QT_Xem";
            this.btnCallDanhMucQuocTich.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucQuocTich_LinkClicked);
            // 
            // btnCallDanhMucDanToc
            // 
            this.btnCallDanhMucDanToc.Caption = "5.Dân tộc";
            this.btnCallDanhMucDanToc.Name = "btnCallDanhMucDanToc";
            this.btnCallDanhMucDanToc.SmallImageIndex = 1;
            this.btnCallDanhMucDanToc.Tag = "DMCT_DT_Xem";
            this.btnCallDanhMucDanToc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucDanToc_LinkClicked);
            // 
            // btnCallDanhMucTonGiao
            // 
            this.btnCallDanhMucTonGiao.Caption = "6.Tôn giáo";
            this.btnCallDanhMucTonGiao.Name = "btnCallDanhMucTonGiao";
            this.btnCallDanhMucTonGiao.SmallImageIndex = 1;
            this.btnCallDanhMucTonGiao.Tag = "DMCT_TG_Xem";
            this.btnCallDanhMucTonGiao.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucTonGiao_LinkClicked);
            // 
            // btnCallDanhMucQuanHeGiaDinh
            // 
            this.btnCallDanhMucQuanHeGiaDinh.Caption = "7.Quan hệ gia đình";
            this.btnCallDanhMucQuanHeGiaDinh.Name = "btnCallDanhMucQuanHeGiaDinh";
            this.btnCallDanhMucQuanHeGiaDinh.SmallImageIndex = 1;
            this.btnCallDanhMucQuanHeGiaDinh.Tag = "DMCT_QHGD_Xem";
            this.btnCallDanhMucQuanHeGiaDinh.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucQuanHeGiaDinh_LinkClicked);
            // 
            // btnCallDanhMucHocVan
            // 
            this.btnCallDanhMucHocVan.Caption = "8.Học vấn";
            this.btnCallDanhMucHocVan.Name = "btnCallDanhMucHocVan";
            this.btnCallDanhMucHocVan.SmallImageIndex = 1;
            this.btnCallDanhMucHocVan.Tag = "DMCT_HV_Xem";
            this.btnCallDanhMucHocVan.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucHocVan_LinkClicked);
            // 
            // btnCallDanhMucTinHoc
            // 
            this.btnCallDanhMucTinHoc.Caption = "9.Tin học";
            this.btnCallDanhMucTinHoc.Name = "btnCallDanhMucTinHoc";
            this.btnCallDanhMucTinHoc.SmallImageIndex = 1;
            this.btnCallDanhMucTinHoc.Tag = "DMCT_TH_Xem";
            this.btnCallDanhMucTinHoc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucTinHoc_LinkClicked);
            // 
            // btnCallDanhMucNgoaiNgu
            // 
            this.btnCallDanhMucNgoaiNgu.Caption = "10.Ngoại ngữ";
            this.btnCallDanhMucNgoaiNgu.Name = "btnCallDanhMucNgoaiNgu";
            this.btnCallDanhMucNgoaiNgu.SmallImageIndex = 1;
            this.btnCallDanhMucNgoaiNgu.Tag = "DMCT_NN_Xem";
            this.btnCallDanhMucNgoaiNgu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucNgoaiNgu_LinkClicked);
            // 
            // btnCallDanhMucKyNang
            // 
            this.btnCallDanhMucKyNang.Caption = "11.Kỹ năng";
            this.btnCallDanhMucKyNang.Name = "btnCallDanhMucKyNang";
            this.btnCallDanhMucKyNang.SmallImageIndex = 1;
            this.btnCallDanhMucKyNang.Tag = "DMCT_KN_Xem";
            this.btnCallDanhMucKyNang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhMucKyNang_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarGroup2.Appearance.Options.UseFont = true;
            this.navBarGroup2.AppearanceBackground.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarGroup2.AppearanceBackground.Options.UseFont = true;
            this.navBarGroup2.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarGroup2.AppearanceHotTracked.Options.UseFont = true;
            this.navBarGroup2.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarGroup2.AppearancePressed.Options.UseFont = true;
            this.navBarGroup2.Caption = "Cơ cấu tổ chức";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhSachChiNhanh),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhSachPhongBan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallDanhSachNhom)});
            this.navBarGroup2.LargeImageIndex = 0;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // btnCallDanhSachChiNhanh
            // 
            this.btnCallDanhSachChiNhanh.Caption = "Danh sách chi nhánh";
            this.btnCallDanhSachChiNhanh.Name = "btnCallDanhSachChiNhanh";
            this.btnCallDanhSachChiNhanh.SmallImageIndex = 0;
            this.btnCallDanhSachChiNhanh.Tag = "DMCT_CN_Xem";
            this.btnCallDanhSachChiNhanh.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhSachChiNhanh_LinkClicked);
            // 
            // btnCallDanhSachPhongBan
            // 
            this.btnCallDanhSachPhongBan.Caption = "Danh sách phòng ban";
            this.btnCallDanhSachPhongBan.Name = "btnCallDanhSachPhongBan";
            this.btnCallDanhSachPhongBan.SmallImageIndex = 0;
            this.btnCallDanhSachPhongBan.Tag = "DMCT_PB_Xem";
            this.btnCallDanhSachPhongBan.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhSachPhongBan_LinkClicked);
            // 
            // btnCallDanhSachNhom
            // 
            this.btnCallDanhSachNhom.Caption = "Các Tổ, Nhóm";
            this.btnCallDanhSachNhom.Name = "btnCallDanhSachNhom";
            this.btnCallDanhSachNhom.SmallImageIndex = 0;
            this.btnCallDanhSachNhom.Tag = "DMCT_TN_Xem";
            this.btnCallDanhSachNhom.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallDanhSachNhom_LinkClicked);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup3.Appearance.Options.UseFont = true;
            this.navBarGroup3.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup3.AppearancePressed.Options.UseFont = true;
            this.navBarGroup3.Caption = "Danh mục chấm công";
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallCaLamViec),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallKyHieuChamCong),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCallThietBiChamCong)});
            this.navBarGroup3.LargeImageIndex = 2;
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // btnCallCaLamViec
            // 
            this.btnCallCaLamViec.Caption = "Ca làm việc";
            this.btnCallCaLamViec.Name = "btnCallCaLamViec";
            this.btnCallCaLamViec.SmallImageIndex = 2;
            this.btnCallCaLamViec.Tag = "DMCT_CA_Xem";
            this.btnCallCaLamViec.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallCaLamViec_LinkClicked);
            // 
            // btnCallKyHieuChamCong
            // 
            this.btnCallKyHieuChamCong.Caption = "Ký hiệu chấm công";
            this.btnCallKyHieuChamCong.Name = "btnCallKyHieuChamCong";
            this.btnCallKyHieuChamCong.SmallImageIndex = 2;
            this.btnCallKyHieuChamCong.Tag = "DMCT_KHCC_Xem";
            this.btnCallKyHieuChamCong.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallKyHieuChamCong_LinkClicked);
            // 
            // btnCallThietBiChamCong
            // 
            this.btnCallThietBiChamCong.Caption = "Thiết bị chấm công";
            this.btnCallThietBiChamCong.Name = "btnCallThietBiChamCong";
            this.btnCallThietBiChamCong.SmallImageIndex = 3;
            this.btnCallThietBiChamCong.Tag = "DMCT_TBCC_Xem";
            this.btnCallThietBiChamCong.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCallThietBiChamCong_LinkClicked);
            // 
            // imageLarge
            // 
            this.imageLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.imageLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageLarge.ImageStream")));
            this.imageLarge.Images.SetKeyName(0, "chart_organisation.png");
            this.imageLarge.Images.SetKeyName(1, "user_group.png");
            this.imageLarge.Images.SetKeyName(2, "clock.png");
            // 
            // imageSmall
            // 
            this.imageSmall.ImageSize = new System.Drawing.Size(20, 20);
            this.imageSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageSmall.ImageStream")));
            this.imageSmall.Images.SetKeyName(0, "chart_organisation_add.png");
            this.imageSmall.Images.SetKeyName(1, "note_3.png");
            this.imageSmall.Images.SetKeyName(2, "notes_1.png");
            this.imageSmall.Images.SetKeyName(3, "connect.png");
            // 
            // pControls
            // 
            this.pControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pControls.Location = new System.Drawing.Point(208, 0);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(531, 443);
            this.pControls.TabIndex = 1;
            // 
            // frmDanhMucChuongTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 443);
            this.Controls.Add(this.pControls);
            this.Controls.Add(this.navBarMenu);
            this.Name = "frmDanhMucChuongTrinh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh mục chương trình";
            this.Load += new System.EventHandler(this.frmDanhMucChuongTrinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarMenu;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhSachPhongBan;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucChucVu;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucChuyenMon;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucBangCap;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucQuocTich;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucDanToc;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucTonGiao;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucQuanHeGiaDinh;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucTinHoc;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucNgoaiNgu;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucKyNang;
        private DevExpress.XtraEditors.PanelControl pControls;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhMucHocVan;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhSachChiNhanh;
        private DevExpress.Utils.ImageCollection imageSmall;
        private DevExpress.Utils.ImageCollection imageLarge;
        private DevExpress.XtraNavBar.NavBarItem btnCallDanhSachNhom;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem btnCallCaLamViec;
        private DevExpress.XtraNavBar.NavBarItem btnCallKyHieuChamCong;
        private DevExpress.XtraNavBar.NavBarItem btnCallThietBiChamCong;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}