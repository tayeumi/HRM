using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;

namespace HRM.Forms
{
    public partial class frmDanhSachNhanVien_Import : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhanVien_Import()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private void frmDanhSachNhanVien_Import_Load(object sender, EventArgs e)
        {
            string filemau = Directory.GetCurrentDirectory() +@"\ImportFile\Employee.xls";
            linkFile.Text = "File mẫu : "+filemau;

            dt.Columns.Add("EmployeeCode", Type.GetType("System.String"));
            dt.Columns.Add("FirstName", Type.GetType("System.String"));
            dt.Columns.Add("LastName", Type.GetType("System.String"));
            dt.Columns.Add("Birthday", Type.GetType("System.DateTime"));
            dt.Columns.Add("BirthPlace", Type.GetType("System.String"));
            dt.Columns.Add("Sex", Type.GetType("System.Boolean"));
            dt.Columns.Add("CellPhone", Type.GetType("System.String"));
            dt.Columns.Add("MainAddress", Type.GetType("System.String"));
            dt.Columns.Add("IDCard", Type.GetType("System.String"));
            dt.Columns.Add("IDCardDate", Type.GetType("System.DateTime"));
            dt.Columns.Add("IDCardPlace", Type.GetType("System.String"));
            dt.Columns.Add("Chon", Type.GetType("System.Boolean"));
            dt.Columns.Add("KiemTra", Type.GetType("System.String"));
        }

        private void linkFile_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + @"\ImportFile\Employee.xls"))
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\ImportFile\Employee.xls");
            else
                MessageBox.Show("Không tìm thấy file mẫu trong đường dẫn trên.");
        }
     
        private void btnChon_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel 2007|*.xlsx| Excel 2003|*.xls";
            open.Title = "Select Excel file";
            open.ShowDialog();            
            txtDuongDan.Text = open.FileName;
            if (txtDuongDan.Text.Length > 0)
                btnDocFile.Enabled = true;
            else
                btnDocFile.Enabled = false;
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            if (txtDuongDan.Text.Length > 0)
            {
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                Microsoft.Office.Interop.Excel.Range range;

                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open(txtDuongDan.Text, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;

                if (range.Rows.Count > 0)
                {
                    btnKiemTraDuLieu.Enabled = true;
                    btnXoaDuLieu.Enabled = true;
                }
              
                // string str;

                int rCnt = 0;
                //int stt = 0;
                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    try
                    {
                        if ((xlWorkSheet.get_Range("A" + rCnt, "A" + rCnt).Value2 != null) || (xlWorkSheet.get_Range("A" + rCnt, "A" + rCnt).Value2.ToString() == ""))
                        {
                            DataRow dr = dt.NewRow();

                            if (xlWorkSheet.get_Range("A" + rCnt, "A" + rCnt).Value2 != null)
                            {
                                dr[0] = xlWorkSheet.get_Range("A" + rCnt, "A" + rCnt).Value2.ToString();
                            }                           
                            if (xlWorkSheet.get_Range("B" + rCnt, "B" + rCnt).Value2 != null)
                            {
                                dr[1] = xlWorkSheet.get_Range("B" + rCnt, "B" + rCnt).Value2.ToString();
                            }
                            else
                            {
                                dr[1] = "";
                            }
                            if (xlWorkSheet.get_Range("C" + rCnt, "C" + rCnt).Value2 != null)
                            {
                                dr[2] = xlWorkSheet.get_Range("C" + rCnt, "C" + rCnt).Value2.ToString();
                            }
                            else
                            {
                                dr[2] = "";
                            }
                            if (xlWorkSheet.get_Range("D" + rCnt, "D" + rCnt).Value2 != null)
                            {
                              //  MessageBox.Show("" + xlWorkSheet.get_Range("D" + rCnt, "D" + rCnt).Value2);
                                dr[3] = DateTime.Parse(xlWorkSheet.get_Range("D" + rCnt, "D" + rCnt).Value2.ToString());
                              //  dr[3] = DateTime.FromOADate(d);
                               // MessageBox.Show("" + dr[3]);
                            }
                           else                           
                            {
                                dr[3] = DateTime.Now;
                            }

                            if (xlWorkSheet.get_Range("E" + rCnt, "E" + rCnt).Value2 != null)
                            {
                                dr[4] = xlWorkSheet.get_Range("E" + rCnt, "E" + rCnt).Value2.ToString();
                            }
                            else
                            {
                                dr[4] = "";
                            }
                            if (xlWorkSheet.get_Range("F" + rCnt, "F" + rCnt).Value2 != null)
                            {                               
                                 if(xlWorkSheet.get_Range("F" + rCnt, "F" + rCnt).Value2.ToString().Trim()=="Nam")
                                     dr[5] = true;
                                 else
                                      dr[5] = false;
                            }
                            else
                            {
                                dr[5] = true;
                            }
                            if (xlWorkSheet.get_Range("G" + rCnt, "G" + rCnt).Value2 != null)
                            {
                                dr[6] = xlWorkSheet.get_Range("G" + rCnt, "G" + rCnt).Value2.ToString();
                            }
                            else
                            {
                                dr[6] = "";
                            }
                            if (xlWorkSheet.get_Range("H" + rCnt, "H" + rCnt).Value2 != null)
                            {
                                dr[7] = xlWorkSheet.get_Range("H" + rCnt, "H" + rCnt).Value2.ToString();
                            }
                            else
                            {
                                dr[7] = "";
                            }
                            if (xlWorkSheet.get_Range("I" + rCnt, "I" + rCnt).Value2 != null)
                            {
                                dr[8] = xlWorkSheet.get_Range("I" + rCnt, "I" + rCnt).Value2.ToString();
                            }
                            else
                            {
                                dr[8] = "";
                            }
                            if (xlWorkSheet.get_Range("J" + rCnt, "J" + rCnt).Value2 != null)
                            {
                                dr[9] = DateTime.Parse(xlWorkSheet.get_Range("J" + rCnt, "J" + rCnt).Value2.ToString());
                              //  dr[9] = DateTime.FromOADate(d);
                            }
                            else
                            {
                                dr[9] = DateTime.Now;
                            }
                            if (xlWorkSheet.get_Range("K" + rCnt, "K" + rCnt).Value2 != null)
                            {
                                dr[10] = xlWorkSheet.get_Range("K" + rCnt, "K" + rCnt).Value2.ToString();
                            }
                            else
                            {
                                dr[10] = "";
                            }

                            dr[11] = true;
                            dr[12] = "0";
                            dt.Rows.Add(dr);
                        }
                       
                           
                       
                    }
                    catch 
                    { 
                        rCnt = range.Rows.Count; // thoat vong for khi ko co du lieu
                    }
                }
                 xlWorkBook.Close(true, misValue, misValue);
                 xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                gridItem.DataSource = dt;
                btnKiemTraDuLieu.Enabled = true;
            }

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            dt.Clear();
            gridItem.DataSource = null;
            btnKiemTraDuLieu.Enabled = false;
            btnImport.Enabled = false;
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;
            //Check whether the indicator cell belongs to a data row
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }

        private void btnKiemTraDuLieu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string manv = dt.Rows[i]["EmployeeCode"].ToString();
                Class.NhanVien nv = new Class.NhanVien();
                DataTable dtnv=  nv.GetEmployeeByCode(manv);
                if (dtnv.Rows.Count > 0)
                {
                   dt.Rows[i]["Chon"] = false;
                   dt.Rows[i]["KiemTra"] = "1";                  
                }
            }
            MessageBox.Show(" Hãy check chọn dữ liệu cần thêm vào CSDL");
            btnImport.Enabled = true;
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (checkAll.Checked)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][11] = true;
                    }

                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][11] = false;
                    }

                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Class.NhanVien nv = new Class.NhanVien();
            if (checkStatus.Checked)
            {
                nv.Status = 1;
            }
            else
            {
                nv.Status = 3;
            }
            if (nv.Import(dt))
            {
                MessageBox.Show("Nạp dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nạp dữ liệu thất bại. Vui lòng kiểm tra dữ liệu đầu vào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnImport.Enabled = false;
        }

        private void gridItemDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridItemDetail.PostEditor();
        }
    }
}