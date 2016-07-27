using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhSachChiNhanh : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachChiNhanh()
        {
            InitializeComponent();
        }

        private void frmDanhSachChiNhanh_Load(object sender, EventArgs e)
        {
            GetAllList_BRANCH();
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
        public void GetAllList_BRANCH()
        {
            Class.DanhSach_ChiNhanh dm = new Class.DanhSach_ChiNhanh();
            gridItem.DataSource = dm.GetAllList_BRANCH();
            gridItemDetail.ExpandAllGroups();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachChiNhanh_Update frm = new frmDanhSachChiNhanh_Update(true, "Thêm Chi nhánh", "CN", null, "frmDanhSachChiNhanh");
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
                string _value = drow["BranchCode"].ToString();

                frmDanhSachChiNhanh_Update frm = new frmDanhSachChiNhanh_Update(false, "Sửa Chi nhánh", "CN", _value, "frmDanhSachChiNhanh");
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
                string _value = drow["BranchCode"].ToString();
                if (Class.App.ConfirmDeletion("Bạn chắc muốn xóa thông tin Chi nhánh này không ? \n Lưu ý: Mọi thông tin Phòng ban, Nhóm, Nhân Viên thuộc chi nhánh này sẽ bị xóa hết !") == DialogResult.No)
                    return;

                Class.DanhSach_ChiNhanh dm = new Class.DanhSach_ChiNhanh();
                dm.BranchCode = _value;
                if (dm.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    GetAllList_BRANCH();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }
    }
}