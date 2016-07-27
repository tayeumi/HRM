using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class QuaTrinhLamViec_KhenThuong
   {
       #region khaibaobien
       private string _RewardID;

       public string RewardID
       {
           get { return _RewardID; }
           set { _RewardID = value; }
       }
       private string _EmployeeCode;

       public string EmployeeCode
       {
           get { return _EmployeeCode; }
           set { _EmployeeCode = value; }
       }
       private string _Foundation;

       public string Foundation
       {
           get { return _Foundation; }
           set { _Foundation = value; }
       }
       private string _Form;

       public string Form
       {
           get { return _Form; }
           set { _Form = value; }
       }
       private string _Reason;

       public string Reason
       {
           get { return _Reason; }
           set { _Reason = value; }
       }
       private DateTime _Date;

       public DateTime Date
       {
           get { return _Date; }
           set { _Date = value; }
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

       public DataTable HRM_PROCESS_REWARD_GetListByEmployee()
       {
           string procname = "HRM_PROCESS_REWARD_GetListByEmployee";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", Class.App._manv);
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_PROCESS_REWARD_Get()
       {
           string procname = "HRM_PROCESS_REWARD_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@RewardID", RewardID);
           return db.ExecuteDataTable(procname);
       }


       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@RewardID", RewardID);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@Foundation", Foundation);
               db.AddParameter("@Reason", Reason);
               db.AddParameter("@Form", Form);
               db.AddParameter("@Date", Date);
               db.AddParameter("@DecideNumber", DecideNumber);
               db.AddParameter("@Person", Person);

               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_REWARD_Insert");
               db.CommitTransaction();
               Class.S_Log.Insert("Quá trình làm việc", "Thêm thông tin khen thưởng Nhân viên: " + Class.App._hotennv);
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
               db.AddParameter("@RewardID", RewardID);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@Foundation", Foundation);
               db.AddParameter("@Reason", Reason);
               db.AddParameter("@Form", Form);
               db.AddParameter("@Date", Date);
               db.AddParameter("@DecideNumber", DecideNumber);
               db.AddParameter("@Person", Person);

               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_REWARD_Update");
               db.CommitTransaction();
              Class.S_Log.Insert("Quá trình làm việc", "Cập nhật thông tin khen thưởng Nhân viên: " + Class.App._hotennv);
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
               db.AddParameter("@RewardID", RewardID);
               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_REWARD_Delete");
               db.CommitTransaction();
               Class.S_Log.Insert("Quá trình làm việc", "Xóa thông tin khen thưởng Nhân viên: " + Class.App._hotennv);
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
