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
            this.toolStripMenuItem_ManageApplicatios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ManagePersons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ManageDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ManageUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RolesPermissionsManagements = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_RolesManagements = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PermissionsManagements = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ManageAccountSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.lab_UserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lab_PermissionsToText = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ManageApplicatios,
            this.toolStripMenuItem_ManagePersons,
            this.toolStripMenuItem_ManageDrivers,
            this.toolStripMenuItem_ManageUsers,
            this.toolStripMenuItem_RolesPermissionsManagements,
            this.toolStripMenuItem_ManageAccountSetting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1354, 90);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_ManageApplicatios
            // 
            this.toolStripMenuItem_ManageApplicatios.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.toolStripMenuItem_ManageApplicatios.Image = global::DVLD_System_Solution.Properties.Resources.Person_Document1;
            this.toolStripMenuItem_ManageApplicatios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem_ManageApplicatios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ManageApplicatios.Name = "toolStripMenuItem_ManageApplicatios";
            this.toolStripMenuItem_ManageApplicatios.Size = new System.Drawing.Size(280, 86);
            this.toolStripMenuItem_ManageApplicatios.Text = "Applications";
            this.toolStripMenuItem_ManageApplicatios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripMenuItem_ManagePersons
            // 
            this.toolStripMenuItem_ManagePersons.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem_ManagePersons.Image = global::DVLD_System_Solution.Properties.Resources.Group_Persons1_80;
            this.toolStripMenuItem_ManagePersons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem_ManagePersons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ManagePersons.Name = "toolStripMenuItem_ManagePersons";
            this.toolStripMenuItem_ManagePersons.Size = new System.Drawing.Size(216, 86);
            this.toolStripMenuItem_ManagePersons.Text = "Persons";
            this.toolStripMenuItem_ManagePersons.Click += new System.EventHandler(this.toolStripMenuItem_Persons_Click);
            // 
            // toolStripMenuItem_ManageDrivers
            // 
            this.toolStripMenuItem_ManageDrivers.Image = global::DVLD_System_Solution.Properties.Resources.Drivers_64;
            this.toolStripMenuItem_ManageDrivers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem_ManageDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ManageDrivers.Name = "toolStripMenuItem_ManageDrivers";
            this.toolStripMenuItem_ManageDrivers.Size = new System.Drawing.Size(190, 86);
            this.toolStripMenuItem_ManageDrivers.Text = "Drivers";
            // 
            // toolStripMenuItem_ManageUsers
            // 
            this.toolStripMenuItem_ManageUsers.Image = global::DVLD_System_Solution.Properties.Resources.Users2_64;
            this.toolStripMenuItem_ManageUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem_ManageUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ManageUsers.Name = "toolStripMenuItem_ManageUsers";
            this.toolStripMenuItem_ManageUsers.Size = new System.Drawing.Size(168, 86);
            this.toolStripMenuItem_ManageUsers.Text = "Users";
            this.toolStripMenuItem_ManageUsers.Click += new System.EventHandler(this.toolStripMenuItem_ManageUsers_Click);
            // 
            // toolStripMenuItem_RolesPermissionsManagements
            // 
            this.toolStripMenuItem_RolesPermissionsManagements.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_RolesManagements,
            this.toolStripMenuItem_PermissionsManagements});
            this.toolStripMenuItem_RolesPermissionsManagements.Image = global::DVLD_System_Solution.Properties.Resources.Manage_Roles1_64;
            this.toolStripMenuItem_RolesPermissionsManagements.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_RolesPermissionsManagements.Name = "toolStripMenuItem_RolesPermissionsManagements";
            this.toolStripMenuItem_RolesPermissionsManagements.Size = new System.Drawing.Size(337, 86);
            this.toolStripMenuItem_RolesPermissionsManagements.Text = "Roles Permissions";
            // 
            // toolStripMenuItem_RolesManagements
            // 
            this.toolStripMenuItem_RolesManagements.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem_RolesManagements.Image = global::DVLD_System_Solution.Properties.Resources.Role_Managements1_32;
            this.toolStripMenuItem_RolesManagements.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_RolesManagements.Name = "toolStripMenuItem_RolesManagements";
            this.toolStripMenuItem_RolesManagements.Size = new System.Drawing.Size(370, 38);
            this.toolStripMenuItem_RolesManagements.Text = "Roles Managements";
            this.toolStripMenuItem_RolesManagements.Click += new System.EventHandler(this.toolStripMenuItem_RolesManagements_Click);
            // 
            // toolStripMenuItem_PermissionsManagements
            // 
            this.toolStripMenuItem_PermissionsManagements.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem_PermissionsManagements.Image = global::DVLD_System_Solution.Properties.Resources.Permissions1_321;
            this.toolStripMenuItem_PermissionsManagements.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_PermissionsManagements.Name = "toolStripMenuItem_PermissionsManagements";
            this.toolStripMenuItem_PermissionsManagements.Size = new System.Drawing.Size(370, 38);
            this.toolStripMenuItem_PermissionsManagements.Text = "Permissions Managements";
            this.toolStripMenuItem_PermissionsManagements.Click += new System.EventHandler(this.toolStripMenuItem_PermissionsManagements_Click);
            // 
            // toolStripMenuItem_ManageAccountSetting
            // 
            this.toolStripMenuItem_ManageAccountSetting.Image = global::DVLD_System_Solution.Properties.Resources.Account_Settings_64;
            this.toolStripMenuItem_ManageAccountSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem_ManageAccountSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ManageAccountSetting.Name = "toolStripMenuItem_ManageAccountSetting";
            this.toolStripMenuItem_ManageAccountSetting.Size = new System.Drawing.Size(313, 86);
            this.toolStripMenuItem_ManageAccountSetting.Text = "Account Setting";
            this.toolStripMenuItem_ManageAccountSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_UserName
            // 
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.BackColor = System.Drawing.Color.Transparent;
            this.lab_UserName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_UserName.ForeColor = System.Drawing.Color.Lime;
            this.lab_UserName.Location = new System.Drawing.Point(122, 107);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(36, 19);
            this.lab_UserName.TabIndex = 208;
            this.lab_UserName.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 211;
            this.label2.Text = "User Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_BackGround1;
            this.pictureBox1.Location = new System.Drawing.Point(331, 207);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(752, 394);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lab_PermissionsToText
            // 
            this.lab_PermissionsToText.BackColor = System.Drawing.Color.Transparent;
            this.lab_PermissionsToText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_PermissionsToText.ForeColor = System.Drawing.Color.Lime;
            this.lab_PermissionsToText.Location = new System.Drawing.Point(12, 139);
            this.lab_PermissionsToText.Name = "lab_PermissionsToText";
            this.lab_PermissionsToText.Size = new System.Drawing.Size(1071, 65);
            this.lab_PermissionsToText.TabIndex = 212;
            this.lab_PermissionsToText.Text = "???";
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1354, 701);
            this.Controls.Add(this.lab_PermissionsToText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_UserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1360, 740);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ManageApplicatios;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ManageDrivers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ManageAccountSetting;
        private System.Windows.Forms.Label lab_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RolesPermissionsManagements;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RolesManagements;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PermissionsManagements;
        private System.Windows.Forms.Label lab_PermissionsToText;
    }
}

