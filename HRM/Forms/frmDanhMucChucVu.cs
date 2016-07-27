using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhMucChucVu : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucChucVu()
        {
            InitializeComponent();
        }
      
        public void GetAllList_POSITION()
        {
            Class.DanhMuc_ChucVu dm= new Class.DanhMuc_ChucVu();
            gridItem.DataSource = dm.GetAllList_POSITION();
        }

        private void frmDanhMucChucVu_Load(object sender, EventArgs e)
        {
            GetAllList_POSITION();
            #region Khoa Phan quyen
            // thuc hien khoa phan quyen phan quyen
            for (int i = 0; i <barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].Tag != null)
                {
                    string txt = barManager1.Items[i].Tag .ToString();
                    if(txt.Length>0)
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

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhMucChucVu_Update frm = new frmDanhMucChucVu_Update(true, "Thêm Chức vụ",null, null);
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
                string _value = drow["PositionCode"].ToString();

                frmDanhMucChucVu_Update frm = new frmDanhMucChucVu_Update(false, "Sửa Chức vụ", "CV", _value);
                frm.Owner = this;
                frm.ShowDialog();                
            }
        }

        private void gridItemDetail_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);  //call edit row
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["PositionCode"].ToString();
                    if (Class.App.ConfirmDeletion() == DialogResult.No)
                        return;

                    Class.DanhMuc_ChucVu dmcv = new Class.DanhMuc_ChucVu();
                    dmcv.PositionCode = _value;
                    if (dmcv.Delete())
                    {
                        Class.App.DeleteSuccessfully();
                        GetAllList_POSITION();
                    }
                    else
                    {
                        Class.App.DeleteNotSuccessfully();
                    }
            }
        }
    }
}