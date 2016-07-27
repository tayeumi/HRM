using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HRM.Reports
{
    public partial class ReportQuyetDinhThoiViec : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportQuyetDinhThoiViec()
        {
            InitializeComponent();
        }
        public ReportQuyetDinhThoiViec(string BoPhan,string Sex,string FullName)
        {
            InitializeComponent();
            lblBoPhan.Text = BoPhan;
            lblSex2.Text =  Sex;
            //lblFulName1.Text = FullName + lblFulName1.Text;
          //  lblFulName2.Text = FullName + lblFulName2.Text;
           // lblFulName3.Text = FullName + lblFulName3.Text;
            //lblFulName4.Text = FullName + lblFulName4.Text;
        }
        public ReportQuyetDinhThoiViec(string BoPhan, string Sex, string FullName, string CanCuNoiDung, string SoHopDongHienTai, string NgayKy, string SoBaoHiem)
        {
            InitializeComponent();
            lblBoPhan.Text = BoPhan;
            lblSex2.Text = Sex;
           // lblFulName1.Text = FullName + lblFulName1.Text;
          //  lblFulName2.Text = FullName + lblFulName2.Text;
           // lblFulName3.Text = FullName + lblFulName3.Text;
          //  lblFulName4.Text = FullName + lblFulName4.Text;
            lblCanCu.Text = CanCuNoiDung;
            lblFullname2.Text =  FullName + " có trách nhiệm bàn giao công việc và hoàn trả tất cả tài sản, trang thiết bị";
            lblFullname3.Text = "Trưởng các phòng ban liên quan," + FullName + " chịu trách nhiệm thi hành quyết định này.";
            lblFullname4.Text =  FullName + " sẽ được thanh toán đầy đủ lương, trợ cấp ";
            lblSoHDHienTai.Text = SoHopDongHienTai;
            lblNgayKy.Text = NgayKy;
            lblSoSoBaoHiem.Text = SoBaoHiem;
        }

    }
}
