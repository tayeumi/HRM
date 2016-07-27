using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Globalization;

namespace HRM.Reports
{
    public partial class reportBangChamCongTongHop_30 : DevExpress.XtraReports.UI.XtraReport
    {
        public reportBangChamCongTongHop_30()
        {
            InitializeComponent();
        }
         public reportBangChamCongTongHop_30(int thang,int nam,string Loai)
        {
            InitializeComponent();
            TinhNgayCong(thang, nam);
            if (Loai == "PB")
            {
                lblBoPhan.Visible = true;
                lblNhom.Visible = false;
            }
            if (Loai == "NHOM")
            {
                lblBoPhan.Visible = false;
                lblNhom.Visible = true;
            }
            if (Loai == "ALL")
            {
                lblBoPhan.Visible = false;
                lblNhom.Visible = false;
            }
        }

        private void TinhNgayCong(int _Month, int _Year)
        {
            int _DayNumber = DateTime.DaysInMonth(_Year, _Month);

            lblNgayTrongThang.Text = ": " + _DayNumber.ToString();
            if (_Month.ToString().Length == 1)
            {
                lblThangCC.Text = "THÁNG 0" + _Month + " NĂM " + _Year;
                lblTieuDe.Text = "BẢNG CHẤM CÔNG TỔNG HỢP THÁNG 0" + _Month + "/" + _Year; ;
            }
            else
            {
                lblThangCC.Text = "THÁNG " + _Month + " NĂM " + _Year;
                lblTieuDe.Text = "BẢNG CHẤM CÔNG TỔNG HỢP THÁNG " + _Month + "/" + _Year; ;


            }

            int SNCN = 0;
            CultureInfo ci = new CultureInfo("en-US");
            for (int k = 1; k <= ci.Calendar.GetDaysInMonth(_Year, _Month); k++)
            {
                if (new DateTime(_Year, _Month, k).DayOfWeek == DayOfWeek.Sunday)
                    SNCN++;
            }
            lblCongChuan.Text = ": "+(_DayNumber - SNCN).ToString();


            List<string> list = new List<string>();
            for (int i = 1; i < _DayNumber + 1; i++)
            {
                DateTime date = new DateTime(_Year, _Month, i);
                string txt = date.DayOfWeek.ToString();
                list.Add(txt.Substring(0, 3));
                #region set color at Sunday
                if (txt.Equals("Sunday"))
                {
                    switch (list.Count)
                    {
                        case 1:
                            D1.BackColor = System.Drawing.Color.LightGray;
                            colD1.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 2:
                            D2.BackColor = System.Drawing.Color.LightGray;
                            colD2.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 3:
                            D3.BackColor = System.Drawing.Color.LightGray;
                            colD3.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 4:
                            D4.BackColor = System.Drawing.Color.LightGray;
                            colD4.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 5:
                            D5.BackColor = System.Drawing.Color.LightGray;
                            colD5.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 6:
                            D6.BackColor = System.Drawing.Color.LightGray;
                            colD6.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 7:
                            D7.BackColor = System.Drawing.Color.LightGray;
                            colD7.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 8:
                            D8.BackColor = System.Drawing.Color.LightGray;
                            colD8.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 9:
                            D9.BackColor = System.Drawing.Color.LightGray;
                            colD9.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 10:
                            D10.BackColor = System.Drawing.Color.LightGray;
                            colD10.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 11:
                            D11.BackColor = System.Drawing.Color.LightGray;
                            colD11.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 12:
                            D12.BackColor = System.Drawing.Color.LightGray;
                            colD12.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 13:
                            D13.BackColor = System.Drawing.Color.LightGray;
                            colD13.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 14:
                            D14.BackColor = System.Drawing.Color.LightGray;
                            colD14.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 15:
                            D15.BackColor = System.Drawing.Color.LightGray;
                            colD15.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 16:
                            D16.BackColor = System.Drawing.Color.LightGray;
                            colD16.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 17:
                            D17.BackColor = System.Drawing.Color.LightGray;
                            colD17.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 18:
                            D18.BackColor = System.Drawing.Color.LightGray;
                            colD18.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 19:
                            D19.BackColor = System.Drawing.Color.LightGray;
                            colD19.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 20:
                            D20.BackColor = System.Drawing.Color.LightGray;
                            colD20.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 21:
                            D21.BackColor = System.Drawing.Color.LightGray;
                            colD21.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 22:
                            D22.BackColor = System.Drawing.Color.LightGray;
                            colD22.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 23:
                            D23.BackColor = System.Drawing.Color.LightGray;
                            colD23.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 24:
                            D24.BackColor = System.Drawing.Color.LightGray;
                            colD24.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 25:
                            D25.BackColor = System.Drawing.Color.LightGray;
                            colD25.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 26:
                            D26.BackColor = System.Drawing.Color.LightGray;
                            colD26.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 27:
                            D27.BackColor = System.Drawing.Color.LightGray;
                            colD27.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 28:
                            D28.BackColor = System.Drawing.Color.LightGray;
                            colD28.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 29:
                            D29.BackColor = System.Drawing.Color.LightGray;
                            colD29.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 30:
                            D30.BackColor = System.Drawing.Color.LightGray;
                            colD30.BackColor = System.Drawing.Color.LightGray;
                            break;                       
                    }
                }
                #endregion
            }
            D1.Text =   list[0];
            D2.Text =  list[1];
            D3.Text = list[2];
            D4.Text =  list[3];
            D5.Text =  list[4];
            D6.Text =  list[5];
            D7.Text =  list[6];
            D8.Text =  list[7];
            D9.Text =  list[8];
            D10.Text = list[9];
            D11.Text =  list[10];
            D12.Text = list[11];
            D13.Text =  list[12];
            D14.Text =list[13];
            D15.Text =  list[14];
            D16.Text =  list[15];
            D17.Text =  list[16];
            D18.Text =  list[17];
            D19.Text =  list[18];
            D20.Text =  list[19];
            D21.Text = list[20];
            D22.Text =  list[21];
            D23.Text = list[22];
            D24.Text =  list[23];
            D25.Text =  list[24];
            D26.Text =  list[25];
            D27.Text = list[26];
            D28.Text = list[27];

            
            if (_DayNumber == 28)
            {
                D29.Visible = false;
                D30.Visible = false;
              
            }
            else if (_DayNumber == 29)
            {
                D30.Visible = false;
                D29.Text = list[28];
            }
            else if (_DayNumber == 30)
            {
                D29.Text =  list[28];
                D30.Text = list[29];
            }
            else if (_DayNumber == 31)
            {
                D29.Text =  list[28];
                D30.Text =  list[29];
            }
            
        }
    }
}
