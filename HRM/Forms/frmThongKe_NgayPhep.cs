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
    public partial class frmThongKe_NgayPhep : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKe_NgayPhep()
        {
            InitializeComponent();
        }

        void Load_TinhNgayPhepHienTai()
        {
            Class.ThongKe_NgayPhep tk = new Class.ThongKe_NgayPhep();
            if (tk.HRM_EMPLOYEE_DAYOFFYEAR_YearCount())
            {
                gridItem.DataSource = tk.HRM_EMPLOYEE_DAYOFFYEAR_Getlist();
            }

        }

        void Load_TinhNgayPhepBenh()
        {
            Class.ThongKe_NgayPhep tk = new Class.ThongKe_NgayPhep();
            if (tk.HRM_EMPLOYEE_DAYOFFMEDICAL_YearCount())
            {
                gridPB.DataSource = tk.HRM_EMPLOYEE_DAYOFFMEDICAL_Getlist();
            }

        }

        private void frmThongKe_NgayPhep_Load(object sender, EventArgs e)
        {
            Load_TinhNgayPhepHienTai();
            Load_TinhNgayPhepBenh();
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {          
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }

        private void gridPBDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }

        void LoadTheoNam(int nam)
        {
            Class.ThongKe_NgayPhep tk = new Class.ThongKe_NgayPhep();
           tk.Year = nam;
           gridPB.DataSource = tk.HRM_EMPLOYEE_DAYOFFMEDICAL_GetbyYear();
           gridItem.DataSource = tk.HRM_EMPLOYEE_DAYOFFYEAR_GetbyYear();
           
        }

        private void btnShowOld2014_Click(object sender, EventArgs e)
        {
            LoadTheoNam(2014);
        }

        private void btnShowNow_Click(object sender, EventArgs e)
        {
            Load_TinhNgayPhepHienTai();
            Load_TinhNgayPhepBenh();
        }

        private void btnShowOld2015_Click(object sender, EventArgs e)
        {
            LoadTheoNam(2015);
        }
    }
}