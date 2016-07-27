using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_QuocTich
   {
       #region KhaiBao_Bien
       private string _NationalityCode;

       public string NationalityCode
       {
           get { return _NationalityCode; }
           set { _NationalityCode = value; }
       }
       private string _NationalityName;

       public string NationalityName
       {
           get { return _NationalityName; }
           set { _NationalityName = value; }
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

       public DataTable GetAllList_NATIONALITY()
        {
            string procname = "DIC_NATIONALITY_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_NATIONALITY_GetList";
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
                        return "QT00000" + next_id.ToString();
                    case 2:
                        return "QT0000" + next_id.ToString();
                    case 3:
                        return "QT000" + next_id.ToString();
                    case 4:
                        return "QT00" + next_id.ToString();
                    case 5:
                        return "QT0" + next_id.ToString();
                    case 6:
                        return "QT" + next_id.ToString();
                }
            }
            return "QT000001";

        }

        public DataTable GetNationalityByCode(string strCode)
        {
            string procname = "DIC_NATIONALITY_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@NationalityCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@NationalityCode", NationalityCode);
                db.AddParameter("@NationalityName", NationalityName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_NATIONALITY_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Quốc tịch", "Thêm Quốc tịch: " + NationalityName);
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
                db.AddParameter("@NationalityCode", NationalityCode);
                db.AddParameter("@NationalityName", NationalityName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_NATIONALITY_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Quốc tịch", "Cập nhật Quốc tịch: " + NationalityName);
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
                db.AddParameter("@NationalityCode", NationalityCode);
                db.ExecuteNonQueryWithTransaction("DIC_NATIONALITY_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Quốc tịch", "Xóa Quốc tịch: " + NationalityCode);
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
