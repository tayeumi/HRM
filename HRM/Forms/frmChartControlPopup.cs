using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.Utils;

namespace HRM.Forms
{
    public partial class frmChartControlPopup : DevExpress.XtraEditors.XtraForm
    {
        public frmChartControlPopup()
        {
            InitializeComponent();
        }
        public frmChartControlPopup(DataTable dt)
        {
            InitializeComponent();
        }
        public frmChartControlPopup(DataTable dt,int type)
        {
            InitializeComponent();

            if (type == 0)
            {
                ChartTitle chartTitle1 = new ChartTitle();
                this.Text = chartTitle1.Text = "Tỉ lệ NV đi trễ từ 6 đến 14 phút";
                chartControl.Titles.Add(chartTitle1);                             
                

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Series series1 = new Series(dt.Rows[i]["DepartmentName"].ToString(), ViewType.Bar);

                    series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                    series1.Label.PointOptions.ValueNumericOptions.Precision = 0;
                    
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["tile1"].ToString()));
                    chartControl.Series.AddRange(new Series[] { series1 });
                    XYDiagram diagram1 = chartControl.Diagram as XYDiagram;
                    diagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                    diagram1.AxisY.NumericOptions.Precision = 0;



                }
                for (int i = 0; i < chartControl.Series.Count; i++)
                {
                    chartControl.Series[i].LabelsVisibility = DefaultBoolean.True;
                   
                }
            }
            else if (type == 1)
            {
                ChartTitle chartTitle1 = new ChartTitle();
                this.Text = chartTitle1.Text = "Tỉ lệ NV đi trễ từ 15 phút trở đi";
                chartControl.Titles.Add(chartTitle1);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Series series1 = new Series(dt.Rows[i]["DepartmentName"].ToString(), ViewType.Bar);

                    series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                    series1.Label.PointOptions.ValueNumericOptions.Precision = 0;

                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["tile2"].ToString()));
                    chartControl.Series.AddRange(new Series[] { series1 });
                    XYDiagram diagram1 = chartControl.Diagram as XYDiagram;
                    diagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                    diagram1.AxisY.NumericOptions.Precision = 0;



                }
                for (int i = 0; i < chartControl.Series.Count; i++)
                {
                    chartControl.Series[i].LabelsVisibility = DefaultBoolean.True;

                }
            }
            else if (type == 2)
            {
                ChartTitle chartTitle1 = new ChartTitle();
                this.Text = chartTitle1.Text = "Tỉ lệ NV về sớm từ 6 đến 14 phút";
                chartControl.Titles.Add(chartTitle1);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Series series1 = new Series(dt.Rows[i]["DepartmentName"].ToString(), ViewType.Bar);

                    series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                    series1.Label.PointOptions.ValueNumericOptions.Precision = 0;

                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["tile1"].ToString()));
                    chartControl.Series.AddRange(new Series[] { series1 });
                    XYDiagram diagram1 = chartControl.Diagram as XYDiagram;
                    diagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                    diagram1.AxisY.NumericOptions.Precision = 0;



                }
                for (int i = 0; i < chartControl.Series.Count; i++)
                {
                    chartControl.Series[i].LabelsVisibility = DefaultBoolean.True;

                }
            }
            else if (type == 3)
            {
                ChartTitle chartTitle1 = new ChartTitle();
                this.Text = chartTitle1.Text = "Tỉ lệ NV về sớm từ 15 phút trở đi";
                chartControl.Titles.Add(chartTitle1);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Series series1 = new Series(dt.Rows[i]["DepartmentName"].ToString(), ViewType.Bar);

                    series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                    series1.Label.PointOptions.ValueNumericOptions.Precision = 0;

                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["tile2"].ToString()));
                    chartControl.Series.AddRange(new Series[] { series1 });
                    XYDiagram diagram1 = chartControl.Diagram as XYDiagram;
                    diagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                    diagram1.AxisY.NumericOptions.Precision = 0;



                }
                for (int i = 0; i < chartControl.Series.Count; i++)
                {
                    chartControl.Series[i].LabelsVisibility = DefaultBoolean.True;

                }
            }

        }
    }
}