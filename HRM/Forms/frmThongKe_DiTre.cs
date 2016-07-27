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
using Excel = Microsoft.Office.Interop.Excel;


namespace HRM.Forms
{
    public partial class frmThongKe_DiTre : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKe_DiTre()
        {
            InitializeComponent();
          
        }
        DataTable dtTHdt= new DataTable();
        DataTable dtTHvs = new DataTable();

        DataTable dtPBan = new DataTable();
        DataTable dtNVien = new DataTable();

        private void frmThongKe_DiTre_Load(object sender, EventArgs e)
        {
            dtTHdt.Columns.Add("STT");
            dtTHdt.Columns.Add("DepartmentName");
            dtTHdt.Columns.Add("SLNV");
            dtTHdt.Columns.Add("SLNVTre15");           
            dtTHdt.Columns.Add("SoLanTre15");
            dtTHdt.Columns.Add("SLNVTreTren15");
            dtTHdt.Columns.Add("SoLanTreTren15");
            
            dtTHdt.Columns.Add("tile1");
            dtTHdt.Columns.Add("tile2");
            dtTHdt.Columns.Add("httile1");
            dtTHdt.Columns.Add("httile2");


            dtTHvs.Columns.Add("STT");
            dtTHvs.Columns.Add("DepartmentName");
            dtTHvs.Columns.Add("SLNV");
            dtTHvs.Columns.Add("SLNVSom15");            
            dtTHvs.Columns.Add("SoLanSom15");
            dtTHvs.Columns.Add("SLNVSomTren15");
            dtTHvs.Columns.Add("SoLanSomTren15");
         
            dtTHvs.Columns.Add("tile1");
            dtTHvs.Columns.Add("tile2");
            dtTHvs.Columns.Add("httile1");
            dtTHvs.Columns.Add("httile2");

            HRM_TIMEKEEPER_TABLELIST_GetList();

            Class.ThongKe tk = new Class.ThongKe();
            dtPBan = tk.HRM_OPTION_LATEOFWORK_GetbyDepartmentName();
            dtNVien = tk.HRM_OPTION_LATEOFWORK_GetbyEmployee();

            gridDSPhongBan.DataSource = dtPBan;
            gridDsNhanVien.DataSource = dtNVien;

            LoadDsBoPhan();
        }

        private void HRM_TIMEKEEPER_TABLELIST_GetList()
        {
            Class.ChamCong_BangXepCa xc = new Class.ChamCong_BangXepCa();
            cboThangChamCong.Properties.DataSource = xc.HRM_TIMEKEEPER_TABLELIST_GetList();
            cboThangChamCong.Properties.ValueMember = "TimeKeeperTableListID";
            cboThangChamCong.Properties.DisplayMember = "TimeKeeperTableListName";
        }

        private void LoadDsBoPhan()
        {
            cboDSPBan.Items.Clear();
            Class.PhongBan pb = new Class.PhongBan();
            DataTable dtpb = pb.GetAllList_DEPARTMENT();
            Class.DanhSach_Nhom nhom = new Class.DanhSach_Nhom();
            DataTable dtgroup = nhom.GetAllList_GROUP();
            for (int i = 0; i < dtpb.Rows.Count; i++)
            {
                bool check = false;

                for (int j = 0; j < dtgroup.Rows.Count; j++)
                {
                    if (dtgroup.Rows[j]["DepartmentCode"].ToString() == dtpb.Rows[i]["DepartmentCode"].ToString())
                    {
                        check = true;
                    }
                }

                if (check == false)
                {
                    cboDSPBan.Items.Add(dtpb.Rows[i]["DepartmentName"].ToString());
                }
            }

            for (int i = 0; i < dtgroup.Rows.Count; i++)
            {
                cboDSPBan.Items.Add(dtgroup.Rows[i]["GroupName"].ToString());
            }

            //-- load ds nv

            Class.ThongKe tk= new Class.ThongKe();            
            dtListEmployee = tk.HRM_OPTION_LATEOFWORK_GetListEmployee();
            cboDsNhanVien.DataSource = dtListEmployee;
            cboDsNhanVien.ValueMember = "OptionName";
            cboDsNhanVien.DisplayMember = "OptionName";
            
        }
        DataTable dtListEmployee = new DataTable();
        DataTable dtCCComment = new DataTable();
        private void cboThangChamCong_EditValueChanged(object sender, EventArgs e)
        {
            if (cboThangChamCong.EditValue != null)
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải thông tin chấm công..");
                Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
                bxc.TimeKeeperTableListID = cboThangChamCong.EditValue.ToString();
                DataTable dt = bxc.HRM_TIMEKEEPER_TABLELIST_GetByID();
                if (dt.Rows.Count > 0)
                {
                    Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                    cct.TimeKeeperTableListID = cboThangChamCong.EditValue.ToString();
                    dtCCComment = cct.HRM_TIMEKEEPER_TABLE_COMMENT_GetList();

                    Waiting.SetWaitFormDescription("Đang tổng hợp thời gian làm việc..");
                    LoadTHCCDiTre(cboThangChamCong.EditValue.ToString(), (int)dt.Rows[0]["Year"], (int)dt.Rows[0]["Month"]);
                    
                    HideColumOfGirdView((int)dt.Rows[0]["Month"], (int)dt.Rows[0]["Year"]);

                    HideColumOfGirdView2((int)dt.Rows[0]["Month"], (int)dt.Rows[0]["Year"]);

                    _year = (int)dt.Rows[0]["Year"];
                    _month = (int)dt.Rows[0]["Month"];

                    btnToExcel.Enabled = true;
                }

             
                Waiting.CloseWaitForm();
            }
        }
        DataTable dtTHCC;
        List<string> ListKoTinhChamCongTre = new List<string> {
        "LBC0020"
        };


        private void LoadTHCCDiTre(string Thang, int _Year, int _Month)
        {
            Class.ChamCong_TongHopChiTiet thct = new Class.ChamCong_TongHopChiTiet();
            dtTHCC = thct.HRM_TIMEKEEPER_SYNTHESIS_GetList(Thang);  // load di tre
            int _DayNumber = DateTime.DaysInMonth(_Year, _Month);
            if (dtTHCC.Rows.Count > 0)
            {
                dtTHCCVeSom.Clear();
                dtTHCCVeSom = dtTHCC.Copy();
              
                for (int i = 0; i < dtTHCC.Rows.Count; i++)
                {
                    // tinh lai cham cong tre
                    for (int ii = _DayNumber; ii > 0; ii--)
                    {
                        string text = dtTHCC.Rows[i]["D" + ii].ToString();
                        if (text.IndexOf("S") > 0)
                        {
                            text=text.Substring(0,text.IndexOf("S"));
                        }
                        if (text.StartsWith("T"))
                        {
                            string[] cat = text.Split('-');
                            if(cat.Length==2){
                                text = cat[0].ToString();
                            }
                        }                        
                        if (text=="1")
                        {
                            text = "";
                        }
                        if (text.StartsWith("S"))
                        {
                            text = "";
                        }
                        if (text.StartsWith("LD"))
                        {
                            text = "";
                        }
                        if (text.StartsWith("TD"))
                        {
                            text = "";
                        }
                        if (text.StartsWith("KR"))
                        {
                            text = "";
                        }
                        if (text.StartsWith("0"))
                        {
                            text = "";
                        }  
                        dtTHCC.Rows[i]["D" + ii] = text;
                    }
                    // loai bo danh sach neu da co ghi chu roi
                    for (int ii = 0; ii < dtCCComment.Rows.Count; ii++)
                    {
                        if (dtTHCC.Rows[i]["EmployeeCode"].ToString() == dtCCComment.Rows[ii]["EmployeeCode"].ToString())
                        {
                            string day = dtCCComment.Rows[ii]["Day"].ToString();
                            dtTHCC.Rows[i][day] = "";
                        }
                    }
                    ///===================
                }

                /// tinh so lan di tre
                /// 
                Waiting.SetWaitFormDescription("Đang tính số lần đi trễ ..");
                for (int i = 0; i < dtTHCC.Rows.Count; i++)
                {
                    // tinh lai cham cong tre
                    string ngaytre15 = "";
                    string ngaytretren15 = "";
                    int solantre15 = 0;
                    int solantretren15 = 0;
                    for (int ii = 1; ii <=_DayNumber; ii++)
                    {
                        string text = dtTHCC.Rows[i]["D" + ii].ToString();                       
                        if (text.StartsWith("T"))
                        {
                            if (text != "TD")
                            {
                                text = text.Replace("T", "");
                                int thoigian = int.Parse(text);
                                if (thoigian <= 15)
                                {
                                    solantre15++;
                                    ngaytre15 += ii.ToString() + ",";
                                }
                                if (thoigian > 15)
                                {
                                    solantretren15++;
                                    ngaytretren15+=ii.ToString() + ",";
                                }
                            }

                        }
                    }
                    // bỏ dau phầy ờ cuối
                    if (ngaytre15.Length > 0)
                    {
                        ngaytre15 = ngaytre15.Substring(0, ngaytre15.Length - 1);
                    }
                    if (ngaytretren15.Length > 0)
                    {
                        ngaytretren15 = ngaytretren15.Substring(0, ngaytretren15.Length - 1);
                    }
                    ////------
                    dtTHCC.Rows[i]["Total15"] = solantre15;
                    dtTHCC.Rows[i]["TotalNgay15"] = ngaytre15;
                    dtTHCC.Rows[i]["TotalTren15"] = solantretren15;
                    dtTHCC.Rows[i]["TotalNgayTren15"] = ngaytretren15;                   

                }
            }

            LoadTHCCVeSom(dtTHCCVeSom,_DayNumber);  // tinh ve som          

            dtTHdt.Clear();
            //
            Waiting.SetWaitFormDescription("Đang tải thông tin phòng ban..");
            Class.PhongBan pb = new Class.PhongBan();
            DataTable dtpb = pb.GetAllList_DEPARTMENT();
            Class.DanhSach_Nhom nhom = new Class.DanhSach_Nhom();
            DataTable dtgroup = nhom.GetAllList_GROUP();
            DataView dtView = new DataView(dtTHCC);
            // loai bo danh sach bo phan ko ap dung
            int st = 0;
            int tongst = dtpb.Rows.Count;
            while (st < tongst)
            {
                
                    for(int stj=0;stj<dtPBan.Rows.Count;stj++){

                        if (dtpb.Rows[st]["DepartmentName"].ToString() == dtPBan.Rows[stj]["OptionName"].ToString())
                        {
                            dtpb.Rows.RemoveAt(st);
                            tongst = dtpb.Rows.Count;
                            st--;
                             break;
                        }
                    }
                st++;
            }
            st = 0;
            tongst = dtgroup.Rows.Count;
            while (st < tongst)
            {

                for (int stj = 0; stj < dtPBan.Rows.Count; stj++)
                {

                    if (dtgroup.Rows[st]["GroupName"].ToString() == dtPBan.Rows[stj]["OptionName"].ToString())
                    {
                        dtgroup.Rows.RemoveAt(st);
                        tongst = dtgroup.Rows.Count;
                        st--;
                        break;
                    }
                }
                st++;
            }
            //-------------------////////////////////////////////////

            //--- bo nhung thanh vien ko tinh vao tre 
            int t = 0;
            int tong = dtTHCC.Rows.Count;
            while (t < tong)
            {               
                    int nhan = t;
                    for (int j = 0; j < dtNVien.Rows.Count; j++)
                    {
                        if (dtTHCC.Rows[t]["EmployeeCode"].ToString() == dtNVien.Rows[j]["OptionName"].ToString())
                        {
                            dtTHCC.Rows.RemoveAt(t);
                            tong = dtTHCC.Rows.Count;
                            t--;
                            break;
                        }
                    }
                    if (t == nhan)
                    {
                        for (int j = 0; j < dtPBan.Rows.Count; j++)
                        {
                            if (dtTHCC.Rows[t]["DepartmentName"].ToString() == dtPBan.Rows[j]["OptionName"].ToString() || dtTHCC.Rows[t]["GroupName"].ToString() == dtPBan.Rows[j]["OptionName"].ToString())
                            {
                                dtTHCC.Rows.RemoveAt(t);
                                tong = dtTHCC.Rows.Count;
                                t--;
                                break;
                            }
                        }
                    }
                
                t++;
            }
            ////-----------------------////

            int stt = 0;
            for (int i = 0; i < dtpb.Rows.Count; i++)
            {
                bool check = false;
                
                for (int j = 0; j < dtgroup.Rows.Count; j++)
                {
                    if (dtgroup.Rows[j]["DepartmentCode"].ToString() == dtpb.Rows[i]["DepartmentCode"].ToString())
                    {
                        check = true;
                    }
                }

                if (check == false)
                {
                    //if (dtpb.Rows[i]["BranchCode"].ToString() == "CN000001") // chi LBC
                    //{
                        dtView.RowFilter = "DepartmentName='" + dtpb.Rows[i]["DepartmentName"].ToString() + "'";
                        float sonhanvientre15 = 0;
                        float sonhanvientretren15 = 0;
                        float tongsolantre15 = 0;
                        float tongsolantretren15 = 0; 
                    if (dtView.Count > 0)
                        {
                            for (int k=0; k < dtView.Count; k++)
                            {
                                tongsolantre15 += int.Parse(dtView[k]["Total15"].ToString());
                                tongsolantretren15 += int.Parse(dtView[k]["TotalTren15"].ToString());

                                if(int.Parse(dtView[k]["Total15"].ToString())>0)
                                    sonhanvientre15++;
                                if (int.Parse(dtView[k]["TotalTren15"].ToString()) > 0)
                                    sonhanvientretren15++;
                            }
                        }

                        stt++;
                        DataRow dr = dtTHdt.NewRow();
                        dr["STT"] = stt;
                        dr["DepartmentName"] = dtpb.Rows[i]["DepartmentName"].ToString();
                        dr["SLNV"] = dtView.Count;
                          // tinh ti le    
                        float ngaycong = _DayNumber - 4;
                        float tile1 = ((tongsolantre15 / (dtView.Count * ngaycong))) ;
                        float tile2 = ((tongsolantretren15 / (dtView.Count * ngaycong)));
                        if (dtView.Count == 0)
                        {
                            tile1 = 0; tile2 = 0;

                        }

                        dr["SoLanTre15"] = tongsolantre15;
                        dr["SoLanTreTren15"] = tongsolantretren15;
                        dr["SLNVTre15"] = sonhanvientre15;
                        dr["SLNVTreTren15"] = sonhanvientretren15;
                        dr["tile1"] = tile1 ;
                        dr["tile2"] = tile2 ;
                        dr["httile1"] = Math.Round((decimal)(tile1 * 100));
                        dr["httile2"] = Math.Round((decimal)(tile2 * 100));
                        dtTHdt.Rows.Add(dr);
                    //}
                }
                
            }
            for (int j = 0; j < dtgroup.Rows.Count; j++)
            {
                dtView.RowFilter = "GroupName='" + dtgroup.Rows[j]["GroupName"].ToString() + "'";
                float sonhanvientre15 = 0;
                float sonhanvientretren15 = 0;
                float tongsolantre15 = 0;
                float tongsolantretren15 = 0;
                if (dtView.Count > 0)
                {
                    for (int k = 0; k < dtView.Count; k++)
                    {
                        tongsolantre15 += int.Parse(dtView[k]["Total15"].ToString());
                        tongsolantretren15 += int.Parse(dtView[k]["TotalTren15"].ToString());
                      
                        if (int.Parse(dtView[k]["Total15"].ToString()) > 0)
                            sonhanvientre15++;
                        if (int.Parse(dtView[k]["TotalTren15"].ToString()) > 0)
                            sonhanvientretren15++;
                    }
                }
                
                stt++;
                DataRow dr = dtTHdt.NewRow();
                dr["STT"] = stt;
                dr["DepartmentName"] = dtgroup.Rows[j]["GroupName"].ToString();
                dr["SLNV"] = dtView.Count;
                float ngaycong = _DayNumber - 4;
                float tile1 = ((tongsolantre15 / (dtView.Count * ngaycong)));
                float tile2 = ((tongsolantretren15 / (dtView.Count * ngaycong)) );
                if (dtView.Count == 0)
                {
                    tile1 = 0; tile2 = 0;

                }
                dr["SoLanTre15"] = tongsolantre15;
                dr["SoLanTreTren15"] = tongsolantretren15;
                dr["SLNVTre15"] = sonhanvientre15;
                dr["SLNVTreTren15"] = sonhanvientretren15;
                dr["tile1"] = tile1;
                dr["tile2"] = tile2;
                dr["httile1"] = Math.Round((decimal)(tile1 * 100));
                dr["httile2"] = Math.Round((decimal)(tile2 * 100));
                dtTHdt.Rows.Add(dr);
            }
            //--- loai nhan vien cham du trong chi tiet cham cong
            t = 0;
            tong = dtTHCC.Rows.Count;
            while (t < tong)
            {
                if (dtTHCC.Rows[t]["Total15"].ToString() == "0" && dtTHCC.Rows[t]["TotalTren15"].ToString() == "0")
                {
                    dtTHCC.Rows.RemoveAt(t);
                    tong = dtTHCC.Rows.Count;
                    t--;
                }
                t++;
            } 

            //-----------------

            Waiting.SetWaitFormDescription("Xuất dữ liệu ra màn hình ..");
            gridItem.DataSource = dtTHCC;
            gridTongHopDiTre.DataSource = dtTHdt;
            Waiting.SetWaitFormDescription("Load biểu đồ ..");
            LoadChart(dtTHdt);
        }
        DataTable dtTHCCVeSom = new DataTable();

        private void LoadTHCCVeSom(DataTable dt, int _DayNumber)
        {
            dtTHvs.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // tinh lai cham ve som
                for (int ii =1; ii <= _DayNumber; ii++)
                {
                    string text = dt.Rows[i]["D" + ii].ToString();                   
                    if (text.IndexOf("S") > 0)
                    {
                        text = text.Substring(text.IndexOf("S"), text.Length - text.IndexOf("S"));
                    }
                    if (text.StartsWith("KV"))
                    {
                        string[] cat = text.Split('-');
                        if (cat.Length == 2)
                        {
                            if (cat[1].ToString().StartsWith("S"))
                            {
                                text = cat[1].ToString();
                            }
                        }
                    }
                   
                    if (text == "1")
                    {
                        text = "";
                    }
                    if (text.StartsWith("LD"))
                    {
                        text = "";
                    }
                    if (text.StartsWith("TD"))
                    {
                        text = "";
                    }
                    if (text.StartsWith("KR"))
                    {
                        text = "";
                    }
                    if (text.StartsWith("T") && text.EndsWith("KR"))
                    {
                        text = "";
                    }
                    if (text.StartsWith("0"))
                    {
                        text = "";
                    }
                    if (text.StartsWith("T"))
                    {
                        text = "";
                    }
                    dt.Rows[i]["D" + ii] = text;
                }

                // loai bo danh sach neu da co ghi chu roi
                for (int ii = 0; ii < dtCCComment.Rows.Count; ii++)
                {
                    if (dt.Rows[i]["EmployeeCode"].ToString() == dtCCComment.Rows[ii]["EmployeeCode"].ToString())
                    {
                        string day = dtCCComment.Rows[ii]["Day"].ToString();
                        dt.Rows[i][day] = "";
                    }
                }
                ///===================

            }

            /// tinh so lan di som
            /// 
            Waiting.SetWaitFormDescription("Đang tính số lần về sớm ..");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // tinh lai cham cong ve som
                string ngaysom15 = "";
                string ngaysomtren15 = "";
                int solansom15 = 0;
                int solansomtren15 = 0;
                for (int ii = 1; ii <= _DayNumber; ii++)
                {
                    string text = dt.Rows[i]["D" + ii].ToString();
                    if (text.StartsWith("S"))
                    {
                       text = text.Replace("S", "");
                            int thoigian = int.Parse(text);
                            if (thoigian < 6)
                            {
                                dt.Rows[i]["D" + ii] = "";  // cap nhat neu thời gian về sớm <5 phút
                            }

                            if (thoigian <= 15 && thoigian > 5)
                            {
                                solansom15++;
                                ngaysom15 += ii.ToString() + ",";
                            }
                            if (thoigian > 15)
                            {
                                solansomtren15++;
                                ngaysomtren15 += ii.ToString() + ",";
                            }
                    }
                }
                // bỏ dau phầy ờ cuối
                if (ngaysom15.Length > 0)
                {
                    ngaysom15 = ngaysom15.Substring(0, ngaysom15.Length - 1);
                }
                if (ngaysomtren15.Length > 0)
                {
                    ngaysomtren15 = ngaysomtren15.Substring(0, ngaysomtren15.Length - 1);
                }
                ////------
                dt.Rows[i]["Total15"] = solansom15;
                dt.Rows[i]["TotalNgay15"] = ngaysom15;
                dt.Rows[i]["TotalTren15"] = solansomtren15;
                dt.Rows[i]["TotalNgayTren15"] = ngaysomtren15;

            }
           
            Waiting.SetWaitFormDescription("Đang tải thông tin phòng ban..");
            Class.PhongBan pb = new Class.PhongBan();
            DataTable dtpb = pb.GetAllList_DEPARTMENT();
            Class.DanhSach_Nhom nhom = new Class.DanhSach_Nhom();
            DataTable dtgroup = nhom.GetAllList_GROUP();
            DataView dtView = new DataView(dt);

            // loai bo danh sach bo phan ko ap dung
            int st = 0;
            int tongst = dtpb.Rows.Count;
            while (st < tongst)
            {
                for (int stj = 0; stj < dtPBan.Rows.Count; stj++)
                {
                    if (dtpb.Rows[st]["DepartmentName"].ToString() == dtPBan.Rows[stj]["OptionName"].ToString())
                    {
                        dtpb.Rows.RemoveAt(st);
                        tongst = dtpb.Rows.Count;
                        st--;
                        break;
                    }
                }
                st++;
            }
            st = 0;
            tongst = dtgroup.Rows.Count;
            while (st < tongst)
            {
                for (int stj = 0; stj < dtPBan.Rows.Count; stj++)
                {
                    if (dtgroup.Rows[st]["GroupName"].ToString() == dtPBan.Rows[stj]["OptionName"].ToString())
                    {
                        dtgroup.Rows.RemoveAt(st);
                        tongst = dtgroup.Rows.Count;
                        st--;
                        break;
                    }
                }
                st++;
            }
            //-------------------////////////////////////////////////            
            //--- bo nhung thanh vien ko tinh vao tre 
            int t = 0;
            int tong = dt.Rows.Count;
            while (t < tong)
            {                
                    int nhan = t;
                    for (int j = 0; j < dtNVien.Rows.Count; j++)
                    {
                        if (dt.Rows[t]["EmployeeCode"].ToString() == dtNVien.Rows[j]["OptionName"].ToString())
                        {
                            dt.Rows.RemoveAt(t);
                            tong = dt.Rows.Count;
                            t--;
                            break;
                        }
                    }
                    if (t == nhan)
                    {
                        for (int j = 0; j < dtPBan.Rows.Count; j++)
                        {
                            if (dt.Rows[t]["DepartmentName"].ToString() == dtPBan.Rows[j]["OptionName"].ToString() || dt.Rows[t]["GroupName"].ToString() == dtPBan.Rows[j]["OptionName"].ToString())
                            {
                                dt.Rows.RemoveAt(t);
                                tong = dt.Rows.Count;
                                t--;
                                break;
                            }
                        }
                    }
                
                t++;
            }
            //----------------------------//////////////

            int stt = 0;
            for (int i = 0; i < dtpb.Rows.Count; i++)
            {
                bool check = false;

                for (int j = 0; j < dtgroup.Rows.Count; j++)
                {
                    if (dtgroup.Rows[j]["DepartmentCode"].ToString() == dtpb.Rows[i]["DepartmentCode"].ToString())
                    {
                        check = true;
                    }
                }

                if (check == false)
                {
                    //if (dtpb.Rows[i]["BranchCode"].ToString() == "CN000001") // chi LBC
                    //{
                    dtView.RowFilter = "DepartmentName='" + dtpb.Rows[i]["DepartmentName"].ToString() + "'";
                    float sonhanviensom15 = 0;
                    float sonhanviensomtren15 = 0;
                    float tongsolansom15 = 0;
                    float tongsolansomtren15 = 0;
                    if (dtView.Count > 0)
                    {
                        for (int k = 0; k < dtView.Count; k++)
                        {
                            tongsolansom15 += int.Parse(dtView[k]["Total15"].ToString());
                            tongsolansomtren15 += int.Parse(dtView[k]["TotalTren15"].ToString());

                            if (int.Parse(dtView[k]["Total15"].ToString()) > 0)
                                sonhanviensom15++;
                            if (int.Parse(dtView[k]["TotalTren15"].ToString()) > 0)
                                sonhanviensomtren15++;
                        }
                    }

                    stt++;
                    DataRow dr = dtTHvs.NewRow();
                    dr["STT"] = stt;
                    dr["DepartmentName"] = dtpb.Rows[i]["DepartmentName"].ToString();
                    dr["SLNV"] = dtView.Count;
                    // tinh ti le    
                    float ngaycong = _DayNumber - 4;
                    float tile1 = ((tongsolansom15 / (dtView.Count * ngaycong)));
                    float tile2 = ((tongsolansomtren15 / (dtView.Count * ngaycong)));
                    if (dtView.Count == 0)
                    {
                        tile1 = 0; tile2 = 0;

                    }

                    dr["SoLanSom15"] = tongsolansom15;
                    dr["SoLanSomTren15"] = tongsolansomtren15;
                    dr["SLNVSom15"] = sonhanviensom15;
                    dr["SLNVSomTren15"] = sonhanviensomtren15;
                    dr["tile1"] = tile1;
                    dr["tile2"] = tile2;
                    dr["httile1"] = Math.Round((decimal)(tile1 * 100));
                    dr["httile2"] = Math.Round((decimal)(tile2 * 100));
                    dtTHvs.Rows.Add(dr);
                    //}
                }

            }
            for (int j = 0; j < dtgroup.Rows.Count; j++)
            {
                dtView.RowFilter = "GroupName='" + dtgroup.Rows[j]["GroupName"].ToString() + "'";
                float sonhanviensom15 = 0;
                float sonhanviensomtren15 = 0;
                float tongsolansom15 = 0;
                float tongsolansomtren15 = 0;
                if (dtView.Count > 0)
                {
                    for (int k = 0; k < dtView.Count; k++)
                    {
                        tongsolansom15 += int.Parse(dtView[k]["Total15"].ToString());
                        tongsolansomtren15 += int.Parse(dtView[k]["TotalTren15"].ToString());

                        if (int.Parse(dtView[k]["Total15"].ToString()) > 0)
                            sonhanviensom15++;
                        if (int.Parse(dtView[k]["TotalTren15"].ToString()) > 0)
                            sonhanviensomtren15++;
                    }
                }

                stt++;
                DataRow dr = dtTHvs.NewRow();
                dr["STT"] = stt;
                dr["DepartmentName"] = dtgroup.Rows[j]["GroupName"].ToString();
                dr["SLNV"] = dtView.Count;
                float ngaycong = _DayNumber - 4;
                
                float tile1 = ((tongsolansom15 / (dtView.Count * ngaycong)));
                float tile2 = ((tongsolansomtren15 / (dtView.Count * ngaycong)));
                if (dtView.Count == 0)
                {
                    tile1 = 0; tile2 = 0;

                }

                dr["SoLanSom15"] = tongsolansom15;
                dr["SoLanSomTren15"] = tongsolansomtren15;
                dr["SLNVSom15"] = sonhanviensom15;
                dr["SLNVSomTren15"] = sonhanviensomtren15;
                dr["tile1"] = tile1;
                dr["tile2"] = tile2;
                dr["httile1"] = Math.Round((decimal)(tile1 *100));
                dr["httile2"] = Math.Round((decimal)(tile2*100));
                dtTHvs.Rows.Add(dr);
            }

            // bo nhung nhan vien cham day du
            t = 0;
            tong = dt.Rows.Count;
            while (t < tong)
            {
                if (dt.Rows[t]["Total15"].ToString() == "0" && dt.Rows[t]["TotalTren15"].ToString() == "0")
                {
                    dt.Rows.RemoveAt(t);
                    tong = dt.Rows.Count;
                    t--;
                }
                t++;
            }

            Waiting.SetWaitFormDescription("Xuất dữ liệu ra màn hình ..");           
            gridTongHopVeSom.DataSource = dtTHvs;
            Waiting.SetWaitFormDescription("Load biểu đồ ..");
            LoadChart2(dtTHvs);
            gridItems.DataSource = dt;           

        }


        private void LoadChart(DataTable dt)
        {
            chartTile1.Series.Clear();
            chartTile2.Series.Clear();
            chartTile1.Titles.Clear();
            chartTile2.Titles.Clear();

            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Tỉ lệ NV đi trễ từ 6 đến 14 phút";
            chartTile1.Titles.Add(chartTitle1);

            ChartTitle chartTitle2 = new ChartTitle();
            chartTitle2.Text = "Tỉ lệ NV đi trễ từ 15 phút trở đi";
            chartTile2.Titles.Add(chartTitle2);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series series1 = new Series(dt.Rows[i]["DepartmentName"].ToString(), ViewType.Bar);

               // series1.LegendPointOptions.PointView = PointView.ArgumentAndValues;
                //series1.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                //series1.LegendPointOptions.ValueNumericOptions.Precision = 0;

                // Adjust the value numeric options of the series.
              series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
             series1.Label.PointOptions.ValueNumericOptions.Precision =0;              
           
            
             series1.Points.Add(new SeriesPoint(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["tile1"].ToString()));
             chartTile1.Series.AddRange(new Series[] { series1 });
             XYDiagram diagram1 = chartTile1.Diagram as XYDiagram;
             diagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
             diagram1.AxisY.NumericOptions.Precision = 0;


             Series series2 = new Series(dt.Rows[i]["DepartmentName"].ToString(), ViewType.Bar);
             
            
             series2.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
             series2.Label.PointOptions.ValueNumericOptions.Precision = 0;
            
           
                series2.Points.Add(new SeriesPoint(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["tile2"].ToString()));
                
                chartTile2.Series.AddRange(new Series[] { series2 });
                ((XYDiagram)chartTile2.Diagram).AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                ((XYDiagram)chartTile2.Diagram).AxisY.NumericOptions.Precision = 0;
              
            }
            for (int i = 0; i < chartTile1.Series.Count; i++)
            {
                chartTile1.Series[i].LabelsVisibility = DefaultBoolean.True;
                chartTile2.Series[i].LabelsVisibility = DefaultBoolean.True;
            }
        }

        private void LoadChart2(DataTable dt)
        {
            chartTiles1.Series.Clear();
            chartTiles2.Series.Clear();
            chartTiles1.Titles.Clear();
            chartTiles2.Titles.Clear();

            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Tỉ lệ NV về sớm từ 6 đến 14 phút";
            chartTiles1.Titles.Add(chartTitle1);

            ChartTitle chartTitle2 = new ChartTitle();
            chartTitle2.Text = "Tỉ lệ NV về sớm từ 15 phút trở đi";
            chartTiles2.Titles.Add(chartTitle2);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Series series1 = new Series(dt.Rows[i]["DepartmentName"].ToString(), ViewType.Bar);

                // series1.LegendPointOptions.PointView = PointView.ArgumentAndValues;
                //series1.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                //series1.LegendPointOptions.ValueNumericOptions.Precision = 0;

                // Adjust the value numeric options of the series.
                series1.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                series1.Label.PointOptions.ValueNumericOptions.Precision = 0;


                series1.Points.Add(new SeriesPoint(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["tile1"].ToString()));
                chartTiles1.Series.AddRange(new Series[] { series1 });
                XYDiagram diagram1 = chartTiles1.Diagram as XYDiagram;
                diagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                diagram1.AxisY.NumericOptions.Precision = 0;


                Series series2 = new Series(dt.Rows[i]["DepartmentName"].ToString(), ViewType.Bar);


                series2.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                series2.Label.PointOptions.ValueNumericOptions.Precision = 0;


                series2.Points.Add(new SeriesPoint(dt.Rows[i]["DepartmentName"].ToString(), dt.Rows[i]["tile2"].ToString()));

                chartTiles2.Series.AddRange(new Series[] { series2 });
                ((XYDiagram)chartTiles2.Diagram).AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent;
                ((XYDiagram)chartTiles2.Diagram).AxisY.NumericOptions.Precision = 0;

            }
            for (int i = 0; i < chartTiles1.Series.Count; i++)
            {
                chartTiles1.Series[i].LabelsVisibility = DefaultBoolean.True;
                chartTiles2.Series[i].LabelsVisibility = DefaultBoolean.True;
            }
        }
        private void HideColumOfGirdView(int _Month, int _Year)
        {
            int _DayNumber = DateTime.DaysInMonth(_Year, _Month);

            List<string> list = new List<string>();
            #region default Color
            this.colD1.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD2.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD3.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD4.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD5.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD6.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD7.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD8.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD9.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD10.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD11.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD12.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD13.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD14.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD15.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD16.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD17.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD18.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD19.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD1.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD20.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD21.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD22.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD23.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD24.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD25.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD26.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD27.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD28.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD29.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD30.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colD31.AppearanceCell.BackColor = System.Drawing.Color.White;
            #endregion
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
                            this.colD1.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 2:
                            this.colD2.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 3:
                            this.colD3.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 4:
                            this.colD4.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 5:
                            this.colD5.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 6:
                            this.colD6.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 7:
                            this.colD7.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 8:
                            this.colD8.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 9:
                            this.colD9.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 10:
                            this.colD10.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 11:
                            this.colD11.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 12:
                            this.colD12.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 13:
                            this.colD13.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 14:
                            this.colD14.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 15:
                            this.colD15.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 16:
                            this.colD16.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 17:
                            this.colD17.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 18:
                            this.colD18.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 19:
                            this.colD19.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 20:
                            this.colD20.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 21:
                            this.colD21.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 22:
                            this.colD22.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 23:
                            this.colD23.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 24:
                            this.colD24.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 25:
                            this.colD25.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 26:
                            this.colD26.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 27:
                            this.colD27.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 28:
                            this.colD28.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 29:
                            this.colD29.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 30:
                            this.colD30.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 31:
                            this.colD31.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                    }
                }
                #endregion
            }
            colD1.Caption = "1 " + list[0];
            colD2.Caption = "2 " + list[1];
            colD3.Caption = "3 " + list[2];
            colD4.Caption = "4 " + list[3];
            colD5.Caption = "5 " + list[4];
            colD6.Caption = "6 " + list[5];
            colD7.Caption = "7 " + list[6];
            colD8.Caption = "8 " + list[7];
            colD9.Caption = "9 " + list[8];
            colD10.Caption = "10 " + list[9];
            colD11.Caption = "11 " + list[10];
            colD12.Caption = "12 " + list[11];
            colD13.Caption = "13 " + list[12];
            colD14.Caption = "14 " + list[13];
            colD15.Caption = "15 " + list[14];
            colD16.Caption = "16 " + list[15];
            colD17.Caption = "17 " + list[16];
            colD18.Caption = "18 " + list[17];
            colD19.Caption = "19 " + list[18];
            colD20.Caption = "20 " + list[19];
            colD21.Caption = "21 " + list[20];
            colD22.Caption = "22 " + list[21];
            colD23.Caption = "23 " + list[22];
            colD24.Caption = "24 " + list[23];
            colD25.Caption = "25 " + list[24];
            colD26.Caption = "26 " + list[25];
            colD27.Caption = "27 " + list[26];
            colD28.Caption = "28 " + list[27];

            colD29.Visible = true;
            colD30.Visible = true;
            colD31.Visible = true;
            if (_DayNumber == 28)
            {
                colD29.Visible = false;
                colD30.Visible = false;
                colD31.Visible = false;
            }
            else if (_DayNumber == 29)
            {
                colD30.Visible = false;
                colD31.Visible = false;
                colD29.Caption = "29 " + list[28];
            }
            else if (_DayNumber == 30)
            {
                colD31.Visible = false;
                colD29.Caption = "29 " + list[28];
                colD30.Caption = "30 " + list[29];
            }
            else if (_DayNumber == 31)
            {
                colD29.Caption = "29 " + list[28];
                colD30.Caption = "30 " + list[29];
                colD31.Caption = "31 " + list[30];
            }
        }

        private void HideColumOfGirdView2(int _Month, int _Year)
        {
            int _DayNumber = DateTime.DaysInMonth(_Year, _Month);

            List<string> list = new List<string>();
            #region default Color
            this.colsD1.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD2.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD3.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD4.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD5.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD6.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD7.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD8.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD9.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD10.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD11.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD12.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD13.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD14.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD15.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD16.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD17.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD18.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD19.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD1.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD20.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD21.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD22.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD23.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD24.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD25.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD26.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD27.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD28.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD29.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD30.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colsD31.AppearanceCell.BackColor = System.Drawing.Color.White;
            #endregion
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
                            this.colsD1.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 2:
                            this.colsD2.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 3:
                            this.colsD3.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 4:
                            this.colsD4.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 5:
                            this.colsD5.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 6:
                            this.colsD6.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 7:
                            this.colsD7.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 8:
                            this.colsD8.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 9:
                            this.colsD9.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 10:
                            this.colsD10.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 11:
                            this.colsD11.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 12:
                            this.colsD12.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 13:
                            this.colsD13.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 14:
                            this.colsD14.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 15:
                            this.colsD15.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 16:
                            this.colsD16.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 17:
                            this.colsD17.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 18:
                            this.colsD18.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 19:
                            this.colsD19.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 20:
                            this.colsD20.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 21:
                            this.colsD21.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 22:
                            this.colsD22.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 23:
                            this.colsD23.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 24:
                            this.colsD24.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 25:
                            this.colsD25.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 26:
                            this.colsD26.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 27:
                            this.colsD27.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 28:
                            this.colsD28.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 29:
                            this.colsD29.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 30:
                            this.colsD30.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case 31:
                            this.colsD31.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
                            break;
                    }
                }
                #endregion
            }
            colsD1.Caption = "1 " + list[0];
            colsD2.Caption = "2 " + list[1];
            colsD3.Caption = "3 " + list[2];
            colsD4.Caption = "4 " + list[3];
            colsD5.Caption = "5 " + list[4];
            colsD6.Caption = "6 " + list[5];
            colsD7.Caption = "7 " + list[6];
            colsD8.Caption = "8 " + list[7];
            colsD9.Caption = "9 " + list[8];
            colsD10.Caption = "10 " + list[9];
            colsD11.Caption = "11 " + list[10];
            colsD12.Caption = "12 " + list[11];
            colsD13.Caption = "13 " + list[12];
            colsD14.Caption = "14 " + list[13];
            colsD15.Caption = "15 " + list[14];
            colsD16.Caption = "16 " + list[15];
            colsD17.Caption = "17 " + list[16];
            colsD18.Caption = "18 " + list[17];
            colsD19.Caption = "19 " + list[18];
            colsD20.Caption = "20 " + list[19];
            colsD21.Caption = "21 " + list[20];
            colsD22.Caption = "22 " + list[21];
            colsD23.Caption = "23 " + list[22];
            colsD24.Caption = "24 " + list[23];
            colsD25.Caption = "25 " + list[24];
            colsD26.Caption = "26 " + list[25];
            colsD27.Caption = "27 " + list[26];
            colsD28.Caption = "28 " + list[27];

            colsD29.Visible = true;
            colsD30.Visible = true;
            colsD31.Visible = true;
            if (_DayNumber == 28)
            {
                colsD29.Visible = false;
                colsD30.Visible = false;
                colsD31.Visible = false;
            }
            else if (_DayNumber == 29)
            {
                colsD30.Visible = false;
                colsD31.Visible = false;
                colsD29.Caption = "29 " + list[28];
            }
            else if (_DayNumber == 30)
            {
                colsD31.Visible = false;
                colsD29.Caption = "29 " + list[28];
                colsD30.Caption = "30 " + list[29];
            }
            else if (_DayNumber == 31)
            {
                colsD29.Caption = "29 " + list[28];
                colsD30.Caption = "30 " + list[29];
                colsD31.Caption = "31 " + list[30];
            }
        }

        private void gridDSPhongBanDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.RowHandle < 0) // thuc hien them moi
            {
                string txt = gridDSPhongBanDetail.GetRowCellValue(e.RowHandle, colTenPhong).ToString();
                for (int i = 0; i < gridDSPhongBanDetail.RowCount; i++)
                {
                    if (gridDSPhongBanDetail.GetRowCellValue(i, colTenPhong).ToString() == txt)
                    {
                        e.ErrorText = "Bạn đã chọn phòng này rồi ! \r\n";
                        e.Valid = false; 
                    }
                }

                if (e.Valid)
                {                    
                    Class.ThongKe tk = new Class.ThongKe();
                    tk.OptionName = gridDSPhongBanDetail.GetRowCellValue(e.RowHandle, colTenPhong).ToString();
                    tk.OptionType = "1";
                    tk.HRM_OPTION_LATEOFWORK_Insert();
                    
                }
            }
        }

        private void gridDSPhongBanDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridDSPhongBanDetail.FocusedRowHandle > -1)
            {
                if (e.KeyValue == 46)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá bộ phận trong danh sách này hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Class.ThongKe tk = new Class.ThongKe();
                        tk.OptionName = gridDSPhongBanDetail.GetFocusedRowCellValue(colTenPhong).ToString();
                        tk.OptionType = "1";
                        tk.HRM_OPTION_LATEOFWORK_Delete();
                        dtPBan = tk.HRM_OPTION_LATEOFWORK_GetbyDepartmentName();                       
                        gridDSPhongBan.DataSource = dtPBan;
                    }
                }
            }
        }

      
        private void gridDSPhongBanDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                colTenPhong.OptionsColumn.AllowEdit = false;
            }
            else
            {
                colTenPhong.OptionsColumn.AllowEdit = true;
            }
        }

        private void gridDsNhanVienDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                colMaNV.OptionsColumn.AllowEdit = false;
            }
            else
            {
                colMaNV.OptionsColumn.AllowEdit = true;
            }
            colHo.OptionsColumn.AllowEdit = false;
            colTen.OptionsColumn.AllowEdit = false;
        }

        private void gridDsNhanVienDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (e.RowHandle < 0) // thuc hien them moi
            {
                string txt = gridDsNhanVienDetail.GetRowCellValue(e.RowHandle, colMaNV).ToString();
                for (int i = 0; i < gridDsNhanVienDetail.RowCount; i++)
                {
                    if (gridDsNhanVienDetail.GetRowCellValue(i, colMaNV).ToString() == txt)
                    {
                        e.ErrorText = "Bạn đã chọn nhân viên này rồi ! \r\n";
                        e.Valid = false;
                    }
                }

                if (e.Valid)
                {
                    Class.ThongKe tk = new Class.ThongKe();
                    tk.OptionName = gridDsNhanVienDetail.GetRowCellValue(e.RowHandle, colMaNV).ToString();
                    tk.OptionType = "2";
                    tk.HRM_OPTION_LATEOFWORK_Insert();
                   // gridDsNhanVienDetail.DataSource = tk.HRM_OPTION_LATEOFWORK_GetListEmployee();
                }
            }
        }

        private void gridDsNhanVienDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colMaNV)
            {
                if (e.RowHandle < 0)
                {
                    string txt = gridDsNhanVienDetail.GetRowCellValue(e.RowHandle, colMaNV).ToString();
                    for (int i = 0; i < dtListEmployee.Rows.Count; i++)
                    {
                        if (txt == dtListEmployee.Rows[i]["EmployeeCode"].ToString())
                        {
                            gridDsNhanVienDetail.SetRowCellValue(e.RowHandle, colholot, dtListEmployee.Rows[i]["FirstName"].ToString());
                            gridDsNhanVienDetail.SetRowCellValue(e.RowHandle, collotten,dtListEmployee.Rows[i]["LastName"].ToString());

                            break;
                        }

                    }
                }

            }
        }

        private void gridDsNhanVienDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridDsNhanVienDetail.FocusedRowHandle > -1)
            {
                if (e.KeyValue == 46)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên trong danh sách này hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Class.ThongKe tk = new Class.ThongKe();
                        tk.OptionName = gridDsNhanVienDetail.GetFocusedRowCellValue(colMaNV).ToString();
                        tk.OptionType = "2";
                        tk.HRM_OPTION_LATEOFWORK_Delete();
                        dtNVien= tk.HRM_OPTION_LATEOFWORK_GetbyEmployee();
                        gridDsNhanVien.DataSource = dtNVien;
                    }
                }
            }
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }

        bool indicatorIcon2 = true;
        private void gridItemsDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon2)
                    e.Info.ImageIndex = -1;
            }
        }
        bool indicatorIcon3 = true;
        private void gridDSPhongBanDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon3)
                    e.Info.ImageIndex = -1;
            }
        }
        bool indicatorIcon4 = true;
        private void gridDsNhanVienDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon4)
                    e.Info.ImageIndex = -1;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboThangChamCong_EditValueChanged(null, null);
        }

        private void chartTile1_DoubleClick(object sender, EventArgs e)
        {
            if (dtTHdt.Rows.Count > 0)
            {
                frmChartControlPopup frm = new frmChartControlPopup(dtTHdt, 0);
                frm.ShowDialog();
            }
        }

        private void chartTile2_DoubleClick(object sender, EventArgs e)
        {
            if (dtTHdt.Rows.Count > 0)
            {
                frmChartControlPopup frm = new frmChartControlPopup(dtTHdt, 1);
                frm.ShowDialog();
            }
        }

        private void chartTiles1_DoubleClick(object sender, EventArgs e)
        {
            if (dtTHvs.Rows.Count > 0)
            {
                frmChartControlPopup frm = new frmChartControlPopup(dtTHvs, 2);
                frm.ShowDialog();
            }
        }

        private void chartTiles2_DoubleClick(object sender, EventArgs e)
        {
            if (dtTHvs.Rows.Count > 0)
            {
                frmChartControlPopup frm = new frmChartControlPopup(dtTHvs, 3);
                frm.ShowDialog();
            }
        }
        int _year = 0;
        int _month = 0;
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (!btnToExcel.Enabled)
                return;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xls";
            saveFile.Title = "Exprot to Excel File";
            saveFile.ShowDialog();

            if (saveFile.FileName != "")
            {

                Excel.Application xlApp;

                Excel.Workbook xlWorkBook;

                Excel.Worksheet xlWorkSheet;
                Excel.Worksheet xlWorkSheet1;

                object misValue = System.Reflection.Missing.Value;


                xlApp = new Excel.ApplicationClass();

                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.Add();

                //add data 

                xlWorkSheet.Cells[1, 1] = "STT";
                xlWorkSheet.Cells[1, 2] = "Bộ phận";
                xlWorkSheet.Cells[1, 3] = "SLNV";
                xlWorkSheet.Cells[1, 4] = "Số NV đi trễ 6-14P";
                xlWorkSheet.Cells[1, 5] = "Số lần trễ 6-14P";
                xlWorkSheet.Cells[1, 6] = "Số NV đi trễ từ 15P trở đi";
                xlWorkSheet.Cells[1, 7] = "Số lần trễ từ 15P trở đi";
                xlWorkSheet.Cells[1, 8] = "Tỉ lệ đi trễ 6-14P";
                xlWorkSheet.Cells[1, 9] = "Tỉ lệ đi trễ từ 15P trở đi";

                xlWorkSheet1.Cells[1, 1] = "STT";
                xlWorkSheet1.Cells[1, 2] = "Bộ phận";
                xlWorkSheet1.Cells[1, 3] = "SLNV";
                xlWorkSheet1.Cells[1, 4] = "Số NV về sớm 6-14P";
                xlWorkSheet1.Cells[1, 5] = "Số lần về sớm 6-14P";
                xlWorkSheet1.Cells[1, 6] = "Số NV về sớm từ 15P trở đi";
                xlWorkSheet1.Cells[1, 7] = "Số lần về sớm từ 15P trở đi";
                xlWorkSheet1.Cells[1, 8] = "Tỉ lệ về sớm 6-14P";
                xlWorkSheet1.Cells[1, 9] = "Tỉ lệ về sớm từ 15P trở đi";

                object[,] Array_Record;
                Array_Record = new object[dtTHdt.Rows.Count, dtTHdt.Columns.Count];
                for (int i = 0; i < dtTHdt.Rows.Count; i++)
                {
                    for (int j = 0; j < dtTHdt.Columns.Count; j++)
                    {
                        Array_Record[i, j] = dtTHdt.Rows[i][j].ToString();
                    }
                }

                object[,] Array_Record1;
                Array_Record1 = new object[dtTHvs.Rows.Count, dtTHvs.Columns.Count];
                for (int i = 0; i < dtTHvs.Rows.Count; i++)
                {
                    for (int j = 0; j < dtTHvs.Columns.Count; j++)
                    {
                        Array_Record1[i, j] = dtTHvs.Rows[i][j].ToString();
                    }
                }


              xlWorkSheet.get_Range("A2", "I" + (dtTHdt.Rows.Count+1)).Value = Array_Record;
                xlWorkSheet.get_Range("H2", "I" + (dtTHdt.Rows.Count+1)).NumberFormat = "0%";
                xlWorkSheet.Name = "Di Tre";

                xlWorkSheet1.get_Range("A2", "I" +( dtTHvs.Rows.Count+1)).Value = Array_Record1;
                xlWorkSheet1.get_Range("H2", "I" + (dtTHvs.Rows.Count+1)).NumberFormat = "0%";
                xlWorkSheet1.Name = "Ve Som";

                Excel.Range chartRange;
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(450, 10, 400, 250);
                Excel.Chart chartPage = myChart.Chart;
                chartPage.HasTitle = true;
                chartPage.ChartTitle.Text = "Tổng hợp đi trễ tháng " + _month + "-" + _year;

                chartRange = xlWorkSheet.get_Range("B1:B" + (dtTHdt.Rows.Count + 1) + ",H1:H" + (dtTHdt.Rows.Count + 1) + ",I1:I" + (dtTHdt.Rows.Count + 1));
                chartPage.SetSourceData(chartRange, misValue);
                chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

                Excel.Range chartRange1;
                Excel.ChartObjects xlCharts1 = (Excel.ChartObjects)xlWorkSheet1.ChartObjects(Type.Missing);
                Excel.ChartObject myChart1 = (Excel.ChartObject)xlCharts1.Add(450, 10, 400, 250);
                Excel.Chart chartPage1 = myChart1.Chart;
                chartPage1.HasTitle = true;
                chartPage1.ChartTitle.Text = "Tổng hợp về sớm tháng " + _month + "-" + _year;

                chartRange1 = xlWorkSheet1.get_Range("B1:B" + (dtTHvs.Rows.Count + 1) + ",H1:H" + (dtTHvs.Rows.Count + 1) + ",I1:I" + (dtTHvs.Rows.Count + 1));
                chartPage1.SetSourceData(chartRange1, misValue);
                chartPage1.ChartType = Excel.XlChartType.xlColumnClustered;


                xlWorkBook.SaveAs(saveFile.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                MessageBox.Show("Xuất file thành công !..");
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
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}