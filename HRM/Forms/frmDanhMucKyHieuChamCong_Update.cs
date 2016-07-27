using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhMucKyHieuChamCong_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucKyHieuChamCong_Update()
        {
            InitializeComponent();
        }
        public frmDanhMucKyHieuChamCong_Update(bool Add_new, string Caption_name, string Form_name, string Code)
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
            Class.DanhMuc_KyHieuChamCong dm = new Class.DanhMuc_KyHieuChamCong();
            DataTable dt = dm.GetSymbolByCode(code);
            txtCode.Text = dt.Rows[0]["SymbolCode"].ToString();
            txtName.Text = dt.Rows[0]["SymbolName"].ToString();            
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
        }
        private string call_Code_New()
        {
            Class.DanhMuc_KyHieuChamCong dm = new Class.DanhMuc_KyHieuChamCong();
            return dm.GetNewCode();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {           
            this.Close();
        }
        private void Update_Symbol()
        {
            Class.DanhMuc_KyHieuChamCong dm = new Class.DanhMuc_KyHieuChamCong();
            dm.SymbolCode = txtCode.Text;
            dm.SymbolName = txtName.Text;
            dm.PercentSalary = 0;
            dm.IsEdit = false;
            dm.Description = txtDescription.Text;
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
            (this.Owner as frmDanhMucKyHieuChamCong).DIC_SYMBOL_GetList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_Symbol();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_Symbol();
            txtCode.Enabled = true;
            txtName.Text = "";
            txtDescription.Text = "";
            this.Text = "Thêm ký hiệu chấm công";
            txtCode.Text = call_Code_New();
        }
    }
}