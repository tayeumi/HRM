using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace HRM.Class
{
   public class ThongKe
    {
       public string OptionType { get; set; }
       public string OptionName { get; set; }

       public DataTable HRM_EMPLOYEE_GetSex()
       {
           string procname = "HRM_EMPLOYEE_GetSex";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();           
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetAllSex()
       {
           string procname = "HRM_EMPLOYEE_GetAllSex";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetAge()
       {
           string procname = "HRM_EMPLOYEE_GetAge";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetPosition()
       {
           string procname = "HRM_EMPLOYEE_GetPosition";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetEducation()
       {
           string procname = "HRM_EMPLOYEE_GetEducation";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_EMPLOYEE_GetNationality()
       {
           string procname = "HRM_EMPLOYEE_GetNationality";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_EMPLOYEE_GetReligion()
       {
           string procname = "HRM_EMPLOYEE_GetReligion";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetMarriage()
       {
           string procname = "HRM_EMPLOYEE_GetMarriage";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_EMPLOYEE_GetEthnic()
       {
           string procname = "HRM_EMPLOYEE_GetEthnic";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetStatistical()
       {
           string procname = "HRM_EMPLOYEE_GetStatistical";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetListBirthdayByMonth(int _Month)
       {
           string procname = "HRM_EMPLOYEE_GetListBirthdayByMonth";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@Month", _Month); 
           DataTable dt =db.ExecuteDataTable(procname);
           dt.Columns.Add("Day", Type.GetType("System.String"));
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               string txt= ((DateTime)dt.Rows[i]["BirthDay"]).Day.ToString();
               if (txt.Length == 1)
               {
                   txt = "0" + txt;
               }
               dt.Rows[i]["Day"] = txt;
               
           }
           DataView dv = dt.DefaultView;
           dv.Sort = "Day ASC";
            dt = dv.ToTable();
            return dt;
       }
       public DataTable HRM_EMPLOYEE_GetListBirthday()
       {
           string procname = "HRM_EMPLOYEE_GetListBirthday";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();          
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_EMPLOYEE_GetRate()
       {
           string procname = "HRM_EMPLOYEE_GetRate";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@FromYear", 2005);
           db.AddParameter("@ToYear", DateTime.Now.Year); 
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_OPTION_LATEOFWORK_GetbyEmployee()
       {
           string procname = "HRM_OPTION_LATEOFWORK_GetbyEmployee";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();          
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_OPTION_LATEOFWORK_GetbyDepartmentName()
       {
           string procname = "HRM_OPTION_LATEOFWORK_GetbyDepartmentName";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable HRM_OPTION_LATEOFWORK_GetListEmployee()
       {
           string procname = "HRM_OPTION_LATEOFWORK_GetListEmployee";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public bool HRM_OPTION_LATEOFWORK_Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@OptionType", OptionType);
               db.AddParameter("@OptionName", OptionName);               
               db.ExecuteNonQueryWithTransaction("HRM_OPTION_LATEOFWORK_Insert");
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

       public bool HRM_OPTION_LATEOFWORK_Delete()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@OptionType", OptionType);
               db.AddParameter("@OptionName", OptionName);   
               db.ExecuteNonQueryWithTransaction("HRM_OPTION_LATEOFWORK_Delete");
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
