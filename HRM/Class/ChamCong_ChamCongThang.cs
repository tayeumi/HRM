using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace HRM.Class
{
   
    class ChamCong_ChamCongThang
    {
        #region khai bao bien
        private string _TimeKeeperTableListID;

        public string TimeKeeperTableListID
        {
            get { return _TimeKeeperTableListID; }
            set { _TimeKeeperTableListID = value; }
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

        private string _Day;

        public string Day
        {
            get { return _Day; }
            set { _Day = value; }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        #endregion

        public DataTable HRM_TIMEKEEPER_TABLE_GetList()
        {
            string procname = "HRM_TIMEKEEPER_TABLE_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            DataTable dt=db.ExecuteDataTable(procname);
            // tinh tong phep theo thang
            dt.Columns.Add("PN",typeof(float));
            dt.Columns.Add("HL", typeof(float));
            dt.Columns.Add("BH", typeof(float));
            dt.Columns.Add("KL", typeof(float));
            dt.Columns.Add("KP", typeof(float));
            dt.Columns.Add("LD", typeof(float));
            dt.Columns.Add("NB", typeof(float));
            dt.Columns.Add("OFF", typeof(float));
            dt.Columns.Add("PB", typeof(float));
            dt.Columns.Add("TD", typeof(float));
            dt.Columns.Add("NC", typeof(float));
            dt.Columns.Add("IsUpdate");
            dt.Columns.Add("PrintAllow", typeof(bool));
            return dt;
        }

        public DataTable HRM_TIMEKEEPER_TABLE_COMMENT_GetList()
        {
            string procname = "HRM_TIMEKEEPER_TABLE_COMMENT_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            DataTable dt = db.ExecuteDataTable(procname);           
            return dt;

        }

        public DataTable HRM_TIMEKEEPER_TABLE_COMMENT_Get()
        {
            string procname = "HRM_TIMEKEEPER_TABLE_COMMENT_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            db.AddParameter("@EmployeeCode", EmployeeCode);
            db.AddParameter("@Day", Day);
            DataTable dt = db.ExecuteDataTable(procname);
            return dt;

        }

        public bool HRM_TIMEKEEPER_TABLE_COMMENT_Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@Day", Day);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLE_COMMENT_Insert");
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
        public bool HRM_TIMEKEEPER_TABLE_COMMENT_Update()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@Day", Day);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLE_COMMENT_Update");
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
        public bool HRM_TIMEKEEPER_TABLE_COMMENT_Delete()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.AddParameter("@Day", Day);               
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLE_COMMENT_Delete");
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


        public static DataTable TinhTongHopChamCong(DataTable dt,int year,int month,DayOfWeek days)
        {
            int _Days = DateTime.DaysInMonth(year,month);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                float _PN = 0F;
                float _BH = 0F;
                float _HL = 0F;
                float _KL = 0F;
                float _KP = 0F;
                float _LD = 0F;
                float _NB = 0F;
                float _OFF = 0F;
                float _PB = 0F;
                float _TD = 0F;
                float _KLV = 0F;
                int _0ChamCong = 0;
                for (int j = 1; j <= _Days; j++)
                    {
                        string txt=dt.Rows[i]["D"+j].ToString();
                        //txt = Convert.ToString(txt);
                        if(dt.Rows[i]["D"+j].ToString().Equals("PN"))
                        {
                            _PN=_PN+1;
                        }
                        if(dt.Rows[i]["D"+j].ToString().Equals("1/2PN"))
                        {
                            _PN=_PN+0.5F;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("PB"))
                        {
                            _PB = _PB + 1;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("1/2PB"))
                        {
                            _PB = _PB + 0.5F;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("BH"))
                        {
                            _BH = _BH + 1;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("HL"))
                        {
                            _HL = _HL + 1;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("KL"))
                        {
                            _KL = _KL + 1;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("1/2KL"))
                        {
                            _KL = _KL + 0.5F;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("KP"))
                        {
                            _KP = _KP + 1;
                        }
                        if (txt=="LD")
                        {
                            _LD = _LD + 1;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("NB"))
                        {
                            _NB = _NB + 1;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("1/2NB"))
                        {
                            _NB = _NB + 0.5F;
                        }
                        if (dt.Rows[i]["D"+j].ToString().Equals("Off"))
                        {
                            _OFF = _OFF + 1;
                        }
                        if (txt=="TD")
                        {
                            _TD = _TD + 1;
                        }
                        if (txt == "PN-PB")
                        {                            
                            _PN = _PN + 0.5F;
                            _PB = _PB + 0.5F;
                        }
                        if (txt == "PN-KL")
                        {
                            _PN = _PN + 0.5F;
                            _KL = _KL + 0.5F;
                        }
                        if (txt == "PB-KL")
                        {
                            _PB = _PB + 0.5F;
                            _KL = _KL + 0.5F;
                        }
                        if (txt == "0")
                        {
                            _0ChamCong++;
                        }                        
                        
                        if (dt.Rows[i]["D"+j].ToString().Equals(" "))
                        {
                            _KLV = _KLV + 1;
                        }


                    }
                dt.Rows[i]["PN"] = _PN;
                dt.Rows[i]["HL"] = _HL;
                dt.Rows[i]["BH"] = _BH;
                dt.Rows[i]["KL"] = _KL;
                dt.Rows[i]["KP"] = _KP;
                dt.Rows[i]["LD"] = _LD;
                dt.Rows[i]["NB"] = _NB;
                dt.Rows[i]["OFF"] = _OFF;
                dt.Rows[i]["PB"] = _PB;
                dt.Rows[i]["TD"] = _TD;      
                int SNCN = 0;
                CultureInfo ci = new CultureInfo("en-US");
                for (int k = 1; k <= ci.Calendar.GetDaysInMonth(year, month); k++)
                {
                    if (new DateTime(year, month, k).DayOfWeek == days)
                        SNCN++;
                }
                int SLNtrongThang = DateTime.DaysInMonth(year, month);
                dt.Rows[i]["NC"] =SLNtrongThang- SNCN -_BH-_KL-_KP-_KLV-_0ChamCong;
                // tinh so ngay CN
                // cho Phep In
                dt.Rows[i]["PrintAllow"] = true;
            }
            return dt;
        }

        public DataTable HRM_TIMEKEEPER_TABLE_Create()
        {
            string procname = "HRM_TIMEKEEPER_TABLE_Create";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            return db.ExecuteDataTable(procname);

        }
        public DataTable HRM_TIMEKEEPER_TABLE_GetListByBranch()
        {
            string procname = "HRM_TIMEKEEPER_TABLE_GetListByBranch";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            db.AddParameter("@BranchCode", BranchCode);
            return db.ExecuteDataTable(procname);

        }
        public DataTable HRM_TIMEKEEPER_TABLE_GetListByDepartment()
        {
            string procname = "HRM_TIMEKEEPER_TABLE_GetListByDepartment";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            db.AddParameter("@DepartmentCode", DepartmentCode);
            return db.ExecuteDataTable(procname);

        }
        public DataTable HRM_TIMEKEEPER_TABLE_GetListByGroup()
        {
            string procname = "HRM_TIMEKEEPER_TABLE_GetListByGroup";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
            db.AddParameter("@GroupCode", GroupCode);
            return db.ExecuteDataTable(procname);
        }
        public bool Update(DataTable Data, int _DayNumber)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < Data.Rows.Count; i++)
                {
                    //if (Data.Rows[i]["IsUpdate"].ToString() == "1")  // tinh co cap nhat moi thay doi
                    //{
                        int _Up = 0;
                        for (int ii = _DayNumber; ii > 1; ii--)
                        {
                                string _day = "0";                            
                                if (Data.Rows[i]["D" + ii].ToString() ==_day)
                                {
                                    _Up = ii;
                                }                           
                        }
                        if (_Up > 0)
                            _Up--; // tra lai truoc 1 ngày de tranh tình trang ko cham ra ma chot luon ko cham ra
                        else
                            _Up = _DayNumber;

                        db.CreateNewSqlCommand();
                        db.AddParameter("@TimeKeeperTableListID", Data.Rows[i]["TimeKeeperTableListID"].ToString());
                        db.AddParameter("@EmployeeCode", Data.Rows[i]["EmployeeCode"].ToString());
                        db.AddParameter("@ShiftCode", Data.Rows[i]["ShiftCode"].ToString());
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
                        db.AddParameter("@UpdateDay", _Up);
                        db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLE_Update");
                        //db.CreateNewSqlCommand();
                        //db.AddParameter("@UserName", S_Log.UserName);
                        //db.AddParameter("@Created", DateTime.Now);
                        //db.AddParameter("@Module", "Chấm công");
                        //db.AddParameter("@IPLan", S_Log.IPLan);
                        //db.AddParameter("@PCName", S_Log.PCName);
                        //db.AddParameter("@Description", S_Log.Description + Data.Rows[i]["FirstName"].ToString() + " " + Data.Rows[i]["LastName"].ToString());
                        //db.AddParameter("@Active", true);
                        //db.ExecuteNonQueryWithTransaction("HRM_LOG_Insert");
                       
                    //}
                }
                db.CommitTransaction();
               //Class.S_Log.Insert("Chấm công", " Cập nhật Bảng Chấm công tháng ");
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public bool HRM_TIMEKEEPER_TABLELIST_Lock()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.AddParameter("@IsLock", IsLock);
                db.AddParameter("@IsFinish", IsFinish);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLELIST_Lock");           
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

        public bool HRM_TIMEKEEPER_TABLE_UpdateByShift()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);
                db.AddParameter("@EmployeeCode", EmployeeCode);
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLE_UpdateByShift");
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

        public bool HRM_TIMEKEEPER_TABLE_Delete()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@TimeKeeperTableListID", TimeKeeperTableListID);                
                db.ExecuteNonQueryWithTransaction("HRM_TIMEKEEPER_TABLE_Delete");
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
