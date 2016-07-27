using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhSach_ChiNhanh
   {
       #region KhaiBao_Bien
       private string _BranchCode;

       public string BranchCode
       {
           get { return _BranchCode; }
           set { _BranchCode = value; }
       }
       private string _BranchName;

       public string BranchName
       {
           get { return _BranchName; }
           set { _BranchName = value; }
       }
       private string _Address;

       public string Address
       {
           get { return _Address; }
           set { _Address = value; }
       }
       private string _Phone;

       public string Phone
       {
           get { return _Phone; }
           set { _Phone = value; }
       }
       private string _Fax;

       public string Fax
       {
           get { return _Fax; }
           set { _Fax = value; }
       }
       private decimal _MinimumSalary;

       public decimal MinimumSalary
       {
           get { return _MinimumSalary; }
           set { _MinimumSalary = value; }
       }
       private string _PersonName;

       public string PersonName
       {
           get { return _PersonName; }
           set { _PersonName = value; }
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

       public DataTable GetAllList_BRANCH()
        {
            string procname = "HRM_BRANCH_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "HRM_BRANCH_GetList";
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
                        return "CN00000" + next_id.ToString();
                    case 2:
                        return "CN0000" + next_id.ToString();
                    case 3:
                        return "CN000" + next_id.ToString();
                    case 4:
                        return "CN00" + next_id.ToString();
                    case 5:
                        return "CN0" + next_id.ToString();
                    case 6:
                        return "CN" + next_id.ToString();
                }
            }
            return "CN000001";

        }

        public DataTable GetBranchByCode(string strCode)
        {
            string procname = "HRM_BRANCH_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@BranchCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@BranchCode", BranchCode);
                db.AddParameter("@BranchName", BranchName);
                db.AddParameter("@Address", Address);
                db.AddParameter("@Phone", Phone);
                db.AddParameter("@Fax", Fax);
                db.AddParameter("@MinimumSalary", MinimumSalary);
                db.AddParameter("@PersonName", PersonName);
                db.AddParameter("@Quantity", Quantity);
                db.AddParameter("@FactQuantity", FactQuantity);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("HRM_BRANCH_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Chi nhánh", "Thêm Chi nhánh: " + BranchName);
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
                db.AddParameter("@BranchCode", BranchCode);
                db.AddParameter("@BranchName", BranchName);
                db.AddParameter("@Address", Address);
                db.AddParameter("@Phone", Phone);
                db.AddParameter("@Fax", Fax);
                db.AddParameter("@MinimumSalary", MinimumSalary);
                db.AddParameter("@PersonName", PersonName);
                db.AddParameter("@Quantity", Quantity);
                db.AddParameter("@FactQuantity", FactQuantity);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("HRM_BRANCH_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Chi nhánh", "Cập nhật Chi nhánh: " + BranchName);
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
                db.AddParameter("@BranchCode", BranchCode);
                db.ExecuteNonQueryWithTransaction("HRM_BRANCH_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Chi nhánh", "Xóa Chi nhánh: " + BranchCode);
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
