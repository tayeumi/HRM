using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
    class ThongKe_NgayPhep
    {
        public int Year { get; set; }

        public DataTable HRM_EMPLOYEE_DAYOFFYEAR_Getlist()
        {
            string procname = "HRM_EMPLOYEE_DAYOFFYEAR_Getlist";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();       
            DataTable dt=db.ExecuteDataTable(procname);
            // cap nhat nhung thang ko dung bang khoang trang
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (dt.Rows[i]["Month" + j].ToString() == "0")
                    {
                        dt.Rows[i]["Month" + j] = "";
                    }
                }
            }
            return dt;
        }

        public DataTable HRM_EMPLOYEE_DAYOFFYEAR_GetbyYear()
        {
            string procname = "HRM_EMPLOYEE_DAYOFFYEAR_GetbyYear";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@Year", Year);
            DataTable dt = db.ExecuteDataTable(procname);
            // cap nhat nhung thang ko dung bang khoang trang
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (dt.Rows[i]["Month" + j].ToString() == "0")
                    {
                        dt.Rows[i]["Month" + j] = "";
                    }
                }
            }
            return dt;
        }


        public bool HRM_EMPLOYEE_DAYOFFYEAR_YearCount()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DAYOFFYEAR_YearCount");
                db.CommitTransaction();
                //Class.S_Log.Insert("Nhân viên", "Cập nhật mã chấm công: " + EmployeeCode + "-" + FullName);
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public bool HRM_EMPLOYEE_DAYOFFMEDICAL_YearCount()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_DAYOFFMEDICAL_YearCount");
                db.CommitTransaction();
                //Class.S_Log.Insert("Nhân viên", "Cập nhật mã chấm công: " + EmployeeCode + "-" + FullName);
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }
        public DataTable HRM_EMPLOYEE_DAYOFFMEDICAL_Getlist()
        {
            string procname = "HRM_EMPLOYEE_DAYOFFMEDICAL_Getlist";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            DataTable dt = db.ExecuteDataTable(procname);
            // cap nhat nhung thang ko dung bang khoang trang
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (dt.Rows[i]["Month" + j].ToString() == "0")
                    {
                        dt.Rows[i]["Month" + j] = "";
                    }

                }

            }

            return dt;
        }

        public DataTable HRM_EMPLOYEE_DAYOFFMEDICAL_GetbyYear()
        {
            string procname = "HRM_EMPLOYEE_DAYOFFMEDICAL_GetbyYear";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@Year", Year);
            DataTable dt = db.ExecuteDataTable(procname);
            // cap nhat nhung thang ko dung bang khoang trang
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (dt.Rows[i]["Month" + j].ToString() == "0")
                    {
                        dt.Rows[i]["Month" + j] = "";
                    }

                }

            }

            return dt;
        }
    }
}
