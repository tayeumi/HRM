using System;
using System.Data;
using System.Windows.Forms;

namespace HRM
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }       
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Length < 1 || txtMatkhau.Text.Length < 1)
            {
                MessageBox.Show(" Chưa nhập đủ thông tin ");
                return;
            }
            Class.S_TaiKhoan tk = new Class.S_TaiKhoan();
            tk.UserName = txtTaiKhoan.Text;           
            tk.Password = Class.S_TaiKhoan.md5(txtMatkhau.Text);
            try
            {
                DataTable dt = tk.CheckLogin();
                if (dt.Rows.Count > 0)
                {
                    // MessageBox.Show(" Đăng nhập thành công !");
                    if (checkLuuPass.Checked)
                    {
                        Class.RegistryWriter rg = new Class.RegistryWriter();
                        rg.WriteKey("user_client", txtTaiKhoan.Text);

                    }
                    else
                    {
                        Class.RegistryWriter rg = new Class.RegistryWriter();
                        rg.WriteKey("user_client", "");

                    }
                    (this.Owner as frmMain)._taiKhoan = txtTaiKhoan.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(" Tài khoản hoặc mật khẩu không đúng !");
                    (this.Owner as frmMain)._taiKhoan = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            Class.RegistryWriter rg = new Class.RegistryWriter();
            string user= rg.valuekey("user_client");
            if (user != "Blue" & user != "")
            {
                txtTaiKhoan.Text = user;
                checkLuuPass.Checked = true;
            }
            else
            {
                txtTaiKhoan.Text = "";
                checkLuuPass.Checked = false;
            }
        }        
    }
}