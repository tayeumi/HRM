using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class PhongBan
   {
       #region KhaiBao_Bien
       private string _BranchCode;

        public string BranchCode
        {
            get { return _BranchCode; }
            set { _BranchCode = value; }
        }

        private string _DepartmentCode;

        public string DepartmentCode
        {
            get { return _DepartmentCode; }
            set { _DepartmentCode = value; }
        }
        private string _DepartmentName;

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }
        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
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
       
       public DataTable LoadDanhSachChiNhanh()
       {
           string procname = "HRM_BRANCH_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public DataTable LoadDanhSachPhongBanThuocChiNhanh()
       {
           string procname = "HRM_DEPARTMENT_GetListByBranch";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@BranchCode", BranchCode); 
           return db.ExecuteDataTable(procname);
       }

       public DataTable LoadDanhSachNhomThuocPhongBan()
       {
           string procname = "HRM_GROUP_GetListByDepartment";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@DepartmentCode", DepartmentCode);
           return db.ExecuteDataTable(procname);
       }

       public DataTable GetAllList_DEPARTMENT()
       {
           string procname = "HRM_DEPARTMENT_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public string GetNewCode()
       {
           string procname = "HRM_DEPARTMENT_GetList";
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
                       return "PB00000" + next_id.ToString();
                   case 2:
                       return "PB0000" + next_id.ToString();
                   case 3:
                       return "PB000" + next_id.ToString();
                   case 4:
                       return "PB00" + next_id.ToString();
                   case 5:
                       return "PB0" + next_id.ToString();
                   case 6:
                       return "PB" + next_id.ToString();
               }
           }
           return "PB000001";

       }

       public DataTable GetDepartmentByCode(string strCode)
       {
           string procname = "HRM_DEPARTMENT_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@DepartmentCode", strCode);
           return db.ExecuteDataTable(procname);
       }

       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@DepartmentCode", DepartmentCode);
               db.AddParameter("@BranchCode", BranchCode);
               db.AddParameter("@DepartmentName", DepartmentName);
               db.AddParameter("@Phone", Phone);
               db.AddParameter("@Quantity", Quantity);
               db.AddParameter("@FactQuantity", FactQuantity);
               db.AddParameter("@Description", Description);
               db.ExecuteNonQueryWithTransaction("HRM_DEPARTMENT_Insert");
               db.CommitTransaction();
               Class.S_Log.Insert("Phòng ban", "Thêm Phòng ban: " + DepartmentName);
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
               db.AddParameter("@DepartmentCode", DepartmentCode);
               db.AddParameter("@BranchCode", BranchCode);
               db.AddParameter("@DepartmentName", DepartmentName);
               db.AddParameter("@Phone", Phone);
               db.AddParameter("@Quantity", Quantity);
               db.AddParameter("@FactQuantity", FactQuantity);
               db.AddParameter("@Description", Description);
               db.ExecuteNonQueryWithTransaction("HRM_DEPARTMENT_Update");
               db.CommitTransaction();
               Class.S_Log.Insert("Phòng ban", "Cập nhật Phòng ban: " + DepartmentName);
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
               db.AddParameter("@DepartmentCode", DepartmentCode);
               db.ExecuteNonQueryWithTransaction("HRM_DEPARTMENT_Delete");
               db.CommitTransaction();
               Class.S_Log.Insert("Phòng ban", "Xóa Phòng ban: " + DepartmentCode);
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
