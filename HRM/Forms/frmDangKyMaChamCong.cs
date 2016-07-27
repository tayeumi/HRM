using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HRM.Forms
{
    public partial class frmDangKyMaChamCong : DevExpress.XtraEditors.XtraForm
    {
        public frmDangKyMaChamCong()
        {
            InitializeComponent();
        }

        string _MaCC = "";
        public frmDangKyMaChamCong(string MaNV,string HoTen,string MaCC)
        {
            InitializeComponent();
            txtMaNV.Text = MaNV;
            txtHoTen.Text = HoTen;
            txtEnrollNumber.Text = MaCC;
            _MaCC = MaCC;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            Class.NhanVien nv = new Class.NhanVien();
            nv.EnrollNumber = txtEnrollNumber.Text;
            nv.EmployeeCode = txtMaNV.Text;
            nv.FullName = txtHoTen.Text;
            nv.EnrollNumber_New = _MaCC;
            if (txtEnrollNumber.Text.Trim().Length != 0)
            {
                DataTable dtcheckEnroll = nv.HRM_EMPLOYEE_GetByEnroll();
                if (dtcheckEnroll.Rows.Count > 0)
                {
                    if (dtcheckEnroll.Rows[0]["EmployeeCode"].ToString() != txtMaNV.Text)
                    {
                        MessageBox.Show(" Mã Chấm công đã có. bạn không thể sử dụng mã chấm công này !!");
                        return;
                    }
                }
            }
            if (checkChangeHistory.Checked)
            {
                // change luon du lieu da cham cong sang cham cong moi
                if (txtEnrollNumber.Text.Trim().Length != 0)
                {
                    if (nv.HRM_EMPLOYEE_UpdateNewEnrollNumber())
                    {
                        Class.App.SaveSuccessfully();
                        (this.Owner as frmDanhSachNhanVien).loaddsNhanVien();
                    }
                    else
                    {
                        Class.App.SaveNotSuccessfully();
                    }
                }
            }
            else
            {
                if (nv.HRM_EMPLOYEE_UpdateEnrollNumber())
                {
                    Class.App.SaveSuccessfully();
                    (this.Owner as frmDanhSachNhanVien).loaddsNhanVien();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            this.Close();
        }
    }
}