using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace HRM.Forms
{
    public partial class frmChamCong_KetNoi : DevExpress.XtraEditors.XtraForm
    {
        public frmChamCong_KetNoi()
        {
            InitializeComponent();
        }
        string template_grid = Application.StartupPath + @"\Templates\Templates_CCINOUT.xml";
        private void frmChamCong_KetNoi_Load(object sender, EventArgs e)
        {
            if (File.Exists(template_grid))
            {
                // gridItemDetail.SaveLayoutToXml(template_grid);
                gridItemDetail.RestoreLayoutFromXml(template_grid);
            }
            DIC_MACHINE_GetList_ToCBO();
            dateFrom.DateTime = DateTime.Today;
            dateTo.DateTime = DateTime.Today.AddHours(23);
            dateTHFrom.DateTime = DateTime.Today;
            dateTHTo.DateTime = DateTime.Today.AddHours(23);

            
        }
        private void DIC_MACHINE_GetList_ToCBO()
        {
            Class.DanhMuc_ThietBiChamCong dm = new Class.DanhMuc_ThietBiChamCong();
            cboListDevice.DataSource = dm.DIC_MACHINE_GetList();
            cboListDevice.ValueMember = "MachineCode";
            cboListDevice.DisplayMember = "MachineName";

        }
        zkemkeeper.CZKEMClass axczkem1 = new zkemkeeper.CZKEMClass();
        bool bIsConnected = false;
        int id;
        string ip;
        int port;

        string product = "";

        private void btnConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cboDeivice.EditValue != null)
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang kết nối thiết bị");
                try
                {
                    Class.DanhMuc_ThietBiChamCong dm = new Class.DanhMuc_ThietBiChamCong();
                    DataTable dt = dm.GetMachineByCode(cboDeivice.EditValue.ToString());
                    id = int.Parse(dt.Rows[0]["MachineCode"].ToString());
                    ip = dt.Rows[0]["IP"].ToString();
                    port = int.Parse(dt.Rows[0]["PortID"].ToString());
                    string MachineName = dt.Rows[0]["MachineName"].ToString();
                    if (MachineName.IndexOf("TFT") > 0)
                    {
                        product = "1";
                    }
                    else
                    {
                        product = "0";
                    }
                    if (dt.Rows[0]["Password"].ToString().Length > 0)
                    {
                        axczkem1.SetCommPassword(int.Parse(dt.Rows[0]["Password"].ToString()));
                    }
                    bIsConnected = axczkem1.Connect_Net(ip, port);
                    int idwErrorCode = 0;

                    if (bIsConnected)
                    {
                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;
                        btnLoadData.Enabled = true;
                        cboDeivice.Enabled = false;
                        lblStatus.Text = "<image=State_Validation_Valid_48x48.png>  Đang kết nối";
                    }
                    else
                    {
                        axczkem1.GetLastError(ref idwErrorCode);
                        MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                    }
                    Class.S_Log.Insert("Chấm công", "Kết nối thiết bị chấm công");
                }               
                catch { }

                Waiting.CloseWaitForm();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thết bị");
            }
        }

        private void btnDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            axczkem1.Disconnect();
            bIsConnected = false;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnLoadData.Enabled = false;
            cboDeivice.Enabled = true;
            product = "";
            lblStatus.Text = "<image=State_Validation_Invalid_48x48.png>  Chưa kết nối";
            Class.S_Log.Insert("Chấm công", "Ngưng Kết nối thiết bị chấm công");
        }

        private void btnLoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang đọc dữ liệu chấm công..");
            Class.S_Log.Insert("Chấm công", "Tải dữ liệu từ máy chấm công về máy tính");
            dtxp.Clear();
            btnExportExcelTemplate.Enabled = false;
            btnExportExcelTemplateByGroup.Enabled = false;
            colMachineNumber.Visible = true;
            colTimeStr.Visible = true;
            colDepartmentName.Visible = false;
            colGroupName.Visible = false;
            colTimeIn.Visible = false;
            colTimeOut.Visible = false;
            colDayStr.Visible = false;
            colDateStr.Visible = false;
            colIndex.Visible = false;
            //create datatabe
            DataTable dt = new DataTable();
            dt.Columns.Add("InOutCode", Type.GetType("System.String"));
            dt.Columns.Add("MachineNumber", Type.GetType("System.String"));
            dt.Columns.Add("EnrollNumber", Type.GetType("System.String"));
            dt.Columns.Add("VerifyMode", Type.GetType("System.String"));
            dt.Columns.Add("InOutMode", Type.GetType("System.String"));
            dt.Columns.Add("Year", Type.GetType("System.String"));
            dt.Columns.Add("Month", Type.GetType("System.String"));
            dt.Columns.Add("Day", Type.GetType("System.String"));
            dt.Columns.Add("Hour", Type.GetType("System.String"));
            dt.Columns.Add("Minute", Type.GetType("System.String"));
            dt.Columns.Add("Second", Type.GetType("System.String"));
            dt.Columns.Add("TimeStr", Type.GetType("System.DateTime"));

             DataTable dtChange = new DataTable();
            dtChange.Columns.Add("InOutCode", Type.GetType("System.String"));
            dtChange.Columns.Add("MachineNumber", Type.GetType("System.String"));
            dtChange.Columns.Add("EnrollNumber", Type.GetType("System.String"));
            dtChange.Columns.Add("VerifyMode", Type.GetType("System.String"));
            dtChange.Columns.Add("InOutMode", Type.GetType("System.String"));
            dtChange.Columns.Add("Year", Type.GetType("System.String"));
            dtChange.Columns.Add("Month", Type.GetType("System.String"));
            dtChange.Columns.Add("Day", Type.GetType("System.String"));
            dtChange.Columns.Add("Hour", Type.GetType("System.String"));
            dtChange.Columns.Add("Minute", Type.GetType("System.String"));
            dtChange.Columns.Add("Second", Type.GetType("System.String"));
            dtChange.Columns.Add("TimeStr", Type.GetType("System.DateTime"));
            dtChange.Columns.Add("EmployeeCode", Type.GetType("System.String"));
            dtChange.Columns.Add("FirstName", Type.GetType("System.String"));
            dtChange.Columns.Add("LastName", Type.GetType("System.String"));
            
            #region Goi Du Lieu May Cham Cong
            Waiting.SetWaitFormDescription("Đang tải dữ liệu chấm công từ thiết bị..");
            //int step = 1;
            if (bIsConnected)
            {
                if (product == "0")
                {
                    bool ret = axczkem1.ReadAllGLogData(id);
                    Application.DoEvents();
                    if (ret)
                    {
                        int a = 0;
                        int b = 0;
                        int c = 0;
                        int d = 0;
                        int ee = 0;
                        int f = 0;
                        int g = 0;
                        int h = 0;
                        int ii = 0;
                        int k = 0;
                        int l = 0;
                        //sw.Write("MachineNumber,EnrollNumber,VerifyMode,InOutMode,Year,Month,Day,Hour,Minute,Second,,, \r\n");
                        while (axczkem1.GetGeneralExtLogData(id, ref a, ref b, ref c, ref d, ref ee, ref f, ref g, ref h, ref ii, ref k, ref l))
                        {
                            //step++;
                           // Waiting.SetWaitFormDescription("Đang tải dữ liệu..("+step.ToString()+")");
                            //Thread.Sleep(1);
                            //Application.DoEvents();
                            DataRow dr = dt.NewRow();
                            dr[0] = id + a.ToString() + d.ToString() + ee.ToString() + f.ToString() + g.ToString() + h.ToString() + ii.ToString();
                            dr[1] = id;
                            dr[2] = a.ToString();
                            dr[3] = b.ToString();
                            dr[4] = c.ToString();
                            dr[5] = d.ToString();
                            dr[6] = ee.ToString();
                            dr[7] = f.ToString();
                            dr[8] = g.ToString();
                            dr[9] = h.ToString();
                            dr[10] = ii.ToString();
                            //string dateString= ee.ToString()+"/"+f.ToString()+"/"+d.ToString()+" "+g.ToString()+":"+h.ToString()+":"+ii.ToString();
                            //  MessageBox.Show(e.ToString()+"-"+ee.ToString()+"-"+f.ToString()+"-"+g.ToString()+"-"+h.ToString()+"-"+id.ToString());
                            dr[11] = new DateTime(d, ee, f, g, h, ii);
                            // dr[11] = DateTime.Parse(dateString);             
                            dt.Rows.Add(dr);
                            Application.DoEvents();
                        }
                    }
                }
                else if (product == "1")
                {
                    bool ret = axczkem1.ReadGeneralLogData(id);
                    Application.DoEvents();
                    if (ret)
                    {
                        string a="" ;
                        int b = 0;
                        int c = 0;
                        int d = 0;
                        int ee = 0;
                        int f = 0;
                        int g = 0;
                        int h = 0;
                        int ii = 0;
                       // int k = 0;
                        int l = 0;
                        //sw.Write("MachineNumber,EnrollNumber,VerifyMode,InOutMode,Year,Month,Day,Hour,Minute,Second,,, \r\n");
                        while (axczkem1.SSR_GetGeneralLogData(id, out a, out b, out c, out d, out ee, out f, out g, out h, out ii,  ref l))
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = id + a.ToString() + d.ToString() + ee.ToString() + f.ToString() + g.ToString() + h.ToString() + ii.ToString();
                            dr[1] = id;
                            dr[2] = a.ToString();
                            dr[3] = b.ToString();
                            dr[4] = c.ToString();
                            dr[5] = d.ToString();
                            dr[6] = ee.ToString();
                            dr[7] = f.ToString();
                            dr[8] = g.ToString();
                            dr[9] = h.ToString();
                            dr[10] = ii.ToString();
                            //string dateString= ee.ToString()+"/"+f.ToString()+"/"+d.ToString()+" "+g.ToString()+":"+h.ToString()+":"+ii.ToString();
                            //  MessageBox.Show(e.ToString()+"-"+ee.ToString()+"-"+f.ToString()+"-"+g.ToString()+"-"+h.ToString()+"-"+id.ToString());
                            dr[11] = new DateTime(d, ee, f, g, h, ii);
                            // dr[11] = DateTime.Parse(dateString);             
                            dt.Rows.Add(dr);
                            Application.DoEvents();
                        }
                    }
                }
            }
           
            #endregion
            Waiting.SetWaitFormDescription("Đang tải dữ liệu hiện tại..");
            Class.ChamCong_CheckInOut cc = new Class.ChamCong_CheckInOut();
            DataTable dtcc = cc.CHECKINOUT_GetList();
            Class.NhanVien nv = new Class.NhanVien();
            nv.Status = -1;
            DataTable dtnv = nv.LoadDanhSachNhanVien_Ex();
            Waiting.SetWaitFormDescription("Đang so sánh dữ liệu hiện tại..");
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow[] result = dtcc.Select("InOutCode='" + dt.Rows[i]["InOutCode"].ToString() + "'");
                    if (result.Length < 1)
                    {
                        // DataTable dtnv = nv.HRM_EMPLOYEE_GetByEnroll(dt.Rows[i]["EnrollNumber"].ToString()); ko su dung chuc năng nay vi làm hao ton bo nho
                        DataRow[] result2 = dtnv.Select("EnrollNumber='" + dt.Rows[i]["EnrollNumber"].ToString() + "'");
                        DataRow dr = dtChange.NewRow();
                        dr[0] = dt.Rows[i][0];
                        dr[1] = dt.Rows[i][1];
                        dr[2] = dt.Rows[i][2];
                        dr[3] = dt.Rows[i][3];
                        dr[4] = dt.Rows[i][4];
                        dr[5] = dt.Rows[i][5];
                        dr[6] = dt.Rows[i][6];
                        dr[7] = dt.Rows[i][7];
                        dr[8] = dt.Rows[i][8];
                        dr[9] = dt.Rows[i][9];
                        dr[10] = dt.Rows[i][10];
                        dr[11] = dt.Rows[i][11];
                        if (result2.Length > 0)
                        {
                            //dr[12] = dtnv.Rows[0]["EmployeeCode"].ToString();
                            //dr[13] = dtnv.Rows[0]["FirstName"].ToString() + " " + dtnv.Rows[0]["LastName"].ToString();
                            dr[12] = result2[0]["EmployeeCode"];
                            dr[13] = result2[0]["FirstName"] ;
                            dr[14]= result2[0]["LastName"];
                        }
                        else
                        {
                            dr[12] = "";
                            dr[13] = "";
                            dr[14]="";
                        }

                        dtChange.Rows.Add(dr);
                    }
                    Application.DoEvents();
                   
                }
            }
            catch { }
            Waiting.SetWaitFormDescription("Hoàn thành quá trình so sánh..");
            gridItem.DataSource = dtChange;

            if (dtChange.Rows.Count > 0)
            {
                Waiting.SetWaitFormDescription("Thêm dữ liệu mới vào CSDL..");
                cc.Insert(dtChange);
            }

            Waiting.CloseWaitForm();
            MessageBox.Show("Dữ liệu chấm công mới: " + dtChange.Rows.Count +"\n Tổng số record máy chấm công: "+dt.Rows.Count);

        }
        bool indicatorIcon=true;
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
       
        private void btnView_Click(object sender, EventArgs e)
        {           
            if (dateTo.DateTime < dateFrom.DateTime)
            {
                MessageBox.Show("Ngày tháng nhập không hợp lệ !.");
                return;
            }
            dtxp.Clear();
            btnExportExcelTemplate.Enabled = false;
            btnExportExcelTemplateByGroup.Enabled = false;
            Waiting.ShowWaitForm();
            colTimeStr.Visible = true;
            colTimeIn.Visible = false;
            colTimeOut.Visible = false;
            colDepartmentName.Visible = true;
            colGroupName.Visible = true;
            colDayStr.Visible = false;
            colDateStr.Visible = false;
            colIndex.Visible = false;
            colMachineNumber.Visible = true;
            Class.ChamCong_CheckInOut cc = new Class.ChamCong_CheckInOut();
            cc.FromDay = dateFrom.DateTime;
            cc.ToDay = dateTo.DateTime;
            DataTable dt = cc.CHECKINOUT_GetByDate();
            gridItem.DataSource = dt;
            Waiting.CloseWaitForm();
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xlsx";
            saveFile.Title = "Exprot to Excel File";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
                gridItem.ExportToXlsx(saveFile.FileName);
        }
        DataTable dtxp = new DataTable();
        private void btnTongHopXem_Click(object sender, EventArgs e)
        {
            if (dateTHTo.DateTime < dateTHFrom.DateTime)
            {
                MessageBox.Show("Ngày tháng nhập không hợp lệ !.");
                return;
            }
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang khởi tạo yêu cầu..");
            colIndex.Visible = true;
            colDayStr.Visible = true;
            colDateStr.Visible = true;
            colTimeOut.Visible = true;
            colTimeIn.Visible = true;           
            colDepartmentName.Visible = true;
            colGroupName.Visible = true;
            colTimeStr.Visible = false;
            colMachineNumber.Visible = false;           
            Class.ChamCong_CheckInOut cc = new Class.ChamCong_CheckInOut();
            cc.FromDay = dateTHFrom.DateTime;
            cc.ToDay = dateTHTo.DateTime;
            cc.TimeBeginIn = timeBeginIn.Time;
            cc.TimeEndIn = timeEndIn.Time;
            cc.TimeBeginOut = timeBeginOut.Time;
            cc.TimeEndOut = timeEndOut.Time;
            dtxp= cc.CHECKINOUT_GetByDateAll_Report();
            Waiting.SetWaitFormDescription("Khởi tạo dữ liệu hoàng tất..");
            gridItem.DataSource = dtxp;
            if (dtxp.Rows.Count > 0)
            {
                btnExportExcelTemplate.Enabled = true;
                btnExportExcelTemplateByGroup.Enabled = true;
            }
            Waiting.CloseWaitForm();
        }

        private void btnTongHopXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xlsx";
            saveFile.Title = "Exprot to Excel File";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
                gridItem.ExportToXlsx(saveFile.FileName);
        }

        private void btnExportExcelTemplate_Click(object sender, EventArgs e)
        {
            //
             SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xlsx";
            saveFile.Title = "Exprot to Excel File";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                Waiting.ShowWaitForm();
                string Link_Template = Application.StartupPath + "\\Templates\\Templates_ChiTietChamCong.xlsx";
                Class.PhongBan pb = new Class.PhongBan();            
                DataTable dtpb = pb.GetAllList_DEPARTMENT();
                
                if (System.IO.File.Exists(Link_Template))
                    Class.ExportDataToExcel.ExportExcel_CTCC(dtxp, dtpb, 4, "A", true, Link_Template, saveFile.FileName, false);

                Waiting.CloseWaitForm();
            }

        }

        private void frmChamCong_KetNoi_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                gridItemDetail.SaveLayoutToXml(template_grid);
            }
            catch { }
        }

        private void btnExportExcelTemplateByGroup_Click(object sender, EventArgs e)
        {
            //
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xlsx";
            saveFile.Title = "Exprot to Excel File";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                Waiting.ShowWaitForm();
                string Link_Template = Application.StartupPath + "\\Templates\\Templates_ChiTietChamCong.xlsx";
                Class.PhongBan pb = new Class.PhongBan();
                DataTable dtpb = pb.GetAllList_DEPARTMENT();
                Class.DanhSach_Nhom nhom = new Class.DanhSach_Nhom();
                DataTable dtgroup = nhom.GetAllList_GROUP();
                if (System.IO.File.Exists(Link_Template))
                    Class.ExportDataToExcel.ExportExcel_CTCCByGroup(dtxp, dtpb, dtgroup, 4, "A", true, Link_Template, saveFile.FileName, false);

                Waiting.CloseWaitForm();
            }
        }
       
    }
}