using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
    class NhanVien_ThoiViec
    {
        public string DeActiveCode { get; set; }
        public string EmployeeCode { get; set; }
        public int Year { get; set; }

        public DataTable HRM_EMPLOYEE_DEACTIVE_GetList()
        {
            string procname = "HRM_EMPLOYEE_DEACTIVE_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public DataTable HRM_EMPLOYEE_DEACTIVE_GetByYear()
        {
            string procname = "HRM_EMPLOYEE_DEACTIVE_GetByYear";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@Year", Year);
            return db.ExecuteDataTable(procname);
        }
        public DataTable HRM_EMPLOYEE_DEACTIVE_GetByEmployeeCode()
        {
            string procname = "HRM_EMPLOYEE_DEACTIVE_GetByEmployeeCode";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@EmployeeCode", EmployeeCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@DeActiveCode", DeActiveCode);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@Year", Year);
                db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Insert");
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
                db.CreateNewSqlCommand();
                db.AddParameter("@DeActiveCode", DeActiveCode);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@Year", Year);
                db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Update");
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
                db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DEACTIVE_Delete");
                db.CommitTransaction();
               // Class.S_Log.Insert("Ngoại ngữ", "Xóa Ngoại ngữ: " + LanguageCode);
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public DataTable HRM_EMPLOYEE_DEACTIVE_GetPrint()
        {
            string procname = "HRM_EMPLOYEE_DEACTIVE_GetPrint";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@EmployeeCode", EmployeeCode);
            return db.ExecuteDataTable(procname);
        }
    }
}
