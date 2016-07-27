using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;

namespace HRM.Forms
{
    public partial class frmChamCong_TongHop : DevExpress.XtraEditors.XtraForm
    {
        public frmChamCong_TongHop()
        {
            InitializeComponent();
        }

        DataTable dtTHCC = new DataTable();
        DataTable dtShift = new DataTable();

        private void frmChamCong_TongHop_Load(object sender, EventArgs e)
        {
            HRM_TIMEKEEPER_TABLELIST_GetList();
            loaddsCocautochuc();

            Class.DanhMuc_CaLamViec ca = new Class.DanhMuc_CaLamViec();
            dtShift = ca.DIC_SHIFT_GetList();
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

            #endregion
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
                        }

                    }
                }

            }
            #endregion

        }

        private void HRM_TIMEKEEPER_TABLELIST_GetList()
        {
            Class.ChamCong_BangXepCa xc = new Class.ChamCong_BangXepCa();
            cboBangChamCong.DataSource = xc.HRM_TIMEKEEPER_TABLELIST_GetList();
            cboBangChamCong.ValueMember = "TimeKeeperTableListID";
            cboBangChamCong.DisplayMember = "TimeKeeperTableListName";
        }

        private void LoadTHCC(string Thang)
        {
            Class.ChamCong_TongHopChiTiet thct = new Class.ChamCong_TongHopChiTiet();
          dtTHCC= thct.HRM_TIMEKEEPER_SYNTHESIS_GetList(Thang);
           gridItem.DataSource = dtTHCC;
        }
        
        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (txtBangChamCong.EditValue != null)
            {
                Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
                bxc.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                DataTable dt = bxc.HRM_TIMEKEEPER_TABLELIST_GetByID();
                if (dt.Rows.Count > 0)
                {
                    HideColumOfGirdView((int)dt.Rows[0]["Month"], (int)dt.Rows[0]["Year"]);
                    Class.S_Log.Insert("Chấm công", "Xem Bảng tổng hợp chi tiết chấm công " + dt.Rows[0]["TimeKeeperTableListName"].ToString());

                }  
                
                LoadTHCC(txtBangChamCong.EditValue.ToString());
                gridItemDetail.BestFitColumns();

            }
            Waiting.CloseWaitForm();

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
           
            //Check whether the indicator cell belongs to a data row
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }

        }

        private void treeListCoCauToChuc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (load_cctt == 0)
            {
                if (treeListCoCauToChuc.FocusedNode != null)
                {
                    string Dl = treeListCoCauToChuc.FocusedNode.GetDisplayText(1);
                    if (Dl == "0") // load tat ca
                    {
                        if (dtTHCC.Rows.Count > 0)
                        {
                            DataView dv = new DataView();
                            dv = dtTHCC.DefaultView;
                            dv.RowFilter = "";
                        }
                    }
                    else if (Dl.IndexOf("CN") > -1)
                    {
                        if (dtTHCC.Rows.Count > 0)
                        {
                            DataView dv = new DataView();
                            dv = dtTHCC.DefaultView;
                            dv.RowFilter = "BranchCode='" + Dl + "'";
                        }
                    }
                    else if (Dl.IndexOf("PB") > -1)
                    {
                        if (dtTHCC.Rows.Count > 0)
                        {
                            DataView dv = new DataView();
                            dv = dtTHCC.DefaultView;
                            dv.RowFilter = "DepartmentCode='" + Dl + "'";
                        }
                    }
                    else
                    {
                        if (dtTHCC.Rows.Count > 0)
                        {
                            DataView dv = new DataView();
                            dv = dtTHCC.DefaultView;
                            dv.RowFilter = "GroupCode='" + Dl + "'";
                        }
                    }
                }
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            link.Component = gridItem;

            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A3;
            link.ShowPreview();
            //gridItem.ShowRibbonPrintPreview();
            
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtTHCC.Rows.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel File|*.xlsx";
                saveFile.Title = "Exprot to Excel File";
                saveFile.ShowDialog();

                if (saveFile.FileName != "")
                    gridItem.ExportToXlsx(saveFile.FileName);              
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

                    if (hi.Column.Name.StartsWith("colD"))
                    {
                        string txt = GetCellHintTextDetail(view, hi.RowHandle, hi.Column);
                        if (txt != "")
                        {
                            info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), txt);
                        }
                        return;
                    }

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
        private string GetCellHintTextDetail(GridView view, int rowHandle, DevExpress.XtraGrid.Columns.GridColumn column)
        {
            string ret = view.GetRowCellDisplayText(rowHandle, column);

            if (ret == "1")
                ret = "Làm đủ ngày";

            if (ret == "0")
                ret = "Không chấm công nguyên ngày";
            if (ret == "TD")
                return "Trực đêm";
            if (ret == "LD")
                return "Làm đêm";

            if(ret.StartsWith("KV"))
            {
                if (ret.Contains("S"))
                {
                    ret = ret.Replace("S", " Về Sớm  ")+ " phút";
                }
                ret = ret.Replace("KV", " Không chấm vào ");
            }
            if (ret.StartsWith("T"))
            {
                if (ret.Contains("KR"))
                {
                    ret = ret.Replace("KR", " phút, Không chấm ra ");
                }
                else
                {
                    ret = ret.Replace("KR", " phút, Về sớm  ") + " phút";
                }
                ret = ret.Replace("T", " Đi trễ ");
            }
            if (ret.StartsWith("S"))
            {
                ret = ret.Replace("S", "Về sớm ") + " phút";
            }
            if (ret.StartsWith("KR"))
            {
                ret = ret.Replace("KR", "Không chấm ra ");
            }
            ret = ret.Replace("-", "");

            return ret;
        }

        private void btnAcceptOne_Click(object sender, EventArgs e)
        {
            // lay thong tin thang cap nhat va kiem tra dang dong hay xong roi
            // kiểm tra sổ đã hoàn thành chưa
            Class.ChamCong_BangXepCa bxc = new Class.ChamCong_BangXepCa();
            bxc.TimeKeeperTableListID = txtBangChamCong.EditValue.ToString();
                DataTable dt = bxc.HRM_TIMEKEEPER_TABLELIST_GetByID();
            if (dt.Rows.Count > 0)
            {
                if ((bool)dt.Rows[0]["IsFinish"] == true)
                {
                    MessageBox.Show("Bảng chấm công tháng này đã xác nhận hoàn thành. Bạn không được phép cập nhật lại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if ((bool)dt.Rows[0]["IsLock"] == true)
                {
                    MessageBox.Show("Bảng chấm công tháng này đang ở trạng thái khóa. Bạn không được phép cập nhật lại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    int SelectedRow = gridItemDetail.FocusedRowHandle;
                    if (SelectedRow >= 0)
                    {
                        DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                        string D1 = drow["D1"].ToString();
                       
                    }
                }
                      
            }

        }

    }
}