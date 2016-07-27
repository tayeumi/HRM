using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_Tinh
   {
       #region KhaiBao_Bien
       private string _ProvinceCode;

       public string ProvinceCode
       {
           get { return _ProvinceCode; }
           set { _ProvinceCode = value; }
       }
       private string _ProvinceName;

       public string ProvinceName
       {
           get { return _ProvinceName; }
           set { _ProvinceName = value; }
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

       public DataTable GetAllList_PROVINCE()
       {
           string procname = "DIC_PROVINCE_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }

       public string GetNewCode()
       {
           string procname = "DIC_PROVINCE_GetList";
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
                       return "TI00000" + next_id.ToString();
                   case 2:
                       return "TI0000" + next_id.ToString();
                   case 3:
                       return "TI000" + next_id.ToString();
                   case 4:
                       return "TI00" + next_id.ToString();
                   case 5:
                       return "TI0" + next_id.ToString();
                   case 6:
                       return "TI" + next_id.ToString();
               }
           }
           return "TI000001";

       }

       public static string GetProvinceSearch(string strCode)
       {
           string procname = "DIC_PROVINCE_Search";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@ProvinceCode", "");
           db.AddParameter("@ProvinceName", strCode);
           db.AddParameter("@Description", "");
           DataTable dt = db.ExecuteDataTable(procname);
           if (dt.Rows.Count > 0)
           {
               return dt.Rows[0]["ProvinceCode"].ToString();
           }
           return "";
       }
       public DataTable GetProvinceByCode(string strCode)
       {
           string procname = "DIC_PROVINCE_Get";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           db.AddParameter("@ProvinceCode", strCode);
           return db.ExecuteDataTable(procname);
       }

       public bool Insert()
       {
           DbAccess db = new DbAccess();
           db.BeginTransaction();
           try
           {
               db.CreateNewSqlCommand();
               db.AddParameter("@ProvinceCode", ProvinceCode);
               db.AddParameter("@ProvinceName", ProvinceName);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("DIC_PROVINCE_Insert");
               db.CommitTransaction();
               Class.S_Log.Insert("Tỉnh thành", "Thêm Tỉnh thành: " + ProvinceName);
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
               db.AddParameter("@ProvinceCode", ProvinceCode);
               db.AddParameter("@ProvinceName", ProvinceName);
               db.AddParameter("@Description", Description);
               db.AddParameter("@Active", Active);
               db.ExecuteNonQueryWithTransaction("DIC_PROVINCE_Update");
               db.CommitTransaction();
               Class.S_Log.Insert("Tỉnh thành", "Cập nhật Tỉnh thành: " + ProvinceName);
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
               db.AddParameter("@ProvinceCode", ProvinceCode);
               db.ExecuteNonQueryWithTransaction("DIC_PROVINCE_Delete");
               db.CommitTransaction();
               Class.S_Log.Insert("Tỉnh thành", "Xóa Tỉnh thành: " + ProvinceCode);
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
