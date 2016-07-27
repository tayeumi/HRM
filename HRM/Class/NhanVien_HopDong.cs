using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class NhanVien_HopDong
   {
       #region Khaibao_bien
       private string _ContractCode;

       public string ContractCode
       {
           get { return _ContractCode; }
           set { _ContractCode = value; }
       }
       private string _EmployeeCode;

       public string EmployeeCode
       {
           get { return _EmployeeCode; }
           set { _EmployeeCode = value; }
       }
       private string _ContractType;

       public string ContractType
       {
           get { return _ContractType; }
           set { _ContractType = value; }
       }
       private string _ContractTime;

       public string ContractTime
       {
           get { return _ContractTime; }
           set { _ContractTime = value; }
       }
       private int _ContractYear;

       public int ContractYear
       {
           get { return _ContractYear; }
           set { _ContractYear = value; }
       }


       private DateTime _SignDate;

       public DateTime SignDate
       {
           get { return _SignDate; }
           set { _SignDate = value; }
       }
       private DateTime _FromDate;

       public DateTime FromDate
       {
           get { return _FromDate; }
           set { _FromDate = value; }
       }
       private DateTime _ToDate;

       public DateTime ToDate
       {
           get { return _ToDate; }
           set { _ToDate = value; }
       }
       private decimal _BasicSalary;

       public decimal BasicSalary
       {
           get { return _BasicSalary; }
           set { _BasicSalary = value; }
       }
       private string _PayForm;

       public string PayForm
       {
           get { return _PayForm; }
           set { _PayForm = value; }
       }
       private int _PayDate;

       public int PayDate
       {
           get { return _PayDate; }
           set { _PayDate = value; }
       }
       private string _Allowance;

       public string Allowance
       {
           get { return _Allowance; }
           set { _Allowance = value; }
       }

       private int _Rate;

       public int Rate
       {
           get { return _Rate; }
           set { _Rate = value; }
       }

       private string _Insurance;

       public string Insurance
       {
           get { return _Insurance; }
           set { _Insurance = value; }
       }
       private string _WorkTime;

       public string WorkTime
       {
           get { return _WorkTime; }
           set { _WorkTime = value; }
       }
       private string _Signer;

       public string Signer
       {
           get { return _Signer; }
           set { _Signer = value; }
       }
       private string _SignerPosition;

       public string SignerPosition
       {
           get { return _SignerPosition; }
           set { _SignerPosition = value; }
       }
       private string _SignerNationality;

       public string SignerNationality
       {
           get { return _SignerNationality; }
           set { _SignerNationality = value; }
       }
       private string _Company;

       public string Company
       {
           get { return _Company; }
           set { _Company = value; }
       }
       private string _Address;

       public string Address
       {
           get { return _Address; }
           set { _Address = value; }
       }
       private string _Tel;

       public string Tel
       {
           get { return _Tel; }
           set { _Tel = value; }
       }
       private string _Subject;

       public string Subject
       {
           get { return _Subject; }
           set { _Subject = value; }
       }
       private string _Description;

       public string Description
       {
           get { return _Description; }
           set { _Description = value; }
       }
       private bool _IsCurrent;

       public bool IsCurrent
       {
           get { return _IsCurrent; }
           set { _IsCurrent = value; }
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

       private string _GroupCode;

       public string GroupCode
       {
           get { return _GroupCode; }
           set { _GroupCode = value; }
       }

       private string _SecondAllowance;

       public string SecondAllowance
       {
           get { return _SecondAllowance; }
           set { _SecondAllowance = value; }
       }
       #endregion

       public DataTable HRM_CONTRACT_GetListByBranch()
       {
           string procname = "HRM_CONTRACT_GetListByBranch";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@BranchCode", BranchCode);        
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_CONTRACT_GetCurrentListByEmployee()
       {
           string procname = "HRM_CONTRACT_GetCurrentListByEmployee";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", EmployeeCode);
           return db.ExecuteDataTable(procname);
       }


       public DataTable HRM_CONTRACT_GetPrintByCode()
       {
           string procname = "HRM_CONTRACT_GetPrintByCode";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@ContractCode", ContractCode);
           DataTable dt= db.ExecuteDataTable(procname);
           dt.Columns.Add("FullName", Type.GetType("System.String"));
           dt.Columns.Add("VND", Type.GetType("System.String"));
           dt.Columns.Add("ContractTypeToDate", Type.GetType("System.String"));
           dt.Columns.Add("SecondContractCode");
           dt.Columns.Add("SecondSignDate",typeof(DateTime));          

           #region XulyTienThuViec_CuareportThuViec
           int _rate = int.Parse(dt.Rows[0]["Rate"].ToString());
           decimal _testSalary =(decimal)(dt.Rows[0]["BasicSalary"]);
           decimal _testAllowance;
           if (dt.Rows[0]["Allowance"].ToString() != "")
           {
                _testAllowance = decimal.Parse(dt.Rows[0]["Allowance"].ToString());
           }
           else
           {
               _testAllowance=0;
           }
           _testSalary= (_testSalary * _rate / 100);
           _testAllowance = (_testAllowance * _rate / 100);
           dt.Columns.Add("TestSalary", Type.GetType("System.Decimal"));
           dt.Columns.Add("TestAllowance", Type.GetType("System.Decimal"));
            dt.Rows[0]["TestSalary"] =_testSalary;
            dt.Rows[0]["TestAllowance"] =_testAllowance;
           #endregion

            DateTime SignDate = (DateTime)dt.Rows[0]["SignDate"];
            dt.Rows[0]["SecondSignDate"] = SignDate.AddDays(1);

            string _contractCode = dt.Rows[0]["ContractCode"].ToString();
           _contractCode= _contractCode.Replace("D","Đ");
           _contractCode= _contractCode.Replace("Lan","Lần");
           dt.Rows[0]["ContractCode"] = _contractCode;

            #region Xu ly In phu luc hop dong
            string _secondContractCode = dt.Rows[0]["ContractCode"].ToString();
            string[] _secondContractCode2 = _secondContractCode.Split('/');
            if (_secondContractCode2.Length > 2)
                dt.Rows[0]["SecondContractCode"] = _secondContractCode2.GetValue(0)+"/ Phụ lục HĐLĐ";

            #endregion

            string _vnd = dt.Rows[0]["BasicSalary"].ToString();
          dt.Rows[0]["Signer"] = dt.Rows[0]["Signer"].ToString().ToUpper();
          _vnd = _vnd.Substring(0, _vnd.IndexOf('.')); // bỏ đi tiền lẻ.(.00)
           dt.Rows[0]["VND"] = Class.App.ChuyenSo(_vnd);
           dt.Rows[0]["Fullname"] = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
           dt.Rows[0]["Fullname"] = dt.Rows[0]["Fullname"].ToString().ToUpper();
           if (dt.Rows[0]["ContractTime"].ToString()!="Không xác định thời hạn")
           {
               dt.Rows[0]["ContractType"] = dt.Rows[0]["ContractType"].ToString() +"( "+ dt.Rows[0]["ContractTime"].ToString() +" )";
                DateTime _to_date=(DateTime)dt.Rows[0]["ToDate"];
                string PrintTodate = "";
                if (_to_date.Day.ToString().Length == 1)
                {
                    PrintTodate = "0" + _to_date.Day.ToString();
                }
                else
                {
                    PrintTodate =_to_date.Day.ToString();
                }
                if (_to_date.Month.ToString().Length == 1)
                {
                    PrintTodate = PrintTodate+"/0" + _to_date.Month.ToString();
                }
                else
                {
                    PrintTodate =PrintTodate+"/"+ _to_date.Month.ToString();
                }
                PrintTodate = PrintTodate +"/"+_to_date.Year.ToString();

                dt.Rows[0]["ContractTypeToDate"] = PrintTodate;
           }else
           {
                dt.Rows[0]["ContractTypeToDate"]=dt.Rows[0]["ContractTime"].ToString();
           }

           return dt;
       }

       public DataTable HRM_CONTRACT_GetList()
       {
           string procname = "HRM_CONTRACT_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();          
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_CONTRACT_GetCurrentList()
       {
           string procname = "HRM_CONTRACT_GetCurrentList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_CONTRACT_GetListExpiration()
       {
           string procname = "HRM_CONTRACT_GetListExpiration";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_CONTRACT_GetListJustExpiration()
       {
           string procname = "HRM_CONTRACT_GetListJustExpiration";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       
       public DataTable HRM_CONTRACT_GetListByDepartment()
       {
           string procname = "HRM_CONTRACT_GetListByDepartment";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@DepartmentCode", DepartmentCode); 
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_CONTRACT_GetListByGroup()
       {
           string procname = "HRM_CONTRACT_GetListByGroup";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@GroupCode", GroupCode);
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_CONTRACT_GetByEmployee()
       {
           string procname = "HRM_CONTRACT_GetByEmployee";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", EmployeeCode);
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_CONTRACT_Get(string strCode)
       {
           string procname = "HRM_CONTRACT_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@ContractCode", strCode);
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_CONTRACT_GetByYear()
       {
           string procname = "HRM_CONTRACT_GetByYear";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@ContractYear", ContractYear);
          // db.AddParameter("@ContractType", ContractType);
           return db.ExecuteDataTable(procname);
       }

       private int SolankyHD()
       {
           string _maHd = ContractCode;
           if (_maHd.IndexOf("HDTV") > 0)
           {
               return 0;
           }
           if (_maHd.IndexOf("Lan1") > 0)
           {
               if (_maHd.IndexOf("KXDTH") > 0)
               {
                   return 4;
               }
               return 1;
           }
           if (_maHd.IndexOf("Lan2") > 0)
           {
               if (_maHd.IndexOf("KXDTH") > 0)
               {
                   return 5;
               }
               return 2;
           }
           if (_maHd.IndexOf("KXDTH") > 0)
           {
               return 3;
           }
           return 6;
       }

       public bool Insert()
       {
           int NoIndex = SolankyHD();
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               #region Them hop dong thi cap nhat thong tin bang nhan vien
              
               if (NoIndex == 0)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode", ContractCode);
                   db.AddParameter("@ContractType", ContractType);
                   db.AddParameter("@ContractTime", ContractTime);
                   db.AddParameter("@ContractSignDate", SignDate);
                   db.AddParameter("@ContractFromDate", FromDate);
                   db.AddParameter("@ContractToDate", ToDate);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update");
               }
               else if (NoIndex == 1)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode1", ContractCode);
                   db.AddParameter("@ContractType1", ContractType);
                   db.AddParameter("@ContractTime1", ContractTime);
                   db.AddParameter("@ContractSignDate1", SignDate);
                   db.AddParameter("@ContractFromDate1", FromDate);
                   db.AddParameter("@ContractToDate1", ToDate);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_01");

               }
               else if (NoIndex == 2)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode2", ContractCode);
                   db.AddParameter("@ContractType2", ContractType);
                   db.AddParameter("@ContractTime2", ContractTime);
                   db.AddParameter("@ContractSignDate2", SignDate);
                   db.AddParameter("@ContractFromDate2", FromDate);
                   db.AddParameter("@ContractToDate2", ToDate);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_02");
               }
               else if (NoIndex == 3)  // lan cuoi cung
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode3", ContractCode);
                   db.AddParameter("@ContractType3", ContractType);
                   db.AddParameter("@ContractTime3", ContractTime);
                   db.AddParameter("@ContractSignDate3", SignDate);
                   db.AddParameter("@ContractFromDate3", FromDate);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_03");
               }
               else if (NoIndex == 4) // truong hop ky lan 1 da kxdth
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode1", ContractCode);
                   db.AddParameter("@ContractType1", ContractType);
                   db.AddParameter("@ContractTime1", ContractTime);
                   db.AddParameter("@ContractSignDate1", SignDate);
                   db.AddParameter("@ContractFromDate1", FromDate);
                   db.AddParameter("@ContractToDate1", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_01");

               }
               else if (NoIndex == 5) //truong hop ky lan 2 da kxdth
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode2", ContractCode);
                   db.AddParameter("@ContractType2", ContractType);
                   db.AddParameter("@ContractTime2", ContractTime);
                   db.AddParameter("@ContractSignDate2", SignDate);
                   db.AddParameter("@ContractFromDate2", FromDate);
                   db.AddParameter("@ContractToDate2", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_02");
               }
               #endregion
               // thu hien neu la hd hien tai
               if (IsCurrent)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_Update_notIsCurrent");
               }
               //
               db.CreateNewSqlCommand();
               db.AddParameter("@ContractCode", ContractCode);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@ContractType", ContractType);
               db.AddParameter("@ContractTime", ContractTime);
               db.AddParameter("@ContractYear", ContractYear);
               db.AddParameter("@SignDate", SignDate);
               db.AddParameter("@FromDate", FromDate);
               if (NoIndex > 2)
               {
                   db.AddParameter("@ToDate", DBNull.Value);

               }
               else
               {
                   db.AddParameter("@ToDate", ToDate);

               }
               db.AddParameter("@BasicSalary", BasicSalary);
               db.AddParameter("@PayForm", PayForm);
               db.AddParameter("@PayDate", PayDate);
               db.AddParameter("@Allowance", Allowance);
               db.AddParameter("@SecondAllowance", SecondAllowance);
               db.AddParameter("@Rate", Rate);
               db.AddParameter("@Insurance", Insurance);
               db.AddParameter("@WorkTime", WorkTime);
               db.AddParameter("@Signer", Signer);
               db.AddParameter("@SignerPosition", SignerPosition);
               db.AddParameter("@SignerNationality", SignerNationality);
               db.AddParameter("@Company", Company);
               db.AddParameter("@Address", Address);
               db.AddParameter("@Tel", Tel);
               db.AddParameter("@Subject", Subject);
               db.AddParameter("@Description", Description);
               db.AddParameter("@IsCurrent", IsCurrent);  
               db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_Insert");              
               db.CommitTransaction();
               Class.S_Log.Insert("Hợp Đồng", "Thêm Hợp đồng: " + ContractCode + " - Mã Nhân viên: " + EmployeeCode);
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
           int NoIndex = SolankyHD();
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               #region Them hop dong thi cap nhat thong tin bang nhan vien

               if (NoIndex == 0)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode", ContractCode);
                   db.AddParameter("@ContractType", ContractType);
                   db.AddParameter("@ContractTime", ContractTime);
                   db.AddParameter("@ContractSignDate", SignDate);
                   db.AddParameter("@ContractFromDate", FromDate);
                   db.AddParameter("@ContractToDate", ToDate);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update");
               }
               else if (NoIndex == 1)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode1", ContractCode);
                   db.AddParameter("@ContractType1", ContractType);
                   db.AddParameter("@ContractTime1", ContractTime);
                   db.AddParameter("@ContractSignDate1", SignDate);
                   db.AddParameter("@ContractFromDate1", FromDate);
                   db.AddParameter("@ContractToDate1", ToDate);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_01");

               }
               else if (NoIndex == 2)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode2", ContractCode);
                   db.AddParameter("@ContractType2", ContractType);
                   db.AddParameter("@ContractTime2", ContractTime);
                   db.AddParameter("@ContractSignDate2", SignDate);
                   db.AddParameter("@ContractFromDate2", FromDate);
                   db.AddParameter("@ContractToDate2", ToDate);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_02");
               }
               else if (NoIndex == 3)  // lan cuoi cung
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode3", ContractCode);
                   db.AddParameter("@ContractType3", ContractType);
                   db.AddParameter("@ContractTime3", ContractTime);
                   db.AddParameter("@ContractSignDate3", SignDate);
                   db.AddParameter("@ContractFromDate3", FromDate);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_03");
               }
               else if (NoIndex == 4) // truong hop ky lan 1 da kxdth
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode1", ContractCode);
                   db.AddParameter("@ContractType1", ContractType);
                   db.AddParameter("@ContractTime1", ContractTime);
                   db.AddParameter("@ContractSignDate1", SignDate);
                   db.AddParameter("@ContractFromDate1", FromDate);
                   db.AddParameter("@ContractToDate1", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_01");

               }
               else if (NoIndex == 5) //truong hop ky lan 2 da kxdth
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode2", ContractCode);
                   db.AddParameter("@ContractType2", ContractType);
                   db.AddParameter("@ContractTime2", ContractTime);
                   db.AddParameter("@ContractSignDate2", SignDate);
                   db.AddParameter("@ContractFromDate2", FromDate);
                   db.AddParameter("@ContractToDate2", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_02");
               }
               #endregion
               // thu hien neu la hd hien tai
               if (IsCurrent)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_Update_notIsCurrent");
               }
               //
               db.CreateNewSqlCommand();
               db.AddParameter("@ContractCode", ContractCode);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@ContractType", ContractType);
               db.AddParameter("@ContractTime", ContractTime);
               db.AddParameter("@ContractYear", ContractYear);
               db.AddParameter("@SignDate", SignDate);
               db.AddParameter("@FromDate", FromDate);
               if (NoIndex > 2)
               {
                   db.AddParameter("@ToDate", DBNull.Value);

               }
               else
               {
                   db.AddParameter("@ToDate", ToDate);

               }
               db.AddParameter("@BasicSalary", BasicSalary);
               db.AddParameter("@PayForm", PayForm);
               db.AddParameter("@PayDate", PayDate);
               db.AddParameter("@Allowance", Allowance);
               db.AddParameter("@SecondAllowance", SecondAllowance);
               db.AddParameter("@Rate", Rate);
               db.AddParameter("@Insurance", Insurance);
               db.AddParameter("@WorkTime", WorkTime);
               db.AddParameter("@Signer", Signer);
               db.AddParameter("@SignerPosition", SignerPosition);
               db.AddParameter("@SignerNationality", SignerNationality);
               db.AddParameter("@Company", Company);
               db.AddParameter("@Address", Address);
               db.AddParameter("@Tel", Tel);
               db.AddParameter("@Subject", Subject);
               db.AddParameter("@Description", Description);
               db.AddParameter("@IsCurrent", IsCurrent);
               db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_Update");
               db.CommitTransaction();
               Class.S_Log.Insert("Hợp Đồng", "Cập nhật Hợp đồng: " + ContractCode + " - Mã Nhân viên: " + EmployeeCode);
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
           // them clear hop dong trong danh sach nhan vien
           int NoIndex = SolankyHD();
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               #region Cập nhật hop dong thi cap nhat thong tin bang nhan vien

               if (NoIndex == 0)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode", "");
                   db.AddParameter("@ContractType", "");
                   db.AddParameter("@ContractTime", "");
                   db.AddParameter("@ContractSignDate", DBNull.Value);
                   db.AddParameter("@ContractFromDate", DBNull.Value);
                   db.AddParameter("@ContractToDate", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update");
               }
               else if (NoIndex == 1)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode1", "");
                   db.AddParameter("@ContractType1", "");
                   db.AddParameter("@ContractTime1", "");
                   db.AddParameter("@ContractSignDate1", DBNull.Value);
                   db.AddParameter("@ContractFromDate1", DBNull.Value);
                   db.AddParameter("@ContractToDate1", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_01");

               }
               else if (NoIndex == 2)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode2", "");
                   db.AddParameter("@ContractType2", "");
                   db.AddParameter("@ContractTime2", "");
                   db.AddParameter("@ContractSignDate2", DBNull.Value);
                   db.AddParameter("@ContractFromDate2", DBNull.Value);
                   db.AddParameter("@ContractToDate2", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_02");
               }
               else if (NoIndex == 3)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode3", "");
                   db.AddParameter("@ContractType3", "");
                   db.AddParameter("@ContractTime3", "");
                   db.AddParameter("@ContractSignDate3", DBNull.Value);
                   db.AddParameter("@ContractFromDate3", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_03");
               }
               else if (NoIndex == 4)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode1", "");
                   db.AddParameter("@ContractType1", "");
                   db.AddParameter("@ContractTime1", "");
                   db.AddParameter("@ContractSignDate1", DBNull.Value);
                   db.AddParameter("@ContractFromDate1", DBNull.Value);
                   db.AddParameter("@ContractToDate1", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_01");

               }
               else if (NoIndex == 5)
               {
                   db.CreateNewSqlCommand();
                   db.AddParameter("@EmployeeCode", EmployeeCode);
                   db.AddParameter("@ContractCode2", "");
                   db.AddParameter("@ContractType2", "");
                   db.AddParameter("@ContractTime2", "");
                   db.AddParameter("@ContractSignDate2", DBNull.Value);
                   db.AddParameter("@ContractFromDate2", DBNull.Value);
                   db.AddParameter("@ContractToDate2", DBNull.Value);
                   db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_CONTRACT_Update_02");
               }
               #endregion

               db.CreateNewSqlCommand();
               db.AddParameter("@ContractCode", ContractCode);
               db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_Delete");              
               db.CommitTransaction();
               Class.S_Log.Insert("Hợp Đồng", "Xóa Hợp đồng: " + ContractCode + " - Mã Nhân viên: " + EmployeeCode);
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
