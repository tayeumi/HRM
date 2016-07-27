using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_BacLuong
    {
        private string _RankCode;

        public string RankCode
        {
            get { return _RankCode; }
            set { _RankCode = value; }
        }
        private int _StepCode;

        public int StepCode
        {
            get { return _StepCode; }
            set { _StepCode = value; }
        }

        public DataTable GetStepBySalaryRank()
        {
            string procname = "DIC_SALARY_STEP_GetListByRank";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@RankCode", RankCode);
            return db.ExecuteDataTable(procname);
        }

        public DataTable GetStepByCode()
        {
            string procname = "DIC_SALARY_STEP_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@StepCode", StepCode);
            db.AddParameter("@RankCode", RankCode);
            return db.ExecuteDataTable(procname);
        }

    }
}
