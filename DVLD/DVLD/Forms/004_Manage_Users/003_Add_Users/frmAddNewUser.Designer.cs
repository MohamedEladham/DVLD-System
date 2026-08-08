using DVLD_System_Solution.Forms._003_Manage_People.Controls;
using DVLD_System_Solution.Forms._004_Manage_Users.Controls;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    partial class frmAddNewUser
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
            uconShowPersonInfo.SendPersonID -= _GetPersonID;
            frmCreateLoginInfo.CreatedLoginInfo -= _UpdateButtonModeCreateLoginInfo;
            uconPersonCardWithUserFilter.SendIsUser -= _UpdateButtonModeCreateLoginInfo;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewUser));
            this.lab_AddNewUser = new System.Windows.Forms.Label();
            this.uconPersonCardWithUserFilter1 = new DVLD_System_Solution.Forms._004_Manage_Users.Controls.uconPersonCardWithUserFilter();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_CreateLoginInfo = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_AddNewUser
            // 
            this.lab_AddNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_AddNewUser.Font = new System.Drawing.Font("Sitka Small", 44F, System.Drawing.FontStyle.Bold);
            this.lab_AddNewUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lab_AddNewUser.Location = new System.Drawing.Point(179, 29);
            this.lab_AddNewUser.Name = "lab_AddNewUser";
            this.lab_AddNewUser.Size = new System.Drawing.Size(706, 84);
            this.lab_AddNewUser.TabIndex = 223;
            this.lab_AddNewUser.Text = "Add New User";
            this.lab_AddNewUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uconPersonCardWithUserFilter1
            // 
            this.uconPersonCardWithUserFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uconPersonCardWithUserFilter1.AutoSize = true;
            this.uconPersonCardWithUserFilter1.Location = new System.Drawing.Point(12, 128);
            this.uconPersonCardWithUserFilter1.Name = "uconPersonCardWithUserFilter1";
            this.uconPersonCardWithUserFilter1.Size = new System.Drawing.Size(1033, 448);
            this.uconPersonCardWithUserFilter1.TabIndex = 224;
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
            this.btn_Close.Location = new System.Drawing.Point(12, 591);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 39);
            this.btn_Close.TabIndex = 226;
            this.btn_Close.Text = "    Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_CreateLoginInfo
            // 
            this.btn_CreateLoginInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CreateLoginInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_CreateLoginInfo.Enabled = false;
            this.btn_CreateLoginInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_CreateLoginInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_CreateLoginInfo.ForeColor = System.Drawing.Color.SteelBlue;
            this.btn_CreateLoginInfo.Image = global::DVLD_System_Solution.Properties.Resources.Login_Info_32;
            this.btn_CreateLoginInfo.Location = new System.Drawing.Point(852, 591);
            this.btn_CreateLoginInfo.Name = "btn_CreateLoginInfo";
            this.btn_CreateLoginInfo.Size = new System.Drawing.Size(193, 39);
            this.btn_CreateLoginInfo.TabIndex = 225;
            this.btn_CreateLoginInfo.Text = "Create Login Info";
            this.btn_CreateLoginInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_CreateLoginInfo.UseVisualStyleBackColor = false;
            this.btn_CreateLoginInfo.Click += new System.EventHandler(this.btn_CreateLoginInfo_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(891, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(154, 110);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 222;
            this.pictureBox11.TabStop = false;
            // 
            // frmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1057, 642);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_CreateLoginInfo);
            this.Controls.Add(this.uconPersonCardWithUserFilter1);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lab_AddNewUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1073, 681);
            this.MinimumSize = new System.Drawing.Size(1073, 681);
            this.Name = "frmAddNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User Screen";
            this.Load += new System.EventHandler(this.frmAddNewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_AddNewUser;
        private Controls.uconPersonCardWithUserFilter uconPersonCardWithUserFilter1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_CreateLoginInfo;
    }
}