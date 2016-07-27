using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmDanhMucThietBiChamCong : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucThietBiChamCong()
        {
            InitializeComponent();
        }

        private void frmDanhMucThietBiChamCong_Load(object sender, EventArgs e)
        {
            DIC_MACHINE_GetList();
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

            for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
            {
                if (contextMenuStrip1.Items[i].Tag != null)
                {
                    string txt = contextMenuStrip1.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        contextMenuStrip1.Items[i].Enabled = false;
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
            for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
            {
                if (contextMenuStrip1.Items[i].Tag != null)
                {
                    string txt = contextMenuStrip1.Items[i].Tag.ToString();
                    if (txt.Length > 0)
                    {
                        for (int l = 0; l < Class.App.dtPermision.Rows.Count; l++)
                        {
                            string _Object_ID = Class.App.dtPermision.Rows[l]["Object_ID"].ToString();
                            if (_Object_ID == txt)
                            {
                                contextMenuStrip1.Items[i].Enabled = true;
                            }
                        }

                    }
                }

            }
            #endregion
        }
        public void DIC_MACHINE_GetList()
        {
            Class.DanhMuc_ThietBiChamCong dm = new Class.DanhMuc_ThietBiChamCong();
            gridItem.DataSource = dm.DIC_MACHINE_GetList();
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhMucThietBiChamCong_Update frm = new frmDanhMucThietBiChamCong_Update(true, "Thêm Máy chấm công", "CC", null);
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
                string _value = drow["MachineCode"].ToString();
                frmDanhMucThietBiChamCong_Update frm = new frmDanhMucThietBiChamCong_Update(false, "Cập nhật Máy chấm công", "CC", _value);
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
                string _value = drow["MachineCode"].ToString();
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.DanhMuc_ThietBiChamCong dm= new Class.DanhMuc_ThietBiChamCong();
                dm.MachineCode = _value;
                if (dm.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    DIC_MACHINE_GetList();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gridItemDetail.FocusedRowHandle < 0)
                return;
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {

            try
            {

                if (!btnSaoLuu.Enabled)
                    return;
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "BacKup File|*.bak";
                saveFile.Title = "Backup to file";
                saveFile.ShowDialog();

                if (saveFile.FileName != "")
                {
                    Waiting.ShowWaitForm();
                    Waiting.SetWaitFormDescription("Đang tiến hành sao lưu ...");
                    zkemkeeper.CZKEMClass axczkem1 = new zkemkeeper.CZKEMClass();
                    bool bIsConnected = false;
                    string ip = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colIP).ToString();
                    int port = int.Parse(gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colPortID).ToString());
                    bIsConnected = axczkem1.Connect_Net(ip, port);
                    if (bIsConnected)
                    {
                        if (axczkem1.BackupData(saveFile.FileName))
                        {
                            Waiting.CloseWaitForm();
                            MessageBox.Show(" Sao Lưu thành công !....");
                        }
                        else
                        {
                            Waiting.CloseWaitForm();
                            MessageBox.Show(" Sao Lưu thất bại !....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Waiting.CloseWaitForm();
                    }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnPhucHoi.Enabled)
                    return;
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Restore File|*.bak";
                saveFile.Title = "Restore from file ";
                saveFile.ShowDialog();

                if (saveFile.FileName != "")
                {
                    Waiting.ShowWaitForm();
                    Waiting.SetWaitFormDescription("Đang tiến hành phục hồi ...");
                    zkemkeeper.CZKEMClass axczkem1 = new zkemkeeper.CZKEMClass();
                    bool bIsConnected = false;
                    string ip = gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colIP).ToString();
                    int port = int.Parse(gridItemDetail.GetRowCellValue(gridItemDetail.FocusedRowHandle, colPortID).ToString());
                    bIsConnected = axczkem1.Connect_Net(ip, port);
                    if (bIsConnected)
                    {
                        if (axczkem1.RestoreData(saveFile.FileName))
                        {
                            Waiting.CloseWaitForm();
                            MessageBox.Show(" Phục hồi thành công !....");
                        }
                        else
                        {
                            Waiting.CloseWaitForm();
                            MessageBox.Show(" Phục hồi thất bại !....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Waiting.CloseWaitForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}