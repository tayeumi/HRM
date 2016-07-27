using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Management;
using DevExpress.Utils;
using System.Security.Cryptography;
using System.IO;
using HRM.Class;

namespace HRM
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textEdit3.Text = Class.App.EncryptString(textEdit1.Text, textEdit2.Text);
            textEdit4.Text = Class.App.DecryptString(textEdit3.Text, textEdit2.Text);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textEdit2.Text = Class.App.ChuyenSo(textEdit1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Key = "Win32_DiskDrive";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Key);
            try
            {
                foreach (ManagementObject share in searcher.Get())
                {
                    foreach (PropertyData PC in share.Properties)
                    {
                        if (PC.Value != null && PC.Value.ToString() != "")
                        {
                            if (PC.Name == "SerialNumber")
                            {
                               MessageBox.Show(PC.Value.ToString());
                                break;
                            }
                        }

                    }                 
                }
            }
            catch
            {


            }

        }
        public string GetHDDSerialNumber(string drive)
        {
            //check to see if the user provided a drive letter
            //if not default it to "C"
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            //create our ManagementObject, passing it the drive letter to the
            //DevideID using WQL
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            //bind our management object
            disk.Get();
            //return the serial number
            return disk["VolumeSerialNumber"].ToString();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            toolTipController1.SetToolTip(textEdit4, "ssssssss");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string[] dll = new string[]{"DevExpress.BonusSkins.v12.1.dll",
            "DevExpress.Charts.v12.1.Core.dll",
            "DevExpress.Data.v12.1.dll",
            "DevExpress.Office.v12.1.Core.dll",
            "DevExpress.PivotGrid.v12.1.Core.dll",  
            "DevExpress.Printing.v12.1.Core.dll",
            "DevExpress.Reports.v12.1.Designer.dll",
            "DevExpress.RichEdit.v12.1.Core.dll",
            "DevExpress.Utils.v12.1.dll",
            "DevExpress.Xpo.v12.1.dll",
            "DevExpress.XtraBars.v12.1.dll",
            "DevExpress.XtraCharts.v12.1.dll",
            "DevExpress.XtraCharts.v12.1.UI.dll",
            "DevExpress.XtraEditors.v12.1.dll",
            "DevExpress.XtraGrid.v12.1.dll",
            "DevExpress.XtraLayout.v12.1.dll",
            "DevExpress.XtraNavBar.v12.1.dll",
            "DevExpress.XtraPivotGrid.v12.1.dll",
            "DevExpress.XtraReports.v12.1.dll",
            "DevExpress.XtraReports.v12.1.Extensions.dll",
            "DevExpress.XtraRichEdit.v12.1.dll",
            "DevExpress.XtraTreeList.v12.1.dll",
            "DevExpress.XtraVerticalGrid.v12.1.dll",
            "DevExpress.XtraPrinting.v12.1.dll",
            "DevExpress.XtraWizard.v12.1.dll"};

            string source = textEdit5.Text;
            string des = textEdit6.Text;
            
            labelControl1.Text="0/"+dll.Length;
            try
            {
                for (int i = 0; i < dll.Length; i++)
                {
                    if(System.IO.File.Exists(des + dll[i].ToString()))
                        System.IO.File.Delete(des + dll[i].ToString());
                    labelControl1.Text = (i + 1).ToString() + "/" + dll.Length;
                    System.IO.File.Copy(source + dll[i].ToString(), des + dll[i].ToString());
                    Application.DoEvents();
                }
                MessageBox.Show("Sao chép xong");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sao chép lỗi: " + ex.Message);
            }
        }

        #region Giai Ma

        public static string CreateHashValue(String plaintext, int n)
        {
            HashAlgorithm hash;
            byte[] buf, result;
            buf = Encoding.ASCII.GetBytes(plaintext);
            hash = HashAlgorithm.Create("SHA256");
            result = hash.ComputeHash(buf);
            return BitConverter.ToString(result).Substring(0, n);
        }

        public static string DecryptByRC2(String encryptedtext, String Key, String IV)
        {
            //lay kich thuoc
            int i = 0;
            while (encryptedtext[i] != ' ')
            {
                i++;
            }
            String str = encryptedtext.Substring(0, i);
            int length = Int32.Parse(str);

            //đọc dữ liệu da ma hoa vào 1 mảng byte
            byte[] arrEncripted = Convert.FromBase64String(encryptedtext.Remove(0, i + 1));

            //tạo 1 thể hiện cho RC2
            RC2CryptoServiceProvider myRC2 = new RC2CryptoServiceProvider();

            //tạo khóa cho RC2
            myRC2.Key = Encoding.ASCII.GetBytes(CreateHashValue(Key, 16));
            myRC2.IV = Encoding.ASCII.GetBytes(CreateHashValue(IV, 8));

            //tạo một bộ mã hóa
            ICryptoTransform myRC2_Decryptor = myRC2.CreateDecryptor(myRC2.Key, myRC2.IV);

            //dữ liệu muốn giải mã được đưa vào một vùng nhớ
            MemoryStream memDecrypt = new MemoryStream(arrEncripted);
            //tạo 1 crypto stream
            CryptoStream DecryptCrypto = new CryptoStream(memDecrypt, myRC2_Decryptor, CryptoStreamMode.Read);

            //lấy lại dữ liệu từ crypto stream --> byte[]
            byte[] arrDecripted = new byte[length];
            DecryptCrypto.Read(arrDecripted, 0, arrDecripted.Length);

            //String kq = Convert.ToBase64String(arrDecripted,0,arrDecripted.Length, Base64FormattingOptions.InsertLineBreaks);
            String kq = Encoding.ASCII.GetString(arrDecripted);

            //dong cac stream
            DecryptCrypto.Close();
            memDecrypt.Close();
            return kq;
        }

        #endregion

        #region Ma Hoa

        public static string EncryptByRC2(String plaintext, String Key, String IV)
        {
            int size = plaintext.Length;

            //tạo 1 thể hiện cho RC2
            RC2CryptoServiceProvider myRC2 = new RC2CryptoServiceProvider();

            //tạo khóa cho RC2
            myRC2.Key = Encoding.ASCII.GetBytes(CreateHashValue(Key, 16));
            myRC2.IV = Encoding.ASCII.GetBytes(CreateHashValue(IV, 8));

            //tạo một bộ mã hóa
            ICryptoTransform myRC2_Ecryptor = myRC2.CreateEncryptor(myRC2.Key, myRC2.IV);

            //dữ liệu muốn mã hóa được đưa vào một vùng nhớ
            MemoryStream memEncrypt = new MemoryStream();
            //tạo 1 crypto stream
            CryptoStream EncryptCrypto = new CryptoStream(memEncrypt, myRC2_Ecryptor, CryptoStreamMode.Write);

            //đọc dữ liệu vào 1 mảng byte
            byte[] arrEncript = Encoding.ASCII.GetBytes(plaintext);

            //ghi tất cả dữ liệu mã hóa xuống crypto stream
            EncryptCrypto.Write(arrEncript, 0, arrEncript.Length);
            EncryptCrypto.FlushFinalBlock();

            //lấy dữ liệu đã mã hóa ra tử vùng nhớ byte[] = memEncrypt.ToArray()
            byte[] arrEncripted = memEncrypt.ToArray();

            String kq = plaintext.Length + " " + Convert.ToBase64String(arrEncripted, 0, arrEncripted.Length, Base64FormattingOptions.InsertLineBreaks);

            memEncrypt.Close();
            EncryptCrypto.Close();
            return kq;
        }

        #endregion 

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //string txt = DecryptByRC2(textEdit7.Text, "ABCDEFGHIJKLMNOP", "");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           // string txt = EncryptByRC2(textEdit7.Text, "ABCDEFGHIJKLMNOP", "");
            byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            byte[] iv = { 8, 7, 6, 5, 4, 3, 2, 1 };

            Encryption enc = new Encryption(key, iv);
            textEdit7.Text = enc.Decrypt("0x06");
            Console.WriteLine(enc.Encrypt("test"));
            Console.WriteLine(enc.Decrypt((string)enc.Encrypt("test")));

            Console.ReadLine();
        }
    }
}
