using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_TonGiao
   {
       #region KhaiBao_Bien
       private string _ReligionCode;

       public string ReligionCode
       {
           get { return _ReligionCode; }
           set { _ReligionCode = value; }
       }
       private string _ReligionName;

       public string ReligionName
       {
           get { return _ReligionName; }
           set { _ReligionName = value; }
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

       public DataTable GetAllList_RELIGION()
        {
            string procname = "DIC_RELIGION_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_RELIGION_GetList";
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
                        return "TG00000" + next_id.ToString();
                    case 2:
                        return "TG0000" + next_id.ToString();
                    case 3:
                        return "TG000" + next_id.ToString();
                    case 4:
                        return "TG00" + next_id.ToString();
                    case 5:
                        return "TG0" + next_id.ToString();
                    case 6:
                        return "TG" + next_id.ToString();
                }
            }
            return "TG000001";

        }

        public DataTable GetReligionByCode(string strCode)
        {
            string procname = "DIC_RELIGION_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@ReligionCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@ReligionCode", ReligionCode);
                db.AddParameter("@ReligionName", ReligionName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_RELIGION_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Tôn giáo", "Thêm Tôn giáo: " + ReligionName);
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
                db.AddParameter("@ReligionCode", ReligionCode);
                db.AddParameter("@ReligionName", ReligionName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_RELIGION_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Tôn giáo", "Cập nhật Tôn giáo: " + ReligionName);
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
                db.AddParameter("@ReligionCode", ReligionCode);
                db.ExecuteNonQueryWithTransaction("DIC_RELIGION_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Tôn giáo", "Xóa Tôn giáo: " + ReligionCode);
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
