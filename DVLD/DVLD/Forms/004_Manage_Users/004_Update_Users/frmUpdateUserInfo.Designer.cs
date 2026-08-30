using DVLD_System_Solution.Forms._004_Manage_Users._004_Update_Users;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    partial class frmUpdateUserInfo
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
            frmUpdateRoles.UpdateUserRole -= _GetIsUpdateUserRole;
            frmUpdateLoginInfo.UpdateLoginInfo -= _GetIsUpdateLoginInfo;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateUserInfo));
            this.lab_UpdateUserInfo = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_UpdateLoginInfo = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.uconShowPersonAndUserInfo1 = new DVLD_System_Solution.Forms._004_Manage_Users.Controls.uconShowPersonAndUserInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_UpdateUserInfo
            // 
            this.lab_UpdateUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_UpdateUserInfo.Font = new System.Drawing.Font("Sitka Small", 40F, System.Drawing.FontStyle.Bold);
            this.lab_UpdateUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lab_UpdateUserInfo.Location = new System.Drawing.Point(144, 30);
            this.lab_UpdateUserInfo.Name = "lab_UpdateUserInfo";
            this.lab_UpdateUserInfo.Size = new System.Drawing.Size(635, 84);
            this.lab_UpdateUserInfo.TabIndex = 225;
            this.lab_UpdateUserInfo.Text = "Update User Info";
            this.lab_UpdateUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btn_Close.Location = new System.Drawing.Point(12, 610);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 39);
            this.btn_Close.TabIndex = 228;
            this.btn_Close.Text = "    Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_UpdateLoginInfo
            // 
            this.btn_UpdateLoginInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UpdateLoginInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_UpdateLoginInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_UpdateLoginInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_UpdateLoginInfo.ForeColor = System.Drawing.Color.SteelBlue;
            this.btn_UpdateLoginInfo.Image = global::DVLD_System_Solution.Properties.Resources.Login_Info_32;
            this.btn_UpdateLoginInfo.Location = new System.Drawing.Point(742, 610);
            this.btn_UpdateLoginInfo.Name = "btn_UpdateLoginInfo";
            this.btn_UpdateLoginInfo.Size = new System.Drawing.Size(197, 39);
            this.btn_UpdateLoginInfo.TabIndex = 227;
            this.btn_UpdateLoginInfo.Text = "Update Login Info";
            this.btn_UpdateLoginInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_UpdateLoginInfo.UseVisualStyleBackColor = false;
            this.btn_UpdateLoginInfo.Click += new System.EventHandler(this.btn_UpdateLoginInfo_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(785, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(154, 120);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 224;
            this.pictureBox11.TabStop = false;
            // 
            // uconShowPersonAndUserInfo1
            // 
            this.uconShowPersonAndUserInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uconShowPersonAndUserInfo1.Location = new System.Drawing.Point(12, 138);
            this.uconShowPersonAndUserInfo1.Name = "uconShowPersonAndUserInfo1";
            this.uconShowPersonAndUserInfo1.Size = new System.Drawing.Size(927, 452);
            this.uconShowPersonAndUserInfo1.TabIndex = 229;
            // 
            // frmUpdateUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(951, 661);
            this.Controls.Add(this.uconShowPersonAndUserInfo1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_UpdateLoginInfo);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lab_UpdateUserInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(967, 700);
            this.MinimumSize = new System.Drawing.Size(967, 700);
            this.Name = "frmUpdateUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update User Info";
            this.Load += new System.EventHandler(this.frmUpdateUserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_UpdateUserInfo;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_UpdateLoginInfo;
        private Controls.uconShowPersonAndUserInfo uconShowPersonAndUserInfo1;
    }
}