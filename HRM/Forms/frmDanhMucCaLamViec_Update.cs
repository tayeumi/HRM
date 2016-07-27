using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhMucCaLamViec_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucCaLamViec_Update()
        {
            InitializeComponent();
        }
        public frmDanhMucCaLamViec_Update(bool Add_new, string Caption_name, string Form_name, string Code)
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
            Class.DanhMuc_CaLamViec dm = new Class.DanhMuc_CaLamViec();
            DataTable dt = dm.GetShiftByCode(code);
            txtCode.Text = dt.Rows[0]["ShiftCode"].ToString();
            txtName.Text = dt.Rows[0]["ShiftName"].ToString();
            timeBeginTime.Time = (DateTime)dt.Rows[0]["BeginTime"];
            timeEndTime.Time = (DateTime)dt.Rows[0]["EndTime"];
            txtDescription.Text = dt.Rows[0]["Description"].ToString();          
        }
        private string call_Code_New()
        {
            Class.DanhMuc_CaLamViec dm = new Class.DanhMuc_CaLamViec();
            return dm.GetNewCode();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("" + timeBeginTime.Time);
            this.Close();
        }
        private void Update_Shift()
        {
            Class.DanhMuc_CaLamViec dm = new Class.DanhMuc_CaLamViec();
            dm.ShiftCode = txtCode.Text;
            dm.ShiftName = txtName.Text;
            dm.BeginTime = timeBeginTime.Time;
            dm.EndTime = timeEndTime.Time;
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
            (this.Owner as frmDanhMucCaLamViec).DIC_SHIFT_GetList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_Shift();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_Shift();
            txtCode.Enabled = true;
            txtName.Text = "";
            txtDescription.Text = "";
            this.Text = "Thêm Ca làm việc";
            txtCode.Text = call_Code_New();
        }

    }
}