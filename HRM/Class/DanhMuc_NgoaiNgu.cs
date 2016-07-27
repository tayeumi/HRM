using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_NgoaiNgu
   {
       #region KhaiBao_Bien
       private string _LanguageCode;

       public string LanguageCode
       {
           get { return _LanguageCode; }
           set { _LanguageCode = value; }
       }
       private string _LanguageName;

       public string LanguageName
       {
           get { return _LanguageName; }
           set { _LanguageName = value; }
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

       public DataTable GetAllList_LANGUAGE()
        {
            string procname = "DIC_LANGUAGE_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_LANGUAGE_GetList";
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
                        return "NN00000" + next_id.ToString();
                    case 2:
                        return "NN0000" + next_id.ToString();
                    case 3:
                        return "NN000" + next_id.ToString();
                    case 4:
                        return "NN00" + next_id.ToString();
                    case 5:
                        return "NN0" + next_id.ToString();
                    case 6:
                        return "NN" + next_id.ToString();
                }
            }
            return "NN000001";

        }

        public DataTable GetLanguageByCode(string strCode)
        {
            string procname = "DIC_LANGUAGE_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@LanguageCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@LanguageCode", LanguageCode);
                db.AddParameter("@LanguageName", LanguageName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_LANGUAGE_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Ngoại ngữ", "Thêm Ngoại ngữ: " + LanguageName);
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
                db.AddParameter("@LanguageCode", LanguageCode);
                db.AddParameter("@LanguageName", LanguageName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_LANGUAGE_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Ngoại ngữ", "Cập nhật Ngoại ngữ: " + LanguageName);
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
                db.AddParameter("@LanguageCode", LanguageCode);
                db.ExecuteNonQueryWithTransaction("DIC_LANGUAGE_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Ngoại ngữ", "Xóa Ngoại ngữ: " + LanguageCode);
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
