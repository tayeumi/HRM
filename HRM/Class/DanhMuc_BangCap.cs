using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
  public class DanhMuc_BangCap
  {
      #region KhaiBao_Bien
      private string _DegreeCode;

      public string DegreeCode
      {
          get { return _DegreeCode; }
          set { _DegreeCode = value; }
      }
      private string _DegreeName;

      public string DegreeName
      {
          get { return _DegreeName; }
          set { _DegreeName = value; }
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

      public DataTable GetAllList_DIC_DEGREE()
        {
          
            string procname = "DIC_DEGREE_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_DEGREE_GetList";
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
                        return "BC00000" + next_id.ToString();
                    case 2:
                        return "BC0000" + next_id.ToString();
                    case 3:
                        return "BC000" + next_id.ToString();
                    case 4:
                        return "BC00" + next_id.ToString();
                    case 5:
                        return "BC0" + next_id.ToString();
                    case 6:
                        return "BC" + next_id.ToString();
                }
            }
            return "BC000001";

        }

        public DataTable GetDegreeByCode(string strCode)
        {
            string procname = "DIC_DEGREE_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@DegreeCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@DegreeCode", DegreeCode);
                db.AddParameter("@DegreeName", DegreeName);               
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_DEGREE_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Bằng Cấp", "Thêm bằng cấp: " + DegreeName);
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
                db.AddParameter("@DegreeCode", DegreeCode);
                db.AddParameter("@DegreeName", DegreeName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_DEGREE_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Bằng Cấp", "Cập nhật bằng cấp: " + DegreeName);
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
                db.AddParameter("@DegreeCode", DegreeCode);
                db.ExecuteNonQueryWithTransaction("DIC_DEGREE_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Bằng Cấp", "Xóa bằng cấp: " + DegreeCode);
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
