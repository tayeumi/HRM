namespace HRM.Forms
{
    partial class frmPopupThongBaoMoi
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
            this.components = new System.ComponentModel.Container();
            this.txtThongBao = new DevExpress.XtraEditors.MemoEdit();
            this.timeoutform = new System.Windows.Forms.Timer(this.components);
            this.timestart = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtThongBao.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtThongBao
            // 
            this.txtThongBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtThongBao.Location = new System.Drawing.Point(0, 0);
            this.txtThongBao.Name = "txtThongBao";
            this.txtThongBao.Properties.ReadOnly = true;
            this.txtThongBao.Size = new System.Drawing.Size(264, 91);
            this.txtThongBao.TabIndex = 0;
            // 
            // timeoutform
            // 
            this.timeoutform.Interval = 10000;
            this.timeoutform.Tick += new System.EventHandler(this.timeoutform_Tick);
            // 
            // timestart
            // 
            this.timestart.Interval = 1000;
            this.timestart.Tick += new System.EventHandler(this.timestart_Tick);
            // 
            // frmPopupThongBaoMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 91);
            this.Controls.Add(this.txtThongBao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPopupThongBaoMoi";
            this.Opacity = 0.1D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Thông báo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPopupThongBaoMoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtThongBao.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtThongBao;
        private System.Windows.Forms.Timer timeoutform;
        private System.Windows.Forms.Timer timestart;
    }
}