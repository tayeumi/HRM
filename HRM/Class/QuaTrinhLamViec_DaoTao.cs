using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class QuaTrinhLamViec_DaoTao
   {
       #region Khai bao bien
       private string _TrainingID;

       public string TrainingID
       {
           get { return _TrainingID; }
           set { _TrainingID = value; }
       }
       private string _EmployeeCode;

       public string EmployeeCode
       {
           get { return _EmployeeCode; }
           set { _EmployeeCode = value; }
       }
       private string _TrainingName;

       public string TrainingName
       {
           get { return _TrainingName; }
           set { _TrainingName = value; }
       }
       private string _Reason;

       public string Reason
       {
           get { return _Reason; }
           set { _Reason = value; }
       }
       private string _Form;

       public string Form
       {
           get { return _Form; }
           set { _Form = value; }
       }
       private string _Time;

       public string Time
       {
           get { return _Time; }
           set { _Time = value; }
       }
       private DateTime _BeginDate;

       public DateTime BeginDate
       {
           get { return _BeginDate; }
           set { _BeginDate = value; }
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
       private string _FilePath;

       public string FilePath
       {
           get { return _FilePath; }
           set { _FilePath = value; }
       }
      
       #endregion

       public DataTable HRM_PROCESS_TRAINING_GetListByEmployee()
       {
           string procname = "HRM_PROCESS_TRAINING_GetListByEmployee";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", Class.App._manv);
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_PROCESS_TRAINING_Get()
       {
           string procname = "HRM_PROCESS_TRAINING_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@TrainingID", TrainingID);
           return db.ExecuteDataTable(procname);
       }


       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@TrainingID", TrainingID);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@TrainingName", TrainingName);
               db.AddParameter("@Reason", Reason);
               db.AddParameter("@Form", Form);
               db.AddParameter("@Time", Time);
               db.AddParameter("@BeginDate", BeginDate);
               db.AddParameter("@Date", Date);
               db.AddParameter("@DecideNumber", DecideNumber);
               db.AddParameter("@Person", Person);
               db.AddParameter("@FilePath", "");
               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_TRAINING_Insert");
               db.CommitTransaction();
              Class.S_Log.Insert("Quá trình làm việc", "Thêm thông tin đào tao: " + TrainingName + " - Nhân viên: "+Class.App._hotennv);
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
               db.AddParameter("@TrainingID", TrainingID);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@TrainingName", TrainingName);
               db.AddParameter("@Reason", Reason);
               db.AddParameter("@Form", Form);
               db.AddParameter("@Time", Time);
               db.AddParameter("@BeginDate", BeginDate);
               db.AddParameter("@Date", Date);
               db.AddParameter("@DecideNumber", DecideNumber);
               db.AddParameter("@Person", Person);
               db.AddParameter("@FilePath", "");
               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_TRAINING_Update");
               db.CommitTransaction();
               Class.S_Log.Insert("Quá trình làm việc", "Cập nhật thông tin đào tao: " + TrainingName + " - Nhân viên: "+Class.App._hotennv);
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
               db.AddParameter("@TrainingID", TrainingID);
               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_TRAINING_Delete");
               db.CommitTransaction();
             Class.S_Log.Insert("Quá trình làm việc", "Xóa thông tin đào tao Nhân viên: "+Class.App._hotennv);
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
