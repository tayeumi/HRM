using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class CongTy
   {
       #region KhaiBao_Bien
       private string _CompanyID;

       public string CompanyID
       {
           get { return _CompanyID; }
           set { _CompanyID = value; }
       }
       private string _CompanyName;

       public string CompanyName
       {
           get { return _CompanyName; }
           set { _CompanyName = value; }
       }
       private string _CompanyAddress;

       public string CompanyAddress
       {
           get { return _CompanyAddress; }
           set { _CompanyAddress = value; }
       }
       private string _CompanyTax;

       public string CompanyTax
       {
           get { return _CompanyTax; }
           set { _CompanyTax = value; }
       }
       private string _Tel;

       public string Tel
       {
           get { return _Tel; }
           set { _Tel = value; }
       }
       private string _Fax;

       public string Fax
       {
           get { return _Fax; }
           set { _Fax = value; }
       }
       private string _WebSite;

       public string WebSite
       {
           get { return _WebSite; }
           set { _WebSite = value; }
       }
       private string _Email;

       public string Email
       {
           get { return _Email; }
           set { _Email = value; }
       }
       private byte[] _Logo;

       public byte[] Logo
       {
           get { return _Logo; }
           set { _Logo = value; }
       }

       #endregion

       public DataTable LoadThongTinCty()
       {
           //Class.S_Log.Insert("Công ty", "Xem Thông tin công ty");
           string procname = "COMPANY_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       
       public DataTable GetComparnyByCode(string strCode)
       {
           string procname = "COMPANY_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@CompanyID", strCode);
           return db.ExecuteDataTable(procname);
       }

       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@CompanyID", CompanyID);
               db.AddParameter("@CompanyName", CompanyName);
               db.AddParameter("@CompanyAddress", CompanyAddress);
               db.AddParameter("@CompanyTax", CompanyTax);
               db.AddParameter("@Tel", Tel);
               db.AddParameter("@Fax", Fax);
               db.AddParameter("@WebSite", WebSite);
               db.AddParameter("@Email", Email);
               db.AddParameter("@Logo", Logo);
               db.ExecuteNonQueryWithTransaction("COMPANY_Insert");
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
               db.AddParameter("@CompanyID", CompanyID);
               db.AddParameter("@CompanyName", CompanyName);
               db.AddParameter("@CompanyAddress", CompanyAddress);
               db.AddParameter("@CompanyTax", CompanyTax);
               db.AddParameter("@Tel", Tel);
               db.AddParameter("@Fax", Fax);
               db.AddParameter("@WebSite", WebSite);
               db.AddParameter("@Email", Email);
               db.AddParameter("@Logo", Logo);
               bool result = db.ExecuteNonQueryWithTransaction("COMPANY_Update");
               if (result)
               {
                   db.CommitTransaction();
                   Class.S_Log.Insert("Công ty", "Cập nhật thông tin công ty");
                   return true;
               }
               else
               {
                   db.RollbackTransaction();
                   return false;
               }
               
             
           }
           catch (Exception ex)
           {
               db.RollbackTransaction();
               Class.App.Log_Write(ex.Message);
               return false;
           }
       }
       /*
       public bool Delete()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@DegreeCode", DegreeCode);
               db.ExecuteNonQueryWithTransaction("DIC_DEGREE_Delete");
               db.CommitTransaction();
               return true;
           }
           catch
           {
               db.RollbackTransaction();
               return false;
           }
       } 
       */
   }
       
}
