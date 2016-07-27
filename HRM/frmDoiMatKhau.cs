using System;
using System.Data;
using System.Windows.Forms;

namespace HRM
{
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        string _tk;
        public frmDoiMatKhau(string _taikhoan)
        {
            InitializeComponent();
            _tk = _taikhoan;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtmkcu.Text.Length < 1 || txtmkmoi.Text.Length < 1 || txtnhaplai.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtmkmoi.Text != txtnhaplai.Text)
            {
                MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu chưa trùng nhau !");
                return;
            }
            Class.S_TaiKhoan tk = new Class.S_TaiKhoan();
            tk.UserName=_tk;
            tk.Password = Class.S_TaiKhoan.md5(txtmkcu.Text);
            DataTable ktpasscu = tk.CheckLogin();
            if (ktpasscu.Rows.Count > 0)
            {
                tk.Password = Class.S_TaiKhoan.md5(txtmkmoi.Text);
                if (tk.ChangePassword())
                {
                    MessageBox.Show("Bạn đã thay đổi Mật khẩu thành công ");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(" Thay đổi mật khẩu thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
            }

        }
                  
       
    }
}