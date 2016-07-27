using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhSach_Nhom
   {
       #region KhaiBao_Bien
       private string _GroupCode;

       public string GroupCode
       {
           get { return _GroupCode; }
           set { _GroupCode = value; }
       }
       private string _DepartmentCode;

       public string DepartmentCode
       {
           get { return _DepartmentCode; }
           set { _DepartmentCode = value; }
       }
       private string _GroupName;

       public string GroupName
       {
           get { return _GroupName; }
           set { _GroupName = value; }
       }
       private int _Quantity;

       public int Quantity
       {
           get { return _Quantity; }
           set { _Quantity = value; }
       }
       private int _FactQuantity;

       public int FactQuantity
       {
           get { return _FactQuantity; }
           set { _FactQuantity = value; }
       }
       private string _Description;

       public string Description
       {
           get { return _Description; }
           set { _Description = value; }
       }
       #endregion

       public DataTable GetAllList_GROUP()
        {
            string procname = "HRM_GROUP_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "HRM_GROUP_GetList";
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
                        return "TN00000" + next_id.ToString();
                    case 2:
                        return "TN0000" + next_id.ToString();
                    case 3:
                        return "TN000" + next_id.ToString();
                    case 4:
                        return "TN00" + next_id.ToString();
                    case 5:
                        return "TN0" + next_id.ToString();
                    case 6:
                        return "TN" + next_id.ToString();
                }
            }
            return "TN000001";

        }

        public DataTable GetGroupByCode(string strCode)
        {
            string procname = "HRM_GROUP_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@GroupCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public DataTable GetGroupByDepartment()
        {
            string procname = "HRM_GROUP_GetListByDepartment";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@DepartmentCode", DepartmentCode);
            return db.ExecuteDataTable(procname);
        }
        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@GroupCode", GroupCode);
                db.AddParameter("@DepartmentCode", DepartmentCode);
                db.AddParameter("@GroupName", GroupName);
                db.AddParameter("@Quantity", Quantity);
                db.AddParameter("@FactQuantity", FactQuantity);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("HRM_GROUP_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Tổ nhóm", "Thêm Tổ nhóm: " + GroupName);
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
                db.AddParameter("@GroupCode", GroupCode);
                db.AddParameter("@DepartmentCode", DepartmentCode);
                db.AddParameter("@GroupName", GroupName);
                db.AddParameter("@Quantity", Quantity);
                db.AddParameter("@FactQuantity", FactQuantity);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("HRM_GROUP_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Tổ nhóm", "Cập nhật Tổ nhóm: " + GroupName);
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
                db.AddParameter("@GroupCode", GroupCode);
                db.ExecuteNonQueryWithTransaction("HRM_GROUP_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Tổ nhóm", "Xóa Tổ nhóm: " + GroupCode);
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
