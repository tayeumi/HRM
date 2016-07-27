using System;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhMucChuongTrinh : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucChuongTrinh()
        {
            InitializeComponent();
        }

        #region Call_linkbutton_DanhMuc_NhanSu
        private void btnCallDanhMucChucVu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
           if(!_checkControl("frmDanhMucChucVu"))
           {
               frmDanhMucChucVu frm = new frmDanhMucChucVu();
               frm.TopLevel = false;
               frm.Dock = System.Windows.Forms.DockStyle.Fill;
               pControls.Controls.Add(frm);
               frm.Show();
           }
           Waiting.CloseWaitForm();
        }    

        private void btnCallDanhMucBangCap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucBangCap"))
            {
                frmDanhMucBangCap frm = new frmDanhMucBangCap();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);   
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhMucChuyenMon_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucChuyenMon"))
            {
                frmDanhMucChuyenMon frm = new frmDanhMucChuyenMon();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }
        
        private void btnCallDanhMucQuocTich_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucQuocTich"))
            {
                frmDanhMucQuocTich frm = new frmDanhMucQuocTich();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhMucDanToc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucDanToc"))
            {
                frmDanhMucDanToc frm = new frmDanhMucDanToc();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhMucTonGiao_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucTonGiao"))
            {
                frmDanhMucTonGiao frm = new frmDanhMucTonGiao();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhMucQuanHeGiaDinh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucQuanHeGiaDinh"))
            {
                frmDanhMucQuanHeGiaDinh frm = new frmDanhMucQuanHeGiaDinh();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhMucTinHoc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucTinHoc"))
            {
                frmDanhMucTinHoc frm = new frmDanhMucTinHoc();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhMucNgoaiNgu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucNgoaiNgu"))
            {
                frmDanhMucNgoaiNgu frm = new frmDanhMucNgoaiNgu();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhMucKyNang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucKyNang"))
            {
                frmDanhMucKyNang frm = new frmDanhMucKyNang();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhMucHocVan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucHocVan"))
            {
                frmDanhMucHocVan frm = new frmDanhMucHocVan();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }
        
        #endregion


        #region KiemTraFormOpen And ReShow

        private bool _checkControl(string frmForm)
        {
            for (int i = 0; i < pControls.Controls.Count; i++)
            {
                if (pControls.Controls[i].Text == frmForm)
                {
                    pControls.Controls[i].Show();
                    // pControls.Controls[i].Size = new System.Drawing.Size(pControls.Width, pControls.Height);
                    return true;
                }
                else
                {
                    pControls.Controls[i].Hide();
                }
            }
            return false;
        }
        #endregion

        private void btnCallDanhSachPhongBan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhSachPhongBan"))
            {
                frmDanhSachPhongBan frm = new frmDanhSachPhongBan();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhSachNhom_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhSachNhom"))
            {
                frmDanhSachNhom frm = new frmDanhSachNhom();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallDanhSachChiNhanh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhSachChiNhanh"))
            {
                frmDanhSachChiNhanh frm = new frmDanhSachChiNhanh();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void frmDanhMucChuongTrinh_Load(object sender, EventArgs e)
        {            
            // khoa tat cac chuc nang neu duoc add phan quyen vao the tag           
                for (int i = 0; i < navBarMenu.Groups.Count; i++)
                {
                    for (int j = 0; j < navBarMenu.Groups[i].ItemLinks.Count; j++)
                    {
                        if (navBarMenu.Groups[i].ItemLinks[j].Item.Tag != null)
                        {
                            string txt = navBarMenu.Groups[i].ItemLinks[j].Item.Tag.ToString();
                            if (txt.Length > 0)
                            {
                                navBarMenu.Groups[i].ItemLinks[j].Item.Enabled = false;
                            }
                        }
                    }
                }      
            // het vong lap khoa
            // goi phan quyen
                for (int i = 0; i < navBarMenu.Groups.Count; i++)
                {
                    for (int j = 0; j < navBarMenu.Groups[i].ItemLinks.Count; j++)
                    {
                        if (navBarMenu.Groups[i].ItemLinks[j].Item.Tag != null)
                        {
                            string txt = navBarMenu.Groups[i].ItemLinks[j].Item.Tag.ToString();
                            if (txt.Length > 0)
                            {
                                for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                                {
                                    string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                    if (_Object_ID == txt)
                                    {
                                        navBarMenu.Groups[i].ItemLinks[j].Item.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }      
           // het goi phan quyen

        }

        private void btnCallCaLamViec_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucCaLamViec"))
            {
                frmDanhMucCaLamViec frm = new frmDanhMucCaLamViec();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallKyHieuChamCong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucKyHieuChamCong"))
            {
                frmDanhMucKyHieuChamCong frm = new frmDanhMucKyHieuChamCong();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnCallThietBiChamCong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!_checkControl("frmDanhMucThietBiChamCong"))
            {
                frmDanhMucThietBiChamCong frm = new frmDanhMucThietBiChamCong();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

            
    }
}