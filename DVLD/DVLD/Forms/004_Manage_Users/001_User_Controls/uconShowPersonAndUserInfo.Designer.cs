namespace DVLD_System_Solution.Forms._004_Manage_Users.Controls
{
    partial class uconShowPersonAndUserInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_UserID = new System.Windows.Forms.Label();
            this.groupBox_UserInfo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picB_ActiveStatus = new System.Windows.Forms.PictureBox();
            this.lab_IsActive = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lab_UserName = new System.Windows.Forms.Label();
            this.uconShowPersonInfo1 = new DVLD_System_Solution.Forms._003_Manage_People.Controls.uconShowPersonInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_UserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picB_ActiveStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System_Solution.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(93, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 237;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 24);
            this.label1.TabIndex = 238;
            this.label1.Text = "User ID:";
            // 
            // lab_UserID
            // 
            this.lab_UserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_UserID.AutoSize = true;
            this.lab_UserID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lab_UserID.ForeColor = System.Drawing.Color.DarkRed;
            this.lab_UserID.Location = new System.Drawing.Point(122, 44);
            this.lab_UserID.Name = "lab_UserID";
            this.lab_UserID.Size = new System.Drawing.Size(44, 17);
            this.lab_UserID.TabIndex = 239;
            this.lab_UserID.Text = "[???]";
            // 
            // groupBox_UserInfo
            // 
            this.groupBox_UserInfo.Controls.Add(this.label4);
            this.groupBox_UserInfo.Controls.Add(this.picB_ActiveStatus);
            this.groupBox_UserInfo.Controls.Add(this.lab_IsActive);
            this.groupBox_UserInfo.Controls.Add(this.label2);
            this.groupBox_UserInfo.Controls.Add(this.pictureBox2);
            this.groupBox_UserInfo.Controls.Add(this.lab_UserName);
            this.groupBox_UserInfo.Controls.Add(this.label1);
            this.groupBox_UserInfo.Controls.Add(this.pictureBox1);
            this.groupBox_UserInfo.Controls.Add(this.lab_UserID);
            this.groupBox_UserInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_UserInfo.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox_UserInfo.ForeColor = System.Drawing.Color.Brown;
            this.groupBox_UserInfo.Location = new System.Drawing.Point(0, 331);
            this.groupBox_UserInfo.Name = "groupBox_UserInfo";
            this.groupBox_UserInfo.Size = new System.Drawing.Size(873, 84);
            this.groupBox_UserInfo.TabIndex = 240;
            this.groupBox_UserInfo.TabStop = false;
            this.groupBox_UserInfo.Text = "User Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(611, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 244;
            this.label4.Text = "Is Active:";
            // 
            // picB_ActiveStatus
            // 
            this.picB_ActiveStatus.Image = global::DVLD_System_Solution.Properties.Resources.Active_User_32;
            this.picB_ActiveStatus.Location = new System.Drawing.Point(707, 40);
            this.picB_ActiveStatus.Name = "picB_ActiveStatus";
            this.picB_ActiveStatus.Size = new System.Drawing.Size(23, 24);
            this.picB_ActiveStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picB_ActiveStatus.TabIndex = 243;
            this.picB_ActiveStatus.TabStop = false;
            // 
            // lab_IsActive
            // 
            this.lab_IsActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_IsActive.AutoSize = true;
            this.lab_IsActive.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lab_IsActive.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_IsActive.Location = new System.Drawing.Point(736, 44);
            this.lab_IsActive.Name = "lab_IsActive";
            this.lab_IsActive.Size = new System.Drawing.Size(44, 17);
            this.lab_IsActive.TabIndex = 245;
            this.lab_IsActive.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(286, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 241;
            this.label2.Text = "User Name:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_System_Solution.Properties.Resources.Person_32;
            this.pictureBox2.Location = new System.Drawing.Point(401, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 240;
            this.pictureBox2.TabStop = false;
            // 
            // lab_UserName
            // 
            this.lab_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lab_UserName.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_UserName.Location = new System.Drawing.Point(430, 44);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(44, 17);
            this.lab_UserName.TabIndex = 242;
            this.lab_UserName.Text = "[???]";
            // 
            // uconShowPersonInfo1
            // 
            this.uconShowPersonInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uconShowPersonInfo1.Location = new System.Drawing.Point(0, 0);
            this.uconShowPersonInfo1.MinimumSize = new System.Drawing.Size(865, 316);
            this.uconShowPersonInfo1.Name = "uconShowPersonInfo1";
            this.uconShowPersonInfo1.Size = new System.Drawing.Size(873, 316);
            this.uconShowPersonInfo1.TabIndex = 0;
            // 
            // uconShowPersonAndUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_UserInfo);
            this.Controls.Add(this.uconShowPersonInfo1);
            this.Name = "uconShowPersonAndUserInfo";
            this.Size = new System.Drawing.Size(873, 415);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_UserInfo.ResumeLayout(false);
            this.groupBox_UserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picB_ActiveStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private _003_Manage_People.Controls.uconShowPersonInfo uconShowPersonInfo1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_UserID;
        private System.Windows.Forms.GroupBox groupBox_UserInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picB_ActiveStatus;
        private System.Windows.Forms.Label lab_IsActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lab_UserName;
    }
}
