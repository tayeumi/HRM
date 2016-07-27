using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhMucBenhVien : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucBenhVien()
        {
            InitializeComponent();
        }

        private void frmDanhMucBenhVien_Load(object sender, EventArgs e)
        {
            GetAllList_HOSPITAL();
        }
        public void GetAllList_HOSPITAL()
        {
            Class.DanhMuc_BenhVien dm = new Class.DanhMuc_BenhVien();
            gridItem.DataSource = dm.GetAllList_HOSPITAL();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhMucBenhVien_Update frm = new frmDanhMucBenhVien_Update(true, "Thêm Bệnh viện", "BV", null);
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnEdit.Enabled)
                return;
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["HospitalCode"].ToString();

                frmDanhMucBenhVien_Update frm = new frmDanhMucBenhVien_Update(false, "Sửa Tên Bệnh viện", "BV", _value);
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void gridItemDetail_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["HospitalCode"].ToString();
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.DanhMuc_BenhVien dm = new Class.DanhMuc_BenhVien();
                dm.HospitalCode = _value;
                if (dm.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    GetAllList_HOSPITAL();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }
    }
}