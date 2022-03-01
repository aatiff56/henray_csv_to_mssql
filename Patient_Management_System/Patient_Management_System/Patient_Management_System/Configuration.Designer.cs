
namespace Patient_Management_System
{
    partial class Configuration
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
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txt_UserId = new System.Windows.Forms.TextBox();
            this.lbl_UserId = new System.Windows.Forms.Label();
            this.lbl_Database = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.cmb_Database = new System.Windows.Forms.ComboBox();
            this.Btn_Start = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Fetch = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbl_Server_Validation = new DevExpress.XtraEditors.LabelControl();
            this.lblDatabase_Validation = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Password_Validation = new DevExpress.XtraEditors.LabelControl();
            this.lbl_user_validation = new DevExpress.XtraEditors.LabelControl();
            this.Btn_View_CSV = new DevExpress.XtraEditors.SimpleButton();
            this.gc_Configuration = new DevExpress.XtraEditors.GroupControl();
            this.chk_authentication = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gc_BrowseFile = new DevExpress.XtraEditors.GroupControl();
            this.lbl_ImportFile = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Progress = new DevExpress.XtraEditors.LabelControl();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Btn_Import = new DevExpress.XtraEditors.SimpleButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Configuration)).BeginInit();
            this.gc_Configuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_authentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_BrowseFile)).BeginInit();
            this.gc_BrowseFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblServerName.Location = new System.Drawing.Point(101, 59);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(111, 21);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Server Name:";
            // 
            // txtServerName
            // 
            this.txtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtServerName.Location = new System.Drawing.Point(218, 56);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(283, 28);
            this.txtServerName.TabIndex = 1;
            // 
            // txt_UserId
            // 
            this.txt_UserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_UserId.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_UserId.Location = new System.Drawing.Point(218, 160);
            this.txt_UserId.Name = "txt_UserId";
            this.txt_UserId.Size = new System.Drawing.Size(283, 28);
            this.txt_UserId.TabIndex = 3;
            // 
            // lbl_UserId
            // 
            this.lbl_UserId.AutoSize = true;
            this.lbl_UserId.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbl_UserId.Location = new System.Drawing.Point(121, 163);
            this.lbl_UserId.Name = "lbl_UserId";
            this.lbl_UserId.Size = new System.Drawing.Size(91, 21);
            this.lbl_UserId.TabIndex = 2;
            this.lbl_UserId.Text = "Username:";
            // 
            // lbl_Database
            // 
            this.lbl_Database.AutoSize = true;
            this.lbl_Database.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbl_Database.Location = new System.Drawing.Point(125, 321);
            this.lbl_Database.Name = "lbl_Database";
            this.lbl_Database.Size = new System.Drawing.Size(87, 21);
            this.lbl_Database.TabIndex = 6;
            this.lbl_Database.Text = "Database:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPassword.Location = new System.Drawing.Point(218, 216);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(283, 28);
            this.txtPassword.TabIndex = 5;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbl_Password.Location = new System.Drawing.Point(125, 220);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(87, 21);
            this.lbl_Password.TabIndex = 4;
            this.lbl_Password.Text = "Password:";
            // 
            // cmb_Database
            // 
            this.cmb_Database.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Database.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmb_Database.FormattingEnabled = true;
            this.cmb_Database.Location = new System.Drawing.Point(218, 318);
            this.cmb_Database.Name = "cmb_Database";
            this.cmb_Database.Size = new System.Drawing.Size(283, 29);
            this.cmb_Database.TabIndex = 11;
            // 
            // Btn_Start
            // 
            this.Btn_Start.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_Start.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Btn_Start.Appearance.Options.UseFont = true;
            this.Btn_Start.Location = new System.Drawing.Point(419, 98);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(82, 28);
            this.Btn_Start.TabIndex = 13;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Fetch
            // 
            this.Btn_Fetch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Fetch.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Btn_Fetch.Appearance.Options.UseFont = true;
            this.Btn_Fetch.Location = new System.Drawing.Point(419, 265);
            this.Btn_Fetch.Name = "Btn_Fetch";
            this.Btn_Fetch.Size = new System.Drawing.Size(82, 28);
            this.Btn_Fetch.TabIndex = 14;
            this.Btn_Fetch.Text = "Fetch ";
            this.Btn_Fetch.Click += new System.EventHandler(this.Btn_FetchDatabase_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // lbl_Server_Validation
            // 
            this.lbl_Server_Validation.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbl_Server_Validation.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_Server_Validation.Appearance.Options.UseFont = true;
            this.lbl_Server_Validation.Appearance.Options.UseForeColor = true;
            this.lbl_Server_Validation.Location = new System.Drawing.Point(219, 31);
            this.lbl_Server_Validation.Name = "lbl_Server_Validation";
            this.lbl_Server_Validation.Size = new System.Drawing.Size(0, 18);
            this.lbl_Server_Validation.TabIndex = 15;
            // 
            // lblDatabase_Validation
            // 
            this.lblDatabase_Validation.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDatabase_Validation.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblDatabase_Validation.Appearance.Options.UseFont = true;
            this.lblDatabase_Validation.Appearance.Options.UseForeColor = true;
            this.lblDatabase_Validation.Location = new System.Drawing.Point(219, 295);
            this.lblDatabase_Validation.Name = "lblDatabase_Validation";
            this.lblDatabase_Validation.Size = new System.Drawing.Size(0, 18);
            this.lblDatabase_Validation.TabIndex = 16;
            // 
            // lbl_Password_Validation
            // 
            this.lbl_Password_Validation.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbl_Password_Validation.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_Password_Validation.Appearance.Options.UseFont = true;
            this.lbl_Password_Validation.Appearance.Options.UseForeColor = true;
            this.lbl_Password_Validation.Location = new System.Drawing.Point(219, 194);
            this.lbl_Password_Validation.Name = "lbl_Password_Validation";
            this.lbl_Password_Validation.Size = new System.Drawing.Size(0, 18);
            this.lbl_Password_Validation.TabIndex = 17;
            // 
            // lbl_user_validation
            // 
            this.lbl_user_validation.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbl_user_validation.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_user_validation.Appearance.Options.UseFont = true;
            this.lbl_user_validation.Appearance.Options.UseForeColor = true;
            this.lbl_user_validation.Location = new System.Drawing.Point(219, 138);
            this.lbl_user_validation.Name = "lbl_user_validation";
            this.lbl_user_validation.Size = new System.Drawing.Size(0, 18);
            this.lbl_user_validation.TabIndex = 18;
            // 
            // Btn_View_CSV
            // 
            this.Btn_View_CSV.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_View_CSV.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Btn_View_CSV.Appearance.Options.UseFont = true;
            this.Btn_View_CSV.Location = new System.Drawing.Point(331, 98);
            this.Btn_View_CSV.Name = "Btn_View_CSV";
            this.Btn_View_CSV.Size = new System.Drawing.Size(82, 28);
            this.Btn_View_CSV.TabIndex = 19;
            this.Btn_View_CSV.Text = "Sample";
            this.Btn_View_CSV.Click += new System.EventHandler(this.Btn_View_CSV_Click);
            // 
            // gc_Configuration
            // 
            this.gc_Configuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc_Configuration.Controls.Add(this.chk_authentication);
            this.gc_Configuration.Controls.Add(this.label1);
            this.gc_Configuration.Controls.Add(this.txtServerName);
            this.gc_Configuration.Controls.Add(this.lblServerName);
            this.gc_Configuration.Controls.Add(this.lblDatabase_Validation);
            this.gc_Configuration.Controls.Add(this.lbl_Password_Validation);
            this.gc_Configuration.Controls.Add(this.Btn_Fetch);
            this.gc_Configuration.Controls.Add(this.cmb_Database);
            this.gc_Configuration.Controls.Add(this.lbl_Database);
            this.gc_Configuration.Controls.Add(this.lbl_user_validation);
            this.gc_Configuration.Controls.Add(this.lbl_Server_Validation);
            this.gc_Configuration.Controls.Add(this.txt_UserId);
            this.gc_Configuration.Controls.Add(this.lbl_UserId);
            this.gc_Configuration.Controls.Add(this.lbl_Password);
            this.gc_Configuration.Controls.Add(this.txtPassword);
            this.gc_Configuration.Location = new System.Drawing.Point(39, 9);
            this.gc_Configuration.Name = "gc_Configuration";
            this.gc_Configuration.Size = new System.Drawing.Size(563, 361);
            this.gc_Configuration.TabIndex = 20;
            this.gc_Configuration.Text = "Configuration";
            // 
            // chk_authentication
            // 
            this.chk_authentication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_authentication.Location = new System.Drawing.Point(218, 106);
            this.chk_authentication.Name = "chk_authentication";
            this.chk_authentication.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chk_authentication.Properties.Appearance.Options.UseFont = true;
            this.chk_authentication.Properties.Caption = "";
            this.chk_authentication.Size = new System.Drawing.Size(34, 24);
            this.chk_authentication.TabIndex = 20;
            this.chk_authentication.CheckedChanged += new System.EventHandler(this.chk_authentication_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(16, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Windows Authentication:";
            // 
            // gc_BrowseFile
            // 
            this.gc_BrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc_BrowseFile.Controls.Add(this.lbl_ImportFile);
            this.gc_BrowseFile.Controls.Add(this.lbl_Progress);
            this.gc_BrowseFile.Controls.Add(this.progressBar);
            this.gc_BrowseFile.Controls.Add(this.Btn_Import);
            this.gc_BrowseFile.Controls.Add(this.txtFile);
            this.gc_BrowseFile.Controls.Add(this.Btn_View_CSV);
            this.gc_BrowseFile.Controls.Add(this.Btn_Start);
            this.gc_BrowseFile.Location = new System.Drawing.Point(39, 395);
            this.gc_BrowseFile.Name = "gc_BrowseFile";
            this.gc_BrowseFile.Size = new System.Drawing.Size(563, 177);
            this.gc_BrowseFile.TabIndex = 21;
            this.gc_BrowseFile.Text = "Browse File";
            // 
            // lbl_ImportFile
            // 
            this.lbl_ImportFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ImportFile.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbl_ImportFile.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_ImportFile.Appearance.Options.UseFont = true;
            this.lbl_ImportFile.Appearance.Options.UseForeColor = true;
            this.lbl_ImportFile.Location = new System.Drawing.Point(65, 34);
            this.lbl_ImportFile.Name = "lbl_ImportFile";
            this.lbl_ImportFile.Size = new System.Drawing.Size(0, 18);
            this.lbl_ImportFile.TabIndex = 23;
            // 
            // lbl_Progress
            // 
            this.lbl_Progress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_Progress.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbl_Progress.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_Progress.Appearance.Options.UseFont = true;
            this.lbl_Progress.Appearance.Options.UseForeColor = true;
            this.lbl_Progress.Location = new System.Drawing.Point(61, 130);
            this.lbl_Progress.Name = "lbl_Progress";
            this.lbl_Progress.Size = new System.Drawing.Size(0, 18);
            this.lbl_Progress.TabIndex = 22;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 151);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(563, 25);
            this.progressBar.TabIndex = 21;
            // 
            // Btn_Import
            // 
            this.Btn_Import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Btn_Import.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Btn_Import.Appearance.Options.UseFont = true;
            this.Btn_Import.Location = new System.Drawing.Point(419, 57);
            this.Btn_Import.Name = "Btn_Import";
            this.Btn_Import.Size = new System.Drawing.Size(82, 28);
            this.Btn_Import.TabIndex = 20;
            this.Btn_Import.Text = "Import";
            this.Btn_Import.Click += new System.EventHandler(this.Btn_Import_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFile.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtFile.Location = new System.Drawing.Point(62, 57);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(351, 28);
            this.txtFile.TabIndex = 19;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 600);
            this.Controls.Add(this.gc_BrowseFile);
            this.Controls.Add(this.gc_Configuration);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(646, 640);
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Management";
            this.Load += new System.EventHandler(this.Configuration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Configuration)).EndInit();
            this.gc_Configuration.ResumeLayout(false);
            this.gc_Configuration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_authentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_BrowseFile)).EndInit();
            this.gc_BrowseFile.ResumeLayout(false);
            this.gc_BrowseFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txt_UserId;
        private System.Windows.Forms.Label lbl_UserId;
        private System.Windows.Forms.Label lbl_Database;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.ComboBox cmb_Database;
        private DevExpress.XtraEditors.SimpleButton Btn_Start;
        private DevExpress.XtraEditors.SimpleButton Btn_Fetch;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraEditors.LabelControl lbl_Server_Validation;
        private DevExpress.XtraEditors.LabelControl lblDatabase_Validation;
        private DevExpress.XtraEditors.LabelControl lbl_Password_Validation;
        private DevExpress.XtraEditors.LabelControl lbl_user_validation;
        private DevExpress.XtraEditors.SimpleButton Btn_View_CSV;
        private DevExpress.XtraEditors.GroupControl gc_Configuration;
        private DevExpress.XtraEditors.GroupControl gc_BrowseFile;
        private DevExpress.XtraEditors.SimpleButton Btn_Import;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ProgressBar progressBar;
        private DevExpress.XtraEditors.LabelControl lbl_Progress;
        private DevExpress.XtraEditors.LabelControl lbl_ImportFile;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit chk_authentication;
    }
}

