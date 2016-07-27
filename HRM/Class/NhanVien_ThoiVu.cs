using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRM.Class
{
    class NhanVien_ThoiVu
    {
        public string EmployeeCode { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName { get; set; }
        public string GroupName { get; set; }

        public string BranchCode { get; set; }
        public string DepartmentCode { get; set; }
        public string GroupCode { get; set; }

        public string EnrollNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public bool Sex { get; set; }
        public string Marriage { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string MainAddress { get; set; }
        public string ContactAddress { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string Nationality { get; set; }
        public string Ethnic { get; set; }
        public string Religion { get; set; }
        public string Education { get; set; }
        public string Language { get; set; }
        public string Informatic { get; set; }
        public string Professional { get; set; }
        public string Position { get; set; }
        public string School { get; set; }
        public string IDCard { get; set; }
        public DateTime IDCardDate { get; set; }
        public string IDCardPlace { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BankCode { get; set; }
        public DateTime BankDate { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }    
        public string TaxCode { get; set; }
        public string Experiences { get; set; }
       
        public int Status { get; set; }
        public string Description { get; set; }

        public string GetNewCode()
        {
            string procname = "HRM_EMPLOYEE_SEASON_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();            
            DataTable dt = db.ExecuteDataTable(procname);
            if (dt.Rows.Count > 0)
            {
                string _strCode = dt.Rows[dt.Rows.Count - 1][0].ToString();
                _strCode = _strCode.Substring(2, _strCode.Length - 2);
                int next_id = int.Parse(_strCode) + 1;
                switch (next_id.ToString().Length)
                {
                    case 1:
                        return "TV00" + next_id.ToString();
                    case 2:
                        return "TV0" + next_id.ToString();
                    case 3:
                        return "TV" + next_id.ToString();
                   
                }
            }
            return "TV001";

        }

        public DataTable HRM_EMPLOYEE_SEASON_GetList()
        {
            string procname = "HRM_EMPLOYEE_SEASON_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();          
            return db.ExecuteDataTable(procname);
        }

        public DataTable HRM_EMPLOYEE_SEASON_GetByEnroll()
        {
            string procname = "HRM_EMPLOYEE_SEASON_GetByEnroll";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@EnrollNumber", EnrollNumber);
            return db.ExecuteDataTable(procname);
        }
        public DataTable HRM_EMPLOYEE_SEASON_Get()
        {
            string procname = "HRM_EMPLOYEE_SEASON_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@EmployeeCode", EmployeeCode);
            return db.ExecuteDataTable(procname);
        }
        public DataTable HRM_EMPLOYEE_SEASON_CheckIDCard()
        {
            string procname = "HRM_EMPLOYEE_SEASON_CheckIDCard";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@IDCard", IDCard);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@BranchCode", BranchCode);
                db.AddParameter("@DepartmentCode", DepartmentCode);
                db.AddParameter("@GroupCode", GroupCode);
                db.AddParameter("@EnrollNumber", EnrollNumber);
                db.AddParameter("@FirstName", FirstName);
                db.AddParameter("@LastName", LastName);
                db.AddParameter("@Alias", Alias);
                db.AddParameter("@Sex", Sex);
                db.AddParameter("@Marriage", Marriage);
                db.AddParameter("@Birthday", Birthday);
                db.AddParameter("@BirthPlace", BirthPlace);
                db.AddParameter("@MainAddress", MainAddress);
                db.AddParameter("@ContactAddress", ContactAddress);
                db.AddParameter("@CellPhone", CellPhone);
                db.AddParameter("@HomePhone", HomePhone);
                db.AddParameter("@Email", Email);
                if (Photo == null)
                {                                       
                    db.AddParameter("@Photo", DBNull.Value,"");
                }
                else
                {
                    db.AddParameter("@Photo", Photo);
                }
                db.AddParameter("@Nationality", Nationality);
                db.AddParameter("@Ethnic", Ethnic);
                db.AddParameter("@Religion", Religion);
                db.AddParameter("@Education", Education);
                db.AddParameter("@Language", Language);
                db.AddParameter("@Informatic", Informatic);
                db.AddParameter("@Professional", Professional);
                db.AddParameter("@Position", Position);
                db.AddParameter("@School", School);
                db.AddParameter("@IDCard", IDCard);
                db.AddParameter("@IDCardDate", IDCardDate);
                db.AddParameter("@IDCardPlace", IDCardPlace);
                db.AddParameter("@BeginDate", BeginDate);
                if (Status == 3) // xu ly tinh trang neu nhan vien da nghi thi moi co ngay ket thuc. con ko nguoc lai
                {
                    db.AddParameter("@EndDate", EndDate);
                }
                else
                {
                    db.AddParameter("@EndDate", DBNull.Value);
                }
                db.AddParameter("@TaxCode", TaxCode);
                db.AddParameter("@BankCode", BankCode);
                db.AddParameter("@BankDate", BankDate);
                db.AddParameter("@BankName", BankName);
                db.AddParameter("@BankAddress", BankAddress);

                db.AddParameter("@Experiences", Experiences);
                db.AddParameter("@Status", Status);
                db.AddParameter("@Description", Description);

                db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_SEASON_Insert");                                                     
               
                db.CommitTransaction();
                Class.S_Log.Insert("Nhân viên", "Thêm Nhân viên thời vụ: " + FirstName + " " + LastName);
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public bool Update()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@BranchCode", BranchCode);
                db.AddParameter("@DepartmentCode", DepartmentCode);
                db.AddParameter("@GroupCode", GroupCode);
                db.AddParameter("@EnrollNumber", EnrollNumber);
                db.AddParameter("@FirstName", FirstName);
                db.AddParameter("@LastName", LastName);
                db.AddParameter("@Alias", Alias);
                db.AddParameter("@Sex", Sex);
                db.AddParameter("@Marriage", Marriage);
                db.AddParameter("@Birthday", Birthday);
                db.AddParameter("@BirthPlace", BirthPlace);
                db.AddParameter("@MainAddress", MainAddress);
                db.AddParameter("@ContactAddress", ContactAddress);
                db.AddParameter("@CellPhone", CellPhone);
                db.AddParameter("@HomePhone", HomePhone);
                db.AddParameter("@Email", Email);
                if (Photo == null)
                {
                    db.AddParameter("@Photo", DBNull.Value, "");
                }
                else
                {
                    db.AddParameter("@Photo", Photo);
                }
                db.AddParameter("@Nationality", Nationality);
                db.AddParameter("@Ethnic", Ethnic);
                db.AddParameter("@Religion", Religion);
                db.AddParameter("@Education", Education);
                db.AddParameter("@Language", Language);
                db.AddParameter("@Informatic", Informatic);
                db.AddParameter("@Professional", Professional);
                db.AddParameter("@Position", Position);
                db.AddParameter("@School", School);
                db.AddParameter("@IDCard", IDCard);
                db.AddParameter("@IDCardDate", IDCardDate);
                db.AddParameter("@IDCardPlace", IDCardPlace);
                db.AddParameter("@BeginDate", BeginDate);
                if (Status == 3) // xu ly tinh trang neu nhan vien da nghi thi moi co ngay ket thuc. con ko nguoc lai
                {
                    db.AddParameter("@EndDate", EndDate);
                }
                else
                {
                    db.AddParameter("@EndDate", DBNull.Value);
                }
                db.AddParameter("@TaxCode", TaxCode);
                db.AddParameter("@BankCode", BankCode);
                db.AddParameter("@BankDate", BankDate);
                db.AddParameter("@BankName", BankName);
                db.AddParameter("@BankAddress", BankAddress);      
               
                db.AddParameter("@Experiences", Experiences);
                db.AddParameter("@Status", Status);
                db.AddParameter("@Description", Description);

                db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_SEASON_Update");

                db.CommitTransaction();
                Class.S_Log.Insert("Nhân viên", "Cập nhật Nhân viên thời vụ: " + FirstName + " " + LastName);
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public bool Delete()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_SEASON_Delete");               
                db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Xóa Nhân viên thời vụ: " + EmployeeCode );
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }
    }
}
