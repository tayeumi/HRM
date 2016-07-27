using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HRM.Forms
{
    public partial class frmReportDesign : DevExpress.XtraEditors.XtraForm
    {
        public frmReportDesign()
        {
            InitializeComponent();
        }

        private void btnDesignHDLD_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
             Waiting.ShowWaitForm();
            if (!_checkControl("frmReportDesign_HDLD"))
            {
                frmReportDesign_HDLD frm = new frmReportDesign_HDLD();
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                pControls.Controls.Add(frm);
                frm.Show();
            }
              Waiting.CloseWaitForm();
        }
        #region KiemTraFormOpen And ReShow

        private bool _checkControl(string frmForm)
        {
            for (int i = 0; i < pControls.Controls.Count; i++)
            {
                if (pControls.Controls[i].Text == frmForm)
                {
                    pControls.Controls[i].Show();
                    // pControls.Controls[i].Size = new System.Drawing.Size(pControls.Width, pControls.Height);
                    return true;
                }
                else
                {
                    pControls.Controls[i].Hide();
                }
            }
            return false;
        }
        #endregion
    }
}