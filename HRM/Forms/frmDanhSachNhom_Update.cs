using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhSachNhom_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhom_Update()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public frmDanhSachNhom_Update(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name;
            GetAllList_BRANCH(); // call danh sach chi nhanh
            if (Add_new)
            {
                txtGroupCode.Text = call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);
                txtGroupCode.Enabled = false;
            }
            _reCallFunction = reCallFunction;
        }
        public void GetAllList_BRANCH()
        {
            Class.PhongBan dm = new Class.PhongBan();
            DataTable dt = dm.LoadDanhSachChiNhanh();
            if (dt.Rows.Count > 0)
            {
                txtBranchName.Properties.DataSource = dt;
                txtBranchName.Properties.DisplayMember = "BranchName";
                txtBranchName.Properties.ValueMember = "BranchCode";
            }
        }

        public void GetListDEPARTMENTByBranch(string strCode)
        {
            Class.PhongBan dm = new Class.PhongBan();
            dm.BranchCode = strCode;
            DataTable dt = dm.LoadDanhSachPhongBanThuocChiNhanh();
            if (dt.Rows.Count > 0)
            {
                txtDepartment.Properties.DataSource = dt;
                txtDepartment.Properties.DisplayMember = "DepartmentName";
                txtDepartment.Properties.ValueMember = "DepartmentCode";
            }
        }

        private void call_info(string Form_name, string code)
        {
            Class.DanhSach_Nhom ds = new Class.DanhSach_Nhom();
            DataTable dt = ds.GetGroupByCode(code);
            txtGroupCode.Text = dt.Rows[0]["GroupCode"].ToString();
            txtGroupName.Text = dt.Rows[0]["GroupName"].ToString();
            txtBranchName.EditValue = dt.Rows[0]["BranchCode"].ToString();
            txtDepartment.EditValue = dt.Rows[0]["DepartmentCode"].ToString();
            txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
            txtFactQuantity.Text = dt.Rows[0]["FactQuantity"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();

        }
        private string call_Code_New()
        {
            txtGroupCode.Text = "";
            txtGroupName.Text = "";
            txtFactQuantity.Text = "0";
            txtQuantity.Text = "0";
            txtDescription.Text = "";
            this.Text = "Thêm Tổ, Nhóm";
            Class.DanhSach_Nhom dm = new Class.DanhSach_Nhom();
            return dm.GetNewCode();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtGroupCode.Text.Length < 1 || txtBranchName.EditValue == null || txtGroupName.Text.Length < 1 || txtDepartment.EditValue == null)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhSach_Nhom ds = new Class.DanhSach_Nhom();
            ds.GroupCode = txtGroupCode.Text;
            ds.GroupName = txtGroupName.Text;
            ds.DepartmentCode = txtDepartment.EditValue.ToString();           
            ds.Quantity = int.Parse(txtQuantity.Text);
            ds.FactQuantity = int.Parse(txtFactQuantity.Text);
            ds.Description = txtDescription.Text;

            if (txtGroupCode.Enabled == true)
            {
                if (ds.Insert())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            else
            {
                if (ds.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }

            if (_reCallFunction == "frmDanhSachNhom")
            {
                (this.Owner as frmDanhSachNhom).GetAllList_GROUP();
            }
            if (_reCallFunction == "frmDanhSachNhanVien")
            {
                (this.Owner as frmDanhSachNhanVien).loaddsCocautochuc();
            }
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtGroupCode.Text.Length < 1 || txtBranchName.EditValue == null || txtGroupName.Text.Length < 1 || txtDepartment.EditValue == null)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhSach_Nhom ds = new Class.DanhSach_Nhom();
            ds.GroupCode = txtGroupCode.Text;
            ds.GroupName = txtGroupName.Text;
            ds.DepartmentCode = txtDepartment.EditValue.ToString();
            ds.Quantity = int.Parse(txtQuantity.Text);
            ds.FactQuantity = int.Parse(txtFactQuantity.Text);
            ds.Description = txtDescription.Text;

            if (txtGroupCode.Enabled == true)
            {
                if (ds.Insert())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            else
            {
                if (ds.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }

            if (_reCallFunction == "frmDanhSachNhom")
            {
                (this.Owner as frmDanhSachNhom).GetAllList_GROUP();
            }
            if (_reCallFunction == "frmDanhSachNhanVien")
            {
                (this.Owner as frmDanhSachNhanVien).loaddsCocautochuc();
            }
            txtGroupCode.Enabled = true;
            txtGroupCode.Text = call_Code_New();
        }

        private void txtBranchName_EditValueChanged(object sender, EventArgs e)
        {
            GetListDEPARTMENTByBranch(txtBranchName.EditValue.ToString());
        }

       
    }
}