using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HRM.Forms
{
    public partial class frmDanhSachHopDong_Season_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachHopDong_Season_Update()
        {
            InitializeComponent();
        }
        public bool _Add_New;
        public frmDanhSachHopDong_Season_Update(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
        {
            InitializeComponent();
            Get_EmployeeCodeToCBO();
            Set_NgayThangMacDinh();
            this.Text = Caption_name;
            if (Add_new)
            {
                call_Code_New();                
            }
            else
            {
                call_info(Form_name, Code);
                txtEmployeeCode.Enabled = false;
                txtContractCode.Enabled = false;
                txtContractYear.Enabled = false;
                txtContractTime.Enabled = false;      
            }
            _Add_New = Add_new;
            Get_Company_Info();
        }
        private void Get_EmployeeCodeToCBO()
        {
            Class.NhanVien nv = new Class.NhanVien();
            nv.Status = -1;
            DataTable dt = nv.LoadDanhSachNhanVien_Ex();
            cboSinger.Properties.DataSource = dt;
            cboSinger.Properties.DisplayMember = "EmployeeCode";
            cboSinger.Properties.ValueMember = "EmployeeCode";
            Class.NhanVien_ThoiVu nvtv = new Class.NhanVien_ThoiVu();
            DataTable dttv = nvtv.HRM_EMPLOYEE_SEASON_GetList();
            txtEmployeeCode.Properties.DataSource = dttv;
            txtEmployeeCode.Properties.DisplayMember = "EmployeeCode";
            txtEmployeeCode.Properties.ValueMember = "EmployeeCode";
        }

        private void call_info(string Form_name, string code)
        {
            Class.NhanVien_HopDong_ThoiVu hd = new Class.NhanVien_HopDong_ThoiVu();
            hd.ContractCode = code;
            DataTable dt = hd.HRM_CONTRACT_SEASON_Get();
            txtSigner.Text = dt.Rows[0]["Signer"].ToString();
            txtSignerNationality.Text = dt.Rows[0]["SignerNationality"].ToString();
            txtSignerPosition.Text = dt.Rows[0]["SignerPosition"].ToString();
            txtCompany.Text = dt.Rows[0]["Company"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtTel.Text = dt.Rows[0]["Tel"].ToString();
            checkIsCurrent.Checked = (bool)dt.Rows[0]["IsCurrent"];
            txtEmployeeCode.EditValue = dt.Rows[0]["EmployeeCode"].ToString();
            Class.NhanVien_ThoiVu nv = new Class.NhanVien_ThoiVu();
            nv.EmployeeCode = dt.Rows[0]["EmployeeCode"].ToString();
            DataTable dtinfo = nv.HRM_EMPLOYEE_SEASON_Get();
            txtFullName.Text = dtinfo.Rows[0]["FirstName"].ToString() + " " + dtinfo.Rows[0]["LastName"].ToString();
            dateBirthday.DateTime = (DateTime)dtinfo.Rows[0]["Birthday"];
            txtPosition.Text = dtinfo.Rows[0]["Position"].ToString();
            txtNationality.Text = dtinfo.Rows[0]["Nationality"].ToString();
            txtIDCard.Text = dtinfo.Rows[0]["IDCard"].ToString();
            dateIDCardDate.DateTime = (DateTime)dtinfo.Rows[0]["IDCardDate"];
            txtIDCardPlace.Text = dtinfo.Rows[0]["IDCardPlace"].ToString();
            txtBranchName.Text = dtinfo.Rows[0]["BranchName"].ToString(); 

            //tab thong tin hop dong
            
            txtContractCode.Text = dt.Rows[0]["ContractCode"].ToString();
            txtContractTime.Text = dt.Rows[0]["ContractTime"].ToString();
            txtContractYear.Text = dt.Rows[0]["ContractYear"].ToString();
            dateSignDate.DateTime = (DateTime)dt.Rows[0]["SignDate"];
            dateFromDate.DateTime = (DateTime)dt.Rows[0]["FromDate"];
            if (dt.Rows[0]["ToDate"] != DBNull.Value)
            {
                dateToDate.DateTime = (DateTime)dt.Rows[0]["ToDate"];
            }
            txtBasicSalary.Value = (decimal)dt.Rows[0]["BasicSalary"];
            txtPayForm.Text = dt.Rows[0]["PayForm"].ToString();
            txtPayDate.Value = (int)dt.Rows[0]["PayDate"];
            txtAllowance.Text = dt.Rows[0]["Allowance"].ToString();
            txtInsurance.Text = dt.Rows[0]["Insurance"].ToString();
            txtWorkTime.Text = dt.Rows[0]["WorkTime"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
        }
       
        private void Set_NgayThangMacDinh()
        {
            dateSignDate.DateTime = DateTime.Now;
            dateFromDate.DateTime = DateTime.Now;
            dateToDate.DateTime = DateTime.Now;
            txtContractYear.Text = DateTime.Now.Year.ToString();
        }

        private void cboSinger_EditValueChanged(object sender, EventArgs e)
        {
            int SelectedRow = cboSingerDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = cboSingerDetail.GetDataRow(SelectedRow);
                string _FirstName = drow["FirstName"].ToString();
                string _LastName = drow["LastName"].ToString();
                //DateTime _Birthday = (DateTime)drow["Birthday"];
                string _Position = drow["Position"].ToString();
                string _Nationality = drow["Nationality"].ToString();

                txtSigner.Text = _FirstName + " " + _LastName;
                txtSignerPosition.Text = _Position;
                txtSignerNationality.Text = _Nationality;
            }
        }
        DateTime DateBegin = DateTime.Now;
        private void txtEmployeeCode_EditValueChanged(object sender, EventArgs e)
        {
            int SelectedRow = cboEmployeeCodeDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = cboEmployeeCodeDetail.GetDataRow(SelectedRow);
                string _FirstName = drow["FirstName"].ToString();
                string _LastName = drow["LastName"].ToString();
                DateTime _Birthday = (DateTime)drow["Birthday"];
                string _Position = drow["Position"].ToString();
                string _Nationality = drow["Nationality"].ToString();
                string _IDCard = drow["IDCard"].ToString();
                DateTime _IDCardDate = (DateTime)drow["IDCardDate"];
                string _IDCardPlace = drow["IDCardPlace"].ToString();
                string _BranchName = drow["BranchName"].ToString();

                if (drow["BeginDate"] != DBNull.Value)
                {
                    DateBegin = (DateTime)drow["BeginDate"];
                }

                txtFullName.Text = _FirstName + " " + _LastName;
                dateBirthday.DateTime = _Birthday;
                txtPosition.Text = _Position;
                txtNationality.Text = _Nationality;
                txtIDCard.Text = _IDCard;
                dateIDCardDate.DateTime = _IDCardDate;
                txtIDCardPlace.Text = _IDCardPlace;
                txtBranchName.Text = _BranchName;

                xulyTaoCodeHopdong(); // goi ham tinh tu dong code
            }
            
        }

        private string call_Code_New()
        {
            txtEmployeeCode.Enabled = true;
            txtContractCode.Enabled = true;
            txtContractYear.Enabled = true;
            txtContractTime.Enabled = true;
            txtBasicSalary.Text = "";
            txtAllowance.Text = "";
            txtDescription.Text = "";
            Set_NgayThangMacDinh();
            cboSinger.EditValue = "PTH0259"; // mac dinh cho Giam Doc Dieu Hanh 
            return "";
        }
        private void Get_Company_Info()
        {
            Class.CongTy ct = new Class.CongTy();
            DataTable dt = ct.LoadThongTinCty();
            txtAddress.Text = dt.Rows[0]["CompanyAddress"].ToString();
            txtTel.Text = dt.Rows[0]["Tel"].ToString(); ;
        }

        private void xulyTaoCodeHopdong()
        {
            if (_Add_New == true)
            {
                if (txtFullName.Text != "[Họ và tên nhân viên]")
                {
                    Class.NhanVien_HopDong_ThoiVu hd = new Class.NhanVien_HopDong_ThoiVu();
                    hd.ContractYear = int.Parse(txtContractYear.Text);
                    DataTable dt = hd.HRM_CONTRACT_SEASON_GetByYear();
                    hd.EmployeeCode = txtEmployeeCode.EditValue.ToString();
                    DataTable dthdbynv = hd.HRM_CONTRACT_SEASON_GetByEmployee();

                    if (dt.Rows.Count > 0)
                    {
                        string _idCheck;
                        string[] cat;
                        int next_ID = 0;
                        int next_ID2 = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            _idCheck = dt.Rows[i]["ContractCode"].ToString();
                            cat = _idCheck.Split('-');
                            next_ID2 = int.Parse(cat.GetValue(0).ToString());
                            if ((next_ID2 - next_ID) > 1)
                            {
                                break;
                            }
                            next_ID = int.Parse(cat.GetValue(0).ToString());
                        }
                        next_ID++;
                        if (next_ID.ToString().Length == 1)
                        {
                            txtContractCode.Text = "00" + next_ID.ToString() + "-" + txtContractYear.Text;
                        }
                        if (next_ID.ToString().Length == 2)
                        {
                            txtContractCode.Text = "0" + next_ID.ToString() + "-" + txtContractYear.Text;
                        }
                        if (next_ID.ToString().Length == 3)
                        {
                            txtContractCode.Text =  next_ID.ToString() + "-" + txtContractYear.Text;
                        }                        
                    }
                    else
                    {
                        txtContractCode.Text = "001-" + txtContractYear.Text;
                    }
                    // kiem tra ky hop dong truc tiep ko co thu viec
                    int solanHD = 1;
                    solanHD = dthdbynv.Rows.Count+1;

                    txtContractCode.Text = txtContractCode.Text + "/HDTVu-Lan"+solanHD;

                    if (dthdbynv.Rows.Count > 0)
                    {
                        if (dthdbynv.Rows[dthdbynv.Rows.Count - 1]["ToDate"] != DBNull.Value)
                        {
                            DateTime _dateNgaykt = (DateTime)dthdbynv.Rows[dthdbynv.Rows.Count - 1]["ToDate"];
                            DateTime _dateNgayKyTiep = _dateNgaykt.AddDays(1);
                            dateFromDate.DateTime = _dateNgayKyTiep;
                            dateSignDate.DateTime = _dateNgayKyTiep;
                            dateFromDate_Validated(null, null);
                        }
                    }
                    else
                    {
                        // la HDTV se lay ngay tu ngay bat dau lam viec
                        dateFromDate.DateTime = DateBegin;
                        dateSignDate.DateTime = DateBegin;
                        dateFromDate_Validated(null, null);
                    }


                }
                else
                {
                    MessageBox.Show("Vui Lòng chọn nhân viên ký hợp đồng trước");
                    TabControl.SelectedTabPage = TabPage1;
                }
            }
            //txtContractTime_SelectedIndexChanged(null, null);
            // tam thoi han che khong cho lam lap 4 hop dong lao dong
            //if (txtContractCode.Text.Contains("Lan4"))
            //{
            //    MessageBox.Show("Hợp đồng Lao động chỉ chấp nhận nhỏ hơn 4 lần, Vui lòng kiểm tra lại hoặc liên hệ Người Quản Trị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void txtContractYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            xulyTaoCodeHopdong();           
        }

        private void dateSignDate_Validated(object sender, EventArgs e)
        {
            dateFromDate.DateTime = dateSignDate.DateTime;
        }

        private void dateFromDate_Validated(object sender, EventArgs e)
        {
            txtContractTime_SelectedIndexChanged(null, null);
        }

        private void txtContractTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (txtContractTime.Text)
            {
                case "1 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(1).AddDays(-1);
                    break;
                case "2 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(2).AddDays(-1);
                    break;
                case "3 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(3).AddDays(-1);
                    break;
                case "4 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(4).AddDays(-1);
                    break;
                case "5 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(5).AddDays(-1);
                    break;
                case "6 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(6).AddDays(-1);
                    break;
                case "7 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(7).AddDays(-1);
                    break;
                case "8 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(8).AddDays(-1);
                    break;
                case "9 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(9).AddDays(-1);
                    break;
                case "10 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(10).AddDays(-1);
                    break;
                case "11 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(11).AddDays(-1);
                    break;
                case "12 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(12).AddDays(-1);
                    break;               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSigner.Text == "[Họ và tên người ký]" || txtFullName.Text == "[Họ và tên nhân viên]" || txtContractCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            // kiem tra ma HD hop le
            string ktMaHD = txtContractCode.Text;
            string[] catMa1 = ktMaHD.Split('-');
            if (catMa1.Length > 0)
            {
                int IntConvert;
                bool result = Int32.TryParse(catMa1.GetValue(0).ToString(), out IntConvert);
                if (!result)
                {
                    MessageBox.Show("Mã Hợp đồng Lao Động không đúng quy định.!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] catMa2 = catMa1.GetValue(1).ToString().Split('/');
                bool result2 = Int32.TryParse(catMa2.GetValue(0).ToString(), out IntConvert);
                if (!result2)
                {
                    MessageBox.Show("Mã Hợp đồng Lao Động không đúng quy định.!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mã Hợp đồng Lao Động không đúng quy định.!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Het kiem tra dinh dang ma HD
            Update_HopDongLaoDong();
            this.Close();
        }

        private void Update_HopDongLaoDong()
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang khởi tạo yêu cầu..");

            Class.NhanVien_HopDong_ThoiVu hd = new Class.NhanVien_HopDong_ThoiVu();
            hd.ContractCode = txtContractCode.Text;
            hd.EmployeeCode = txtEmployeeCode.EditValue.ToString();
            hd.ContractTime = txtContractTime.Text;
            hd.ContractYear = int.Parse(txtContractYear.Text);
            hd.SignDate = dateSignDate.DateTime;
            hd.FromDate = dateFromDate.DateTime;
            hd.ToDate = dateToDate.DateTime;
            hd.BasicSalary = txtBasicSalary.Value;
            hd.PayForm = txtPayForm.Text;
            hd.PayDate = txtPayDate.Text;
            hd.Allowance = txtAllowance.Text;
            hd.Insurance = txtInsurance.Text;
            hd.WorkTime = txtWorkTime.Text;
            hd.Signer = txtSigner.Text;
            hd.SignerPosition = txtSignerPosition.Text;
            hd.SignerNationality = txtSignerNationality.Text;
            hd.Company = txtCompany.Text;
            hd.Address = txtAddress.Text;
            hd.Tel = txtTel.Text;
            hd.Description = txtDescription.Text;
            hd.IsCurrent = checkIsCurrent.Checked;

            if (txtContractCode.Enabled == true)
            {                
                Waiting.SetWaitFormDescription("Đang thực hiện thêm..");
                if (hd.Insert())
                {
                    Waiting.SetWaitFormDescription("Đang tải dữ liệu..");

                    (this.Owner as frmDanhSachHopDong_Season).HRM_CONTRACT_SEASON_GetList();
                    
                    Waiting.CloseWaitForm();
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Waiting.CloseWaitForm();
                    Class.App.SaveNotSuccessfully();
                }
            }
            else
            {
                Waiting.SetWaitFormDescription("Đang thực hiện cập nhật..");
                if (hd.Update())
                {
                    Waiting.SetWaitFormDescription("Đang tải dữ liệu..");
                    (this.Owner as frmDanhSachHopDong_Season).HRM_CONTRACT_SEASON_GetList();
                    Waiting.CloseWaitForm();
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Waiting.CloseWaitForm();
                    Class.App.SaveNotSuccessfully();
                }
            }
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtSigner.Text.Length < 1 || txtFullName.Text.Length < 1 || txtContractCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
           
            // kiem tra ma HD hop le
            string ktMaHD = txtContractCode.Text;
            string[] catMa1 = ktMaHD.Split('-');
            if (catMa1.Length > 0)
            {
                int IntConvert;
                bool result = Int32.TryParse(catMa1.GetValue(0).ToString(), out IntConvert);
                if (!result)
                {
                    MessageBox.Show("Mã Hợp đồng Lao Động không đúng quy định.!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] catMa2 = catMa1.GetValue(1).ToString().Split('/');
                bool result2 = Int32.TryParse(catMa2.GetValue(0).ToString(), out IntConvert);
                if (!result2)
                {
                    MessageBox.Show("Mã Hợp đồng Lao Động không đúng quy định.!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mã Hợp đồng Lao Động không đúng quy định.!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Het kiem tra dinh dang ma HD

            Update_HopDongLaoDong();
            call_Code_New();
            _Add_New = true;
            txtFullName_TextChanged(null, null); // xu ly tieu de
            xulyTaoCodeHopdong();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            if (_Add_New)
            {
                this.Text = "Thêm Hợp Đồng Lao Động : " + txtFullName.Text;
            }
            else
            {
                this.Text = "Cập nhật Hợp Đồng Lao Động : " + txtFullName.Text;
            }
        }

    }
}