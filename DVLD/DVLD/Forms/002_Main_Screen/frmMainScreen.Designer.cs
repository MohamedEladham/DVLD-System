namespace Main_Screen
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_Applicatios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ManagePersons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Drivers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ManageUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AccountSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lab_Permissions = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Applicatios,
            this.toolStripMenuItem_ManagePersons,
            this.toolStripMenuItem_Drivers,
            this.toolStripMenuItem_ManageUsers,
            this.toolStripMenuItem_AccountSetting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1203, 88);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Applicatios
            // 
            this.toolStripMenuItem_Applicatios.Image = global::DVLD_System_Solution.Properties.Resources.Person_Document1;
            this.toolStripMenuItem_Applicatios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_Applicatios.Name = "toolStripMenuItem_Applicatios";
            this.toolStripMenuItem_Applicatios.Size = new System.Drawing.Size(280, 84);
            this.toolStripMenuItem_Applicatios.Text = "Applications";
            // 
            // toolStripMenuItem_ManagePersons
            // 
            this.toolStripMenuItem_ManagePersons.Image = global::DVLD_System_Solution.Properties.Resources.Group_Persons1_80;
            this.toolStripMenuItem_ManagePersons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ManagePersons.Name = "toolStripMenuItem_ManagePersons";
            this.toolStripMenuItem_ManagePersons.Size = new System.Drawing.Size(216, 84);
            this.toolStripMenuItem_ManagePersons.Text = "Persons";
            this.toolStripMenuItem_ManagePersons.Click += new System.EventHandler(this.toolStripMenuItem_Persons_Click);
            // 
            // toolStripMenuItem_Drivers
            // 
            this.toolStripMenuItem_Drivers.Image = global::DVLD_System_Solution.Properties.Resources.Drivers_64;
            this.toolStripMenuItem_Drivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_Drivers.Name = "toolStripMenuItem_Drivers";
            this.toolStripMenuItem_Drivers.Size = new System.Drawing.Size(190, 84);
            this.toolStripMenuItem_Drivers.Text = "Drivers";
            // 
            // toolStripMenuItem_ManageUsers
            // 
            this.toolStripMenuItem_ManageUsers.Image = global::DVLD_System_Solution.Properties.Resources.Users2_64;
            this.toolStripMenuItem_ManageUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ManageUsers.Name = "toolStripMenuItem_ManageUsers";
            this.toolStripMenuItem_ManageUsers.Size = new System.Drawing.Size(168, 84);
            this.toolStripMenuItem_ManageUsers.Text = "Users";
            this.toolStripMenuItem_ManageUsers.Click += new System.EventHandler(this.toolStripMenuItem_ManageUsers_Click);
            // 
            // toolStripMenuItem_AccountSetting
            // 
            this.toolStripMenuItem_AccountSetting.Image = global::DVLD_System_Solution.Properties.Resources.Account_Settings_64;
            this.toolStripMenuItem_AccountSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_AccountSetting.Name = "toolStripMenuItem_AccountSetting";
            this.toolStripMenuItem_AccountSetting.Size = new System.Drawing.Size(313, 84);
            this.toolStripMenuItem_AccountSetting.Text = "Account Setting";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_BackGround1;
            this.pictureBox1.Location = new System.Drawing.Point(324, 237);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 323);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lab_Permissions
            // 
            this.lab_Permissions.AutoSize = true;
            this.lab_Permissions.BackColor = System.Drawing.Color.Transparent;
            this.lab_Permissions.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_Permissions.ForeColor = System.Drawing.Color.White;
            this.lab_Permissions.Location = new System.Drawing.Point(12, 111);
            this.lab_Permissions.Name = "lab_Permissions";
            this.lab_Permissions.Size = new System.Drawing.Size(36, 19);
            this.lab_Permissions.TabIndex = 206;
            this.lab_Permissions.Text = "???";
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1203, 701);
            this.Controls.Add(this.lab_Permissions);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1219, 740);
            this.Name = "frmMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ManagePersons;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ManageUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Applicatios;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Drivers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AccountSetting;
        private System.Windows.Forms.Label lab_Permissions;
    }
}

