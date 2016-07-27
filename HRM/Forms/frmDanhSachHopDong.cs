using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.XtraReports.UI;

namespace HRM.Forms
{
    public partial class frmDanhSachHopDong : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachHopDong()
        {
            InitializeComponent();
            loaddsCocautochuc();
        }
        string template_grid = Application.StartupPath + @"\Templates\Templates_DSHD.xml";
        private void frmDanhSachHopDong_Load(object sender, EventArgs e)
        {
            if (File.Exists(template_grid))
            {
                // gridItemDetail.SaveLayoutToXml(template_grid);
                gridItemDetail.RestoreLayoutFromXml(template_grid);
            }
            HRM_CONTRACT_GetList();
           // EnableControl();

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
                                if (txt == "QLHD_In")
                                {
                                    _inhd = true;
                                }
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

            this.Activate();
        }

        DataTable dthd = new DataTable();
        public void HRM_CONTRACT_GetList()
        {
            Class.NhanVien_HopDong hd= new Class.NhanVien_HopDong();
           dthd = hd.HRM_CONTRACT_GetList();
           gridItem.DataSource = dthd;
        }
        int load_cctt = 0;
        public void loaddsCocautochuc()
        {
            load_cctt = 1;
            // xu ly load ds nhan vien luon
            Class.NhanVien nv = new Class.NhanVien();          
            nv.DayFirstMonth = DateTime.Now;
            nv.DayEndMonth = DateTime.Now;
            DataTable dtnv = new DataTable();
            DataTable dtCN;
            DataTable dtPBofCN;
            DataTable dtGroupByPB;
            //
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
                 dtCN = pb.LoadDanhSachChiNhanh();
                for (int ii = 0; ii < dtCN.Rows.Count; ii++)
                {
                    indexid2++;
                    // add child treen chi nhanh
                    pb.BranchCode = dtCN.Rows[ii]["BranchCode"].ToString();
                    this.treeListCoCauToChuc.AppendNode(new object[] { dtCN.Rows[ii]["BranchName"].ToString() + " (" + dtCN.Rows[ii]["FactQuantity"].ToString() + "/" + dtCN.Rows[ii]["Quantity"].ToString() + ")", dtCN.Rows[ii]["BranchCode"].ToString() }, 0, 0, 0, 1);
                     dtPBofCN = pb.LoadDanhSachPhongBanThuocChiNhanh();

                    for (int iii = 0; iii < dtPBofCN.Rows.Count; iii++)
                    {
                        indexid2++;
                        // Add tree list Phong Ban
                        this.treeListCoCauToChuc.AppendNode(new object[] { dtPBofCN.Rows[iii]["DepartmentName"].ToString() + " (" + dtPBofCN.Rows[iii]["FactQuantity"].ToString() + "/" + dtPBofCN.Rows[iii]["Quantity"].ToString() + ")", dtPBofCN.Rows[iii]["DepartmentCode"].ToString() }, indexid, 0, 0, 2);
                       pb.DepartmentCode = dtPBofCN.Rows[iii]["DepartmentCode"].ToString();
                         dtGroupByPB = pb.LoadDanhSachNhomThuocPhongBan();
                        int t = indexid2;
                        // add nhan vien
                        #region Add_NhanVien to Trelist
                        nv.Status = -1;
                        nv.DepartmentCode = dtPBofCN.Rows[iii]["DepartmentCode"].ToString();
                        dtnv = nv.LoadDanhSachNhanVienTheoPhong_Ex();
                        for (int j = 0; j < dtnv.Rows.Count; j++)
                        {
                            int imageIndex = 4;
                            if ((bool)dtnv.Rows[j]["Sex"] == false) // xac dinh hinh cua nam/ nữ
                                imageIndex = 5;
                            this.treeListCoCauToChuc.AppendNode(new object[] { dtnv.Rows[j]["FirstName"].ToString() + " " + dtnv.Rows[j]["LastName"].ToString(), dtnv.Rows[j]["EmployeeCode"].ToString() }, t, 0, 0, imageIndex);
                            indexid2++;
                        }
                        #endregion
                        ///
                        for (int iiii = 0; iiii < dtGroupByPB.Rows.Count; iiii++)
                        {                           
                            // add nhom
                            this.treeListCoCauToChuc.AppendNode(new object[] { dtGroupByPB.Rows[iiii]["GroupName"].ToString() + " (" + dtGroupByPB.Rows[iiii]["FactQuantity"].ToString() + "/" + dtGroupByPB.Rows[iiii]["Quantity"].ToString() + ")", dtGroupByPB.Rows[iiii]["GroupCode"].ToString() }, t, 0, 0, 3);
                            indexid2++;                  
                            // add list nv to group
                            int tt = indexid2;
                            nv.Status = -1;
                            nv.GroupCode = dtGroupByPB.Rows[iiii]["GroupCode"].ToString();
                            dtnv = nv.LoadDanhSachNhanVienTheoNhom_Ex();
                            for (int j = 0; j < dtnv.Rows.Count; j++)
                            {
                                int imageIndex = 4;
                                if ((bool)dtnv.Rows[j]["Sex"] == false) // xac dinh hinh cua nam/ nữ
                                    imageIndex = 5;
                                this.treeListCoCauToChuc.AppendNode(new object[] { dtnv.Rows[j]["FirstName"].ToString() + " " + dtnv.Rows[j]["LastName"].ToString(), dtnv.Rows[j]["EmployeeCode"].ToString() }, tt, 0, 0, imageIndex);
                              indexid2++;
                            }
                              
                        }

                    }
                    indexid = indexid2 + 1;
                }
            }
            this.treeListCoCauToChuc.ExpandAll();
            load_cctt = 0;
        }

        private void xulyloaddsHopDong(string Dl, int status)
        {
            Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
            gridItem.DataSource = dthd;
            if (Dl == "0") // load tat ca
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải danh sách hợp đồng..");
                dthd = hd.HRM_CONTRACT_GetList();
                gridItem.DataSource = dthd;
                Waiting.CloseWaitForm();

                //if (dthd.Rows.Count > 0)
                //{
                //    DataView dv = new DataView();
                //    dv = dthd.DefaultView;                   
                //        dv.RowFilter = "";
                //}               
            }
            else if (Dl.IndexOf("CN") > -1)
            {
                //hd.BranchCode = Dl;
                //gridItem.DataSource = hd.HRM_CONTRACT_GetListByBranch();
                if (dthd.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dthd.DefaultView;
                    dv.RowFilter = "BranchCode='" + Dl + "'";
                }

            }
            else if (Dl.IndexOf("PB") > -1)
            {
                //hd.DepartmentCode = Dl;
                //gridItem.DataSource = hd.HRM_CONTRACT_GetListByDepartment();
                if (dthd.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dthd.DefaultView;
                    dv.RowFilter = "DepartmentCode='" + Dl + "'";
                }
              
            }
            else if (Dl.IndexOf("TN") > -1)
            {
                //hd.GroupCode = Dl;
                //gridItem.DataSource = hd.HRM_CONTRACT_GetListByGroup();
                if (dthd.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dthd.DefaultView;
                    dv.RowFilter = "GroupCode='" + Dl + "'";
                }              
            }
            else if (Dl.Equals("HDHT"))
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải danh sách hợp đồng..");
                gridItem.DataSource = hd.HRM_CONTRACT_GetCurrentList();
                Waiting.CloseWaitForm();
            }
            else if (Dl.Equals("30Ngay"))
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải danh sách hợp đồng..");
                gridItem.DataSource = hd.HRM_CONTRACT_GetListJustExpiration();
                Waiting.CloseWaitForm();

            }
            else if (Dl.Equals("HetHan"))
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải danh sách hợp đồng..");
                gridItem.DataSource = hd.HRM_CONTRACT_GetListExpiration();
                Waiting.CloseWaitForm();

            }
            else
            {
                hd.EmployeeCode = Dl;
                gridItem.DataSource = hd.HRM_CONTRACT_GetByEmployee();
            }
           
        }

         

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnEdit.Enabled)
                return;
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                _focusGridItem = SelectedRow; // lay gia tri de dua de dong hien tai

                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["ContractCode"].ToString();
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải thông tin hợp đồng..");
                frmDanhSachHopDong_Update frm = new frmDanhSachHopDong_Update(false, "Cập nhật Hợp Đồng Lao Động", "HĐ", _value, "frmDanhSachHopDong");
                frm.Owner = this;
                Waiting.CloseWaitForm();
                frm.ShowDialog();
            }
        }

        private void gridItemDetail_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
        }

        private void btnAddHD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang khởi tạo hợp đồng mới..");
            frmDanhSachHopDong_Update frm = new frmDanhSachHopDong_Update(true, "Thêm Hợp Đồng Lao Động", "HĐ", null, "frmDanhSachHopDong");
            frm.Owner = this;
            Waiting.CloseWaitForm();
            frm.ShowDialog();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["ContractCode"].ToString();
                string _manv = drow["EmployeeCode"].ToString();
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                hd.ContractCode = _value;
                hd.EmployeeCode = _manv;
                if (hd.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    HRM_CONTRACT_GetList();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            int SelectedRow = gridItemDetail.FocusedRowHandle;
           
            if (SelectedRow >= 0)
            {

                string _value = gridItemDetail.GetFocusedRowCellValue(colContractCode).ToString();
                Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                hd.ContractCode=_value;
                DataTable dt = hd.HRM_CONTRACT_GetPrintByCode();
                if (_value.IndexOf("HDTV") > 0)
                {
                   // Reports.reportHoDongThuViec rp = new Reports.reportHoDongThuViec();
                   // rp.DataSource = dt;
                   // rp.ShowDesigner();
                   // rp.ShowPreviewDialog();
                }else
                {
                    // kiem tra xem neu la HD HKtri ky thi dung report_DL
                    if (dt.Rows[0]["Signer"].ToString().ToLower() == "hồ kim trí")
                    {
                        Reports.reportHopDongLaoDong_DL rp = new Reports.reportHopDongLaoDong_DL(dt);
                        rp.DataSource = dt;
                        rp.ShowPreviewDialog();
                    }
                    else
                    {

                        Reports.reportHopDongLaoDong report = new Reports.reportHopDongLaoDong(dt);
                        report.DataSource = dt;
                        report.ShowPreviewDialog();
                       
                    }
                    Class.S_Log.Insert("Hợp đồng", "Xem trang In Hợp đồng lao động: " + _value);
                }
                
            }

        }

        private void btnCallPrintThuViec_Click(object sender, EventArgs e)
        {
             int SelectedRow = gridItemDetail.FocusedRowHandle;
             if (SelectedRow >= 0)
             {
                 Waiting.ShowWaitForm();

                 string _value = gridItemDetail.GetFocusedRowCellValue(colContractCode).ToString();
                 Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                 hd.ContractCode = _value;
                 DataTable dt = hd.HRM_CONTRACT_GetPrintByCode();
                 Waiting.CloseWaitForm();
                 decimal totalSalary = 0;
                 decimal totalTestSalary = 0;
               // kiem tra la HD dac biet hay ko
                 if (dt.Rows[0]["SecondAllowance"].ToString().Length > 0)
                 {
                     decimal _secondAllowance = decimal.Parse(dt.Rows[0]["SecondAllowance"].ToString());
                     decimal _testAllowance = 0;
                     decimal.TryParse(dt.Rows[0]["Allowance"].ToString(), out _testAllowance);
                     int _rate = int.Parse(dt.Rows[0]["Rate"].ToString());
                     decimal _testAllowance2 = (_testAllowance * _rate / 100);
                     decimal _basicSalaray = 0;
                     decimal _testSalaray = 0;
                     decimal _testAllowance_ = 0;
                     decimal.TryParse(dt.Rows[0]["BasicSalary"].ToString(), out _basicSalaray);
                     decimal.TryParse(dt.Rows[0]["TestSalary"].ToString(), out _testSalaray);
                     decimal.TryParse(dt.Rows[0]["SecondAllowance"].ToString(), out _testAllowance_);
                     totalSalary = _basicSalaray + _testAllowance;
                     totalTestSalary = _testSalaray + _testAllowance_;

                     if (_testAllowance2 == _secondAllowance)
                     {
                         // kiem tra xem neu la HD HKtri ky thi dung report_DL
                         if (dt.Rows[0]["Signer"].ToString().ToLower() == "hồ kim trí")
                         {
                             Reports.reportHopDongThuViec_DL rp = new Reports.reportHopDongThuViec_DL(dt, totalSalary, totalTestSalary);
                             rp.DataSource = dt;
                             rp.ShowPreviewDialog();
                         }
                         else
                         {
                             Reports.reportHopDongThuViec rp = new Reports.reportHopDongThuViec(dt, totalSalary, totalTestSalary);
                             rp.DataSource = dt;
                             rp.ShowPreviewDialog();
                             // rp.ShowDesigner();
                         }
                     }
                     else
                     {
                         if (dt.Rows[0]["Signer"].ToString().ToLower() == "hồ kim trí")
                         {
                             Reports.reportHopDongThuViec_DL rp = new Reports.reportHopDongThuViec_DL(dt, totalSalary, totalTestSalary);
                             rp.DataSource = dt;
                             rp.ShowPreviewDialog();
                         }
                         else
                         {
                             Reports.reportHopDongThuViec rp = new Reports.reportHopDongThuViec(dt, totalSalary, totalTestSalary);
                             rp.DataSource = dt;
                             rp.ShowPreviewDialog();
                             // rp.ShowDesigner();
                         }
                         //Reports.reportHopDongThuViec rp = new Reports.reportHopDongThuViec(dt, totalSalary, totalTestSalary);
                         //rp.DataSource = dt;
                         //rp.ShowPreviewDialog();
                         //Reports.reportHopDongThuViec_DB rp = new Reports.reportHopDongThuViec_DB(dt, totalSalary, totalTestSalary);
                         //rp.DataSource = dt;
                         //rp.ShowPreviewDialog();
                         ////  rp.ShowDesigner();
                     }
                 }
                 else
                 { // kiem tra xem neu la HD HKtri ky thi dung report_DL
                     if (dt.Rows[0]["Signer"].ToString().ToLower() == "hồ kim trí")
                     {
                         Reports.reportHopDongThuViec_DL rp = new Reports.reportHopDongThuViec_DL(dt, totalSalary, totalTestSalary);
                         rp.DataSource = dt;
                         rp.ShowPreviewDialog();
                     }
                     else
                     {

                         Reports.reportHopDongThuViec rp = new Reports.reportHopDongThuViec(dt, totalSalary, totalTestSalary);
                         rp.DataSource = dt;
                         rp.ShowPreviewDialog();
                         // rp.ShowDesigner();
                     }
                 }
                
                  // rp.ShowDesigner();
                // rp.ShowPreviewDialog();
                Class.S_Log.Insert("Hợp đồng", "Xem trang In Thỏa thuận làm việc: " + _value);
             }
        }

        private void btnCallPrintThuMoi_Click(object sender, EventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                Waiting.ShowWaitForm();

                string _value = gridItemDetail.GetFocusedRowCellValue(colContractCode).ToString();
                Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                hd.ContractCode = _value;
                DataTable dt = hd.HRM_CONTRACT_GetPrintByCode();
                Waiting.CloseWaitForm();
                decimal totalSalary = 0;
                decimal totalTestSalary = 0;
                // kiem tra la HD dac biet hay ko
                if (dt.Rows[0]["SecondAllowance"].ToString().Length > 0)
                {
                    decimal _secondAllowance = decimal.Parse(dt.Rows[0]["SecondAllowance"].ToString());
                    decimal _testAllowance = 0;
                    decimal.TryParse(dt.Rows[0]["Allowance"].ToString(), out _testAllowance);
                    int _rate = int.Parse(dt.Rows[0]["Rate"].ToString());
                    decimal _testAllowance2 = (_testAllowance * _rate / 100);
                    decimal _basicSalaray = 0;
                    decimal _testSalaray = 0;
                    decimal _testAllowance_ = 0;
                    decimal.TryParse(dt.Rows[0]["BasicSalary"].ToString(), out _basicSalaray);
                    decimal.TryParse(dt.Rows[0]["TestSalary"].ToString(), out _testSalaray);
                    decimal.TryParse(dt.Rows[0]["SecondAllowance"].ToString(), out _testAllowance_);
                    totalSalary = _basicSalaray + _testAllowance;
                    totalTestSalary = _testSalaray + _testAllowance_;
                    if (_testAllowance2 == _secondAllowance)
                    { 
                        // kiem tra xem neu la HD HKtri ky thi dung report_DL
                        if (dt.Rows[0]["Signer"].ToString().ToLower() == "hồ kim trí")
                        {
                            Reports.reportThuMoiLamViec_DL rp = new Reports.reportThuMoiLamViec_DL(totalSalary, totalTestSalary);
                            rp.DataSource = dt;
                            rp.ShowPreviewDialog();
                        }
                        else
                        {
                            Reports.reportThuMoiLamViec rp = new Reports.reportThuMoiLamViec(totalSalary, totalTestSalary);
                            rp.DataSource = dt;
                            rp.ShowPreviewDialog();
                        }
                    }
                    else
                    {
                        Reports.reportThuMoiLamViec rp = new Reports.reportThuMoiLamViec(totalSalary, totalTestSalary);
                        rp.DataSource = dt;
                        rp.ShowPreviewDialog();
                        //Reports.reportThuMoiLamViec_DB rp = new Reports.reportThuMoiLamViec_DB(totalSalary, totalTestSalary);
                        //rp.DataSource = dt;
                        //rp.ShowPreviewDialog();
                       
                    }
                }
                else
                {
                    // kiem tra xem neu la HD HKtri ky thi dung report_DL
                    if (dt.Rows[0]["Signer"].ToString().ToLower() == "hồ kim trí")
                    {
                        Reports.reportThuMoiLamViec_DL rp = new Reports.reportThuMoiLamViec_DL(totalSalary, totalTestSalary);
                        rp.DataSource = dt;
                        rp.ShowPreviewDialog();
                    }
                    else
                    {

                        Reports.reportThuMoiLamViec rp = new Reports.reportThuMoiLamViec(totalSalary, totalTestSalary);
                        rp.DataSource = dt;
                        rp.ShowPreviewDialog();
                    }
                }
                
               // Reports.reportThuMoiLamViec rp = new Reports.reportThuMoiLamViec();
               // rp.DataSource = dt;
                
               //rp.ShowDesigner();
               //  rp.ShowPreviewDialog();
               Class.S_Log.Insert("Hợp đồng", "Xem trang In Thư mời làm việc: " + _value);
            }
        }

        private void btnCallThemHD_Click(object sender, EventArgs e)
        {
            btnAddHD_ItemClick(null, null);
        }

        private void btnCallCapNhatHD_Click(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //GridView view = (GridView)sender;
            //Check whether the indicator cell belongs to a data row
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle+1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }

   
        private void cboTrangThai_EditValueChanged(object sender, EventArgs e)
        {
           // string txt = cboTrangThai.EditValue.ToString();
            if (cboTrangThai.EditValue == null)
            {
                cboTrangThai.EditValue = "[Tất cả]";
            }
            switch (cboTrangThai.EditValue.ToString())
            {
                case "[Tất cả]":
                    xulyloaddsHopDong(treeListCoCauToChuc.FocusedNode.GetDisplayText(1), -1);
                    break;
                case "[Danh sách hợp đồng hiện tại]":
                    xulyloaddsHopDong("HDHT", -1);
                    break;
                case "[Danh sách hợp đồng sắp hết hạn (30 Ngày)]":
                    xulyloaddsHopDong("30Ngay", -1);
                    break;
                case "[Danh sách hợp đồng đã hết hạn]":
                    xulyloaddsHopDong("HetHan", -1);
                    break;
            }

           // EnableControl();
        }

        private void EnableControl()
        {
            if (gridItemDetail.RowCount < 1)
            {
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                btnExport.Enabled = false;
                btnPrint.Enabled = false;
                btnCallCapNhatHD.Enabled = false;
                btnCallPrintThuMoi.Enabled = false;
                btnCallPrintThuViec.Enabled = false;

            }
            else
            {
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                btnExport.Enabled = true;
                btnPrint.Enabled = true;
                btnCallCapNhatHD.Enabled = true;
                btnCallPrintThuMoi.Enabled = true;
                btnCallPrintThuViec.Enabled = true;
            }

        }

        bool _inhd = false;
        private void gridItemDetail_Click(object sender, EventArgs e)
        {
            if (_inhd)
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["ContractCode"].ToString();
                    if (_value.IndexOf("HDTV") > 0)
                    {
                        btnPrint.Enabled = false;
                        btnCallPrintThuViec.Enabled = true;
                        btnCallPrintThuMoi.Enabled = true;
                        btnCallPrintPhuLucHopDong.Enabled = false;
                    }
                    else
                    {
                        btnPrint.Enabled = true;
                        btnCallPrintThuViec.Enabled = false;
                        btnCallPrintThuMoi.Enabled = false;
                        btnCallPrintPhuLucHopDong.Enabled = true;
                    }

                }
            }
        }

        private void frmDanhSachHopDong_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                gridItemDetail.SaveLayoutToXml(template_grid);
                this.Dispose();
            }
            catch { }
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xlsx";
            saveFile.Title = "Exprot to Excel File";
            saveFile.ShowDialog();

            if (saveFile.FileName != "")
                gridItem.ExportToXlsx(saveFile.FileName);
        }

        int _focusGridItem = 1;
        private void gridItem_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridItemDetail.DataSource != null)
            {
                if (_focusGridItem < gridItemDetail.RowCount)
                {
                    gridItemDetail.MoveBy(_focusGridItem);
                }
            }
        }

        private void treeListCoCauToChuc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (load_cctt == 0)
            {
                if (treeListCoCauToChuc.FocusedNode != null)
                {
                    cboTrangThai_EditValueChanged(null, null);
                }
            }
        }

        private void btnCallPrintPhuLucHopDong_Click(object sender, EventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                int waitIndex = 0;
                Waiting.ShowWaitForm();
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["ContractCode"].ToString();
                Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                hd.ContractCode = _value;
                DataTable dt = hd.HRM_CONTRACT_GetPrintByCode();
                if (_value.IndexOf("HDTV") > 0)
                {
                    // Reports.reportHoDongThuViec rp = new Reports.reportHoDongThuViec();
                    // rp.DataSource = dt;
                    // rp.ShowDesigner();
                    // rp.ShowPreviewDialog();
                }
                else
                {
                    Reports.reportPhuLucHopDongLaoDong report = new Reports.reportPhuLucHopDongLaoDong(dt);
                    report.DataSource = dt;
                    Waiting.CloseWaitForm();
                    waitIndex = 1;
                   report.ShowPreviewDialog();

                   // report.ShowDesigner();
                   Class.S_Log.Insert("Hợp đồng", "Xem trang In Phụ lục Hợp đồng lao động: " + _value);
                }
                if (waitIndex != 1)
                    Waiting.CloseWaitForm();
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gridItemDetail.FocusedRowHandle < 0)
                e.Cancel = true;

            string _value = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colContractCode).ToString();
            if (_value.Contains("Lan1"))
            {
                if (_value.Contains("KXDTH"))
                {
                    btnToKhaiBH.Enabled = false;
                }
                else
                {
                    btnToKhaiBH.Enabled = true;
                }
            }
            else
            {
                btnToKhaiBH.Enabled = false;
            }
        }

        private void btnToKhaiBH_Click(object sender, EventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                int waitIndex = 0;
                Waiting.ShowWaitForm();
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["ContractCode"].ToString();
                Class.NhanVien_HopDong hd = new Class.NhanVien_HopDong();
                hd.ContractCode = _value;
                DataTable dt = hd.HRM_CONTRACT_GetPrintByCode();
                if(_value.Contains("Lan1")){
                                       
                    Reports.ReportToKhaiThamGiaBaoHiem report = new Reports.ReportToKhaiThamGiaBaoHiem(dt);
                    report.DataSource = dt;
                    Waiting.CloseWaitForm();
                    waitIndex = 1;
                    report.ShowPreviewDialog();

                     //report.ShowDesigner();
                   Class.S_Log.Insert("Hợp đồng", "Xem trang In Tờ khai Tham Gia Bảo Hiểm : " + _value);
                }
                if (waitIndex != 1)
                    Waiting.CloseWaitForm();
            }
        }      
      
    }
}