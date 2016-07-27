using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
    class DanhMuc_ThietBiChamCong
    {
        #region Khaibaobien
        private string _MachineCode;

        public string MachineCode
        {
            get { return _MachineCode; }
            set { _MachineCode = value; }
        }
        private string _MachineName;

        public string MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }
        private string _PortType;

        public string PortType
        {
            get { return _PortType; }
            set { _PortType = value; }
        }
        private string _PortID;

        public string PortID
        {
            get { return _PortID; }
            set { _PortID = value; }
        }
        private string _IP;

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private string _Com;

        public string Com
        {
            get { return _Com; }
            set { _Com = value; }
        }
        
        #endregion

        public DataTable DIC_MACHINE_GetList()
        {
            string procname = "DIC_MACHINE_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public string GetNewCode()
        {
            return "";
        }

        public DataTable GetMachineByCode(string strCode)
        {
            string procname = "DIC_MACHINE_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MachineCode", strCode);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@MachineCode", MachineCode);
                db.AddParameter("@MachineName", MachineName);
                db.AddParameter("@PortType", PortType);
                db.AddParameter("@PortID", PortID);
                db.AddParameter("@IP", IP);
                db.AddParameter("@Password", Password);
                db.AddParameter("@Com", Com);
                db.ExecuteNonQueryWithTransaction("DIC_MACHINE_Insert");
                db.CommitTransaction();
                Class.S_Log.Insert("Thiết bị chấm công", "Thêm Thiết bị chấm công: " + MachineName);
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
                db.AddParameter("@MachineCode", MachineCode);
                db.AddParameter("@MachineName", MachineName);
                db.AddParameter("@PortType", PortType);
                db.AddParameter("@PortID", PortID);
                db.AddParameter("@IP", IP);
                db.AddParameter("@Password", Password);
                db.AddParameter("@Com", Com);
                db.ExecuteNonQueryWithTransaction("DIC_MACHINE_Update");
                db.CommitTransaction();
                Class.S_Log.Insert("Thiết bị chấm công", "Cập nhật Thiết bị chấm công: " + MachineName);
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
                db.AddParameter("@MachineCode", MachineCode);
                db.ExecuteNonQueryWithTransaction("DIC_MACHINE_Delete");
                db.CommitTransaction();
                Class.S_Log.Insert("Thiết bị chấm công", "Xóa Thiết bị chấm công: " + MachineCode);
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
