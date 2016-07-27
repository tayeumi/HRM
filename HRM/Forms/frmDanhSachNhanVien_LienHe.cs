using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhSachNhanVien_LienHe : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhanVien_LienHe()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public frmDanhSachNhanVien_LienHe(bool Add_new, string Caption_name, string Form_name, string Code1,string Code2,string fullname, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name;
            Call_info_toCBO();
            if (Add_new)
            {
               txtPersonID.Text = call_Code_New();
               txtEmployeeCode.Text = Code2;
               txtFullname.Text = fullname;
               txtEmployeeCode.Properties.ReadOnly = true;
               txtFullname.Properties.ReadOnly = true;
            }
            else
            {
               call_info(Form_name, Code1,fullname);
                txtPersonID.Enabled = false;
                txtEmployeeCode.Properties.ReadOnly = true;
                txtFullname.Properties.ReadOnly = true;
            }
            _reCallFunction = reCallFunction;

        }
        private void call_info(string Form_name, string code,string fullname)
        {
            Class.NhanVien_LienHe nv = new Class.NhanVien_LienHe();
           DataTable dt = nv.GetPersonByCode(code);
           txtPersonID.Text = dt.Rows[0]["PersonID"].ToString();
           txtEmployeeCode.Text = dt.Rows[0]["EmployeeCode"].ToString();
           txtFullname.Text = fullname;
           txtPersonName.Text = dt.Rows[0]["PersonName"].ToString();
           txtRelative.Text = dt.Rows[0]["Relative"].ToString();
           txtAddress.Text = dt.Rows[0]["Address"].ToString();
           txtEmail.Text = dt.Rows[0]["Email"].ToString();
           txtPhone.Text = dt.Rows[0]["Phone"].ToString();
           checkIsDepend.Checked = (bool)dt.Rows[0]["IsDepend"];

        }
        private string call_Code_New()
        {      
   
            this.Text = "Thêm liên hệ";
            txtPersonName.Text = "";
           // txtRelative.EditValue = "";
            //txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";

            return Guid.NewGuid().ToString();           
        }
        private void frmDanhSachNhanVien_LienHe_Load(object sender, EventArgs e)
        {

        }
        private void Call_info_toCBO()
        {
            Class.DanhMuc_QuanHeGiaDinh qh = new Class.DanhMuc_QuanHeGiaDinh();
            DataTable dt = qh.GetAllList_RELATIVE();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtRelative.Properties.Items.Add(dt.Rows[i]["RelativeName"].ToString());
            }
        }

        private void Update_LienHe()
        {
            Class.NhanVien_LienHe lh = new Class.NhanVien_LienHe();
            lh.PersonID = txtPersonID.Text;
            lh.EmployeeCode = txtEmployeeCode.Text;
            lh.PersonName = txtPersonName.Text;
            lh.Relative = txtRelative.Text;
            lh.Address = txtAddress.Text;
            lh.Email = txtEmail.Text;
            lh.Phone = txtPhone.Text;
            lh.IsDepend = checkIsDepend.Checked;
            if (txtPersonID.Enabled == true)
            {
                if (lh.Insert())
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
                if (lh.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            (this.Owner as frmCapNhatNhanVien).GetList_RelativeByEmployee(txtEmployeeCode.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPersonID.Text.Length < 1||txtPersonName.Text.Length<1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_LienHe();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtPersonID.Text.Length < 1 || txtPersonName.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_LienHe();
            txtPersonID.Text = call_Code_New();
        }
    }
}