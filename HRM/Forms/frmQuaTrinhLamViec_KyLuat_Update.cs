using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmQuaTrinhLamViec_KyLuat_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmQuaTrinhLamViec_KyLuat_Update()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public frmQuaTrinhLamViec_KyLuat_Update(bool Add_new, string Caption_name, string Form_name, string Code, string Name, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name + " - " + Name;

            if (Add_new)
            {
               txtDisciplineID.Text = call_Code_New();
            }
            else
            {
               call_info(Form_name, Code);
                txtDisciplineID.Enabled = false;
            }
            _reCallFunction = reCallFunction;
        }
        private void call_info(string Form_name, string code)
        {
            Class.QuaTrinhLamViec_KyLuat kl = new Class.QuaTrinhLamViec_KyLuat();
            kl.DisciplineID = code;
            DataTable dt = kl.HRM_PROCESS_DISCIPLINE_Get();
            txtDisciplineID.Text = code;
            txtDisciplineName.Text = dt.Rows[0]["DisciplineName"].ToString();
            dateDateOccurred.DateTime = (DateTime)dt.Rows[0]["DateOccurred"];
            txtLocation.Text = dt.Rows[0]["Location"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            txtWitnesses.Text = dt.Rows[0]["Witnesses"].ToString();
            if ((bool)dt.Rows[0]["Violations"] == true)
                radioViolations.SelectedIndex=0;
            else
                radioViolations.SelectedIndex = 1;         
            txtNotes.Text = dt.Rows[0]["Notes"].ToString();

            txtForm.Text = dt.Rows[0]["Form"].ToString();
            if ((bool)dt.Rows[0]["Settlement"] == true)
                radioSettlement.SelectedIndex = 0;
            else
                radioSettlement.SelectedIndex = 1;
          

            txtReason.Text = dt.Rows[0]["Reason"].ToString();
            txtDecideNumber.Text = dt.Rows[0]["DecideNumber"].ToString();
            txtPerson.Text = dt.Rows[0]["Person"].ToString();
            dateDate.DateTime = (DateTime)dt.Rows[0]["Date"];
        }
        private string call_Code_New()
        {
            dateDate.DateTime = DateTime.Now;
            dateDateOccurred.DateTime = DateTime.Now;
            this.Text = "Thêm Thông tin kỷ luật - " + Class.App._hotennv;
            return Guid.NewGuid().ToString();
        }


        private void Update_KyLuat()
        {
            Class.QuaTrinhLamViec_KyLuat kl = new Class.QuaTrinhLamViec_KyLuat();
            kl.DisciplineID = txtDisciplineID.Text;
            kl.EmployeeCode = Class.App._manv;
            kl.DisciplineName = txtDisciplineName.Text;
            kl.DateOccurred = dateDateOccurred.DateTime;
            kl.Location = txtLocation.Text;
            kl.Description = txtDescription.Text;
            kl.Witnesses = txtWitnesses.Text;
          
            if(radioViolations.SelectedIndex==0)
                kl.Violations = true;
            else
                kl.Violations = false;

            kl.Notes = txtNotes.Text;
            kl.Form = txtForm.Text;
            if (radioSettlement.SelectedIndex == 0)
                kl.Settlement = true;
            else
                kl.Settlement = false;

            kl.Reason = txtReason.Text;
            kl.DecideNumber = txtDecideNumber.Text;
            kl.Person = txtPerson.Text;
            kl.Date = dateDate.DateTime;
            if (txtDisciplineID.Enabled == true)
            {

                if (kl.Insert())
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
                if (kl.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            (this.Owner as frmQuaTrinhLamViec_KyLuat).HRM_PROCESS_DISCIPLINE_GetListByEmployee();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDisciplineName.Text.Length < 1 || txtForm.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_KyLuat();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtDisciplineName.Text.Length < 1 || txtForm.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Update_KyLuat();
            txtDisciplineID.Enabled = true;
            txtDisciplineID.Text = call_Code_New();
        }
    }
}