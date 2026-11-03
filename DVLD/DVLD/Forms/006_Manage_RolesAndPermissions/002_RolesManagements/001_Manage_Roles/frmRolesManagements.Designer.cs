using DVLD_System_Solution.Forms._005_Manage_Roles._002_AddRoles;

namespace DVLD_System_Solution.Forms._005_Manage_Roles._001_ShowRoles
{
    partial class frmRolesManagements
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
                frmAddUpdateRole.AddUpdateRole -= _GetIsAddOrUpdateRole;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRolesManagements));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_ShowRolesInfo = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_ActiveRoles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ShowActiveRoleDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_AddNewRole = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_UpdateRoleInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SoftDeleteRole = new System.Windows.Forms.ToolStripMenuItem();
            this.lab_RecordsCount = new System.Windows.Forms.Label();
            this.txt_SearchValue = new System.Windows.Forms.TextBox();
            this.comBox_FilterItems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comBox_DisplayStatus = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip_DeletedRoles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ShowDeletedRoleDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RestoreRole = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddNewRole = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowRolesInfo)).BeginInit();
            this.contextMenuStrip_ActiveRoles.SuspendLayout();
            this.contextMenuStrip_DeletedRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 33F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(148, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 65);
            this.label1.TabIndex = 224;
            this.label1.Text = "Roles Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView_ShowRolesInfo
            // 
            this.dataGridView_ShowRolesInfo.AllowUserToAddRows = false;
            this.dataGridView_ShowRolesInfo.AllowUserToDeleteRows = false;
            this.dataGridView_ShowRolesInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_ShowRolesInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ShowRolesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ShowRolesInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ShowRolesInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ShowRolesInfo.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_ShowRolesInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_ShowRolesInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ShowRolesInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ShowRolesInfo.ColumnHeadersHeight = 30;
            this.dataGridView_ShowRolesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_ShowRolesInfo.ContextMenuStrip = this.contextMenuStrip_ActiveRoles;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ShowRolesInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_ShowRolesInfo.EnableHeadersVisualStyles = false;
            this.dataGridView_ShowRolesInfo.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView_ShowRolesInfo.Location = new System.Drawing.Point(12, 209);
            this.dataGridView_ShowRolesInfo.Name = "dataGridView_ShowRolesInfo";
            this.dataGridView_ShowRolesInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ShowRolesInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_ShowRolesInfo.RowHeadersWidth = 35;
            this.dataGridView_ShowRolesInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_ShowRolesInfo.Size = new System.Drawing.Size(729, 261);
            this.dataGridView_ShowRolesInfo.TabIndex = 229;
            this.dataGridView_ShowRolesInfo.DoubleClick += new System.EventHandler(this.dataGridView_ShowRolesInfo_DoubleClick);
            this.dataGridView_ShowRolesInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_ShowRolesInfo_MouseDown);
            // 
            // contextMenuStrip_ActiveRoles
            // 
            this.contextMenuStrip_ActiveRoles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_ActiveRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowActiveRoleDetails,
            this.toolStripSeparator2,
            this.toolStripMenuItem_AddNewRole,
            this.toolStripMenuItem_UpdateRoleInfo,
            this.toolStripMenuItem_SoftDeleteRole});
            this.contextMenuStrip_ActiveRoles.Name = "contextMenuStrip1";
            this.contextMenuStrip_ActiveRoles.Size = new System.Drawing.Size(203, 162);
            // 
            // toolStripMenuItem_ShowActiveRoleDetails
            // 
            this.toolStripMenuItem_ShowActiveRoleDetails.Image = global::DVLD_System_Solution.Properties.Resources.CheckList_Document1_32;
            this.toolStripMenuItem_ShowActiveRoleDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowActiveRoleDetails.Name = "toolStripMenuItem_ShowActiveRoleDetails";
            this.toolStripMenuItem_ShowActiveRoleDetails.Size = new System.Drawing.Size(202, 38);
            this.toolStripMenuItem_ShowActiveRoleDetails.Text = "Show Role Details";
            this.toolStripMenuItem_ShowActiveRoleDetails.Click += new System.EventHandler(this.toolStripMenuItem_ShowRoleDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripMenuItem_AddNewRole
            // 
            this.toolStripMenuItem_AddNewRole.Image = global::DVLD_System_Solution.Properties.Resources.Add_CheckList_Document1_32;
            this.toolStripMenuItem_AddNewRole.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_AddNewRole.Name = "toolStripMenuItem_AddNewRole";
            this.toolStripMenuItem_AddNewRole.Size = new System.Drawing.Size(202, 38);
            this.toolStripMenuItem_AddNewRole.Text = "Add New Role";
            this.toolStripMenuItem_AddNewRole.Click += new System.EventHandler(this.toolStripMenuItem_AddNewRole_Click);
            // 
            // toolStripMenuItem_UpdateRoleInfo
            // 
            this.toolStripMenuItem_UpdateRoleInfo.Image = global::DVLD_System_Solution.Properties.Resources.Update_CheckList_Document1_32;
            this.toolStripMenuItem_UpdateRoleInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_UpdateRoleInfo.Name = "toolStripMenuItem_UpdateRoleInfo";
            this.toolStripMenuItem_UpdateRoleInfo.Size = new System.Drawing.Size(202, 38);
            this.toolStripMenuItem_UpdateRoleInfo.Text = "Update Role";
            this.toolStripMenuItem_UpdateRoleInfo.Click += new System.EventHandler(this.toolStripMenuItem_UpdateRoleInfo_Click);
            // 
            // toolStripMenuItem_SoftDeleteRole
            // 
            this.toolStripMenuItem_SoftDeleteRole.Image = global::DVLD_System_Solution.Properties.Resources.Delete_File1_32;
            this.toolStripMenuItem_SoftDeleteRole.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_SoftDeleteRole.Name = "toolStripMenuItem_SoftDeleteRole";
            this.toolStripMenuItem_SoftDeleteRole.Size = new System.Drawing.Size(202, 38);
            this.toolStripMenuItem_SoftDeleteRole.Text = "Delete Role";
            this.toolStripMenuItem_SoftDeleteRole.Click += new System.EventHandler(this.toolStripMenuItem_SoftDeleteRole_Click);
            // 
            // lab_RecordsCount
            // 
            this.lab_RecordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_RecordsCount.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lab_RecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lab_RecordsCount.Location = new System.Drawing.Point(292, 500);
            this.lab_RecordsCount.Name = "lab_RecordsCount";
            this.lab_RecordsCount.Size = new System.Drawing.Size(187, 33);
            this.lab_RecordsCount.TabIndex = 241;
            this.lab_RecordsCount.Text = "??";
            this.lab_RecordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_SearchValue
            // 
            this.txt_SearchValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_SearchValue.Location = new System.Drawing.Point(134, 179);
            this.txt_SearchValue.Name = "txt_SearchValue";
            this.txt_SearchValue.Size = new System.Drawing.Size(296, 24);
            this.txt_SearchValue.TabIndex = 244;
            this.txt_SearchValue.Visible = false;
            this.txt_SearchValue.TextChanged += new System.EventHandler(this.txt_SearchValue_TextChanged);
            this.txt_SearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchValue_KeyPress);
            // 
            // comBox_FilterItems
            // 
            this.comBox_FilterItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_FilterItems.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_FilterItems.FormattingEnabled = true;
            this.comBox_FilterItems.Location = new System.Drawing.Point(134, 149);
            this.comBox_FilterItems.Name = "comBox_FilterItems";
            this.comBox_FilterItems.Size = new System.Drawing.Size(296, 24);
            this.comBox_FilterItems.TabIndex = 243;
            this.comBox_FilterItems.SelectedIndexChanged += new System.EventHandler(this.comBox_FilterItems_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(7, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 33);
            this.label2.TabIndex = 242;
            this.label2.Text = "Filter By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 33);
            this.label3.TabIndex = 248;
            this.label3.Text = "Display Status:";
            // 
            // comBox_DisplayStatus
            // 
            this.comBox_DisplayStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_DisplayStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_DisplayStatus.FormattingEnabled = true;
            this.comBox_DisplayStatus.Location = new System.Drawing.Point(194, 116);
            this.comBox_DisplayStatus.Name = "comBox_DisplayStatus";
            this.comBox_DisplayStatus.Size = new System.Drawing.Size(236, 24);
            this.comBox_DisplayStatus.TabIndex = 247;
            this.comBox_DisplayStatus.SelectedIndexChanged += new System.EventHandler(this.comBox_DisplayStatus_SelectedIndexChanged);
            // 
            // contextMenuStrip_DeletedRoles
            // 
            this.contextMenuStrip_DeletedRoles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_DeletedRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowDeletedRoleDetails,
            this.toolStripSeparator1,
            this.toolStripMenuItem_RestoreRole});
            this.contextMenuStrip_DeletedRoles.Name = "contextMenuStrip1";
            this.contextMenuStrip_DeletedRoles.Size = new System.Drawing.Size(203, 86);
            // 
            // toolStripMenuItem_ShowDeletedRoleDetails
            // 
            this.toolStripMenuItem_ShowDeletedRoleDetails.Image = global::DVLD_System_Solution.Properties.Resources.CheckList_Document1_32;
            this.toolStripMenuItem_ShowDeletedRoleDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowDeletedRoleDetails.Name = "toolStripMenuItem_ShowDeletedRoleDetails";
            this.toolStripMenuItem_ShowDeletedRoleDetails.Size = new System.Drawing.Size(202, 38);
            this.toolStripMenuItem_ShowDeletedRoleDetails.Text = "Show Role Details";
            this.toolStripMenuItem_ShowDeletedRoleDetails.Click += new System.EventHandler(this.toolStripMenuItem_ShowRoleDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripMenuItem_RestoreRole
            // 
            this.toolStripMenuItem_RestoreRole.Image = global::DVLD_System_Solution.Properties.Resources.Restore_24;
            this.toolStripMenuItem_RestoreRole.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_RestoreRole.Name = "toolStripMenuItem_RestoreRole";
            this.toolStripMenuItem_RestoreRole.Size = new System.Drawing.Size(202, 38);
            this.toolStripMenuItem_RestoreRole.Text = "Restore Role";
            this.toolStripMenuItem_RestoreRole.Click += new System.EventHandler(this.toolStripMenuItem_RestoreRole_Click);
            // 
            // btn_AddNewRole
            // 
            this.btn_AddNewRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewRole.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btn_AddNewRole.Image = global::DVLD_System_Solution.Properties.Resources.Add_CheckList_Document1_32;
            this.btn_AddNewRole.Location = new System.Drawing.Point(697, 164);
            this.btn_AddNewRole.Name = "btn_AddNewRole";
            this.btn_AddNewRole.Size = new System.Drawing.Size(44, 41);
            this.btn_AddNewRole.TabIndex = 246;
            this.btn_AddNewRole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddNewRole.UseVisualStyleBackColor = false;
            this.btn_AddNewRole.Click += new System.EventHandler(this.btn_AddNewRole_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.Location = new System.Drawing.Point(12, 498);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(110, 38);
            this.btn_Close.TabIndex = 245;
            this.btn_Close.Text = " Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(638, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(103, 99);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 223;
            this.pictureBox11.TabStop = false;
            // 
            // frmRolesManagements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(753, 548);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comBox_DisplayStatus);
            this.Controls.Add(this.btn_AddNewRole);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.txt_SearchValue);
            this.Controls.Add(this.comBox_FilterItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_RecordsCount);
            this.Controls.Add(this.dataGridView_ShowRolesInfo);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(769, 587);
            this.MinimumSize = new System.Drawing.Size(769, 587);
            this.Name = "frmRolesManagements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roles Managements";
            this.Load += new System.EventHandler(this.frmShowRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowRolesInfo)).EndInit();
            this.contextMenuStrip_ActiveRoles.ResumeLayout(false);
            this.contextMenuStrip_DeletedRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_ShowRolesInfo;
        private System.Windows.Forms.Label lab_RecordsCount;
        private System.Windows.Forms.TextBox txt_SearchValue;
        private System.Windows.Forms.ComboBox comBox_FilterItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ActiveRoles;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowActiveRoleDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddNewRole;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_UpdateRoleInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SoftDeleteRole;
        private System.Windows.Forms.Button btn_AddNewRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comBox_DisplayStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DeletedRoles;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowDeletedRoleDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RestoreRole;
    }
}