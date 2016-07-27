using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;

namespace HRM.Class
{
   public class S_Log
   {
       #region KhaiBao_Bien
       public static string UserName;
       public static DateTime Created;
       public static string Module;
       public static string IPLan;
       public static string PCName;
       public static string Description;

   
       #endregion

       public static DataTable Log_HeThong()
       {
           string procname = "HRM_LOG_Getlist";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public static bool Insert(string _module,string _des)
       {
           Module = _module;
           Description = _des;
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@UserName", UserName);
               db.AddParameter("@Created", DateTime.Now);
               db.AddParameter("@Module", Module);
               db.AddParameter("@IPLan", IPLan);
               db.AddParameter("@PCName", PCName);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", true);

               db.ExecuteNonQueryWithTransaction("HRM_LOG_Insert");
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

       public static void Call_PcInfo()
       {
           string _PCName = System.Environment.MachineName;  
           IPHostEntry host;
           string localIP = "?";
           host = Dns.GetHostEntry(Dns.GetHostName());
           foreach (IPAddress ip in host.AddressList)
           {
               if (ip.AddressFamily.ToString() == "InterNetwork")
               {
                   localIP = ip.ToString();
               }
           }

           IPLan = localIP;
           PCName = _PCName;
       }

       public static bool ClearAll_Log_HeThong()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.ExecuteNonQueryWithTransaction("HRM_LOG_DeleteAll");
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
