using DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._003_PermissionsManagements._002_Add_Update_Permissions;

namespace DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._003_PermissionsManagements._001_Manage_Permissions
{
    partial class frmPermissionsManagement
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
            frmAddUpdatePermission.AddUpdatePermission -= _GetIsAddOrUpdatePermission;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissionsManagement));
            this.label3 = new System.Windows.Forms.Label();
            this.comBox_DisplayStatus = new System.Windows.Forms.ComboBox();
            this.txt_SearchValue = new System.Windows.Forms.TextBox();
            this.comBox_FilterItems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_RecordsCount = new System.Windows.Forms.Label();
            this.dataGridView_ShowPermissionsInfo = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_ActivePermissions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ShowActivePermissionDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_AddNewPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_UpdatePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DisablingPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip_InActivePermissions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ShowDeletedPermissionDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ActivePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddNewPermission = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowPermissionsInfo)).BeginInit();
            this.contextMenuStrip_ActivePermissions.SuspendLayout();
            this.contextMenuStrip_InActivePermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(6, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 33);
            this.label3.TabIndex = 259;
            this.label3.Text = "Display Status:";
            // 
            // comBox_DisplayStatus
            // 
            this.comBox_DisplayStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_DisplayStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_DisplayStatus.FormattingEnabled = true;
            this.comBox_DisplayStatus.Location = new System.Drawing.Point(196, 146);
            this.comBox_DisplayStatus.Name = "comBox_DisplayStatus";
            this.comBox_DisplayStatus.Size = new System.Drawing.Size(272, 24);
            this.comBox_DisplayStatus.TabIndex = 258;
            this.comBox_DisplayStatus.SelectedIndexChanged += new System.EventHandler(this.comBox_DisplayStatus_SelectedIndexChanged);
            // 
            // txt_SearchValue
            // 
            this.txt_SearchValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_SearchValue.Location = new System.Drawing.Point(136, 209);
            this.txt_SearchValue.Name = "txt_SearchValue";
            this.txt_SearchValue.Size = new System.Drawing.Size(332, 24);
            this.txt_SearchValue.TabIndex = 255;
            this.txt_SearchValue.TextChanged += new System.EventHandler(this.txt_SearchValue_TextChanged);
            this.txt_SearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchValue_KeyPress);
            // 
            // comBox_FilterItems
            // 
            this.comBox_FilterItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_FilterItems.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_FilterItems.FormattingEnabled = true;
            this.comBox_FilterItems.Location = new System.Drawing.Point(136, 179);
            this.comBox_FilterItems.Name = "comBox_FilterItems";
            this.comBox_FilterItems.Size = new System.Drawing.Size(332, 24);
            this.comBox_FilterItems.TabIndex = 254;
            this.comBox_FilterItems.SelectedIndexChanged += new System.EventHandler(this.comBox_FilterItems_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 33);
            this.label2.TabIndex = 253;
            this.label2.Text = "Filter By:";
            // 
            // lab_RecordsCount
            // 
            this.lab_RecordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_RecordsCount.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lab_RecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lab_RecordsCount.Location = new System.Drawing.Point(223, 652);
            this.lab_RecordsCount.Name = "lab_RecordsCount";
            this.lab_RecordsCount.Size = new System.Drawing.Size(281, 33);
            this.lab_RecordsCount.TabIndex = 252;
            this.lab_RecordsCount.Text = "??";
            this.lab_RecordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView_ShowPermissionsInfo
            // 
            this.dataGridView_ShowPermissionsInfo.AllowUserToAddRows = false;
            this.dataGridView_ShowPermissionsInfo.AllowUserToDeleteRows = false;
            this.dataGridView_ShowPermissionsInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_ShowPermissionsInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ShowPermissionsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ShowPermissionsInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ShowPermissionsInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ShowPermissionsInfo.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_ShowPermissionsInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_ShowPermissionsInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ShowPermissionsInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ShowPermissionsInfo.ColumnHeadersHeight = 30;
            this.dataGridView_ShowPermissionsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_ShowPermissionsInfo.ContextMenuStrip = this.contextMenuStrip_ActivePermissions;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ShowPermissionsInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_ShowPermissionsInfo.EnableHeadersVisualStyles = false;
            this.dataGridView_ShowPermissionsInfo.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView_ShowPermissionsInfo.Location = new System.Drawing.Point(12, 239);
            this.dataGridView_ShowPermissionsInfo.Name = "dataGridView_ShowPermissionsInfo";
            this.dataGridView_ShowPermissionsInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ShowPermissionsInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_ShowPermissionsInfo.RowHeadersWidth = 35;
            this.dataGridView_ShowPermissionsInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_ShowPermissionsInfo.Size = new System.Drawing.Size(710, 379);
            this.dataGridView_ShowPermissionsInfo.TabIndex = 251;
            this.dataGridView_ShowPermissionsInfo.DoubleClick += new System.EventHandler(this._ShowPermissionDetails);
            this.dataGridView_ShowPermissionsInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_ShowPermissionsInfo_MouseDown);
            // 
            // contextMenuStrip_ActivePermissions
            // 
            this.contextMenuStrip_ActivePermissions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_ActivePermissions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowActivePermissionDetails,
            this.toolStripSeparator2,
            this.toolStripMenuItem_AddNewPermission,
            this.toolStripMenuItem_UpdatePermission,
            this.toolStripMenuItem_DisablingPermission});
            this.contextMenuStrip_ActivePermissions.Name = "contextMenuStrip1";
            this.contextMenuStrip_ActivePermissions.Size = new System.Drawing.Size(242, 184);
            // 
            // toolStripMenuItem_ShowActivePermissionDetails
            // 
            this.toolStripMenuItem_ShowActivePermissionDetails.Image = global::DVLD_System_Solution.Properties.Resources.CheckList_Document1_32;
            this.toolStripMenuItem_ShowActivePermissionDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowActivePermissionDetails.Name = "toolStripMenuItem_ShowActivePermissionDetails";
            this.toolStripMenuItem_ShowActivePermissionDetails.Size = new System.Drawing.Size(241, 38);
            this.toolStripMenuItem_ShowActivePermissionDetails.Text = "Show Permission Details";
            this.toolStripMenuItem_ShowActivePermissionDetails.Click += new System.EventHandler(this._ShowPermissionDetails);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // toolStripMenuItem_AddNewPermission
            // 
            this.toolStripMenuItem_AddNewPermission.Image = global::DVLD_System_Solution.Properties.Resources.Add_CheckList_Document1_32;
            this.toolStripMenuItem_AddNewPermission.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_AddNewPermission.Name = "toolStripMenuItem_AddNewPermission";
            this.toolStripMenuItem_AddNewPermission.Size = new System.Drawing.Size(241, 38);
            this.toolStripMenuItem_AddNewPermission.Text = "Add New Permission";
            this.toolStripMenuItem_AddNewPermission.Click += new System.EventHandler(this._AddNewPermission_Click);
            // 
            // toolStripMenuItem_UpdatePermission
            // 
            this.toolStripMenuItem_UpdatePermission.Image = global::DVLD_System_Solution.Properties.Resources.Update_CheckList_Document1_32;
            this.toolStripMenuItem_UpdatePermission.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_UpdatePermission.Name = "toolStripMenuItem_UpdatePermission";
            this.toolStripMenuItem_UpdatePermission.Size = new System.Drawing.Size(241, 38);
            this.toolStripMenuItem_UpdatePermission.Text = "Update Permission";
            this.toolStripMenuItem_UpdatePermission.Click += new System.EventHandler(this._UpdatePermission_Click);
            // 
            // toolStripMenuItem_DisablingPermission
            // 
            this.toolStripMenuItem_DisablingPermission.Image = global::DVLD_System_Solution.Properties.Resources.Delete_32;
            this.toolStripMenuItem_DisablingPermission.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_DisablingPermission.Name = "toolStripMenuItem_DisablingPermission";
            this.toolStripMenuItem_DisablingPermission.Size = new System.Drawing.Size(241, 38);
            this.toolStripMenuItem_DisablingPermission.Text = "Disabling Permission";
            this.toolStripMenuItem_DisablingPermission.Click += new System.EventHandler(this._DisablingPermission_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 33F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(190, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 65);
            this.label1.TabIndex = 250;
            this.label1.Text = "Permissions";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip_InActivePermissions
            // 
            this.contextMenuStrip_InActivePermissions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_InActivePermissions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowDeletedPermissionDetails,
            this.toolStripSeparator1,
            this.toolStripMenuItem_ActivePermission});
            this.contextMenuStrip_InActivePermissions.Name = "contextMenuStrip1";
            this.contextMenuStrip_InActivePermissions.Size = new System.Drawing.Size(242, 86);
            // 
            // toolStripMenuItem_ShowDeletedPermissionDetails
            // 
            this.toolStripMenuItem_ShowDeletedPermissionDetails.Image = global::DVLD_System_Solution.Properties.Resources.CheckList_Document1_32;
            this.toolStripMenuItem_ShowDeletedPermissionDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowDeletedPermissionDetails.Name = "toolStripMenuItem_ShowDeletedPermissionDetails";
            this.toolStripMenuItem_ShowDeletedPermissionDetails.Size = new System.Drawing.Size(241, 38);
            this.toolStripMenuItem_ShowDeletedPermissionDetails.Text = "Show Permission Details";
            this.toolStripMenuItem_ShowDeletedPermissionDetails.Click += new System.EventHandler(this._ShowPermissionDetails);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // toolStripMenuItem_ActivePermission
            // 
            this.toolStripMenuItem_ActivePermission.Image = global::DVLD_System_Solution.Properties.Resources.Restore_24;
            this.toolStripMenuItem_ActivePermission.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ActivePermission.Name = "toolStripMenuItem_ActivePermission";
            this.toolStripMenuItem_ActivePermission.Size = new System.Drawing.Size(241, 38);
            this.toolStripMenuItem_ActivePermission.Text = "Active Permission";
            this.toolStripMenuItem_ActivePermission.Click += new System.EventHandler(this._ActivePermission_Click);
            // 
            // btn_AddNewPermission
            // 
            this.btn_AddNewPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewPermission.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btn_AddNewPermission.Image = global::DVLD_System_Solution.Properties.Resources.Add_CheckList_Document1_32;
            this.btn_AddNewPermission.Location = new System.Drawing.Point(670, 192);
            this.btn_AddNewPermission.Name = "btn_AddNewPermission";
            this.btn_AddNewPermission.Size = new System.Drawing.Size(52, 41);
            this.btn_AddNewPermission.TabIndex = 257;
            this.btn_AddNewPermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddNewPermission.UseVisualStyleBackColor = false;
            this.btn_AddNewPermission.Click += new System.EventHandler(this._AddNewPermission_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.Location = new System.Drawing.Point(12, 650);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(110, 38);
            this.btn_Close.TabIndex = 256;
            this.btn_Close.Text = " Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(611, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(111, 99);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 249;
            this.pictureBox11.TabStop = false;
            // 
            // frmPermissionsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(734, 698);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comBox_DisplayStatus);
            this.Controls.Add(this.btn_AddNewPermission);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.txt_SearchValue);
            this.Controls.Add(this.comBox_FilterItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_RecordsCount);
            this.Controls.Add(this.dataGridView_ShowPermissionsInfo);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 737);
            this.MinimumSize = new System.Drawing.Size(750, 737);
            this.Name = "frmPermissionsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permissions Management";
            this.Load += new System.EventHandler(this.frmPermissionsManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowPermissionsInfo)).EndInit();
            this.contextMenuStrip_ActivePermissions.ResumeLayout(false);
            this.contextMenuStrip_InActivePermissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comBox_DisplayStatus;
        private System.Windows.Forms.Button btn_AddNewPermission;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox txt_SearchValue;
        private System.Windows.Forms.ComboBox comBox_FilterItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_RecordsCount;
        private System.Windows.Forms.DataGridView dataGridView_ShowPermissionsInfo;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_InActivePermissions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowDeletedPermissionDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ActivePermission;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ActivePermissions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowActivePermissionDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddNewPermission;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_UpdatePermission;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DisablingPermission;
    }
}