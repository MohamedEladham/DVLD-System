namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    partial class frmUpdatePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdatePassword));
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_NewPassword = new System.Windows.Forms.TextBox();
            this.lab_UpdatePassword = new System.Windows.Forms.Label();
            this.lab_UserIDToText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_PersonIDToText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.picB_ShowHidePassword = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_ShowHidePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(12, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 19);
            this.label5.TabIndex = 250;
            this.label5.Text = "Confirm Password:";
            // 
            // txt_ConfirmPassword
            // 
            this.txt_ConfirmPassword.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_ConfirmPassword.Location = new System.Drawing.Point(216, 282);
            this.txt_ConfirmPassword.MaxLength = 50;
            this.txt_ConfirmPassword.Name = "txt_ConfirmPassword";
            this.txt_ConfirmPassword.Size = new System.Drawing.Size(429, 24);
            this.txt_ConfirmPassword.TabIndex = 248;
            this.txt_ConfirmPassword.UseSystemPasswordChar = true;
            this.txt_ConfirmPassword.Click += new System.EventHandler(this.txt_Password_Click);
            this.txt_ConfirmPassword.TextChanged += new System.EventHandler(this.txt_Password_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(13, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 19);
            this.label4.TabIndex = 247;
            this.label4.Text = "New Password:";
            // 
            // txt_NewPassword
            // 
            this.txt_NewPassword.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_NewPassword.Location = new System.Drawing.Point(215, 234);
            this.txt_NewPassword.MaxLength = 50;
            this.txt_NewPassword.Name = "txt_NewPassword";
            this.txt_NewPassword.Size = new System.Drawing.Size(430, 24);
            this.txt_NewPassword.TabIndex = 245;
            this.txt_NewPassword.UseSystemPasswordChar = true;
            this.txt_NewPassword.Click += new System.EventHandler(this.txt_Password_Click);
            this.txt_NewPassword.TextChanged += new System.EventHandler(this.txt_Password_TextChanged);
            // 
            // lab_UpdatePassword
            // 
            this.lab_UpdatePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_UpdatePassword.AutoSize = true;
            this.lab_UpdatePassword.Font = new System.Drawing.Font("Sitka Small", 33F, System.Drawing.FontStyle.Bold);
            this.lab_UpdatePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lab_UpdatePassword.Location = new System.Drawing.Point(166, 35);
            this.lab_UpdatePassword.Name = "lab_UpdatePassword";
            this.lab_UpdatePassword.Size = new System.Drawing.Size(432, 65);
            this.lab_UpdatePassword.TabIndex = 242;
            this.lab_UpdatePassword.Text = "Update Password";
            this.lab_UpdatePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_UserIDToText
            // 
            this.lab_UserIDToText.AutoSize = true;
            this.lab_UserIDToText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_UserIDToText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lab_UserIDToText.Location = new System.Drawing.Point(215, 189);
            this.lab_UserIDToText.Name = "lab_UserIDToText";
            this.lab_UserIDToText.Size = new System.Drawing.Size(36, 19);
            this.lab_UserIDToText.TabIndex = 257;
            this.lab_UserIDToText.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 256;
            this.label3.Text = "User ID: ";
            // 
            // lab_PersonIDToText
            // 
            this.lab_PersonIDToText.AutoSize = true;
            this.lab_PersonIDToText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_PersonIDToText.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_PersonIDToText.Location = new System.Drawing.Point(215, 145);
            this.lab_PersonIDToText.Name = "lab_PersonIDToText";
            this.lab_PersonIDToText.Size = new System.Drawing.Size(36, 19);
            this.lab_PersonIDToText.TabIndex = 254;
            this.lab_PersonIDToText.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 253;
            this.label1.Text = "Person ID: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System_Solution.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(180, 186);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 255;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD_System_Solution.Properties.Resources.Number_32;
            this.pictureBox10.Location = new System.Drawing.Point(180, 142);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(23, 24);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 252;
            this.pictureBox10.TabStop = false;
            // 
            // picB_ShowHidePassword
            // 
            this.picB_ShowHidePassword.Image = global::DVLD_System_Solution.Properties.Resources.Hide_Passowrd_32;
            this.picB_ShowHidePassword.Location = new System.Drawing.Point(665, 230);
            this.picB_ShowHidePassword.Name = "picB_ShowHidePassword";
            this.picB_ShowHidePassword.Size = new System.Drawing.Size(32, 32);
            this.picB_ShowHidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picB_ShowHidePassword.TabIndex = 251;
            this.picB_ShowHidePassword.TabStop = false;
            this.picB_ShowHidePassword.Click += new System.EventHandler(this.picB_ShowHidePassword_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_System_Solution.Properties.Resources.Password_32;
            this.pictureBox4.Location = new System.Drawing.Point(180, 282);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 249;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_System_Solution.Properties.Resources.Password_32;
            this.pictureBox3.Location = new System.Drawing.Point(180, 234);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 246;
            this.pictureBox3.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Close.Location = new System.Drawing.Point(12, 334);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 39);
            this.btn_Close.TabIndex = 244;
            this.btn_Close.Text = "    Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click_1);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Save.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Save.Image = global::DVLD_System_Solution.Properties.Resources.Save1_32;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Save.Location = new System.Drawing.Point(635, 334);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 39);
            this.btn_Save.TabIndex = 243;
            this.btn_Save.Text = "    Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(617, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(153, 110);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 241;
            this.pictureBox11.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmUpdatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 386);
            this.Controls.Add(this.lab_UserIDToText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_PersonIDToText);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picB_ShowHidePassword);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_ConfirmPassword);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_NewPassword);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lab_UpdatePassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(798, 425);
            this.MinimumSize = new System.Drawing.Size(798, 425);
            this.Name = "frmUpdatePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Password";
            this.Load += new System.EventHandler(this.frmUpdatePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_ShowHidePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picB_ShowHidePassword;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ConfirmPassword;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_NewPassword;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_UpdatePassword;
        private System.Windows.Forms.Label lab_UserIDToText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_PersonIDToText;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}