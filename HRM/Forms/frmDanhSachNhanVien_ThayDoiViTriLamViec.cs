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
    public partial class frmDanhSachNhanVien_ThayDoiViTriLamViec : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhanVien_ThayDoiViTriLamViec()
        {
            InitializeComponent();
        }
        object[] _emCode;
        public frmDanhSachNhanVien_ThayDoiViTriLamViec(object[] EmCode,DataTable dt)
        {
            InitializeComponent();
            loadBranch();
            _emCode = EmCode;
            string em = "";
            for (int i = 0; i < EmCode.Length; i++)
            {
                em += EmCode[i].ToString() + ",";
            }
            em = em.TrimEnd(',');
            lblDanhSach.Text = "Đang chọn:(" + EmCode.Length + ") " + em;
            string _name = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < EmCode.Length; j++)
                {
                    if (EmCode[j].ToString() == dt.Rows[i]["EmployeeCode"].ToString())
                    {
                        _name += dt.Rows[i]["FirstName"].ToString() + " " + dt.Rows[i]["LastName"].ToString() + ",";
                    }
                }
            }
            _name = _name.TrimEnd(',');
            lblDanhSach.ToolTip = "Đang chọn:(" + EmCode.Length + ") " + _name;
            string tb = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < EmCode.Length; j++)
                {
                    if (EmCode[j].ToString() == dt.Rows[i]["EmployeeCode"].ToString())
                    {
                        tb += dt.Rows[i]["EmployeeCode"].ToString() + ":" + dt.Rows[i]["FirstName"].ToString() + " " + dt.Rows[i]["LastName"].ToString() + "\r\n";
                    }
                }
            }
            alertControl.Show(this, "Danh sách Nhân viên đang chọn:"+ EmCode.Length, tb);
        }
        void loadBranch()
        {
            Class.DanhSach_ChiNhanh cn = new Class.DanhSach_ChiNhanh();
            DataTable dtcn = cn.GetAllList_BRANCH();           
            cboNewBranch.Properties.DataSource = dtcn;
            cboNewBranch.Properties.ValueMember = "BranchCode";
            cboNewBranch.Properties.DisplayMember = "BranchName";
        }

        private void cboNewBranch_EditValueChanged(object sender, EventArgs e)
        {

            Class.PhongBan pb = new Class.PhongBan();
            pb.BranchCode = cboNewBranch.EditValue.ToString();
            DataTable dtpb = pb.LoadDanhSachPhongBanThuocChiNhanh();
            cboNewDepartment.Properties.DataSource = dtpb;
            cboNewDepartment.Properties.ValueMember = "DepartmentCode";
            cboNewDepartment.Properties.DisplayMember = "DepartmentName";
        }

        private void cboNewDepartment_EditValueChanged(object sender, EventArgs e)
        {
            Class.DanhSach_Nhom nhom = new Class.DanhSach_Nhom();
            nhom.DepartmentCode = cboNewDepartment.EditValue.ToString();
            DataTable dtnhom = nhom.GetGroupByDepartment();
            cboNewGroup.Properties.DataSource = dtnhom;
            cboNewGroup.Properties.ValueMember = "GroupCode";
            cboNewGroup.Properties.DisplayMember = "GroupName";
        }
        private void cboNewGroup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Del")
                cboNewGroup.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboNewBranch.EditValue == null || cboNewDepartment.EditValue == null )
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.NhanVien nv = new Class.NhanVien();
            nv.BranchCode = cboNewBranch.EditValue.ToString();
            nv.DepartmentCode = cboNewDepartment.EditValue.ToString();
            nv.GroupCode = cboNewGroup.EditValue.ToString();
            if (nv.HRM_EMPLOYEE_Update_DepartmentFast(_emCode))
            {
                Class.App.SaveSuccessfully();
            }
            else
            {
                Class.App.SaveNotSuccessfully();
            }
            (this.Owner as frmDanhSachNhanVien).loaddsCocautochuc();
            (this.Owner as frmDanhSachNhanVien).loaddsNhanVien();
            this.Close();
        }
    }
}