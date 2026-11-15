namespace DVLD_System_Solution.Forms._005_Manage_Roles._002_AddRoles
{
    partial class frmAddUpdateRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateRole));
            this.lab_ModeStatue1 = new System.Windows.Forms.Label();
            this.lab_RoleID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_RoleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chB_Permissions = new System.Windows.Forms.CheckedListBox();
            this.lab_ModeStatue2 = new System.Windows.Forms.Label();
            this.txt_SearchValue = new System.Windows.Forms.TextBox();
            this.comBox_FilterItems = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picB_CheckedNotCheckedPermissions = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_CheckedNotCheckedPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_ModeStatue1
            // 
            this.lab_ModeStatue1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_ModeStatue1.AutoSize = true;
            this.lab_ModeStatue1.Font = new System.Drawing.Font("Sitka Small", 33F, System.Drawing.FontStyle.Bold);
            this.lab_ModeStatue1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lab_ModeStatue1.Location = new System.Drawing.Point(146, 23);
            this.lab_ModeStatue1.Name = "lab_ModeStatue1";
            this.lab_ModeStatue1.Size = new System.Drawing.Size(352, 65);
            this.lab_ModeStatue1.TabIndex = 226;
            this.lab_ModeStatue1.Text = "Add New Role";
            this.lab_ModeStatue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_RoleID
            // 
            this.lab_RoleID.AutoSize = true;
            this.lab_RoleID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_RoleID.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_RoleID.Location = new System.Drawing.Point(153, 121);
            this.lab_RoleID.Name = "lab_RoleID";
            this.lab_RoleID.Size = new System.Drawing.Size(36, 19);
            this.lab_RoleID.TabIndex = 231;
            this.lab_RoleID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(11, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 230;
            this.label1.Text = "Role ID: ";
            // 
            // txt_RoleName
            // 
            this.txt_RoleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_RoleName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_RoleName.Location = new System.Drawing.Point(157, 149);
            this.txt_RoleName.MaxLength = 50;
            this.txt_RoleName.Name = "txt_RoleName";
            this.txt_RoleName.Size = new System.Drawing.Size(341, 24);
            this.txt_RoleName.TabIndex = 1;
            this.txt_RoleName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxies_MouseClick);
            this.txt_RoleName.TextChanged += new System.EventHandler(this.TextBoxies_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(11, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 232;
            this.label2.Text = "Role Name:";
            // 
            // txt_Description
            // 
            this.txt_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_Description.Location = new System.Drawing.Point(157, 181);
            this.txt_Description.MaxLength = 500;
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(341, 73);
            this.txt_Description.TabIndex = 2;
            this.txt_Description.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxies_MouseClick);
            this.txt_Description.TextChanged += new System.EventHandler(this.TextBoxies_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(11, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 237;
            this.label3.Text = "Description:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 700;
            this.errorProvider1.ContainerControl = this;
            // 
            // chB_Permissions
            // 
            this.chB_Permissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chB_Permissions.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chB_Permissions.ForeColor = System.Drawing.Color.Black;
            this.chB_Permissions.FormattingEnabled = true;
            this.chB_Permissions.Location = new System.Drawing.Point(12, 364);
            this.chB_Permissions.Name = "chB_Permissions";
            this.chB_Permissions.Size = new System.Drawing.Size(640, 312);
            this.chB_Permissions.TabIndex = 3;
            this.chB_Permissions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chB_Permissions_ItemCheck);
            // 
            // lab_ModeStatue2
            // 
            this.lab_ModeStatue2.AutoSize = true;
            this.lab_ModeStatue2.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.lab_ModeStatue2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lab_ModeStatue2.Location = new System.Drawing.Point(6, 328);
            this.lab_ModeStatue2.Name = "lab_ModeStatue2";
            this.lab_ModeStatue2.Size = new System.Drawing.Size(199, 33);
            this.lab_ModeStatue2.TabIndex = 277;
            this.lab_ModeStatue2.Text = "Add Permissions";
            // 
            // txt_SearchValue
            // 
            this.txt_SearchValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_SearchValue.Location = new System.Drawing.Point(157, 301);
            this.txt_SearchValue.Name = "txt_SearchValue";
            this.txt_SearchValue.Size = new System.Drawing.Size(341, 24);
            this.txt_SearchValue.TabIndex = 280;
            this.txt_SearchValue.Visible = false;
            this.txt_SearchValue.TextChanged += new System.EventHandler(this.txt_SearchValue_TextChanged);
            this.txt_SearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchValue_KeyPress);
            // 
            // comBox_FilterItems
            // 
            this.comBox_FilterItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_FilterItems.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_FilterItems.FormattingEnabled = true;
            this.comBox_FilterItems.Location = new System.Drawing.Point(157, 271);
            this.comBox_FilterItems.Name = "comBox_FilterItems";
            this.comBox_FilterItems.Size = new System.Drawing.Size(341, 24);
            this.comBox_FilterItems.TabIndex = 279;
            this.comBox_FilterItems.SelectedIndexChanged += new System.EventHandler(this.comBox_FilterItems_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(30, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 33);
            this.label4.TabIndex = 278;
            this.label4.Text = "Filter By:";
            // 
            // picB_CheckedNotCheckedPermissions
            // 
            this.picB_CheckedNotCheckedPermissions.Image = global::DVLD_System_Solution.Properties.Resources.TickBox2_32;
            this.picB_CheckedNotCheckedPermissions.Location = new System.Drawing.Point(620, 329);
            this.picB_CheckedNotCheckedPermissions.Name = "picB_CheckedNotCheckedPermissions";
            this.picB_CheckedNotCheckedPermissions.Size = new System.Drawing.Size(32, 32);
            this.picB_CheckedNotCheckedPermissions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picB_CheckedNotCheckedPermissions.TabIndex = 285;
            this.picB_CheckedNotCheckedPermissions.TabStop = false;
            this.picB_CheckedNotCheckedPermissions.Click += new System.EventHandler(this.picB_CheckedNotCheckedPermissions_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_System_Solution.Properties.Resources.Description1_32;
            this.pictureBox2.Location = new System.Drawing.Point(124, 181);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 236;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Close.Location = new System.Drawing.Point(12, 704);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 39);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "    Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Save.Image = global::DVLD_System_Solution.Properties.Resources.Save1_32;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Save.Location = new System.Drawing.Point(517, 704);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 39);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "    Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD_System_Solution.Properties.Resources.ID_Number1_32;
            this.pictureBox10.Location = new System.Drawing.Point(124, 118);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(23, 24);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 229;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System_Solution.Properties.Resources.Description1_32;
            this.pictureBox1.Location = new System.Drawing.Point(124, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 228;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(541, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(111, 90);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 225;
            this.pictureBox11.TabStop = false;
            // 
            // frmAddUpdateRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(664, 755);
            this.Controls.Add(this.picB_CheckedNotCheckedPermissions);
            this.Controls.Add(this.txt_SearchValue);
            this.Controls.Add(this.comBox_FilterItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chB_Permissions);
            this.Controls.Add(this.lab_ModeStatue2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txt_Description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lab_RoleID);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_RoleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lab_ModeStatue1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(680, 794);
            this.MinimumSize = new System.Drawing.Size(680, 794);
            this.Name = "frmAddUpdateRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Update Role";
            this.Load += new System.EventHandler(this.frmAddUpdateRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_CheckedNotCheckedPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_ModeStatue1;
        private System.Windows.Forms.Label lab_RoleID;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_RoleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckedListBox chB_Permissions;
        private System.Windows.Forms.Label lab_ModeStatue2;
        private System.Windows.Forms.TextBox txt_SearchValue;
        private System.Windows.Forms.ComboBox comBox_FilterItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picB_CheckedNotCheckedPermissions;
    }
}