using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class QuaTrinhLamViec_ChucVu
    {
        // thay doi chuc vu va phong ban
        #region khaibaobien
        private string _PositionID;

        public string PositionID
        {
            get { return _PositionID; }
            set { _PositionID = value; }
        }
        private string _EmployeeCode;

        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }
        private string _OldBranch;

        public string OldBranch
        {
            get { return _OldBranch; }
            set { _OldBranch = value; }
        }
        private string _OldDepartment;

        public string OldDepartment
        {
            get { return _OldDepartment; }
            set { _OldDepartment = value; }
        }
        private string _OldGroup;

        public string OldGroup
        {
            get { return _OldGroup; }
            set { _OldGroup = value; }
        }
        private string _OldPosition;

        public string OldPosition
        {
            get { return _OldPosition; }
            set { _OldPosition = value; }
        }
        private string _NewBranch;

        public string NewBranch
        {
            get { return _NewBranch; }
            set { _NewBranch = value; }
        }
        private string _NewDepartment;

        public string NewDepartment
        {
            get { return _NewDepartment; }
            set { _NewDepartment = value; }
        }
        private string _NewGroup;

        public string NewGroup
        {
            get { return _NewGroup; }
            set { _NewGroup = value; }
        }
        private string _NewPosition;

        public string NewPosition
        {
            get { return _NewPosition; }
            set { _NewPosition = value; }
        }
        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        private string _Reason;

        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        private string _DecideNumber;

        public string DecideNumber
        {
            get { return _DecideNumber; }
            set { _DecideNumber = value; }
        }
        private string _Person;

        public string Person
        {
            get { return _Person; }
            set { _Person = value; }
        }      
        #endregion
        public DataTable HRM_PROCESS_POSITION_GetListByEmployee()
        {
            string procname = "HRM_PROCESS_POSITION_GetListByEmployee";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@EmployeeCode", Class.App._manv);
            return db.ExecuteDataTable(procname);
        }
        public DataTable HRM_PROCESS_POSITION_Get()
        {
            string procname = "HRM_PROCESS_POSITION_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@PositionID", PositionID);
            return db.ExecuteDataTable(procname);
        }


        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@PositionID", PositionID);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@OldBranch", OldBranch);
                db.AddParameter("@OldDepartment", OldDepartment);
                db.AddParameter("@OldGroup", OldGroup);
                db.AddParameter("@OldPosition", OldPosition);
                db.AddParameter("@NewBranch", NewBranch);
                db.AddParameter("@NewDepartment", NewDepartment);
                db.AddParameter("@NewGroup", NewGroup);
                db.AddParameter("@NewPosition", NewPosition);
                db.AddParameter("@Date", Date);
                db.AddParameter("@Reason", Reason);
                db.AddParameter("@DecideNumber", DecideNumber);
                db.AddParameter("@Person", Person);
                db.ExecuteNonQueryWithTransaction("HRM_PROCESS_POSITION_Insert");
                //db.CreateNewSqlCommand();
                //db.AddParameter("@EmployeeCode", EmployeeCode);
                //db.AddParameter("@BranchCode", NewBranch);
              //  db.AddParameter("@DepartmentCode", NewDepartment);
               // db.AddParameter("@GroupCode", NewGroup);
               // db.AddParameter("@Position", NewPosition);
               // db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_UpdatePosition");
              //  db.CreateNewSqlCommand();
              //  db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Count");
                db.CommitTransaction();
                Class.S_Log.Insert("Quá trình làm việc", "Thêm thay đổi thông tin Chứa vụ, phòng ban Nhân viên: "+Class.App._hotennv);
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
                db.AddParameter("@PositionID", PositionID);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@OldBranch", OldBranch);
                db.AddParameter("@OldDepartment", OldDepartment);
                db.AddParameter("@OldGroup", OldGroup);
                db.AddParameter("@OldPosition", OldPosition);
                db.AddParameter("@NewBranch", NewBranch);
                db.AddParameter("@NewDepartment", NewDepartment);
                db.AddParameter("@NewGroup", NewGroup);
                db.AddParameter("@NewPosition", NewPosition);
                db.AddParameter("@Date", Date);
                db.AddParameter("@Reason", Reason);
                db.AddParameter("@DecideNumber", DecideNumber);
                db.AddParameter("@Person", Person);
                db.ExecuteNonQueryWithTransaction("HRM_PROCESS_POSITION_Update");

            //    db.CreateNewSqlCommand();
            //    db.AddParameter("@EmployeeCode", EmployeeCode);
             //   db.AddParameter("@BranchCode", NewBranch);
              //  db.AddParameter("@DepartmentCode", NewDepartment);
              //  db.AddParameter("@GroupCode", NewGroup);
              //  db.AddParameter("@Position", NewPosition);
                //db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_UpdatePosition");

              //  db.CreateNewSqlCommand();
               // db.ExecuteNonQueryWithTransaction("HRM_EMPLOYEE_Count");
                db.CommitTransaction();
                Class.S_Log.Insert("Quá trình làm việc", "Cập nhật thông tin Chứa vụ, phòng ban Nhân viên: "+Class.App._hotennv);
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
                db.AddParameter("@PositionID", PositionID);
                db.ExecuteNonQueryWithTransaction("HRM_PROCESS_POSITION_Delete");
                db.CommitTransaction();
              Class.S_Log.Insert("Quá trình làm việc", "Xóa thông tin chức vụ phòng ban: "+Class.App._hotennv);
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
