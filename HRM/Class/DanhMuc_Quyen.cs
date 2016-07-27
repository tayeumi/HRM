using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_Quyen
   {
       #region KhaiBao_Bien
       private string _ID;

       public string ID
       {
           get { return _ID; }
           set { _ID = value; }
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
       #endregion

       public DataTable GetAllList_OBJECT()
       {
           string procname = "HRM_OBJECT_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       
       public DataTable GetObjectByCode(string strCode)
       {
           string procname = "HRM_OBJECT_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@ID", strCode);
           return db.ExecuteDataTable(procname);
       }

       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@ID", ID);
               db.AddParameter("@Object_ID", Object_ID);
               db.AddParameter("@Object_Name", Object_Name);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("HRM_OBJECT_Insert");
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
               db.AddParameter("@ID", ID);
               db.AddParameter("@Object_ID", Object_ID);
               db.AddParameter("@Object_Name", Object_Name);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("HRM_OBJECT_Update");
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
               db.AddParameter("@ID", ID);
               db.ExecuteNonQueryWithTransaction("HRM_OBJECT_Delete");
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
