using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace HRM.Reports
{
    public partial class reportHopDongThuViec_DL : DevExpress.XtraReports.UI.XtraReport
    {
        public reportHopDongThuViec_DL()
        {
            InitializeComponent();
        }
        public reportHopDongThuViec_DL(DataTable dt, decimal totalSalary, decimal totalTestSalary)
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
                if (dt.Rows[0]["Allowance"].ToString() == "")
                {
                    txtAllowance.Text = "Theo cơ chế của công ty tại Chi nhánh";
                }
                else
                {
                    if (decimal.Parse(dt.Rows[0]["Allowance"].ToString().Replace(",","")) > 0)
                    {
                        txtAllowance.Text = (decimal.Parse(dt.Rows[0]["Allowance"].ToString().Replace(",",""))).ToString("#,#") + " VNĐ/ Tháng";
                    }
                }

                if (dt.Rows[0]["TestAllowance"].ToString() == "")
                {
                    txtAllowance.Text = "Theo cơ chế của công ty tại Chi nhánh";
                }
                else
                {
                    if (decimal.Parse(dt.Rows[0]["TestAllowance"].ToString().Replace(",", "")) > 0)
                    {
                        txtTestAllowance.Text = (decimal.Parse(dt.Rows[0]["TestAllowance"].ToString().Replace(",", ""))).ToString("#,#") + " VNĐ/ Tháng";
                    }
                    else
                    {
                        txtTestAllowance.Text = "Theo cơ chế của công ty tại Chi nhánh";

                    }
                }
            if (dt.Rows[0]["Signer"].ToString().ToLower() == "hồ kim trí")
            {
                txtuyquyen.Visible = true;
                // richText1.Text = richText1.Text.Replace("vào thứ 7, ", "");
            }
            else
            {
                txtuyquyen.Visible = false;
            }
        }

        private void reportHopDongThuViec_DL_PrintProgress(object sender, DevExpress.XtraPrinting.PrintProgressEventArgs e)
        {
            try
            {
                string txtfile = Application.StartupPath + "\\temp.png";
                if (File.Exists(txtfile))
                {
                    File.Delete(txtfile);
                }

                this.ExportOptions.Image.Resolution = 200;
                this.ExportToImage(txtfile);

                if (File.Exists(txtfile))
                {
                    // luu vao csdl HD da in
                    Class.NhanVien_HopDong_In cls = new Class.NhanVien_HopDong_In();
                    DataTable dt = (DataTable)this.DataSource;
                    cls.ContractCode = dt.Rows[0]["ContractCode"].ToString();
                    cls.ContractCode = cls.ContractCode.Replace("Đ", "D").Replace("ầ", "a").Replace("ụ", "u");
                    cls.EmployeeCode = dt.Rows[0]["EmployeeCode"].ToString();
                    cls.DateTime = DateTime.Now;
                    cls.Images = System.IO.File.ReadAllBytes(txtfile);
                    cls.UserPrint = Class.App.client_User;
                    cls.Insert();

                    File.Delete(txtfile);
                }
            }
            catch { }
        }

    }
}
