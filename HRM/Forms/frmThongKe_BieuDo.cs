using System;
using System.Data;
using DevExpress.XtraCharts;
using DevExpress.Utils;
using DevExpress.XtraPrinting;

namespace HRM.Forms
{
    public partial class frmThongKe_BieuDo : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKe_BieuDo()
        {
            InitializeComponent();
        }

        private void frmThongKe_BieuDo_Load(object sender, EventArgs e)
        {
            HRM_EMPLOYEE_GetSex();
            HRM_EMPLOYEE_GetAge();
            HRM_EMPLOYEE_GetPosition();
            HRM_EMPLOYEE_GetEducation();
            HRM_EMPLOYEE_GetEthnic();
            HRM_EMPLOYEE_GetReligion();
            HRM_EMPLOYEE_GetNationality();
            HRM_EMPLOYEE_GetMarriage();
            HRM_EMPLOYEE_GetRate();
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Biểu đồ giới tính";
            chartGioiTinh.Titles.Add(chartTitle1);

            ChartTitle chartTitle2 = new ChartTitle();
            chartTitle2.Text = "Biểu đồ độ tuổi";
            chartDoTuoi.Titles.Add(chartTitle2);


            ChartTitle chartTitle3 = new ChartTitle();
            chartTitle3.Text = "Biểu đồ chức vụ";
            chartChucVu.Titles.Add(chartTitle3);

            ChartTitle chartTitle4 = new ChartTitle();
            chartTitle4.Text = "Biểu đồ trình độ";
            chartTrinhDo.Titles.Add(chartTitle4);

            ChartTitle chartTitle5 = new ChartTitle();
            chartTitle5.Text = "Biểu đồ dân tộc";
            chartDanToc.Titles.Add(chartTitle5);

            ChartTitle chartTitle6 = new ChartTitle();
            chartTitle6.Text = "Biểu đồ tôn giáo";
            chartTonGiao.Titles.Add(chartTitle6);

            ChartTitle chartTitle7 = new ChartTitle();
            chartTitle7.Text = "Biểu đồ quốc tịch";
            chartQuocTich.Titles.Add(chartTitle7);

            ChartTitle chartTitle8 = new ChartTitle();
            chartTitle8.Text = "Biểu đồ Tình trạng hôn nhân";
            chartTinhTrangHonNhan.Titles.Add(chartTitle8);

            ChartTitle chartTitle9 = new ChartTitle();
            chartTitle9.Text = "Biểu đồ tăng Nhân sự theo năm";
            chartTheoNam.Titles.Add(chartTitle9);
        }
        private void HRM_EMPLOYEE_GetAllSex()
        {
            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetAllSex();
           // chartGioiTinh.DataSource = dt;
            Series series1 = new Series("Nam", ViewType.Bar);
            Series series2 = new Series("Nữ", ViewType.Bar);
            chartGioiTinh.Series.Clear();
            series1.Points.Add(new SeriesPoint("Nam", dt.Rows[0]["Man"].ToString()));
            series2.Points.Add(new SeriesPoint("Nữ", dt.Rows[0]["Woman"].ToString()));
            
            chartGioiTinh.Series.AddRange(new Series[] { series1, series2 });
           chartGioiTinh.Series[0].LabelsVisibility = DefaultBoolean.True;
           chartGioiTinh.Series[1].LabelsVisibility = DefaultBoolean.True;
                    
        }

        private void cboSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSex.SelectedIndex == 0)
            {
                HRM_EMPLOYEE_GetAllSex();
            }
            else
            {
                HRM_EMPLOYEE_GetSex();
            }
        }
        private void HRM_EMPLOYEE_GetSex()
        {
            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetSex();
            // chartGioiTinh.DataSource = dt;
            Series series1 = new Series("Nam", ViewType.Bar);
            Series series2 = new Series("Nữ", ViewType.Bar);

            series1.Points.Add(new SeriesPoint("Nam", dt.Rows[0]["Man"].ToString()));
            series2.Points.Add(new SeriesPoint("Nữ", dt.Rows[0]["Woman"].ToString()));
            chartGioiTinh.Series.Clear();
            chartGioiTinh.Series.AddRange(new Series[] { series1, series2 });
            chartGioiTinh.Series[0].LabelsVisibility = DefaultBoolean.True;
            chartGioiTinh.Series[1].LabelsVisibility = DefaultBoolean.True;
            // chartGioiTinh.SeriesTemplate.LabelsVisibility = DefaultBoolean.True;            
        }

        private void btnPrintGT_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            chartGioiTinh.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            chartGioiTinh.ShowPrintPreview();       
        }

        private void HRM_EMPLOYEE_GetAge()
        {
            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetAge();
            Series series1 = new Series("Dưới 18", ViewType.Bar);
            Series series2 = new Series("18-20", ViewType.Bar);
            Series series3 = new Series("20-30", ViewType.Bar);
            Series series4 = new Series("30-40", ViewType.Bar);
            Series series5 = new Series("40-50", ViewType.Bar);
            Series series6 = new Series("Trên 50", ViewType.Bar);
            series1.Points.Add(new SeriesPoint("Dưới 18", dt.Rows[0]["age18"].ToString()));
            series2.Points.Add(new SeriesPoint("18-20", dt.Rows[0]["age1820"].ToString()));
            series3.Points.Add(new SeriesPoint("20-30", dt.Rows[0]["age2030"].ToString()));
            series4.Points.Add(new SeriesPoint("30-40", dt.Rows[0]["age3040"].ToString()));
            series5.Points.Add(new SeriesPoint("40-50", dt.Rows[0]["age4050"].ToString()));
            series6.Points.Add(new SeriesPoint("Trên 50", dt.Rows[0]["age50"].ToString()));
            chartDoTuoi.Series.AddRange(new Series[] { series1, series2, series3, series4, series5, series6 });

            for (int i = 0; i < chartDoTuoi.Series.Count; i++)
             chartDoTuoi.Series[i].LabelsVisibility = DefaultBoolean.True;
           
        }

        private void btnPrintDoTuoi_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            chartDoTuoi.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            chartDoTuoi.ShowPrintPreview();     

        }

        private void HRM_EMPLOYEE_GetPosition()
        {
            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetPosition();
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                if (dt.Rows[i]["PositionName"].ToString() != "")
                {
                    Series series1 = new Series(dt.Rows[i]["PositionName"].ToString(), ViewType.Bar);
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["PositionName"].ToString(), dt.Rows[i]["Value"].ToString()));
                    chartChucVu.Series.AddRange(new Series[] { series1 });
                }
            }
            for (int i = 0; i < chartChucVu.Series.Count; i++)
                chartChucVu.Series[i].LabelsVisibility = DefaultBoolean.True;
        }

        private void btnPrintChucVu_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            link.Component = chartChucVu;

            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A3;
            link.ShowPreview();
            
          //  chartChucVu.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            
          //  chartChucVu.ShowPrintPreview();
        }

        private void HRM_EMPLOYEE_GetEducation()
        {
            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetEducation();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series series1 = new Series(dt.Rows[i]["EducationName"].ToString(), ViewType.Bar);
                series1.Points.Add(new SeriesPoint(dt.Rows[i]["EducationName"].ToString(), dt.Rows[i]["Value"].ToString()));
                    chartTrinhDo.Series.AddRange(new Series[] { series1 });
                
            }
            for (int i = 0; i < chartTrinhDo.Series.Count; i++)
                chartTrinhDo.Series[i].LabelsVisibility = DefaultBoolean.True;

        }

        private void btnPrintTrinhDo_Click(object sender, EventArgs e)
        {
            chartTrinhDo.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            chartTrinhDo.ShowPrintPreview();
        }

        private void HRM_EMPLOYEE_GetNationality()
        {
            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetNationality();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series series1 = new Series(dt.Rows[i]["Nationality"].ToString(), ViewType.Bar);
                series1.Points.Add(new SeriesPoint(dt.Rows[i]["Nationality"].ToString(), dt.Rows[i]["Value"].ToString()));
                chartQuocTich.Series.AddRange(new Series[] { series1 });

            }
            for (int i = 0; i < chartQuocTich.Series.Count; i++)
                chartQuocTich.Series[i].LabelsVisibility = DefaultBoolean.True;

        }

       
        private void HRM_EMPLOYEE_GetReligion()
        {
            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetReligion();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series series1 = new Series(dt.Rows[i]["Religion"].ToString(), ViewType.Bar);
                series1.Points.Add(new SeriesPoint(dt.Rows[i]["Religion"].ToString(), dt.Rows[i]["Value"].ToString()));
                chartTonGiao.Series.AddRange(new Series[] { series1 });

            }
            for (int i = 0; i < chartTonGiao.Series.Count; i++)
                chartTonGiao.Series[i].LabelsVisibility = DefaultBoolean.True;

        }

        private void btnPrintTonGiao_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            chartTonGiao.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            chartTonGiao.ShowPrintPreview();
        }

        private void HRM_EMPLOYEE_GetMarriage()
        {
            try
            {
                Class.ThongKe tk = new Class.ThongKe();
                DataTable dt = tk.HRM_EMPLOYEE_GetMarriage();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Series series1 = new Series(dt.Rows[i]["Marriage"].ToString(), ViewType.Bar);
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["Marriage"].ToString(), dt.Rows[i]["Value"].ToString()));
                    chartTinhTrangHonNhan.Series.AddRange(new Series[] { series1 });

                }
                for (int i = 0; i < chartTinhTrangHonNhan.Series.Count; i++)
                    chartTinhTrangHonNhan.Series[i].LabelsVisibility = DefaultBoolean.True;
            }
            catch { }
        }

        private void btnPrintTinhTrangHonNhan_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            chartTinhTrangHonNhan.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            chartTinhTrangHonNhan.ShowPrintPreview();
        }
        private void HRM_EMPLOYEE_GetEthnic()
        {

            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetEthnic();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series series1 = new Series(dt.Rows[i]["Ethnic"].ToString(), ViewType.Bar);
                series1.Points.Add(new SeriesPoint(dt.Rows[i]["Ethnic"].ToString(), dt.Rows[i]["Value"].ToString()));
                chartDanToc.Series.AddRange(new Series[] { series1 });

            }
            for (int i = 0; i < chartDanToc.Series.Count; i++)
                chartDanToc.Series[i].LabelsVisibility = DefaultBoolean.True;
        }

        private void btnPrintQuocTich_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            chartQuocTich.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            chartQuocTich.ShowPrintPreview();
        }

        private void HRM_EMPLOYEE_GetRate()
        {
            Class.ThongKe tk = new Class.ThongKe();
            DataTable dt = tk.HRM_EMPLOYEE_GetRate();
            // chartGioiTinh.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series series1 = new Series(dt.Rows[i]["Year"].ToString(), ViewType.Bar);
                series1.Points.Add(new SeriesPoint(dt.Rows[i]["Year"].ToString(), dt.Rows[i]["NumberLabour"].ToString()));
                chartTheoNam.Series.AddRange(new Series[] { series1 });

            }
            for (int i = 0; i < chartTheoNam.Series.Count; i++)
                chartTheoNam.Series[i].LabelsVisibility = DefaultBoolean.True; 
        }

        private void btnPrintTheoNam_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            chartTheoNam.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Zoom;
            chartTheoNam.ShowPrintPreview();
        }

    }
}