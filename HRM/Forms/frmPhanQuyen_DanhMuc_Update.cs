using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmPhanQuyen_DanhMuc_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyen_DanhMuc_Update()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public frmPhanQuyen_DanhMuc_Update(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name;          
            if (Add_new)
            {
                txtID.Text = call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);
                txtID.Enabled = false;
            }
            _reCallFunction = reCallFunction;
        }
        private void call_info(string Form_name, string code)
        {
            Class.DanhMuc_Quyen dm = new Class.DanhMuc_Quyen();
            DataTable dt = dm.GetObjectByCode(code);
            txtID.Text = dt.Rows[0]["ID"].ToString();
            txtObject_ID.Text = dt.Rows[0]["Object_ID"].ToString();
            txtObject_Name.Text = dt.Rows[0]["Object_Name"].ToString();           
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            checkActive.Checked = (bool)dt.Rows[0]["Active"];

        }
        private string call_Code_New()
        {
            //txtObject_ID.Text = "";
            txtObject_Name.Text = "";         
            this.Text = "Thêm Danh mục quyền";
            return Guid.NewGuid().ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length < 1 || txtObject_Name.Text.Length<1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhMuc_Quyen dm = new Class.DanhMuc_Quyen();
            dm.ID = txtID.Text;
            dm.Object_ID = txtObject_ID.Text;
            dm.Object_Name = txtObject_Name.Text;        
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
            if (txtID.Enabled == true)
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

            if (_reCallFunction == "frmPhanQuyen_DanhMuc")
            {
                (this.Owner as frmPhanQuyen_DanhMuc).GetAllList_OBJECT();
            }
           
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length < 1 || txtObject_Name.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.DanhMuc_Quyen dm = new Class.DanhMuc_Quyen();
            dm.ID = txtID.Text;
            dm.Object_ID = txtObject_ID.Text;
            dm.Object_Name = txtObject_Name.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
            if (txtID.Enabled == true)
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

            if (_reCallFunction == "frmPhanQuyen_DanhMuc")
            {
                (this.Owner as frmPhanQuyen_DanhMuc).GetAllList_OBJECT();
            }
           
            txtID.Enabled = true;
            txtID.Text = call_Code_New();
        }
    }
}