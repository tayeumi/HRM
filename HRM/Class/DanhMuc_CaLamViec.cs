using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
    class DanhMuc_CaLamViec
    {
        #region khai bao bien
        private string _ShiftCode;

        public string ShiftCode
        {
            get { return _ShiftCode; }
            set { _ShiftCode = value; }
        }
        private string _ShiftName;

        public string ShiftName
        {
            get { return _ShiftName; }
            set { _ShiftName = value; }
        }
        private DateTime _BeginTime;

        public DateTime BeginTime
        {
            get { return _BeginTime; }
            set { _BeginTime = value; }
        }
        private DateTime _EndTime;

        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        #endregion


        public DataTable DIC_SHIFT_GetList()
        {
            string procname = "DIC_SHIFT_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            string procname = "DIC_SHIFT_GetList";
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
                        return "CA00000" + next_id.ToString();
                    case 2:
                        return "CA0000" + next_id.ToString();
                    case 3:
                        return "CA000" + next_id.ToString();
                    case 4:
                        return "CA00" + next_id.ToString();
                    case 5:
                        return "CA0" + next_id.ToString();
                    case 6:
                        return "CA" + next_id.ToString();
                }
            }
            return "CA000001";

        }

        public DataTable GetShiftByCode(string strCode)
        {
            string procname = "DIC_SHIFT_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@ShiftCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@ShiftCode", ShiftCode);
                db.AddParameter("@ShiftName", ShiftName);
                db.AddParameter("@BeginTime", BeginTime);
                db.AddParameter("@EndTime", EndTime);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("DIC_SHIFT_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Ca làm việc", "Ca làm việc: " + ShiftName);
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
                db.AddParameter("@ShiftCode", ShiftCode);
                db.AddParameter("@ShiftName", ShiftName);
                db.AddParameter("@BeginTime", BeginTime);
                db.AddParameter("@EndTime", EndTime);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("DIC_SHIFT_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Ca làm việc", "Cập nhật Ca làm việc: " + ShiftName);
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
                db.AddParameter("@ShiftCode", ShiftCode);
                db.ExecuteNonQueryWithTransaction("DIC_SHIFT_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Ca làm việc", "Xóa a làm việc: " + ShiftCode);
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
