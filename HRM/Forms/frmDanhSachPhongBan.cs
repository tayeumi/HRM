using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhSachPhongBan : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachPhongBan()
        {
            InitializeComponent();
        }

        private void frmDanhSachPhongBan_Load(object sender, EventArgs e)
        {
            GetAllList_DEPARTMENT();
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

        public void GetAllList_DEPARTMENT()
        {
            Class.PhongBan dm = new Class.PhongBan();
            gridItem.DataSource = dm.GetAllList_DEPARTMENT();
            gridItemDetail.ExpandAllGroups();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachPhongBan_Update frm = new frmDanhSachPhongBan_Update(true, "Thêm Phòng ban", "PB", null,"frmDanhSachPhongBan");
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
                string _value = drow["DepartmentCode"].ToString();

                frmDanhSachPhongBan_Update frm = new frmDanhSachPhongBan_Update(false, "Sửa Phòng ban", "PB", _value, "frmDanhSachPhongBan");
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
                string _value = drow["DepartmentCode"].ToString();
                if (Class.App.ConfirmDeletion("Bạn chắc muốn xóa thông tin Phòng Ban này không ? \n Lưu ý: Mọi thông tin Nhóm và Nhân Viên thuộc Phòng Ban này sẽ bị xóa hết !") == DialogResult.No)
                    return;

                Class.PhongBan dm = new Class.PhongBan();
                dm.DepartmentCode = _value;
                if (dm.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    GetAllList_DEPARTMENT();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }
    }
}