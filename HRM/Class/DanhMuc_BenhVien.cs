using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_BenhVien
   {
       #region KhaiBao_Bien
       private string _HospitalCode;

       public string HospitalCode
       {
           get { return _HospitalCode; }
           set { _HospitalCode = value; }
       }
       private string _ProvinceCode;

       public string ProvinceCode
       {
           get { return _ProvinceCode; }
           set { _ProvinceCode = value; }
       }
       private string _HospitalName;

       public string HospitalName
       {
           get { return _HospitalName; }
           set { _HospitalName = value; }
       }
       private string _Description;

       public string Description
       {
           get { return _Description; }
           set { _Description = value; }
       }
       private bool _Active;

       public bool Active
       {
           get { return _Active; }
           set { _Active = value; }
       }
       #endregion

       public DataTable GetAllList_HOSPITAL()
       {
          
           string procname = "DIC_HOSPITAL_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public string GetNewCode()
       {
           string procname = "DIC_HOSPITAL_GetList";
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
                       return "BV00000" + next_id.ToString();
                   case 2:
                       return "BV0000" + next_id.ToString();
                   case 3:
                       return "BV000" + next_id.ToString();
                   case 4:
                       return "BV00" + next_id.ToString();
                   case 5:
                       return "BV0" + next_id.ToString();
                   case 6:
                       return "TI" + next_id.ToString();
               }
           }
           return "BV000001";

       }

       public DataTable GetHospitalByCode(string strCode)
       {
           string procname = "DIC_HOSPITAL_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@HospitalCode", strCode);
           return db.ExecuteDataTable(procname);
       }
       public DataTable GetHospitalByProvince()
       {
           string procname = "DIC_HOSPITAL_GetListByProvince";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@ProvinceCode", ProvinceCode);
           return db.ExecuteDataTable(procname);
       }

       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@HospitalCode", HospitalCode);               
               db.AddParameter("@ProvinceCode", ProvinceCode);
               db.AddParameter("@HospitalName", HospitalName);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("DIC_HOSPITAL_Insert");
               db.CommitTransaction();

               Class.S_Log.Insert("Bệnh viện", "Thêm mới bệnh viện: " +HospitalName);
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
               db.AddParameter("@HospitalCode", HospitalCode);               
               db.AddParameter("@ProvinceCode", ProvinceCode);
               db.AddParameter("@HospitalName", HospitalName);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("DIC_HOSPITAL_Update");
               Class.S_Log.Insert("Bệnh viện", "Cập nhật bệnh viện: " + HospitalName);
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

       public bool Delete()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@HospitalCode", HospitalCode);
               db.ExecuteNonQueryWithTransaction("DIC_HOSPITAL_Delete");
               db.CommitTransaction();
               Class.S_Log.Insert("Bệnh viện", "Xóa bệnh viện: " + HospitalCode);
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
