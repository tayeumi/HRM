using System;

namespace HRM.Forms
{
    public partial class frmThongKe : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void btnCallThongKeNhanSu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!_checkControl("frmThongKe_BieuDo"))
            {
                frmThongKe_BieuDo frm = new frmThongKe_BieuDo();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
        }
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

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            btnCallThongKeNhanSu_LinkClicked(null, null);
            HRM_EMPLOYEE_GetStatistical();
        }

        private void HRM_EMPLOYEE_GetStatistical()
        {
            Class.ThongKe tk = new Class.ThongKe();
            gridItem.DataSource = tk.HRM_EMPLOYEE_GetStatistical();

        }

        private void btnCallSinhNhatNhanVienTheoThang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!_checkControl("frmThongKe_SinhNhat"))
            {
                frmThongKe_SinhNhat frm = new frmThongKe_SinhNhat();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
        }

        private void btnCallTinhHinhChamCong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!_checkControl("frmThongKe_DiTre"))
            {
                frmThongKe_DiTre frm = new frmThongKe_DiTre();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
        }

        private void btnCallThongKeNgayNghi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!_checkControl("frmThongKe_NgayPhep"))
            {
                frmThongKe_NgayPhep frm = new frmThongKe_NgayPhep();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
        }
    }
}