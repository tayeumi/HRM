using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmPhanQuyen_DanhMuc : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyen_DanhMuc()
        {
            InitializeComponent();
        }

        private void frmPhanQuyen_DanhMuc_Load(object sender, EventArgs e)
        {
            GetAllList_OBJECT();
        }
        public void GetAllList_OBJECT()
        {
            Class.DanhMuc_Quyen dm = new Class.DanhMuc_Quyen();
            gridItem.DataSource = dm.GetAllList_OBJECT();
            gridItemDetail.ExpandAllGroups();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhanQuyen_DanhMuc_Update frm = new frmPhanQuyen_DanhMuc_Update(true, "Thêm Danh mục quyền", "Q", null, "frmPhanQuyen_DanhMuc");
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["ID"].ToString();

                frmPhanQuyen_DanhMuc_Update frm = new frmPhanQuyen_DanhMuc_Update(false, "Cập nhật Danh mục", "Q", _value, "frmPhanQuyen_DanhMuc");
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
                string _value = drow["ID"].ToString();
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.DanhMuc_Quyen dm = new Class.DanhMuc_Quyen();
                dm.ID = _value;
                if (dm.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    GetAllList_OBJECT();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }

        private void btnGomNhom_Click(object sender, EventArgs e)
        {
            if (btnGomNhom.Checked)
            {
                btnGomNhom.Checked = false;
                gridItemDetail.ExpandAllGroups();
            }
            else
            {
                btnGomNhom.Checked = true;
              
                gridItemDetail.CollapseAllGroups();
            }
        }
    }
}