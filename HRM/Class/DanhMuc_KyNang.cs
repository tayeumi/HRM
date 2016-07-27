using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_KyNang
   {
       #region KhaiBao_Bien
       private string _SkillCode;

       public string SkillCode
       {
           get { return _SkillCode; }
           set { _SkillCode = value; }
       }
       private string _SkillName;

       public string SkillName
       {
           get { return _SkillName; }
           set { _SkillName = value; }
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
       public DataTable GetAllList_SKILL()
        {
            string procname = "DIC_SKILL_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_SKILL_GetList";
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
                        return "KN00000" + next_id.ToString();
                    case 2:
                        return "KN0000" + next_id.ToString();
                    case 3:
                        return "KN000" + next_id.ToString();
                    case 4:
                        return "KN00" + next_id.ToString();
                    case 5:
                        return "KN0" + next_id.ToString();
                    case 6:
                        return "KN" + next_id.ToString();
                }
            }
            return "KN000001";

        }

        public DataTable GetSkillByCode(string strCode)
        {
            string procname = "DIC_SKILL_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@SkillCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@SkillCode", SkillCode);
                db.AddParameter("@SkillName", SkillName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_SKILL_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Kỹ năng", "Thêm Kỹ năng: " + SkillName);
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
                db.AddParameter("@SkillCode", SkillCode);
                db.AddParameter("@SkillName", SkillName);
                db.AddParameter("@Description", Description);
                db.AddParameter("@Active", Active);
                db.ExecuteNonQueryWithTransaction("DIC_SKILL_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Kỹ năng", "Cập nhật Kỹ năng: " + SkillName);
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
                db.AddParameter("@SkillCode", SkillCode);
                db.ExecuteNonQueryWithTransaction("DIC_SKILL_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Kỹ năng", "Xóa Kỹ năng: " + SkillCode);
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
