using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhMucBenhVien_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucBenhVien_Update()
        {
            InitializeComponent();
        }
        public frmDanhMucBenhVien_Update(bool Add_new, string Caption_name, string Form_name, string Code)
        {
            InitializeComponent();
            GetList_Province();
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
        private void GetList_Province()
        {
            Class.DanhMuc_Tinh dm = new Class.DanhMuc_Tinh();
            txtProvince.Properties.DataSource = dm.GetAllList_PROVINCE();
            txtProvince.Properties.DisplayMember = "ProvinceName";
            txtProvince.Properties.ValueMember = "ProvinceCode";
        }
        private void frmDanhMucBenhVien_Update_Load(object sender, EventArgs e)
        {

        }
        private void call_info(string Form_name, string code)
        {
            Class.DanhMuc_BenhVien dm = new Class.DanhMuc_BenhVien();
            DataTable dt = dm.GetHospitalByCode(code);
            txtCode.Text = dt.Rows[0]["HospitalCode"].ToString();
            txtName.Text = dt.Rows[0]["HospitalName"].ToString();
            txtProvince.EditValue = dt.Rows[0]["ProvinceCode"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            checkActive.Checked = (bool)dt.Rows[0]["Active"];
        }
        private string call_Code_New()
        {
            Class.DanhMuc_BenhVien dm = new Class.DanhMuc_BenhVien();
            return dm.GetNewCode();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtProvince.EditValue.ToString()=="")
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhMuc_BenhVien dm = new Class.DanhMuc_BenhVien();
            dm.HospitalCode = txtCode.Text;
            dm.HospitalName = txtName.Text;
            dm.ProvinceCode = txtProvince.EditValue.ToString();
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
            if (txtCode.Enabled == true)
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
            (this.Owner as frmDanhMucBenhVien).GetAllList_HOSPITAL();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtProvince.EditValue.ToString() == "")
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhMuc_BenhVien dm = new Class.DanhMuc_BenhVien();
            dm.HospitalCode = txtCode.Text;
            dm.HospitalName = txtName.Text;
            dm.ProvinceCode = txtProvince.EditValue.ToString();
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
            if (txtCode.Enabled == true)
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
            (this.Owner as frmDanhMucBenhVien).GetAllList_HOSPITAL();
            txtCode.Enabled = true;
            txtName.Text = "";
            txtDescription.Text = "";
            this.Text = "Thêm Bệnh viện";
            txtCode.Text = call_Code_New();
        }
    }
}