using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System.IO;

namespace HRM.Forms
{
    public partial class frmDanhSachNhanVien_ThoiVu : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhanVien_ThoiVu()
        {
            InitializeComponent();
        }
        string template_grid_all = Application.StartupPath + @"\Templates\Templates_DSNSTV_All.xml";
        private void frmDanhSachNhanVien_ThoiVu_Load(object sender, EventArgs e)
        {
            if (File.Exists(template_grid_all))
            {
                gridItemDetail.RestoreLayoutFromXml(template_grid_all);
            }
            
           // #region Khoa Phan quyen
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

            HRM_EMPLOYEE_SEASON_GetList();

        }
        DataTable dtnv; 
        public void HRM_EMPLOYEE_SEASON_GetList()
        {
            Class.NhanVien_ThoiVu cls = new Class.NhanVien_ThoiVu();
            dtnv = cls.HRM_EMPLOYEE_SEASON_GetList();
            gridItem.DataSource = dtnv;
        }

        private void btnAddNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnAddNV.Enabled)
                return;

            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải khởi tạo nhân viên mới..");
            frmCapNhatNhanVien_ThoiVu frm = new frmCapNhatNhanVien_ThoiVu(true, "Thêm nhân viên ", null, null, "frmDanhSachNhanVien");
            frm.Owner = this;
            Waiting.CloseWaitForm();
            frm.ShowDialog();
            this.Activate();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnEdit.Enabled)
                return;

                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    Waiting.ShowWaitForm();
                    Waiting.SetWaitFormDescription("Đang tải thông tin nhân viên..");
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _name = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                    frmCapNhatNhanVien_ThoiVu frm = new frmCapNhatNhanVien_ThoiVu(false, "Cập nhật nhân viên: " + _name + "(" + _value + ")", "NV", _value, "frmDanhSachNhanVien");
                    frm.Owner = this;
                    Waiting.CloseWaitForm();
                    frm.ShowDialog();
                    this.Activate();
                }
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnDel.Enabled)
                return;
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    string _value = drow["EmployeeCode"].ToString();
                    string _fulname = drow["FirstName"].ToString() + " " + drow["LastName"].ToString();
                  

                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá hay không ?" +
                               " \n Lưu ý: Tất cả thông tin về " + _fulname + " sẽ bị xóa khỏi cơ sở dữ liệu !", "Cảnh báo: Xóa nhân viên - " + _fulname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    Class.NhanVien_ThoiVu nv = new Class.NhanVien_ThoiVu();
                    nv.EmployeeCode = _value;
                   
                    if (nv.Delete())
                    {
                        Class.App.DeleteSuccessfully();
                        HRM_EMPLOYEE_SEASON_GetList();
                    }
                    else
                    {
                        Class.App.DeleteNotSuccessfully();
                    }
                }
            
        }

        private void gridItemDetail_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
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
                    xulyloaddsNhanVien(-1);
                    break;
                case "[Đang thử việc]":
                    xulyloaddsNhanVien(0);
                    break;
                case "[Đang làm việc]":
                    xulyloaddsNhanVien(1);
                    break;
                case "[Đang ngưng việc]":
                    xulyloaddsNhanVien(2);
                    break;
                case "[Đã nghỉ việc]":
                    xulyloaddsNhanVien(3);
                    break;
            }
        }
        private void xulyloaddsNhanVien(int trangthai)
        {
            if (trangthai == -1)
            {
                DataView dv = new DataView();
                dv = dtnv.DefaultView;
                dv.RowFilter = "";
            }
            else
            {
                DataView dv = new DataView();
                dv = dtnv.DefaultView;
                dv.RowFilter = "Status='" + trangthai + "'";
            }
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnPrint.Enabled)
                return;
           
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

        private void frmDanhSachNhanVien_ThoiVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridItemDetail.SaveLayoutToXml(template_grid_all); 
        }
    }
}