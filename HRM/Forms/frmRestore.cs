using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace HRM.Forms
{
    public partial class frmRestore : DevExpress.XtraEditors.XtraForm
    {
        public frmRestore()
        {
            InitializeComponent();
        }

        private void frmRestore_Load(object sender, EventArgs e)
        {
            Class.RegistryWriter rg = new Class.RegistryWriter();
            string dataname = rg.valuekey("database");
            txtDatabaseName.Text = dataname;
        }

        public static void RestoreDB(string backUpFilePath, string databaseName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Class.RegistryWriter rg = new Class.RegistryWriter();
                string _serverName = rg.valuekey("server");
                string _user = Class.DbConnection.user;
                string _pass = Class.DbConnection.password;           

               // Console.WriteLine("Restore operation started");
                Restore restore = new Restore();
                //Set type of backup to be performed to database
                restore.Database = databaseName;
                restore.Action = RestoreActionType.Database;
                //Set up the backup device to use filesystem.         
                restore.Devices.AddDevice(backUpFilePath, DeviceType.File);
                //set ReplaceDatabase = true to create new database
                //regardless of the existence of specified database
                restore.ReplaceDatabase = true;
                //If you have a differential or log restore to be followed,
                //you would specify NoRecovery = true
                restore.NoRecovery = false;               
                //if you want to restore to a different location, specify
                //the logical and physical file names
               // restore.RelocateFiles.Add(new RelocateFile("Test",@"C:\Temp\Test.mdf"));
              //  restore.RelocateFiles.Add(new RelocateFile("Test_Log",@"C:\Temp\Test_Log.ldf"));
                ServerConnection connection = new ServerConnection(_serverName);
                //my SQL user doesnt have sufficient permissions,
                //so i am using my windows account
                //connection.LoginSecure = true;
               connection.LoginSecure = false;
               connection.Login = _user;
                connection.Password = _pass;
                Server sqlServer = new Server(connection);
                sqlServer.KillAllProcesses(databaseName);
                //SqlRestore method starts to restore database                  
                restore.SqlRestore(sqlServer);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Phục Hồi dữ liệu thành công ! \n Phần mềm sẽ tự động đóng lại. Vui lòng mở lại phần mềm");
                Application.Exit();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Restore operation failed");
               MessageBox.Show(ex.Message);
            }
           // Console.ReadLine();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPathName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog _fileName = new System.Windows.Forms.OpenFileDialog();
            _fileName.DefaultExt = "bak";
            _fileName.Filter = "Sql files (*.bak)|*.bak";
            _fileName.ShowDialog();
            if (_fileName.FileName != "")
                txtPathName.Text = _fileName.FileName;
        }

        private void btnAcction_Click(object sender, EventArgs e)
        {
            if (txtPathName.Text.Length < 2)
            {
                MessageBox.Show(" Bạn chưa chọn file backup");
                return;
            }
            if (MessageBox.Show("Bạn thực hiện chức năng này, dữ liệu của bạn sẽ phục hồi về thời điểm sao lưu. \n Bạn chắc chắn là muốn thực hiện thao tác này chứ ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            RestoreDB(txtPathName.Text, txtDatabaseName.Text);
        }

    }
}