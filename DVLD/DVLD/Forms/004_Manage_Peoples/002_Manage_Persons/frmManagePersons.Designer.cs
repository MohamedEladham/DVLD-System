using Main_Screen.Forms.Persons;

namespace Main_Screen.Froms.Persons_Screen
{
    partial class frmManagePersons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagePersons));
            this.dataGridView_ShowPersonsInfos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_ActivePersons = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ShowActivePersonDelails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_AddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditPersonInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SoftDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_SendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comBox_FilterItems = new System.Windows.Forms.ComboBox();
            this.txt_SearchValue = new System.Windows.Forms.TextBox();
            this.lab_PersonIDToText = new System.Windows.Forms.Label();
            this.lab_NationalNoToText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStripMenuItem_ShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.lab_RecordsCount = new System.Windows.Forms.Label();
            this.btn_AddNewPerson = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItem_ShowDeletedPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_DeletedPersons = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_RestoreDeletedPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.comBox_DisplayStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowPersonsInfos)).BeginInit();
            this.contextMenuStrip_ActivePersons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip_DeletedPersons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_ShowPersonsInfos
            // 
            this.dataGridView_ShowPersonsInfos.AllowUserToAddRows = false;
            this.dataGridView_ShowPersonsInfos.AllowUserToDeleteRows = false;
            this.dataGridView_ShowPersonsInfos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_ShowPersonsInfos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ShowPersonsInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ShowPersonsInfos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ShowPersonsInfos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ShowPersonsInfos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_ShowPersonsInfos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_ShowPersonsInfos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ShowPersonsInfos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ShowPersonsInfos.ColumnHeadersHeight = 30;
            this.dataGridView_ShowPersonsInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_ShowPersonsInfos.ContextMenuStrip = this.contextMenuStrip_ActivePersons;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ShowPersonsInfos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_ShowPersonsInfos.EnableHeadersVisualStyles = false;
            this.dataGridView_ShowPersonsInfos.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView_ShowPersonsInfos.Location = new System.Drawing.Point(12, 305);
            this.dataGridView_ShowPersonsInfos.Name = "dataGridView_ShowPersonsInfos";
            this.dataGridView_ShowPersonsInfos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ShowPersonsInfos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_ShowPersonsInfos.RowHeadersWidth = 35;
            this.dataGridView_ShowPersonsInfos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_ShowPersonsInfos.Size = new System.Drawing.Size(1307, 388);
            this.dataGridView_ShowPersonsInfos.TabIndex = 1;
            this.dataGridView_ShowPersonsInfos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ShowPersonsInfos_CellClick);
            this.dataGridView_ShowPersonsInfos.DoubleClick += new System.EventHandler(this.dataGridView_ShowPersonsInfos_DoubleClick);
            this.dataGridView_ShowPersonsInfos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_ShowPersonsInfos_MouseDown);
            // 
            // contextMenuStrip_ActivePersons
            // 
            this.contextMenuStrip_ActivePersons.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_ActivePersons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowActivePersonDelails,
            this.toolStripSeparator2,
            this.toolStripMenuItem_AddNewPerson,
            this.toolStripMenuItem_EditPersonInfo,
            this.toolStripMenuItem_SoftDeletePerson,
            this.toolStripSeparator1,
            this.toolStripMenuItem_SendEmail,
            this.toolStripMenuItem_PhoneCall});
            this.contextMenuStrip_ActivePersons.Name = "contextMenuStrip1";
            this.contextMenuStrip_ActivePersons.Size = new System.Drawing.Size(196, 244);
            // 
            // toolStripMenuItem_ShowActivePersonDelails
            // 
            this.toolStripMenuItem_ShowActivePersonDelails.Image = global::DVLD_System_Solution.Properties.Resources.Person_Details_32;
            this.toolStripMenuItem_ShowActivePersonDelails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowActivePersonDelails.Name = "toolStripMenuItem_ShowActivePersonDelails";
            this.toolStripMenuItem_ShowActivePersonDelails.Size = new System.Drawing.Size(195, 38);
            this.toolStripMenuItem_ShowActivePersonDelails.Text = "Show Details";
            this.toolStripMenuItem_ShowActivePersonDelails.Click += new System.EventHandler(this.toolStripMenuItem_ShowActivePersonDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // toolStripMenuItem_AddNewPerson
            // 
            this.toolStripMenuItem_AddNewPerson.Image = global::DVLD_System_Solution.Properties.Resources.Add_Person_32;
            this.toolStripMenuItem_AddNewPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_AddNewPerson.Name = "toolStripMenuItem_AddNewPerson";
            this.toolStripMenuItem_AddNewPerson.Size = new System.Drawing.Size(195, 38);
            this.toolStripMenuItem_AddNewPerson.Text = "Add New Person";
            this.toolStripMenuItem_AddNewPerson.Click += new System.EventHandler(this.toolStripMenuItem_AddNewPerson_Click);
            // 
            // toolStripMenuItem_EditPersonInfo
            // 
            this.toolStripMenuItem_EditPersonInfo.Image = global::DVLD_System_Solution.Properties.Resources.Edit_32;
            this.toolStripMenuItem_EditPersonInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_EditPersonInfo.Name = "toolStripMenuItem_EditPersonInfo";
            this.toolStripMenuItem_EditPersonInfo.Size = new System.Drawing.Size(195, 38);
            this.toolStripMenuItem_EditPersonInfo.Text = "Edit";
            this.toolStripMenuItem_EditPersonInfo.Click += new System.EventHandler(this.toolStripMenuItem_EditPersonInfo_Click);
            // 
            // toolStripMenuItem_SoftDeletePerson
            // 
            this.toolStripMenuItem_SoftDeletePerson.Image = global::DVLD_System_Solution.Properties.Resources.Delete_32;
            this.toolStripMenuItem_SoftDeletePerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_SoftDeletePerson.Name = "toolStripMenuItem_SoftDeletePerson";
            this.toolStripMenuItem_SoftDeletePerson.Size = new System.Drawing.Size(195, 38);
            this.toolStripMenuItem_SoftDeletePerson.Text = "Delete";
            this.toolStripMenuItem_SoftDeletePerson.Click += new System.EventHandler(this.toolStripMenuItem_SoftDeletePerson_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // toolStripMenuItem_SendEmail
            // 
            this.toolStripMenuItem_SendEmail.Image = global::DVLD_System_Solution.Properties.Resources.Send_Email_32;
            this.toolStripMenuItem_SendEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_SendEmail.Name = "toolStripMenuItem_SendEmail";
            this.toolStripMenuItem_SendEmail.Size = new System.Drawing.Size(195, 38);
            this.toolStripMenuItem_SendEmail.Text = "Send Email";
            // 
            // toolStripMenuItem_PhoneCall
            // 
            this.toolStripMenuItem_PhoneCall.Image = global::DVLD_System_Solution.Properties.Resources.Phone_Call_32;
            this.toolStripMenuItem_PhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_PhoneCall.Name = "toolStripMenuItem_PhoneCall";
            this.toolStripMenuItem_PhoneCall.Size = new System.Drawing.Size(195, 38);
            this.toolStripMenuItem_PhoneCall.Text = "Phone Call";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(438, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "Persons Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter By:";
            // 
            // comBox_FilterItems
            // 
            this.comBox_FilterItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_FilterItems.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_FilterItems.FormattingEnabled = true;
            this.comBox_FilterItems.Location = new System.Drawing.Point(139, 273);
            this.comBox_FilterItems.Name = "comBox_FilterItems";
            this.comBox_FilterItems.Size = new System.Drawing.Size(284, 24);
            this.comBox_FilterItems.TabIndex = 5;
            this.comBox_FilterItems.SelectedIndexChanged += new System.EventHandler(this.comBox_FilterItems_SelectedIndexChanged);
            // 
            // txt_SearchValue
            // 
            this.txt_SearchValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_SearchValue.Location = new System.Drawing.Point(429, 273);
            this.txt_SearchValue.Name = "txt_SearchValue";
            this.txt_SearchValue.Size = new System.Drawing.Size(242, 24);
            this.txt_SearchValue.TabIndex = 9;
            this.txt_SearchValue.Visible = false;
            this.txt_SearchValue.TextChanged += new System.EventHandler(this.txt_SearchValue_TextChanged);
            this.txt_SearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchValue_KeyPress);
            // 
            // lab_PersonIDToText
            // 
            this.lab_PersonIDToText.AutoSize = true;
            this.lab_PersonIDToText.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lab_PersonIDToText.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_PersonIDToText.Location = new System.Drawing.Point(116, 153);
            this.lab_PersonIDToText.Name = "lab_PersonIDToText";
            this.lab_PersonIDToText.Size = new System.Drawing.Size(29, 17);
            this.lab_PersonIDToText.TabIndex = 218;
            this.lab_PersonIDToText.Text = "???";
            // 
            // lab_NationalNoToText
            // 
            this.lab_NationalNoToText.AutoSize = true;
            this.lab_NationalNoToText.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lab_NationalNoToText.ForeColor = System.Drawing.Color.LimeGreen;
            this.lab_NationalNoToText.Location = new System.Drawing.Point(116, 187);
            this.lab_NationalNoToText.Name = "lab_NationalNoToText";
            this.lab_NationalNoToText.Size = new System.Drawing.Size(29, 17);
            this.lab_NationalNoToText.TabIndex = 219;
            this.lab_NationalNoToText.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 220;
            this.label4.Text = "Person ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Small", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(12, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 221;
            this.label5.Text = "NationalNO:";
            // 
            // toolStripMenuItem_ShowDetails
            // 
            this.toolStripMenuItem_ShowDetails.AutoToolTip = true;
            this.toolStripMenuItem_ShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowDetails.Name = "toolStripMenuItem_ShowDetails";
            this.toolStripMenuItem_ShowDetails.Size = new System.Drawing.Size(218, 38);
            this.toolStripMenuItem_ShowDetails.Text = "Show Details";
            // 
            // lab_RecordsCount
            // 
            this.lab_RecordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_RecordsCount.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lab_RecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lab_RecordsCount.Location = new System.Drawing.Point(533, 710);
            this.lab_RecordsCount.Name = "lab_RecordsCount";
            this.lab_RecordsCount.Size = new System.Drawing.Size(189, 33);
            this.lab_RecordsCount.TabIndex = 223;
            this.lab_RecordsCount.Text = "??";
            this.lab_RecordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_AddNewPerson
            // 
            this.btn_AddNewPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewPerson.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btn_AddNewPerson.Image = global::DVLD_System_Solution.Properties.Resources.Add_Person_40;
            this.btn_AddNewPerson.Location = new System.Drawing.Point(1256, 236);
            this.btn_AddNewPerson.Name = "btn_AddNewPerson";
            this.btn_AddNewPerson.Size = new System.Drawing.Size(63, 53);
            this.btn_AddNewPerson.TabIndex = 7;
            this.btn_AddNewPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddNewPerson.UseVisualStyleBackColor = false;
            this.btn_AddNewPerson.Click += new System.EventHandler(this.btn_AddNewPerson_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.Location = new System.Drawing.Point(12, 707);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(110, 38);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = " Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::DVLD_System_Solution.Properties.Resources.Group_Persons2_560;
            this.pictureBox2.Location = new System.Drawing.Point(515, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(221, 158);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox1.Location = new System.Drawing.Point(1098, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripMenuItem_ShowDeletedPersonDetails
            // 
            this.toolStripMenuItem_ShowDeletedPersonDetails.Image = global::DVLD_System_Solution.Properties.Resources.Person_Details_32;
            this.toolStripMenuItem_ShowDeletedPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_ShowDeletedPersonDetails.Name = "toolStripMenuItem_ShowDeletedPersonDetails";
            this.toolStripMenuItem_ShowDeletedPersonDetails.Size = new System.Drawing.Size(185, 38);
            this.toolStripMenuItem_ShowDeletedPersonDetails.Text = "Show Details";
            this.toolStripMenuItem_ShowDeletedPersonDetails.Click += new System.EventHandler(this.toolStripMenuItem_ShowDeletedPersonDetails_Click);
            // 
            // contextMenuStrip_DeletedPersons
            // 
            this.contextMenuStrip_DeletedPersons.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip_DeletedPersons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowDeletedPersonDetails,
            this.toolStripSeparator3,
            this.toolStripMenuItem_RestoreDeletedPerson});
            this.contextMenuStrip_DeletedPersons.Name = "contextMenuStrip1";
            this.contextMenuStrip_DeletedPersons.Size = new System.Drawing.Size(186, 86);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripMenuItem_RestoreDeletedPerson
            // 
            this.toolStripMenuItem_RestoreDeletedPerson.Image = global::DVLD_System_Solution.Properties.Resources.Restore_24;
            this.toolStripMenuItem_RestoreDeletedPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem_RestoreDeletedPerson.Name = "toolStripMenuItem_RestoreDeletedPerson";
            this.toolStripMenuItem_RestoreDeletedPerson.Size = new System.Drawing.Size(185, 38);
            this.toolStripMenuItem_RestoreDeletedPerson.Text = "Restore Person";
            this.toolStripMenuItem_RestoreDeletedPerson.Click += new System.EventHandler(this.toolStripMenuItem_RestoreDeletedPerson_Click);
            // 
            // comBox_DisplayStatus
            // 
            this.comBox_DisplayStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_DisplayStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_DisplayStatus.FormattingEnabled = true;
            this.comBox_DisplayStatus.Location = new System.Drawing.Point(193, 243);
            this.comBox_DisplayStatus.Name = "comBox_DisplayStatus";
            this.comBox_DisplayStatus.Size = new System.Drawing.Size(230, 24);
            this.comBox_DisplayStatus.TabIndex = 225;
            this.comBox_DisplayStatus.SelectedIndexChanged += new System.EventHandler(this.comBox_DisplayStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(12, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 33);
            this.label3.TabIndex = 226;
            this.label3.Text = "Person Status:";
            // 
            // frmManagePersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1331, 757);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comBox_DisplayStatus);
            this.Controls.Add(this.lab_RecordsCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_NationalNoToText);
            this.Controls.Add(this.lab_PersonIDToText);
            this.Controls.Add(this.txt_SearchValue);
            this.Controls.Add(this.btn_AddNewPerson);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.comBox_FilterItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridView_ShowPersonsInfos);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1347, 796);
            this.Name = "frmManagePersons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Persons Management Screen";
            this.Load += new System.EventHandler(this.frmManagePersons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowPersonsInfos)).EndInit();
            this.contextMenuStrip_ActivePersons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip_DeletedPersons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView_ShowPersonsInfos;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comBox_FilterItems;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_AddNewPerson;
        private System.Windows.Forms.TextBox txt_SearchValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ActivePersons;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditPersonInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SoftDeletePerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SendEmail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PhoneCall;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowActivePersonDelails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowDetails;
        private System.Windows.Forms.Label lab_PersonIDToText;
        private System.Windows.Forms.Label lab_NationalNoToText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_RecordsCount;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowDeletedPersonDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DeletedPersons;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RestoreDeletedPerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ComboBox comBox_DisplayStatus;
        private System.Windows.Forms.Label label3;
    }
}