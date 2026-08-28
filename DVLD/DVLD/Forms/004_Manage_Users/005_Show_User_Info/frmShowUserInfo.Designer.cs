namespace DVLD_System_Solution.Forms._004_Manage_Users._005_Show_User_Info
{
    partial class frmShowUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowUserInfo));
            this.btn_Close = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.lab_UserInfo = new System.Windows.Forms.Label();
            this.uconShowPersonAndUserInfo1 = new DVLD_System_Solution.Forms._004_Manage_Users.Controls.uconShowPersonAndUserInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.Location = new System.Drawing.Point(12, 587);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(119, 39);
            this.btn_Close.TabIndex = 220;
            this.btn_Close.Text = "  Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(827, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(116, 110);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 221;
            this.pictureBox11.TabStop = false;
            // 
            // lab_UserInfo
            // 
            this.lab_UserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_UserInfo.AutoSize = true;
            this.lab_UserInfo.Font = new System.Drawing.Font("Sitka Small", 33F, System.Drawing.FontStyle.Bold);
            this.lab_UserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lab_UserInfo.Location = new System.Drawing.Point(279, 43);
            this.lab_UserInfo.Name = "lab_UserInfo";
            this.lab_UserInfo.Size = new System.Drawing.Size(387, 65);
            this.lab_UserInfo.TabIndex = 222;
            this.lab_UserInfo.Text = "Show User Info";
            this.lab_UserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uconShowPersonAndUserInfo1
            // 
            this.uconShowPersonAndUserInfo1.Location = new System.Drawing.Point(12, 128);
            this.uconShowPersonAndUserInfo1.Name = "uconShowPersonAndUserInfo1";
            this.uconShowPersonAndUserInfo1.Size = new System.Drawing.Size(931, 453);
            this.uconShowPersonAndUserInfo1.TabIndex = 223;
            // 
            // frmShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(955, 638);
            this.Controls.Add(this.uconShowPersonAndUserInfo1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lab_UserInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(971, 677);
            this.MinimumSize = new System.Drawing.Size(971, 677);
            this.Name = "frmShowUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show User Info";
            this.Load += new System.EventHandler(this.frmShowUserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_UserInfo;
        private Controls.uconShowPersonAndUserInfo uconShowPersonAndUserInfo1;
    }
}