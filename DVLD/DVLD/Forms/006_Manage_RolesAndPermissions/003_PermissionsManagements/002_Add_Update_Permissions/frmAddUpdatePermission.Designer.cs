namespace DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._003_PermissionsManagements._002_Add_Update_Permissions
{
    partial class frmAddUpdatePermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdatePermission));
            this.txt_PermissionCategory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_PermissionID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PermissionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_ModeStatue1 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_PermissionCategory
            // 
            this.txt_PermissionCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PermissionCategory.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_PermissionCategory.Location = new System.Drawing.Point(16, 305);
            this.txt_PermissionCategory.MaxLength = 500;
            this.txt_PermissionCategory.Multiline = true;
            this.txt_PermissionCategory.Name = "txt_PermissionCategory";
            this.txt_PermissionCategory.Size = new System.Drawing.Size(515, 119);
            this.txt_PermissionCategory.TabIndex = 239;
            this.txt_PermissionCategory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxies_MouseClick);
            this.txt_PermissionCategory.TextChanged += new System.EventHandler(this.TextBoxies_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 248;
            this.label3.Text = "Category:";
            // 
            // lab_PermissionID
            // 
            this.lab_PermissionID.AutoSize = true;
            this.lab_PermissionID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lab_PermissionID.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_PermissionID.Location = new System.Drawing.Point(146, 178);
            this.lab_PermissionID.Name = "lab_PermissionID";
            this.lab_PermissionID.Size = new System.Drawing.Size(36, 19);
            this.lab_PermissionID.TabIndex = 245;
            this.lab_PermissionID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 244;
            this.label1.Text = "Permission ID:";
            // 
            // txt_PermissionName
            // 
            this.txt_PermissionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PermissionName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_PermissionName.Location = new System.Drawing.Point(16, 245);
            this.txt_PermissionName.MaxLength = 50;
            this.txt_PermissionName.Name = "txt_PermissionName";
            this.txt_PermissionName.Size = new System.Drawing.Size(515, 24);
            this.txt_PermissionName.TabIndex = 238;
            this.txt_PermissionName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxies_MouseClick);
            this.txt_PermissionName.TextChanged += new System.EventHandler(this.TextBoxies_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 246;
            this.label2.Text = "Per Name:";
            // 
            // lab_ModeStatue1
            // 
            this.lab_ModeStatue1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_ModeStatue1.Font = new System.Drawing.Font("Sitka Small", 35F, System.Drawing.FontStyle.Bold);
            this.lab_ModeStatue1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lab_ModeStatue1.Location = new System.Drawing.Point(102, 12);
            this.lab_ModeStatue1.Name = "lab_ModeStatue1";
            this.lab_ModeStatue1.Size = new System.Drawing.Size(321, 139);
            this.lab_ModeStatue1.TabIndex = 241;
            this.lab_ModeStatue1.Text = "Add Permission";
            this.lab_ModeStatue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(429, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(114, 103);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 240;
            this.pictureBox11.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.Location = new System.Drawing.Point(12, 470);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(110, 38);
            this.btn_Close.TabIndex = 257;
            this.btn_Close.Text = " Close";
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
            this.btn_Save.Location = new System.Drawing.Point(408, 470);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 39);
            this.btn_Save.TabIndex = 258;
            this.btn_Save.Text = "    Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 700;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdatePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(555, 521);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.txt_PermissionCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_PermissionID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_PermissionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lab_ModeStatue1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(571, 560);
            this.MinimumSize = new System.Drawing.Size(571, 560);
            this.Name = "frmAddUpdatePermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Update Permission";
            this.Load += new System.EventHandler(this.frmAddUpdatePermission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_PermissionCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_PermissionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PermissionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_ModeStatue1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}