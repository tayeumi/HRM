using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRM.Class
{
    class ChamCong_TongHopChiTiet
    {
        public DataTable HRM_TIMEKEEPER_SYNTHESIS_GetList(string Thang)
        {
            string procname = "HRM_TIMEKEEPER_SYNTHESIS_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@TimeKeeperTableListID", Thang);
            DataTable dt= db.ExecuteDataTable(procname);
            // bảo trì không chấm ra  -----/// ---- khai thac dich vu
            #region bao tri ko cham cong
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (dt.Rows[i]["Position"].ToString().ToLower().Contains("bảo trì") || dt.Rows[i]["Position"].ToString().ToLower().Contains("quản lý chung cư"))
            //    {
            //        // loai nhung nhan vien van tinh ra trong phong do
            //        if (dt.Rows[i]["EmployeeCode"].ToString().Contains("LBC0699")) // nhan vien bang trong khai thac dich vu
            //        {

            //        }
            //        else
            //        {

            //            for (int j = 0; j < dt.Columns.Count; j++)
            //            {
            //                if (dt.Columns[j].ColumnName.StartsWith("D") && dt.Columns[j].ColumnName.Length < 4)
            //                {
            //                    if (dt.Rows[i][j].ToString().Equals("KR"))
            //                    {
            //                        dt.Rows[i][j] = "1";
            //                    }
            //                    if (dt.Rows[i][j].ToString().StartsWith("S"))
            //                    {

            //                        dt.Rows[i][j] = "1";  // chi co som ko, thi van tinh 1 ca du vi chi cham vao

            //                    }
            //                    if (dt.Rows[i][j].ToString().EndsWith("-KR"))
            //                    {

            //                        dt.Rows[i][j] = dt.Rows[i][j].ToString().Replace("-KR", ""); // bo ko ra o phia sau

            //                    }
            //                }
            //            }
            //        }

            //    }

            //}
            #endregion
            dt.Columns.Add("Total15");
            dt.Columns.Add("TotalNgay15");
            dt.Columns.Add("TotalTren15");
            dt.Columns.Add("TotalNgayTren15");

            return dt;
        }
      
    }
}
