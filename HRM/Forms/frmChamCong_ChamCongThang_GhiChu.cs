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
    public partial class frmChamCong_ChamCongThang_GhiChu : DevExpress.XtraEditors.XtraForm
    {
        public frmChamCong_ChamCongThang_GhiChu()
        {
            InitializeComponent();
        }
        string _TimeKeeperTableListID;
        string _EmployeeCode;
        string _Day;
        bool _New;
        public frmChamCong_ChamCongThang_GhiChu(string TimeKeeperTableListID, string EmployeeCode,string Day,bool New)
        {
            InitializeComponent();
            _TimeKeeperTableListID = TimeKeeperTableListID;
            _EmployeeCode = EmployeeCode;
            _Day = Day;
            _New = New;
            if(!New)
            {
                Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                cct.TimeKeeperTableListID = TimeKeeperTableListID;
                cct.EmployeeCode = EmployeeCode;
                cct.Day = Day;
                DataTable dt = cct.HRM_TIMEKEEPER_TABLE_COMMENT_Get();
                if (dt.Rows.Count > 0)
                {
                    string txt= dt.Rows[0]["Description"].ToString();
                    if(txt.IndexOf("\r\n")>0)
                    {
                      txt=  txt.Substring(txt.IndexOf("\r\n"));
                    }

                    txtComment.Text = txt.Trim();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtComment.Text.Length >1)
            {
                Class.ChamCong_ChamCongThang cct = new Class.ChamCong_ChamCongThang();
                cct.TimeKeeperTableListID = _TimeKeeperTableListID;
                cct.EmployeeCode = _EmployeeCode;
                cct.Day = _Day;
                cct.Description =Class.App.client_User + ": \r\n"+ txtComment.Text;

                if (_New)
                {
                    // tao moi
                    if (cct.HRM_TIMEKEEPER_TABLE_COMMENT_Insert())
                    {
                        MessageBox.Show("Thêm ghi chú thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Thêm ghi chú thất bại !");

                    }

                }
                else
                {
                    // update
                    if (cct.HRM_TIMEKEEPER_TABLE_COMMENT_Update())
                    {
                        MessageBox.Show("Cập nhật ghi chú thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật ghi chú thất bại !");
                    }

                }

            }
            this.Close();
        }

        private void frmChamCong_ChamCongThang_GhiChu_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}