using System;
using System.Windows.Forms;
using System.Media;

namespace HRM.Forms
{
    public partial class frmPopupThongBaoMoi : DevExpress.XtraEditors.XtraForm
    {
        public frmPopupThongBaoMoi()
        {
            InitializeComponent();
        }

        public frmPopupThongBaoMoi(string[] noidung)
        {
            InitializeComponent();
            for (int i = 0; i < noidung.Length; i++)
            {
                txtThongBao.Text += noidung[i].ToString();
            }
        }

        private void timeoutform_Tick(object sender, EventArgs e)
        {
            timeoutform.Interval = 80;
            if (this.Opacity > 0.01)
            {
                this.Opacity = this.Opacity - 0.05;
            }
            else
            {
                timeoutform.Enabled = false;
                this.Close();
            }
        }

        private void frmPopupThongBaoMoi_Load(object sender, EventArgs e)
        {
             // Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
               // this.Left = (scr.WorkingArea.Width – this.Width)/2;
                //this.Top = (scr.WordkingArea.Height – this.Height)/2;
              this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width -10;
              this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height -30;
            timestart.Enabled = true;
            if(System.IO.File.Exists(@"media/"+Class.App.media))
            {
                SoundPlayer simpleSound = new SoundPlayer(@"media/" + Class.App.media);
                 simpleSound.Play();
            }
        }

        private void timestart_Tick(object sender, EventArgs e)
        {
            timestart.Interval = 80;
            if (this.Opacity < 1)
            {
                this.Opacity =this.Opacity+ 0.05;
            }
            else
            {
            timeoutform.Enabled = true;
            timestart.Enabled = false;
            }
           
        }
    }
}