using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmNguoiDung_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmNguoiDung_Update()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public frmNguoiDung_Update(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name;
            if (Add_new)
            {
                txtUserName.Text = call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);
                txtUserName.Enabled = false;
            }
            _reCallFunction = reCallFunction;
        }

        private void call_info(string Form_name, string code)
        {
            Class.S_TaiKhoan dm = new Class.S_TaiKhoan();
            DataTable dt = dm.GetUserByCode(code);
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            checkActive.Checked = (bool)dt.Rows[0]["Active"];

        }
        private string call_Code_New()
        {                      
            this.Text = "Thêm Người dùng";
            return "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length < 1 || txtPassword.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtPassword.Text!=txtRePassword.Text)
            {
                Class.App.InputNotAccess();
                return;
            }

            Class.S_TaiKhoan dm = new Class.S_TaiKhoan();
            dm.UserName = txtUserName.Text;
            dm.Password =Class.S_TaiKhoan.md5(txtPassword.Text);
            dm.Email = txtEmail.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
            if (txtUserName.Enabled == true)
            {
                if (dm.Insert())
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
                if (dm.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }

            if (_reCallFunction == "frmNguoiDung")
            {
                (this.Owner as frmNguoiDung).GetAllList_USER();
            }

            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length < 1 || txtPassword.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtPassword.Text != txtRePassword.Text)
            {
                Class.App.InputNotAccess();
                return;
            }

            Class.S_TaiKhoan dm = new Class.S_TaiKhoan();
            dm.UserName = txtUserName.Text;
            dm.Password = txtPassword.Text;
            dm.Email = txtEmail.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
            if (txtUserName.Enabled == true)
            {
                if (dm.Insert())
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
                if (dm.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }

            if (_reCallFunction == "frmNguoiDung")
            {
                (this.Owner as frmNguoiDung).GetAllList_USER();
            }


            txtUserName.Enabled = true;
            txtUserName.Text = call_Code_New();
        }
    }
}