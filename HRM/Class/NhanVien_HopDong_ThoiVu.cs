using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
    class NhanVien_HopDong_ThoiVu
    {

        public string ContractCode { get; set; }
        public string EmployeeCode { get; set; }
        public string ContractTime { get; set; }
        public int ContractYear { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal BasicSalary { get; set; }
        public string PayForm { get; set; }
        public string PayDate { get; set; }
        public string Allowance { get; set; }
        public string Insurance { get; set; }
        public string WorkTime { get; set; }
        public string Signer { get; set; }
        public string SignerPosition { get; set; }
        public string SignerNationality { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool IsCurrent { get; set; }

        public DataTable HRM_CONTRACT_SEASON_GetList()
        {
            string procname = "HRM_CONTRACT_SEASON_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable HRM_CONTRACT_SEASON_GetListExpiration()
        {
            string procname = "HRM_CONTRACT_SEASON_GetListExpiration";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        
        public DataTable HRM_CONTRACT_SEASON_GetByEmployee()
        {
            string procname = "HRM_CONTRACT_SEASON_GetByEmployee";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@EmployeeCode", EmployeeCode);
            return db.ExecuteDataTable(procname);
        }

        public DataTable HRM_CONTRACT_SEASON_Get()
        {
            string procname = "HRM_CONTRACT_SEASON_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@ContractCode", ContractCode);
            return db.ExecuteDataTable(procname);
        }
        public DataTable HRM_CONTRACT_SEASON_GetByYear()
        {
            string procname = "HRM_CONTRACT_SEASON_GetByYear";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@ContractYear", ContractYear);         
            return db.ExecuteDataTable(procname);
        }
        public bool Insert()
        {
           
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {               
                // thu hien neu la hd hien tai
                if (IsCurrent)
                {
                    db.CreateNewSqlCommand();
                    db.AddParameter("@EmployeeCode", EmployeeCode);
                    db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_SEASON_Update_notIsCurrent");
                }
                //
                db.CreateNewSqlCommand();
                db.AddParameter("@ContractCode", ContractCode);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@ContractTime", ContractTime);
                db.AddParameter("@ContractYear", ContractYear);
                db.AddParameter("@SignDate", SignDate);
                db.AddParameter("@FromDate", FromDate);               
                db.AddParameter("@ToDate", ToDate);
                db.AddParameter("@BasicSalary", BasicSalary);
                db.AddParameter("@PayForm", PayForm);
                db.AddParameter("@PayDate", PayDate);
                db.AddParameter("@Allowance", Allowance);
                db.AddParameter("@Insurance", Insurance);
                db.AddParameter("@WorkTime", WorkTime);
                db.AddParameter("@Signer", Signer);
                db.AddParameter("@SignerPosition", SignerPosition);
                db.AddParameter("@SignerNationality", SignerNationality);
                db.AddParameter("@Company", Company);
                db.AddParameter("@Address", Address);
                db.AddParameter("@Tel", Tel);                
                db.AddParameter("@Description", Description);
                db.AddParameter("@IsCurrent", IsCurrent);
                db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_SEASON_Insert");
                db.CommitTransaction();
               Class.S_Log.Insert("Hợp Đồng", "Thêm Hợp đồng thời vụ : " + ContractCode + " - Mã Nhân viên: " + EmployeeCode);
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
                // thu hien neu la hd hien tai
                if (IsCurrent)
                {
                    db.CreateNewSqlCommand();
                    db.AddParameter("@EmployeeCode", EmployeeCode);
                    db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_SEASON_Update_notIsCurrent");
                }
                //
                db.CreateNewSqlCommand();
                db.AddParameter("@ContractCode", ContractCode);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@ContractTime", ContractTime);
                db.AddParameter("@ContractYear", ContractYear);
                db.AddParameter("@SignDate", SignDate);
                db.AddParameter("@FromDate", FromDate);
               
                    db.AddParameter("@ToDate", ToDate);

                db.AddParameter("@BasicSalary", BasicSalary);
                db.AddParameter("@PayForm", PayForm);
                db.AddParameter("@PayDate", PayDate);
                db.AddParameter("@Allowance", Allowance);
                db.AddParameter("@Insurance", Insurance);
                db.AddParameter("@WorkTime", WorkTime);
                db.AddParameter("@Signer", Signer);
                db.AddParameter("@SignerPosition", SignerPosition);
                db.AddParameter("@SignerNationality", SignerNationality);
                db.AddParameter("@Company", Company);
                db.AddParameter("@Address", Address);
                db.AddParameter("@Tel", Tel);
                db.AddParameter("@Description", Description);
                db.AddParameter("@IsCurrent", IsCurrent);
                db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_SEASON_Update");
                db.CommitTransaction();
               Class.S_Log.Insert("Hợp Đồng", "Cập nhật Hợp đồng thời vụ: " + ContractCode + " - Mã Nhân viên: " + EmployeeCode);
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
                db.AddParameter("@ContractCode", ContractCode);
                db.ExecuteNonQueryWithTransaction("HRM_CONTRACT_SEASON_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Hợp Đồng", "Xóa Hợp đồng thời vụ: " + ContractCode + " - Mã Nhân viên: " + EmployeeCode);
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public DataTable HRM_CONTRACT_SEASON_GetPrintByCode()
        {
            string procname = "HRM_CONTRACT_SEASON_GetPrintByCode";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@ContractCode", ContractCode);
            DataTable dt = db.ExecuteDataTable(procname);
            dt.Columns.Add("FullName", Type.GetType("System.String"));
            dt.Columns.Add("VND", Type.GetType("System.String"));
            dt.Columns.Add("TotalSalary", Type.GetType("System.String"));
            DateTime SignDate = (DateTime)dt.Rows[0]["SignDate"];

            string _contractCode = dt.Rows[0]["ContractCode"].ToString();
            _contractCode = _contractCode.Replace("D", "Đ");
            _contractCode = _contractCode.Replace("u", "ụ");
            _contractCode = _contractCode.Replace("Lan", "Lần");
            dt.Rows[0]["ContractCode"] = _contractCode;
            Decimal BasicSalary = (Decimal)dt.Rows[0]["BasicSalary"];
            Decimal Allowance = 0;
            if (dt.Rows[0]["Allowance"].ToString().Trim().Length > 0)
            {
                Allowance = Decimal.Parse(dt.Rows[0]["Allowance"].ToString().Replace(",", ""));
            }
            Decimal Total = BasicSalary + Allowance;
            dt.Rows[0]["TotalSalary"] = Total.ToString("#,##");
            string _vnd = dt.Rows[0]["BasicSalary"].ToString();
            dt.Rows[0]["Signer"] = dt.Rows[0]["Signer"].ToString().ToUpper();
            if (_vnd.IndexOf('.') > 0)
            {
                _vnd = _vnd.Substring(0, _vnd.IndexOf('.')); // bỏ đi tiền lẻ.(.00)
            }
            dt.Rows[0]["VND"] = Class.App.ChuyenSo(_vnd);
            dt.Rows[0]["Fullname"] = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
            dt.Rows[0]["Fullname"] = dt.Rows[0]["Fullname"].ToString().ToUpper();            
            return dt;
        }
    }
}
