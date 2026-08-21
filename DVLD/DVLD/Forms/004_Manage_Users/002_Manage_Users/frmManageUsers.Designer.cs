using Main_Screen.Forms.Persons;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    partial class frmManageUsers
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
            frmCreateLoginInfo.CreatedLoginInfo -= _GetCreatedLoginInfo;
            frmUpdateLoginInfo.UpdateLoginInfo -= _GetIsUpdateLoginInfo;
            frmAddUpdatePersons.AddOrUpdatePersonDialogResultReceived -= _GetIsAddOrUpdatePersonDialogResult;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUsers));
            this.label3 = new System.Windows.Forms.Label();
            this.comBox_DisplayStatus = new System.Windows.Forms.ComboBox();
            this.lab_RecordsCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_UserIDToText = new System.Windows.Forms.Label();
            this.lab_PersonIDToText = new System.Windows.Forms.Label();
            this.txt_SearchValue = new System.Windows.Forms.TextBox();
            this.comBox_FilterItems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_ShowUsersInfos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_ActiveUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ShowUserDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_AddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_UpdateUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SoftDeleteActiveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_UpdateLoginInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_InActiveUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ShowInActiveUserDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ActiveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_SoftDeleteInActiveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DeletedUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_RestoreDeletedUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ShowDeletedUserDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddNewUser = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowUsersInfos)).BeginInit();
            this.contextMenuStrip_ActiveUsers.SuspendLayout();
            this.contextMenuStrip_InActiveUsers.SuspendLayout();
            this.contextMenuStrip_DeletedUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(12, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 33);
            this.label3.TabIndex = 242;
            this.label3.Text = "Display Status:";
            // 
            // comBox_DisplayStatus
            // 
            this.comBox_DisplayStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_DisplayStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_DisplayStatus.FormattingEnabled = true;
            this.comBox_DisplayStatus.Location = new System.Drawing.Point(200, 311);
            this.comBox_DisplayStatus.Name = "comBox_DisplayStatus";
            this.comBox_DisplayStatus.Size = new System.Drawing.Size(232, 24);
            this.comBox_DisplayStatus.TabIndex = 241;
            this.comBox_DisplayStatus.SelectedIndexChanged += new System.EventHandler(this.comBox_DisplayStatus_SelectedIndexChanged);
            // 
            // lab_RecordsCount
            // 
            this.lab_RecordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_RecordsCount.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lab_RecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lab_RecordsCount.Location = new System.Drawing.Point(488, 725);
            this.lab_RecordsCount.Name = "lab_RecordsCount";
            this.lab_RecordsCount.Size = new System.Drawing.Size(160, 33);
            this.lab_RecordsCount.TabIndex = 240;
            this.lab_RecordsCount.Text = "??";
            this.lab_RecordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Small", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(14, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 239;
            this.label5.Text = "Person ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(14, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 238;
            this.label4.Text = "User ID:";
            // 
            // lab_UserIDToText
            // 
            this.lab_UserIDToText.AutoSize = true;
            this.lab_UserIDToText.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lab_UserIDToText.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_UserIDToText.Location = new System.Drawing.Point(111, 198);
            this.lab_UserIDToText.Name = "lab_UserIDToText";
            this.lab_UserIDToText.Size = new System.Drawing.Size(29, 17);
            this.lab_UserIDToText.TabIndex = 237;
            this.lab_UserIDToText.Text = "???";
            // 
            // lab_PersonIDToText
            // 
            this.lab_PersonIDToText.AutoSize = true;
            this.lab_PersonIDToText.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lab_PersonIDToText.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_PersonIDToText.Location = new System.Drawing.Point(111, 233);
            this.lab_PersonIDToText.Name = "lab_PersonIDToText";
            this.lab_PersonIDToText.Size = new System.Drawing.Size(29, 17);
            this.lab_PersonIDToText.TabIndex = 236;
            this.lab_PersonIDToText.Text = "???";
            // 
            // txt_SearchValue
            // 
            this.txt_SearchValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_SearchValue.Location = new System.Drawing.Point(445, 270);
            this.txt_SearchValue.Name = "txt_SearchValue";
            this.txt_SearchValue.Size = new System.Drawing.Size(242, 24);
            this.txt_SearchValue.TabIndex = 235;
            this.txt_SearchValue.TextChanged += new System.EventHandler(this.txt_SearchValue_TextChanged);
            // 
            // comBox_FilterItems
            // 
            this.comBox_FilterItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_FilterItems.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_FilterItems.FormattingEnabled = true;
            this.comBox_FilterItems.Location = new System.Drawing.Point(200, 270);
            this.comBox_FilterItems.Name = "comBox_FilterItems";
            this.comBox_FilterItems.Size = new System.Drawing.Size(232, 24);
            this.comBox_FilterItems.TabIndex = 232;
            this.comBox_FilterItems.SelectedIndexChanged += new System.EventHandler(this.comBox_FilterItems_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 33);
            this.label2.TabIndex = 231;
            this.label2.Text = "Filter By: ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(411, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 41);
            this.label1.TabIndex = 230;
            this.label1.Text = "Users Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView_ShowUsersInfos
            // 
            this.dataGridView_ShowUsersInfos.AllowUserToAddRows = false;
            this.dataGridView_ShowUsersInfos.AllowUserToDeleteRows = false;
            this.dataGridView_ShowUsersInfos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_ShowUsersInfos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ShowUsersInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ShowUsersInfos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ShowUsersInfos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ShowUsersInfos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_ShowUsersInfos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_ShowUsersInfos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ShowUsersInfos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ShowUsersInfos.ColumnHeadersHeight = 30;
            this.dataGridView_ShowUsersInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_ShowUsersInfos.ContextMenuStrip = this.contextMenuStrip_ActiveUsers;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ShowUsersInfos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_ShowUsersInfos.EnableHeadersVisualStyles = false;
            this.dataGridView_ShowUsersInfos.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView_ShowUsersInfos.Location = new System.Drawing.Point(12, 341);
            this.dataGridView_ShowUsersInfos.Name = "dataGridView_ShowUsersInfos";
            this.dataGridView_ShowUsersInfos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ShowUsersInfos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_ShowUsersInfos.RowHeadersWidth = 35;
            this.dataGridView_ShowUsersInfos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_ShowUsersInfos.Size = new System.Drawing.Size(1136, 376);
            this.dataGridView_ShowUsersInfos.TabIndex = 228;
            this.dataGridView_ShowUsersInfos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ShowUsersInfos_CellClick);
            this.dataGridView_ShowUsersInfos.DoubleClick += new System.EventHandler(this.dataGridView_ShowUsersInfos_DoubleClick);
            this.dataGridView_ShowUsersInfos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_ShowUsersInfos_MouseDown);
            // 
            // contextMenuStrip_ActiveUsers
            // 
            this.contextMenuStrip_ActiveUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_ActiveUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowUserDetails,
            this.toolStripSeparator2,
            this.toolStripMenuItem_AddNewUser,
            this.toolStripMenuItem_UpdateUserInfo,
            this.toolStripMenuItem_SoftDeleteActiveUser,
            this.toolStripSeparator1,
            this.toolStripMenuItem_UpdateLoginInfo});
            this.contextMenuStrip_ActiveUsers.Name = "contextMenuStrip1";
            this.contextMenuStrip_ActiveUsers.Size = new System.Drawing.Size(206, 206);
            // 
            // toolStripMenuItem_ShowUserDetails
            // 
            this.toolStripMenuItem_ShowUserDetails.Image = global::DVLD_System_Solution.Properties.Resources.Person_Details_32;
            this.toolStripMenuItem_ShowUserDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowUserDetails.Name = "toolStripMenuItem_ShowUserDetails";
            this.toolStripMenuItem_ShowUserDetails.Size = new System.Drawing.Size(205, 38);
            this.toolStripMenuItem_ShowUserDetails.Text = "Show User Details";
            this.toolStripMenuItem_ShowUserDetails.Click += new System.EventHandler(this.toolStripMenuItem_ShowUserDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItem_AddNewUser
            // 
            this.toolStripMenuItem_AddNewUser.Image = global::DVLD_System_Solution.Properties.Resources.Add_New_User_32;
            this.toolStripMenuItem_AddNewUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_AddNewUser.Name = "toolStripMenuItem_AddNewUser";
            this.toolStripMenuItem_AddNewUser.Size = new System.Drawing.Size(205, 38);
            this.toolStripMenuItem_AddNewUser.Text = "Add New User";
            this.toolStripMenuItem_AddNewUser.Click += new System.EventHandler(this.toolStripMenuItem_AddNewUser_Click);
            // 
            // toolStripMenuItem_UpdateUserInfo
            // 
            this.toolStripMenuItem_UpdateUserInfo.Image = global::DVLD_System_Solution.Properties.Resources.Edit_32;
            this.toolStripMenuItem_UpdateUserInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_UpdateUserInfo.Name = "toolStripMenuItem_UpdateUserInfo";
            this.toolStripMenuItem_UpdateUserInfo.Size = new System.Drawing.Size(205, 38);
            this.toolStripMenuItem_UpdateUserInfo.Text = "Update User Info";
            this.toolStripMenuItem_UpdateUserInfo.Click += new System.EventHandler(this.toolStripMenuItem_UpdateUserInfo_Click);
            // 
            // toolStripMenuItem_SoftDeleteActiveUser
            // 
            this.toolStripMenuItem_SoftDeleteActiveUser.Image = global::DVLD_System_Solution.Properties.Resources.Delete_32;
            this.toolStripMenuItem_SoftDeleteActiveUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_SoftDeleteActiveUser.Name = "toolStripMenuItem_SoftDeleteActiveUser";
            this.toolStripMenuItem_SoftDeleteActiveUser.Size = new System.Drawing.Size(205, 38);
            this.toolStripMenuItem_SoftDeleteActiveUser.Text = "Delete User";
            this.toolStripMenuItem_SoftDeleteActiveUser.Click += new System.EventHandler(this.toolStripMenuItem_SoftDeleteActiveUser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItem_UpdateLoginInfo
            // 
            this.toolStripMenuItem_UpdateLoginInfo.Image = global::DVLD_System_Solution.Properties.Resources.User_Access_32;
            this.toolStripMenuItem_UpdateLoginInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_UpdateLoginInfo.Name = "toolStripMenuItem_UpdateLoginInfo";
            this.toolStripMenuItem_UpdateLoginInfo.Size = new System.Drawing.Size(205, 38);
            this.toolStripMenuItem_UpdateLoginInfo.Text = "Update Login Info";
            this.toolStripMenuItem_UpdateLoginInfo.Click += new System.EventHandler(this.toolStripMenuItem_UpdateLoginInfo_Click);
            // 
            // contextMenuStrip_InActiveUsers
            // 
            this.contextMenuStrip_InActiveUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_InActiveUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowInActiveUserDetails,
            this.toolStripSeparator5,
            this.toolStripMenuItem_ActiveUser,
            this.toolStripSeparator3,
            this.toolStripMenuItem_SoftDeleteInActiveUser});
            this.contextMenuStrip_InActiveUsers.Name = "contextMenuStrip1";
            this.contextMenuStrip_InActiveUsers.Size = new System.Drawing.Size(258, 130);
            // 
            // toolStripMenuItem_ShowInActiveUserDetails
            // 
            this.toolStripMenuItem_ShowInActiveUserDetails.Image = global::DVLD_System_Solution.Properties.Resources.Person_Details_32;
            this.toolStripMenuItem_ShowInActiveUserDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowInActiveUserDetails.Name = "toolStripMenuItem_ShowInActiveUserDetails";
            this.toolStripMenuItem_ShowInActiveUserDetails.Size = new System.Drawing.Size(257, 38);
            this.toolStripMenuItem_ShowInActiveUserDetails.Text = "Show InActive User Details";
            this.toolStripMenuItem_ShowInActiveUserDetails.Click += new System.EventHandler(this.toolStripMenuItem_ShowInActiveUserDetails_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(254, 6);
            // 
            // toolStripMenuItem_ActiveUser
            // 
            this.toolStripMenuItem_ActiveUser.Image = global::DVLD_System_Solution.Properties.Resources.Active_User4_32;
            this.toolStripMenuItem_ActiveUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ActiveUser.Name = "toolStripMenuItem_ActiveUser";
            this.toolStripMenuItem_ActiveUser.Size = new System.Drawing.Size(257, 38);
            this.toolStripMenuItem_ActiveUser.Text = "Active User";
            this.toolStripMenuItem_ActiveUser.Click += new System.EventHandler(this.toolStripMenuItem_ActiveUser_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(254, 6);
            // 
            // toolStripMenuItem_SoftDeleteInActiveUser
            // 
            this.toolStripMenuItem_SoftDeleteInActiveUser.Image = global::DVLD_System_Solution.Properties.Resources.Delete_32;
            this.toolStripMenuItem_SoftDeleteInActiveUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_SoftDeleteInActiveUser.Name = "toolStripMenuItem_SoftDeleteInActiveUser";
            this.toolStripMenuItem_SoftDeleteInActiveUser.Size = new System.Drawing.Size(257, 38);
            this.toolStripMenuItem_SoftDeleteInActiveUser.Text = "Delete User";
            this.toolStripMenuItem_SoftDeleteInActiveUser.Click += new System.EventHandler(this.toolStripMenuItem_SoftDeleteInActiveUser_Click);
            // 
            // contextMenuStrip_DeletedUsers
            // 
            this.contextMenuStrip_DeletedUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_DeletedUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_RestoreDeletedUser,
            this.toolStripSeparator4,
            this.toolStripMenuItem_ShowDeletedUserDetails});
            this.contextMenuStrip_DeletedUsers.Name = "contextMenuStrip1";
            this.contextMenuStrip_DeletedUsers.Size = new System.Drawing.Size(173, 86);
            // 
            // toolStripMenuItem_RestoreDeletedUser
            // 
            this.toolStripMenuItem_RestoreDeletedUser.Image = global::DVLD_System_Solution.Properties.Resources.Restore_24;
            this.toolStripMenuItem_RestoreDeletedUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_RestoreDeletedUser.Name = "toolStripMenuItem_RestoreDeletedUser";
            this.toolStripMenuItem_RestoreDeletedUser.Size = new System.Drawing.Size(172, 38);
            this.toolStripMenuItem_RestoreDeletedUser.Text = "Restore User";
            this.toolStripMenuItem_RestoreDeletedUser.Click += new System.EventHandler(this.toolStripMenuItem_RestoreDeletedUser_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItem_ShowDeletedUserDetails
            // 
            this.toolStripMenuItem_ShowDeletedUserDetails.Image = global::DVLD_System_Solution.Properties.Resources.Person_Details_32;
            this.toolStripMenuItem_ShowDeletedUserDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowDeletedUserDetails.Name = "toolStripMenuItem_ShowDeletedUserDetails";
            this.toolStripMenuItem_ShowDeletedUserDetails.Size = new System.Drawing.Size(172, 38);
            this.toolStripMenuItem_ShowDeletedUserDetails.Text = "Show Details";
            this.toolStripMenuItem_ShowDeletedUserDetails.Click += new System.EventHandler(this.toolStripMenuItem_ShowDeletedUserDetails_Click);
            // 
            // btn_AddNewUser
            // 
            this.btn_AddNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btn_AddNewUser.Image = global::DVLD_System_Solution.Properties.Resources.Add_New_User_32;
            this.btn_AddNewUser.Location = new System.Drawing.Point(1085, 279);
            this.btn_AddNewUser.Name = "btn_AddNewUser";
            this.btn_AddNewUser.Size = new System.Drawing.Size(63, 56);
            this.btn_AddNewUser.TabIndex = 234;
            this.btn_AddNewUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddNewUser.UseVisualStyleBackColor = false;
            this.btn_AddNewUser.Click += new System.EventHandler(this.btn_OpenfrmAddUpdatePersonInfo_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.Location = new System.Drawing.Point(12, 723);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(110, 38);
            this.btn_Close.TabIndex = 233;
            this.btn_Close.Text = " Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::DVLD_System_Solution.Properties.Resources.Users2_400;
            this.pictureBox2.Location = new System.Drawing.Point(462, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(227, 165);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 229;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox1.Location = new System.Drawing.Point(927, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 227;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 773);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comBox_DisplayStatus);
            this.Controls.Add(this.lab_RecordsCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_UserIDToText);
            this.Controls.Add(this.lab_PersonIDToText);
            this.Controls.Add(this.txt_SearchValue);
            this.Controls.Add(this.btn_AddNewUser);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.comBox_FilterItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridView_ShowUsersInfos);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1176, 812);
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users Managements Screen";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowUsersInfos)).EndInit();
            this.contextMenuStrip_ActiveUsers.ResumeLayout(false);
            this.contextMenuStrip_InActiveUsers.ResumeLayout(false);
            this.contextMenuStrip_DeletedUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comBox_DisplayStatus;
        private System.Windows.Forms.Label lab_RecordsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_UserIDToText;
        private System.Windows.Forms.Label lab_PersonIDToText;
        private System.Windows.Forms.TextBox txt_SearchValue;
        private System.Windows.Forms.Button btn_AddNewUser;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ComboBox comBox_FilterItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridView_ShowUsersInfos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ActiveUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowUserDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddNewUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_UpdateUserInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SoftDeleteActiveUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_UpdateLoginInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_InActiveUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ActiveUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowInActiveUserDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DeletedUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RestoreDeletedUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowDeletedUserDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SoftDeleteInActiveUser;
    }
}