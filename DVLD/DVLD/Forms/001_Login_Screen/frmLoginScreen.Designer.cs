namespace Main_Screen.Forms._001_Login_Screen
{
    partial class frmLoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginScreen));
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.lab_Name = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_LoginScreen = new System.Windows.Forms.Label();
            this.checkBox_RememberMe = new System.Windows.Forms.CheckBox();
            this.lab_LoginResult = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.picB_ShowHidePassword = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_LogoScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_ShowHidePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LogoScreen)).BeginInit();
            this.SuspendLayout();
            //
            // txt_UserName
            //
            this.txt_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_UserName.BackColor = System.Drawing.Color.GhostWhite;
            this.txt_UserName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_UserName.ForeColor = System.Drawing.Color.Black;
            this.txt_UserName.Location = new System.Drawing.Point(496, 202);
            this.txt_UserName.MaxLength = 50;
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(363, 25);
            this.txt_UserName.TabIndex = 0;
            this.txt_UserName.MouseClick += new System.Windows.Forms.MouseEventHandler(this._ClearErrorProviderOn_MouseClick);
            this.txt_UserName.TextChanged += new System.EventHandler(this._ClearErrorProviderOn_TextChanged);
            //
            // lab_Name
            //
            this.lab_Name.AutoSize = true;
            this.lab_Name.BackColor = System.Drawing.Color.Transparent;
            this.lab_Name.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_Name.ForeColor = System.Drawing.Color.White;
            this.lab_Name.Location = new System.Drawing.Point(357, 205);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(104, 19);
            this.lab_Name.TabIndex = 205;
            this.lab_Name.Text = "User Name:";
            this.lab_Name.MouseDown += new System.Windows.Forms.MouseEventHandler(this._FrmLogin_MouseDown);
            //
            // txt_Password
            //
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.BackColor = System.Drawing.Color.GhostWhite;
            this.txt_Password.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_Password.ForeColor = System.Drawing.Color.Black;
            this.txt_Password.Location = new System.Drawing.Point(496, 262);
            this.txt_Password.MaxLength = 50;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(363, 25);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.UseSystemPasswordChar = true;
            this.txt_Password.MouseClick += new System.Windows.Forms.MouseEventHandler(this._ClearErrorProviderOn_MouseClick);
            this.txt_Password.TextChanged += new System.EventHandler(this._ClearErrorProviderOn_TextChanged);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(357, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this._FrmLogin_MouseDown);
            //
            // lab_LoginScreen
            //
            this.lab_LoginScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_LoginScreen.AutoSize = true;
            this.lab_LoginScreen.Font = new System.Drawing.Font("Perpetua", 40F, System.Drawing.FontStyle.Bold);
            this.lab_LoginScreen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lab_LoginScreen.Location = new System.Drawing.Point(467, 99);
            this.lab_LoginScreen.Name = "lab_LoginScreen";
            this.lab_LoginScreen.Size = new System.Drawing.Size(312, 62);
            this.lab_LoginScreen.TabIndex = 211;
            this.lab_LoginScreen.Text = "Login Screes";
            this.lab_LoginScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_LoginScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this._FrmLogin_MouseDown);
            //
            // checkBox_RememberMe
            //
            this.checkBox_RememberMe.AutoSize = true;
            this.checkBox_RememberMe.Font = new System.Drawing.Font("Tahoma", 10F);
            this.checkBox_RememberMe.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.checkBox_RememberMe.Location = new System.Drawing.Point(728, 394);
            this.checkBox_RememberMe.Name = "checkBox_RememberMe";
            this.checkBox_RememberMe.Size = new System.Drawing.Size(119, 21);
            this.checkBox_RememberMe.TabIndex = 4;
            this.checkBox_RememberMe.Text = "Remember Me.";
            this.checkBox_RememberMe.UseVisualStyleBackColor = true;
            //
            // lab_LoginResult
            //
            this.lab_LoginResult.AutoSize = true;
            this.lab_LoginResult.BackColor = System.Drawing.Color.Transparent;
            this.lab_LoginResult.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lab_LoginResult.ForeColor = System.Drawing.Color.White;
            this.lab_LoginResult.Location = new System.Drawing.Point(492, 290);
            this.lab_LoginResult.Name = "lab_LoginResult";
            this.lab_LoginResult.Size = new System.Drawing.Size(33, 19);
            this.lab_LoginResult.TabIndex = 214;
            this.lab_LoginResult.Text = "???";
            this.lab_LoginResult.Visible = false;
            //
            // errorProvider1
            //
            this.errorProvider1.ContainerControl = this;
            //
            // picB_ShowHidePassword
            //
            this.picB_ShowHidePassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picB_ShowHidePassword.Image = global::DVLD_System_Solution.Properties.Resources.Hide_Passowrd_32;
            this.picB_ShowHidePassword.Location = new System.Drawing.Point(879, 258);
            this.picB_ShowHidePassword.Name = "picB_ShowHidePassword";
            this.picB_ShowHidePassword.Size = new System.Drawing.Size(32, 32);
            this.picB_ShowHidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picB_ShowHidePassword.TabIndex = 310;
            this.picB_ShowHidePassword.TabStop = false;
            this.picB_ShowHidePassword.Click += new System.EventHandler(this.picB_ShowHidePassword_Click);
            //
            // btn_Close
            //
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close2_32;
            this.btn_Close.Location = new System.Drawing.Point(867, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(41, 39);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            //
            // btn_Login
            //
            this.btn_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Image = global::DVLD_System_Solution.Properties.Resources.SignIn_32;
            this.btn_Login.Location = new System.Drawing.Point(728, 349);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(131, 39);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "   Login";
            this.btn_Login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            //
            // pictureBox3
            //
            this.pictureBox3.Image = global::DVLD_System_Solution.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(467, 262);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 207;
            this.pictureBox3.TabStop = false;
            //
            // pictureBox2
            //
            this.pictureBox2.Image = global::DVLD_System_Solution.Properties.Resources.Person_32;
            this.pictureBox2.Location = new System.Drawing.Point(467, 202);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 204;
            this.pictureBox2.TabStop = false;
            //
            // pictureBox_LogoScreen
            //
            this.pictureBox_LogoScreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox_LogoScreen.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_BackGround1;
            this.pictureBox_LogoScreen.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_LogoScreen.Name = "pictureBox_LogoScreen";
            this.pictureBox_LogoScreen.Size = new System.Drawing.Size(346, 425);
            this.pictureBox_LogoScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_LogoScreen.TabIndex = 0;
            this.pictureBox_LogoScreen.TabStop = false;
            this.pictureBox_LogoScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this._FrmLogin_MouseDown);
            //
            // frmLoginScreen
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(920, 425);
            this.Controls.Add(this.picB_ShowHidePassword);
            this.Controls.Add(this.lab_LoginResult);
            this.Controls.Add(this.checkBox_RememberMe);
            this.Controls.Add(this.lab_LoginScreen);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.lab_Name);
            this.Controls.Add(this.pictureBox_LogoScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Screen";
            this.Load += new System.EventHandler(this.frmLoginScreen_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this._FrmLogin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_ShowHidePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LogoScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_LogoScreen;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label lab_Name;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lab_LoginScreen;
        private System.Windows.Forms.CheckBox checkBox_RememberMe;
        private System.Windows.Forms.Label lab_LoginResult;
        private System.Windows.Forms.PictureBox picB_ShowHidePassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}