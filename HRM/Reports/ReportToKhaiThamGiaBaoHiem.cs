using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HRM.Reports
{
    public partial class ReportToKhaiThamGiaBaoHiem : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportToKhaiThamGiaBaoHiem()
        {
            InitializeComponent();
        }
        public ReportToKhaiThamGiaBaoHiem(DataTable dt)
        {
            InitializeComponent();
            bool _Sex = (bool)dt.Rows[0]["Sex"];
            if (_Sex)
            {
                lblNamFalse.Visible = true;
                lblNuTrue.Visible = false;
            }
            else
            {
                lblNamTrue.Visible = false;
                lblNuFalse.Visible = true;

            }                    
            string txt = dt.Rows[0]["FullName"].ToString();
            int Dolon = txt.Length;            
           lblGioiTinh.LeftF = lblGioiTinh.LeftF+ Dolon *10;
           lblNamTrue.LeftF = lblNamTrue.LeftF + Dolon * 10;
           lblNamFalse.LeftF = lblNamFalse.LeftF + Dolon * 10;
           lblNuTrue.LeftF = lblNuTrue.LeftF + Dolon * 10;
           lblNuFalse.LeftF = lblNuFalse.LeftF + Dolon * 10;
        }          
    }
}
