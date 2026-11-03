namespace DVLD_System_Solution.Forms._003_Applications_Managements._002_FirstTimeDrivingLicenesApplication_Screen
{
    partial class frmFirstTimeDrivingLicenesApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFirstTimeDrivingLicenesApplication));
            this.label3 = new System.Windows.Forms.Label();
            this.comBox_LicenseClasses = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lab_MinimumAgeForLicenseClass = new System.Windows.Forms.Label();
            this.txt_ApplicationPaidFees = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.uconApplicationDetails1 = new DVLD_System_Solution.Forms._003_Applications_Managements._001_User_Controls.uconApplicationDetails();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 33);
            this.label3.TabIndex = 260;
            this.label3.Text = "License Class:";
            // 
            // comBox_LicenseClasses
            // 
            this.comBox_LicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_LicenseClasses.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_LicenseClasses.FormattingEnabled = true;
            this.comBox_LicenseClasses.Location = new System.Drawing.Point(14, 87);
            this.comBox_LicenseClasses.Name = "comBox_LicenseClasses";
            this.comBox_LicenseClasses.Size = new System.Drawing.Size(378, 24);
            this.comBox_LicenseClasses.TabIndex = 259;
            this.comBox_LicenseClasses.SelectedIndexChanged += new System.EventHandler(this.comBox_LicenseClasses_SelectedIndexChanged);
            this.comBox_LicenseClasses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comBox_LicenseClasses_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lab_MinimumAgeForLicenseClass);
            this.groupBox1.Controls.Add(this.txt_ApplicationPaidFees);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comBox_LicenseClasses);
            this.groupBox1.Font = new System.Drawing.Font("Sitka Small", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox1.ForeColor = System.Drawing.Color.Brown;
            this.groupBox1.Location = new System.Drawing.Point(12, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 257);
            this.groupBox1.TabIndex = 261;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service-Specific Section";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Sitka Small", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(6, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 33);
            this.label10.TabIndex = 273;
            this.label10.Text = "Minimum Age:";
            // 
            // lab_MinimumAgeForLicenseClass
            // 
            this.lab_MinimumAgeForLicenseClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_MinimumAgeForLicenseClass.AutoSize = true;
            this.lab_MinimumAgeForLicenseClass.Font = new System.Drawing.Font("Tahoma", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lab_MinimumAgeForLicenseClass.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_MinimumAgeForLicenseClass.Location = new System.Drawing.Point(197, 123);
            this.lab_MinimumAgeForLicenseClass.Name = "lab_MinimumAgeForLicenseClass";
            this.lab_MinimumAgeForLicenseClass.Size = new System.Drawing.Size(66, 36);
            this.lab_MinimumAgeForLicenseClass.TabIndex = 274;
            this.lab_MinimumAgeForLicenseClass.Text = "???";
            // 
            // txt_ApplicationPaidFees
            // 
            this.txt_ApplicationPaidFees.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_ApplicationPaidFees.Location = new System.Drawing.Point(144, 188);
            this.txt_ApplicationPaidFees.Name = "txt_ApplicationPaidFees";
            this.txt_ApplicationPaidFees.Size = new System.Drawing.Size(248, 24);
            this.txt_ApplicationPaidFees.TabIndex = 262;
            this.txt_ApplicationPaidFees.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_ApplicationPaidFees_MouseClick);
            this.txt_ApplicationPaidFees.TextChanged += new System.EventHandler(this.txt_ApplicationPaidFees_TextChanged);
            this.txt_ApplicationPaidFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ApplicationPaidFees_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(6, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 33);
            this.label1.TabIndex = 261;
            this.label1.Text = "Paid Fees:";
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.Location = new System.Drawing.Point(12, 626);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(118, 39);
            this.btn_Close.TabIndex = 263;
            this.btn_Close.Text = "  Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Save.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Save.Image = global::DVLD_System_Solution.Properties.Resources.Save1_32;
            this.btn_Save.Location = new System.Drawing.Point(599, 626);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(124, 39);
            this.btn_Save.TabIndex = 262;
            this.btn_Save.Text = "  Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 700;
            this.errorProvider1.ContainerControl = this;
            // 
            // uconApplicationDetails1
            // 
            this.uconApplicationDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uconApplicationDetails1.Location = new System.Drawing.Point(12, 12);
            this.uconApplicationDetails1.Name = "uconApplicationDetails1";
            this.uconApplicationDetails1.Size = new System.Drawing.Size(711, 321);
            this.uconApplicationDetails1.TabIndex = 264;
            // 
            // frmFirstTimeDrivingLicenesApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(735, 677);
            this.Controls.Add(this.uconApplicationDetails1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 716);
            this.MinimumSize = new System.Drawing.Size(751, 716);
            this.Name = "frmFirstTimeDrivingLicenesApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First Time Driving Licenes Application";
            this.Load += new System.EventHandler(this.frmFirstTimeDrivingLicenesApplication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comBox_LicenseClasses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ApplicationPaidFees;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private _001_User_Controls.uconApplicationDetails uconApplicationDetails1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lab_MinimumAgeForLicenseClass;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}