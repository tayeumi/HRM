using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class NhanVien_PhuCap
   {
       #region KhaiBao_Bien
       private string _EmployeeCode;

       public string EmployeeCode
       {
           get { return _EmployeeCode; }
           set { _EmployeeCode = value; }
       }
       private string _AllowanceCode;

       public string AllowanceCode
       {
           get { return _AllowanceCode; }
           set { _AllowanceCode = value; }
       }
       private decimal _Money;

       public decimal Money
       {
           get { return _Money; }
           set { _Money = value; }
       }
       #endregion

       public DataTable GetAllowanceByEmployee()
       {
           string procname = "HRM_EMPLOYEE_ALLOWANCE_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", EmployeeCode);
           return db.ExecuteDataTable(procname);
       }

       public DataTable GetAllowanceByCode()
       {
           string procname = "HRM_EMPLOYEE_ALLOWANCE_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", EmployeeCode);
           db.AddParameter("@AllowanceCode", AllowanceCode);
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
               db.AddParameter("@AllowanceCode", AllowanceCode);
               db.AddParameter("@Money", Money);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_ALLOWANCE_Insert");
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

       public bool Update()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@AllowanceCode", AllowanceCode);
               db.AddParameter("@Money", Money);
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_ALLOWANCE_Update");
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
               db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_ALLOWANCE_Delete");
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
    }
}
