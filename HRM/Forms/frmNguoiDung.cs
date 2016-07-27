using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            GetAllList_USER();
        }

        public void GetAllList_USER()
        {
            Class.S_TaiKhoan dm = new Class.S_TaiKhoan();
            gridItem.DataSource = dm.GetAllList_USER();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNguoiDung_Update frm = new frmNguoiDung_Update(true, "Thêm Người dùng", "ND", null, "frmNguoiDung");
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["UserName"].ToString();

                frmNguoiDung_Update frm = new frmNguoiDung_Update(false, "Cập nhật Người dùng", "ND", _value, "frmNguoiDung");
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
                string _value = drow["UserName"].ToString();
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.S_TaiKhoan dm = new Class.S_TaiKhoan();
                dm.UserName = _value;
                if (dm.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    GetAllList_USER();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }
    }
}