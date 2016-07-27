using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
   public class DanhMuc_NgachLuong
    {

       public DataTable GetAllList_SALARY_RANK()
       {
           string procname = "DIC_SALARY_RANK_GetList";
           DbAccess db = new DbAccess();
           db.CreateNewSqlCommand();
           return db.ExecuteDataTable(procname);
       }
    }
}
