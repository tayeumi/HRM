using System;
using System.Windows.Forms;
using System.IO;

namespace HRM.Forms
{
    public partial class frmThongKe_SinhNhat : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKe_SinhNhat()
        {
            InitializeComponent();
        }
        string template_grid = Application.StartupPath + @"\Templates\Templates_TKSN.xml";
        private void frmThongKe_SinhNhat_Load(object sender, EventArgs e)
        {
            if (File.Exists(template_grid))
            {
                // gridItemDetail.SaveLayoutToXml(template_grid);
                gridItemDetail.RestoreLayoutFromXml(template_grid);
            }
            txtMonth.EditValue = DateTime.Now.Month.ToString();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {           
            Class.ThongKe tk = new Class.ThongKe();
            gridItem.DataSource = tk.HRM_EMPLOYEE_GetListBirthdayByMonth(int.Parse(txtMonth.EditValue.ToString()));
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File|*.xlsx";
            saveFile.Title = "Exprot to Excel File";
            saveFile.ShowDialog();

            if (saveFile.FileName != "")
                gridItem.ExportToXlsx(saveFile.FileName);
        }

        private void frmThongKe_SinhNhat_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                gridItemDetail.SaveLayoutToXml(template_grid);
            }
            catch { }
        }
    }
}