using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
    class ChamCong_BangXepCa
    {
        #region Khai Bao Bien
        private string _TimeKeeperTableListID;

        public string TimeKeeperTableListID
        {
            get { return _TimeKeeperTableListID; }
            set { _TimeKeeperTableListID = value; }
        }
        private string _TimeKeeperTableListName;

        public string TimeKeeperTableListName
        {
            get { return _TimeKeeperTableListName; }
            set { _TimeKeeperTableListName = value; }
        }
        private int _Month;

        public int Month
        {
            get { return _Month; }
            set { _Month = value; }
        }
        private int _Year;

        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        private bool _IsLock;

        public bool IsLock
        {
            get { return _IsLock; }
            set { _IsLock = value; }
        }
        private bool _IsFinish;

        public bool IsFinish
        {
            get { return _IsFinish; }
            set { _IsFinish = value; }
        }

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
        private string _EmployeeCode;

        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }

        private string _GroupCode;

        public string GroupCode
        {
            get { return _GroupCode; }
            set { _GroupCode = value; }
        }

        private string _ShiftCode;

        public string ShiftCode
        {
            get { return _ShiftCode; }
            set { _ShiftCode = value; }
        }

        private string _TimeKeeperTableListIDFrom;

        public string TimeKeeperTableListIDFrom
        {
            get { return _TimeKeeperTableListIDFrom; }
            set { _TimeKeeperTableListIDFrom = value; }
        }
        private string _TimeKeeperTableListIDTo;

        public string TimeKeeperTableListIDTo
        {
            get { return _TimeKeeperTableListIDTo; }
            set { _TimeKeeperTableListIDTo = value; }
        }
        #endregion

        public DataTable HRM_TIMEKEEPER_TABLELIST_GetList()
        {
            string procname = "HRM_TIMEKEEPER_TABLELIST_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
       

        public DataTable HRM_TIMEKEEPER_TABLELIST_Get()
        {
            string procname = "HRM_TIMEKEEPER_TABLELIST_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@Month", Month);
            db.AddParameter("@Year", Year);
            return db.ExecuteDataTable(procname);
        }
        public DataTable HRM_TIMEKEEPER_SHIFT_GetList()
        {
            string procname = "HRM_TIMEKEEPER_SHIFT_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID); 
            DataTable dt= db.ExecuteDataTable(procname);
            dt.Columns.Add("IsUpdate");
            return dt;
        }

        public DataTable HRM_TIMEKEEPER_SHIFT_GetListByBranch()
        {
            string procname = "HRM_TIMEKEEPER_SHIFT_GetListByBranch";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            db.AddParameter("@BranchCode", BranchCode);
            DataTable dt = db.ExecuteDataTable(procname);
            dt.Columns.Add("IsUpdate");
            return dt;
        }
        public DataTable HRM_TIMEKEEPER_SHIFT_GetListByDepartment()
        {
            string procname = "HRM_TIMEKEEPER_SHIFT_GetListByDepartment";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            db.AddParameter("@DepartmentCode", DepartmentCode);
            DataTable dt = db.ExecuteDataTable(procname);
            dt.Columns.Add("IsUpdate");
            return dt;
        }
        public DataTable HRM_TIMEKEEPER_SHIFT_GetListByEmployee()
        {
            string procname = "HRM_TIMEKEEPER_SHIFT_GetListByEmployee";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            db.AddParameter("@EmployeeCode", EmployeeCode);
            DataTable dt = db.ExecuteDataTable(procname);
            dt.Columns.Add("IsUpdate");
            return dt;
        }

        public DataTable HRM_TIMEKEEPER_SHIFT_GetListByGroup()
        {
            string procname = "HRM_TIMEKEEPER_SHIFT_GetListByGroup";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            db.AddParameter("@GroupCode", GroupCode);
            DataTable dt = db.ExecuteDataTable(procname);
            dt.Columns.Add("IsUpdate");
            return dt;
        }
        public DataTable HRM_TIMEKEEPER_TABLELIST_GetByID()
        {
            string procname = "HRM_TIMEKEEPER_TABLELIST_GetByID";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);     
            DataTable dt = db.ExecuteDataTable(procname);           
            return dt;
        }
        public bool HRM_TIMEKEEPER_TABLELIST_Reset()
        {

            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {  
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLELIST_Delete");
                TimeKeeperTableListID = Guid.NewGuid().ToString();

                IsLock = false;
                IsFinish = false;
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.AddParameter("@TimeKeeperTableListName", TimeKeeperTableListName);
                db.AddParameter("@Month", Month);
                db.AddParameter("@Year", Year);
                db.AddParameter("@IsLock", IsLock);
                db.AddParameter("@IsFinish", IsFinish);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLELIST_Insert");

                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_SHIFT_Create");

                db.CommitTransaction();               
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                IsLock = false;
                IsFinish = false;
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.AddParameter("@TimeKeeperTableListName", TimeKeeperTableListName);
                db.AddParameter("@Month", Month);
                db.AddParameter("@Year", Year);
                db.AddParameter("@IsLock", IsLock);
                db.AddParameter("@IsFinish", IsFinish);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLELIST_Insert");

                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_SHIFT_Create");

                db.CommitTransaction();
               // Class.S_Log.Insert("Chức vụ", "Thêm Chức vụ " + PositionName);
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public bool Update(DataTable Data)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < Data.Rows.Count; i++)
                {
                    if (Data.Rows[i]["IsUpdate"].ToString() == "1")
                    {
                        db.CreateNewSqlCommand();
                        db.AddParameter("@TimeKeeperTableListID", Data.Rows[i]["TimeKeeperTableListID"].ToString());
                        db.AddParameter("@EmployeeCode", Data.Rows[i]["EmployeeCode"].ToString());
                        db.AddParameter("@ShiftCode", Data.Rows[i]["ShiftCode"].ToString());
                        db.AddParameter("@AllDay", (bool)Data.Rows[i]["AllDay"]);
                        db.AddParameter("@D1", Data.Rows[i]["D1"].ToString());
                        db.AddParameter("@D2", Data.Rows[i]["D2"].ToString());
                        db.AddParameter("@D3", Data.Rows[i]["D3"].ToString());
                        db.AddParameter("@D4", Data.Rows[i]["D4"].ToString());
                        db.AddParameter("@D5", Data.Rows[i]["D5"].ToString());
                        db.AddParameter("@D6", Data.Rows[i]["D6"].ToString());
                        db.AddParameter("@D7", Data.Rows[i]["D7"].ToString());
                        db.AddParameter("@D8", Data.Rows[i]["D8"].ToString());
                        db.AddParameter("@D9", Data.Rows[i]["D9"].ToString());
                        db.AddParameter("@D10", Data.Rows[i]["D10"].ToString());
                        db.AddParameter("@D11", Data.Rows[i]["D11"].ToString());
                        db.AddParameter("@D12", Data.Rows[i]["D12"].ToString());
                        db.AddParameter("@D13", Data.Rows[i]["D13"].ToString());
                        db.AddParameter("@D14", Data.Rows[i]["D14"].ToString());
                        db.AddParameter("@D15", Data.Rows[i]["D15"].ToString());
                        db.AddParameter("@D16", Data.Rows[i]["D16"].ToString());
                        db.AddParameter("@D17", Data.Rows[i]["D17"].ToString());
                        db.AddParameter("@D18", Data.Rows[i]["D18"].ToString());
                        db.AddParameter("@D19", Data.Rows[i]["D19"].ToString());
                        db.AddParameter("@D20", Data.Rows[i]["D20"].ToString());
                        db.AddParameter("@D21", Data.Rows[i]["D21"].ToString());
                        db.AddParameter("@D22", Data.Rows[i]["D22"].ToString());
                        db.AddParameter("@D23", Data.Rows[i]["D23"].ToString());
                        db.AddParameter("@D24", Data.Rows[i]["D24"].ToString());
                        db.AddParameter("@D25", Data.Rows[i]["D25"].ToString());
                        db.AddParameter("@D26", Data.Rows[i]["D26"].ToString());
                        db.AddParameter("@D27", Data.Rows[i]["D27"].ToString());
                        db.AddParameter("@D28", Data.Rows[i]["D28"].ToString());
                        db.AddParameter("@D29", Data.Rows[i]["D29"].ToString());
                        db.AddParameter("@D30", Data.Rows[i]["D30"].ToString());
                        db.AddParameter("@D31", Data.Rows[i]["D31"].ToString());
                        db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_SHIFT_Update");
                      //  Class.S_Log.Insert("Chấm công", "Cập nhật Bảng xếp ca nhân viên: " + Data.Rows[i]["FirstName"].ToString() + " " + Data.Rows[i]["LastName"].ToString());
                        db.CreateNewSqlCommand();
                        db.AddParameter("@UserName", S_Log.UserName);
                        db.AddParameter("@Created", DateTime.Now);
                        db.AddParameter("@Module", "Chấm công");
                        db.AddParameter("@IPLan", S_Log.IPLan);
                        db.AddParameter("@PCName", S_Log.PCName);
                        db.AddParameter("@Description", S_Log.Description + Data.Rows[i]["FirstName"].ToString() + " " + Data.Rows[i]["LastName"].ToString());
                        db.AddParameter("@Active", true);
                        db.ExecuteNonQueryWithTransaction("HRM_LOG_Insert");
                    }
                }
                db.CommitTransaction();
                // Class.S_Log.Insert("Chấm công", " Cập nhật Bảng xếp ca " + PositionName);
                return true;
            }
            catch(Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public bool HRM_TIMEKEEPER_SHIFT_UpdateNewEmployee()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {               
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_SHIFT_UpdateNewEmployee");
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public bool HRM_TIMEKEEPER_SHIFT_UpdateFromOld()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListIDFrom", TimeKeeperTableListIDFrom);
                db.AddParameter("@TimeKeeperTableListIDTo", TimeKeeperTableListIDTo);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_SHIFT_UpdateFromOld");
                db.CommitTransaction();
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
