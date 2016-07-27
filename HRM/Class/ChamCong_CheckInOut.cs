using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace HRM.Class
{
    class ChamCong_CheckInOut
    {
        #region khai bao bien
        private string _InOutCode;

        public string InOutCode
        {
            get { return _InOutCode; }
            set { _InOutCode = value; }
        }
        private string _MachineNumber;

        public string MachineNumber
        {
            get { return _MachineNumber; }
            set { _MachineNumber = value; }
        }
        private string _EnrollNumber;

        public string EnrollNumber
        {
            get { return _EnrollNumber; }
            set { _EnrollNumber = value; }
        }
        private string _VerifyMode;

        public string VerifyMode
        {
            get { return _VerifyMode; }
            set { _VerifyMode = value; }
        }
        private string _InOutMode;

        public string InOutMode
        {
            get { return _InOutMode; }
            set { _InOutMode = value; }
        }
        private string _Year;

        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        private string _Month;

        public string Month
        {
            get { return _Month; }
            set { _Month = value; }
        }
        private string _Day;

        public string Day
        {
            get { return _Day; }
            set { _Day = value; }
        }
        private string _Hour;

        public string Hour
        {
            get { return _Hour; }
            set { _Hour = value; }
        }
        private string _Minute;

        public string Minute
        {
            get { return _Minute; }
            set { _Minute = value; }
        }
        private string _Second;

        public string Second
        {
            get { return _Second; }
            set { _Second = value; }
        }
        private DateTime _TimeStr;

        public DateTime TimeStr
        {
            get { return _TimeStr; }
            set { _TimeStr = value; }
        }

        private DateTime _FromDay;

        public DateTime FromDay
        {
            get { return _FromDay; }
            set { _FromDay = value; }
        }
        private DateTime _ToDay;

        public DateTime ToDay
        {
            get { return _ToDay; }
            set { _ToDay = value; }
        }

        private DateTime _TimeBeginIn;

        public DateTime TimeBeginIn
        {
            get { return _TimeBeginIn; }
            set { _TimeBeginIn = value; }
        }
        private DateTime _TimeEndIn;

        public DateTime TimeEndIn
        {
            get { return _TimeEndIn; }
            set { _TimeEndIn = value; }
        }
        private DateTime _TimeBeginOut;

        public DateTime TimeBeginOut
        {
            get { return _TimeBeginOut; }
            set { _TimeBeginOut = value; }
        }
        private DateTime _TimeEndOut;

        public DateTime TimeEndOut
        {
            get { return _TimeEndOut; }
            set { _TimeEndOut = value; }
        }
        #endregion
        public DataTable CHECKINOUT_GetList()
        {
            string procname = "CHECKINOUT_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable CHECKINOUT_GetByDate()
        {
            string procname = "CHECKINOUT_GetByDate";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@FromDay", FromDay);
            db.AddParameter("@ToDay", ToDay);
            return db.ExecuteDataTable(procname);
        }

        public DataTable CHECKINOUT_GetByDateAll()
        {
            string procname = "CHECKINOUT_GetByDateAll";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@FromDay", FromDay);
            db.AddParameter("@ToDay", ToDay);
            db.AddParameter("@TimeBeginIn", TimeBeginIn);
            db.AddParameter("@TimeEndIn", TimeEndIn);
            db.AddParameter("@TimeBeginOut", TimeBeginOut);
            db.AddParameter("@TimeEndOut", TimeEndOut);
            DataTable dt=db.ExecuteDataTable(procname);
            // xu ly bao du lieu
            DataTable dtChange = new DataTable();
            dtChange.Columns.Add("InOutCode", Type.GetType("System.String"));//0
            dtChange.Columns.Add("MachineNumber", Type.GetType("System.String"));//1
            dtChange.Columns.Add("EnrollNumber", Type.GetType("System.String"));//2
            dtChange.Columns.Add("VerifyMode", Type.GetType("System.String"));//3
            dtChange.Columns.Add("InOutMode", Type.GetType("System.String"));//4
            dtChange.Columns.Add("Year", Type.GetType("System.String"));//5
            dtChange.Columns.Add("Month", Type.GetType("System.String"));//6
            dtChange.Columns.Add("Day", Type.GetType("System.String"));//7
            dtChange.Columns.Add("Hour", Type.GetType("System.String"));//8
            dtChange.Columns.Add("Minute", Type.GetType("System.String"));//9
            dtChange.Columns.Add("Second", Type.GetType("System.String"));//10
            dtChange.Columns.Add("TimeStr", Type.GetType("System.DateTime"));//11
            dtChange.Columns.Add("EmployeeCode", Type.GetType("System.String"));//12
            dtChange.Columns.Add("FirstName", Type.GetType("System.String"));//13
            dtChange.Columns.Add("LastName", Type.GetType("System.String"));//14
            dtChange.Columns.Add("DayStr", Type.GetType("System.String"));//15
            dtChange.Columns.Add("DateStr", Type.GetType("System.String"));//16
            dtChange.Columns.Add("TimeIn", Type.GetType("System.String"));//17
            dtChange.Columns.Add("TimeOut", Type.GetType("System.String"));//18
            dtChange.Columns.Add("DepartmentName", Type.GetType("System.String"));//19   
            dtChange.Columns.Add("GroupName", Type.GetType("System.String"));//20
            dtChange.Columns.Add("Index", Type.GetType("System.String"));//21
            #region xu ly du lieu ngay thang
            DateTime dtFromDay = FromDay;
            DateTime dtToDay = ToDay;
            CultureInfo vnam = new CultureInfo("vi-VN");
            while (dtFromDay < dtToDay)
            {
                List<string> listTemp = new List<string>();
                string _Ngay = dtFromDay.Day.ToString();
                string _Thang = dtFromDay.Month.ToString();
                string _Nam = dtFromDay.Year.ToString();
                string _search = "Day='"+_Ngay+"' AND Month='"+_Thang+"' AND Year='"+_Nam+"'";
                DataRow[] result = dt.Select(_search);
                for (int i = 0; i < result.Length; i++)
                {
                    string _EnrollNumber = result[i]["EnrollNumber"].ToString();
                    bool check = false;
                    for (int j = 0; j < listTemp.Count; j++)
                    {
                        if (listTemp[j].ToString() == _EnrollNumber)
                            check= true;
                        else
                        check= false;
                    }
                    if (check == false)
                    {
                        listTemp.Add(_EnrollNumber);
                        string _searchNext = _search + " AND EnrollNumber='" + _EnrollNumber + "'";
                        DataRow[] result2 = dt.Select(_searchNext);
                        DataRow dr = dtChange.NewRow();
                        dr[0] = result2[0]["InOutCode"].ToString();
                        dr[1] = result2[0]["MachineNumber"].ToString();
                        dr[2] = result2[0]["EnrollNumber"].ToString();
                        dr[3] = result2[0]["VerifyMode"].ToString();
                        dr[4] = result2[0]["InOutMode"].ToString();
                        dr[5] = result2[0]["Year"].ToString();
                        dr[6] = result2[0]["Month"].ToString();
                        dr[7] = result2[0]["Day"].ToString();
                        dr[8] = result2[0]["Hour"].ToString();
                        dr[9] = result2[0]["Minute"].ToString();
                        dr[10] = result2[0]["Second"].ToString();
                        dr[11] = (DateTime)result2[0]["TimeStr"];
                        dr[12] = result2[0]["EmployeeCode"].ToString();
                        dr[13] = result2[0]["FirstName"].ToString();
                        dr[14] = result2[0]["LastName"].ToString();
                        dr[15] = ((DateTime)result2[0]["TimeStr"]).ToString("dd/MM/yyyy");
                        string _Thu = vnam.DateTimeFormat.DayNames[(int)((DateTime)result2[0]["TimeStr"]).DayOfWeek];
                        dr[16] = _Thu;
                        dr[17] = result2[0]["TimeIn"].ToString();
                        if (result2.Length == 1)
                        {
                            dr[18] = "";
                            if(result2[0]["TimeIn"].ToString().Length<2)
                                dr[18] = result2[0]["TimeOut"].ToString(); // xu ly nv chi cham gio ra
                        }
                        else
                        {
                            dr[18] = result2[result2.Length - 1]["TimeOut"].ToString();
                        }
                        if (result2.Length == 2) // xu ly neu vao nua ngay
                        {
                            if(result2[0]["TimeIn"].ToString().Length<2)
                                dr[17] = result2[0]["TimeOut"].ToString();
                        }
                        dr[19] = result2[0]["DepartmentName"].ToString();
                        dr[20] = result2[0]["GroupName"].ToString();
                        dtChange.Rows.Add(dr);
                    }
                    //if (result.Length == 0)
                    //{
                    //    DataRow dr = dtChange.NewRow();
                    //    dr[15] = dtFromDay.ToString("d/M/yyyy");
                    //    string _Thu = vnam.DateTimeFormat.DayNames[(int)(dtFromDay.DayOfWeek)];
                    //    dr[16] = _Thu;
                    //    dtChange.Rows.Add(dr);
                    //}
                }  
                dtFromDay=  dtFromDay.AddDays(1);
            }
            #endregion
            // xu lý xuat theo thang
            List<string> list = new List<string>();
            for (int d = 0; d < dtChange.Rows.Count; d++)
            {
                bool check = false;
                string txtAdd = dtChange.Rows[d]["MachineNumber"].ToString() + "|" + dtChange.Rows[d]["EnrollNumber"].ToString() + "|" + dtChange.Rows[d]["EmployeeCode"].ToString() + "|" + dtChange.Rows[d]["FirstName"].ToString() + "|" + dtChange.Rows[d]["LastName"].ToString() + "|" + dtChange.Rows[d]["DepartmentName"].ToString() + "|" + dtChange.Rows[d]["InOutMode"].ToString() + "|" + dtChange.Rows[d]["GroupName"].ToString();
                for (int dd = 0; dd < list.Count; dd++)
                {

                    if (list[dd].ToString() == txtAdd)
                        check = true;
                    else
                        check = false;
                }
                if (check == false)
                {
                    list.Add(txtAdd);
                }
            }
            DateTime dtExFromDay = FromDay;
            DateTime dtEXToDay = ToDay;
             int stt = 1;
            while (dtExFromDay < dtEXToDay)
            {               
                for (int t = 0; t < list.Count; t++)
                {
                    string[] strSplip = list[t].ToString().Split('|');
                    DataRow[] result3 = dtChange.Select("EnrollNumber='" + strSplip[1].ToString() + "' AND DayStr='" + dtExFromDay.ToString("dd/MM/yyyy") + "'");
                    if (result3.Length < 1)
                    {
                        DataRow dr = dtChange.NewRow();
                        dr[1] = strSplip[0].ToString();
                        dr[2] = strSplip[1].ToString();
                        dr[12] = strSplip[2].ToString();
                        dr[13] = strSplip[3].ToString();
                        dr[14] = strSplip[4].ToString();
                        dr[15] = dtExFromDay.ToString("dd/MM/yyyy");
                        string _Thu = vnam.DateTimeFormat.DayNames[(int)dtExFromDay.DayOfWeek];
                        dr[16] = _Thu;
                        dr[19] = strSplip[5].ToString();
                        dr[4] = strSplip[6].ToString();
                        dr[11] = dtExFromDay;
                        dr[20] = strSplip[7].ToString();
                        dr[21] = stt.ToString();
                        dtChange.Rows.Add(dr);
                    }                    
                }
                stt++;
                dtExFromDay = dtExFromDay.AddDays(1);
            }
            DataView dv = dtChange.DefaultView;

            dv.Sort = "DepartmentName,GroupName,LastName,TimeStr ASC";
            dtChange = dv.ToTable();
            // het xu ly chon ngay
            // xu lý index tu dong
            int index = 1;
            string ktra="",text="";

            for (int ll = 0; ll < dtChange.Rows.Count; ll++)
            {
                ktra = dtChange.Rows[ll]["EnrollNumber"].ToString();
                if (ktra.Equals(text))
                {
                    dtChange.Rows[ll]["Index"] = index;                   
                }
                else
                {
                    index = 1;
                    dtChange.Rows[ll]["Index"] = index;
                    text = dtChange.Rows[ll]["EnrollNumber"].ToString(); ;
                }
                index++;
            }
            return dtChange;
        }

        public DataTable CHECKINOUT_GetByDateAll_Report()
        {
            string procname = "CHECKINOUT_GetByDateAll_Report";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@FromDay", FromDay);
            db.AddParameter("@ToDay", ToDay);
            db.AddParameter("@TimeBeginIn", TimeBeginIn);
            db.AddParameter("@TimeEndIn", TimeEndIn);
            db.AddParameter("@TimeBeginOut", TimeBeginOut);
            db.AddParameter("@TimeEndOut", TimeEndOut);
            DataTable dt = db.ExecuteDataTable(procname);
            CultureInfo vnam = new CultureInfo("vi-VN");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string _Thu = vnam.DateTimeFormat.DayNames[(int)((DateTime)dt.Rows[i]["DayStr"]).DayOfWeek];
                dt.Rows[i]["DateStr"] = _Thu;
            }
            return dt;
        }

        public DataTable CHECKINOUT_GetByDateAll_Report_Season()
        {
            string procname = "CHECKINOUT_GetByDateAll_Report_Season";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@FromDay", FromDay);
            db.AddParameter("@ToDay", ToDay);
            db.AddParameter("@TimeBeginIn", TimeBeginIn);
            db.AddParameter("@TimeEndIn", TimeEndIn);
            db.AddParameter("@TimeBeginOut", TimeBeginOut);
            db.AddParameter("@TimeEndOut", TimeEndOut);
            DataTable dt = db.ExecuteDataTable(procname);
            CultureInfo vnam = new CultureInfo("vi-VN");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string _Thu = vnam.DateTimeFormat.DayNames[(int)((DateTime)dt.Rows[i]["DayStr"]).DayOfWeek];
                dt.Rows[i]["DateStr"] = _Thu;
            }
            return dt;
        }


        public bool Insert(DataTable Data)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < Data.Rows.Count; i++)
                {
                    InOutCode = Data.Rows[i]["InOutCode"].ToString();
                    MachineNumber = Data.Rows[i]["MachineNumber"].ToString();
                    EnrollNumber = Data.Rows[i]["EnrollNumber"].ToString();
                    VerifyMode = Data.Rows[i]["VerifyMode"].ToString();
                    InOutMode = Data.Rows[i]["InOutMode"].ToString();
                    Year = Data.Rows[i]["Year"].ToString();
                    Month = Data.Rows[i]["Month"].ToString();
                    Day = Data.Rows[i]["Day"].ToString();
                    Hour = Data.Rows[i]["Hour"].ToString();
                    Minute = Data.Rows[i]["Minute"].ToString();
                    Second = Data.Rows[i]["Second"].ToString();
                    TimeStr = (DateTime)Data.Rows[i]["TimeStr"];

                    db.CreateNewSqlCommand();
                    db.AddParameter("@InOutCode", InOutCode);
                    db.AddParameter("@MachineNumber", MachineNumber);
                    db.AddParameter("@EnrollNumber", EnrollNumber);
                    db.AddParameter("@VerifyMode", VerifyMode);
                    db.AddParameter("@InOutMode", InOutMode);
                    db.AddParameter("@Year", Year);
                    db.AddParameter("@Month", Month);
                    db.AddParameter("@Day", Day);
                    db.AddParameter("@Hour", Hour);
                    db.AddParameter("@Minute", Minute);
                    db.AddParameter("@Second", Second);
                    db.AddParameter("@TimeStr", TimeStr);
                    db.ExecuteNonQueryWithTransaction("CHECKINOUT_Insert");
                }
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
