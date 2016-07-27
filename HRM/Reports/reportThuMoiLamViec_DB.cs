using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HRM.Reports
{
    public partial class reportThuMoiLamViec_DB : DevExpress.XtraReports.UI.XtraReport
    {
        public reportThuMoiLamViec_DB(decimal totalSalary, decimal totalTestSalary)
        {
            InitializeComponent();
            xrtotalTestSalary.Text = totalTestSalary.ToString("#,#") + " VNĐ/ Tháng";
            xrtotalSalary.Text = totalSalary.ToString("#,#") + " VNĐ/ Tháng";
        }

    }
}
