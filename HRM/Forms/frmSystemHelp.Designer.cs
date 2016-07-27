namespace HRM.Forms
{
    partial class frmSystemHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemHelp));
            this.txtHelp = new DevExpress.XtraEditors.MemoEdit();
            this.btnInstall = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtHelp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHelp
            // 
            this.txtHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHelp.EditValue = resources.GetString("txtHelp.EditValue");
            this.txtHelp.Location = new System.Drawing.Point(0, 0);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(635, 465);
            this.txtHelp.TabIndex = 0;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(537, 418);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(86, 35);
            this.btnInstall.TabIndex = 1;
            this.btnInstall.Text = "Cài Dll";
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // frmSystemHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 465);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.txtHelp);
            this.Name = "frmSystemHelp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Trợ giúp hướng dẫn cài đặt các dịch vụ";
            this.Load += new System.EventHandler(this.frmSystemHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtHelp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtHelp;
        private DevExpress.XtraEditors.SimpleButton btnInstall;
    }
}