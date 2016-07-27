using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
    class DanhMuc_KyHieuChamCong
    {
        #region KhaiBaoBien
        private string _SymbolCode;

        public string SymbolCode
        {
            get { return _SymbolCode; }
            set { _SymbolCode = value; }
        }
        private string _SymbolName;

        public string SymbolName
        {
            get { return _SymbolName; }
            set { _SymbolName = value; }
        }
        private int _PercentSalary;

        public int PercentSalary
        {
            get { return _PercentSalary; }
            set { _PercentSalary = value; }
        }
        private bool _IsEdit;

        public bool IsEdit
        {
            get { return _IsEdit; }
            set { _IsEdit = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


        #endregion

        public DataTable DIC_SYMBOL_GetList()
        {
            string procname = "DIC_SYMBOL_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {            
            return "";
        }

        public DataTable GetSymbolByCode(string strCode)
        {
            string procname = "DIC_SYMBOL_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@SymbolCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@SymbolCode", SymbolCode);
                db.AddParameter("@SymbolName", SymbolName);
                db.AddParameter("@PercentSalary", PercentSalary);
                db.AddParameter("@IsEdit", IsEdit);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("DIC_SYMBOL_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Ký hiệu chấm công", "Thêm Ký hiệu chấm công: " + SymbolName);
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
                db.AddParameter("@SymbolCode", SymbolCode);
                db.AddParameter("@SymbolName", SymbolName);
                db.AddParameter("@PercentSalary", PercentSalary);
                db.AddParameter("@IsEdit", IsEdit);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("DIC_SYMBOL_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Ký hiệu chấm công", "Cập nhật Ký hiệu chấm công: " + SymbolName);
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
                db.AddParameter("@SymbolCode", SymbolCode);
                db.ExecuteNonQueryWithTransaction("DIC_SYMBOL_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Ký hiệu chấm công", "Xóa Ký hiệu chấm công: " + SymbolCode);
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
