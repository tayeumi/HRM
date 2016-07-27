using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhSachNhom : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhom()
        {
            InitializeComponent();
        }

        private void frmDanhSachNhom_Load(object sender, EventArgs e)
        {
            GetAllList_GROUP();
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
            //-----------
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

        public void GetAllList_GROUP()
        {
            Class.DanhSach_Nhom ds = new Class.DanhSach_Nhom();
            gridItem.DataSource = ds.GetAllList_GROUP();
            gridItemDetail.ExpandAllGroups();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachNhom_Update frm = new frmDanhSachNhom_Update(true, "Thêm Tổ, Nhóm", "TN", null, "frmDanhSachNhom");
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
                string _value = drow["GroupCode"].ToString();

                frmDanhSachNhom_Update frm = new frmDanhSachNhom_Update(false, "Sửa Tổ, nhóm", "TN", _value, "frmDanhSachNhom");
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
                string _value = drow["GroupCode"].ToString();
                if (Class.App.ConfirmDeletion("Bạn chắc muốn xóa thông tin Nhóm này không ? \n Lưu ý: Mọi thông tin Nhân Viên thuộc nhóm này sẽ bị xóa hết !") == DialogResult.No)
                    return;

                Class.DanhSach_Nhom dm = new Class.DanhSach_Nhom();
                dm.GroupCode = _value;
                if (dm.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    GetAllList_GROUP();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }
    }
}