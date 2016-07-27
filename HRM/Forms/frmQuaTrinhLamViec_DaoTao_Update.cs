using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmQuaTrinhLamViec_DaoTao_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmQuaTrinhLamViec_DaoTao_Update()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public frmQuaTrinhLamViec_DaoTao_Update(bool Add_new, string Caption_name, string Form_name, string Code, string Name, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name + " - " + Name;

            if (Add_new)
            {
                txtTrainingID.Text = call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);
                txtTrainingID.Enabled = false;
            }
            _reCallFunction = reCallFunction;
        }
        private void call_info(string Form_name, string code)
        {
            Class.QuaTrinhLamViec_DaoTao dtao = new Class.QuaTrinhLamViec_DaoTao();
            dtao.TrainingID = code;
            DataTable dt = dtao.HRM_PROCESS_TRAINING_Get();
            txtTrainingID.Text = code;
            txtTrainingName.Text = dt.Rows[0]["TrainingName"].ToString();
            txtReason.Text = dt.Rows[0]["Reason"].ToString();
            txtForm.Text = dt.Rows[0]["Form"].ToString();
            txtTime.Text = dt.Rows[0]["Time"].ToString();
            dateBeginDate.DateTime = (DateTime)dt.Rows[0]["BeginDate"];
            dateDate.DateTime = (DateTime)dt.Rows[0]["Date"];
            txtDecideNumber.Text = dt.Rows[0]["DecideNumber"].ToString();
            txtPerson.Text = dt.Rows[0]["Person"].ToString();   
        }
        private string call_Code_New()
        {           
            this.Text = "Thêm Thông tin đào tạo - " + Class.App._hotennv;
            txtTrainingName.Text = "";
            txtReason.Text = "";
            txtForm.Text = "";
            dateBeginDate.DateTime = DateTime.Now;
            dateDate.DateTime=  DateTime.Now;
            return Guid.NewGuid().ToString();
        }

        private void Update_DaoTao()
        {
            Class.QuaTrinhLamViec_DaoTao dtao = new Class.QuaTrinhLamViec_DaoTao();
            dtao.TrainingID = txtTrainingID.Text;
            dtao.EmployeeCode = Class.App._manv;
            dtao.TrainingName = txtTrainingName.Text;
            dtao.Reason = txtReason.Text;
            dtao.Form = txtForm.Text;
            dtao.Time = txtTime.Text;
            dtao.BeginDate = dateBeginDate.DateTime;
            dtao.DecideNumber = txtDecideNumber.Text;
            dtao.Date = dateDate.DateTime;
            dtao.Person = txtPerson.Text;

            if (txtTrainingID.Enabled == true)
            {

                if (dtao.Insert())
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
                if (dtao.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            (this.Owner as frmQuaTrinhLamViec_DaoTao).HRM_PROCESS_TRAINING_GetListByEmployee();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTrainingName.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_DaoTao();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtTrainingName.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_DaoTao();
            txtTrainingID.Enabled = true;
            txtTrainingID.Text = call_Code_New();
        }
    }
}