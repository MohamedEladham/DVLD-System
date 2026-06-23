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
            this.toolStripMenuItem_Persons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Drivers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Users = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AccountSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Applicatios,
            this.toolStripMenuItem_Persons,
            this.toolStripMenuItem_Drivers,
            this.toolStripMenuItem_Users,
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
            // toolStripMenuItem_Persons
            // 
            this.toolStripMenuItem_Persons.Image = global::DVLD_System_Solution.Properties.Resources.Group_Persons1_80;
            this.toolStripMenuItem_Persons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_Persons.Name = "toolStripMenuItem_Persons";
            this.toolStripMenuItem_Persons.Size = new System.Drawing.Size(216, 84);
            this.toolStripMenuItem_Persons.Text = "Persons";
            this.toolStripMenuItem_Persons.Click += new System.EventHandler(this.toolStripMenuItem_Persons_Click);
            // 
            // toolStripMenuItem_Drivers
            // 
            this.toolStripMenuItem_Drivers.Image = global::DVLD_System_Solution.Properties.Resources.Drivers_64;
            this.toolStripMenuItem_Drivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_Drivers.Name = "toolStripMenuItem_Drivers";
            this.toolStripMenuItem_Drivers.Size = new System.Drawing.Size(190, 84);
            this.toolStripMenuItem_Drivers.Text = "Drivers";
            // 
            // toolStripMenuItem_Users
            // 
            this.toolStripMenuItem_Users.Image = global::DVLD_System_Solution.Properties.Resources.Users1_64;
            this.toolStripMenuItem_Users.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_Users.Name = "toolStripMenuItem_Users";
            this.toolStripMenuItem_Users.Size = new System.Drawing.Size(168, 84);
            this.toolStripMenuItem_Users.Text = "Users";
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
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1203, 701);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1219, 740);
            this.Name = "frmMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Persons;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Users;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Applicatios;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Drivers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AccountSetting;
    }
}

