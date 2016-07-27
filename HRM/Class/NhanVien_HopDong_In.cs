using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class NhanVien_HopDong_In
    {
       public string ContractCode { get; set; }
       public string EmployeeCode { get; set; }
       public byte[] Images { get; set; }
       public DateTime DateTime { get; set; }
       public string UserPrint { get; set; }

       public DataTable HRM_CONTRACT_PRINT_Getlist()
       {
           string procname = "HRM_CONTRACT_PRINT_Getlist";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_CONTRACT_PRINT_GetbyEmployeeCode()
       {
           string procname = "HRM_CONTRACT_PRINT_GetbyEmployeeCode";
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
               db.AddParameter("@ContractCode", ContractCode);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@Images", Images);
               db.AddParameter("@DateTime", DateTime.Now);
               db.AddParameter("@UserPrint", App.client_User);
               db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_PRINT_Insert");
               db.CommitTransaction();
               Class.S_Log.Insert("In HD", "In HD: " + ContractCode + "|" + EmployeeCode);
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
