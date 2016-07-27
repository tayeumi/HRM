using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhMucThietBiChamCong_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucThietBiChamCong_Update()
        {
            InitializeComponent();
        }

        public frmDanhMucThietBiChamCong_Update(bool Add_new, string Caption_name, string Form_name, string Code)
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
            Class.DanhMuc_ThietBiChamCong dm = new Class.DanhMuc_ThietBiChamCong();
            DataTable dt = dm.GetMachineByCode(code);
            txtCode.Text = dt.Rows[0]["MachineCode"].ToString();
            txtName.Text = dt.Rows[0]["MachineName"].ToString();
            txtPortType.Text = dt.Rows[0]["PortType"].ToString();
            txtPortID.Text = dt.Rows[0]["PortID"].ToString();
            txtIP.Text = dt.Rows[0]["IP"].ToString();
            txtPassword.Text = dt.Rows[0]["Password"].ToString();
            txtCom.Text = dt.Rows[0]["Com"].ToString();            
        }
        private string call_Code_New()
        {
            Class.DanhMuc_ThietBiChamCong dm = new Class.DanhMuc_ThietBiChamCong();
            return dm.GetNewCode();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Update_Machine()
        {
            Class.DanhMuc_ThietBiChamCong dm = new Class.DanhMuc_ThietBiChamCong();
            dm.MachineCode = txtCode.Text;
            dm.MachineName = txtName.Text;
            dm.PortType = txtPortType.Text;
            dm.PortID = txtPortID.Text;
            dm.IP = txtIP.Text;
            dm.Password = txtPassword.Text;
            dm.Com = txtCom.Text;

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
            (this.Owner as frmDanhMucThietBiChamCong).DIC_MACHINE_GetList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_Machine();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_Machine();
            txtCode.Enabled = true;
            txtName.Text = "";           
            this.Text = "Thêm Máy chấm công";
            txtCode.Text = call_Code_New();
        }
    }
}