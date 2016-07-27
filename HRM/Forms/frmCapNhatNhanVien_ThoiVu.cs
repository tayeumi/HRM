using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace HRM.Forms
{
    public partial class frmCapNhatNhanVien_ThoiVu : DevExpress.XtraEditors.XtraForm
    {
        public frmCapNhatNhanVien_ThoiVu()
        {
            InitializeComponent();
        }
        public frmCapNhatNhanVien_ThoiVu(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
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
            GetList_Branch(); /// danh sach chi nhanh
            GetList_Position();                  /// 

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
            }
        }

        private void frmCapNhatNhanVien_ThoiVu_Load(object sender, EventArgs e)
        {

        }

        private string call_Code_New()
        {
            string code = "";
            Class.NhanVien_ThoiVu nv = new Class.NhanVien_ThoiVu();
            code = nv.GetNewCode();
            return code;
        }

        public void GetList_Branch()
        {
            Class.DanhSach_ChiNhanh dm = new Class.DanhSach_ChiNhanh();
            DataTable dt = dm.GetAllList_BRANCH();
            txtBranchCode.Properties.DataSource = dt;
            txtBranchCode.Properties.DisplayMember = "BranchName";
            txtBranchCode.Properties.ValueMember = "BranchCode";
        }
        public void GetList_Nationality()
        {
            Class.DanhMuc_QuocTich dm = new Class.DanhMuc_QuocTich();
            DataTable dt = dm.GetAllList_NATIONALITY();
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

        private void Set_NgayThangMacDinh()
        {
            dateBirthday.DateTime = DateTime.Now;
            dateIDCardDate.DateTime = DateTime.Now;
            dateEndDate.DateTime = DateTime.Now;
            dateBankDate.DateTime = DateTime.Now;
            dateBeginDate.DateTime = DateTime.Now;
        }

        private void txtBranchCode_EditValueChanged(object sender, EventArgs e)
        {
            GetList_DepartmentByBranch(txtBranchCode.EditValue.ToString());
        }

        public void GetList_DepartmentByBranch(string strcode)
        {
            Class.PhongBan dm = new Class.PhongBan();
            dm.BranchCode = strcode;
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
            txtGroupCode.Properties.DataSource = dt;
            txtGroupCode.Properties.DisplayMember = "GroupName";
            txtGroupCode.Properties.ValueMember = "GroupCode";
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

        private void txtDepartmentCode_EditValueChanged(object sender, EventArgs e)
        {
            GetList_GroupByDepartment(txtDepartmentCode.EditValue.ToString());
        }

        private void txtGroupCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Del")
            {
                txtGroupCode.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
            Class.NhanVien_ThoiVu nv = new Class.NhanVien_ThoiVu();
            nv.EnrollNumber = txtEnrollNumber.Text;
            if (txtEnrollNumber.Text.Length != 0)
            {
                DataTable dtcheckEnroll = nv.HRM_EMPLOYEE_SEASON_GetByEnroll();
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
                DataTable dTCheckID = nv.HRM_EMPLOYEE_SEASON_CheckIDCard();
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

        private void Update_NhanVien()
        {
            Class.NhanVien_ThoiVu nv = new Class.NhanVien_ThoiVu();

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
            nv.EnrollNumber = txtEnrollNumber.Text;
            nv.Description = txtDescription.Text;
            nv.Status = (int)txtStatus.SelectedIndex;
            #endregion
            #region Tab_ThongTinCongViec
            nv.BranchCode = txtBranchCode.EditValue.ToString(); 
            nv.DepartmentCode = txtDepartmentCode.EditValue.ToString();
            nv.GroupCode = txtGroupCode.EditValue.ToString();
            nv.Position = txtPosition.Text;
            nv.TaxCode = txtTaxCode.Text;
            nv.BeginDate = dateBeginDate.DateTime;
            nv.EndDate = dateEndDate.DateTime;
            nv.Experiences = txtExperiences.Text;
            #endregion

            #region Update_TabThongTinXaHoi
            nv.BankCode = txtBankCode.Text;
            nv.BankDate = dateBankDate.DateTime;
            nv.BankName = txtBankName.Text;
            nv.BankAddress = txtBankAddress.Text;
            #endregion

            this.Activate();

            if (txtEmployeeCode.Enabled == true)
            {
                if (nv.Insert())
                {
                    Waiting.SetWaitFormDescription("Đang tải danh sách nhân viên..");
                    (this.Owner as frmDanhSachNhanVien_ThoiVu).HRM_EMPLOYEE_SEASON_GetList();
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
                if (nv.Update())
                {
                    Waiting.SetWaitFormDescription("Đang tải danh sách nhân viên..");
                    (this.Owner as frmDanhSachNhanVien_ThoiVu).HRM_EMPLOYEE_SEASON_GetList();
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
            Class.NhanVien_ThoiVu nv = new Class.NhanVien_ThoiVu();
            nv.EnrollNumber = txtEnrollNumber.Text;
            if (txtEnrollNumber.Text.Length != 0)
            {
                DataTable dtcheckEnroll = nv.HRM_EMPLOYEE_SEASON_GetByEnroll();
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
                DataTable dTCheckID = nv.HRM_EMPLOYEE_SEASON_CheckIDCard();
                if (dTCheckID.Rows.Count > 0)
                {
                    if (MessageBox.Show("Thông Tin CMND trùng lặp, Bạn có muốn tiếp tục không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                }
            }
            Update_NhanVien();

            txtEmployeeCode.Enabled = true;
            txtEmployeeCode.Text = call_Code_New();
            Clear_txt();
            Set_NgayThangMacDinh();
            TabControl.SelectedTabPage = TabInfo;
            txtFirstName.Focus();
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
            txtTaxCode.Text = "";
            txtExperiences.Text = "";
            PicPhoto.Image = null;            
        }


        private void call_info(string Form_name, string code)
        {
            Class.NhanVien_ThoiVu nv = new Class.NhanVien_ThoiVu();
            nv.EmployeeCode = code;
            DataTable dt = nv.HRM_EMPLOYEE_SEASON_Get();
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
                if (dt.Rows[0]["Birthday"] != DBNull.Value)
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
                txtSchool.Text = dt.Rows[0]["School"].ToString();
                txtIDCard.Text = dt.Rows[0]["IDCard"].ToString();
                if (dt.Rows[0]["IDCardDate"] != DBNull.Value)
                    dateIDCardDate.DateTime = (DateTime)dt.Rows[0]["IDCardDate"];
                txtIDCardPlace.Text = dt.Rows[0]["IDCardPlace"].ToString();
                txtEnrollNumber.Text = dt.Rows[0]["EnrollNumber"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
               
                #endregion

                #region Tab_ThongtinCongViec
                txtBranchCode.EditValue = dt.Rows[0]["BranchCode"].ToString();
                txtDepartmentCode.EditValue = dt.Rows[0]["DepartmentCode"].ToString();
                txtGroupCode.EditValue = dt.Rows[0]["GroupCode"].ToString();
                txtPosition.Text = dt.Rows[0]["Position"].ToString();
                txtTaxCode.Text = dt.Rows[0]["TaxCode"].ToString();
                if (dt.Rows[0]["BeginDate"] != DBNull.Value)
                    dateBeginDate.DateTime = (DateTime)dt.Rows[0]["BeginDate"];
                if (dt.Rows[0]["EndDate"] != DBNull.Value)
                    dateEndDate.DateTime = (DateTime)dt.Rows[0]["EndDate"];

                txtExperiences.Text = dt.Rows[0]["Experiences"].ToString();
                #endregion

                txtStatus.SelectedIndex = (int)dt.Rows[0]["Status"];  // chuyen duoi de  doc thong tin nghi viec cho dung


                #region Tab_ThongTinXaHoi

                txtBankCode.Text = dt.Rows[0]["BankCode"].ToString();
                if (dt.Rows[0]["BankDate"] != DBNull.Value)
                    dateBankDate.DateTime = (DateTime)dt.Rows[0]["BankDate"];
                txtBankName.Text = dt.Rows[0]["BankName"].ToString();
                txtBankAddress.Text = dt.Rows[0]["BankAddress"].ToString();

                #endregion
                
            }
            catch { }
        }

    
    }
}