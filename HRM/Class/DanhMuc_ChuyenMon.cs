using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_ChuyenMon
   {
       #region KhaiBao_Bien
       private string _ProfessionalCode;

       public string ProfessionalCode
       {
           get { return _ProfessionalCode; }
           set { _ProfessionalCode = value; }
       }
       private string _ProfessionalName;

       public string ProfessionalName
       {
           get { return _ProfessionalName; }
           set { _ProfessionalName = value; }
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
       public string GetNewCode()
       {
           string procname = "DIC_PROFESSIONAL_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           DataTable dt = db.ExecuteDataTable(procname);
           if (dt.Rows.Count > 0)
           {
               string _strCode = dt.Rows[dt.Rows.Count - 1][0].ToString();
               _strCode = _strCode.Substring(2, _strCode.Length - 2);
               int next_id = int.Parse(_strCode) + 1;
               switch (next_id.ToString().Length)
               {
                   case 1:
                       return "CM00000" + next_id.ToString();
                   case 2:
                       return "CM0000" + next_id.ToString();
                   case 3:
                       return "CM000" + next_id.ToString();
                   case 4:
                       return "CM00" + next_id.ToString();
                   case 5:
                       return "CM0" + next_id.ToString();
                   case 6:
                       return "CM" + next_id.ToString();
               }
           }
           return "CM000001";

       }

       public DataTable GetAllList_PROFESSIONAL()
       {
          
           string procname = "DIC_PROFESSIONAL_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
       public DataTable GetProfessionalByCode(string strCode)
       {
           string procname = "DIC_PROFESSIONAL_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@ProfessionalCode", strCode);
           return db.ExecuteDataTable(procname);
       }

       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();

           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@ProfessionalCode", ProfessionalCode);
               db.AddParameter("@ProfessionalName", ProfessionalName);              
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("DIC_PROFESSIONAL_Insert");
               db.CommitTransaction();
               Class.S_Log.Insert("Chuyên môn", "Thêm chuyên môn: " + ProfessionalName);
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
               db.AddParameter("@ProfessionalCode", ProfessionalCode);
               db.AddParameter("@ProfessionalName", ProfessionalName);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("DIC_PROFESSIONAL_Update");
               db.CommitTransaction();
               Class.S_Log.Insert("Chuyên môn", "Cập nhật chuyên môn: " + ProfessionalName);
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
               db.AddParameter("@ProfessionalCode", ProfessionalCode);
               db.ExecuteNonQueryWithTransaction("DIC_PROFESSIONAL_Delete");
               db.CommitTransaction();
               Class.S_Log.Insert("Chuyên môn", "Xóa chuyên môn: " + ProfessionalCode);
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
