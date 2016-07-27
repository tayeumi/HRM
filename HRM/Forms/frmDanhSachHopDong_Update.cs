using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhSachHopDong_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachHopDong_Update()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        public bool _Add_New;
        static string _textAll="0";
        public frmDanhSachHopDong_Update(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
        {
            InitializeComponent();
            Get_EmployeeCodeToCBO();
            Set_NgayThangMacDinh();
            this.Text = Caption_name;
            GetList_Position();
            if (Add_new)
            {
              call_Code_New();
              alertControl.Show(this, "Các lưu ý khi thêm mới hợp đồng : ", 
                                       "- Năm lập Hợp đồng \r\n "+
                                       "- Loại hợp đồng và thời hạn hợp đồng.");
            }
            else
            {
             call_info(Form_name, Code);
             txtEmployeeCode.Enabled = false;
             txtContractCode.Enabled = false;
             txtContractYear.Enabled = false;
             txtContractType.Enabled = false;
             txtContractTime.Enabled = false;                
            }
            _reCallFunction = reCallFunction;
            _Add_New = Add_new;

            Get_Company_Info();
        }
        private void call_info(string Form_name, string code)
        {
            Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
            DataTable dt = hd.HRM_CONTRACT_Get(code);
            txtSigner.Text = dt.Rows[0]["Signer"].ToString();
            txtSignerNationality.Text = dt.Rows[0]["SignerNationality"].ToString();
            txtSignerPosition.Text = dt.Rows[0]["SignerPosition"].ToString();
            txtCompany.Text = dt.Rows[0]["Company"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtTel.Text = dt.Rows[0]["Tel"].ToString();
            checkIsCurrent.Checked = (bool)dt.Rows[0]["IsCurrent"];
            txtEmployeeCode.EditValue = dt.Rows[0]["EmployeeCode"].ToString();
        
            //tab thong tin hop dong
            if (dt.Rows[0]["SecondAllowance"].ToString().Length > 0)
                _textAll = dt.Rows[0]["SecondAllowance"].ToString();
            else
                _textAll = "0";

            txtContractCode.Text = dt.Rows[0]["ContractCode"].ToString();
            txtContractTime.Text = dt.Rows[0]["ContractTime"].ToString();
            txtContractType.Text = dt.Rows[0]["ContractType"].ToString();
            txtContractYear.Text = dt.Rows[0]["ContractYear"].ToString();
            dateSignDate.DateTime = (DateTime)dt.Rows[0]["SignDate"];
            dateFromDate.DateTime = (DateTime)dt.Rows[0]["FromDate"];
            if (dt.Rows[0]["ToDate"] != DBNull.Value)
            {
                dateToDate.DateTime = (DateTime)dt.Rows[0]["ToDate"];
            }
            txtBasicSalary.Value =(decimal)dt.Rows[0]["BasicSalary"];
            txtPayForm.Text = dt.Rows[0]["PayForm"].ToString();
            txtPayDate.Value = (int)dt.Rows[0]["PayDate"];
            txtAllowance.Text =dt.Rows[0]["Allowance"].ToString();
            txtTestAllowance.Text = dt.Rows[0]["SecondAllowance"].ToString();
            txtRate.Text = dt.Rows[0]["Rate"].ToString();
            txtInsurance.Text = dt.Rows[0]["Insurance"].ToString();
            txtWorkTime.Text = dt.Rows[0]["WorkTime"].ToString();
            txtSubject.Text = dt.Rows[0]["Subject"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
        }

        private string call_Code_New()
        {
            txtEmployeeCode.Enabled = true;
            txtContractCode.Enabled = true;
            txtContractYear.Enabled = true;
            txtContractType.Enabled = true;
            txtContractTime.Enabled = true;
            txtBasicSalary.Text = "";
            txtAllowance.Text = "";
            txtRate.Text = "80";
            txtSubject.Text = "";
            txtDescription.Text = "";
            Set_NgayThangMacDinh();
            xulyTaoCodeHopdong();
            cboSinger.EditValue = "PTH0259"; // mac dinh cho Tong Giam Doc
            _textAll = "0";
            return "";
        }

        private void xulyTaoCodeHopdong()
        {           
            if (_Add_New == true)
                {
                    if (txtFullName.Text != "[Họ và tên nhân viên]")
                    {
                    Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                    hd.ContractYear = int.Parse(txtContractYear.Text);
                   // hd.ContractType = txtContractType.Text;
                    DataTable dt = hd.HRM_CONTRACT_GetByYear();
                    hd.EmployeeCode=txtEmployeeCode.EditValue.ToString();
                    DataTable dthdbynv = hd.HRM_CONTRACT_GetByEmployee();

                    if (dt.Rows.Count > 0)
                    {
                         string _idCheck;
                        string[] cat ;
                         int next_ID=0;
                        int next_ID2=0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                           _idCheck = dt.Rows[i]["ContractCode"].ToString();
                           cat = _idCheck.Split('-');
                           next_ID2 = int.Parse(cat.GetValue(0).ToString());
                           if ((next_ID2 - next_ID) >1)
                           {                                                           
                               break;
                           }
                           next_ID = int.Parse(cat.GetValue(0).ToString());
                        }
                        //string _idContract = dt.Rows[dt.Rows.Count - 1]["ContractCode"].ToString();
                        //cat = _idContract.Split('-');
                        // next_ID = int.Parse(cat.GetValue(0).ToString()) + 1;
                        next_ID++;
                        if (next_ID.ToString().Length == 1)
                        {
                            txtContractCode.Text ="000"+ next_ID.ToString() + "-" + txtContractYear.Text;
                        }
                        if (next_ID.ToString().Length == 2)
                        {
                            txtContractCode.Text ="00"+ next_ID.ToString() + "-" + txtContractYear.Text;
                        }
                        if (next_ID.ToString().Length == 3)
                        {
                            txtContractCode.Text ="0"+ next_ID.ToString() + "-" + txtContractYear.Text;
                        }
                        if (next_ID.ToString().Length == 4)
                        {
                            txtContractCode.Text = next_ID.ToString() + "-" + txtContractYear.Text;
                        }                        
                    }
                    else
                    {
                        txtContractCode.Text = "0001-" + txtContractYear.Text;
                    }
                    // kiem tra ky hop dong truc tiep ko co thu viec
                    int solanHD = 1;
                    for (int i = 0; i < dthdbynv.Rows.Count; i++)
                    {
                        string maHD = dthdbynv.Rows[i]["ContractCode"].ToString();
                        if (maHD.Contains("HDTV"))
                        {
                            solanHD = dthdbynv.Rows.Count;
                            break;
                        }
                        if (maHD.Contains("HDLD"))
                        {
                            solanHD++;
                        }                       
                    }
                            switch (txtContractType.Text)
                            {
                                case "Hợp đồng xác định thời hạn":
                                    txtContractCode.Text = txtContractCode.Text + "/HDLD/Lan" + solanHD;
                                    break;

                                case "Hợp đồng không xác định thời hạn":
                                    txtContractCode.Text = txtContractCode.Text + "/HDLD/KXDTH-Lan" + solanHD;
                                    break;
                                case "Hợp đồng thử việc":
                                    txtContractCode.Text = txtContractCode.Text + "/HDTV";
                                    break;
                                case "Hợp đồng học việc":
                                    txtContractCode.Text = txtContractCode.Text + "/HDHV";
                                    break;
                            }

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

            // tam thoi han che khong cho lam lap 4 hop dong lao dong
            if(txtContractCode.Text.Contains("Lan4"))
            {
             MessageBox.Show("Hợp đồng Lao động chỉ chấp nhận nhỏ hơn 4 lần, Vui lòng kiểm tra lại hoặc liên hệ Người Quản Trị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Get_Company_Info()
        {
            Class.CongTy ct = new Class.CongTy();
            DataTable dt = ct.LoadThongTinCty();
            txtAddress.Text = dt.Rows[0]["CompanyAddress"].ToString();
            txtTel.Text = dt.Rows[0]["Tel"].ToString(); ;
        }

        private void Set_NgayThangMacDinh()
        {
            dateSignDate.DateTime = DateTime.Now;
            dateFromDate.DateTime = DateTime.Now;
            dateToDate.DateTime = DateTime.Now;
            txtContractYear.Text = DateTime.Now.Year.ToString();
        }

        private void frmDanhSachHopDong_Update_Load(object sender, EventArgs e)
        {
            if(txtEmployeeCode.EditValue!=null)
            Get_EmployeeCodeByCode(txtEmployeeCode.EditValue.ToString());
            this.Activate();
            btnUpdate.Focus();
        }

        private void Get_EmployeeCodeToCBO()
        {
            Class.NhanVien nv = new Class.NhanVien();
            nv.Status = -1;            
            DataTable dt = nv.LoadDanhSachNhanVien_Ex();
            cboSinger.Properties.DataSource = dt;
            cboSinger.Properties.DisplayMember = "EmployeeCode";
            cboSinger.Properties.ValueMember = "EmployeeCode";

            txtEmployeeCode.Properties.DataSource = dt;
            txtEmployeeCode.Properties.DisplayMember = "EmployeeCode";
            txtEmployeeCode.Properties.ValueMember = "EmployeeCode";
        }
        private void Get_EmployeeCodeByCode(string strcode)
        {
            Class.NhanVien nv = new Class.NhanVien();
            DataTable dt = nv.GetEmployeeByCode(strcode);
            txtFullName.Text = dt.Rows[0]["FirstName"].ToString() +" " + dt.Rows[0]["LastName"].ToString(); ;
            dateBirthday.DateTime = (DateTime)dt.Rows[0]["Birthday"];
            txtPosition.Text = dt.Rows[0]["Position"].ToString();
            txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
            txtIDCard.Text = dt.Rows[0]["IDCard"].ToString();
            dateIDCardDate.DateTime = (DateTime)dt.Rows[0]["IDCardDate"];
            txtIDCardPlace.Text = dt.Rows[0]["IDCardPlace"].ToString();
            txtBranchName.Text = dt.Rows[0]["BranchName"].ToString();

           

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

        private void Update_HopDongLaoDong()
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang khởi tạo yêu cầu..");

            Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
            hd.ContractCode = txtContractCode.Text;
            hd.EmployeeCode = txtEmployeeCode.EditValue.ToString();
            hd.ContractType = txtContractType.Text;
            hd.ContractTime = txtContractTime.Text;
            hd.ContractYear = int.Parse(txtContractYear.Text);
            hd.SignDate = dateSignDate.DateTime;
            hd.FromDate = dateFromDate.DateTime;
            hd.ToDate = dateToDate.DateTime;
            hd.BasicSalary = txtBasicSalary.Value;
            hd.PayForm = txtPayForm.Text;
            hd.PayDate=int.Parse(txtPayDate.Text);
            hd.Allowance = txtAllowance.Text;
            hd.SecondAllowance = txtTestAllowance.Text;
            hd.Rate = int.Parse(txtRate.Text);
            hd.Insurance = txtInsurance.Text;
            hd.WorkTime = txtWorkTime.Text;
            hd.Signer = txtSigner.Text;
            hd.SignerPosition = txtSignerPosition.Text;
            hd.SignerNationality = txtSignerNationality.Text;
            hd.Company = txtCompany.Text;
            hd.Address = txtAddress.Text;
            hd.Tel = txtTel.Text;
            hd.Subject = txtSubject.Text;
            hd.Description = txtDescription.Text;
            hd.IsCurrent = checkIsCurrent.Checked;

            if (txtContractCode.Enabled == true)
            {
                // kiem tra đa nhap hdkxdth chua neu co roi ko cho them nua
                Class.NhanVien_HopDong hdcheck = new Class.NhanVien_HopDong();

                hdcheck.EmployeeCode = txtEmployeeCode.EditValue.ToString();
                DataTable dthdbynv = hdcheck.HRM_CONTRACT_GetByEmployee();
                string _mahd;
                Waiting.SetWaitFormDescription("Đang kiểm tra hợp đồng..");
                for (int i = 0; i < dthdbynv.Rows.Count; i++)
                {
                     _mahd = dthdbynv.Rows[i]["ContractCode"].ToString();
                    if (_mahd.Contains("KXDTH"))
                    {
                        Waiting.CloseWaitForm();
                        MessageBox.Show("Bạn đã lập hợp đồng không xác định thời hạn rồi. không thể lập thêm được nữa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                        return;
                    }
                    if (_mahd.Contains("HDTV"))
                    {
                        if (hd.ContractCode.Contains("HDTV"))
                        {
                            Waiting.CloseWaitForm();
                            MessageBox.Show("Bạn đã lập hợp đồng Thử việc cho nhân viên này rồi. không thể lập thêm được nữa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           
                            return;
                        }
                    }
                }
                Waiting.SetWaitFormDescription("Đang thực hiện thêm..");
                if (hd.Insert())
                {
                    Waiting.SetWaitFormDescription("Đang tải dữ liệu..");
                    if (_reCallFunction == "frmDanhSachHopDong")
                    {
                        (this.Owner as frmDanhSachHopDong).HRM_CONTRACT_GetList();
                    }
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
                    if (_reCallFunction == "frmDanhSachHopDong")
                    {
                        (this.Owner as frmDanhSachHopDong).HRM_CONTRACT_GetList();
                    }
                    Waiting.CloseWaitForm();
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Waiting.CloseWaitForm();
                    Class.App.SaveNotSuccessfully();
                }
            }
            //if (_reCallFunction == "frmDanhSachHopDong")
            //{
            //    (this.Owner as frmDanhSachHopDong).HRM_CONTRACT_GetList();
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {            
            if (txtSigner.Text == "[Họ và tên người ký]" || txtFullName.Text=="[Họ và tên nhân viên]" || txtContractCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }

            // tam thoi han che khong cho lam lap 4 hop dong lao dong
            if (txtContractCode.Text.Contains("Lan"))
            {
                string _code = txtContractCode.Text.Substring(txtContractCode.Text.IndexOf("Lan")+3);
                int _codeNumber;
                bool _lan = int.TryParse(_code, out _codeNumber);
                if (_lan)
                {
                    if (_codeNumber > 3)
                    {
                        MessageBox.Show("Hợp đồng Lao động chỉ chấp nhận nhỏ hơn 4 lần, Vui lòng kiểm tra lại hoặc liên hệ Người Quản Trị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_codeNumber < 1)
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

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtSigner.Text.Length < 1 || txtFullName.Text.Length < 1 || txtContractCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            // tam thoi han che khong cho lam lap 4 hop dong lao dong
            if (txtContractCode.Text.Contains("Lan"))
            {
                string _code = txtContractCode.Text.Substring(txtContractCode.Text.IndexOf("Lan")+3);
                int _codeNumber;
                bool _lan = int.TryParse(_code, out _codeNumber);
                if (_lan)
                {
                    if (_codeNumber > 3)
                    {
                        MessageBox.Show("Hợp đồng Lao động chỉ chấp nhận nhỏ hơn 4 lần, Vui lòng kiểm tra lại hoặc liên hệ Người Quản Trị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_codeNumber <1)
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
        }

        private void txtContractYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            xulyTaoCodeHopdong();           
        }

        private void txtContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            xulyTaoCodeHopdong();
            if (txtContractType.Text == "Hợp đồng không xác định thời hạn")
            {
                txtContractTime.Text = "Không xác định thời hạn";
            }
        }

        private void txtContractTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (txtContractTime.Text)
            {
                case "0 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime;
                    break;
                case "1 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(1).AddDays(-1);
                    break;
                case "2 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(2).AddDays(-1);
                    break;
                case "6 Tháng":
                    dateToDate.DateTime = dateFromDate.DateTime.AddMonths(6).AddDays(-1);
                    break;
                case "1 Năm":
                    dateToDate.DateTime = dateFromDate.DateTime.AddYears(1).AddDays(-1);
                    break;
                case "2 Năm":
                    dateToDate.DateTime = dateFromDate.DateTime.AddYears(2).AddDays(-1);
                    break;
                case "3 Năm":
                    dateToDate.DateTime = dateFromDate.DateTime.AddYears(3).AddDays(-1);
                    break;
            }

        }

        private void txtRate_EditValueChanged(object sender, EventArgs e)
        {
            string _ra = txtRate.Text.Replace(",", "");
            int _rate = int.Parse(_ra);
            decimal _testSalary = txtBasicSalary.Value;
            decimal _testAllowance = txtAllowance.Value;
            
            decimal _txttestAllowance = decimal.Parse(_textAll); ;
            decimal _txtteAllowance=(_testAllowance * _rate / 100);

           txtTestSalary.Value = (_testSalary * _rate / 100);
           txtTestAllowance.Value = (_testAllowance * _rate / 100);
           if (_txttestAllowance > 0)
           {
               if (_txttestAllowance != _txtteAllowance)
               {
                   //tính toán nếu đã từng lưu tỷ lệ thì tính tự động / ap dung truong hop ngoai le nhap bang tay tro cap
                   txtTestAllowance.Text = _textAll;
               }
           }
        }

        private void txtBasicSalary_EditValueChanged(object sender, EventArgs e)
        {
            txtRate_EditValueChanged(null, null);
        }

        private void txtAllowance_EditValueChanged(object sender, EventArgs e)
        {
            txtRate_EditValueChanged(null, null);
        }

        public void GetList_Position()
        {
            Class.DanhMuc_ChucVu dm = new Class.DanhMuc_ChucVu();
            DataTable dt = dm.GetAllList_POSITION();
           // txtSubject.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtSubject.Properties.Items.Add(dt.Rows[i]["PositionName"].ToString());
            }
        }

        private void dateFromDate_Validated(object sender, EventArgs e)
        {
            txtContractTime_SelectedIndexChanged(null, null);
        }

        private void dateSignDate_Validated(object sender, EventArgs e)
        {
            dateFromDate.DateTime = dateSignDate.DateTime;
        }

        private void frmDanhSachHopDong_Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Dispose();
        }

        private void txtContractTime_Validated(object sender, EventArgs e)
        {
            if (txtContractType.Text == "Hợp đồng không xác định thời hạn")
            {
                if (txtContractTime.Text != "Không xác định thời hạn")
                {
                    MessageBox.Show("Hợp đồng là không xác định thời hạn không được chọn thời gian", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContractTime.Focus();
                }
            }
            else
            {
                if (txtContractTime.Text == "Không xác định thời hạn")
                {
                    MessageBox.Show("Hợp đồng có thời hạn, vui lòng chọn thời gian hiệu lực", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContractTime.Focus();
                }

            }
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