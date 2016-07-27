using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace HRM.Reports
{
    public partial class reportHopDongThuViec_DB : DevExpress.XtraReports.UI.XtraReport
    {
        public reportHopDongThuViec_DB()
        {
            InitializeComponent();
            
        }
        public reportHopDongThuViec_DB(DataTable dt, decimal totalSalary, decimal totalTestSalary)
        {
            InitializeComponent();
            if (dt.Rows[0]["BranchName"].ToString() == "BBS2")
            {
                lblBranchName.Visible = true;
                lblGroup.Visible = false;
                lblDepartment.Visible = false;
                if (dt.Rows[0]["DepartmentName"].ToString().ToLower() == "dịch vụ sau bán hàng")
                {
                    lblBranchName.Text = "BBS2-DVSBH";
                }
                else if (dt.Rows[0]["DepartmentName"].ToString().ToLower() == "kiểm soát nội bộ")
                {
                    lblBranchName.Text = "BBS2-KSNB";
                }
                else if (dt.Rows[0]["DepartmentName"].ToString().ToLower() == "kế toán tài chính")
                {
                    lblBranchName.Text = "BBS2-KTTC";
                }
                else
                {
                    lblBranchName.Text = "BBS2";
                }
            }

            else if (dt.Rows[0]["GroupName"].ToString().Length < 1)
            {
                lblGroup.Visible = false;
                lblDepartment.Visible = true;
                lblBranchName.Visible = false;
            }
            else
            {
                lblGroup.Visible = true;
                lblDepartment.Visible = false;
                lblBranchName.Visible = false;
            }
            xrtotalTestSalary.Text = totalTestSalary.ToString("#,#") + " VNĐ/ Tháng";
            xrtotalSalary.Text = totalSalary.ToString("#,#") + " VNĐ/ Tháng";
        }

    }
}
