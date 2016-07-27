using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace HRM.Forms
{
    public partial class frmDanhSachNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhanVien()
        {
            InitializeComponent();
            loaddsCocautochuc();                    

        }
        public  BindingSource bind = new BindingSource();
        string template_grid_all = Application.StartupPath + @"\Templates\Templates_DSNS_All.xml";
        string template_grid_Layout = Application.StartupPath + @"\Templates\Templates_DSNS_Layout.xml";
        string template_grid_Basic = Application.StartupPath + @"\Templates\Templates_DSNS_Basic.xml";
        static string Istemplate = "0";
        private void frmDanhSachNhanVien_Load(object sender, EventArgs e)
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
            for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
            {
                if (contextMenuStrip1.Items[i].Tag != null)
                {
                    string txt = contextMenuStrip1.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        contextMenuStrip1.Items[i].Enabled = false;
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

            for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
            {
                if (contextMenuStrip1.Items[i].Tag != null)
                {
                    string txt = contextMenuStrip1.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                        {
                            string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                            if (_Object_ID == txt)
                            {
                                contextMenuStrip1.Items[i].Enabled = true;
                            }
                        }
                        
                    }
                }

            }

            #endregion

            bind.DataSource = dtnv;
            gridItem.DataSource = bind; 
           // EnableControl();
            // load loai nhan vien da luu trong bo nho
              Class.RegistryWriter rg = new Class.RegistryWriter();
              Istemplate = rg.valuekey("Istemplate");
              if (Istemplate == "0")
              {
                  if (File.Exists(template_grid_all))
                  {                      
                      gridItemDetail.RestoreLayoutFromXml(template_grid_all);
                                        }
                  gridItem.MainView = gridItemDetail;
              }
              if (Istemplate == "1")
              {
                  if (File.Exists(template_grid_Layout))
                  {
                      layoutItemDetail.RestoreLayoutFromXml(template_grid_Layout);                    
                  }
                  gridItem.MainView = layoutItemDetail;
              }
              if (Istemplate == "2")
              {
                  if (File.Exists(template_grid_Basic))
                  {
                      gridItemBasic.RestoreLayoutFromXml(template_grid_Basic);                     
                  }
                  gridItem.MainView = gridItemBasic;
              }

              try
              {
                  if (rg.valuekey("cboLoadNV") != "Blue" && rg.valuekey("cboLoadNV") != "[Tất cả]")
                  {
                      loadbd = 1;
                      cboTrangThai.EditValue = rg.valuekey("cboLoadNV");
                      loadbd = 0;
                  }
                  else
                  {
                      loaddsNhanVien();   
                  }
              }
              catch
              {

              }

            //  this.Activate();
        }
        int loadbd = 0;
        int load_cctt = 0;

        public void loaddsCocautochuc()
        {
            load_cctt = 1;
            treeListCoCauToChuc.Nodes.Clear();            
            int indexid = 1;
            int indexid2 = 0;
           
            Class.CongTy cty = new Class.CongTy();
            DataTable dtCty = cty.LoadThongTinCty();
            DataTable dtCN;
            DataTable dtPBofCN;
            DataTable dtGroupByPB;
            for (int i = 0; i < dtCty.Rows.Count; i++)
            {               
                // add root tree list Cty
                this.treeListCoCauToChuc.AppendNode(new object[] { dtCty.Rows[i]["CompanyName"].ToString(),"0" }, -1, 0, 0, 0);
                Class.PhongBan pb = new Class.PhongBan();
                 dtCN = pb.LoadDanhSachChiNhanh();
                for (int ii = 0; ii < dtCN.Rows.Count; ii++)
                {
                    indexid2++;
                    // add child treen chi nhanh
                    pb.BranchCode = dtCN.Rows[ii]["BranchCode"].ToString();
                    this.treeListCoCauToChuc.AppendNode(new object[] { dtCN.Rows[ii]["BranchName"].ToString() + " (" + dtCN.Rows[ii]["FactQuantity"].ToString() + "/" + dtCN.Rows[ii]["Quantity"].ToString() + ")", dtCN.Rows[ii]["BranchCode"].ToString() }, 0, 0, 0, 1);
                     dtPBofCN = pb.LoadDanhSachPhongBanThuocChiNhanh();
                    
                        for(int iii=0;iii<dtPBofCN.Rows.Count; iii++)
                        {
                            indexid2++;
                            // Add tree list Phong Ban
                            this.treeListCoCauToChuc.AppendNode(new object[] { dtPBofCN.Rows[iii]["DepartmentName"].ToString() + " (" + dtPBofCN.Rows[iii]["FactQuantity"].ToString() + "/" + dtPBofCN.Rows[iii]["Quantity"].ToString() + ")", dtPBofCN.Rows[iii]["DepartmentCode"].ToString() }, indexid, 0, 0, 2);
                            pb.DepartmentCode = dtPBofCN.Rows[iii]["DepartmentCode"].ToString();
                             dtGroupByPB = pb.LoadDanhSachNhomThuocPhongBan();
                            int t = indexid2;
                            for (int iiii = 0; iiii < dtGroupByPB.Rows.Count; iiii++)
                            {                               
                                // add nhom
                                this.treeListCoCauToChuc.AppendNode(new object[] { dtGroupByPB.Rows[iiii]["GroupName"].ToString() + " (" + dtGroupByPB.Rows[iiii]["FactQuantity"].ToString() + "/" + dtGroupByPB.Rows[iiii]["Quantity"].ToString() + ")", dtGroupByPB.Rows[iiii]["GroupCode"].ToString() }, t, 0, 0, 3);
                                indexid2++;
                           }
                          
                        }
                        indexid = indexid2+1;         
                }
            }
            this.treeListCoCauToChuc.ExpandAll();
            load_cctt = 0;
        }

        public void loaddsNhanVien()
        {
            Class.NhanVien nv = new Class.NhanVien();
            nv.Status = -1;
            nv.DayFirstMonth = DateTime.Now;
            nv.DayEndMonth = DateTime.Now;           
            if (Istemplate == "2")
            {
                dtnv = nv.LoadDanhSachNhanVien_Basic();
            }
            else
            {
                dtnv = nv.LoadDanhSachNhanVien();
            }
            bind.DataSource = dtnv;
            //gridItem.DataSource = bind;            
          //  gridItemDetail.ExpandAllGroups();
           // gridItemDetail.BestFitColumns();
        }


        private void xulyloaddsNhanVien(string Dl,int status)
        {
            if (Dl == "0") // load tat ca
            {
                if (loadbd == 0)
                {
                    Waiting.ShowWaitForm();
                    Waiting.SetWaitFormDescription("Đang tải danh sách nhân viên..");
                }
                Class.NhanVien nv = new Class.NhanVien();

                nv.Status = status;
                nv.DayFirstMonth = DateTime.Now;
                nv.DayEndMonth = DateTime.Now;
                this.gridItemDetail.SortInfo.Clear();
                this.gridItemDetail.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBranchName, DevExpress.Data.ColumnSortOrder.Ascending));
                if (Istemplate == "2")
                {
                    dtnv = nv.LoadDanhSachNhanVien_Basic();
                   // gridItem.MainView = gridItemBasic;
                }
                else
                {
                    dtnv = nv.LoadDanhSachNhanVien();
                }
                bind.DataSource = dtnv;
               // dtnv = nv.LoadDanhSachNhanVien();
                //gridItem.DataSource = dtnv;
                //gridItemDetail.ExpandAllGroups();

                //if (dtnv.Rows.Count > 0)
                //{
                //    DataView dv = new DataView();
                //    dv = dtnv.DefaultView;
                //    if (status == -1)
                //    {
                //        dv.RowFilter = "";
                //    }
                //    else
                //    {
                //        dv.RowFilter = "Status='" + status + "'";
                //    }
                //}
                if (loadbd == 0)                   
                Waiting.CloseWaitForm();
            }
            else if (Dl.IndexOf("CN") >-1)
            {
                //nv.BranchCode = Dl;
                //nv.Status = status;
                //nv.DayFirstMonth = DateTime.Now;
                //nv.DayEndMonth = DateTime.Now;
                //this.gridItemDetail.SortInfo.Clear();
                //this.gridItemDetail.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBranchName, DevExpress.Data.ColumnSortOrder.Ascending));
                //dtnv = nv.LoadDanhSachNhanVienTheoChiNhanh();
                //gridItem.DataSource = dtnv;              
               // gridItemDetail.ExpandAllGroups();
                if (dtnv.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtnv.DefaultView;
                    if (status == -1)
                    {
                        dv.RowFilter = "BranchCode='" + Dl + "'";

                    }
                    else
                    {                       
                        dv.RowFilter = "BranchCode='" + Dl + "' AND "+"Status='" + status + "'";
                    }                   
                }

            }
            else if (Dl.IndexOf("PB") > -1)
            {
                //nv.DepartmentCode = Dl;
                //nv.Status = status;
                //nv.DayFirstMonth = DateTime.Now;
                //nv.DayEndMonth = DateTime.Now;
                //this.gridItemDetail.SortInfo.Clear();
                //this.gridItemDetail.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentName, DevExpress.Data.ColumnSortOrder.Ascending));
                //dtnv = nv.LoadDanhSachNhanVienTheoPhong();
                //gridItem.DataSource = dtnv;
                //gridItemDetail.ExpandAllGroups();
                if (dtnv.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtnv.DefaultView;
                    if (status == -1)
                    {
                        dv.RowFilter = "DepartmentCode='" + Dl + "'";

                    }
                    else
                    {
                        dv.RowFilter = "DepartmentCode='" + Dl + "' AND " + "Status='" + status + "'";
                    }                   

                }
            }
            else
            { 
                //nv.GroupCode = Dl;
                //nv.Status = status;
                //nv.DayFirstMonth = DateTime.Now;
                //nv.DayEndMonth = DateTime.Now;
                //this.gridItemDetail.SortInfo.Clear();
                //this.gridItemDetail.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGroupName, DevExpress.Data.ColumnSortOrder.Ascending));
                //dtnv=nv.LoadDanhSachNhanVienTheoNhom();
                //gridItem.DataSource = dtnv;
                //gridItemDetail.ExpandAllGroups();
                if (dtnv.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dtnv.DefaultView;
                    if (status == -1)
                    {
                        dv.RowFilter = "GroupCode='" + Dl + "'";

                    }
                    else
                    {
                        dv.RowFilter = "GroupCode='" + Dl + "' AND " + "Status='" + status + "'";
                    }   
                }
                
            }

           // gridItemDetail.ExpandAllGroups();
            bind.DataSource = dtnv;
        }

        DataTable dtnv = new DataTable();


        private void EnableControl()
        {
            if (gridItem.MainView == gridItemDetail)
            {
                if (gridItemDetail.RowCount < 1)
                {
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    btnExport.Enabled = false;
                    btnPrint.Enabled = false;

                }
                else
                {
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    btnExport.Enabled = true;
                    btnPrint.Enabled = true;

                }
            }
            else
            {
                if (layoutItemDetail.RowCount < 1)
                {
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    btnExport.Enabled = false;
                    btnPrint.Enabled = false;

                }
                else
                {
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    btnExport.Enabled = true;
                    btnPrint.Enabled = true;

                }
            }

        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         //   Guid _gui = new Guid();
           //  MessageBox.Show(Guid.NewGuid().ToString());
       this.Close();
            //if (gridItem.MainView.Equals(gridItemDetail))
            //{
            //    gridItem.MainView = cardView;
            //    gridItem.ForceInitialize();
            //}
            //else
            //{
            //    gridItem.MainView = gridItemDetail;
            //    gridItem.ForceInitialize();
            //}
        }

        private void cboTrangThai_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTrangThai.EditValue == null)
            {
                cboTrangThai.EditValue = "[Tất cả]";
            }
          switch (cboTrangThai.EditValue.ToString())
          {
              case "[Tất cả]" :
            //  this.colTrangThai.ClearFilter();     
                 xulyloaddsNhanVien(treeListCoCauToChuc.FocusedNode.GetDisplayText(1), -1);  
              break;
              case "[Đang thử việc]":
              xulyloaddsNhanVien(treeListCoCauToChuc.FocusedNode.GetDisplayText(1), 0);
              break;
              case "[Đang làm việc]" :
              xulyloaddsNhanVien(treeListCoCauToChuc.FocusedNode.GetDisplayText(1), 1);                   
              break;
              case "[Đang ngưng việc]" :
              xulyloaddsNhanVien(treeListCoCauToChuc.FocusedNode.GetDisplayText(1), 2);  
              break;
            case "[Đã nghỉ việc]" :
                 //   gridItemDetail.ActiveFilterString="[Status]=3";                 
              xulyloaddsNhanVien(treeListCoCauToChuc.FocusedNode.GetDisplayText(1), 3);  
              break;
          }
           // MessageBox.Show(cboTrangThai.EditValue.ToString());

         // EnableControl();
        }

        private void btnAddPB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnAddPB.Enabled)
                return;

            frmDanhSachPhongBan_Update frm = new frmDanhSachPhongBan_Update(true, "Thêm Phòng ban", "PB", null,"frmDanhSachNhanVien");
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnPrint.Enabled)
                return;
            // gridItemDetail.OptionsPrint.size
           // gridItem.ShowRibbonPrintPreview(
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            link.Component = gridItem;

            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A3;
            link.ShowPreview();
        }
       
        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnExport.Enabled)
                return;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xlsx";
            saveFile.Title = "Exprot to Excel File";
            saveFile.ShowDialog();         

            if(saveFile.FileName!="")
            gridItem.ExportToXlsx(saveFile.FileName);
        }

        private void btnAddGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnAddGroup.Enabled)
                return;
            frmDanhSachNhom_Update frm = new frmDanhSachNhom_Update(true, "Thêm Tổ, Nhóm", "TN", null, "frmDanhSachNhanVien");
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnEdit.Enabled)
                return;
            
            if (gridItem.MainView == gridItemDetail)
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    _focusGridItem = SelectedRow; // lay gia tri de dua de dong hien tai

                    Waiting.ShowWaitForm();
                    Waiting.SetWaitFormDescription("Đang tải thông tin nhân viên..");
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _name = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    Class.App._manv = _value;
                    Class.App._hotennv = _name; 
                    frmCapNhatNhanVien frm = new frmCapNhatNhanVien(false, "Cập nhật nhân viên: " + _name + "(" + _value + ")", "NV", _value, "frmDanhSachNhanVien");
                    frm.Owner = this;
                    Waiting.CloseWaitForm();
                    frm.ShowDialog();
                    this.Activate();
                }
            }
            else if (gridItem.MainView == layoutItemDetail)
            {
                int SelectedRow = layoutItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    _focusGridItem = SelectedRow; // lay gia tri de dua de dong hien tai

                    Waiting.ShowWaitForm();
                    Waiting.SetWaitFormDescription("Đang tải thông tin nhân viên..");
                    DataRow drow = layoutItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _name = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    Class.App._manv = _value;
                    Class.App._hotennv = _name; 
                    frmCapNhatNhanVien frm = new frmCapNhatNhanVien(false, "Cập nhật nhân viên: " + _name + "(" + _value + ")", "NV", _value, "frmDanhSachNhanVien");
                    frm.Owner = this;
                    Waiting.CloseWaitForm();
                    frm.ShowDialog();
                    this.Activate();
                }
            }
            else
            {
                int SelectedRow = gridItemBasic.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    _focusGridItem = SelectedRow; // lay gia tri de dua de dong hien tai

                    Waiting.ShowWaitForm();
                    Waiting.SetWaitFormDescription("Đang tải thông tin nhân viên..");
                    DataRow drow = gridItemBasic.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _name = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    Class.App._manv = _value;
                    Class.App._hotennv = _name; 
                    frmCapNhatNhanVien frm = new frmCapNhatNhanVien(false, "Cập nhật nhân viên: " + _name + "(" + _value + ")", "NV", _value, "frmDanhSachNhanVien");
                    frm.Owner = this;
                    Waiting.CloseWaitForm();
                    frm.ShowDialog();
                    this.Activate();
                }

            }
        }

        private void gridItemDetail_DoubleClick(object sender, EventArgs e)
        {
            if(btnEdit.Enabled==true)
            btnEdit_ItemClick(null, null);
        }

        private void btnAddNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnAddNV.Enabled)
                return;

            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải khởi tạo nhân viên mới..");
            frmCapNhatNhanVien frm = new frmCapNhatNhanVien(true, "Thêm nhân viên ", null, null, "frmDanhSachNhanVien");
            frm.Owner = this;
            Waiting.CloseWaitForm();
            frm.ShowDialog();
            this.Activate();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnDel.Enabled)
                return;

            if (gridItem.MainView == gridItemDetail)
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _fulname = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    string _contractcode = drow["ContractCode"].ToString();
                    string _contractcode1 = drow["ContractCode1"].ToString();
                    string _contractcode2 = drow["ContractCode2"].ToString();
                    string _contractcode3 = drow["ContractCode3"].ToString();

                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá hay không ?" +
                               " \n Lưu ý: Tất cả thông tin về " + _fulname + " sẽ bị xóa khỏi cơ sở dữ liệu !", "Cảnh báo: Xóa nhân viên - " + _fulname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    Class.NhanVien nv = new Class.NhanVien();
                    nv.EmployeeCode = _value;
                    nv.ContractCode = _contractcode;
                    nv.ContractCode1 = _contractcode1;
                    nv.ContractCode2 = _contractcode2;
                    nv.ContractCode3 = _contractcode3;
                    nv.FullName = _fulname;
                    if (nv.Delete())
                    {
                        Class.App.DeleteSuccessfully();
                        loaddsCocautochuc();
                        loaddsNhanVien();
                    }
                    else
                    {
                        Class.App.DeleteNotSuccessfully();
                    }
                }
            }
            else
            {
                int SelectedRow = layoutItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = layoutItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _fulname = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    string _contractcode = drow["ContractCode"].ToString();
                    string _contractcode1 = drow["ContractCode1"].ToString();
                    string _contractcode2 = drow["ContractCode2"].ToString();
                    string _contractcode3 = drow["ContractCode3"].ToString();

                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá hay không ?" +
                               " \n Lưu ý: Tất cả thông tin về " + _fulname + " sẽ bị xóa khỏi cơ sở dữ liệu !", "Cảnh báo: Xóa nhân viên - " + _fulname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    Class.NhanVien nv = new Class.NhanVien();
                    nv.EmployeeCode = _value;
                    nv.ContractCode = _contractcode;
                    nv.ContractCode1 = _contractcode1;
                    nv.ContractCode2 = _contractcode2;
                    nv.ContractCode3 = _contractcode3;
                    nv.FullName = _fulname;
                    if (nv.Delete())
                    {
                        Class.App.DeleteSuccessfully();
                        loaddsCocautochuc();
                        loaddsNhanVien();
                    }
                    else
                    {
                        Class.App.DeleteNotSuccessfully();
                    }
                }

            }
        }

        private void btnAddCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnAddCN.Enabled)
                return;

            frmDanhSachChiNhanh_Update frm = new frmDanhSachChiNhanh_Update(true, "Thêm Chi nhánh", "CN", null, "frmDanhSachNhanVien");
            frm.Owner = this;
            frm.ShowDialog();
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
           // GridView view = (GridView)sender;
           // bool _sex;
            //Check whether the indicator cell belongs to a data row
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {               
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                {
                    e.Info.ImageIndex = -1;                   
                }
                //else
                //{
                //    _sex = (bool)gridItemDetail.GetRowCellValue(e.RowHandle, colSex);
                //    if (_sex)                        
                //       colImage.ImageIndex = 0;
                //    else
                //        colImage.ImageIndex = 1;
                //}
            }

        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnImport.Enabled)
                return;
           
            frmDanhSachNhanVien_Import frm = new frmDanhSachNhanVien_Import();
            frm.ShowDialog();
        }
        int indexSelect = 0;
        private void gridItemDetail_Click(object sender, EventArgs e)
        {
            _focusGridItem = gridItemDetail.FocusedRowHandle;
            if (gridItemDetail.FocusedColumn == colLastName || gridItemDetail.FocusedColumn == colImage)
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                   
                    if (indexSelect != SelectedRow)
                    {
                        DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                        string _value = drow["EmployeeCode"].ToString();
                        string _name = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                        DateTime date = DateTime.Parse(drow["Birthday"].ToString());
                        DateTime dateId = DateTime.Parse(drow["IDCardDate"].ToString());
                        string _birthday = date.Day + "-" + date.Month + "-" + date.Year;
                        string _cardday = dateId.Day + "-" + dateId.Month + "-" + dateId.Year;
                        string _birthPlace = drow["BirthPlace"].ToString();
                        if (drow["Photo"] != DBNull.Value)
                        {
                            Byte[] imgbyte = (byte[])drow["Photo"];
                            if (imgbyte.Length > 10)
                            {
                                MemoryStream stmPicData = new MemoryStream(imgbyte);
                                Image img = Image.FromStream(stmPicData);
                                alertControl.Show(this, "Mã: " + _value,
                                    "<b>Họ tên:</b>  " + _name + "\n" +
                                    "<b>Ngày sinh:</b>  " + _birthday + "\n" +
                                    //"<b>Làm việc tại: </b> " + drow["BranchName"].ToString() + "\n" +
                                 "<b>Phòng: </b> " + drow["DepartmentName"].ToString() + "\n" +
                                 "<b><color=red>Chức vụ:</color> </b> " + drow["Position"].ToString() + "\n"
                                , resizeImage(img, 60, 65));
                                indexSelect = SelectedRow;
                            }
                        }
                    }
                }
            }
        }
       
        public Image resizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);

            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }

        private void btnMenuThemPhongBan_Click(object sender, EventArgs e)
        {
            btnAddPB_ItemClick(null, null);
        }

        private void btnMenuThemToNhom_Click(object sender, EventArgs e)
        {
            btnAddGroup_ItemClick(null, null);
        }

        private void btnMenuThemNhanVien_Click(object sender, EventArgs e)
        {
            btnAddNV_ItemClick(null, null);
        }

       

        private void frmDanhSachNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Istemplate == "0")
            {
                gridItemDetail.SaveLayoutToXml(template_grid_all);               

            }
            if (Istemplate == "1")
            {
                layoutItemDetail.SaveLayoutToXml(template_grid_Layout);   

            }
            if (Istemplate == "2")
            {
                gridItemBasic.SaveLayoutToXml(template_grid_Basic);  

            }
            Class.RegistryWriter rg = new Class.RegistryWriter();
            if (cboTrangThai.EditValue != null)
            {              
                rg.WriteKey("cboLoadNV", cboTrangThai.EditValue.ToString());
            }
            rg.WriteKey("Istemplate", Istemplate);
            this.Dispose();
        }
        
        private void gridItemDetail_RowCountChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtnv.Rows.Count; i++)
            {
                int t;
                t = (i + 1) % 2;
                gridItemDetail.SetRowCellValue(i, colColor, t);
            }
        }

        private void btnDangKyMaChamCong_Click(object sender, EventArgs e)
        {
            if (gridItem.MainView == gridItemDetail)
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _fulname = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    string _enrollNumber = drow["EnrollNumber"].ToString();
                    frmDangKyMaChamCong frm = new frmDangKyMaChamCong(_value, _fulname, _enrollNumber);
                    frm.Owner = this;
                    frm.ShowDialog();
                }
            }
            else if (gridItem.MainView == layoutItemDetail)
            {
                int SelectedRow = layoutItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = layoutItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _fulname = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    string _enrollNumber = drow["EnrollNumber"].ToString();
                    frmDangKyMaChamCong frm = new frmDangKyMaChamCong(_value, _fulname, _enrollNumber);
                    frm.Owner = this;
                    frm.ShowDialog();
                }

            }
            else
            {
                int SelectedRow = gridItemBasic.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridItemBasic.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _fulname = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    string _enrollNumber = drow["EnrollNumber"].ToString();
                    frmDangKyMaChamCong frm = new frmDangKyMaChamCong(_value, _fulname, _enrollNumber);
                    frm.Owner = this;
                    frm.ShowDialog();
                }
            }
        }

        int _focusGridItem = 1;      

        private void gridItem_DataSourceChanged(object sender, EventArgs e)
        {
            //int countr = dtnv.Rows.Count;
            //if (countr > 99 && countr < 999)
            //{
            //    gridItemDetail.IndicatorWidth = 55;
            //}
            //else if (countr > 999 && countr < 9999)
            //{
            //    gridItemDetail.IndicatorWidth = 65;
            //}
            //else
            //{
            //    gridItemDetail.IndicatorWidth = 40;
            //}

            //// move toi dong dang Edit
            //if (gridItem.MainView == gridItemDetail)
            //{
            //    if (gridItemDetail.DataSource != null)
            //    {
            //        if (_focusGridItem < gridItemDetail.RowCount)
            //        {
            //            gridItemDetail.MoveBy(_focusGridItem);
            //        }
            //    }
            //}
            //if (gridItem.MainView == layoutItemDetail)
            //{
            //    if (layoutItemDetail.DataSource != null)
            //    {
            //        if (_focusGridItem < layoutItemDetail.RowCount)
            //        {
            //            layoutItemDetail.MoveBy(_focusGridItem);
            //        }
            //    }
            //}
            //if (gridItem.MainView == gridItemBasic)
            //{
            //    if (gridItemBasic.DataSource != null)
            //    {
            //        if (_focusGridItem < gridItemBasic.RowCount)
            //        {
            //            gridItemBasic.MoveBy(_focusGridItem);
            //        }
            //    }
            //}

        }
             
        
        public void treeListCoCauToChuc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (load_cctt == 0)
            {
                if (treeListCoCauToChuc.FocusedNode != null)
                {
                    cboTrangThai_EditValueChanged(null, null);
                }
            }
        }

        private void btnDoiNhanhViTriLamViec_Click(object sender, EventArgs e)
        {
            if(gridItemDetail.SelectedRowsCount>0){
                    int[] selectedRows = gridItemDetail.GetSelectedRows();
                    if (selectedRows.Length == dtnv.Rows.Count)
                    {
                        MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    object[] result = new object[selectedRows.Length];
                    for (int i = 0; i < selectedRows.Length; i++)
                    {
                        int rowHandle = selectedRows[i];
                        if (!gridItemDetail.IsGroupRow(rowHandle))
                        {
                            result[i] = gridItemDetail.GetRowCellValue(rowHandle, colEmployeeCode);
                           // MessageBox.Show(result[i].ToString());
                        }                
                    }
                    frmDanhSachNhanVien_ThayDoiViTriLamViec frm = new frmDanhSachNhanVien_ThayDoiViTriLamViec(result,dtnv);
                    frm.Owner = this;
                    frm.ShowDialog();
                }
            if (layoutItemDetail.SelectedRowsCount > 0)
            {
                int[] selectedRows = layoutItemDetail.GetSelectedRows();
                if (selectedRows.Length == dtnv.Rows.Count)
                {
                    MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                object[] result = new object[selectedRows.Length];

                result[0] = layoutItemDetail.GetRowCellValue(layoutItemDetail.FocusedRowHandle, colEmployeeCode);

                frmDanhSachNhanVien_ThayDoiViTriLamViec frm = new frmDanhSachNhanVien_ThayDoiViTriLamViec(result, dtnv);
                frm.Owner = this;
                frm.ShowDialog();
            }
            if (gridItemBasic.SelectedRowsCount > 0)
            {
                int[] selectedRows = gridItemBasic.GetSelectedRows();
                if (selectedRows.Length == dtnv.Rows.Count)
                {
                    MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                object[] result = new object[selectedRows.Length];
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int rowHandle = selectedRows[i];
                    if (!gridItemBasic.IsGroupRow(rowHandle))
                    {
                        result[i] = gridItemBasic.GetRowCellValue(rowHandle, colEmployeeCode);
                        // MessageBox.Show(result[i].ToString());
                    }
                }
                frmDanhSachNhanVien_ThayDoiViTriLamViec frm = new frmDanhSachNhanVien_ThayDoiViTriLamViec(result, dtnv);
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void btnDoiNhanhChucVu_Click(object sender, EventArgs e)
        {
            if (gridItemDetail.SelectedRowsCount > 0)
            {
                int[] selectedRows = gridItemDetail.GetSelectedRows();
                if (selectedRows.Length == dtnv.Rows.Count)
                {
                    MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                object[] result = new object[selectedRows.Length];
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int rowHandle = selectedRows[i];
                    if (!gridItemDetail.IsGroupRow(rowHandle))
                    {
                        result[i] = gridItemDetail.GetRowCellValue(rowHandle, colEmployeeCode);                        
                    }
                }
                frmDanhSachNhanVien_ThayDoiChucVu frm = new frmDanhSachNhanVien_ThayDoiChucVu(result,dtnv);
                frm.Owner = this;
                frm.ShowDialog();
            }

            if (layoutItemDetail.SelectedRowsCount > 0)
            {
                int[] selectedRows = layoutItemDetail.GetSelectedRows();
                if (selectedRows.Length == dtnv.Rows.Count)
                {
                    MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                object[] result = new object[selectedRows.Length];

                result[0] = layoutItemDetail.GetRowCellValue(layoutItemDetail.FocusedRowHandle, colEmployeeCode);
                                  
                frmDanhSachNhanVien_ThayDoiChucVu frm = new frmDanhSachNhanVien_ThayDoiChucVu(result, dtnv);
                frm.Owner = this;
                frm.ShowDialog();
            }
            if (gridItemBasic.SelectedRowsCount > 0)
            {
                int[] selectedRows = gridItemBasic.GetSelectedRows();
                if (selectedRows.Length == dtnv.Rows.Count)
                {
                    MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                object[] result = new object[selectedRows.Length];
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int rowHandle = selectedRows[i];
                    if (!gridItemBasic.IsGroupRow(rowHandle))
                    {
                        result[i] = gridItemBasic.GetRowCellValue(rowHandle, colEmployeeCode);
                    }
                }
                frmDanhSachNhanVien_ThayDoiChucVu frm = new frmDanhSachNhanVien_ThayDoiChucVu(result, dtnv);
                frm.Owner = this;
                frm.ShowDialog();
            }

        }

        private void btnChuyenStyle_All_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải danh sách nhân viên..");
            gridItem.MainView = gridItemDetail;
            Istemplate = "0";           
            loaddsNhanVien();
            Waiting.CloseWaitForm();

        }

        private void btnChuyenStyle_Card_Click(object sender, EventArgs e)
        {
            gridItem.MainView = layoutItemDetail;
            Istemplate = "1";
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (gridItemDetail.FocusedRowHandle < 0)
                e.Cancel = true;

            if (Istemplate == "0")
            {
                btnChuyenStyle_All.Checked = true;
                btnChuyenStyle_Card.Checked = false;
                btnChuyenStyle_Basic.Checked = false;
            }
            if (Istemplate == "1")
            {
                btnChuyenStyle_All.Checked =false ;
                btnChuyenStyle_Card.Checked = true;
                btnChuyenStyle_Basic.Checked = false;
            }
            if (Istemplate == "2")
            {
                btnChuyenStyle_All.Checked = false;
                btnChuyenStyle_Card.Checked = false;
                btnChuyenStyle_Basic.Checked = true;
            }
            if (gridItem.MainView == gridItemDetail)
            {
                int[] selectedRows = gridItemDetail.GetSelectedRows();
                if (selectedRows.Length > 1)
                    btnThuyenChuyenNhanVien.Enabled = false;
                else
                {
                    for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
                    {
                        if (contextMenuStrip1.Items[i].Tag != null)
                        {
                            string txt = contextMenuStrip1.Items[i].Tag.ToString();
                            if (txt.Length > 0)
                            {
                                for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                                {
                                    string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                    if (_Object_ID == txt)
                                    {
                                        contextMenuStrip1.Items[i].Enabled = true;
                                    }
                                }

                            }
                        }

                    }
                }

                string EmployeeCode = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colEmployeeCode).ToString();
                Class.NhanVien_ThoiViec nvtv = new Class.NhanVien_ThoiViec();
                nvtv.EmployeeCode = EmployeeCode;
                DataTable dttv = nvtv.HRM_EMPLOYEE_DEACTIVE_GetByEmployeeCode();
                if (dttv.Rows.Count > 0)
                {
                    btnInQDTV.Enabled = true;
                    btnInTTTV.Enabled = true;
                }
                else
                {
                    btnInQDTV.Enabled = false;
                    btnInTTTV.Enabled = false;


                }

            }
            if (gridItem.MainView == gridItemBasic)
            {
                int[] selectedRows2 = gridItemBasic.GetSelectedRows();
                if (selectedRows2.Length > 1)
                    btnThuyenChuyenNhanVien.Enabled = false;
                else
                {
                    for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
                    {
                        if (contextMenuStrip1.Items[i].Tag != null)
                        {
                            string txt = contextMenuStrip1.Items[i].Tag.ToString();
                            if (txt.Length > 0)
                            {
                                for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                                {
                                    string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                                    if (_Object_ID == txt)
                                    {
                                        contextMenuStrip1.Items[i].Enabled = true;
                                    }
                                }

                            }
                        }

                    }
                }
            }
        }

        private void btnChuyenStyle_Basic_Click(object sender, EventArgs e)
        {
            gridItem.MainView = gridItemBasic;
            Istemplate = "2";           
        }

        private void gridItemBasic_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                {
                    e.Info.ImageIndex = -1;
                }               
            }
        }

        private void gridItemBasic_Click(object sender, EventArgs e)
        {
            _focusGridItem = gridItemBasic.FocusedRowHandle;
            if (gridItemBasic.FocusedColumn == colBasicLastName || gridItemBasic.FocusedColumn == colBasicSex)
            {
                int SelectedRow = gridItemBasic.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    if (indexSelect != SelectedRow)
                    {
                        DataRow drow = gridItemBasic.GetDataRow(SelectedRow);
                        string _value = drow["EmployeeCode"].ToString();
                        string _name = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                        DateTime date = DateTime.Parse(drow["Birthday"].ToString());
                        DateTime dateId = DateTime.Parse(drow["IDCardDate"].ToString());
                        string _birthday = date.Day + "-" + date.Month + "-" + date.Year;
                        string _cardday = dateId.Day + "-" + dateId.Month + "-" + dateId.Year;
                        string _birthPlace = drow["BirthPlace"].ToString();
                        if (drow["Photo"] != DBNull.Value)
                        {
                            Byte[] imgbyte = (byte[])drow["Photo"];
                            if (imgbyte.Length > 10)
                            {
                                MemoryStream stmPicData = new MemoryStream(imgbyte);
                                Image img = Image.FromStream(stmPicData);
                                alertControl.Show(this, "Mã: " + _value,
                                    "<b>Họ tên:</b>  " + _name + "\n" +
                                    "<b>Ngày sinh:</b>  " + _birthday + "\n" +
                                    //"<b>Làm việc tại: </b> " + drow["BranchName"].ToString() + "\n" +
                                 "<b>Phòng: </b> " + drow["DepartmentName"].ToString() + "\n" +
                                 "<b><color=red>Chức vụ:</color> </b> " + drow["Position"].ToString() + "\n"
                                , resizeImage(img, 60, 65));
                                indexSelect = SelectedRow;
                            }
                        }
                    }
                }
            }
        }

        private void gridItemBasic_DoubleClick(object sender, EventArgs e)
        {
            if (btnEdit.Enabled == true)
                btnEdit_ItemClick(null, null);
        }

        private void layoutItemDetail_Click(object sender, EventArgs e)
        {
           // this.gridItem.ContextMenuStrip = this.contextMenuStrip1;
            _focusGridItem = layoutItemDetail.FocusedRowHandle;
        }

        private void btnThuyenChuyenNhanVien_Click(object sender, EventArgs e)
        {
            if (gridItemDetail.SelectedRowsCount > 0)
            {
                int[] selectedRows = gridItemDetail.GetSelectedRows();
                if (selectedRows.Length == dtnv.Rows.Count)
                {
                    MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                object[] result = new object[selectedRows.Length];
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int rowHandle = selectedRows[i];
                    if (!gridItemDetail.IsGroupRow(rowHandle))
                    {
                        result[i] = gridItemDetail.GetRowCellValue(rowHandle, colEmployeeCode);
                        // MessageBox.Show(result[i].ToString());
                    }
                }
                string _name = "";
                if(result.Length==1)
                    _name = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colFirstName).ToString() + " " + gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colLastName).ToString();

                frmQuaTrinhLamViec_ChucVu_Update frm = new frmQuaTrinhLamViec_ChucVu_Update("Fast", result, dtnv, _name);
                frm.Owner = this;
                frm.ShowDialog();
            }
            if (layoutItemDetail.SelectedRowsCount > 0)
            {
                int[] selectedRows = layoutItemDetail.GetSelectedRows();
                if (selectedRows.Length == dtnv.Rows.Count)
                {
                    MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                object[] result = new object[selectedRows.Length];
                string _name = layoutItemDetail.GetRowCellValue(layoutItemDetail.FocusedRowHandle, colFirstName).ToString() + " " + layoutItemDetail.GetRowCellValue(layoutItemDetail.FocusedRowHandle, colLastName).ToString();
                result[0] = layoutItemDetail.GetRowCellValue(layoutItemDetail.FocusedRowHandle, colEmployeeCode);

                frmQuaTrinhLamViec_ChucVu_Update frm = new frmQuaTrinhLamViec_ChucVu_Update("Fast", result, dtnv, _name);
                frm.Owner = this;
                frm.ShowDialog();
            }
            if (gridItemBasic.SelectedRowsCount > 0)
            {
                int[] selectedRows = gridItemBasic.GetSelectedRows();
                if (selectedRows.Length == dtnv.Rows.Count)
                {
                    MessageBox.Show("Chức năng này không áp dụng cho toàn bộ nhân viên công ty, \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                object[] result = new object[selectedRows.Length];
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int rowHandle = selectedRows[i];
                    if (!gridItemBasic.IsGroupRow(rowHandle))
                    {
                        result[i] = gridItemBasic.GetRowCellValue(rowHandle, colEmployeeCode);                       
                    }
                }
                string _name = "";
                if (result.Length == 1)
                    _name = gridItemBasic.GetRowCellValue(gridItemBasic.FocusedRowHandle, colFirstName).ToString() + " " + gridItemBasic.GetRowCellValue(gridItemBasic.FocusedRowHandle, colLastName).ToString();
                frmQuaTrinhLamViec_ChucVu_Update frm = new frmQuaTrinhLamViec_ChucVu_Update("Fast", result, dtnv, _name);
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

      

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnChuyenStyle_All_Click(null, null);
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            btnChuyenStyle_Card_Click(null, null);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnChuyenStyle_Basic_Click(null, null);
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            btnPrint_ItemClick(null, null);
        }

        private void btnInQDTV_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải trang in quyết định thôi việc..");
            Class.NhanVien_ThoiViec nvtv = new Class.NhanVien_ThoiViec();
            nvtv.EmployeeCode = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colEmployeeCode).ToString();
            DataTable dt = nvtv.HRM_EMPLOYEE_DEACTIVE_GetPrint();
            if (dt.Rows.Count > 0)
            {
                string _boPhan="";
                string _sex = "";
                if (dt.Rows[0]["GroupName"].ToString().Trim().Length < 1)
                {
                    _boPhan = dt.Rows[0]["DepartmentName"].ToString();
                }
                else
                {
                    _boPhan = dt.Rows[0]["GroupName"].ToString();
                }
                if ((bool)dt.Rows[0]["Sex"])
                {
                    _sex = "Ông ";
                }
                else
                {
                    _sex = "Bà ";
                }

                string SoHD = "";
                string Ngayky = "";
                String SoBaoHiem = "";
                Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                hd.EmployeeCode = nvtv.EmployeeCode;
                DataTable dthd = hd.HRM_CONTRACT_GetCurrentListByEmployee();
                if (dthd.Rows.Count > 0)
                {
                    SoHD = dthd.Rows[0]["ContractCode"].ToString();
                    SoHD = SoHD.Replace("D", "Đ");
                    SoHD = SoHD.Replace("Lan", "Lần");
                    Ngayky = ((DateTime)dthd.Rows[0]["SignDate"]).ToString("dd/MM/yyyy");
                }
                SoBaoHiem = dt.Rows[0]["InsuranceCode"].ToString();

                Reports.ReportQuyetDinhThoiViec rp = new Reports.ReportQuyetDinhThoiViec(_boPhan, _sex, _sex + dt.Rows[0]["FullName"].ToString(), "Căn cứ đơn xin thôi việc của " +_sex+ dt.Rows[0]["FullName"].ToString(),SoHD,Ngayky,SoBaoHiem);
                rp.DataSource = dt;
              // rp.ShowDesigner();
               rp.ShowPreview();

                Class.S_Log.Insert("Nhân viên", "Xem trang in Quyết định thôi viêc: "
                    + dt.Rows[0]["EmployeeCode"].ToString() + "-"
                    + dt.Rows[0]["FullName"].ToString());
            }
            Waiting.CloseWaitForm();
        }

        private void btnInTTTV_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải trang in quyết định thôi việc..");
            Class.NhanVien_ThoiViec nvtv = new Class.NhanVien_ThoiViec();
            nvtv.EmployeeCode = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colEmployeeCode).ToString();
            DataTable dt = nvtv.HRM_EMPLOYEE_DEACTIVE_GetPrint();
            if (dt.Rows.Count > 0)
            {
                string _boPhan = "";
                string _sex = "";
                if (dt.Rows[0]["GroupName"].ToString().Trim().Length < 1)
                {
                    _boPhan = dt.Rows[0]["DepartmentName"].ToString();
                }
                else
                {
                    _boPhan = dt.Rows[0]["GroupName"].ToString();
                }
                if ((bool)dt.Rows[0]["Sex"])
                {
                    _sex = "Ông ";
                }
                else
                {
                    _sex = "Bà ";
                }
                string SoHD = "";
                string Ngayky = "";
                String SoBaoHiem = "";
                Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                hd.EmployeeCode = nvtv.EmployeeCode;
                DataTable dthd = hd.HRM_CONTRACT_GetCurrentListByEmployee();
                if (dthd.Rows.Count > 0)
                {
                    SoHD = dthd.Rows[0]["ContractCode"].ToString();
                    SoHD = SoHD.Replace("D", "Đ");
                    SoHD = SoHD.Replace("Lan", "Lần");
                    Ngayky = ((DateTime)dthd.Rows[0]["SignDate"]).ToString("dd/MM/yyyy");
                }
                SoBaoHiem = dt.Rows[0]["InsuranceCode"].ToString();

                Reports.ReportThoaThuanThoiViec rp = new Reports.ReportThoaThuanThoiViec(_boPhan, _sex, _sex + dt.Rows[0]["FullName"].ToString(), "" + _sex + dt.Rows[0]["FullName"].ToString(),SoHD,Ngayky,SoBaoHiem);

                rp.DataSource = dt;
                // rp.ShowDesigner();
                rp.ShowPreview();

                Class.S_Log.Insert("Nhân viên", "Xem trang in Quyết định thôi viêc: "
                    + dt.Rows[0]["EmployeeCode"].ToString() + "-"
                    + dt.Rows[0]["FullName"].ToString());
            }
            Waiting.CloseWaitForm();
        }
    }
}