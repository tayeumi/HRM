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
    public partial class frmDanhSachNhanVien_ThayDoiChucVu : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachNhanVien_ThayDoiChucVu()
        {
            InitializeComponent();
        }
        object[] _emCode;
        public frmDanhSachNhanVien_ThayDoiChucVu(object[] EmCode, DataTable dt)
        {
            InitializeComponent();
            GetList_Position();
            _emCode = EmCode;
            string em = "";
            for (int i = 0; i < EmCode.Length; i++)
            {
                em += EmCode[i].ToString() + ",";
            }
            em = em.TrimEnd(',');
            lblDanhSach.Text = "Đang chọn:(" + EmCode.Length + ") " + em;
            string _name = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < EmCode.Length; j++)
                {
                    if (EmCode[j].ToString() == dt.Rows[i]["EmployeeCode"].ToString())
                    {
                        _name += dt.Rows[i]["FirstName"].ToString() + " " + dt.Rows[i]["LastName"].ToString() + ",";
                    }
                }
            }
            _name = _name.TrimEnd(',');
            lblDanhSach.ToolTip = "Đang chọn: (" + EmCode.Length + ") " + _name;

            string tb = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < EmCode.Length; j++)
                {
                    if (EmCode[j].ToString() == dt.Rows[i]["EmployeeCode"].ToString())
                    {
                        tb += dt.Rows[i]["EmployeeCode"].ToString() + ":" + dt.Rows[i]["FirstName"].ToString() + " " + dt.Rows[i]["LastName"].ToString() + "\r\n";
                    }
                }
            }
            alertControl.Show(this, "Danh sách Nhân viên đang chọn: " + EmCode.Length, tb);
        }

        public void GetList_Position()
        {
            Class.DanhMuc_ChucVu dm = new Class.DanhMuc_ChucVu();
            DataTable dt = dm.GetAllList_POSITION();
            txtPosition.Properties.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtPosition.Properties.Items.Add(dt.Rows[i]["PositionName"].ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPosition.SelectedIndex < 1)
                return;
            Class.NhanVien nv = new Class.NhanVien();
            nv.Position = txtPosition.Text;
            if (nv.HRM_EMPLOYEE_Update_PositionFast(_emCode))
            {
                Class.App.SaveSuccessfully();
            }
            else
            {
                Class.App.SaveNotSuccessfully();
            }           
            (this.Owner as frmDanhSachNhanVien).loaddsNhanVien();
            this.Close();

        }
    }
}