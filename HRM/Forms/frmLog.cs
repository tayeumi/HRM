using System;
using System.IO;
using System.Windows.Forms;

namespace HRM.Forms
{
    public partial class frmLog : DevExpress.XtraEditors.XtraForm
    {
        public frmLog()
        {
            InitializeComponent();
        }
        string template_grid = Application.StartupPath + @"\Templates\Templates_Log.xml";
        private void frmLog_Load(object sender, EventArgs e)
        {
            if (File.Exists(template_grid))
            {
                // gridItemDetail.SaveLayoutToXml(template_grid);
                gridItemDetail.RestoreLayoutFromXml(template_grid);
            }
            Get_LogSystem();
        }

        private void Get_LogSystem()
        {
            gridItem.DataSource = Class.S_Log.Log_HeThong();
            gridItemDetail.ExpandAllGroups();
        }

        private void btnCallHistory_Click(object sender, EventArgs e)
        {
            Get_LogSystem();
        }

        private void btnCallClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLog_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            try
            {
                gridItemDetail.SaveLayoutToXml(template_grid);
            }
            catch { }
        }
    }
}