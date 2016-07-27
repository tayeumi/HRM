using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HRM.Forms
{
    public partial class frmDanhSachNhanVien_ThoiVu_ChamCong : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhanVien_ThoiVu_ChamCong()
        {
            InitializeComponent();
        }

        DataTable dtxp;
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
            dtxp = cc.CHECKINOUT_GetByDateAll_Report_Season();
            Waiting.SetWaitFormDescription("Khởi tạo dữ liệu hoàng tất..");
            gridItem.DataSource = dtxp;
            if (dtxp.Rows.Count > 0)
            {
                // btnExportExcelTemplate.Enabled = true;
                //  btnExportExcelTemplateByGroup.Enabled = true;
                btnTongHopXuat.Enabled = true;
            }
            else
            {
                btnTongHopXuat.Enabled = false;
            }
            Waiting.CloseWaitForm();

        }

        private void frmDanhSachNhanVien_ThoiVu_ChamCong_Load(object sender, EventArgs e)
        {
            //dateTHFrom.EditValue = DateTime.Now;
           // dateTHTo.EditValue = DateTime.Now;
            dateTHFrom.DateTime = DateTime.Today;
            dateTHTo.DateTime = DateTime.Today.AddHours(23);
            //dateTHFrom.DateTime = DateTime.Today;
           // dateTHTo.DateTime = DateTime.Today.AddHours(23);

        }

        private void btnTongHopXuat_Click(object sender, EventArgs e)
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
              //  Class.DanhSach_Nhom nhom = new Class.DanhSach_Nhom();
                //DataTable dtgroup = nhom.GetAllList_GROUP();
                //if (System.IO.File.Exists(Link_Template))
                //  Class.ExportDataToExcel.ExportExcel_CTCCByGroup(dtxp, dtpb, dtgroup, 4, "A", true, Link_Template, saveFile.FileName, false);
                if (System.IO.File.Exists(Link_Template))
                    Class.ExportDataToExcel.ExportExcel_CTCC(dtxp, dtpb, 4, "A", true, Link_Template, saveFile.FileName, false);

                Waiting.CloseWaitForm();
            }
        }
    }
}