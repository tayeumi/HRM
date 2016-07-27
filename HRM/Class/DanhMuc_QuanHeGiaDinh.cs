using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_QuanHeGiaDinh
   {
       #region KhaiBao_Bien
       private string _RelativeCode;

       public string RelativeCode
       {
           get { return _RelativeCode; }
           set { _RelativeCode = value; }
       }
       private string _RelativeName;

       public string RelativeName
       {
           get { return _RelativeName; }
           set { _RelativeName = value; }
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

       public DataTable GetAllList_RELATIVE()
        {
            string procname = "DIC_RELATIVE_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_RELATIVE_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            DataTable dt = db.ExecuteDataTable(procname);
            if (dt.Rows.Count > 0)
            {
                string _strCode = dt.Rows[dt.Rows.Count - 1][0].ToString();
                _strCode = _strCode.Substring(4, _strCode.Length - 4);
                int next_id = int.Parse(_strCode) + 1;
                switch (next_id.ToString().Length)
                {
                    case 1:
                        return "QHGD00000" + next_id.ToString();
                    case 2:
                        return "QHGD0000" + next_id.ToString();
                    case 3:
                        return "QHGD000" + next_id.ToString();
                    case 4:
                        return "QHGD00" + next_id.ToString();
                    case 5:
                        return "QHGD0" + next_id.ToString();
                    case 6:
                        return "QHGD" + next_id.ToString();
                }
            }
            return "QHGD000001";

        }

        public DataTable GetRelativeByCode(string strCode)
        {
            string procname = "DIC_RELATIVE_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@RelativeCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@RelativeCode", RelativeCode);
                db.AddParameter("@RelativeName", RelativeName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_RELATIVE_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Quan hệ gia đình", "Thêm Quan hệ gia đình: " + RelativeName);
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
                db.AddParameter("@RelativeCode", RelativeCode);
                db.AddParameter("@RelativeName", RelativeName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_RELATIVE_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Quan hệ gia đình", "Cập nhật Quan hệ gia đình: " + RelativeName);
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
                db.AddParameter("@RelativeCode", RelativeCode);
                db.ExecuteNonQueryWithTransaction("DIC_RELATIVE_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Quan hệ gia đình", "Xóa Quan hệ gia đình: " + RelativeCode);
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
