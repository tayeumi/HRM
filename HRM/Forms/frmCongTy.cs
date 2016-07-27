using System;
using System.Data;
using System.Drawing;
using System.IO;

namespace HRM.Forms
{
    public partial class frmCongTy : DevExpress.XtraEditors.XtraForm
    {
        public frmCongTy()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCongTy_Load(object sender, EventArgs e)
        {
            Get_Comapy_Info();
        }
        private void Get_Comapy_Info()
        {
            Class.CongTy ct = new Class.CongTy();
            DataTable dt = ct.LoadThongTinCty();
            txtCompanyID.Text = dt.Rows[0]["CompanyID"].ToString();
            txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
            txtCompanyAddress.Text = dt.Rows[0]["CompanyAddress"].ToString();
            txtTel.Text = dt.Rows[0]["Tel"].ToString();
            txtFax.Text = dt.Rows[0]["Fax"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtWebsite.Text = dt.Rows[0]["Website"].ToString();
            txtCompanyTax.Text = dt.Rows[0]["CompanyTax"].ToString();
            // xu ly photo   
            try
            {
                if (dt.Rows[0]["Logo"] != null)
                {
                    Byte[] imgbyte = (byte[])dt.Rows[0]["Logo"];
                    if (imgbyte.Length > 10)
                    {
                        MemoryStream stmPicData = new MemoryStream(imgbyte);
                        Logo.Image = Image.FromStream(stmPicData);
                    }
                    //
                }
            }
            catch { }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Class.CongTy ct = new Class.CongTy();
            ct.CompanyID = txtCompanyID.Text;
            ct.CompanyName = txtCompanyName.Text;
            ct.CompanyAddress = txtCompanyAddress.Text;
            ct.Tel = txtTel.Text;
            ct.Fax = txtFax.Text;
            ct.Email = txtEmail.Text;
            ct.WebSite = txtWebsite.Text;
            ct.CompanyTax = txtCompanyTax.Text;           
                 // xu ly Photo
            if (Logo.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                Logo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] bytImage = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(bytImage, 0, Convert.ToInt32(ms.Length));
                ct.Logo = bytImage;
            }
            else
            {
                MemoryStream ms = new MemoryStream(5);
                Byte[] bytImage = new Byte[ms.Length];
                ct.Logo = bytImage;
            }
            if (ct.Update())
            {
                Class.App.SaveSuccessfully();
                this.Close();
            }
            else
            {
                Class.App.SaveNotSuccessfully();
            }

        }
    }
}