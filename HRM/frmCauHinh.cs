using System;
using System.Windows.Forms;

namespace HRM
{
    public partial class frmCauHinh : DevExpress.XtraEditors.XtraForm
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {           
            Class.RegistryWriter rg = new Class.RegistryWriter();
            try
            {
               
                rg.WriteKey("server", txtServer.Text);
                rg.WriteKey("database", txtDatabaseName.Text);
                string _user = Class.App.EncryptString(txtUser.Text, "UserID");
                string _pass = Class.App.EncryptString(txtPass.Text, "PasswordID");
                rg.WriteKey("user", _user);
                rg.WriteKey("pass", _pass);
                if (checkAutoUpdate.Checked)
                {
                    rg.WriteKey("autoupdate", "1");
                }
                else
                {
                    rg.WriteKey("autoupdate", "0");
                }

                MessageBox.Show("Lưu cấu hình thành công !");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lưu cấu hình thất bại !");
            }
            
        }

        private void frmCauHinh_Load(object sender, EventArgs e)
        {
            try
            {
                Class.RegistryWriter rg = new Class.RegistryWriter();
                txtServer.Text = rg.valuekey("server");
                txtDatabaseName.Text = rg.valuekey("database");
                txtUser.Text = Class.App.DecryptString(rg.valuekey("user"), "UserID");
                txtPass.Text = Class.App.DecryptString(rg.valuekey("pass"), "PasswordID");
                if (rg.valuekey("autoupdate") == "1")
                {
                    checkAutoUpdate.Checked = true;
                }
                else
                {
                    checkAutoUpdate.Checked = false;
                }
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}