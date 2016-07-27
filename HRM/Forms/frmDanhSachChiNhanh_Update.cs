using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhSachChiNhanh_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachChiNhanh_Update()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public frmDanhSachChiNhanh_Update(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name;          
            if (Add_new)
            {
                txtBranchCode.Text = call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);
                txtBranchCode.Enabled = false;
            }
            _reCallFunction = reCallFunction;

        }

        private void frmDanhSachChiNhanh_Update_Load(object sender, EventArgs e)
        {

        }
        private void call_info(string Form_name, string code)
        {
            Class.DanhSach_ChiNhanh dm = new Class.DanhSach_ChiNhanh();
            DataTable dt = dm.GetBranchByCode(code);
            txtBranchCode.Text = dt.Rows[0]["BranchCode"].ToString();
            txtBranchName.Text = dt.Rows[0]["BranchName"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();            
            txtPhone.Text = dt.Rows[0]["Phone"].ToString();
            txtFax.Text = dt.Rows[0]["Fax"].ToString();
            txtMinimumSalary.Value =(decimal)dt.Rows[0]["MinimumSalary"];
            txtPersonName.Text = dt.Rows[0]["PersonName"].ToString();
            txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
            txtFactQuantity.Text = dt.Rows[0]["FactQuantity"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();

        }
        private string call_Code_New()
        {
            txtBranchCode.Text = "";
            txtBranchName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtMinimumSalary.Value = 0;
            txtPersonName.Text = "";
            txtFactQuantity.Text = "0";
            txtQuantity.Text = "0";
            txtDescription.Text = "";
            this.Text = "Thêm Chi nhánh";
            Class.DanhSach_ChiNhanh dm = new Class.DanhSach_ChiNhanh();
            return dm.GetNewCode();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtBranchCode.Text.Length < 1 || txtBranchName.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhSach_ChiNhanh dm = new Class.DanhSach_ChiNhanh();
            dm.BranchCode = txtBranchCode.Text;
            dm.BranchName = txtBranchName.Text;
            dm.Address = txtAddress.Text;
            dm.Phone = txtPhone.Text;
            dm.Fax = txtFax.Text;
            dm.MinimumSalary = txtMinimumSalary.Value;
            dm.PersonName = txtPersonName.Text;
            dm.Quantity = int.Parse(txtQuantity.Text);
            dm.FactQuantity = int.Parse(txtFactQuantity.Text);
            dm.Description = txtDescription.Text;

            if (txtBranchCode.Enabled == true)
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

            if (_reCallFunction == "frmDanhSachChiNhanh")
            {
                (this.Owner as frmDanhSachChiNhanh).GetAllList_BRANCH();
            }
            if (_reCallFunction == "frmDanhSachNhanVien")
            {
                (this.Owner as frmDanhSachNhanVien).loaddsCocautochuc();
            }
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtBranchCode.Text.Length < 1 || txtBranchName.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhSach_ChiNhanh dm = new Class.DanhSach_ChiNhanh();
            dm.BranchCode = txtBranchCode.Text;
            dm.BranchName = txtBranchName.Text;
            dm.Address = txtAddress.Text;
            dm.Phone = txtPhone.Text;
            dm.Fax = txtFax.Text;
            dm.MinimumSalary = txtMinimumSalary.Value;
            dm.PersonName = txtPersonName.Text;
            dm.Quantity = int.Parse(txtQuantity.Text);
            dm.FactQuantity = int.Parse(txtFactQuantity.Text);
            dm.Description = txtDescription.Text;

            if (txtBranchCode.Enabled == true)
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

            if (_reCallFunction == "frmDanhSachChiNhanh")
            {
                (this.Owner as frmDanhSachChiNhanh).GetAllList_BRANCH();
            }
            if (_reCallFunction == "frmDanhSachNhanVien")
            {
                (this.Owner as frmDanhSachNhanVien).loaddsCocautochuc();
            }
            txtBranchCode.Enabled = true;
            txtBranchCode.Text = call_Code_New();
        }
    }
}