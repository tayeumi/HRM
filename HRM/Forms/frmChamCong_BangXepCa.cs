using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;

namespace HRM.Forms
{
    public partial class frmChamCong_BangXepCa : DevExpress.XtraEditors.XtraForm
    {
        public frmChamCong_BangXepCa()
        {
            InitializeComponent();
            // qua trinh cap nhat thong tin nhan vien moi se duoc them trong qua trinh load du lieu.
            // su dung goi pro HRM_TIMEKEEPER_SHIFT_UpdateNewEmployee();
        }
        DataTable dtBXC = new DataTable();
        string _TimeKeeperTableListID="";
        DataTable dtShift= new DataTable();
        string template_grid = Application.StartupPath + @"\Templates\Templates_CCXepCa.xml";
        private void frmChamCong_BangXepCa_Load(object sender, EventArgs e)
        {
            #region Khoa Phan quyen
            // thuc hien khoa phan quyen phan quyen
            for (int i = 0; i < barManager.Items.Count; i++)
            {
                if (barManager.Items[i].Tag != null)
                {
                    string txt = barManager.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        barManager.Items[i].Enabled = false;
                    }
                }

            }

            #endregion
            #region mo phan quyen
            for (int i = 0; i < barManager.Items.Count; i++)
            {
                if (barManager.Items[i].Tag != null)
                {
                    string txt = barManager.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                        {
                            string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                            if (_Object_ID == txt)
                            {
                                barManager.Items[i].Enabled = true;
                            }
                        }

                    }
                }

            }
            #endregion


            Class.DanhMuc_CaLamViec ca = new Class.DanhMuc_CaLamViec();
            dtShift = ca.DIC_SHIFT_GetList();
            cboSelectItem.Items.Clear();
            cboSelectItem.Items.Add("Off");
            for (int i = 0; i < dtShift.Rows.Count; i++)
            {
                cboSelectItem.Items.Add(dtShift.Rows[i]["ShiftName"].ToString());
            }

        
            if (File.Exists(template_grid))
            {
                // gridItemDetail.SaveLayoutToXml(template_grid);
                gridItemDetail.RestoreLayoutFromXml(template_grid);
            }
            loaddsCocautochuc();
            int _Month = DateTime.Now.Month;
            int _Year = DateTime.Now.Year;
         //   kiemtraDuLieuTruockhiloadForm(_Month, _Year);
            txtMonth.EditValue = _Month;
            txtYear.EditValue = _Year;
          _TimeKeeperTableListID = HRM_TIMEKEEPER_TABLELIST_Get();
          btnSelect_ItemClick(null, null);
          treeListCoCauToChuc_FocusedNodeChanged(null, null);
          //Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
          //bxc.TimeKeeperTableListID = _TimeKeeperTableListID;
          //dtBXC = bxc.HRM_TIMEKEEPER_SHIFT_GetList();
          //gridItem.DataSource = dtBXC;  
          EnableControl();
         // colIsUpdate.Visible = true;         

        }
      
        private bool kiemtraDuLieuTruockhiloadForm(int _Month,int _Year)
        { 
            Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
            bxc.Month = _Month;
            bxc.Year = _Year;
            bxc.TimeKeeperTableListName = "Tháng " + _Month + "-" + _Year;
            bxc.TimeKeeperTableListID = Guid.NewGuid().ToString();
            DataTable dt = bxc.HRM_TIMEKEEPER_TABLELIST_Get();
            if (dt.Rows.Count < 1)
            {
                // kiem tra quyen tao truoc khi thong bao
                string _quyenKhoiTao = "";
                for (int i = 0; i < Class.App.dtPermision.Rows.Count; i++)
                {
                    if (Class.App.dtPermision.Rows[i]["Object_ID"].ToString() == "BXC_Tao")
                    {
                        _quyenKhoiTao = "BXC_Tao";
                    }
                }
                if (_quyenKhoiTao == "BXC_Tao")
                {// co quyen tao                   

                    if (MessageBox.Show("Bảng xếp ca tháng: " + bxc.Month + "/" + bxc.Year + " chưa có. Bạn có muốn khởi tạo cho tháng này không ?", "Tạo bảng xếp ca cho tháng: " + bxc.Month + "/" + bxc.Year, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        // gridItem.DataSource = null;
                        dtBXC.Clear();
                        EnableControl();
                        return false;
                    }
                    bxc.Insert();
                }
                else
                {// ko  co quyen tao
                    dtBXC.Clear();
                    EnableControl();
                    return false;
                }
            }

         
             return true;
        }
        int load_cctt = 0;
        public void loaddsCocautochuc()
        {
            load_cctt = 1;
            treeListCoCauToChuc.Nodes.Clear();
            int indexid = 1;
            int indexid2 = 0;

            Class.CongTy cty = new Class.CongTy();
            DataTable dtCty = cty.LoadThongTinCty();
            for (int i = 0; i < dtCty.Rows.Count; i++)
            {
                // add root tree list Cty
                this.treeListCoCauToChuc.AppendNode(new object[] { dtCty.Rows[i]["CompanyName"].ToString(), "0" }, -1, 0, 0, 0);
                Class.PhongBan pb = new Class.PhongBan();
                DataTable dtCN = pb.LoadDanhSachChiNhanh();
                for (int ii = 0; ii < dtCN.Rows.Count; ii++)
                {
                    indexid2++;
                    // add child treen chi nhanh
                    pb.BranchCode = dtCN.Rows[ii]["BranchCode"].ToString();
                    this.treeListCoCauToChuc.AppendNode(new object[] { dtCN.Rows[ii]["BranchName"].ToString() + " (" + dtCN.Rows[ii]["FactQuantity"].ToString() + "/" + dtCN.Rows[ii]["Quantity"].ToString() + ")", dtCN.Rows[ii]["BranchCode"].ToString() }, 0, 0, 0, 1);
                    DataTable dtPBofCN = pb.LoadDanhSachPhongBanThuocChiNhanh();

                    for (int iii = 0; iii < dtPBofCN.Rows.Count; iii++)
                    {
                        indexid2++;
                        // Add tree list Phong Ban
                        this.treeListCoCauToChuc.AppendNode(new object[] { dtPBofCN.Rows[iii]["DepartmentName"].ToString() + " (" + dtPBofCN.Rows[iii]["FactQuantity"].ToString() + "/" + dtPBofCN.Rows[iii]["Quantity"].ToString() + ")", dtPBofCN.Rows[iii]["DepartmentCode"].ToString() }, indexid, 0, 0, 2);
                        pb.DepartmentCode = dtPBofCN.Rows[iii]["DepartmentCode"].ToString();
                        DataTable dtGroupByPB = pb.LoadDanhSachNhomThuocPhongBan();
                        int t = indexid2;
                        for (int iiii = 0; iiii < dtGroupByPB.Rows.Count; iiii++)
                        {
                            // add nhom
                            this.treeListCoCauToChuc.AppendNode(new object[] { dtGroupByPB.Rows[iiii]["GroupName"].ToString() + " (" + dtGroupByPB.Rows[iiii]["FactQuantity"].ToString() + "/" + dtGroupByPB.Rows[iiii]["Quantity"].ToString() + ")", dtGroupByPB.Rows[iiii]["GroupCode"].ToString() }, t, 0, 0, 3);
                            indexid2++;
                        }

                    }
                    indexid = indexid2 + 1;
                }
            }
            this.treeListCoCauToChuc.ExpandAll();
            load_cctt = 0;
        }      
        private string HRM_TIMEKEEPER_TABLELIST_Get()
        {
            Class.ChamCong_BangXepCa xc = new Class.ChamCong_BangXepCa();
            xc.Month = int.Parse(txtMonth.EditValue.ToString());
            xc.Year =  int.Parse(txtYear.EditValue.ToString());  

            DataTable dt = xc.HRM_TIMEKEEPER_TABLELIST_Get();
            if (dt.Rows.Count > 0)
            {
                txtTimeKeeperTableListName.EditValue = dt.Rows[0]["TimeKeeperTableListName"].ToString();
                //_TimeKeeperTableListID = dt.Rows[0]["TimeKeeperTableListID "].ToString(); 
                return dt.Rows[0]["TimeKeeperTableListID"].ToString();
            }
            return "";           
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

        private void xulyloaddsNhanVien(string Dl)
        {
            Class.NhanVien nv = new Class.NhanVien();
            if (Dl == "0") // load tat ca
            {
                //Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
                //bxc.TimeKeeperTableListID = _TimeKeeperTableListID;
                //dtBXC.Clear();
                //dtBXC = bxc.HRM_TIMEKEEPER_SHIFT_GetList();        
                //gridItem.DataSource = dtBXC;
                //gridItem.DataSource = bxc.HRM_TIMEKEEPER_SHIFT_GetList();
                if (dtBXC.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtBXC.DefaultView;
                    dv.RowFilter = "";
                }

            }
            else if (Dl.IndexOf("CN") > -1)
            {
                //Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
                //bxc.TimeKeeperTableListID = _TimeKeeperTableListID;
                //bxc.BranchCode = Dl;
                //dtBXC.Clear();
                //dtBXC = bxc.HRM_TIMEKEEPER_SHIFT_GetListByBranch(); 
                //gridItem.DataSource = dtBXC;
                if (dtBXC.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtBXC.DefaultView;
                    dv.RowFilter = "BranchCode='" + Dl + "'";
                }

            }
            else if (Dl.IndexOf("PB") > -1)
            {
                //Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
                //bxc.TimeKeeperTableListID = _TimeKeeperTableListID;
                //bxc.DepartmentCode = Dl;
                //dtBXC.Clear();
                //dtBXC = bxc.HRM_TIMEKEEPER_SHIFT_GetListByDepartment();   
                //gridItem.DataSource = dtBXC;
               // gridItem.DataSource = bxc.HRM_TIMEKEEPER_SHIFT_GetListByDepartment();
                if (dtBXC.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtBXC.DefaultView;
                    dv.RowFilter = "DepartmentCode='" + Dl + "'";
                }
            }
            else
            {
                //Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
                //bxc.TimeKeeperTableListID = _TimeKeeperTableListID;
                //bxc.GroupCode = Dl;
                //dtBXC.Clear();
                //dtBXC = bxc.HRM_TIMEKEEPER_SHIFT_GetListByGroup();
                //gridItem.DataSource = dtBXC;
               // gridItem.DataSource = bxc.HRM_TIMEKEEPER_SHIFT_GetListByGroup();
                if (dtBXC.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtBXC.DefaultView;
                    dv.RowFilter = "GroupCode='" + Dl + "'";
                }
            }
        }

      

        private void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtBXC.Rows.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel File|*.xlsx";
                saveFile.Title = "Exprot to Excel File";
                saveFile.ShowDialog();

                if (saveFile.FileName != "")
                    gridItem.ExportToXlsx(saveFile.FileName);
                Class.S_Log.Insert("Chấm công", "Xuất bảng xếp ca " + txtTimeKeeperTableListName.EditValue.ToString());
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // kiểm tra sổ đã hoàn thành chưa
            Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
            bxc.Month = int.Parse(txtMonth.EditValue.ToString());
            bxc.Year = int.Parse(txtYear.EditValue.ToString()) ;                     
            DataTable dt = bxc.HRM_TIMEKEEPER_TABLELIST_Get();
            if (dt.Rows.Count > 0)
            {
                if ((bool)dt.Rows[0]["IsFinish"] == true)
                {
                    MessageBox.Show("Bảng xếp ca này đã xác nhận hoàn thành. Bạn không được phép cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if ((bool)dt.Rows[0]["IsLock"] == true)
                {
                    MessageBox.Show("Bảng xếp ca này hiện đang ở trạng thái khóa. Bạn không được phép cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Class.S_Log.Description = "Cập nhật bảng xếp ca " + txtTimeKeeperTableListName.EditValue.ToString()+ ": ";
                    if (dtBXC.Rows.Count > 0)
                    {                       
                        if (bxc.Update(dtBXC))
                        {
                            Class.App.SaveSuccessfully();
                           // Class.S_Log.Insert("Chấm công", "Cập nhật bảng xếp ca " + txtTimeKeeperTableListName.EditValue.ToString());
                            if (btnSelect.Enabled)
                            {
                                btnSelect_ItemClick(null, null);
                            }
                        }
                        else
                        {
                            Class.App.SaveNotSuccessfully();
                        }
                    }
                }
            }
        }

        private void HideColumOfGirdView(int _Month, int _Year)
        {
          int _DayNumber= DateTime.DaysInMonth(_Year, _Month);
         
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

         
            for (int i = 1; i < _DayNumber+1; i++)
          {
               DateTime date = new DateTime(_Year,_Month,i);
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
          colD1.Caption = "1 "+list[0];
          colD2.Caption = "2 "+list[1];
          colD3.Caption = "3 "+list[2];
          colD4.Caption = "4 "+list[3];
          colD5.Caption = "5 "+list[4];
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

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtBXC.Rows.Count > 0)
            {
                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

                link.Component = gridItem;

                link.Landscape = true;
                link.PaperKind = System.Drawing.Printing.PaperKind.A3;
                link.ShowPreview();

                //gridItem.ShowRibbonPrintPreview();
                Class.S_Log.Insert("Chấm công", "Xem trang In bảng xếp ca " + txtTimeKeeperTableListName.EditValue.ToString());
            }

        }
               
        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnSelect.Enabled == false)
                return;

            if (!kiemtraDuLieuTruockhiloadForm(int.Parse(txtMonth.EditValue.ToString()), int.Parse(txtYear.EditValue.ToString())))
                return;
            _TimeKeeperTableListID = HRM_TIMEKEEPER_TABLELIST_Get();
            Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
            bxc.TimeKeeperTableListID = _TimeKeeperTableListID;
            if (_TimeKeeperTableListID != "")
            {
                DataTable dtTempCheck = bxc.HRM_TIMEKEEPER_TABLELIST_GetByID();
                if (dtTempCheck.Rows.Count > 0)
                {
                    if ((bool)dtTempCheck.Rows[0]["IsFinish"] == false)
                    {
                        if ((bool)dtTempCheck.Rows[0]["IsLock"] == false)
                        {
                            bxc.HRM_TIMEKEEPER_SHIFT_UpdateNewEmployee();  // update neu nhan vien nhap sau khi bang cham cong duoc tao
                        }
                    }
                }
            }
            dtBXC = bxc.HRM_TIMEKEEPER_SHIFT_GetList();
            gridItem.DataSource = dtBXC;
            treeListCoCauToChuc_FocusedNodeChanged(null, null);
             EnableControl();
             Class.S_Log.Insert("Chấm công", "Xem bảng xếp ca tháng " + txtMonth.EditValue + " - " + txtYear.EditValue);

        }

        private void EnableControl()
        {

            if (dtBXC.Rows.Count < 1)
            {
                btnLuu.Enabled = false;
                btnPrint.Enabled = false;
                btnExportExcel.Enabled = false;               
                btnReset.Enabled = false;
            }
            else
            {
                //btnLuu.Enabled = true;
                //btnPrint.Enabled = true;
                //btnExportExcel.Enabled = true;
                //btnReset.Enabled = true;
                #region mo phan quyen
                for (int i = 0; i < barManager.Items.Count; i++)
                {
                    if (barManager.Items[i].Tag != null)
                    {
                        string txt = barManager.Items[i].Tag.ToString();
                        if (txt.Length > 0)
                        {
                            for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                            {
                                string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                if (_Object_ID == txt)
                                {
                                    barManager.Items[i].Enabled = true;
                                }
                            }

                        }
                    }

                }
                #endregion

            }
        }        

        private void btnMenuOffT7_Click(object sender, EventArgs e)
        {
            if (dtBXC.Rows.Count > 0)
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    for (int i = 0; i < gridItemDetail.Columns.Count; i++)
                    {
                        string txt = gridItemDetail.Columns[i].Caption;
                        if (txt.IndexOf("Sat") > 0)
                        {
                           // drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns[i], false);
                           gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colIsUpdate, "1");
                           gridItemDetail.PostEditor();
                        }
                    }
                }
            }

        }

        private void btnMenuOffCN_Click(object sender, EventArgs e)
        {
            if (dtBXC.Rows.Count > 0)
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    for (int i = 0; i < gridItemDetail.Columns.Count; i++)
                    {
                        string txt = gridItemDetail.Columns[i].Caption;
                        if (txt.IndexOf("Sun") > 0)
                        {
                            //drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns[i], false);
                          gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colIsUpdate, "1");
                           gridItemDetail.PostEditor();

                        }
                    }
                }
            }
        }

        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thực hiện chức năng này không ? \n Khi thực hiện chức năng này đồng nghĩa với việc bạn phải xếp ca và chấm công lại cho tháng " + txtMonth.EditValue.ToString()+"-"+txtYear.EditValue.ToString(), "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            // kiểm tra sổ đã hoàn thành chưa
            Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
            bxc.Month = int.Parse(txtMonth.EditValue.ToString());
            bxc.Year = int.Parse(txtYear.EditValue.ToString()) ;
            bxc.TimeKeeperTableListName = "Tháng " + txtMonth.EditValue + "-" + txtYear.EditValue;            
            DataTable dt = bxc.HRM_TIMEKEEPER_TABLELIST_Get();
            if (dt.Rows.Count > 0)
            {
                if ((bool)dt.Rows[0]["IsFinish"] == true)
                {
                    MessageBox.Show("Bảng xếp ca này đã xác nhận hoàn thành. Bạn không được phép khởi tạo lại dữ liệu xếp ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if ((bool)dt.Rows[0]["IsLock"] == true)
                {
                    MessageBox.Show("Bảng xếp ca này hiện đang ở trạng thái khóa. Bạn không được phép khởi tạo lại dữ liệu xếp ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // thay doi , them chuc nang tao tu Du lieu co san: Luu ly  NV moi                  
                    frmChamCong_BangXepCa_New frm = new frmChamCong_BangXepCa_New(dt.Rows[0]["TimeKeeperTableListID"].ToString());
                    frm.Owner = this;
                    frm.ShowDialog();
                    btnSelect_ItemClick(null, null);
                    //bxc.TimeKeeperTableListID = dt.Rows[0]["TimeKeeperTableListID"].ToString();
                    //if (bxc.HRM_TIMEKEEPER_TABLELIST_Reset())
                    //{
                    //    MessageBox.Show("Khởi tạo lại Dữ liệu thành công !");
                    //    Class.S_Log.Insert("Chấm công", "Khởi tạo lại dữ liệu xếp ca tháng " + txtMonth.EditValue + " - " + txtYear.EditValue);
                    //    btnSelect_ItemClick(null, null);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Lổi. không thể tạo lại Dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                   
                    
                    // bxc.TimeKeeperTableListID = Guid.NewGuid().ToString();

                }
            }
            else
            {
                MessageBox.Show("Lỗi. Bảng xếp ca " + "Tháng " + txtMonth.EditValue + "-" + txtYear.EditValue + " Chưa được tạo !!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmChamCong_BangXepCa_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                gridItemDetail.SaveLayoutToXml(template_grid);
            }
            catch { }
        }

       
        private void btnMenuOffT7VaCN_Click(object sender, EventArgs e)
        {
            if (dtBXC.Rows.Count > 0)
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {

                    int i = gridItemDetail.FocusedRowHandle;
                    gridItemDetail.SetRowCellValue(i, colD1, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD2, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD3, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD4, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD5, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD6, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD7, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD8, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD9, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD10, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD11, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD12, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD13, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD14, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD15, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD16, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD17, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD18, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD19, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD20, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD21, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD22, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD23, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD24, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD25, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD26, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD27, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD28, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD29, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD30, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD31, "HC1");

                    // loai bo ngay CN
                    for (int j = 0; j < gridItemDetail.Columns.Count; j++)
                    {
                        string txt = gridItemDetail.Columns[j].Caption;
                        if (txt.IndexOf("Sun") > 0)
                        {
                            // drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "Off");
                            gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                            gridItemDetail.PostEditor();
                        }
                        if (txt.IndexOf("Sat") > 0)
                        {
                            // drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "Off");
                            gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                            gridItemDetail.PostEditor();
                        }

                    }


                    gridItemDetail.PostEditor();
                }
            }
        }

      

        private void treeListCoCauToChuc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if( load_cctt ==0){
                if (treeListCoCauToChuc.FocusedNode != null)
                {  
                    if (_TimeKeeperTableListID.Length < 1)
                        return;
                    xulyloaddsNhanVien(treeListCoCauToChuc.FocusedNode.GetDisplayText(1));
                    HideColumOfGirdView(int.Parse(txtMonth.EditValue.ToString()), int.Parse(txtYear.EditValue.ToString()));  // ham an cot nay cua thang
                   EnableControl();
                }
            }
        }

       
        private void toolTip_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gridItem) return;
            ToolTipControlInfo info = null;
            try
            {
                GridView view = gridItem.GetViewAt(e.ControlMousePosition) as GridView;
                if (view == null) return;
                GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                if (hi.InRowCell)
                {
                    if (hi.Column.Name != "colShiftName")
                        return;

                    info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), GetCellHintText(view, hi.RowHandle, hi.Column));
                    return;
                }
               
            }
            finally
            {
                e.Info = info;
            }

        }
        private string GetCellHintText(GridView view, int rowHandle, DevExpress.XtraGrid.Columns.GridColumn column)
        {
            string ret = view.GetRowCellDisplayText(rowHandle, column);
            for (int i = 0; i < dtShift.Rows.Count; i++)
            {
                if (ret == dtShift.Rows[i]["ShiftName"].ToString())
                {
                    if (dtShift.Rows[i]["Description"].ToString() != "")
                    {
                        ret = dtShift.Rows[i]["Description"].ToString();
                    }
                    break;
                }                
            }
            return ret;
        }

        private void checkItem_CheckedChanged(object sender, EventArgs e)
        {
             gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colIsUpdate, "1");
            gridItemDetail.PostEditor();
        }

        private void btnAllCaHanhChanh_NghiCN_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridItemDetail.RowCount; i++)
            {               
                    gridItemDetail.SetRowCellValue(i, colD1, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD2, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD3, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD4, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD5, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD6, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD7, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD8, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD9, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD10, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD11, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD12, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD13, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD14, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD15, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD16, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD17, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD18, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD19, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD20, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD21, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD22, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD23, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD24, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD25, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD26, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD27, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD28, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD29, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD30, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD31, "HC1");

                    // loai bo ngay CN
                    for (int j = 0; j < gridItemDetail.Columns.Count; j++)
                    {
                        string txt = gridItemDetail.Columns[j].Caption;
                        if (txt.IndexOf("Sun") > 0)
                        {
                            // drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "Off");
                            gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                            gridItemDetail.PostEditor();
                        }
                    }

                }
               
            
        }

        private void btnAllCaHanhChanh_T7NghiCN_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridItemDetail.RowCount; i++)
            {                     
                    gridItemDetail.SetRowCellValue(i, colD1, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD2, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD3, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD4, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD5, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD6, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD7, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD8, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD9, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD10, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD11, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD12, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD13, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD14, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD15, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD16, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD17, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD18, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD19, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD20, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD21, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD22, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD23, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD24, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD25, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD26, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD27, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD28, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD29, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD30, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD31, "HC1");

                    // loai bo ngay CN va t7
                    for (int j = 0; j < gridItemDetail.Columns.Count; j++)
                    {
                        string txt = gridItemDetail.Columns[j].Caption;
                        if (txt.IndexOf("Sun") > 0)
                        {
                            // drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "Off");
                            gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                            gridItemDetail.PostEditor();
                        }
                        if (txt.IndexOf("Sat") > 0)
                        {
                            // drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "Off");
                            gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                            gridItemDetail.PostEditor();
                        }
                    }

                }
         
               
            
        }

        private void btnAllCaHanhChanh_NghiCN_LamSangT7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridItemDetail.RowCount; i++)
            {                
                    gridItemDetail.SetRowCellValue(i, colD1, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD2, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD3, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD4, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD5, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD6, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD7, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD8, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD9, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD10, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD11, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD12, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD13, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD14, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD15, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD16, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD17, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD18, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD19, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD20, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD21, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD22, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD23, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD24, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD25, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD26, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD27, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD28, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD29, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD30, "HC1");
                    gridItemDetail.SetRowCellValue(i, colD31, "HC1");

                    // loai bo ngay CN
                    for (int j = 0; j < gridItemDetail.Columns.Count; j++)
                    {
                        string txt = gridItemDetail.Columns[j].Caption;
                        if (txt.IndexOf("Sun") > 0)
                        {
                            // drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "Off");
                            gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                            gridItemDetail.PostEditor();
                        }
                        if (txt.IndexOf("Sat") > 0)
                        {
                            // drow[i - 1] = false;
                            gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "NB1");
                            gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                            gridItemDetail.PostEditor();
                        }
                    }

                }
              
        }

        private void btnCaHanhChanh_NghiCN_LamSangT7_Click(object sender, EventArgs e)
        {
                        int i = gridItemDetail.FocusedRowHandle;
                        gridItemDetail.SetRowCellValue(i, colD1, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD2, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD3, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD4, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD5, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD6, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD7, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD8, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD9, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD10, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD11, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD12, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD13, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD14, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD15, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD16, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD17, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD18, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD19, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD20, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD21, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD22, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD23, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD24, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD25, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD26, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD27, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD28, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD29, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD30, "HC1");
                        gridItemDetail.SetRowCellValue(i, colD31, "HC1");

                        // loai bo ngay CN
                        for (int j = 0; j < gridItemDetail.Columns.Count; j++)
                        {
                            string txt = gridItemDetail.Columns[j].Caption;
                            if (txt.IndexOf("Sun") > 0)
                            {
                                // drow[i - 1] = false;
                                gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "Off");
                                gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                                gridItemDetail.PostEditor();
                            }
                            if (txt.IndexOf("Sat") > 0)
                            {
                                // drow[i - 1] = false;
                                gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "NB1");
                                gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                                gridItemDetail.PostEditor();
                            }
                                          
                          }
            
                     gridItemDetail.PostEditor();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gridItemDetail.FocusedRowHandle < 0)
                e.Cancel = true;
            string data = Clipboard.GetText();
                data = data.Replace("\t", "|");
                string[] dl = data.Split('|');

                btnCaBaoTri.Enabled = false;
                btnCaCS.Enabled = false;
                btnCaThuNgan.Enabled = false;
                btnCaBBS2.Enabled = false;
                btnCaDPld.Enabled = false;
                btnCanvLM.Enabled = false;
                

                if (dl.Length > 24 && dl.Length < 32)
                {

                    btnCaBaoTri.Enabled = true;
                    btnCaCS.Enabled = true;
                    btnCaThuNgan.Enabled = true;
                    btnCaBBS2.Enabled = true;
                    btnCaDPld.Enabled = true;
                    btnCanvLM.Enabled = true;
                }
                else
                {

                    btnCaBaoTri.Enabled = false;
                    btnCaCS.Enabled = false;
                    btnCaThuNgan.Enabled = false;
                    btnCaBBS2.Enabled = false;
                    btnCaDPld.Enabled = false;
                    btnCanvLM.Enabled = false;
                }               

        }

        private void gridItemDetail_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {          
            gridItemDetail.PostEditor();
        }

        private void gridItemDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column != colIsUpdate)
            {
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colIsUpdate, "1");
            }
        }

        private void btnCaBaoTri_Click(object sender, EventArgs e)
        {
                string data = Clipboard.GetText();
                data = data.Replace("\t", "|");
                string[] dl = data.Split('|');
                if (dl.Length > 27 && dl.Length < 32)
                {
                    for (int i = 0; i < dl.Length; i++)
                    {

                        if (dl[i].ToString().Trim().ToLower() == "off")
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                        }
                        else if (dl[i].ToString().Trim().Length==0)
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC1");
                        }
                        else if (dl[i].ToString().Trim().ToLower() == "tđ")
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "TD");
                        }
                        else if (dl[i].ToString().Trim().ToLower() == "lđ")
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "LD");
                        }
                        else if (dl[i].ToString().Trim().ToLower() == "lm")
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC1");
                        }
                        else if (dl[i].ToString().Trim().ToLower() == "pn")
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "PN");
                        }
                        else if (dl[i].ToString().Trim().ToLower() == "nb")
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "NB");
                        }
                        else if (dl[i].ToString().Trim().ToLower() == "nl")
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HL");
                        }
                        else if (dl[i].ToString().Trim().ToLower() == "pb")
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "PB");
                        }
                    }
                    gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
                }
        }

        private void btnCaCS_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            data = data.Replace("\t", "|");
            string[] dl = data.Split('|');
            if (dl.Length > 27 && dl.Length < 32)
            {
                for (int i = 0; i < dl.Length; i++)
                {
                    if (dl[i].ToString().Trim().ToLower() == "off")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cs")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 1a");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cc")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 2a");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cg")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC1");
                    }

                }
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
            }
        }

        private void cboSelectItem_EditValueChanged(object sender, EventArgs e)
        {
            gridItemDetail.PostEditor();
        }

        private void btnDieuPhoi_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            data = data.Replace("\t", "|");
            string[] dl = data.Split('|');
            if (dl.Length > 27 && dl.Length < 32)
            {
                for (int i = 0; i < dl.Length; i++)
                {
                    if (dl[i].ToString().Trim().ToLower() == "off")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cs")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 1a");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cc")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 2a");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "hc")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC1");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "pn")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "PN");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "nb")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "NB");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "nl")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HL");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "pb")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "PB");
                    }
                  

                }
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
            }
        }

        private void btnCaThuNgan_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            data = data.Replace("\t", "|");
            string[] dl = data.Split('|');
            if (dl.Length > 27 && dl.Length < 32)
            {
                for (int i = 0; i < dl.Length; i++)
                {
                    if (dl[i].ToString().Trim().ToLower() == "off")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cs")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 1a");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cc")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 2a");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "7h-11h")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "NB2");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "8h-12h")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "NB1");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "hc")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC1");
                    }  

                }
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
            }
        }

        private void btnCaBBS2_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            data = data.Replace("\t", "|");
            string[] dl = data.Split('|');
            if (dl.Length > 27 && dl.Length < 32)
            {
                for (int i = 0; i < dl.Length; i++)
                {
                    if (dl[i].ToString().Trim().ToLower() == "off")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cs")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 1");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cc")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 2");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "cg")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC1");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "kg")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "KG");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "ca 2")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Ca 2");
                    }

                }
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
            }
        }

        private void btnCaHanhChanh_NghiCN_LamT7_Click(object sender, EventArgs e)
        {
            int i = gridItemDetail.FocusedRowHandle;
            gridItemDetail.SetRowCellValue(i, colD1, "HC1");
            gridItemDetail.SetRowCellValue(i, colD2, "HC1");
            gridItemDetail.SetRowCellValue(i, colD3, "HC1");
            gridItemDetail.SetRowCellValue(i, colD4, "HC1");
            gridItemDetail.SetRowCellValue(i, colD5, "HC1");
            gridItemDetail.SetRowCellValue(i, colD6, "HC1");
            gridItemDetail.SetRowCellValue(i, colD7, "HC1");
            gridItemDetail.SetRowCellValue(i, colD8, "HC1");
            gridItemDetail.SetRowCellValue(i, colD9, "HC1");
            gridItemDetail.SetRowCellValue(i, colD10, "HC1");
            gridItemDetail.SetRowCellValue(i, colD11, "HC1");
            gridItemDetail.SetRowCellValue(i, colD12, "HC1");
            gridItemDetail.SetRowCellValue(i, colD13, "HC1");
            gridItemDetail.SetRowCellValue(i, colD14, "HC1");
            gridItemDetail.SetRowCellValue(i, colD15, "HC1");
            gridItemDetail.SetRowCellValue(i, colD16, "HC1");
            gridItemDetail.SetRowCellValue(i, colD17, "HC1");
            gridItemDetail.SetRowCellValue(i, colD18, "HC1");
            gridItemDetail.SetRowCellValue(i, colD19, "HC1");
            gridItemDetail.SetRowCellValue(i, colD20, "HC1");
            gridItemDetail.SetRowCellValue(i, colD21, "HC1");
            gridItemDetail.SetRowCellValue(i, colD22, "HC1");
            gridItemDetail.SetRowCellValue(i, colD23, "HC1");
            gridItemDetail.SetRowCellValue(i, colD24, "HC1");
            gridItemDetail.SetRowCellValue(i, colD25, "HC1");
            gridItemDetail.SetRowCellValue(i, colD26, "HC1");
            gridItemDetail.SetRowCellValue(i, colD27, "HC1");
            gridItemDetail.SetRowCellValue(i, colD28, "HC1");
            gridItemDetail.SetRowCellValue(i, colD29, "HC1");
            gridItemDetail.SetRowCellValue(i, colD30, "HC1");
            gridItemDetail.SetRowCellValue(i, colD31, "HC1");

            // loai bo ngay CN
            for (int j = 0; j < gridItemDetail.Columns.Count; j++)
            {
                string txt = gridItemDetail.Columns[j].Caption;
                if (txt.IndexOf("Sun") > 0)
                {
                    // drow[i - 1] = false;
                    gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "Off");
                    gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                    gridItemDetail.PostEditor();
                }
                if (txt.IndexOf("Sat") > 0)
                {
                    // drow[i - 1] = false;
                    gridItemDetail.SetRowCellValue(i, gridItemDetail.Columns[j], "HC1");
                    gridItemDetail.SetRowCellValue(i, colIsUpdate, "1");
                    gridItemDetail.PostEditor();
                }

            }

            gridItemDetail.PostEditor();
        }

        private void btnCaillegal_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            data = data.Replace("\t", "|");
            string[] dl = data.Split('|');
            if (dl.Length > 27 && dl.Length < 32)
            {
                for (int i = 0; i < dl.Length; i++)
                {
                    if (dl[i].ToString().Trim().ToLower() == "off")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                    }
                    else 
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC2");
                    }
                   

                }
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
            }
        }

        private void btnCaDPld_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            data = data.Replace("\t", "|");
            string[] dl = data.Split('|');
            if (dl.Length > 27 && dl.Length < 32)
            {
                for (int i = 0; i < dl.Length; i++)
                {
                    if (dl[i].ToString().Trim().ToLower() == "off")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "hc1")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC1");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "hc3")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC3");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "hc2")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC2");
                    }    

                }
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
            }
        }

        private void btnCanvQ2Q9_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            data = data.Replace("\t", "|");
            string[] dl = data.Split('|');
            if (dl.Length > 27 && dl.Length < 32)
            {
                for (int i = 0; i < dl.Length; i++)
                {
                    if (dl[i].ToString().Trim().ToLower() == "off")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "pn")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "PN");
                    }
                    else
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC2");
                    }


                }
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
            }
        }

        private void btnCanvLM_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            data = data.Replace("\t", "|");
            string[] dl = data.Split('|');
            if (dl.Length > 27 && dl.Length < 32)
            {
                for (int i = 0; i < dl.Length; i++)
                {
                    if (dl[i].ToString().Trim().ToLower() == "off")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "Off");
                    }
                    else if (dl[i].ToString().Trim().ToLower() == "pn")
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "PN");
                    }
                    else
                    {
                        gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["D" + (i + 1).ToString()], "HC1");
                    }


                }
                gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns["IsUpdate"], 1);
            }
        }
                    
    }
}