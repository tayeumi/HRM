using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhSachPhongBan_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachPhongBan_Update()
        {
            InitializeComponent();
        }
       public string _reCallFunction;
        public frmDanhSachPhongBan_Update(bool Add_new, string Caption_name, string Form_name, string Code,string reCallFunction)
        {
            InitializeComponent();           
            this.Text = Caption_name;
            GetAllList_BRANCH(); // call danh sach chi nhanh
            if (Add_new)
            {
                txtDepartmentCode.Text = call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);
                txtDepartmentCode.Enabled = false;
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

        private void txtBranchName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           /*
            if (e.Button.Caption == "Add")
            {
                MessageBox.Show(txtBranchName.EditValue.ToString());
            }
            */
        }

        private void call_info(string Form_name, string code)        
        {           
            Class.PhongBan dm = new Class.PhongBan();
            DataTable dt = dm.GetDepartmentByCode(code);
            txtDepartmentCode.Text = dt.Rows[0]["DepartmentCode"].ToString();
            txtDepartmentName.Text = dt.Rows[0]["DepartmentName"].ToString();
            txtBranchName.EditValue = dt.Rows[0]["BranchCode"].ToString();
            txtPhone.Text = dt.Rows[0]["Phone"].ToString();
            txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
            txtFactQuantity.Text = dt.Rows[0]["FactQuantity"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            
        }
        private string call_Code_New()
        {
            txtDepartmentName.Text = "";
            txtPhone.Text = "";
            txtFactQuantity.Text = "0";
            txtQuantity.Text = "0";
            txtDescription.Text = "";
            this.Text = "Thêm Phòng ban";
            Class.PhongBan dm = new Class.PhongBan();
            return dm.GetNewCode();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text.Length < 1|| txtBranchName.EditValue==null)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.PhongBan dm = new Class.PhongBan();
            dm.DepartmentCode = txtDepartmentCode.Text;
            dm.DepartmentName = txtDepartmentName.Text;
            dm.BranchCode = txtBranchName.EditValue.ToString();
            dm.Phone = txtPhone.Text;
            dm.Quantity =int.Parse( txtQuantity.Text);
            dm.FactQuantity =int.Parse( txtFactQuantity.Text);
            dm.Description = txtDescription.Text;
           
            if (txtDepartmentCode.Enabled == true)
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
           
            if(_reCallFunction=="frmDanhSachPhongBan")
            {
                (this.Owner as frmDanhSachPhongBan).GetAllList_DEPARTMENT();
            }
            if (_reCallFunction == "frmDanhSachNhanVien")
            {
                (this.Owner as frmDanhSachNhanVien).loaddsCocautochuc();
            }
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text.Length < 1 || txtBranchName.EditValue == null)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.PhongBan dm = new Class.PhongBan();
            dm.DepartmentCode = txtDepartmentCode.Text;
            dm.DepartmentName = txtDepartmentName.Text;
            dm.BranchCode = txtBranchName.EditValue.ToString();
            dm.Phone = txtPhone.Text;
            dm.Quantity = int.Parse(txtQuantity.Text);
            dm.FactQuantity = int.Parse(txtFactQuantity.Text);
            dm.Description = txtDescription.Text;
            if (txtDepartmentCode.Enabled == true)
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
            // xac dinh du lieu co thay doi de reload form danh muc.
            if (_reCallFunction == "frmDanhSachPhongBan")
            {
                (this.Owner as frmDanhSachPhongBan).GetAllList_DEPARTMENT();
            }
            if (_reCallFunction == "frmDanhSachNhanVien")
            {
                (this.Owner as frmDanhSachNhanVien).loaddsCocautochuc();
            }
            txtDepartmentCode.Enabled = true;            
            txtDepartmentCode.Text = call_Code_New();
        }
    }
}