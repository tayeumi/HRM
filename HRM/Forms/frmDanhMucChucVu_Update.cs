using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhMucChucVu_Update : DevExpress.XtraEditors.XtraForm
    {       
        public frmDanhMucChucVu_Update()
        {
            InitializeComponent();
        }

        public frmDanhMucChucVu_Update(bool Add_new, string Caption_name, string Form_name, string Code)
        {
            InitializeComponent();
            this.Text = Caption_name;
            if (Add_new)
            {
                txtCode.Text = call_Code_New();             
            }
            else
            {
                call_info(Form_name, Code);
                txtCode.Enabled = false;
            }
        }
        private void call_info(string Form_name, string code)
        {
            Class.DanhMuc_ChucVu dmcv = new Class.DanhMuc_ChucVu();
            DataTable dt = dmcv.GetPositionByCode(code);
            txtCode.Text = dt.Rows[0]["PositionCode"].ToString();
            txtName.Text = dt.Rows[0]["PositionName"].ToString();
            checkIsManager.Checked =(bool)dt.Rows[0]["IsManager"];
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            checkActive.Checked = (bool)dt.Rows[0]["Active"];
        }
        private string call_Code_New()
        {           
               Class.DanhMuc_ChucVu dmcv = new Class.DanhMuc_ChucVu();
               return dmcv.GetNewCode();           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Length<1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhMuc_ChucVu dmcv = new Class.DanhMuc_ChucVu();
            dmcv.PositionCode = txtCode.Text;
            dmcv.PositionName = txtName.Text;
            dmcv.IsManager = checkIsManager.Checked;
            dmcv.Description = txtDescription.Text;
            dmcv.Active = checkActive.Checked;
            if (txtCode.Enabled == true)
            {
                if (dmcv.Insert())
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
                if (dmcv.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            (this.Owner as frmDanhMucChucVu).GetAllList_POSITION();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhMuc_ChucVu dmcv = new Class.DanhMuc_ChucVu();
            dmcv.PositionCode = txtCode.Text;
            dmcv.PositionName = txtName.Text;
            dmcv.IsManager = checkIsManager.Checked;
            dmcv.Description = txtDescription.Text;
            dmcv.Active = checkActive.Checked;
            if (txtCode.Enabled == true)
            {
                if (dmcv.Insert())
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
                if (dmcv.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            // xac dinh du lieu co thay doi de reload form danh muc.
            (this.Owner as frmDanhMucChucVu).GetAllList_POSITION();
            txtCode.Enabled = true;
            txtName.Text = "";
            txtDescription.Text = "";
            this.Text = "Thêm chức vụ";
            txtCode.Text = call_Code_New();
        }
    }
}