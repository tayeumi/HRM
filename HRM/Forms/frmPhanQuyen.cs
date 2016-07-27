using System;
using System.Data;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            GetList_User();
        }

        private void GetList_User()
        {
            Class.S_TaiKhoan tk = new Class.S_TaiKhoan();
            treeAccount.Nodes.Clear();
            this.treeAccount.AppendNode(new object[] { "Tài khoản ", "0" }, -1, 1, 1, 0);
            DataTable dt =tk.GetAllList_USER();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.treeAccount.AppendNode(new object[] { dt.Rows[i]["Username"].ToString(), dt.Rows[i]["Username"].ToString() }, 0, 0, 0, 0);
            }
            treeAccount.ExpandAll();
        }

        DataTable dtNotUse=null;
        DataTable dtIsUse = null;
        private void GetList_PermissionByUser(string strUser)
        {
            if(dtNotUse!=null)
            dtNotUse.Clear();
            if (dtIsUse != null)
            dtIsUse.Clear();

            Class.S_TaiKhoan tk = new Class.S_TaiKhoan();
            tk.UserName=strUser;
            dtNotUse = tk.GetPermissionNotUseByUser();
            dtIsUse = tk.GetPermissionByUser();
            gridIsUse.DataSource = dtIsUse;
            gridNotUse.DataSource = dtNotUse;
            gridNotUseDetail.ExpandAllGroups();
            bandedgridNotUse.ExpandAllGroups();
            bandedgirdIsUse.ExpandAllGroups();
            bandedgridNotUse.BestFitColumns();
            bandedgirdIsUse.BestFitColumns();
        }

        private void treeAccount_Click(object sender, EventArgs e)
        {
            if (!treeAccount.FocusedNode.RootNode.Focused)
           {
                this.Text ="Bảng phân quyền cho Tài khoản: "  + treeAccount.FocusedNode.GetDisplayText(1);
                GetList_PermissionByUser(treeAccount.FocusedNode.GetDisplayText(1));
           }
                        
        }

   
        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            if (dtNotUse != null)
            {
                
                int _checkvalue = 0;
                for (int i = 0; i < dtNotUse.Rows.Count; i++)
                {
                    if ((bool)dtNotUse.Rows[i]["selectvalue"] == true)
                        _checkvalue++;
                }

                if (_checkvalue < 1)
                {
                    MessageBox.Show(" Bạn chưa chọn quyền để thêm ");
                    return;
                }
                Class.S_TaiKhoan tk = new Class.S_TaiKhoan();
                tk.UserName = treeAccount.FocusedNode.GetDisplayText(1);
                if (tk.Insert_Permission(dtNotUse))
                {
                    Class.App.SaveSuccessfully();
                    GetList_PermissionByUser(treeAccount.FocusedNode.GetDisplayText(1));
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }             
            }

        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {
            if (dtIsUse != null)
            {
                int _checkvalue = 0;
                for (int i = 0; i < dtIsUse.Rows.Count; i++)
                {
                    if ((bool)dtIsUse.Rows[i]["selectvalue"] == true)
                        _checkvalue++;
                }

                if (_checkvalue < 1)
                {
                    MessageBox.Show(" Bạn chưa chọn quyền để xóa ");
                    return;
                }

                Class.S_TaiKhoan tk = new Class.S_TaiKhoan();
                tk.UserName = treeAccount.FocusedNode.GetDisplayText(1);
                if (tk.Delete_Permission(dtIsUse))
                {
                    Class.App.SaveSuccessfully();
                    GetList_PermissionByUser(treeAccount.FocusedNode.GetDisplayText(1));
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }

            }
           
        }

        private void btnChonTatCaAdd_Click(object sender, EventArgs e)
        {
            if (dtNotUse != null)
            {
                for (int i = 0; i < dtNotUse.Rows.Count; i++)
                {
                    dtNotUse.Rows[i]["selectvalue"] = true;
                }
            }
        }

        private void btnChonTatCaRemove_Click(object sender, EventArgs e)
        {
            if (dtIsUse != null)
            {
                for (int i = 0; i < dtIsUse.Rows.Count; i++)
                {
                    dtIsUse.Rows[i]["selectvalue"] = true;
                }
            }
        }

        private void btnBoChonTatCaAdd_Click(object sender, EventArgs e)
        {
            if (dtNotUse != null)
            {
                for (int i = 0; i < dtNotUse.Rows.Count; i++)
                {
                    dtNotUse.Rows[i]["selectvalue"] = false;
                }
            }
        }

        private void btnBoChonTatCaRemove_Click(object sender, EventArgs e)
        {
            if (dtIsUse != null)
            {
                for (int i = 0; i < dtIsUse.Rows.Count; i++)
                {
                    dtIsUse.Rows[i]["selectvalue"] = false;
                }
            }
        }

        private void bandedgridNotUse_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bandedgridNotUse.PostEditor();
        }

        private void bandedgirdIsUse_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bandedgirdIsUse.PostEditor();
        }

        private void contextMenuAdd_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dtNotUse != null)
            {
                int _checkvalue = 0;
                for (int i = 0; i < dtNotUse.Rows.Count; i++)
                {
                    if ((bool)dtNotUse.Rows[i]["selectvalue"] == true)
                        _checkvalue++;
                }

                if (_checkvalue < 1)
                {
                    btnThemQuyen.Enabled = false;
                }
                else
                {
                    btnThemQuyen.Enabled = true;
                }
            }
        }

        private void contextMenuRemove_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dtIsUse != null)
            {
                int _checkvalue = 0;
                for (int i = 0; i < dtIsUse.Rows.Count; i++)
                {
                    if ((bool)dtIsUse.Rows[i]["selectvalue"] == true)
                        _checkvalue++;
                }

                if (_checkvalue < 1)
                {
                    btnXoaQuyen.Enabled = false;
                    btnSaoChepQuyen.Enabled = false;

                }
                else
                {
                    btnXoaQuyen.Enabled = true;
                    btnSaoChepQuyen.Enabled = true;
                }

            }
        }
         DataTable dtSaoChepQuyen;
        private void btnSaoChepQuyen_Click(object sender, EventArgs e)
        {
            if (dtIsUse != null)
            {                
              //  dtSaoChepQuyen = dtIsUse;
                dtSaoChepQuyen= dtIsUse.Copy();
                int _checkvalue = 0;
                for (int i = 0; i < dtIsUse.Rows.Count; i++)
                {
                    if ((bool)dtIsUse.Rows[i]["selectvalue"] == true)
                        _checkvalue++;
                }

                if (_checkvalue < 1)
                {
                    MessageBox.Show(" Bạn chưa chọn quyền để sao chép ");
                    dtSaoChepQuyen = null;
                    return;
                }              
            }
        }

        private void contextMenuCopy_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dtSaoChepQuyen == null)
            {
                btnDanQuyen.Enabled = false;
            }
            else
            {
                if (dtIsUse == null || dtIsUse.Rows.Count==0)
                {
                    btnDanQuyen.Enabled = true;
                }
                else
                {
                    btnDanQuyen.Enabled = false;
                }
            }
        }

        private void btnDanQuyen_Click(object sender, EventArgs e)
        {
            if (dtSaoChepQuyen == null)
            {
                return;
            }
            Class.S_TaiKhoan tk = new Class.S_TaiKhoan();
            tk.UserName = treeAccount.FocusedNode.GetDisplayText(1);
            if (tk.Insert_Permission(dtSaoChepQuyen))
            {
                Class.App.SaveSuccessfully();
                GetList_PermissionByUser(treeAccount.FocusedNode.GetDisplayText(1));
            }
            else
            {
                Class.App.SaveNotSuccessfully();
            }    
        }
    }
}