using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace HRM.Reports
{
    public partial class reportHopDongLaoDong : DevExpress.XtraReports.UI.XtraReport
    {
        public reportHopDongLaoDong()
        {
            InitializeComponent();
        }

        public reportHopDongLaoDong(DataTable dt)
        {
            InitializeComponent();
             if (dt.Rows[0]["BranchName"].ToString()=="BBS2")
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
        }

        private void reportHopDongLaoDong_PrintProgress(object sender, DevExpress.XtraPrinting.PrintProgressEventArgs e)
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
