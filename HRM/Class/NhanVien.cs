using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace HRM.Class
{
   public class NhanVien
   {
       #region Khaibao_Bien
       private string _EmployeeCode;

       public string EmployeeCode
       {
           get { return _EmployeeCode; }
           set { _EmployeeCode = value; }
       }
       private string _DegreeCode;

       public string DegreeCode
       {
           get { return _DegreeCode; }
           set { _DegreeCode = value; }
       }

       private string _BranchCode;

       public string BranchCode
       {
           get { return _BranchCode; }
           set { _BranchCode = value; }
       }

       private string _DepartmentCode;
       public string DepartmentCode
       {
           get { return _DepartmentCode; }
           set { _DepartmentCode = value; }
       }

       private int _Status;

       public int Status
       {
           get { return _Status; }
           set { _Status = value; }
       }

       private DateTime _DayFirstMonth;

       public DateTime DayFirstMonth
       {
           get { return _DayFirstMonth; }
           set { _DayFirstMonth = value; }
       }

       private DateTime _DayEndMonth;

       public DateTime DayEndMonth
       {
           get { return _DayEndMonth; }
           set { _DayEndMonth = value; }
       }

       private string _GroupCode;

       public string GroupCode
       {
           get { return _GroupCode; }
           set { _GroupCode = value; }
       }

       private string _CandidateCode;

       public string CandidateCode
       {
           get { return _CandidateCode; }
           set { _CandidateCode = value; }
       }
       private string _EnrollNumber;

       public string EnrollNumber
       {
           get { return _EnrollNumber; }
           set { _EnrollNumber = value; }
       }
       public string EnrollNumber_New { get; set; }
             
       private string _FirstName;

       public string FirstName
       {
           get { return _FirstName; }
           set { _FirstName = value; }
       }
       private string _LastName;

       public string LastName
       {
           get { return _LastName; }
           set { _LastName = value; }
       }
       private string _Alias;

       public string Alias
       {
           get { return _Alias; }
           set { _Alias = value; }
       }
       private bool _Sex;

       public bool Sex
       {
           get { return _Sex; }
           set { _Sex = value; }
       }
       private string _Marriage;

       public string Marriage
       {
           get { return _Marriage; }
           set { _Marriage = value; }
       }
       private DateTime _Birthday;

       public DateTime Birthday
       {
           get { return _Birthday; }
           set { _Birthday = value; }
       }
       private string _BirthPlace;

       public string BirthPlace
       {
           get { return _BirthPlace; }
           set { _BirthPlace = value; }
       }
       private string _MainAddress;

       public string MainAddress
       {
           get { return _MainAddress; }
           set { _MainAddress = value; }
       }
       private string _ContactAddress;

       public string ContactAddress
       {
           get { return _ContactAddress; }
           set { _ContactAddress = value; }
       }
       private string _CellPhone;

       public string CellPhone
       {
           get { return _CellPhone; }
           set { _CellPhone = value; }
       }
       private string _HomePhone;

       public string HomePhone
       {
           get { return _HomePhone; }
           set { _HomePhone = value; }
       }
       private string _Email;

       public string Email
       {
           get { return _Email; }
           set { _Email = value; }
       }
       private byte[] _Photo;

       public byte[] Photo
       {
           get { return _Photo; }
           set { _Photo = value; }
       }

       private string _Nationality;

       public string Nationality
       {
           get { return _Nationality; }
           set { _Nationality = value; }
       }
       private string _Ethnic;

       public string Ethnic
       {
           get { return _Ethnic; }
           set { _Ethnic = value; }
       }
       private string _Religion;

       public string Religion
       {
           get { return _Religion; }
           set { _Religion = value; }
       }
       private string _Education;

       public string Education
       {
           get { return _Education; }
           set { _Education = value; }
       }
       private string _Language;

       public string Language
       {
           get { return _Language; }
           set { _Language = value; }
       }
       private string _Informatic;

       public string Informatic
       {
           get { return _Informatic; }
           set { _Informatic = value; }
       }
       private string _Professional;

       public string Professional
       {
           get { return _Professional; }
           set { _Professional = value; }
       }
       private string _Position;

       public string Position
       {
           get { return _Position; }
           set { _Position = value; }
       }
       private string _School;

       public string School
       {
           get { return _School; }
           set { _School = value; }
       }
       private string _IDCard;

       public string IDCard
       {
           get { return _IDCard; }
           set { _IDCard = value; }
       }
       private DateTime _IDCardDate;

       public DateTime IDCardDate
       {
           get { return _IDCardDate; }
           set { _IDCardDate = value; }
       }
       private string _IDCardPlace;

       public string IDCardPlace
       {
           get { return _IDCardPlace; }
           set { _IDCardPlace = value; }
       }
       private bool _IsTest;

       public bool IsTest
       {
           get { return _IsTest; }
           set { _IsTest = value; }
       }
       private string _TestTime;

       public string TestTime
       {
           get { return _TestTime; }
           set { _TestTime = value; }
       }
       private DateTime _TestFromDate;

       public DateTime TestFromDate
       {
           get { return _TestFromDate; }
           set { _TestFromDate = value; }
       }
       private DateTime _TestToDate;

       public DateTime TestToDate
       {
           get { return _TestToDate; }
           set { _TestToDate = value; }
       }
       private decimal _TestSalary;

       public decimal TestSalary
       {
           get { return _TestSalary; }
           set { _TestSalary = value; }
       }
       private DateTime _BeginDate;

       public DateTime BeginDate
       {
           get { return _BeginDate; }
           set { _BeginDate = value; }
       }
       private bool _IsOffWork;

       public bool IsOffWork
       {
           get { return _IsOffWork; }
           set { _IsOffWork = value; }
       }
       private DateTime _EndDate;

       public DateTime EndDate
       {
           get { return _EndDate; }
           set { _EndDate = value; }
       }
       private string _Health;

       public string Health
       {
           get { return _Health; }
           set { _Health = value; }
       }
       private float _Height;

       public float Height
       {
           get { return _Height; }
           set { _Height = value; }
       }
       private float _Weight;

       public float Weight
       {
           get { return _Weight; }
           set { _Weight = value; }
       }
       private int _PayForm;

       public int PayForm
       {
           get { return _PayForm; }
           set { _PayForm = value; }
       }
       private decimal _PayMoney;

       public decimal PayMoney
       {
           get { return _PayMoney; }
           set { _PayMoney = value; }
       }
      
       private string _RankSalary;

       public string RankSalary
       {
           get { return _RankSalary; }
           set { _RankSalary = value; }
       }
       private int _StepSalary;

       public int StepSalary
       {
           get { return _StepSalary; }
           set { _StepSalary = value; }
       }
       private float _CoefficientSalary;

       public float CoefficientSalary
       {
           get { return _CoefficientSalary; }
           set { _CoefficientSalary = value; }
       }
       private DateTime _DateSalary;

       public DateTime DateSalary
       {
           get { return _DateSalary; }
           set { _DateSalary = value; }
       }
      
       private decimal _InsuranceSalary;

       public decimal InsuranceSalary
       {
           get { return _InsuranceSalary; }
           set { _InsuranceSalary = value; }
       }
       private decimal _Allowance1;

       public decimal Allowance1
       {
           get { return _Allowance1; }
           set { _Allowance1 = value; }
       }
       private decimal _Allowance2;

       public decimal Allowance2
       {
           get { return _Allowance2; }
           set { _Allowance2 = value; }
       }
       private decimal _Allowance3;

       public decimal Allowance3
       {
           get { return _Allowance3; }
           set { _Allowance3 = value; }
       }
       private decimal _Allowance4;

       public decimal Allowance4
       {
           get { return _Allowance4; }
           set { _Allowance4 = value; }
       }
       private bool _IsSocialInsurance;

       public bool IsSocialInsurance
       {
           get { return _IsSocialInsurance; }
           set { _IsSocialInsurance = value; }
       }
       private bool _IsHealthInsurance;

       public bool IsHealthInsurance
       {
           get { return _IsHealthInsurance; }
           set { _IsHealthInsurance = value; }
       }
       private bool _IsUnemploymentInsurance;

       public bool IsUnemploymentInsurance
       {
           get { return _IsUnemploymentInsurance; }
           set { _IsUnemploymentInsurance = value; }
       }
       private bool _IsUnionMoney;

       public bool IsUnionMoney
       {
           get { return _IsUnionMoney; }
           set { _IsUnionMoney = value; }
       }
       private string _BankCode;

       public string BankCode
       {
           get { return _BankCode; }
           set { _BankCode = value; }
       }
       private DateTime _BankDate;

       public DateTime BankDate
       {
           get { return _BankDate; }
           set { _BankDate = value; }
       }
       private string _BankName;

       public string BankName
       {
           get { return _BankName; }
           set { _BankName = value; }
       }
       private string _BankAddress;

       public string BankAddress
       {
           get { return _BankAddress; }
           set { _BankAddress = value; }
       }
       private string _LaborCode;

       public string LaborCode
       {
           get { return _LaborCode; }
           set { _LaborCode = value; }
       }
       private DateTime _LaborDate;

       public DateTime LaborDate
       {
           get { return _LaborDate; }
           set { _LaborDate = value; }
       }
       private string _LaborPlace;

       public string LaborPlace
       {
           get { return _LaborPlace; }
           set { _LaborPlace = value; }
       }
       private bool _IsUnion;

       public bool IsUnion
       {
           get { return _IsUnion; }
           set { _IsUnion = value; }
       }
       private string _UnionCode;

       public string UnionCode
       {
           get { return _UnionCode; }
           set { _UnionCode = value; }
       }
       private DateTime _UnionDate;

       public DateTime UnionDate
       {
           get { return _UnionDate; }
           set { _UnionDate = value; }
       }
       private string _UnionPlace;

       public string UnionPlace
       {
           get { return _UnionPlace; }
           set { _UnionPlace = value; }
       }
       private bool _IsParty;

       public bool IsParty
       {
           get { return _IsParty; }
           set { _IsParty = value; }
       }
       private string _PartyCode;

       public string PartyCode
       {
           get { return _PartyCode; }
           set { _PartyCode = value; }
       }
       private DateTime _PartyDate;

       public DateTime PartyDate
       {
           get { return _PartyDate; }
           set { _PartyDate = value; }
       }
       private string _PartyPlace;

       public string PartyPlace
       {
           get { return _PartyPlace; }
           set { _PartyPlace = value; }
       }
       private string _InsuranceCode;

       public string InsuranceCode
       {
           get { return _InsuranceCode; }
           set { _InsuranceCode = value; }
       }
       private DateTime _InsuranceDate;

       public DateTime InsuranceDate
       {
           get { return _InsuranceDate; }
           set { _InsuranceDate = value; }
       }
       private string _InsurancePlace;

       public string InsurancePlace
       {
           get { return _InsurancePlace; }
           set { _InsurancePlace = value; }
       }
       private string _HealthInsuranceCode;

       public string HealthInsuranceCode
       {
           get { return _HealthInsuranceCode; }
           set { _HealthInsuranceCode = value; }
       }
       private DateTime _HealthInsuranceFromDate;

       public DateTime HealthInsuranceFromDate
       {
           get { return _HealthInsuranceFromDate; }
           set { _HealthInsuranceFromDate = value; }
       }
       private DateTime _HealthInsuranceToDate;

       public DateTime HealthInsuranceToDate
       {
           get { return _HealthInsuranceToDate; }
           set { _HealthInsuranceToDate = value; }
       }
       private string _ContractCode;

       public string ContractCode
       {
           get { return _ContractCode; }
           set { _ContractCode = value; }
       }
       private string _ContractType;

       public string ContractType
       {
           get { return _ContractType; }
           set { _ContractType = value; }
       }
       private DateTime _ContractSignDate;

       public DateTime ContractSignDate
       {
           get { return _ContractSignDate; }
           set { _ContractSignDate = value; }
       }
       private DateTime _ContractFromDate;

       public DateTime ContractFromDate
       {
           get { return _ContractFromDate; }
           set { _ContractFromDate = value; }
       }
       private DateTime _ContractToDate;

       public DateTime ContractToDate
       {
           get { return _ContractToDate; }
           set { _ContractToDate = value; }
       }
       private string _Province;

       public string Province
       {
           get { return _Province; }
           set { _Province = value; }
       }
       private string _Hospital;

       public string Hospital
       {
           get { return _Hospital; }
           set { _Hospital = value; }
       }
       private string _MilitaryCode;

       public string MilitaryCode
       {
           get { return _MilitaryCode; }
           set { _MilitaryCode = value; }
       }
       private DateTime _MilitaryFromDate;

       public DateTime MilitaryFromDate
       {
           get { return _MilitaryFromDate; }
           set { _MilitaryFromDate = value; }
       }
       private DateTime _MilitaryToDate;

       public DateTime MilitaryToDate
       {
           get { return _MilitaryToDate; }
           set { _MilitaryToDate = value; }
       }
       private string _MilitaryPosition;

       public string MilitaryPosition
       {
           get { return _MilitaryPosition; }
           set { _MilitaryPosition = value; }
       }
       private string _PassportCode;

       public string PassportCode
       {
           get { return _PassportCode; }
           set { _PassportCode = value; }
       }
       private DateTime _PassportFromDate;

       public DateTime PassportFromDate
       {
           get { return _PassportFromDate; }
           set { _PassportFromDate = value; }
       }
       private DateTime _PassportToDate;

       public DateTime PassportToDate
       {
           get { return _PassportToDate; }
           set { _PassportToDate = value; }
       }
       private string _Account;

       public string Account
       {
           get { return _Account; }
           set { _Account = value; }
       }
       private string _Password;

       public string Password
       {
           get { return _Password; }
           set { _Password = value; }
       }
       private string _Description;

       public string Description
       {
           get { return _Description; }
           set { _Description = value; }
       }

       private string _TaxCode;

       public string TaxCode
       {
           get { return _TaxCode; }
           set { _TaxCode = value; }
       }
       private string _ContractCode1;

       public string ContractCode1
       {
           get { return _ContractCode1; }
           set { _ContractCode1 = value; }
       }
       private string _ContractCode2;

       public string ContractCode2
       {
           get { return _ContractCode2; }
           set { _ContractCode2 = value; }
       }
       private string _ContractCode3;

       public string ContractCode3
       {
           get { return _ContractCode3; }
           set { _ContractCode3 = value; }
       }
       private string _FullName;

       public string FullName
       {
           get { return _FullName; }
           set { _FullName = value; }
       }

       private string _Experiences;

       public string Experiences
       {
           get { return _Experiences; }
           set { _Experiences = value; }
       }

       private string _StopWork;

       public string StopWork
       {
           get { return _StopWork; }
           set { _StopWork = value; }
       }

       private string _StopWorkCode;

       public string StopWorkCode
       {
           get { return _StopWorkCode; }
           set { _StopWorkCode = value; }
       }

       private bool _IsHopDong;

       public bool IsHopDong
       {
           get { return _IsHopDong; }
           set { _IsHopDong = value; }
       }
       #endregion
       public DataTable LoadDanhSachNhanVienTheoPhong()
       {
           string procname = "HRM_EMPLOYEE_GetListByDepartment";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@DepartmentCode", DepartmentCode);
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DayFirstMonth);
           db.AddParameter("@DayEndMonth", DayEndMonth);
           return db.ExecuteDataTable(procname);
       }
       public DataTable LoadDanhSachNhanVienTheoPhong_Ex()
       {
           string procname = "HRM_EMPLOYEE_GetListByDepartment_Ex";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@DepartmentCode", DepartmentCode);
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DayFirstMonth);
           db.AddParameter("@DayEndMonth", DayEndMonth);
           return db.ExecuteDataTable(procname);
       }

       public DataTable LoadDanhSachNhanVien()
       {
           string procname = "HRM_EMPLOYEE_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DateTime.Now);
           db.AddParameter("@DayEndMonth", DateTime.Now);
           return db.ExecuteDataTable(procname);
       }
       public DataTable LoadDanhSachNhanVien_Basic()
       {
           string procname = "HRM_EMPLOYEE_GetList_Basic";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DateTime.Now);
           db.AddParameter("@DayEndMonth", DateTime.Now);
           return db.ExecuteDataTable(procname);
       }
       public DataTable LoadDanhSachNhanVien_Ex()
       {
           string procname = "HRM_EMPLOYEE_GetList_Ex";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DateTime.Now);
           db.AddParameter("@DayEndMonth", DateTime.Now);
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_EMPLOYEE_CheckIDCard()
       {
           string procname = "HRM_EMPLOYEE_CheckIDCard";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@IDCard", IDCard);
           return db.ExecuteDataTable(procname);
       }
       

       public DataTable LoadDanhSachNhanVienTheoChiNhanh()
       {
           string procname = "HRM_EMPLOYEE_GetListByBranch";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@BranchCode", BranchCode);
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DayFirstMonth);
           db.AddParameter("@DayEndMonth", DayEndMonth);
           return db.ExecuteDataTable(procname);
       }

       public DataTable LoadDanhSachNhanVienTheoNhom()
       {
           string procname = "HRM_EMPLOYEE_GetListByGroup";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@GroupCode", GroupCode);
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DayFirstMonth);
           db.AddParameter("@DayEndMonth", DayEndMonth);
           return db.ExecuteDataTable(procname);
       }
       public DataTable LoadDanhSachNhanVienTheoNhom_Ex()
       {
           string procname = "HRM_EMPLOYEE_GetListByGroup_Ex";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@GroupCode", GroupCode);
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DayFirstMonth);
           db.AddParameter("@DayEndMonth", DayEndMonth);
           return db.ExecuteDataTable(procname);
       }
       public DataTable GetEmployeeByCode(string strCode)
       {
           string procname = "HRM_EMPLOYEE_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", strCode);
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetByEnroll(string strCode)
       {
           string procname = "HRM_EMPLOYEE_GetByEnroll";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EnrollNumber", strCode);
           return db.ExecuteDataTable(procname);
       }

       public DataTable GetEmployee_Degree()
       {
           string procname = "HRM_EMPLOYEE_DEGREE_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", EmployeeCode);
           db.AddParameter("@DegreeCode", DegreeCode);          
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetByEnroll()
       {
           string procname = "HRM_EMPLOYEE_GetByEnroll";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EnrollNumber", EnrollNumber);          
           return db.ExecuteDataTable(procname);
       }

       public bool HRM_EMPLOYEE_UpdateEnrollNumber()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@EnrollNumber", EnrollNumber);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_UpdateEnrollNumber");             
               db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Cập nhật mã chấm công: " + EmployeeCode + "-" + FullName);
               return true;
           }
           catch (Exception ex)
           {
               db.RollbackTransaction();
               Class.App.Log_Write(ex.Message);
               return false;
           }
       }
       public bool HRM_EMPLOYEE_UpdateNewEnrollNumber()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@EnrollNumber", EnrollNumber);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_UpdateEnrollNumber");
               db.CreateNewSqlCommand();
               db.AddParameter("@EnrollNumber", EnrollNumber_New);
               db.AddParameter("@EnrollNumber_New",EnrollNumber );
               db.ExecuteNonQueryWithTransaction("CHECKINOUT_UpdateNewEnrollNumber");               
               db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Cập nhật mã chấm công: " + EmployeeCode + "-" + FullName+" - Thay đổi History Chấm công");
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
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Delete");

               db.CreateNewSqlCommand();
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Count");
               db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Xóa Nhân viên: " + EmployeeCode + "-" + FullName);
               return true;
           }
           catch (Exception ex)
           {
               db.RollbackTransaction();
               Class.App.Log_Write(ex.Message);
               return false;
           }
       }

       public string GetNewCode()
       {
           string procname = "HRM_EMPLOYEE_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@Status", Status);
           db.AddParameter("@DayFirstMonth", DayFirstMonth);
           db.AddParameter("@DayEndMonth", DayEndMonth);          
           DataTable dt = db.ExecuteDataTable(procname);
           if (dt.Rows.Count > 0)
           {
               string _strCode = dt.Rows[dt.Rows.Count - 1][0].ToString();
               _strCode = _strCode.Substring(3, _strCode.Length - 3);
               int next_id = int.Parse(_strCode) + 1;
               switch (next_id.ToString().Length)
               {
                   case 1:
                       return "PTH000" + next_id.ToString();
                   case 2:
                       return "PTH00" + next_id.ToString();
                   case 3:
                       return "PTH0" + next_id.ToString();
                   case 4:
                       return "PTH" + next_id.ToString();                                 
               }
           }
           return "PTH0001";

       }
   
       // viet them func insert cac du lieu phu
       public bool Insert(DataTable DataDegree)
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
              // db.AddParameter("@CandidateCode", "");
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
              // db.AddParameter("@IsTest", IsTest);
             //  db.AddParameter("@TestTime", TestTime);
              // db.AddParameter("@TestFromDate", TestFromDate);
             //  db.AddParameter("@TestToDate", TestToDate);
             //  db.AddParameter("@TestSalary", TestSalary);
            db.AddParameter("@BeginDate", BeginDate);
            if (Status == 3) // xu ly tinh trang neu nhan vien da nghi thi moi co ngay ket thuc. con ko nguoc lai
            {
                db.AddParameter("@EndDate", EndDate);
            }
            else
            {
                db.AddParameter("@EndDate", DBNull.Value);
            }
            //   db.AddParameter("@IsOffWork", IsOffWork);
         
               db.AddParameter("@Health", Health);
               db.AddParameter("@Height", Height);
               db.AddParameter("@Weight", Weight);
              // db.AddParameter("@PayForm", PayForm);
              // db.AddParameter("@PayMoney", PayMoney);
              // db.AddParameter("@MinimumSalary", MinimumSalary);
              // db.AddParameter("@RankSalary", RankSalary);
              // db.AddParameter("@StepSalary", StepSalary);
              // db.AddParameter("@CoefficientSalary", CoefficientSalary);
              // db.AddParameter("@DateSalary", DateSalary);
              // db.AddParameter("@BasicSalary", BasicSalary);
              // db.AddParameter("@InsuranceSalary", InsuranceSalary);
               db.AddParameter("@Allowance1", Allowance1);
               db.AddParameter("@Allowance2", Allowance2);
               db.AddParameter("@Allowance3", Allowance3);
               db.AddParameter("@Allowance4", Allowance4);
               db.AddParameter("@TaxCode", TaxCode);
               db.AddParameter("@IsSocialInsurance", IsSocialInsurance);
               db.AddParameter("@IsHealthInsurance", IsHealthInsurance);
               db.AddParameter("@IsUnemploymentInsurance", IsUnemploymentInsurance);
               db.AddParameter("@IsUnionMoney", IsUnionMoney);
               db.AddParameter("@BankCode", BankCode);
               db.AddParameter("@BankDate", BankDate);
               db.AddParameter("@BankName", BankName);
               db.AddParameter("@BankAddress", BankAddress);
               db.AddParameter("@LaborCode", LaborCode);
               db.AddParameter("@LaborDate", LaborDate);
               db.AddParameter("@LaborPlace", LaborPlace);
               db.AddParameter("@IsUnion", IsUnion);
               db.AddParameter("@UnionCode", UnionCode);
               db.AddParameter("@UnionDate", UnionDate);
               db.AddParameter("@UnionPlace", UnionPlace);
               db.AddParameter("@IsParty", IsParty);
               db.AddParameter("@PartyCode", PartyCode);
               db.AddParameter("@PartyDate", PartyDate);
               db.AddParameter("@PartyPlace", PartyPlace);
               db.AddParameter("@InsuranceCode", InsuranceCode);
               if (InsuranceCode.Length > 1)
               {
                   double t;
                   if (double.TryParse(InsuranceCode, out t))
                   {
                       db.AddParameter("@InsuranceDate", InsuranceDate);
                   }
                   else
                   {
                       db.AddParameter("@InsuranceDate", DBNull.Value);
                   }                  
               }
               else
               {
                   db.AddParameter("@InsuranceDate", DBNull.Value);
               }
               db.AddParameter("@InsurancePlace", InsurancePlace);
               db.AddParameter("@HealthInsuranceCode", HealthInsuranceCode);
               db.AddParameter("@HealthInsuranceFromDate", HealthInsuranceFromDate);
               db.AddParameter("@HealthInsuranceToDate", HealthInsuranceToDate);
              
            //   db.AddParameter("@ContractCode", ContractCode);
             //  db.AddParameter("@ContractType", ContractType);
             //  db.AddParameter("@ContractSignDate", ContractSignDate);
             //  db.AddParameter("@ContractFromDate", ContractFromDate);
             //  db.AddParameter("@ContractToDate", ContractToDate);
               db.AddParameter("@Province", Province);
               db.AddParameter("@Hospital", Hospital);
               db.AddParameter("@MilitaryCode", MilitaryCode);
               db.AddParameter("@MilitaryFromDate", MilitaryFromDate);
               db.AddParameter("@MilitaryToDate", MilitaryToDate);
               db.AddParameter("@MilitaryPosition", MilitaryPosition);
               db.AddParameter("@PassportCode", PassportCode);
               db.AddParameter("@PassportFromDate", PassportFromDate);
               db.AddParameter("@PassportToDate", PassportToDate);
               db.AddParameter("@Experiences", Experiences);
               db.AddParameter("@StopWork", StopWork);  
               db.AddParameter("@Status", Status);
               db.AddParameter("@Account", Account);
               db.AddParameter("@Password", Password);
               db.AddParameter("@Description", Description);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Insert");

               // truoc khi cap nhat bang cap thi xoa het luon ( thêm mới thi ko cần)
             //  db.CreateNewSqlCommand();
             //  db.AddParameter("@EmployeeCode", EmployeeCode);
            //   db.ExecuteNonQueryWithTransaction("RM_EMPLOYEE_DEGREE_Delete_Ta");
               ///
               for (int i = 0; i < DataDegree.Rows.Count; i++)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@DegreeCode", DataDegree.Rows[i]["DegreeCode"].ToString());
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEGREE_Insert");
               }

               // xu ly cap nhat quyet dinh thoi viec
                if (IsHopDong)
                    {
                       db.CreateNewSqlCommand();
                       db.AddParameter("@EmployeeCode", EmployeeCode);
                       db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Delete");
              
                       if (Status == 3) // 
                       {
                           if (StopWorkCode.Length != 0)
                           {
                               db.CreateNewSqlCommand();
                               db.AddParameter("@DeActiveCode", StopWorkCode);
                               db.AddParameter("@EmployeeCode", EmployeeCode);
                               db.AddParameter("@Year", EndDate.Year);
                               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Insert");
                           }
                       }
                    }
                else if (StopWorkCode.Length > 5)
                {
                    db.CreateNewSqlCommand();
                    db.AddParameter("@EmployeeCode", EmployeeCode);
                    db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Delete");

                    if (Status == 3) // 
                    {
                        
                            db.CreateNewSqlCommand();
                            db.AddParameter("@DeActiveCode", StopWorkCode);
                            db.AddParameter("@EmployeeCode", EmployeeCode);
                            db.AddParameter("@Year", EndDate.Year);
                            db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Insert");
                        
                    }

                }
              
             ////------------------
               
                db.CreateNewSqlCommand();
              db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Count");
               db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Thêm Nhân viên: " + FirstName + " " + LastName);
               return true;
           }
           catch (Exception ex)
           {
               db.RollbackTransaction();
               Class.App.Log_Write(ex.Message);
               return false;
           }
       }
    

       public bool Update(DataTable DataDegree)
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
              // db.AddParameter("@CandidateCode", "");
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
              // db.AddParameter("@IsTest", IsTest);
             //  db.AddParameter("@TestTime", TestTime);
              // db.AddParameter("@TestFromDate", TestFromDate);
              // db.AddParameter("@TestToDate", TestToDate);
              // db.AddParameter("@TestSalary", TestSalary);
               db.AddParameter("@BeginDate", BeginDate);
              // db.AddParameter("@IsOffWork", IsOffWork);
               if (Status == 3) // xu ly tinh trang neu nhan vien da nghi thi moi co ngay ket thuc. con ko nguoc lai
               {
                   db.AddParameter("@EndDate", EndDate);
               }
               else
               {
                   db.AddParameter("@EndDate", DBNull.Value);
               }
               db.AddParameter("@Health", Health);
               db.AddParameter("@Height", Height);
               db.AddParameter("@Weight", Weight);
             //  db.AddParameter("@PayForm", PayForm);
             //  db.AddParameter("@PayMoney", PayMoney);
             //  db.AddParameter("@MinimumSalary", MinimumSalary);
             //  db.AddParameter("@RankSalary", RankSalary);
             //  db.AddParameter("@StepSalary", StepSalary);
           //    db.AddParameter("@CoefficientSalary", CoefficientSalary);
            //   db.AddParameter("@DateSalary", DateSalary);
            //   db.AddParameter("@BasicSalary", BasicSalary);
            //   db.AddParameter("@InsuranceSalary", InsuranceSalary);
               db.AddParameter("@Allowance1", Allowance1);
               db.AddParameter("@Allowance2", Allowance2);
               db.AddParameter("@Allowance3", Allowance3);
               db.AddParameter("@Allowance4", Allowance4);
               db.AddParameter("@TaxCode", TaxCode);
               db.AddParameter("@IsSocialInsurance", IsSocialInsurance);
               db.AddParameter("@IsHealthInsurance", IsHealthInsurance);
               db.AddParameter("@IsUnemploymentInsurance", IsUnemploymentInsurance);
               db.AddParameter("@IsUnionMoney", IsUnionMoney);
               db.AddParameter("@BankCode", BankCode);
               db.AddParameter("@BankDate", BankDate);
               db.AddParameter("@BankName", BankName);
               db.AddParameter("@BankAddress", BankAddress);
               db.AddParameter("@LaborCode", LaborCode);
               db.AddParameter("@LaborDate", LaborDate);
               db.AddParameter("@LaborPlace", LaborPlace);
               db.AddParameter("@IsUnion", IsUnion);
               db.AddParameter("@UnionCode", UnionCode);
               db.AddParameter("@UnionDate", UnionDate);
               db.AddParameter("@UnionPlace", UnionPlace);
               db.AddParameter("@IsParty", IsParty);
               db.AddParameter("@PartyCode", PartyCode);
               db.AddParameter("@PartyDate", PartyDate);
               db.AddParameter("@PartyPlace", PartyPlace);
               db.AddParameter("@InsuranceCode", InsuranceCode);
               if (InsuranceCode.Length > 1)
               {
                   double t;
                   if (double.TryParse(InsuranceCode, out t))
                   {
                       db.AddParameter("@InsuranceDate", InsuranceDate);
                   }
                   else
                   {
                       db.AddParameter("@InsuranceDate", DBNull.Value);
                   }          
               }
               else
               {
                   db.AddParameter("@InsuranceDate", DBNull.Value);
               }
               db.AddParameter("@InsurancePlace", InsurancePlace);
               db.AddParameter("@HealthInsuranceCode", HealthInsuranceCode);
               db.AddParameter("@HealthInsuranceFromDate", HealthInsuranceFromDate);
               db.AddParameter("@HealthInsuranceToDate", HealthInsuranceToDate);               
               //db.AddParameter("@ContractCode", ContractCode);
             //  db.AddParameter("@ContractType", ContractType);
              // db.AddParameter("@ContractSignDate", ContractSignDate);
             //  db.AddParameter("@ContractFromDate", ContractFromDate);
             //  db.AddParameter("@ContractToDate", ContractToDate);
               db.AddParameter("@Province", Province);
               db.AddParameter("@Hospital", Hospital);
               db.AddParameter("@MilitaryCode", MilitaryCode);
               db.AddParameter("@MilitaryFromDate", MilitaryFromDate);
               db.AddParameter("@MilitaryToDate", MilitaryToDate);
               db.AddParameter("@MilitaryPosition", MilitaryPosition);
               db.AddParameter("@PassportCode", PassportCode);
               db.AddParameter("@PassportFromDate", PassportFromDate);
               db.AddParameter("@PassportToDate", PassportToDate);
               db.AddParameter("@StopWork", StopWork);
               db.AddParameter("@Experiences", Experiences);
               db.AddParameter("@Status", Status);
               db.AddParameter("@Account", Account);
               db.AddParameter("@Password", Password);
               db.AddParameter("@Description", Description);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Update");

               // truoc khi cap nhat bang cap thi xoa het luon
               db.CreateNewSqlCommand();
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEGREE_Delete_Ta");
               ///
               for (int i = 0; i < DataDegree.Rows.Count; i++)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@DegreeCode", DataDegree.Rows[i]["DegreeCode"].ToString());
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEGREE_Insert");
               }

               // xu ly them quyet dinh thoi viec
               if (IsHopDong)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Delete");

                   if (Status == 3) // 
                   {
                       if (StopWorkCode.Length != 0)
                       {
                           db.CreateNewSqlCommand();
                           db.AddParameter("@DeActiveCode", StopWorkCode);
                           db.AddParameter("@EmployeeCode", EmployeeCode);
                           db.AddParameter("@Year", EndDate.Year);
                           db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Insert");
                       }
                   }
               }
               else if (StopWorkCode.Length > 5)   // neu nhap bang tay thi van cho nhap
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Delete");

                   if (Status == 3) // 
                   {
                                           
                       db.CreateNewSqlCommand();
                       db.AddParameter("@DeActiveCode", StopWorkCode);
                       db.AddParameter("@EmployeeCode", EmployeeCode);
                       db.AddParameter("@Year", EndDate.Year);
                       db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Insert");
                       
                   }

               }
               
               ///-------------------------------------------

               db.CreateNewSqlCommand();
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Count");
               db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Cập nhật Nhân viên: " + FirstName + " " + LastName);
               return true;
           }
           catch (Exception ex)
           {
               db.RollbackTransaction();
               Class.App.Log_Write(ex.Message);
               return false;
           }
       }

       public bool Import(DataTable Data)
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               for(int i=0;i<Data.Rows.Count;i++)
               {
                   if ((bool)Data.Rows[i]["Chon"] == true)
                   {
                       EmployeeCode = Data.Rows[i]["EmployeeCode"].ToString();
                       BranchCode = "CN000001";
                       DepartmentCode = "PB000001";
                       FirstName = Data.Rows[i]["FirstName"].ToString();
                       LastName = Data.Rows[i]["LastName"].ToString();
                       Birthday = (DateTime)Data.Rows[i]["Birthday"];
                       BirthPlace = Data.Rows[i]["BirthPlace"].ToString();
                       Sex = (bool)Data.Rows[i]["Sex"];
                       CellPhone = Data.Rows[i]["CellPhone"].ToString();
                       //xu ly hinh anh
                       MemoryStream ms = new MemoryStream(5);
                       Byte[] bytImage = new Byte[ms.Length];
                       Photo = bytImage;

                       MainAddress = Data.Rows[i]["MainAddress"].ToString();
                       IDCard = Data.Rows[i]["IDCard"].ToString();
                       IDCardDate = (DateTime)Data.Rows[i]["IDCardDate"];
                       IDCardPlace = Data.Rows[i]["IDCardPlace"].ToString();
                      // Status = 1;

                       db.CreateNewSqlCommand();
                       db.AddParameter("@EmployeeCode", EmployeeCode);
                       db.AddParameter("@BranchCode", BranchCode);
                       db.AddParameter("@DepartmentCode", DepartmentCode);
                       db.AddParameter("@FirstName", FirstName);
                       db.AddParameter("@LastName", LastName);
                       db.AddParameter("@Birthday", Birthday);
                       db.AddParameter("@BirthPlace", BirthPlace);
                       db.AddParameter("@Sex", Sex);
                       db.AddParameter("@CellPhone", CellPhone);
                       db.AddParameter("@Photo", Photo);
                       db.AddParameter("@MainAddress", MainAddress);
                       db.AddParameter("@IDCard", IDCard);
                       db.AddParameter("@IDCardDate", IDCardDate);
                       db.AddParameter("@IDCardPlace", IDCardPlace);
                       db.AddParameter("@Status", Status);
                       db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Import");
                   }
                }
               db.CreateNewSqlCommand();
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Count");
               db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Import " + Data.Rows.Count + " Nhân viên từ file excel");
               return true;
           }
           catch (Exception ex)
           {
               db.RollbackTransaction();
               Class.App.Log_Write(ex.Message);
               return false;
           }
       }

       public bool HRM_EMPLOYEE_Update_DepartmentFast(object[] EmCode)
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               string DanhSach = "";
               for (int i = 0; i < EmCode.Length; i++)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmCode[i].ToString());
                   db.AddParameter("@BranchCode", BranchCode);
                   db.AddParameter("@DepartmentCode", DepartmentCode);
                   db.AddParameter("@GroupCode", GroupCode);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Update_DepartmentFast");
                   DanhSach += EmCode[i].ToString() + ',';
               }
               db.CreateNewSqlCommand();
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Count");
               db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Cập nhật Nhanh vị trí nhân viên: " + DanhSach);
               return true;
           }

           catch (Exception ex)
           {
               db.RollbackTransaction();
               Class.App.Log_Write(ex.Message);
               return false;
           }
       }

       public bool HRM_EMPLOYEE_Update_PositionFast(object[] EmCode)
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               string DanhSach = "";
               for (int i = 0; i < EmCode.Length; i++)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmCode[i].ToString());
                   db.AddParameter("@Position", Position);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Update_PositionFast");
                   DanhSach += EmCode[i].ToString() + ',';
               }
               db.CreateNewSqlCommand();
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Count");
               db.CommitTransaction();
               Class.S_Log.Insert("Nhân viên", "Cập nhật Nhanh chức vụ : " + DanhSach);
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
