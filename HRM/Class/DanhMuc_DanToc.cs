using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_DanToc
   {
       #region KhaiBao_bien
       private string _EthnicCode;

       public string EthnicCode
       {
           get { return _EthnicCode; }
           set { _EthnicCode = value; }
       }
       private string _EthnicName;

       public string EthnicName
       {
           get { return _EthnicName; }
           set { _EthnicName = value; }
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

       public DataTable GetAllList_ETHNIC()
        {
            string procname = "DIC_ETHNIC_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_ETHNIC_GetList";
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
                        return "DT00000" + next_id.ToString();
                    case 2:
                        return "DT0000" + next_id.ToString();
                    case 3:
                        return "DT000" + next_id.ToString();
                    case 4:
                        return "DT00" + next_id.ToString();
                    case 5:
                        return "DT0" + next_id.ToString();
                    case 6:
                        return "DT" + next_id.ToString();
                }
            }
            return "DT000001";

        }

        public DataTable GetEthnicByCode(string strCode)
        {
            string procname = "DIC_ETHNIC_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@EthnicCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@EthnicCode", EthnicCode);
                db.AddParameter("@EthnicName", EthnicName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_ETHNIC_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Dân Tộc", "Thêm Dân tộc: " + EthnicName);
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
                db.AddParameter("@EthnicCode", EthnicCode);
                db.AddParameter("@EthnicName", EthnicName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_ETHNIC_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Dân Tộc", "Cập nhật Dân tộc: " + EthnicName);
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
                db.AddParameter("@EthnicCode", EthnicCode);
                db.ExecuteNonQueryWithTransaction("DIC_ETHNIC_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Dân Tộc", "Xóa Dân tộc: " + EthnicCode);
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
