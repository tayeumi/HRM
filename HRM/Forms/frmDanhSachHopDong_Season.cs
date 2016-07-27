using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace HRM.Forms
{
    public partial class frmDanhSachHopDong_Season : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachHopDong_Season()
        {
            InitializeComponent();
        }

        private void frmDanhSachHopDong_Season_Load(object sender, EventArgs e)
        {
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

            HRM_CONTRACT_SEASON_GetList();
        }
        DataTable dttv= new DataTable();
        public void HRM_CONTRACT_SEASON_GetList()
        {
            Class.NhanVien_HopDong_ThoiVu hdtv = new Class.NhanVien_HopDong_ThoiVu();
             dttv=   hdtv.HRM_CONTRACT_SEASON_GetList();
            gridItem.DataSource = dttv;

        }

        private void btnAddHD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang khởi tạo hợp đồng mới..");
            frmDanhSachHopDong_Season_Update frm = new frmDanhSachHopDong_Season_Update(true, "Thêm Hợp Đồng Thời vụ", "HĐ", null, "frmDanhSachHopDong");
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

                Class.NhanVien_HopDong_ThoiVu hd = new Class.NhanVien_HopDong_ThoiVu();
                hd.ContractCode = _value;
                hd.EmployeeCode = _manv;
                if (hd.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    HRM_CONTRACT_SEASON_GetList();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnEdit.Enabled)
                return;
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["ContractCode"].ToString();
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải thông tin hợp đồng..");
                frmDanhSachHopDong_Season_Update frm = new frmDanhSachHopDong_Season_Update(false, "Cập nhật Hợp Đồng Lao Động", "HĐ", _value, "frmDanhSachHopDong");
                frm.Owner = this;
                Waiting.CloseWaitForm();
                frm.ShowDialog();
            }
        }

        private void gridItemDetail_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải trang in hợp đồng thời vụ");
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["ContractCode"].ToString();
                Class.NhanVien_HopDong_ThoiVu hd = new Class.NhanVien_HopDong_ThoiVu();
                hd.ContractCode = _value;
                DataTable dt = hd.HRM_CONTRACT_SEASON_GetPrintByCode();
                Reports.reportHopDongThoiVu_DL rp;
                Reports.reportHopDongThoiVu rp1;
                if (dt.Rows[0]["Signer"].ToString().ToLower() == "hồ kim trí")
                {
                    if (dt.Rows[0]["BranchName"].ToString().ToLower().Contains("hồ chí minh"))
                    {
                        rp1 = new Reports.reportHopDongThoiVu();
                        rp1.DataSource = dt;
                        rp1.ShowPreview();
                       // rp1.ShowDesigner();
                    }
                    else
                    {
                        rp = new Reports.reportHopDongThoiVu_DL();
                        rp.DataSource = dt;
                        rp.ShowPreview();
                    }
                }else{
                     rp1 = new Reports.reportHopDongThoiVu();
                     rp1.DataSource = dt;
                     rp1.ShowPreview();
                }
               
               
               // rp.ShowDesigner();               
                Waiting.CloseWaitForm();
            }
        }

        private void cboTrangThai_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTrangThai.EditValue == null)
            {
                cboTrangThai.EditValue = "[Tất cả]";
            }
            switch (cboTrangThai.EditValue.ToString())
            {
                case "[Tất cả]":
                    LoadHDTV("all");
                    break;
                case "[Danh sách hợp đồng hiện tại]":
                    LoadHDTV("now");
                    break;
                case "[Danh sách hợp đồng đã hết hạn]":
                    LoadHDTV("end");
                    break;              
            }
        }

        private void LoadHDTV(string loaiHD)
        {
            if (loaiHD == "all")
            {
                gridItem.DataSource = dttv;
                if (dttv.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dttv.DefaultView;
                    dv.RowFilter = "";
                }
            }
            else if (loaiHD == "now")
            {
                gridItem.DataSource = dttv;
                if (dttv.Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dttv.DefaultView;
                    dv.RowFilter = "IsCurrent='"+true+"' and Status<3";
                }
            }
            else if (loaiHD == "end")
            {
                Class.NhanVien_HopDong_ThoiVu tv = new Class.NhanVien_HopDong_ThoiVu();
               DataTable dttv2 = tv.HRM_CONTRACT_SEASON_GetListExpiration();
               gridItem.DataSource = dttv2;
            }

        }
    }
}