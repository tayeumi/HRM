using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using System.Drawing;


namespace HRM.Forms
{
    public partial class frmChamCong_ChamCongThang : DevExpress.XtraEditors.XtraForm
    {
        public frmChamCong_ChamCongThang()
        {
            InitializeComponent();
        }
        string bccname = "";
        static bool _islock = true;
        static bool _isFinish = true;
        DataTable dtCC = new DataTable();
        DataTable dtCTCC = new DataTable();
        DataTable dtCCComment = new DataTable();
        DataTable dtSYMBOL = new DataTable();
        string template_grid = Application.StartupPath + @"\Templates\Templates_CCThang.xml";
        private void frmChamCong_ChamCongThang_Load(object sender, EventArgs e)
        {
        //    if (File.Exists(template_grid))
        //    {
        //        // gridItemDetail.SaveLayoutToXml(template_grid);
        //        gridItemDetail.RestoreLayoutFromXml(template_grid);
        //    }
            HRM_TIMEKEEPER_TABLELIST_GetList();
            loaddsCocautochuc();
            DIC_SYMBOL_GetList();
            butonEnableControl();

            #region Khoa Phan quyen
            // thuc hien khoa phan quyen phan quyen
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].Tag != null)
                {
                    string txt = barManager1.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        barManager1.Items[i].Enabled = false;
                    }
                }

            }

            for (int i = 0; i < contextMenuComment.Items.Count; i++)
            {
                if (contextMenuComment.Items[i].Tag != null)
                {
                    string txt = contextMenuComment.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        contextMenuComment.Items[i].Enabled = false;
                    }
                }

            }
            #endregion
           #region mo phan quyen
            for (int i = 0; i < contextMenuComment.Items.Count; i++)
            {
                if (contextMenuComment.Items[i].Tag != null)
                {
                    string txt = contextMenuComment.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                        {
                            string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                            if (_Object_ID == txt)
                            {
                                contextMenuComment.Items[i].Enabled = true;
                            }
                        }

                    }
                }

            }
           #endregion


        }

        private void DIC_SYMBOL_GetList()
        {
            Class.DanhMuc_KyHieuChamCong dm = new Class.DanhMuc_KyHieuChamCong();
            dtSYMBOL = dm.DIC_SYMBOL_GetList();
            cboSelectItem.Items.Clear();
            //string txt = "    ";
            for (int i = 0; i < dtSYMBOL.Rows.Count; i++)
            {
                cboSelectItem.Items.Add(dtSYMBOL.Rows[i]["SymbolCode"].ToString());

                //txt += txt_return(dt.Rows[i]["SymbolCode"].ToString() + " : " + dt.Rows[i]["SymbolName"].ToString(), 40);
                //if ((i == 4) || (i == 9))
                //    txt += "\r\n";
            }
           // txtKyHieuChamCong.Text = txt;
        }

        private string txt_return(string txt, int _len) // hàm thêm khoảng trắng cho txt đều nhau ( format)
        {          
            int _len2 = _len - txt.Length;
            for(int i=0;i<_len2;i++){
                txt += " ";
            }
            return txt;
        }

        private void HRM_TIMEKEEPER_TABLELIST_GetList()
        {
            Class.ChamCong_BangXepCa xc= new Class.ChamCong_BangXepCa();
            cboBangChamCong.DataSource = xc.HRM_TIMEKEEPER_TABLELIST_GetList();
            cboBangChamCong.ValueMember = "TimeKeeperTableListID";
            cboBangChamCong.DisplayMember = "TimeKeeperTableListName";
        }

        public void HRM_TIMEKEEPER_TABLE_COMMENT_GetList()
        {
            if (txtBangChamCong.EditValue != null)
            {
                Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                cct.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
               dtCCComment = cct.HRM_TIMEKEEPER_TABLE_COMMENT_GetList();
            }
        }
        private void KiemTraVaoKhoiTaoDuLieuMoi(int year,int month)
        {
            if (txtBangChamCong.EditValue != null)
            {
                Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                cct.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                dtCC = cct.HRM_TIMEKEEPER_TABLE_GetList();
                if (dtCC.Rows.Count < 1)
                {
                    cct.HRM_TIMEKEEPER_TABLE_Create();
                    dtCC = cct.HRM_TIMEKEEPER_TABLE_GetList();                   
                }
                dtCC = Class.ChamCong_ChamCongThang.TinhTongHopChamCong(dtCC, year, month, DayOfWeek.Sunday);
                gridItem.DataSource = dtCC;
                HRM_TIMEKEEPER_TABLE_COMMENT_GetList();
            }
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
        int _year = 0;
        int _month = 0;
        private void txtBangChamCong_EditValueChanged(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
            bxc.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();           
            DataTable dt = bxc.HRM_TIMEKEEPER_TABLELIST_GetByID();
           
            if (dt.Rows.Count > 0)
            {
                HideColumOfGirdView((int)dt.Rows[0]["Month"], (int)dt.Rows[0]["Year"]);
                KiemTraSoChamCong((bool)dt.Rows[0]["IsLock"], (bool)dt.Rows[0]["IsFinish"]);
                _islock = (bool)dt.Rows[0]["IsLock"];
                _isFinish = (bool)dt.Rows[0]["IsFinish"];
                bccname = dt.Rows[0]["TimeKeeperTableListName"].ToString();
                _year= (int)dt.Rows[0]["Year"];
                _month=(int)dt.Rows[0]["Month"];
            }          
                KiemTraVaoKhoiTaoDuLieuMoi(_year,_month); 
                 butonEnableControl();

                 if (txtBangChamCong.EditValue != null)
                     btnRefresh.Enabled = true;

                 dtCTCC.Clear();  // xoa bang chi tiet cham cong cua thang chon trước
           Waiting.CloseWaitForm();
        }
        private void butonEnableControl()
        {

            if (dtCC.Rows.Count < 1)
            {
                btnSave.Enabled = false;
                btnPrint.Enabled = false;
                btnExport.Enabled = false;
                btnOpenBook.Enabled = false;
                btnCloseBook.Enabled = false;
                btnComplete.Enabled = false;
                btnMenuLoadCCNhanVien.Enabled = false;
                btnMenuLoadAllCCThang.Enabled = false;
                btnLoadChiTietCC.Enabled = false;
                btnReLoadTHCC.Enabled = false;
            }
            else
            {
               // btnSave.Enabled = true;
               // btnPrint.Enabled = true;
               // btnExport.Enabled = true;
                #region mo phan quyen
                for (int i = 0; i < barManager1.Items.Count; i++)
                {
                    if (barManager1.Items[i].Tag != null)
                    {
                        string txt = barManager1.Items[i].Tag.ToString();
                        if (txt.Length > 0)
                        {
                            for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                            {
                                string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                if (_Object_ID == txt)
                                {
                                    barManager1.Items[i].Enabled = true;
                                }
                                if (_Object_ID == "CCT_RTHCTCC")
                                {
                                    btnReLoadTHCC.Enabled = true;
                                }
                            }

                        }
                    }

                }
                #endregion
            }
                     

            if (_islock)
            {
              //  btnOpenBook.Enabled = true;
                #region mo phan quyen
                for (int i = 0; i < barManager1.Items.Count; i++)
                {
                    if (barManager1.Items[i].Tag != null)
                    {
                        string txt = barManager1.Items[i].Tag.ToString();
                        if (txt.Length > 0)
                        {
                            for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                            {
                                string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                if (_Object_ID == txt)
                                {
                                    if (txt == "CCT_UnLock")
                                    {
                                        barManager1.Items[i].Enabled = true;
                                    }
                                }
                                if (_Object_ID == "CCT_RTHCTCC")
                                {
                                    btnReLoadTHCC.Enabled = true;
                                }
                            }

                        }
                    }

                }
                #endregion
                
                btnCloseBook.Enabled = false;
                btnSave.Enabled = false;
                btnMenuLoadCCNhanVien.Enabled = false;
                btnMenuLoadAllCCThang.Enabled = false;
              
            }
            else
            {
                btnOpenBook.Enabled = false;

                //btnCloseBook.Enabled = true;
                //btnSave.Enabled = true;
                #region mo phan quyen
                for (int i = 0; i < barManager1.Items.Count; i++)
                {
                    if (barManager1.Items[i].Tag != null)
                    {
                        string txt = barManager1.Items[i].Tag.ToString();
                        if (txt.Length > 0)
                        {
                            for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                            {
                                string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                if (_Object_ID == txt)
                                {
                                    if (txt == "CCT_Lock")
                                    {
                                        barManager1.Items[i].Enabled = true;
                                    }                                   
                                }
                                if (_Object_ID == "CCT_RTHCTCC")
                                {
                                    btnReLoadTHCC.Enabled = true;
                                }
                            }

                        }
                    }

                }
                #endregion

                btnMenuLoadCCNhanVien.Enabled = true;
                btnMenuLoadAllCCThang.Enabled = true;
               
            }
            if (_isFinish)
            {
                btnSave.Enabled = false;
                btnOpenBook.Enabled = false;
                btnCloseBook.Enabled = false;
                btnComplete.Enabled = false;
                btnMenuLoadCCNhanVien.Enabled = false;
                btnMenuLoadAllCCThang.Enabled = false;
            }
            else
            {
               // btnComplete.Enabled = true;
                #region mo phan quyen
                for (int i = 0; i < barManager1.Items.Count; i++)
                {
                    if (barManager1.Items[i].Tag != null)
                    {
                        string txt = barManager1.Items[i].Tag.ToString();
                        if (txt.Length > 0)
                        {
                            for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                            {
                                string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                if (_Object_ID == txt)
                                {
                                    if (txt == "CCT_Finish")
                                    {
                                        barManager1.Items[i].Enabled = true;
                                    }
                                    if (txt == "CCT_RTHCTCC")
                                    {
                                       btnReLoadTHCC.Enabled = true;
                                    }
                                }
                            }

                        }
                    }

                }
                #endregion
            }

        }

        private void KiemTraSoChamCong(bool IsLock,bool IsFinish)
        {
            if (IsLock)
            {
                for (int i = 0; i < gridItemDetail.Columns.Count; i++)
                {
                    gridItemDetail.Columns[i].OptionsColumn.AllowEdit = false;
                }  
            }
            else
            {
                for (int i = 0; i < gridItemDetail.Columns.Count; i++)
                {

                    gridItemDetail.Columns[i].OptionsColumn.AllowEdit = true;
                    if (gridItemDetail.Columns[i].Caption == "Mã Nhân Viên")
                        gridItemDetail.Columns[i].OptionsColumn.AllowEdit = false;
                    if (gridItemDetail.Columns[i].Caption == "Họ lót")
                        gridItemDetail.Columns[i].OptionsColumn.AllowEdit = false;
                    if (gridItemDetail.Columns[i].Caption == "Tên")
                        gridItemDetail.Columns[i].OptionsColumn.AllowEdit = false;
                    if (gridItemDetail.Columns[i].Caption == "Ca")
                        gridItemDetail.Columns[i].OptionsColumn.AllowEdit = false;
                }  
            }


            if (IsFinish)
            {
                for (int i = 0; i < gridItemDetail.Columns.Count; i++)
                {
                    gridItemDetail.Columns[i].OptionsColumn.AllowEdit = false;                
                }
            }

        }

        private void HideColumOfGirdView(int _Month, int _Year)
        {
            int _DayNumber = DateTime.DaysInMonth(_Year, _Month);

            List<string> list = new List<string>();
            #region default Color
            this.colD1.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD2.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD3.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD4.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD5.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD6.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD7.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD8.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD9.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD10.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD11.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD12.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD13.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD14.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD15.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD16.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD17.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD18.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD19.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD1.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD20.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD21.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD22.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD23.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD24.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD25.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD26.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD27.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD28.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD29.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD30.AppearanceCell.BackColor = System.Drawing.Color.Empty;
            this.colD31.AppearanceCell.BackColor = System.Drawing.Color.Empty;
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

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

      
        private void xulyloaddsNhanVien(string Dl)
        {
            Class.NhanVien nv = new Class.NhanVien();
            if (Dl == "0") // load tat ca
            {
                //Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                //cct.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                //dtCC.Clear();
                //dtCC = cct.HRM_TIMEKEEPER_TABLE_GetList();
                //gridItem.DataSource = dtCC;  
                if (dtCC.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtCC.DefaultView;
                    dv.RowFilter = "";
                }

            }
            else if (Dl.IndexOf("CN") > -1)
            {
                //Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                //cct.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                //cct.BranchCode = Dl;
                //dtCC.Clear();
                //dtCC = cct.HRM_TIMEKEEPER_TABLE_GetListByBranch();
                //gridItem.DataSource = dtCC;
                if (dtCC.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtCC.DefaultView;
                    dv.RowFilter = "BranchCode='" + Dl + "'";
                }

            }
            else if (Dl.IndexOf("PB") > -1)
            {
                //Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                //cct.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                //cct.DepartmentCode = Dl;
                //dtCC.Clear();
                //dtCC = cct.HRM_TIMEKEEPER_TABLE_GetListByDepartment();
                //gridItem.DataSource = dtCC;
                if (dtCC.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtCC.DefaultView;
                    dv.RowFilter = "DepartmentCode='" + Dl + "'";
                }
               
            }
            else
            {
                //Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                //cct.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                //cct.GroupCode = Dl;
                //dtCC.Clear();
                //dtCC = cct.HRM_TIMEKEEPER_TABLE_GetListByGroup();
                //gridItem.DataSource = dtCC;     
                if (dtCC.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtCC.DefaultView;
                    dv.RowFilter = "GroupCode='" + Dl + "'";
                }
            }
            //butonEnableControl();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
            bxc.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();           
            DataTable dt = bxc.HRM_TIMEKEEPER_TABLELIST_GetByID();
            if (dt.Rows.Count > 0)
            {
                if (dtCC.Rows.Count > 0)
                {
                    Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                    Class.S_Log.Description = "Cập nhật bảng Chấm công " + bccname + ": ";
                   // cap nhat ngay update vao dttble
                    //for (int j = 0; j < dtCC.Rows.Count; j++)
                    //{
                    //    if (dtCC.Rows[j]["IsUpdate"].ToString() == "1")
                    //    {
                    //        dtCC.Rows[j]["UpdateDay"] = _Updateday;
                    //        dtCC.Rows[j]["Worked"] = true;
                    //    }
                    //}
                    // het cap nhat
                    int _DayNumber = DateTime.DaysInMonth(_year, _month);
                    if (cct.Update(dtCC, _DayNumber))
                    {
                        Class.App.SaveSuccessfully();
                       
                      Class.S_Log.Insert("Chấm công", " Cập nhật Bảng Chấm công " + bccname);
                     btnRefresh_ItemClick(null, null);

                    }
                    else
                    {
                        Class.App.SaveNotSuccessfully();
                    }
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu hiện tại không khớp vì có sự thay đổi về bảng xếp ca. \n Vui lòng đóng và mở lại chức năng này.! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // gridItem.ShowRibbonPrintPreview();
            Waiting.ShowWaitForm();
            if (_month > 0 && _year > 0)
            {
                Class.S_Log.Insert("Chấm công", "In bảng Chấm công " + bccname);
                DataTable DTin_Temp = new DataTable();
                DTin_Temp = dtCC.DefaultView.ToTable();
                int t = 0;              
                for (int i = 0; i < DTin_Temp.Rows.Count; i++)
                {
                    if (!(bool)DTin_Temp.Rows[i]["PrintAllow"])
                    {
                        DTin_Temp.Rows.RemoveAt(i);
                        i = -1;
                        t++;
                    }
                   
                }
               
                if (DTin_Temp.Columns["STT"] == null)
                    DTin_Temp.Columns.Add("STT");
                for (int i = 0; i < DTin_Temp.Rows.Count; i++)
                {
                    DTin_Temp.Rows[i]["STT"] = i + 1;  
                }
                if (DTin_Temp.Rows.Count > 0)
                {                 
                    if ((DTin_Temp.Rows.Count+t) == dtCC.Rows.Count) // neu khong chon gi ca thi xuat tat ca cong ty
                    {
                        int _DayNumber = DateTime.DaysInMonth(_year, _month);
                        if (_DayNumber == 31)
                        {
                            Reports.reportBangChamCongTongHop rp = new Reports.reportBangChamCongTongHop(_month, _year, "ALL");
                            rp.DataSource = DTin_Temp;
                            rp.ShowPreview();
                           
                        }
                        else if (_DayNumber == 30)
                        {
                            Reports.reportBangChamCongTongHop_30 rp = new Reports.reportBangChamCongTongHop_30(_month, _year, "ALL");
                            rp.DataSource = DTin_Temp;
                            rp.ShowPreview();
                        }
                        else if (_DayNumber == 29)
                        {
                            Reports.reportBangChamCongTongHop_29 rp = new Reports.reportBangChamCongTongHop_29(_month, _year, "ALL");
                            rp.DataSource = DTin_Temp;
                            rp.ShowPreview();
                        }
                        else
                        {
                            Reports.reportBangChamCongTongHop_28 rp = new Reports.reportBangChamCongTongHop_28(_month, _year, "ALL");
                            rp.DataSource = DTin_Temp;
                            rp.ShowPreview();
                        }
                    }
                    else
                    {
                        #region Gọi Report
                        if (DTin_Temp.Rows[0]["GroupName"].ToString() == "") // xac dinh hien thi bộ phận
                        {
                            int _DayNumber = DateTime.DaysInMonth(_year, _month);
                            if (_DayNumber == 31)
                            {
                                Reports.reportBangChamCongTongHop rp = new Reports.reportBangChamCongTongHop(_month, _year, "PB");
                                rp.DataSource = DTin_Temp;
                                rp.ShowPreview();
                            }
                            else if (_DayNumber == 30)
                            {
                                Reports.reportBangChamCongTongHop_30 rp = new Reports.reportBangChamCongTongHop_30(_month, _year, "PB");
                                rp.DataSource = DTin_Temp;
                                rp.ShowPreview();
                            }
                            else if (_DayNumber == 29)
                            {
                                Reports.reportBangChamCongTongHop_29 rp = new Reports.reportBangChamCongTongHop_29(_month, _year, "PB");
                                rp.DataSource = DTin_Temp;
                                rp.ShowPreview();
                            }
                            else
                            {
                                Reports.reportBangChamCongTongHop_28 rp = new Reports.reportBangChamCongTongHop_28(_month, _year, "PB");
                                rp.DataSource = DTin_Temp;
                                rp.ShowPreview();
                            }
                        }
                        else
                        {
                            int _DayNumber = DateTime.DaysInMonth(_year, _month);
                            if (_DayNumber == 31)
                            {
                                Reports.reportBangChamCongTongHop rp = new Reports.reportBangChamCongTongHop(_month, _year, "NHOM");
                                rp.DataSource = DTin_Temp;
                                rp.ShowPreview();
                            }
                            else if (_DayNumber == 30)
                            {
                                Reports.reportBangChamCongTongHop_30 rp = new Reports.reportBangChamCongTongHop_30(_month, _year, "NHOM");
                                rp.DataSource = DTin_Temp;
                                rp.ShowPreview();
                            }
                            else if (_DayNumber == 29)
                            {
                                Reports.reportBangChamCongTongHop_29 rp = new Reports.reportBangChamCongTongHop_29(_month, _year, "NHOM");
                                rp.DataSource = DTin_Temp;
                                rp.ShowPreview();
                            }
                            else
                            {
                                Reports.reportBangChamCongTongHop_28 rp = new Reports.reportBangChamCongTongHop_28(_month, _year, "NHOM");
                                rp.DataSource = DTin_Temp;
                                rp.ShowPreview();
                            }
                        }
                        #endregion
                    }
                }
            }
            Waiting.CloseWaitForm();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtCC.Rows.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel File|*.xlsx";
                saveFile.Title = "Exprot to Excel File";
                saveFile.ShowDialog();

                if (saveFile.FileName != "")
                    gridItem.ExportToXlsx(saveFile.FileName);
                Class.S_Log.Insert("Chấm công", "Xuất bảng Chấm công " + bccname);
            }
        }

        private void btnCloseBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtBangChamCong.EditValue != null)
            {
                Class.ChamCong_ChamCongThang bcc = new Class.ChamCong_ChamCongThang();
                bcc.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                bcc.IsLock = true;
                bcc.IsFinish = false;
                if (bcc.HRM_TIMEKEEPER_TABLELIST_Lock())
                {
                    MessageBox.Show("Đã khóa sổ thành công");
                    txtBangChamCong_EditValueChanged(null, null);
                    Class.S_Log.Insert("Chấm công", "Khóa sổ bảng Chấm công " + bccname);
                }
                else
                {
                    MessageBox.Show("Đã khóa sổ thất bại");
                }
            }
        }

        private void btnOpenBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtBangChamCong.EditValue != null)
            {
                Class.ChamCong_ChamCongThang bcc = new Class.ChamCong_ChamCongThang();
                bcc.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                bcc.IsLock = false;
                bcc.IsFinish = false;
                if (bcc.HRM_TIMEKEEPER_TABLELIST_Lock())
                {
                    MessageBox.Show("Đã mở sổ thành công !");
                    txtBangChamCong_EditValueChanged(null, null);
                    Class.S_Log.Insert("Chấm công", "Mở sổ bảng Chấm công " + bccname);
                }
                else
                {
                    MessageBox.Show("Mở sổ thất bại !");
                }
            }
        }

        private void btnComplete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (txtBangChamCong.EditValue != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thực hiện tác vụ này không ? \n Tác vụ này được hiểu là bạn đã hoàn thành bảng chấm công của tháng này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                Class.ChamCong_ChamCongThang bcc = new Class.ChamCong_ChamCongThang();
                bcc.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                bcc.IsLock = _islock;
                bcc.IsFinish = true;
                _isFinish = true;
                if (bcc.HRM_TIMEKEEPER_TABLELIST_Lock())
                {
                    MessageBox.Show("Thực hiện thành công !");
                    txtBangChamCong_EditValueChanged(null, null);
                    Class.S_Log.Insert("Chấm công", "Hoàn thành bảng Chấm công " + bccname);
                }
                else
                {
                    MessageBox.Show("Thực hiện thất bại!");
                }
            }
        }

        private void btnMenuLoadCCNhanVien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thực hiện chức năng này không ? \n Chức năng được sử dụng khi bạn có cập nhật thay đổi từ bảng xếp ca của nhân viên này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                string _EmployeeCode = drow["EmployeeCode"].ToString();
                Class.ChamCong_ChamCongThang bcc = new Class.ChamCong_ChamCongThang();
                bcc.TimeKeeperTableListID = _TimeKeeperTableListID;
                bcc.EmployeeCode = _EmployeeCode;
                if (bcc.HRM_TIMEKEEPER_TABLE_UpdateByShift())
                {
                    MessageBox.Show("Thực hiện tải thành công !");
                    txtBangChamCong_EditValueChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Thực hiện tải thất bại!");
                }

            }

        }

        private void btnMenuLoadAllCCThang_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thực hiện chức năng này không ? \n Chức năng này sẽ thực hiện tải lại từ bảng xếp ca tháng. \n Đồng nghĩ với những thay đổi của bảng chấm công này sẽ trở lại từ đầu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            string _TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
            Class.ChamCong_ChamCongThang bcc = new Class.ChamCong_ChamCongThang();
            bcc.TimeKeeperTableListID = _TimeKeeperTableListID;
            if (bcc.HRM_TIMEKEEPER_TABLE_Delete())
            {
                txtBangChamCong_EditValueChanged(null, null);
                MessageBox.Show("Thực hiện tải thành công !");
            }
            else
            {
                MessageBox.Show("Thực hiện tải thất bại!");
            }
        }

        private void frmChamCong_ChamCongThang_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                gridItemDetail.SaveLayoutToXml(template_grid);
            }
            catch { }
        }

        private void btnMenuOffT7_Click(object sender, EventArgs e)
        {
            if (dtCC.Rows.Count > 0)
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
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns[i], "OFF");                           
                        }
                    }
                }
            }
        }

        private void btnMenuOffCN_Click(object sender, EventArgs e)
        {
            if (dtCC.Rows.Count > 0)
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
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns[i], "OFF");
                           
                        }
                    }
                }
            }
        }

        private void btnMenuOffT7VaCN_Click(object sender, EventArgs e)
        {
            if (dtCC.Rows.Count > 0)
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
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns[i], "OFF");
                        }
                        if (txt.IndexOf("Sun") > 0)
                        {
                            gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, gridItemDetail.Columns[i], "OFF");

                        }
                    }
                }
            }
        }

        private void treeListCoCauToChuc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (load_cctt == 0)
            {
                if (treeListCoCauToChuc.FocusedNode != null)
                {
                    if (txtBangChamCong.EditValue == null)
                        return;
                    xulyloaddsNhanVien(treeListCoCauToChuc.FocusedNode.GetDisplayText(1));
                }
            }
        }

        private void gridItemDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

                if (_year != 0 && _month != 0)
                {
                    if (dtCC.Rows.Count > 0)
                    {
                        if (e != null)
                        {
                            if (e.Column != colBH & e.Column != colPN && e.Column != colKL && e.Column != colPB && e.Column != colLD && e.Column != colNB && e.Column != colOFF && e.Column != colPB && e.Column != colTD && e.Column != colNC && e.Column != colHL && e.Column != colIsUpdate && e.Column != colPrintAllow)
                            {
                                dtCC = Class.ChamCong_ChamCongThang.TinhTongHopChamCong(dtCC, _year, _month, DayOfWeek.Sunday);

                                if (gridItemDetail.FocusedRowHandle > -1)
                                {
                                    gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colIsUpdate, "1");

                                }

                            }
                        }
                    }
                }            
            
        }

     

        private void cboSelectItem_EditValueChanged(object sender, EventArgs e)
        {
            gridItemDetail.PostEditor();
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
                    if (hi.Column.Name.StartsWith("colD"))
                    {
                        string txt = GetCellHintTextDetail(view, hi.RowHandle, hi.Column);
                        if (txt != "")
                        {
                            info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), txt);
                        }
                        return;
                    }                   
                }

            }
            finally
            {
                e.Info = info;
            }
        }
        private string GetCellHintTextDetail(GridView view, int rowHandle, DevExpress.XtraGrid.Columns.GridColumn column)
        {
            string ret="";
            int chk = 0;
            if (rowHandle > -1)
            {
                toolTip.ImageIndex = 12;
                for (int i = 0; i < dtCCComment.Rows.Count; i++)
                {
                    if (column.FieldName == dtCCComment.Rows[i]["Day"].ToString() && gridItemDetail.GetRowCellValue(rowHandle, colEmployeeCode).ToString() == dtCCComment.Rows[i]["EmployeeCode"].ToString())
                    {
                        ret = dtCCComment.Rows[i]["Description"].ToString();
                        chk = 1;
                       
                        #region mo phan quyen
                        for (int j = 0; j < contextMenuComment.Items.Count; j++)
                        {
                            if (contextMenuComment.Items[j].Tag != null)
                            {
                                string txt = contextMenuComment.Items[j].Tag.ToString();
                                if (txt.Length > 0)
                                {
                                    for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                                    {
                                        string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                        if (_Object_ID == txt)
                                        {
                                            contextMenuComment.Items[j].Enabled = true;
                                        }
                                    }

                                }
                            }

                        }
                        #endregion
                        btnThemGhiChu.Enabled = false;
                       // btnCapNhatGhiChu.Enabled = true;

                       // btnXoaGhiChu.Enabled = true;
                        break;
                    }
                }
            }
            if (chk == 0)
            {
                toolTip.ImageIndex = -1;
                ret = view.GetRowCellDisplayText(rowHandle, column);
                if(ret=="TD")
                    return "Trực đêm";
                if (ret == "LD")
                    return "Làm đêm";
                for (int i = 0; i < dtSYMBOL.Rows.Count; i++)
                {
                    if (ret == dtSYMBOL.Rows[i]["SymbolCode"].ToString())
                    {
                        if (dtSYMBOL.Rows[i]["SymbolName"].ToString() != "Không làm việc")
                        {
                            ret = dtSYMBOL.Rows[i]["SymbolName"].ToString();
                        }
                        break;
                    }
                }

                if (ret == "0")
                {
                    ret = "Không chấm công";
                }

               // btnThemGhiChu.Enabled = true ;
               
                 #region mo phan quyen
                        for (int j = 0; j < contextMenuComment.Items.Count; j++)
                        {
                            if (contextMenuComment.Items[j].Tag != null)
                            {
                                string txt = contextMenuComment.Items[j].Tag.ToString();
                                if (txt.Length > 0)
                                {
                                    for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                                    {
                                        string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                        if (_Object_ID == txt)
                                        {
                                            contextMenuComment.Items[j].Enabled = true;
                                        }
                                    }

                                }
                            }

                        }
                        #endregion
                        btnCapNhatGhiChu.Enabled = false;
                        btnXoaGhiChu.Enabled = false;
            }
            return ret;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtBangChamCong.EditValue != null)
            {
                txtBangChamCong_EditValueChanged(null, null);
            }
        }

        int _Updateday = 0;
        private void btnLoadChiTietCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải tổng hợp chấm công ! ");
            if (dtCTCC.Rows.Count > 0)
            {
                // chi tiet cham cong da tai roi
               // Color_SetTo_Gird(dtCTCC);
                
                _Updateday = UpdateDay(dtCTCC);
                UpToBCC_NotChangeSave(dtCTCC);
            }
            else
            {
                // bat dau tai chi tiet cham cong và áp màu cho bảng chấm công tháng
                if (txtBangChamCong.EditValue != null)
                {
                    Class.ChamCong_TongHopChiTiet thct = new Class.ChamCong_TongHopChiTiet();
                    dtCTCC = thct.HRM_TIMEKEEPER_SYNTHESIS_GetList(txtBangChamCong.EditValue.ToString());
                    _Updateday = UpdateDay(dtCTCC);
                    UpToBCC_NotChangeSave(dtCTCC);
                }
            }
           
            Waiting.CloseWaitForm();
        }
        


        private void UpToBCC_NotChangeSave(DataTable dt)        
        {
            if (dtCC.Rows.Count > 0)
            {
                int _DayNumber = DateTime.DaysInMonth(_year, _month);

                for (int i = 0; i < dtCC.Rows.Count; i++)
                {
                   // string EmployeeCode = dtCC.Rows[i]["EmployeeCode"].ToString();
                    if (dtCC.Rows[i]["Worked"] != DBNull.Value)
                    {
                        if ((bool)dtCC.Rows[i]["Worked"] == false)
                        {
                            for (int j = 0; j < dtCTCC.Rows.Count; j++)
                            {
                                if (dtCC.Rows[i]["EmployeeCode"].ToString() == dtCTCC.Rows[j]["EmployeeCode"].ToString())
                                {
                                    for (int k = 1; k <= _DayNumber; k++)
                                    {
                                        //if ((dtCC.Columns[k].ColumnName.Length < 4) & dtCC.Columns[k].ColumnName.StartsWith("D"))
                                       // {
                                          //  dtCC.Rows[i][dtCC.Columns[k].ColumnName] = dtCTCC.Rows[j][dtCC.Columns[k].ColumnName].ToString();
                                        if (dtCC.Rows[i]["D" + k].ToString() != "Off" && dtCC.Rows[i]["D" + k].ToString() != "HL" && dtCC.Rows[i]["D" + k].ToString() != "PN" && dtCC.Rows[i]["D" + k].ToString() != "NB" && dtCC.Rows[i]["D" + k].ToString() != "PB")
                                        {
                                            dtCC.Rows[i]["D" + k] = dtCTCC.Rows[j]["D" + k].ToString();
                                        }
                                      //  }
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // nguoc lai cap nhat theo ngay
                            if (dtCC.Rows[i]["UpdateDay"] != DBNull.Value)
                            {
                                for (int j = 0; j < dtCTCC.Rows.Count; j++)
                                {
                                    if (dtCC.Rows[i]["EmployeeCode"].ToString() == dtCTCC.Rows[j]["EmployeeCode"].ToString())
                                    {
                                        int _UpdateDay =int.Parse(dtCC.Rows[i]["UpdateDay"].ToString());
                                        if (_UpdateDay != 0) // neu ngay cap nhat nay khac 0 thi moi cap nhat. tuc là khi đã chấm xong bảng thì ko thực hiện chạy lại nữa
                                        {
                                            for (int k = _DayNumber; k > _UpdateDay; k--)
                                            {
                                                //if ((dtCC.Columns[k].ColumnName.Length < 4) & dtCC.Columns[k].ColumnName.StartsWith("D"))
                                                // {
                                                //dtCC.Rows[i][dtCC.Columns[k].ColumnName] = dtCTCC.Rows[j][dtCC.Columns[k].ColumnName].ToString();
                                                if (dtCC.Rows[i]["D" + k].ToString() != "Off" && dtCC.Rows[i]["D" + k].ToString() != "HL" && dtCC.Rows[i]["D" + k].ToString() != "PN" && dtCC.Rows[i]["D" + k].ToString() != "NB" && dtCC.Rows[i]["D" + k].ToString() != "PB")
                                                {
                                                    dtCC.Rows[i]["D" + k] = dtCTCC.Rows[j]["D" + k].ToString();
                                                }
                                                // }
                                            }

                                            // chay them vong lap  update lai tinh hinh cham cong du do thoi diem tai du lieu cham cong
                                            for (int kk = 1; kk <= _DayNumber; kk++)
                                            {
                                               if( dtCTCC.Rows[j]["D" + kk].ToString()=="1")
                                               {
                                                   string txt= dtCC.Rows[i]["D" + kk].ToString();
                                                   if(txt.Contains("S")){
                                                       dtCC.Rows[i]["D" + kk]="1";
                                                   }
                                               }
                                            }
                                            ///---------------------
                                        }
                                        break;
                                    }
                                }

                            }
                        }

                    }
                    else
                    {                      
                            for (int j = 0; j < dtCTCC.Rows.Count; j++)
                            {
                                if (dtCC.Rows[i]["EmployeeCode"].ToString() == dtCTCC.Rows[j]["EmployeeCode"].ToString())
                                {
                                    for (int k = 1; k <= _DayNumber; k++)
                                    {
                                        //if ((dtCC.Columns[k].ColumnName.Length < 4) & dtCC.Columns[k].ColumnName.StartsWith("D"))
                                        // {
                                        //  dtCC.Rows[i][dtCC.Columns[k].ColumnName] = dtCTCC.Rows[j][dtCC.Columns[k].ColumnName].ToString();
                                        if (dtCC.Rows[i]["D" + k].ToString() != "Off" && dtCC.Rows[i]["D" + k].ToString() != "HL" && dtCC.Rows[i]["D" + k].ToString() != "PN" && dtCC.Rows[i]["D" + k].ToString() != "NB" && dtCC.Rows[i]["D" + k].ToString() != "PB")
                                        {
                                            dtCC.Rows[i]["D" + k] = dtCTCC.Rows[j]["D" + k].ToString();
                                        }
                                        //  }
                                    }
                                    break;
                                }
                            }
                        }
                    
                }
            }
        }


        private int UpdateDay(DataTable dt)
        {
            int _Up = 0;
            for (int i = 31; i > 1; i--)
            {
                string _day = "0";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["D" + i].ToString() != _day && dt.Rows[j]["D" + i].ToString().Length>0)
                    {
                        _Up = i;                       
                    }
                }
            }
            return _Up;
        }

        private void btnReLoadTHCC_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải lại tổng hợp chấm công ! ");
            if (txtBangChamCong.EditValue != null)
            {
                Class.ChamCong_TongHopChiTiet thct = new Class.ChamCong_TongHopChiTiet();
                dtCTCC = thct.HRM_TIMEKEEPER_SYNTHESIS_GetList(txtBangChamCong.EditValue.ToString());

                if (dtCC.Rows.Count > 0)
                {

                    int _DayNumber = DateTime.DaysInMonth(_year, _month);
                    for (int i = 0; i < dtCC.Rows.Count; i++)
                    {
                        // string EmployeeCode = dtCC.Rows[i]["EmployeeCode"].ToString();                   
                        for (int j = 0; j < dtCTCC.Rows.Count; j++)
                        {
                            if (dtCC.Rows[i]["EmployeeCode"].ToString() == dtCTCC.Rows[j]["EmployeeCode"].ToString())
                            {
                                for (int k = 1; k <= _DayNumber; k++)
                                {
                                    //if ((dtCC.Columns[k].ColumnName.Length < 4) & dtCC.Columns[k].ColumnName.StartsWith("D"))
                                    // {
                                    //  dtCC.Rows[i][dtCC.Columns[k].ColumnName] = dtCTCC.Rows[j][dtCC.Columns[k].ColumnName].ToString();
                                    if (dtCC.Rows[i]["D" + k].ToString() != "Off" && dtCC.Rows[i]["D" + k].ToString() != "HL" && dtCC.Rows[i]["D" + k].ToString() != "PN" && dtCC.Rows[i]["D" + k].ToString() != "NB" && dtCC.Rows[i]["D" + k].ToString() != "PB")
                                    {
                                        dtCC.Rows[i]["D" + k] = dtCTCC.Rows[j]["D" + k].ToString();
                                    }
                                    //  }
                                }
                                break;
                            }
                        }

                    }
                }
            }
            Waiting.CloseWaitForm();
        }

        private void gridItemDetail_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            gridItemDetail.PostEditor();
        }

        private void gridItemDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridCell[] cells =gridItemDetail.GetSelectedCells();          
            
            if (dtCCComment.Rows.Count > 0)
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    try
                    {
                        if (e.Column.Name.StartsWith("colD"))
                        {
                            string txtField = e.Column.FieldName;
                            string _code = gridItemDetail.GetRowCellValue(e.RowHandle, colEmployeeCode).ToString();
                            for (int i = 0; i < dtCCComment.Rows.Count; i++)
                            {
                                string Day = dtCCComment.Rows[i]["Day"].ToString();

                                bool  _cancelCheck=false;

                                if (cells != null)
                                {
                                    for (int ie = 0; ie < cells.Length; ie++)
                                    {
                                        if ((cells[ie].Column.Name == e.Column.Name) && (cells[ie].RowHandle==e.RowHandle))
                                        {
                                            _cancelCheck=true;
                                            break;
                                        }

                                    }
                                }
                                if(_cancelCheck)
                                {
                                    // đang chon thì ko to mau backgroug
                                }
                                else if (txtField == Day && _code == dtCCComment.Rows[i]["EmployeeCode"].ToString())
                                {                                   
                                    e.Appearance.BackColor = Color.LightCyan;
                                    e.Appearance.BackColor2 = Color.YellowGreen;
                                    break;
                                }
                                else
                                {
                                    if (!e.Column.Caption.Contains("Sun"))
                                    {
                                        e.Appearance.BackColor = Color.Empty;
                                        e.Appearance.BackColor2 = Color.Empty;
                                    }
                                }

                            }
                        }
                    }
                    catch
                    {

                    }
                }

            }
        }

        private void contextMenuComment_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!gridItemDetail.FocusedColumn.Name.StartsWith("colD"))
            {
                e.Cancel = true;                
            }
        }

        private void btnThemGhiChu_Click(object sender, EventArgs e)
        {
            string TimeKeeperTableListID= txtBangChamCong.EditValue.ToString();
            string EmployeeCode = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle,colEmployeeCode).ToString();
            string Day=gridItemDetail.FocusedColumn.FieldName;
            frmChamCong_ChamCongThang_GhiChu frm = new frmChamCong_ChamCongThang_GhiChu(TimeKeeperTableListID, EmployeeCode, Day,true);
           //Cursor.Position.X, Cursor.Position.Y
          
            frm.ShowDialog();
            HRM_TIMEKEEPER_TABLE_COMMENT_GetList();
           
        }

        private void btnCapNhatGhiChu_Click(object sender, EventArgs e)
        {
            string TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
            string EmployeeCode = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colEmployeeCode).ToString();
            string Day = gridItemDetail.FocusedColumn.FieldName;
            frmChamCong_ChamCongThang_GhiChu frm = new frmChamCong_ChamCongThang_GhiChu(TimeKeeperTableListID, EmployeeCode, Day, false);
           
            frm.ShowDialog();
           
            HRM_TIMEKEEPER_TABLE_COMMENT_GetList();
            
        }

        private void btnXoaGhiChu_Click(object sender, EventArgs e)
        {
            Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
            cct.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
            cct.EmployeeCode = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colEmployeeCode).ToString();
            cct.Day = gridItemDetail.FocusedColumn.FieldName;
            if (cct.HRM_TIMEKEEPER_TABLE_COMMENT_Delete())
            {
                MessageBox.Show("Xóa ghi chú thành công !");
                HRM_TIMEKEEPER_TABLE_COMMENT_GetList();
            }
            else
            {
                MessageBox.Show("Không thể xóa ghi chú !");
            }

        }

        private void gridItemDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridItemDetail.FocusedRowHandle > -1)
            {
                if (gridItemDetail.FocusedColumn.Name.StartsWith("colD"))
                {  
                    if (e.Control && e.KeyCode == Keys.C)
                    {
                        Clipboard.SetText(gridItemDetail.GetFocusedDisplayText());
                        // MessageBox.Show(" " + gridItemDetail.GetFocusedDisplayText());
                    }

                    if (btnComplete.Enabled)
                    {
                        if (btnCloseBook.Enabled)
                        {
                            if (e.Control && e.KeyCode == Keys.V)
                            {
                                if (Clipboard.GetText() != "")
                                {
                                    GridCell[] cells = gridItemDetail.GetSelectedCells();
                                    if (cells != null)
                                    {

                                        for (int i = 0; i < cells.Length; i++)
                                        {
                                            gridItemDetail.SetRowCellValue(cells[i].RowHandle, cells[i].Column, Clipboard.GetText());
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

       
       
      
       
    }
}