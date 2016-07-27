using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class NhanVien_LienHe
   {
       #region KhaiBao_Bien
       private string _PersonID;

       public string PersonID
       {
           get { return _PersonID; }
           set { _PersonID = value; }
       }
       private string _EmployeeCode;

       public string EmployeeCode
       {
           get { return _EmployeeCode; }
           set { _EmployeeCode = value; }
       }
       private string _PersonName;

       public string PersonName
       {
           get { return _PersonName; }
           set { _PersonName = value; }
       }
       private string _Relative;

       public string Relative
       {
           get { return _Relative; }
           set { _Relative = value; }
       }
       private string _Address;

       public string Address
       {
           get { return _Address; }
           set { _Address = value; }
       }
       private string _Email;

       public string Email
       {
           get { return _Email; }
           set { _Email = value; }
       }
       private string _Phone;

       public string Phone
       {
           get { return _Phone; }
           set { _Phone = value; }
       }
       private bool _IsDepend;

       public bool IsDepend
       {
           get { return _IsDepend; }
           set { _IsDepend = value; }
       }

       #endregion
       public DataTable GetRelativeByEmployee()
       {
           string procname = "HRM_EMPLOYEE_RELATIVE_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", EmployeeCode);
           return db.ExecuteDataTable(procname);
       }

       public DataTable GetPersonByCode(string strCode)
       {
           string procname = "HRM_EMPLOYEE_RELATIVE_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@PersonID", strCode);          
           return db.ExecuteDataTable(procname);
       }

       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@PersonID", PersonID);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@PersonName", PersonName);
               db.AddParameter("@Relative", Relative);
               db.AddParameter("@Address", Address);
               db.AddParameter("@Email", Email);
               db.AddParameter("@Phone", Phone);
               db.AddParameter("@IsDepend", IsDepend);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_RELATIVE_Insert");
               db.CommitTransaction();
               Class.S_Log.Insert("Liên hệ", "Thêm liên hệ: " + PersonName);
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
               db.AddParameter("@PersonID", PersonID);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@PersonName", PersonName);
               db.AddParameter("@Relative", Relative);
               db.AddParameter("@Address", Address);
               db.AddParameter("@Email", Email);
               db.AddParameter("@Phone", Phone);
               db.AddParameter("@IsDepend", IsDepend);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_RELATIVE_Update");
               Class.S_Log.Insert("Liên hệ", "Cập nhật liên hệ: " + PersonName);
               db.CommitTransaction();
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
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_RELATIVE_Delete");              
               db.CommitTransaction();
               Class.S_Log.Insert("Liên hệ", "Xóa liên hệ của nhân viên: " + EmployeeCode);
               return true;
           }
           catch (Exception ex)
           {
               db.RollbackTransaction();
               Class.App.Log_Write(ex.Message);
               return false;
           }
       }
       public bool DeleteByPersonID()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@PersonID", PersonID);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_RELATIVE_DeleteByPersonID");
               db.CommitTransaction();
               Class.S_Log.Insert("Liên hệ", "Xóa liên hệ của nhân viên: " + EmployeeCode);
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
