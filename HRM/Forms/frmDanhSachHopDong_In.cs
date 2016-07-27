using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace HRM.Forms
{
    public partial class frmDanhSachHopDong_In : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachHopDong_In()
        {
            InitializeComponent();
        }

        private void frmDanhSachHopDong_In_Load(object sender, EventArgs e)
        {
            //HRM_CONTRACT_PRINT_Getlist();
        }

        void HRM_CONTRACT_PRINT_Getlist()
        {
            Class.NhanVien_HopDong_In cls = new Class.NhanVien_HopDong_In();
            gridItem.DataSource = cls.HRM_CONTRACT_PRINT_Getlist();
          
        }

        private void gridItemDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridItemDetail.GetFocusedRowCellValue(colImages) != DBNull.Value)
                {
                    // xu ly photo            
                    Byte[] imgbyte = (byte[])gridItemDetail.GetFocusedRowCellValue(colImages);
                    if (imgbyte.Length > 10)
                    {
                        MemoryStream stmPicData = new MemoryStream(imgbyte);
                        ImageHD.Image = Image.FromStream(stmPicData);
                    }
                    //
                }          
                
            }
            catch { }
        }
        bool dubclick = false;
        private void ImageHD_DoubleClick(object sender, EventArgs e)
        {
            if (dubclick)
            {
                this.ImageHD.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                dubclick = false;
            }
            else
            {
                this.ImageHD.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
                dubclick = true;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            if (txtEmployeeCode.Text.Trim().Length > 0)
            {
                Class.NhanVien_HopDong_In cls = new Class.NhanVien_HopDong_In();
                cls.EmployeeCode = txtEmployeeCode.Text;
                gridItem.DataSource = cls.HRM_CONTRACT_PRINT_GetbyEmployeeCode();
            }
            Waiting.CloseWaitForm();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            HRM_CONTRACT_PRINT_Getlist();
            Waiting.CloseWaitForm();
        }
    }
}