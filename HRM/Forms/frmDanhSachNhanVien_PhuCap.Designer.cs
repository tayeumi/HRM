namespace HRM.Forms
{
    partial class frmDanhSachNhanVien_PhuCap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnThemPhuCap = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // btnThemPhuCap
            // 
            this.btnThemPhuCap.Location = new System.Drawing.Point(98, 95);
            this.btnThemPhuCap.Name = "btnThemPhuCap";
            this.btnThemPhuCap.Size = new System.Drawing.Size(80, 31);
            this.btnThemPhuCap.TabIndex = 0;
            this.btnThemPhuCap.Text = "Thêm";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Nhân viên :";
            // 
            // frmDanhSachNhanVien_PhuCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 139);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnThemPhuCap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhSachNhanVien_PhuCap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmDanhSachNhanVien_PhuCap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnThemPhuCap;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}