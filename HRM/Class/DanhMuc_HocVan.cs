using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_HocVan
   {
       #region KhaiBao_Bien
       private string _EducationCode;

       public string EducationCode
       {
           get { return _EducationCode; }
           set { _EducationCode = value; }
       }
       private string _EducationName;

       public string EducationName
       {
           get { return _EducationName; }
           set { _EducationName = value; }
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


       public DataTable GetAllList_EDUCATION()
        {
            string procname = "DIC_EDUCATION_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_EDUCATION_GetList";
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
                        return "HV00000" + next_id.ToString();
                    case 2:
                        return "HV0000" + next_id.ToString();
                    case 3:
                        return "HV000" + next_id.ToString();
                    case 4:
                        return "HV00" + next_id.ToString();
                    case 5:
                        return "HV0" + next_id.ToString();
                    case 6:
                        return "HV" + next_id.ToString();
                }
            }
            return "HV000001";

        }

        public DataTable GetEducationByCode(string strCode)
        {
            string procname = "DIC_EDUCATION_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@EducationCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@EducationCode", EducationCode);
                db.AddParameter("@EducationName", EducationName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_EDUCATION_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Học vấn", "Thêm Học vấn: " + EducationName);
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
                db.AddParameter("@EducationCode", EducationCode);
                db.AddParameter("@EducationName", EducationName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_EDUCATION_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Học vấn", "Cập nhật Học vấn: " + EducationName);
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
                db.AddParameter("@EducationCode", EducationCode);
                db.ExecuteNonQueryWithTransaction("DIC_EDUCATION_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Học vấn", "Xóa Học vấn: " + EducationCode);
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
