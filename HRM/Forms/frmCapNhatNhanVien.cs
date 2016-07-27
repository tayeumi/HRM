using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace HRM.Forms
{
    public partial class frmCapNhatNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmCapNhatNhanVien()
        {
            InitializeComponent();
        }
        public string _reCallFunction;
        frmQuaTrinhLamViec_KhenThuong frmkt = new frmQuaTrinhLamViec_KhenThuong();
        frmQuaTrinhLamViec_KyLuat frmkl = new frmQuaTrinhLamViec_KyLuat();
        frmQuaTrinhLamViec_DaoTao frmdtao = new frmQuaTrinhLamViec_DaoTao();
        frmQuaTrinhLamViec_ChucVu frmcv = new frmQuaTrinhLamViec_ChucVu();
        public frmCapNhatNhanVien(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
        {
            InitializeComponent();
            // call func_all combobox
            GetList_Nationality();  // quoc tich
            GetList_Ethnic();   // dan toc
            GetList_Religion(); // ton giao
            GetList_Education();    // Hoc van
            GetList_Language();     // ngoai ngu
            GetList_Informatic();       // tin hoc
            GetList_Professional(); // Chuyen mon
            GetList_School();       // truong hoc
            GetList_Degree();       // bang cap
            GetList_Branch(); /// danh sach chi nhanh
                              /// 
            GetList_Position(); // danh sach chuc vu     
           
            GetList_Province();         //Danh sach tinh
            Set_NgayThangMacDinh();

            this.Text = Caption_name;           
            if (Add_new)
            {
              txtEmployeeCode.Text = call_Code_New();              
            }
            else
            {
                call_info(Form_name, Code);
                txtEmployeeCode.Enabled = false;

                frmkt.TopLevel = false;
                frmkt.Dock = System.Windows.Forms.DockStyle.Fill;
                TabKhenThuong.Controls.Add(frmkt);
                frmkt.Show();

                frmkl.TopLevel = false;
                frmkl.Dock = System.Windows.Forms.DockStyle.Fill;
                TabKyLuat.Controls.Add(frmkl);
                frmkl.Show();

                frmdtao.TopLevel = false;
                frmdtao.Dock = System.Windows.Forms.DockStyle.Fill;
                TabQTDaoTao.Controls.Add(frmdtao);
                frmdtao.Show();

                frmcv.TopLevel = false;
                frmcv.Dock = System.Windows.Forms.DockStyle.Fill;
                frmcv.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                TabThayDoiChucVu.Controls.Add(frmcv);
                frmcv.Show();
                Call_Info_NV();
            }
            _reCallFunction = reCallFunction;
        }
       
        private void call_info(string Form_name, string code)
        {
            Class.NhanVien nv = new Class.NhanVien();
            DataTable dt = nv.GetEmployeeByCode(code);
            try
            {
                #region Tab_ThongTinNhanVien
                txtEmployeeCode.Text = dt.Rows[0]["EmployeeCode"].ToString();
                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                checkSex.Checked = (bool)dt.Rows[0]["Sex"];                
                if (dt.Rows[0]["Photo"] != DBNull.Value)
                {
                    // xu ly photo            
                    Byte[] imgbyte = (byte[])dt.Rows[0]["Photo"];
                    if (imgbyte.Length > 10)
                    {
                        MemoryStream stmPicData = new MemoryStream(imgbyte);
                        PicPhoto.Image = Image.FromStream(stmPicData);
                    }
                    //
                }             
                if(dt.Rows[0]["Birthday"]!=DBNull.Value)
                 dateBirthday.DateTime = (DateTime)dt.Rows[0]["Birthday"];
                txtBirthPlace.Text = dt.Rows[0]["BirthPlace"].ToString();
                txtAlias.Text = dt.Rows[0]["Alias"].ToString();
                txtMarriage.Text = dt.Rows[0]["Marriage"].ToString();
                txtMainAddress.Text = dt.Rows[0]["MainAddress"].ToString();
                txtContactAddress.Text = dt.Rows[0]["ContactAddress"].ToString();
                txtCellPhone.Text = dt.Rows[0]["CellPhone"].ToString();
                txtHomePhone.Text = dt.Rows[0]["HomePhone"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
                txtEthnic.Text = dt.Rows[0]["Ethnic"].ToString();
                txtReligion.Text = dt.Rows[0]["Religion"].ToString();
                txtEducation.Text = dt.Rows[0]["Education"].ToString();
                txtLanguage.Text = dt.Rows[0]["Language"].ToString();
                txtInformatic.Text = dt.Rows[0]["Informatic"].ToString();
                txtProfessional.Text = dt.Rows[0]["Professional"].ToString();
                // txtDegreeCode.Text = dt.Rows[0]["DegreeCode"].ToString();
                txtSchool.Text = dt.Rows[0]["School"].ToString();
                txtIDCard.Text = dt.Rows[0]["IDCard"].ToString();
                if(dt.Rows[0]["IDCardDate"]!=DBNull.Value)
                      dateIDCardDate.DateTime = (DateTime)dt.Rows[0]["IDCardDate"];
                txtIDCardPlace.Text = dt.Rows[0]["IDCardPlace"].ToString();
                txtHealth.Text = dt.Rows[0]["Health"].ToString();
                txtHeight.Text = dt.Rows[0]["Height"].ToString();
                txtWeight.Text = dt.Rows[0]["Weight"].ToString();
                txtEnrollNumber.Text = dt.Rows[0]["EnrollNumber"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
              
                nv.EmployeeCode = code;
                for (int i = 0; i < txtDegreeCode.Properties.Items.Count; i++)
                {
                    nv.DegreeCode = txtDegreeCode.Properties.Items[i].Value.ToString();
                    if (nv.GetEmployee_Degree().Rows.Count > 0)
                        txtDegreeCode.Properties.Items[i].CheckState = CheckState.Checked;
                }
                #endregion

                #region Tab_ThongtinCongViec
                txtBranchCode.EditValue = dt.Rows[0]["BranchCode"].ToString();
                txtDepartmentCode.EditValue = dt.Rows[0]["DepartmentCode"].ToString();
                txtGroupCode.EditValue = dt.Rows[0]["GroupCode"].ToString();
                txtPosition.Text = dt.Rows[0]["Position"].ToString();
                // txtPayForm.SelectedIndex = (int)dt.Rows[0]["PayForm"];
                //txtPayForm_SelectedIndexChanged(null, null);        // goi hàm select vi form chua load xong nen chua cap nhat gia tri
                // txtPayMoney.Value = (decimal)dt.Rows[0]["PayMoney"];
                // txtRankSalary.EditValue = dt.Rows[0]["RankSalary"].ToString();
                //  txtStepSalary.Text = dt.Rows[0]["StepSalary"].ToString(); // tam thoi gan gia tri( gia tri nay phai là dt source
                //   txtMinimumSalary.Value = (decimal)dt.Rows[0]["MinimumSalary"];
                //   txtCoefficientSalary.Text =dt.Rows[0]["CoefficientSalary"].ToString();
                //  txtBasicSalary.Value = (decimal)dt.Rows[0]["BasicSalary"];
                //  dateDateSalary.DateTime = (DateTime)dt.Rows[0]["DateSalary"];
                //  txtInsuranceSalary.Value = (decimal)dt.Rows[0]["InsuranceSalary"];
                txtInsuranceCode.Text = dt.Rows[0]["InsuranceCode"].ToString();
                if (dt.Rows[0]["InsuranceDate"] != DBNull.Value)
                {
                    dateInsuranceDate.DateTime = (DateTime)dt.Rows[0]["InsuranceDate"];
                }
                txtInsurancePlace.Text = dt.Rows[0]["InsurancePlace"].ToString();
                txtHealthInsuranceCode.Text = dt.Rows[0]["HealthInsuranceCode"].ToString();
                if (dt.Rows[0]["HealthInsuranceFromDate"] != DBNull.Value)
                     dateHealthInsuranceFromDate.DateTime = (DateTime)dt.Rows[0]["HealthInsuranceFromDate"];
                if (dt.Rows[0]["HealthInsuranceToDate"] != DBNull.Value)
                        dateHealthInsuranceToDate.DateTime = (DateTime)dt.Rows[0]["HealthInsuranceToDate"];
                // tam xử lý code này để get thông tin bvien65benh thuoc tinh
                txtProvince.EditValue = Class.DanhMuc_Tinh.GetProvinceSearch(dt.Rows[0]["Province"].ToString());
                //
                txtHospital.EditValue = dt.Rows[0]["Hospital"].ToString();
                txtTaxCode.Text = dt.Rows[0]["TaxCode"].ToString();
                //  txtContractCode.Text = dt.Rows[0]["ContractCode"].ToString();
                //  txtContractType.Text = dt.Rows[0]["ContractType"].ToString();
                //  dateContractSignDate.DateTime = (DateTime)dt.Rows[0]["ContractSignDate"];
                //  dateContractFromDate.DateTime = (DateTime)dt.Rows[0]["ContractFromDate"];
                //   dateContractToDate.DateTime = (DateTime)dt.Rows[0]["ContractToDate"];
                checkIsSocialInsurance.Checked = (bool)dt.Rows[0]["IsSocialInsurance"];
                checkIsHealthInsurance.Checked = (bool)dt.Rows[0]["IsHealthInsurance"];
                checkIsUnemploymentInsurance.Checked = (bool)dt.Rows[0]["IsUnemploymentInsurance"];
                checkIsUnionMoney.Checked = (bool)dt.Rows[0]["IsUnionMoney"];
                // checkIsTest.Checked = (bool)dt.Rows[0]["IsTest"];
                //  txtTestTime.Text = dt.Rows[0]["TestTime"].ToString();
                //  txtTestSalary.Value = (decimal)dt.Rows[0]["TestSalary"];
                //  dateTestFromDate.DateTime = (DateTime)dt.Rows[0]["TestFromDate"];
                //  dateTestToDate.DateTime = (DateTime)dt.Rows[0]["TestToDate"];
                if (dt.Rows[0]["BeginDate"] != DBNull.Value)
                      dateBeginDate.DateTime = (DateTime)dt.Rows[0]["BeginDate"];
                if (dt.Rows[0]["EndDate"] != DBNull.Value)                
                    dateEndDate.DateTime = (DateTime)dt.Rows[0]["EndDate"];
                
                txtExperiences.Text = dt.Rows[0]["Experiences"].ToString();
                txtStopWork.Text = dt.Rows[0]["StopWork"].ToString();
                #endregion

                txtStatus.SelectedIndex = (int)dt.Rows[0]["Status"];  // chuyen duoi de  doc thong tin nghi viec cho dung
               
                // kiem tra neu đang stop thi ko load khoi tao ma nghi viec khi load len
                if ((int)dt.Rows[0]["Status"] == 3)
                {
                    _IsCreateDeactive = false;
                }
                else
                {
                    _IsCreateDeactive = true;
                }


                #region Tab_ThongTinXaHoi
                checkIsUnion.Checked = (bool)dt.Rows[0]["IsUnion"];
                txtUnionCode.Text = dt.Rows[0]["UnionCode"].ToString();
                if (dt.Rows[0]["UnionDate"] != DBNull.Value)    
                      dateUnionDate.DateTime = (DateTime)dt.Rows[0]["UnionDate"];
                txtUnionPlace.Text = dt.Rows[0]["UnionPlace"].ToString();

                checkIsParty.Checked = (bool)dt.Rows[0]["IsParty"];
                txtPartyCode.Text = dt.Rows[0]["PartyCode"].ToString();
                if (dt.Rows[0]["PartyDate"] != DBNull.Value)   
                     datePartyDate.DateTime = (DateTime)dt.Rows[0]["PartyDate"];
                txtPartyPlace.Text = dt.Rows[0]["PartyPlace"].ToString();

                txtMilitaryCode.Text = dt.Rows[0]["MilitaryCode"].ToString();
                if (dt.Rows[0]["MilitaryFromDate"] != DBNull.Value)   
                      dateMilitaryFromDate.DateTime = (DateTime)dt.Rows[0]["MilitaryFromDate"];
                if (dt.Rows[0]["MilitaryToDate"] != DBNull.Value)  
                     dateMilitaryToDate.DateTime = (DateTime)dt.Rows[0]["MilitaryToDate"];
                txtMilitaryPosition.Text = dt.Rows[0]["MilitaryPosition"].ToString();

                txtBankCode.Text = dt.Rows[0]["BankCode"].ToString();
                if (dt.Rows[0]["BankDate"] != DBNull.Value)  
                         dateBankDate.DateTime = (DateTime)dt.Rows[0]["BankDate"];
                txtBankName.Text = dt.Rows[0]["BankName"].ToString();
                txtBankAddress.Text = dt.Rows[0]["BankAddress"].ToString();

                txtPassportCode.Text = dt.Rows[0]["PassportCode"].ToString();
                if (dt.Rows[0]["PassportFromDate"] != DBNull.Value)  
                     datePassportFromDate.DateTime = (DateTime)dt.Rows[0]["PassportFromDate"];
                if (dt.Rows[0]["PassportToDate"] != DBNull.Value)  
                      datePassportToDate.DateTime = (DateTime)dt.Rows[0]["PassportToDate"];

                txtLaborCode.Text = dt.Rows[0]["LaborCode"].ToString();
                if (dt.Rows[0]["LaborDate"] != DBNull.Value)  
                        dateLaborDate.DateTime = (DateTime)dt.Rows[0]["LaborDate"];
                txtLaborPlace.Text = dt.Rows[0]["LaborPlace"].ToString();

                txtAccount.Text = dt.Rows[0]["Account"].ToString();
                txtPassword.Text = dt.Rows[0]["Password"].ToString();

                #endregion

                #region Tab_PhuCap
                GetList_AllowanceByEmployee(code);
                #endregion

                #region Tab_LienHe
                GetList_RelativeByEmployee(code);
                #endregion
            }
            catch { }
            }

        private string call_Code_New()
        {
            string code = "";
            Class.NhanVien nv = new Class.NhanVien();
            nv.Status = -1;
            nv.DayFirstMonth = DateTime.Now;
            nv.DayEndMonth = DateTime.Now;
            code = nv.GetNewCode();
            TabThayDoiChucVu.PageVisible = false;
            TabKhenThuong.PageVisible = false;
            TabKyLuat.PageVisible = false;
            TabQTDaoTao.PageVisible = false;
            return code;
        }

        #region Call_insert_Combobox

        #region Call_insert_Combobox_TabThongtinNhanVien
        public void GetList_Nationality()
        {
            Class.DanhMuc_QuocTich dm = new Class.DanhMuc_QuocTich();
            DataTable dt=dm.GetAllList_NATIONALITY();
            txtNationality.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               txtNationality.Properties.Items.Add(dt.Rows[i]["NationalityName"].ToString());
            }
        }
        public void GetList_Ethnic()
        {
            Class.DanhMuc_DanToc dm = new Class.DanhMuc_DanToc();
            DataTable dt = dm.GetAllList_ETHNIC();
            txtEthnic.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtEthnic.Properties.Items.Add(dt.Rows[i]["EthnicName"].ToString());
            }
        }
        public void GetList_Religion()
        {
            Class.DanhMuc_TonGiao dm = new Class.DanhMuc_TonGiao();
            DataTable dt = dm.GetAllList_RELIGION();
            txtReligion.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtReligion.Properties.Items.Add(dt.Rows[i]["ReligionName"].ToString());
            }
        }
        public void GetList_Education()
        {
            Class.DanhMuc_HocVan dm = new Class.DanhMuc_HocVan();
            DataTable dt = dm.GetAllList_EDUCATION();
            txtEducation.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtEducation.Properties.Items.Add(dt.Rows[i]["EducationName"].ToString());
            }
        }
        public void GetList_Language()
        {
            Class.DanhMuc_NgoaiNgu dm = new Class.DanhMuc_NgoaiNgu();
            DataTable dt = dm.GetAllList_LANGUAGE();
            txtLanguage.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtLanguage.Properties.Items.Add(dt.Rows[i]["LanguageName"].ToString());
            }
        }
        public void GetList_Informatic()
        {
            Class.DanhMuc_TinHoc dm = new Class.DanhMuc_TinHoc();
            DataTable dt = dm.GetAllList_INFORMATIC();
            txtInformatic.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtInformatic.Properties.Items.Add(dt.Rows[i]["InformaticName"].ToString());
            }
        }
        public void GetList_Professional()
        {
            Class.DanhMuc_ChuyenMon dm = new Class.DanhMuc_ChuyenMon();
            DataTable dt = dm.GetAllList_PROFESSIONAL();
            txtProfessional.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtProfessional.Properties.Items.Add(dt.Rows[i]["ProfessionalName"].ToString());
            }
        }
        public void GetList_School()
        {
            Class.DanhMuc_TruongHoc dm = new Class.DanhMuc_TruongHoc();
            DataTable dt = dm.GetAllList_SCHOOL();
            txtSchool.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtSchool.Properties.Items.Add(dt.Rows[i]["SchoolName"].ToString());
            }
        }
        public void GetList_Degree()
        {
            Class.DanhMuc_BangCap dm = new Class.DanhMuc_BangCap();
            DataTable dt = dm.GetAllList_DIC_DEGREE();
            txtDegreeCode.Properties.DataSource = dt;
            txtDegreeCode.Properties.DisplayMember = "DegreeName";
            txtDegreeCode.Properties.ValueMember = "DegreeCode";
            txtDegreeCode.RefreshEditValue();
        }
        #endregion

        #region Call_insert_Combobox_TabThongtinCongviec
        public void GetList_Branch()
        {
            Class.DanhSach_ChiNhanh dm = new Class.DanhSach_ChiNhanh();
            DataTable dt = dm.GetAllList_BRANCH();
            txtBranchCode.Properties.DataSource = dt;
            txtBranchCode.Properties.DisplayMember = "BranchName";
            txtBranchCode.Properties.ValueMember = "BranchCode";
        }
        public void GetList_DepartmentByBranch(string strcode)
        {
            Class.PhongBan dm = new Class.PhongBan();
            dm.BranchCode=strcode;
            DataTable dt = dm.LoadDanhSachPhongBanThuocChiNhanh();
            txtDepartmentCode.Properties.DataSource = dt;
            txtDepartmentCode.Properties.DisplayMember = "DepartmentName";
            txtDepartmentCode.Properties.ValueMember = "DepartmentCode";
          
        }
        public void GetList_GroupByDepartment(string strcode)
        {
            Class.DanhSach_Nhom dm = new Class.DanhSach_Nhom();
            dm.DepartmentCode = strcode;
            DataTable dt = dm.GetGroupByDepartment();
            if (dt.Rows.Count > 0)
            {
                txtGroupCode.Properties.DataSource = dt;
                txtGroupCode.Properties.DisplayMember = "GroupName";
                txtGroupCode.Properties.ValueMember = "GroupCode";
            }
            else
            {
                txtGroupCode.EditValue = "";
            }
        }
        public void GetList_Position()
        {
            Class.DanhMuc_ChucVu dm = new Class.DanhMuc_ChucVu();
            DataTable dt = dm.GetAllList_POSITION();
            txtPosition.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtPosition.Properties.Items.Add(dt.Rows[i]["PositionName"].ToString());
            }
        }
            
        
        public void GetList_Province()
        {
            Class.DanhMuc_Tinh dm = new Class.DanhMuc_Tinh();
            DataTable dt = dm.GetAllList_PROVINCE(); 
            txtProvince.Properties.DataSource = dt;
            txtProvince.Properties.DisplayMember = "ProvinceName";
            txtProvince.Properties.ValueMember = "ProvinceCode";
           // txtProvince.EditValue = "TI000004";
        }

        public void GetList_HospitalByProvince()
        {
            Class.DanhMuc_BenhVien dm = new Class.DanhMuc_BenhVien();
            dm.ProvinceCode = txtProvince.EditValue.ToString();
            DataTable dt = dm.GetHospitalByProvince();  
           // txtHospital.Properties.Items.Clear();
            //txtHospital.Text = "";
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    txtHospital.Properties.Items.Add(dt.Rows[i]["HospitalName"].ToString());
            //}
            txtHospital.Properties.DataSource = dt;
            txtHospital.Properties.DisplayMember = "HospitalName";
            txtHospital.Properties.ValueMember = "HospitalName";
        }
        #endregion

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmployeeCode.Text.Length < 1 || txtFirstName.Text.Length < 1 || txtLastName.Text.Length < 1 || txtBirthPlace.Text.Length<1)
            {
                Class.App.InputNotAccess();
                TabControl.SelectedTabPage = TabInfo;
                return;
            }
            if (txtBranchCode.EditValue == null || txtDepartmentCode.EditValue == null || txtPosition.EditValue==null)
            {
                Class.App.InputNotAccess();
                TabControl.SelectedTabPage = TabWork;
                return;
            }
            // xu ly kiem tra EnrollNumber
            Class.NhanVien nv = new Class.NhanVien();
            nv.EnrollNumber = txtEnrollNumber.Text;          
            if (txtEnrollNumber.Text.Length != 0)
            {
                DataTable dtcheckEnroll = nv.HRM_EMPLOYEE_GetByEnroll();
                if (dtcheckEnroll.Rows.Count > 0)
                {
                    if (dtcheckEnroll.Rows[0]["EmployeeCode"].ToString() != txtEmployeeCode.Text)
                    {
                        MessageBox.Show(" Mã Chấm công đã có. bạn không thể sử dụng mã chấm công này !!");
                        return;
                    }
                }
            }
            // het xu ly kiem tra ma cham cong
            if (txtEmployeeCode.Enabled == true)
            {
                nv.IDCard = txtIDCard.Text;
                // kiem tra nhan vien da tung lam chua bang cach kiem tra CMND
                DataTable dTCheckID = nv.HRM_EMPLOYEE_CheckIDCard();
                if (dTCheckID.Rows.Count > 0)
                {
                    if (MessageBox.Show("Thông Tin CMND trùng lặp, Bạn có muốn tiếp tục không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                }
            }
            Update_NhanVien();

            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtEmployeeCode.Text.Length < 1 || txtFirstName.Text.Length < 1 || txtLastName.Text.Length < 1 || txtBirthPlace.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                TabControl.SelectedTabPage = TabInfo;
                return;
            }
            if (txtBranchCode.EditValue == null || txtDepartmentCode.EditValue == null || txtPosition.EditValue == null)
            {
                Class.App.InputNotAccess();
                TabControl.SelectedTabPage = TabWork;
                return;
            }
            // xu ly kiem tra EnrollNumber
            Class.NhanVien nv = new Class.NhanVien();
            nv.EnrollNumber = txtEnrollNumber.Text;
            if (txtEnrollNumber.Text.Length != 0)
            {
                DataTable dtcheckEnroll = nv.HRM_EMPLOYEE_GetByEnroll();
                if (dtcheckEnroll.Rows.Count > 0)
                {
                    if (dtcheckEnroll.Rows[0]["EmployeeCode"].ToString() != txtEmployeeCode.Text)
                    {
                        MessageBox.Show(" Mã Chấm công đã có. bạn không thể sử dụng mã chấm công này !!");
                        return;
                    }
                }
            }

            if (txtEmployeeCode.Enabled == true)
            {
                nv.IDCard = txtIDCard.Text;
                // kiem tra nhan vien da tung lam chua bang cach kiem tra CMND
                DataTable dTCheckID = nv.HRM_EMPLOYEE_CheckIDCard();
                if (dTCheckID.Rows.Count > 0)
                {
                    if (MessageBox.Show("Thông Tin CMND trùng lặp, Bạn có muốn tiếp tục không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                }
            }

            // het xu ly kiem tra ma cham cong
            Update_NhanVien();
            txtEmployeeCode.Enabled = true;
            txtEmployeeCode.Text = call_Code_New();
            Clear_txt();
            Set_NgayThangMacDinh();
            TabControl.SelectedTabPage = TabInfo;
            txtFirstName.Focus();
        }

        private void txtBranchCode_EditValueChanged(object sender, EventArgs e)
        {
            GetList_DepartmentByBranch(txtBranchCode.EditValue.ToString()); 
        }

        private void txtDepartmentCode_EditValueChanged(object sender, EventArgs e)
        {
            GetList_GroupByDepartment(txtDepartmentCode.EditValue.ToString());
        }
        
        private void txtProvince_EditValueChanged(object sender, EventArgs e)
        {
            GetList_HospitalByProvince();
        }

        private void txtProvince_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMucTinh frm = new frmDanhMucTinh();
                frm.ShowDialog();
            }
        }

        private void txtHospital_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMucBenhVien frm = new frmDanhMucBenhVien();
                frm.ShowDialog();
            }
        }

        private void txtGroupCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Del")
            {
                txtGroupCode.Text = "";
            }
        }

        public void GetList_AllowanceByEmployee(string strCode)
        {
            Class.NhanVien_PhuCap pc = new Class.NhanVien_PhuCap();
            pc.EmployeeCode = strCode;
            gridPhuCap.DataSource = pc.GetAllowanceByEmployee();

        }
        public void GetList_RelativeByEmployee(string strCode)
        {
            Class.NhanVien_LienHe lh = new Class.NhanVien_LienHe();
            lh.EmployeeCode = strCode;
            gridLienHe.DataSource = lh.GetRelativeByEmployee();

        }

        private void txtNationality_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMuc_Update frm = new frmDanhMuc_Update(true, "Thêm Quốc tịch", "QT", null, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void txtEthnic_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMuc_Update frm = new frmDanhMuc_Update(true, "Thêm Dân tộc", "DT", null, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void txtReligion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMuc_Update frm = new frmDanhMuc_Update(true, "Thêm Tôn giáo", "TG", null, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void txtEducation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMuc_Update frm = new frmDanhMuc_Update(true, "Thêm Học vấn", "HV", null, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void txtLanguage_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMuc_Update frm = new frmDanhMuc_Update(true, "Thêm Bằng Ngoại ngữ", "NN", null, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void txtInformatic_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMuc_Update frm = new frmDanhMuc_Update(true, "Thêm Bằng Tin học", "TH", null, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void txtProfessional_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMuc_Update frm = new frmDanhMuc_Update(true, "Thêm Chuyên môn", "CM", null, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void txtDegreeCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMuc_Update frm = new frmDanhMuc_Update(true, "Thêm Bằng cấp", "BC", null, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void txtSchool_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Add")
            {
                frmDanhMucTruongHoc frm = new frmDanhMucTruongHoc();              
               frm.ShowDialog();
               GetList_School();
            }
        }

        private void Update_NhanVien()
        {
            if (txtStatus.SelectedIndex == 3)
            {
                alertControl.Show(this, "Lưu ý nhân viên nghỉ việc:", "- Cập nhật đúng ngày nghỉ. \r\n - Số Quyết định nghỉ. \r\n - Lý do nghỉ ( nếu có ).");
            }

            Class.NhanVien nv = new Class.NhanVien();
            //if (txtEmployeeCode.Enabled == true)
            //{
            //    nv.IDCard = txtIDCard.Text;
            //    // kiem tra nhan vien da tung lam chua bang cach kiem tra CMND
            //    DataTable dTCheckID = nv.HRM_EMPLOYEE_CheckIDCard();
            //    if (dTCheckID.Rows.Count > 0)
            //    {
            //        if (MessageBox.Show("Thông Tin CMND trùng lặp, Bạn có muốn tiếp tục không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //        {
            //            return;
            //        }

            //    }
            //}

            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang lưu dữ liệu");
            #region Update_Tab_ThongTinNhanVien
           
            nv.EmployeeCode = txtEmployeeCode.Text;
            nv.FirstName = txtFirstName.Text;
            nv.LastName = txtLastName.Text;
            nv.Sex = checkSex.Checked;
            nv.Birthday = dateBirthday.DateTime;
            nv.BirthPlace = txtBirthPlace.Text;
            nv.Alias = txtAlias.Text;
            nv.Marriage = txtMarriage.Text;
            nv.MainAddress = txtMainAddress.Text;
            nv.ContactAddress = txtContactAddress.Text;
            nv.CellPhone = txtCellPhone.Text;
            nv.HomePhone = txtHomePhone.Text;
            nv.Email = txtEmail.Text;
            // xu ly Photo
            if (PicPhoto.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                PicPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] bytImage = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(bytImage, 0, Convert.ToInt32(ms.Length));
                nv.Photo = bytImage;
            }
            else
            {               
               nv.Photo = null;
            }
            nv.Nationality = txtNationality.Text;
            nv.Ethnic = txtEthnic.Text;
            nv.Religion = txtReligion.Text;
            nv.Education = txtEducation.Text;
            nv.Language = txtLanguage.Text;
            nv.Informatic = txtInformatic.Text;
            nv.Professional = txtProfessional.Text;
            nv.School = txtSchool.Text;
            nv.IDCard = txtIDCard.Text;
            nv.IDCardDate = dateIDCardDate.DateTime;
            nv.IDCardPlace = txtIDCardPlace.Text;
            nv.Health = txtHealth.Text;
            nv.Height = (float)txtHeight.Value;
            nv.Weight = (float)txtWeight.Value;
            nv.EnrollNumber = txtEnrollNumber.Text;
            nv.Description = txtDescription.Text;
            nv.Status = (int)txtStatus.SelectedIndex;
          // xu ly bang cap
          
           DataTable dtDegree = new DataTable();
           dtDegree.Columns.Add("DegreeCode", Type.GetType("System.String"));

            for (int i = 0; i < txtDegreeCode.Properties.Items.Count; i++)
            {               
               if(txtDegreeCode.Properties.Items[i].CheckState == CheckState.Checked)
                   dtDegree.Rows.Add(new Object[] { txtDegreeCode.Properties.Items[i].Value.ToString() });
               
            }
            // het xu ly            
            #endregion

            #region Tab_ThongTinCongViec
            nv.BranchCode = txtBranchCode.EditValue.ToString();
            nv.DepartmentCode = txtDepartmentCode.EditValue.ToString();
            if (txtGroupCode.EditValue.ToString()=="")
                 nv.GroupCode="";
            else
            nv.GroupCode = txtGroupCode.EditValue.ToString();

            nv.Position = txtPosition.Text;
           // nv.PayForm = txtPayForm.SelectedIndex;
         //   nv.PayMoney = txtPayMoney.Value;
          //  nv.RankSalary = txtRankSalary.EditValue.ToString();
          //  if(txtStepSalary.Text!=""){
          //  nv.StepSalary = int.Parse(txtStepSalary.Text);
          //    }
          //  nv.MinimumSalary = txtMinimumSalary.Value;
          //  nv.CoefficientSalary =(float)txtCoefficientSalary.Value;
          //  nv.BasicSalary = txtBasicSalary.Value;
          //  nv.DateSalary = dateDateSalary.DateTime;
           // nv.InsuranceSalary = txtInsuranceSalary.Value;
            nv.InsuranceCode = txtInsuranceCode.Text;
            nv.InsuranceDate = dateInsuranceDate.DateTime;
            nv.InsurancePlace = txtInsurancePlace.Text;
            nv.HealthInsuranceCode = txtHealthInsuranceCode.Text;
            nv.HealthInsuranceFromDate = dateHealthInsuranceFromDate.DateTime;
            nv.HealthInsuranceToDate = dateHealthInsuranceToDate.DateTime;
            nv.Province = txtProvince.Text;
            nv.Hospital = txtHospital.EditValue.ToString();
            nv.TaxCode = txtTaxCode.Text;
         //   nv.ContractCode = txtContractCode.Text;
          //  nv.ContractType = txtContractType.Text;
         //   nv.ContractSignDate = dateContractSignDate.DateTime;
        //    nv.ContractFromDate = dateContractFromDate.DateTime;
        //    nv.ContractToDate = dateContractToDate.DateTime;
            nv.IsSocialInsurance = checkIsSocialInsurance.Checked;
            nv.IsHealthInsurance = checkIsHealthInsurance.Checked;
            nv.IsUnemploymentInsurance = checkIsUnemploymentInsurance.Checked;
            nv.IsUnionMoney = checkIsUnionMoney.Checked;
          //  nv.IsTest = checkIsTest.Checked;
           // nv.TestTime = txtTestTime.Text;
           // nv.TestSalary = txtTestSalary.Value;
           // nv.TestFromDate = dateTestFromDate.DateTime;
           // nv.TestToDate = dateTestToDate.DateTime;
             nv.BeginDate = dateBeginDate.DateTime;
           nv.EndDate = dateEndDate.DateTime;
           nv.Experiences = txtExperiences.Text;
           nv.StopWork = txtStopWork.Text;
           nv.StopWorkCode = txtStopWorkCode.Text;
           nv.IsHopDong = _IsHopDong;
            #endregion

            #region Update_TabThongTinXaHoi
            nv.IsUnion = checkIsUnion.Checked;
            nv.UnionCode = txtUnionCode.Text;
            nv.UnionDate = dateUnionDate.DateTime;
            nv.UnionPlace = txtUnionPlace.Text;

            nv.IsParty = checkIsParty.Checked;
            nv.PartyCode = txtPartyCode.Text;
            nv.PartyDate = datePartyDate.DateTime;
            nv.PartyPlace = txtPartyPlace.Text;

            nv.MilitaryCode = txtMilitaryCode.Text;
            nv.MilitaryFromDate = dateMilitaryFromDate.DateTime;
            nv.MilitaryToDate = dateMilitaryToDate.DateTime;
            nv.MilitaryPosition = txtMilitaryPosition.Text;

            nv.BankCode = txtBankCode.Text;
            nv.BankDate = dateBankDate.DateTime;
            nv.BankName = txtBankName.Text;
            nv.BankAddress = txtBankAddress.Text;

            nv.PassportCode = txtPassportCode.Text;
            nv.PassportFromDate = datePassportFromDate.DateTime;
            nv.PassportToDate = datePassportToDate.DateTime;

            nv.LaborCode = txtLaborCode.Text;
            nv.LaborDate = dateLaborDate.DateTime;
            nv.LaborPlace = txtLaborPlace.Text;

            nv.Account = txtAccount.Text;
            nv.Password = txtPassword.Text;
            #endregion

            this.Activate();
            
            if (txtEmployeeCode.Enabled == true)
            {
                if (nv.Insert(dtDegree))
                {
                    Waiting.SetWaitFormDescription("Đang tải danh sách nhân viên..");
                    (this.Owner as frmDanhSachNhanVien).loaddsNhanVien();
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
                if (nv.Update(dtDegree))
                {
                    Waiting.SetWaitFormDescription("Đang tải danh sách nhân viên..");
                    (this.Owner as frmDanhSachNhanVien).loaddsNhanVien();
                    Waiting.CloseWaitForm();
                    Class.App.SaveSuccessfully();
                   
                }
                else
                {
                    Waiting.CloseWaitForm();
                    Class.App.SaveNotSuccessfully();
                  
                }
            }
           // (this.Owner as frmDanhSachNhanVien).loaddsCocautochuc();
            
        }

        private void Update_PhuCap()
        {
            if (txtEmployeeCode.Enabled == false)
            {
                // sửa nhân viên thi insert trực tiếp vào csdl
            }
            else
            {

            }
        }

        private void Update_LienHe()
        {
            if (txtEmployeeCode.Enabled == false)
            {
                // sửa nhân viên thi insert trực tiếp vào csdl
            }
            else
            {

            }
        }

        private void Set_NgayThangMacDinh()
        {
            dateBirthday.DateTime = DateTime.Now;
            dateIDCardDate.DateTime = DateTime.Now;
          dateEndDate.DateTime = DateTime.Now;
            dateBankDate.DateTime = DateTime.Now;
           dateBeginDate.DateTime = DateTime.Now;
          // dateContractFromDate.DateTime = DateTime.Now;
          //  dateContractSignDate.DateTime = DateTime.Now;
         //   dateContractToDate.DateTime = DateTime.Now;
          //  dateDateSalary.DateTime = DateTime.Now;
            dateHealthInsuranceFromDate.DateTime = DateTime.Now;
            dateHealthInsuranceToDate.DateTime = DateTime.Now;
            dateInsuranceDate.DateTime = DateTime.Now;
            dateLaborDate.DateTime = DateTime.Now;
            dateMilitaryFromDate.DateTime = DateTime.Now;
            datePartyDate.DateTime = DateTime.Now;
            datePassportFromDate.DateTime = DateTime.Now;
            datePassportToDate.DateTime = DateTime.Now;
          //  dateTestFromDate.DateTime = DateTime.Now;
           // dateTestToDate.DateTime = DateTime.Now;
            dateUnionDate.DateTime = DateTime.Now;
            dateMilitaryToDate.DateTime = DateTime.Now;
            dateInsuranceDate.DateTime = DateTime.Now;
        }


        private void Clear_txt()
        {
            this.Text = "Thêm nhân viên";
            txtFirstName.Text = "";
            txtDescription.Text = "";
            txtLastName.Text = "";
            txtBirthPlace.Text = "";
            txtAlias.Text = "";
            txtMainAddress.Text = "";
            txtContactAddress.Text = "";
            txtIDCard.Text = "";
            txtIDCardPlace.Text = "";
            txtEnrollNumber.Text = "";
            txtCellPhone.Text = "";
            txtHomePhone.Text = "";
            txtEmail.Text = "";
            txtInsuranceCode.Text = "";
            txtInsurancePlace.Text = "";
            txtHealthInsuranceCode.Text = "";
            txtTaxCode.Text = "";
            txtExperiences.Text = "";
            txtStopWork.Text = "";
            PicPhoto.Image = null;
          //  txtContractCode.Text = "";
          //  txtContractType.Text = "";
        }

        private void btnCallThemLienHe_Click(object sender, EventArgs e)
        {
            if (txtEmployeeCode.Enabled == false)
            {
                frmDanhSachNhanVien_LienHe frm = new frmDanhSachNhanVien_LienHe(true, "Thêm liên hệ", "LH", null, txtEmployeeCode.Text, txtFirstName.Text + " " + txtLastName.Text, "frmCapNhatNhanVien");
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void btnCallSuaLienHe_Click(object sender, EventArgs e)
        {
            if (txtEmployeeCode.Enabled == false)
            {
                int SelectedRow = gridLienHeDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridLienHeDetail.GetDataRow(SelectedRow);
                    string _value = drow["PersonID"].ToString();
                    frmDanhSachNhanVien_LienHe frm = new frmDanhSachNhanVien_LienHe(false, "Cập nhật liên hệ", "LH", _value, txtEmployeeCode.Text, txtFirstName.Text + " " + txtLastName.Text, "frmCapNhatNhanVien");
                    frm.Owner = this;
                    frm.ShowDialog();
                }
            }
        }

        private void btnCallXoaAllLienHe_Click(object sender, EventArgs e)
        {
            if (txtEmployeeCode.Enabled == false)
            {
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.NhanVien_LienHe lh = new Class.NhanVien_LienHe();
                lh.EmployeeCode = txtEmployeeCode.Text;
                if (lh.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    GetList_RelativeByEmployee(txtEmployeeCode.Text);
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }

            }
        }

        private void frmCapNhatNhanVien_Load(object sender, EventArgs e)
        {
          //  this.Focus();         
            this.Activate();
            btnUpdate.Focus();
            txtProvince.EditValue = "TI000004"; // tu load thanh pho HCM
        }

        private void btnCallXoaChonLienHe_Click(object sender, EventArgs e)
        {

            if (txtEmployeeCode.Enabled == false)
            {
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                int SelectedRow = gridLienHeDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridLienHeDetail.GetDataRow(SelectedRow);
                    string _value = drow["PersonID"].ToString();
                    Class.NhanVien_LienHe lh = new Class.NhanVien_LienHe();
                    lh.PersonID = _value;
                    if (lh.DeleteByPersonID())
                    {
                        Class.App.DeleteSuccessfully();
                        GetList_RelativeByEmployee(txtEmployeeCode.Text);
                    }
                    else
                    {
                        Class.App.DeleteNotSuccessfully();
                    }
                }
            }
        }

        private void menuLienHe_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // MessageBox.Show("");
            //' kiem tra neu chua co thong tin gi thi disable sua, xoa, xoa het
            if (gridLienHeDetail.RowCount > 0)
            {
                btnCallSuaLienHe.Enabled = true;
                btnCallXoaChonLienHe.Enabled = true;
                btnCallXoaAllLienHe.Enabled = true;
            }
            else
            {
                btnCallSuaLienHe.Enabled = false;
                btnCallXoaChonLienHe.Enabled = false;
                btnCallXoaAllLienHe.Enabled = false;
            }
        }

        private void frmCapNhatNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        // this.Dispose();
           // (this.Owner as frmDanhSachNhanVien).Activate();
        }

        private void Call_Info_NV()
        {
            frmkt.HRM_PROCESS_REWARD_GetListByEmployee();
            frmkl.HRM_PROCESS_DISCIPLINE_GetListByEmployee();
            frmdtao.HRM_PROCESS_TRAINING_GetListByEmployee();
            frmcv.HRM_PROCESS_POSITION_GetListByEmployee();
        }

        bool _IsHopDong=false;
        bool _IsCreateDeactive = false;
        private void txtStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class.NhanVien_ThoiViec nvtvc = new Class.NhanVien_ThoiViec();
            nvtvc.EmployeeCode = txtEmployeeCode.Text;
            DataTable dtc = nvtvc.HRM_EMPLOYEE_DEACTIVE_GetByEmployeeCode();
            if (dtc.Rows.Count > 0)
            {
                txtStopWorkCode.Text = dtc.Rows[0]["DeActiveCode"].ToString();
            }
            
            // thuc hien tao so quyet dinh thoi viec
            // kiem tra neu chua ky HD thi ko phat sinh Quyet Dinh
            Class.NhanVien_HopDong clsHD = new Class.NhanVien_HopDong();
            clsHD.EmployeeCode = txtEmployeeCode.Text;
            DataTable dtHD = clsHD.HRM_CONTRACT_GetByEmployee();
            if (dtHD.Rows.Count > 0)
            {
                bool hd=false;
                
                for (int i = 0; i < dtHD.Rows.Count; i++)
                {
                    string IDhD = dtHD.Rows[i]["ContractCode"].ToString();
                    if (IDhD.Contains("HDLD"))
                    {
                        hd = true;
                        break;
                    }                
                }

                _IsHopDong = hd;

                if (hd == false)
                {
                    return;
                }
            }
            else
            {
                return;
            }
           
                if (txtStatus.SelectedIndex == 3)
                {
                    Class.NhanVien_ThoiViec nvtv = new Class.NhanVien_ThoiViec();
                    nvtv.EmployeeCode = txtEmployeeCode.Text;
                    DataTable dt = nvtv.HRM_EMPLOYEE_DEACTIVE_GetByEmployeeCode();
                    if (dt.Rows.Count > 0)
                    {
                        txtStopWorkCode.Text = dt.Rows[0]["DeActiveCode"].ToString();
                    }
                    else
                    {
                        if (_IsCreateDeactive)
                        {
                            nvtv.Year = ((DateTime)dateEndDate.EditValue).Year;
                            string ID = "1";

                            DataTable dtByYear = nvtv.HRM_EMPLOYEE_DEACTIVE_GetByYear();
                            if (dtByYear.Rows.Count > 0)
                            {
                                int NextID1 = 0;
                                int NextID2 = 0;
                                string[] catDau = dtByYear.Rows[0]["DeActiveCode"].ToString().Split('-');
                                if (catDau.Length == 3)
                                {
                                    NextID1 =int.Parse(catDau[0].ToString());
                                }

                                ///**** bo nay de bo qua nhung ma da xoa de tiep tuc
                                //for (int i = 0; i < dtByYear.Rows.Count; i++)
                                //{
                                //    string[] cat = dtByYear.Rows[i]["DeActiveCode"].ToString().Split('-');
                                //    if (cat.Length == 3)
                                //    {
                                //        NextID2 = int.Parse(cat[0]);
                                //        if ((NextID2 - NextID1) > 1)
                                //        {
                                //            break;
                                //        }
                                //        NextID1 = NextID2;
                                //    }

                                //}
                                //////////888*** Thay de bang doan code tiep tuc ra ma
                                //========
                                string[] cat = dtByYear.Rows[dtByYear.Rows.Count-1]["DeActiveCode"].ToString().Split('-');
                                if (cat.Length == 3)
                                {
                                    NextID2 = int.Parse(cat[0]);                                   
                                    NextID1 = NextID2;
                                }


                                //=======


                                NextID2++;
                                // ID = NextID2.ToString();
                                if (NextID2.ToString().Length == 1)
                                {
                                    ID = "00" + NextID2.ToString();
                                }
                                if (NextID2.ToString().Length == 2)
                                {
                                    ID = "0" + NextID2.ToString();
                                }

                            }
                            else
                            {
                                ID = "001";
                            }

                            nvtv.DeActiveCode = ID + "-" + nvtv.Year + "/PTH-QĐTV";
                            txtStopWorkCode.Text = nvtv.DeActiveCode;
                        }
                    }
                }
                else
                {
                    txtStopWorkCode.Text = "";
                }
            

            // sau khi load gan _IsCreateDeactive = true; de khoi tao code khi chon vao thay doi
            _IsCreateDeactive = true;
            ////----------
        }

       
    }
}