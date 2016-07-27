using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace HRM.Class
{
   public class S_TaiKhoan
   {
       #region KhaiBao_Bien
       private string _UserName;

       public string UserName
       {
           get { return _UserName; }
           set { _UserName = value; }
       }
       private string _Password;

       public string Password
       {
           get { return _Password; }
           set { _Password = value; }
       }
       private string _Email;

       public string Email
       {
           get { return _Email; }
           set { _Email = value; }
       }
       private string _Description;

       public string Description
       {
           get { return _Description; }
           set { _Description = value; }
       }
       private bool _Active;

       public bool Active
       {
           get { return _Active; }
           set { _Active = value; }
       }
       private string _Object_ID;

       public string Object_ID
       {
           get { return _Object_ID; }
           set { _Object_ID = value; }
       }
       private string _Object_Name;

       public string Object_Name
       {
           get { return _Object_Name; }
           set { _Object_Name = value; }
       }
          

       #endregion

       public static string md5(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            //  return BitConverter.ToString(encodedBytes);
            return Regex.Replace(BitConverter.ToString(encodedBytes), "-", "");
        }

       public DataTable CheckLogin()
       {
           string procname = "HRM_USER_Get_Login";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@UserName", UserName);
           db.AddParameter("@Password", Password); 
           return db.ExecuteDataTable(procname);
       }

       public DataTable GetAllList_USER()
       {
           Class.S_Log.Insert("Tài Khoản", "Xem Danh sách tài khoản");
           string procname = "HRM_USER_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable GetUserByCode(string strCode)
       {
           Class.S_Log.Insert("Tài Khoản", "Xem tài khoản: " + strCode);
           string procname = "HRM_USER_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@UserName", strCode);
           return db.ExecuteDataTable(procname);
       }

       public DataTable GetPermissionByUser()
       {
           string procname = "HRM_USER_RULE_GetListByUsername";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@UserName", UserName);
           DataTable dt =db.ExecuteDataTable(procname);
           dt.Columns.Add("selectvalue", Type.GetType("System.Boolean"));
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               dt.Rows[i]["selectvalue"] = false;
           }
           return dt;
       }
        
       public DataTable GetPermissionNotUseByUser()
       {
           string procname = "HRM_OBJECT_NotUseByUsername";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@UserName", UserName);
           DataTable dt =db.ExecuteDataTable(procname);
           dt.Columns.Add("selectvalue", Type.GetType("System.Boolean"));
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               dt.Rows[i]["selectvalue"] = false;
           }
           return dt;           
       }

       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@UserName", UserName);
               db.AddParameter("@Password", Password);
               db.AddParameter("@Email", Email);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("HRM_USER_Insert");
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
               db.AddParameter("@UserName", UserName);
               db.AddParameter("@Password", Password);
               db.AddParameter("@Email", Email);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("HRM_USER_Update");
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
               db.AddParameter("@UserName", UserName);
               db.ExecuteNonQueryWithTransaction("HRM_USER_Delete");
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

       public bool Insert_Permission(DataTable dt)
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   if ((bool)dt.Rows[i]["selectvalue"] == true)
                   {
                       db.CreateNewSqlCommand();
                       db.AddParameter("@UserName", UserName);
                       db.AddParameter("@Object_ID", dt.Rows[i]["Object_ID"].ToString());
                       db.AddParameter("@Object_Name", dt.Rows[i]["Object_Name"].ToString());
                       db.ExecuteNonQueryWithTransaction("HRM_USER_RULE_Insert");
                   }
               }
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

       public bool Delete_Permission(DataTable dt)
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   if ((bool)dt.Rows[i]["selectvalue"] == true)
                   {
                       db.CreateNewSqlCommand();
                       db.AddParameter("@UserName", UserName);
                       db.AddParameter("@Object_ID", dt.Rows[i]["Object_ID"].ToString());
                       db.ExecuteNonQueryWithTransaction("HRM_USER_RULE_Delete");
                   }
               }
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

       public bool ChangePassword()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@UserName", UserName);
               db.AddParameter("@Password", Password);
               db.ExecuteNonQueryWithTransaction("HRM_USER_ChangePassword");               
               db.CommitTransaction();
               Class.S_Log.Insert("Tài Khoản", "Đổi mật khẩu: " + UserName);
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
