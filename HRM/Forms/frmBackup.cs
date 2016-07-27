using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Threading;

//using Microsoft.SqlServer.ConnectionInfo;
//using Microsoft.SqlServer.Management.Sdk.Sfc;
//using Microsoft.SqlServer.Smo;
//using Microsoft.SqlServer.SmoExtended;


namespace HRM.Forms
{
    public partial class frmBackup : DevExpress.XtraEditors.XtraForm
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            Class.RegistryWriter rg = new Class.RegistryWriter();
            string dataname = rg.valuekey("database");
            string _folderbk=rg.valuekey("FolderBK");
            string _sv = rg.valuekey("server"); 
            if(_sv.IndexOf(@"\")>0){
                _sv = _sv.Substring(0, _sv.IndexOf(@"\"));
            }
            txtServerName.Text = _sv;
            if (_folderbk != "Blue")
                txtPathName.Text = _folderbk;
            txtFileName.Text = dataname + "." + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + "." + DateTime.Now.Hour + "." + DateTime.Now.Minute+".bak";
        }


        public static string BackupDB(string backupDestinationFilePath)
        {
            try
            {               
                Class.RegistryWriter rg = new Class.RegistryWriter();
                string _serverName = rg.valuekey("server");
                string _user = Class.DbConnection.user;
                string _pass = Class.DbConnection.password;
                string _database = rg.valuekey("database");

                //Console.WriteLine("Backup operation started");
                Backup backup = new Backup();
                //Set type of backup to be performed to database
                backup.Action = BackupActionType.Database;
                 backup.BackupSetDescription = "BackupDataBase description";
                //Set the name used to identify a particular backup set.
                backup.BackupSetName = "Backup";
                //specify the name of the database to back up
                backup.Database = _database;
                //Set up the backup device to use filesystem.
                BackupDeviceItem deviceItem = new BackupDeviceItem(
                                                backupDestinationFilePath,
                                                DeviceType.File);
                backup.Devices.Add(deviceItem);

                // Setup a new connection to the data server
               
                ServerConnection connection = new ServerConnection(_serverName);
                // Log in using SQL authentication
                connection.LoginSecure = false;
                connection.Login = _user;
                connection.Password = _pass;
                Server sqlServer = new Server(connection);
                //Initialize devices associated with a backup operation.
                backup.Initialize = true;
                backup.Checksum = true;
                //Set it to true to have the process continue even
                //after checksum error.
                backup.ContinueAfterError = true;
                //Set the backup expiry date.
               // backup.ExpirationDate = DateTime.Now.AddDays(3);
                //truncate the database log as part of the backup operation.
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                //start the back up operation               
                backup.SqlBackup(sqlServer);

                return "Backup operation succeeded";
            }
            catch 
            {
              return "Backup operation failed";
             // MessageBox.Show(ex.Message);
            }            
        }

        private void btnAcction_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            Cursor.Current = Cursors.WaitCursor;
            if (!Directory.Exists(txtPathName.Text))
            {
                Directory.CreateDirectory(txtPathName.Text);
            }
            Waiting.SetWaitFormDescription("Đang thực hiện sao lưu...");
            string _kq=BackupDB(txtServerFolder.Text + "\\" + txtFileName.Text);
            Waiting.SetWaitFormDescription(_kq);

           // Thread.Sleep(1000);

            Waiting.SetWaitFormDescription("Đang thực hiện chép dữ liệu về máy...");          

            Class.RegistryWriter rg = new Class.RegistryWriter();
            rg.WriteKey("FolderBK", txtPathName.Text);
            string linksv = @"\\" + txtServerName.Text +"\\HRM_Backup$\\" + txtFileName.Text;
            if (File.Exists(linksv))
            {
                Application.DoEvents();
                File.Copy(linksv, txtPathName.Text + "\\" + txtFileName.Text);
                Application.DoEvents();
            }
            Cursor.Current = Cursors.Default;
            Waiting.CloseWaitForm();
            this.Close();
        }

        private void txtPathName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog openFolder = new System.Windows.Forms.FolderBrowserDialog();
            openFolder.Description = "Chọn nơi Lưu trữ dữ liệu";
            openFolder.ShowDialog();           
            if (openFolder.SelectedPath != "")
                txtPathName.Text = openFolder.SelectedPath;
        }
 

    }
}