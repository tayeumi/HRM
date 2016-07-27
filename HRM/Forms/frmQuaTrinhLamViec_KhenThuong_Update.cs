using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmQuaTrinhLamViec_KhenThuong_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmQuaTrinhLamViec_KhenThuong_Update()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public frmQuaTrinhLamViec_KhenThuong_Update(bool Add_new, string Caption_name, string Form_name, string Code, string Name, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name + " - "+Name;
            
            if (Add_new)
            {
                txtRewardID.Text = call_Code_New();
            }
            else
            {
               call_info(Form_name, Code);
               txtRewardID.Enabled = false;
            }
            _reCallFunction = reCallFunction;
        }
        private void call_info(string Form_name, string code)
        {          
            Class.QuaTrinhLamViec_KhenThuong kt = new Class.QuaTrinhLamViec_KhenThuong();
            kt.RewardID = code;
            DataTable dt = kt.HRM_PROCESS_REWARD_Get();
            txtFoundation.Text = dt.Rows[0]["Foundation"].ToString();
            txtReason.Text = dt.Rows[0]["Reason"].ToString();
            txtForm.Text = dt.Rows[0]["Form"].ToString();
            txtDecideNumber.Text = dt.Rows[0]["DecideNumber"].ToString();
            dateDate.DateTime = (DateTime)dt.Rows[0]["Date"];
            txtPerson.Text = dt.Rows[0]["Person"].ToString();
            txtRewardID.Text = code;
        }
        private string call_Code_New()
        {         
            txtFoundation.Text = "";
            txtReason.Text = "";
            txtForm.Text = "";
            txtDecideNumber.Text = "";
            dateDate.DateTime = DateTime.Now;
            this.Text = "Thêm Thông tin khen thưởng - " + Class.App._hotennv;
            return Guid.NewGuid().ToString();
        }

        private void Update_KhenThuong()
        {
            Class.QuaTrinhLamViec_KhenThuong kt = new Class.QuaTrinhLamViec_KhenThuong();
            kt.RewardID = txtRewardID.Text;
            kt.Foundation = txtFoundation.Text;
            kt.Reason = txtReason.Text;
            kt.Form = txtForm.Text;
            kt.DecideNumber = txtDecideNumber.Text;
            kt.Date = dateDate.DateTime;
            kt.Person = txtPerson.Text;
            kt.EmployeeCode = Class.App._manv;
            if (txtRewardID.Enabled == true)
            {

                if (kt.Insert())
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
                if (kt.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            (this.Owner as frmQuaTrinhLamViec_KhenThuong).HRM_PROCESS_REWARD_GetListByEmployee();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFoundation.Text.Length < 1 || txtReason.Text.Length < 1 || txtForm.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_KhenThuong();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtFoundation.Text.Length < 1 || txtReason.Text.Length < 1 || txtForm.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_KhenThuong();
            txtRewardID.Enabled = true;
            txtRewardID.Text = call_Code_New();
        }
    }
}