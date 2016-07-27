using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class QuaTrinhLamViec_KyLuat
   {
       #region KhaiBao Bien
       private string _DisciplineID;

       public string DisciplineID
       {
           get { return _DisciplineID; }
           set { _DisciplineID = value; }
       }
       private string _EmployeeCode;

       public string EmployeeCode
       {
           get { return _EmployeeCode; }
           set { _EmployeeCode = value; }
       }
       private string _DisciplineName;

       public string DisciplineName
       {
           get { return _DisciplineName; }
           set { _DisciplineName = value; }
       }
       private DateTime _DateOccurred;

       public DateTime DateOccurred
       {
           get { return _DateOccurred; }
           set { _DateOccurred = value; }
       }
       private string _Location;

       public string Location
       {
           get { return _Location; }
           set { _Location = value; }
       }
       private string _Description;

       public string Description
       {
           get { return _Description; }
           set { _Description = value; }
       }
       private string _Witnesses;

       public string Witnesses
       {
           get { return _Witnesses; }
           set { _Witnesses = value; }
       }
       private bool _Violations;

       public bool Violations
       {
           get { return _Violations; }
           set { _Violations = value; }
       }
       private string _Notes;

       public string Notes
       {
           get { return _Notes; }
           set { _Notes = value; }
       }
       private string _Form;

       public string Form
       {
           get { return _Form; }
           set { _Form = value; }
       }
       private bool _Settlement;

       public bool Settlement
       {
           get { return _Settlement; }
           set { _Settlement = value; }
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
       private string _FilePath;

       public string FilePath
       {
           get { return _FilePath; }
           set { _FilePath = value; }
       }

       #endregion

       public DataTable HRM_PROCESS_DISCIPLINE_GetListByEmployee()
       {
           string procname = "HRM_PROCESS_DISCIPLINE_GetListByEmployee";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@EmployeeCode", Class.App._manv);
           return db.ExecuteDataTable(procname);
       }
       public DataTable HRM_PROCESS_DISCIPLINE_Get()
       {
           string procname = "HRM_PROCESS_DISCIPLINE_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@DisciplineID", DisciplineID);
           return db.ExecuteDataTable(procname);
       }


       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@DisciplineID", DisciplineID);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@DisciplineName", DisciplineName);
               db.AddParameter("@DateOccurred", DateOccurred);
               db.AddParameter("@Location", Location);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Witnesses", Witnesses);
               db.AddParameter("@Violations", Violations);
               db.AddParameter("@Notes", Notes);
               db.AddParameter("@Form", Form);
               db.AddParameter("@Settlement", Settlement);
               db.AddParameter("@Reason", Reason);
               db.AddParameter("@Date", Date);
               db.AddParameter("@DecideNumber", DecideNumber);
               db.AddParameter("@Person", Person);
               db.AddParameter("@FilePath", "");
               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_DISCIPLINE_Insert");
               db.CommitTransaction();
              Class.S_Log.Insert("Quá trình làm việc", "Thêm thông tin kỷ luật Nhân viên: " + Class.App._hotennv);
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
               db.AddParameter("@DisciplineID", DisciplineID);
               db.AddParameter("@EmployeeCode", EmployeeCode);
               db.AddParameter("@DisciplineName", DisciplineName);
               db.AddParameter("@DateOccurred", DateOccurred);
               db.AddParameter("@Location", Location);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Witnesses", Witnesses);
               db.AddParameter("@Violations", Violations);
               db.AddParameter("@Notes", Notes);
               db.AddParameter("@Form", Form);
               db.AddParameter("@Settlement", Settlement);
               db.AddParameter("@Reason", Reason);
               db.AddParameter("@Date", Date);
               db.AddParameter("@DecideNumber", DecideNumber);
               db.AddParameter("@Person", Person);
               db.AddParameter("@FilePath", "");
               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_DISCIPLINE_Update");
               db.CommitTransaction();
               Class.S_Log.Insert("Quá trình làm việc", "Cập nhật thông tin kỷ luật Nhân viên: " + Class.App._hotennv);
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
               db.AddParameter("@DisciplineID", DisciplineID);
               db.ExecuteNonQueryWithTransaction("HRM_PROCESS_DISCIPLINE_Delete");
               db.CommitTransaction();
               Class.S_Log.Insert("Quá trình làm việc", "Xóa thông tin kỷ luật Nhân viên: " + Class.App._hotennv);
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
