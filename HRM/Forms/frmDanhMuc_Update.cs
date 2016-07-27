using System;
using System.Data;

namespace HRM.Forms
{
    public partial class frmDanhMuc_Update : DevExpress.XtraEditors.XtraForm
    {
        string _FormName = "";
        public string _reCallFunction;
        public frmDanhMuc_Update()
        {
            InitializeComponent();
        }

        public frmDanhMuc_Update(bool Add_new, string Caption_name, string Form_name, string Code, string reCallFunction)
        {
            InitializeComponent();
            this.Text = Caption_name;
            if (Add_new)
            {
                txtCode.Text = call_Code_New(Form_name); 
            }
            else
            {
                call_info(Form_name, Code);
                txtCode.Enabled = false;
            }
            _FormName = Form_name;
            _reCallFunction = reCallFunction;
        }

        private void call_info(string Form_name, string code)
        {
            switch (Form_name)
            {
                case "CM":
                    Class.DanhMuc_ChuyenMon dmcm = new Class.DanhMuc_ChuyenMon();
                    DataTable dt = dmcm.GetProfessionalByCode(code);
                    txtCode.Text = dt.Rows[0]["ProfessionalCode"].ToString();
                    txtName.Text = dt.Rows[0]["ProfessionalName"].ToString();                    
                      txtDescription.Text = dt.Rows[0]["Description"].ToString();
                     checkActive.Checked = (bool)dt.Rows[0]["Active"];
                    break;
                case "BC":
                    Class.DanhMuc_BangCap dmbc = new Class.DanhMuc_BangCap();
                    DataTable dtbc = dmbc.GetDegreeByCode(code);
                    txtCode.Text = dtbc.Rows[0]["DegreeCode"].ToString();
                    txtName.Text = dtbc.Rows[0]["DegreeName"].ToString();
                    txtDescription.Text = dtbc.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dtbc.Rows[0]["Active"];
                    break;
                case "QT":
                    Class.DanhMuc_QuocTich dmqt = new Class.DanhMuc_QuocTich();
                    DataTable dtqt = dmqt.GetNationalityByCode(code);
                    txtCode.Text = dtqt.Rows[0]["NationalityCode"].ToString();
                    txtName.Text = dtqt.Rows[0]["NationalityName"].ToString();
                    txtDescription.Text = dtqt.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dtqt.Rows[0]["Active"];
                    break;
                case "DT":
                    Class.DanhMuc_DanToc dmdt = new Class.DanhMuc_DanToc();
                    DataTable dtdt = dmdt.GetEthnicByCode(code);
                    txtCode.Text = dtdt.Rows[0]["EthnicCode"].ToString();
                    txtName.Text = dtdt.Rows[0]["EthnicName"].ToString();
                    txtDescription.Text = dtdt.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dtdt.Rows[0]["Active"];
                    break;
                case "TG":
                    Class.DanhMuc_TonGiao dmtg = new Class.DanhMuc_TonGiao();
                    DataTable dttg = dmtg.GetReligionByCode(code);
                    txtCode.Text = dttg.Rows[0]["ReligionCode"].ToString();
                    txtName.Text = dttg.Rows[0]["ReligionName"].ToString();
                    txtDescription.Text = dttg.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dttg.Rows[0]["Active"];
                    break;
                case "QHGD":
                    Class.DanhMuc_QuanHeGiaDinh dmqhgd = new Class.DanhMuc_QuanHeGiaDinh();
                    DataTable dtqhgd = dmqhgd.GetRelativeByCode(code);
                    txtCode.Text = dtqhgd.Rows[0]["RelativeCode"].ToString();
                    txtName.Text = dtqhgd.Rows[0]["RelativeName"].ToString();
                    txtDescription.Text = dtqhgd.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dtqhgd.Rows[0]["Active"];
                    break;
                case "HV":
                    Class.DanhMuc_HocVan dmhv= new Class.DanhMuc_HocVan();
                    DataTable dthv = dmhv.GetEducationByCode(code);
                    txtCode.Text = dthv.Rows[0]["EducationCode"].ToString();
                    txtName.Text = dthv.Rows[0]["EducationName"].ToString();
                    txtDescription.Text = dthv.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dthv.Rows[0]["Active"];
                    break;
                case "TH":
                    Class.DanhMuc_TinHoc dmth = new Class.DanhMuc_TinHoc();
                    DataTable dtth = dmth.GetInformaticByCode(code);
                    txtCode.Text = dtth.Rows[0]["InformaticCode"].ToString();
                    txtName.Text = dtth.Rows[0]["InformaticName"].ToString();
                    txtDescription.Text = dtth.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dtth.Rows[0]["Active"];
                    break;
                case "NN":
                    Class.DanhMuc_NgoaiNgu dmnn = new Class.DanhMuc_NgoaiNgu();
                    DataTable dtnn = dmnn.GetLanguageByCode(code);
                    txtCode.Text = dtnn.Rows[0]["LanguageCode"].ToString();
                    txtName.Text = dtnn.Rows[0]["LanguageName"].ToString();
                    txtDescription.Text = dtnn.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dtnn.Rows[0]["Active"];
                    break;
                case "KN":
                    Class.DanhMuc_KyNang dmkn = new Class.DanhMuc_KyNang();
                    DataTable dtkn = dmkn.GetSkillByCode(code);
                    txtCode.Text = dtkn.Rows[0]["SkillCode"].ToString();
                    txtName.Text = dtkn.Rows[0]["SkillName"].ToString();
                    txtDescription.Text = dtkn.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dtkn.Rows[0]["Active"];
                    break;
                case "TT":
                    Class.DanhMuc_Tinh dmtt = new Class.DanhMuc_Tinh();
                    DataTable dttt = dmtt.GetProvinceByCode(code);
                    txtCode.Text = dttt.Rows[0]["ProvinceCode"].ToString();
                    txtName.Text = dttt.Rows[0]["ProvinceName"].ToString();
                    txtDescription.Text = dttt.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dttt.Rows[0]["Active"];
                    break;
                case "TrH":
                    Class.DanhMuc_TruongHoc dmtrh = new Class.DanhMuc_TruongHoc();
                    DataTable dttrh = dmtrh.GetSchoolByCode(code);
                    txtCode.Text = dttrh.Rows[0]["SchoolCode"].ToString();
                    txtName.Text = dttrh.Rows[0]["SchoolName"].ToString();
                    txtDescription.Text = dttrh.Rows[0]["Description"].ToString();
                    checkActive.Checked = (bool)dttrh.Rows[0]["Active"];
                    break;          
            }
        }
        private string call_Code_New(string Form_name)
        {
            string code = "";
            switch (Form_name)
            {
                case "CM":
                    Class.DanhMuc_ChuyenMon dmcm = new Class.DanhMuc_ChuyenMon();
                    code= dmcm.GetNewCode();
                    break;
                case "BC":
                    Class.DanhMuc_BangCap dmbc = new Class.DanhMuc_BangCap();
                    code = dmbc.GetNewCode();
                    break;
                case "QT":
                    Class.DanhMuc_QuocTich dmqt = new Class.DanhMuc_QuocTich();
                    code = dmqt.GetNewCode();
                    break;
                case "DT":
                    Class.DanhMuc_DanToc dmdt = new Class.DanhMuc_DanToc();
                    code = dmdt.GetNewCode();
                    break;
                case "TG":
                    Class.DanhMuc_TonGiao dmtg = new Class.DanhMuc_TonGiao();
                    code = dmtg.GetNewCode();
                    break;
                case "QHGD":
                    Class.DanhMuc_QuanHeGiaDinh dmghgd = new Class.DanhMuc_QuanHeGiaDinh();
                    code = dmghgd.GetNewCode();
                    break;
                case "HV":
                    Class.DanhMuc_HocVan dmhv = new Class.DanhMuc_HocVan();
                    code = dmhv.GetNewCode();
                    break;
                case "TH":
                    Class.DanhMuc_TinHoc dmth = new Class.DanhMuc_TinHoc();
                    code = dmth.GetNewCode();
                    break;
                case "NN":
                    Class.DanhMuc_NgoaiNgu dmnn = new Class.DanhMuc_NgoaiNgu();
                    code = dmnn.GetNewCode();
                    break;
                case "KN":
                    Class.DanhMuc_KyNang dmkn = new Class.DanhMuc_KyNang();
                    code = dmkn.GetNewCode();
                    break;
                case "TT":
                    Class.DanhMuc_Tinh dmtt = new Class.DanhMuc_Tinh();
                    code = dmtt.GetNewCode();
                    break;
                case "TrH":
                    Class.DanhMuc_TruongHoc dmtrh = new Class.DanhMuc_TruongHoc();
                    code = dmtrh.GetNewCode();
                    break;
            }
            return code;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            switch (_FormName)
            {
                case "CM":
                    Update_ChuyenMon();                   
                    break;
                case "BC":
                    Update_BangCap();
                    break;
                case "QT":
                    Update_QuocTich();
                    break;
                case "DT":
                    Update_DanToc();
                    break;
                case "TG":
                    Update_TonGiao();
                    break;
                case "QHGD":
                    Update_QuanHeGiaDinh();
                    break;
                case "HV":
                    Update_HocVan();
                    break;
                case "TH":
                    Update_TinHoc();
                    break;
                case "NN":
                    Update_NgoaiNgu();
                    break;
                case "KN":
                    Update_KyNang();
                    break;
                case "TT":
                    Update_Tinh();
                    break;
                case "TrH":
                    Update_TruongHoc();
                    break;
            }
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1 || txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            switch (_FormName)
            {
                case "CM":
                    Update_ChuyenMon();
                    this.Text = "Thêm chuyên môn";
                    break;
                case "BC":
                    Update_BangCap();
                    this.Text = "Thêm Bằng cấp";
                    break;
                case "QT":
                    Update_QuocTich();
                    this.Text = "Thêm Quốc tịch";
                    break;
                case "DT":
                    Update_DanToc();
                    this.Text = "Thêm Dân tộc";
                    break;
                case "TG":
                    Update_TonGiao();
                    this.Text = "Thêm Tôn Giáo";
                    break;
                case "QHGD":
                    Update_QuanHeGiaDinh();
                    this.Text = "Thêm Quan hệ gia đình";
                    break;
                case "HV":
                    Update_HocVan();
                    this.Text = "Thêm Học vấn";
                    break;
                case "TH":
                    Update_TinHoc();
                    this.Text = "Thêm Bằng tin học";
                    break;
                case "NN":
                    Update_NgoaiNgu();
                    this.Text = "Thêm Bằng ngoại ngữ";
                    break;
                case "KN":
                    Update_KyNang();
                    this.Text = "Thêm Kỹ năng";
                    break;
                case "TT":
                    Update_Tinh();
                    this.Text = "Thêm Tỉnh";
                    break;
                case "TrH":
                    Update_TruongHoc();
                    this.Text = "Thêm Trường học";
                    break;
            }
            txtCode.Enabled = true;
            txtCode.Text = call_Code_New(_FormName);
            txtName.Text = "";
            txtDescription.Text = "";
        }

        #region Call function to data Update_insert
        private void Update_ChuyenMon()
        {
            Class.DanhMuc_ChuyenMon dmcm = new Class.DanhMuc_ChuyenMon();
            dmcm.ProfessionalCode = txtCode.Text;
            dmcm.ProfessionalName = txtName.Text;
            dmcm.Description = txtDescription.Text;
            dmcm.Active = checkActive.Checked;
            if (txtCode.Enabled == true)
            {
                if (dmcm.Insert())
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
                if (dmcm.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            if (_reCallFunction == "frmDanhMucChuyenMon")            
                (this.Owner as frmDanhMucChuyenMon).GetAllList_PROFESSIONAL();
            
        }
        
        private void Update_BangCap()
        {
            Class.DanhMuc_BangCap dm = new Class.DanhMuc_BangCap();
            dm.DegreeCode = txtCode.Text;
            dm.DegreeName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucBangCap")            
                (this.Owner as frmDanhMucBangCap).GetAllList_DEGREE();
            
        }

        private void Update_QuocTich()
        {
            Class.DanhMuc_QuocTich dm = new Class.DanhMuc_QuocTich();
            dm.NationalityCode = txtCode.Text;
            dm.NationalityName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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

            if (_reCallFunction == "frmDanhMucQuocTich")
            (this.Owner as frmDanhMucQuocTich).GetAllList_NATIONALITY();
        }

        private void Update_DanToc()
        {
            Class.DanhMuc_DanToc dm = new Class.DanhMuc_DanToc();
            dm.EthnicCode = txtCode.Text;
            dm.EthnicName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucDanToc")   
            (this.Owner as frmDanhMucDanToc).GetAllList_ETHNIC();
        }

        private void Update_TonGiao()
        {
            Class.DanhMuc_TonGiao dm = new Class.DanhMuc_TonGiao();
            dm.ReligionCode = txtCode.Text;
            dm.ReligionName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucTonGiao")   
                 (this.Owner as frmDanhMucTonGiao).GetAllList_RELIGION();
        }

        private void Update_QuanHeGiaDinh()
        {
            Class.DanhMuc_QuanHeGiaDinh dm = new Class.DanhMuc_QuanHeGiaDinh();
            dm.RelativeCode = txtCode.Text;
            dm.RelativeName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucQuanHeGiaDinh")   
                  (this.Owner as frmDanhMucQuanHeGiaDinh).GetAllList_RELATIVE();
        }

        private void Update_HocVan()
        {
            Class.DanhMuc_HocVan dm = new Class.DanhMuc_HocVan();
            dm.EducationCode = txtCode.Text;
            dm.EducationName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucHocVan")   
                 (this.Owner as frmDanhMucHocVan).GetAllList_EDUCATION();
        }

        private void Update_TinHoc()
        {
            Class.DanhMuc_TinHoc dm = new Class.DanhMuc_TinHoc();
            dm.InformaticCode = txtCode.Text;
            dm.InformaticName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucTinHoc")   
                  (this.Owner as frmDanhMucTinHoc).GetAllList_INFORMATIC();
        }

        private void Update_NgoaiNgu()
        {
            Class.DanhMuc_NgoaiNgu dm = new Class.DanhMuc_NgoaiNgu();
            dm.LanguageCode= txtCode.Text;
            dm.LanguageName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucNgoaiNgu")   
                  (this.Owner as frmDanhMucNgoaiNgu).GetAllList_LANGUAGE();
        }

        private void Update_KyNang()
        {
            Class.DanhMuc_KyNang dm = new Class.DanhMuc_KyNang();
            dm.SkillCode = txtCode.Text;
            dm.SkillName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucKyNang")   
                 (this.Owner as frmDanhMucKyNang).GetAllList_SKILL();
        }

        private void Update_Tinh()
        {
            Class.DanhMuc_Tinh dm = new Class.DanhMuc_Tinh();
            dm.ProvinceCode = txtCode.Text;
            dm.ProvinceName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucTinh")
                (this.Owner as frmDanhMucTinh).GetAllList_PROVINCE();
        }

        private void Update_TruongHoc()
        {
            Class.DanhMuc_TruongHoc dm = new Class.DanhMuc_TruongHoc();
            dm.SchoolCode = txtCode.Text;
            dm.SchoolName = txtName.Text;
            dm.Description = txtDescription.Text;
            dm.Active = checkActive.Checked;
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
            if (_reCallFunction == "frmDanhMucTruongHoc")
                (this.Owner as frmDanhMucTruongHoc).GetAllList_SCHOOL();
        }
        #endregion
       
    }
}