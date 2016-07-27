using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhMucKyHieuChamCong : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucKyHieuChamCong()
        {
            InitializeComponent();
        }

        private void frmDanhMucKyHieuChamCong_Load(object sender, EventArgs e)
        {
            DIC_SYMBOL_GetList();
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
        public void DIC_SYMBOL_GetList()
        {
            Class.DanhMuc_KyHieuChamCong dm = new Class.DanhMuc_KyHieuChamCong();
            gridItem.DataSource = dm.DIC_SYMBOL_GetList();
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhMucKyHieuChamCong_Update frm = new frmDanhMucKyHieuChamCong_Update(true, "Thêm Ký hiệu chấm công", "CC", null);
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
                string _value = drow["SymbolCode"].ToString();
                frmDanhMucKyHieuChamCong_Update frm = new frmDanhMucKyHieuChamCong_Update(false, "Cập nhật ký hiệu chấm công", "CC", _value);
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
                string _value = drow["SymbolCode"].ToString();
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.DanhMuc_KyHieuChamCong dm = new Class.DanhMuc_KyHieuChamCong();
                dm.SymbolCode = _value;
                if (dm.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    DIC_SYMBOL_GetList();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }
    }
}