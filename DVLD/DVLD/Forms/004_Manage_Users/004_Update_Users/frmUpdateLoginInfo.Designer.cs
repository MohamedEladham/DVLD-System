namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    partial class frmUpdateLoginInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateLoginInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.rdoB_NotActive = new System.Windows.Forms.RadioButton();
            this.rdoB_Active = new System.Windows.Forms.RadioButton();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lab_UserIDToText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.lab_PersonIDToText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_UpdateRoles = new System.Windows.Forms.Button();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.rdoB_NotActive);
            this.panel1.Controls.Add(this.rdoB_Active);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Location = new System.Drawing.Point(169, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 37);
            this.panel1.TabIndex = 250;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.Image = global::DVLD_System_Solution.Properties.Resources.Active_User_32;
            this.pictureBox5.Location = new System.Drawing.Point(82, 6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(23, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 26;
            this.pictureBox5.TabStop = false;
            // 
            // rdoB_NotActive
            // 
            this.rdoB_NotActive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdoB_NotActive.AutoSize = true;
            this.rdoB_NotActive.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rdoB_NotActive.ForeColor = System.Drawing.Color.Black;
            this.rdoB_NotActive.Location = new System.Drawing.Point(266, 8);
            this.rdoB_NotActive.Name = "rdoB_NotActive";
            this.rdoB_NotActive.Size = new System.Drawing.Size(89, 21);
            this.rdoB_NotActive.TabIndex = 8;
            this.rdoB_NotActive.Text = "Not Active";
            this.rdoB_NotActive.UseVisualStyleBackColor = true;
            // 
            // rdoB_Active
            // 
            this.rdoB_Active.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdoB_Active.AutoSize = true;
            this.rdoB_Active.Checked = true;
            this.rdoB_Active.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rdoB_Active.ForeColor = System.Drawing.Color.Black;
            this.rdoB_Active.Location = new System.Drawing.Point(111, 8);
            this.rdoB_Active.Name = "rdoB_Active";
            this.rdoB_Active.Size = new System.Drawing.Size(63, 21);
            this.rdoB_Active.TabIndex = 7;
            this.rdoB_Active.TabStop = true;
            this.rdoB_Active.Text = "Active";
            this.rdoB_Active.UseVisualStyleBackColor = true;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox6.Image = global::DVLD_System_Solution.Properties.Resources.Block_User_32;
            this.pictureBox6.Location = new System.Drawing.Point(237, 6);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(23, 24);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 27;
            this.pictureBox6.TabStop = false;
            // 
            // lab_UserIDToText
            // 
            this.lab_UserIDToText.AutoSize = true;
            this.lab_UserIDToText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_UserIDToText.ForeColor = System.Drawing.Color.Brown;
            this.lab_UserIDToText.Location = new System.Drawing.Point(169, 187);
            this.lab_UserIDToText.Name = "lab_UserIDToText";
            this.lab_UserIDToText.Size = new System.Drawing.Size(36, 19);
            this.lab_UserIDToText.TabIndex = 249;
            this.lab_UserIDToText.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 248;
            this.label3.Text = "User ID: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(12, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 246;
            this.label4.Text = "User Name:";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_UserName.Location = new System.Drawing.Point(169, 232);
            this.txt_UserName.MaxLength = 50;
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(440, 24);
            this.txt_UserName.TabIndex = 244;
            this.txt_UserName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_UserName_MouseClick);
            this.txt_UserName.TextChanged += new System.EventHandler(this.txt_UserName_TextChanged);
            // 
            // lab_PersonIDToText
            // 
            this.lab_PersonIDToText.AutoSize = true;
            this.lab_PersonIDToText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_PersonIDToText.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_PersonIDToText.Location = new System.Drawing.Point(169, 143);
            this.lab_PersonIDToText.Name = "lab_PersonIDToText";
            this.lab_PersonIDToText.Size = new System.Drawing.Size(36, 19);
            this.lab_PersonIDToText.TabIndex = 240;
            this.lab_PersonIDToText.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 239;
            this.label1.Text = "Person ID: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_UpdateRoles
            // 
            this.btn_UpdateRoles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_UpdateRoles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_UpdateRoles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_UpdateRoles.ForeColor = System.Drawing.Color.DimGray;
            this.btn_UpdateRoles.Image = global::DVLD_System_Solution.Properties.Resources.Permissions2_32;
            this.btn_UpdateRoles.Location = new System.Drawing.Point(239, 330);
            this.btn_UpdateRoles.Name = "btn_UpdateRoles";
            this.btn_UpdateRoles.Size = new System.Drawing.Size(300, 45);
            this.btn_UpdateRoles.TabIndex = 253;
            this.btn_UpdateRoles.UseVisualStyleBackColor = false;
            this.btn_UpdateRoles.Click += new System.EventHandler(this.btn_UpdateRoles_Click);
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ChangePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_ChangePassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ChangePassword.ForeColor = System.Drawing.Color.DimGray;
            this.btn_ChangePassword.Image = global::DVLD_System_Solution.Properties.Resources.Update_Password3_32;
            this.btn_ChangePassword.Location = new System.Drawing.Point(239, 392);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(300, 45);
            this.btn_ChangePassword.TabIndex = 251;
            this.btn_ChangePassword.UseVisualStyleBackColor = false;
            this.btn_ChangePassword.Click += new System.EventHandler(this.btn_UpdatePassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System_Solution.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(131, 182);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 247;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_System_Solution.Properties.Resources.Person_32;
            this.pictureBox2.Location = new System.Drawing.Point(131, 232);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 245;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.Location = new System.Drawing.Point(16, 452);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(118, 39);
            this.btn_Close.TabIndex = 243;
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
            this.btn_Save.Location = new System.Drawing.Point(646, 452);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(124, 39);
            this.btn_Save.TabIndex = 242;
            this.btn_Save.Text = "  Save";
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
            this.pictureBox11.Size = new System.Drawing.Size(153, 122);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 238;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD_System_Solution.Properties.Resources.Number_32;
            this.pictureBox10.Location = new System.Drawing.Point(131, 138);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(23, 24);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 237;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(279, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(220, 167);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 254;
            this.pictureBox3.TabStop = false;
            // 
            // frmUpdateLoginInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(782, 503);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btn_UpdateRoles);
            this.Controls.Add(this.btn_ChangePassword);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lab_UserIDToText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lab_PersonIDToText);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(798, 542);
            this.MinimumSize = new System.Drawing.Size(798, 542);
            this.Name = "frmUpdateLoginInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Login Info";
            this.Load += new System.EventHandler(this.frmUpdateLoginInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RadioButton rdoB_NotActive;
        private System.Windows.Forms.RadioButton rdoB_Active;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lab_UserIDToText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_PersonIDToText;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ChangePassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_UpdateRoles;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}