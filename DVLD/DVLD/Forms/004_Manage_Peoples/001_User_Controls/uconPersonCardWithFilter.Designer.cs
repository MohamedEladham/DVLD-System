namespace DVLD_System_Solution.Forms._003_Manage_People.Controls
{
    partial class uconPersonCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_AddNewPerson = new System.Windows.Forms.Button();
            this.txt_SearchValue = new System.Windows.Forms.TextBox();
            this.btn_GetPersonBy = new System.Windows.Forms.Button();
            this.comBox_FilterItems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.uconShowPersonInfo1 = new DVLD_System_Solution.Forms._003_Manage_People.Controls.uconShowPersonInfo();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_AddNewPerson);
            this.groupBox1.Controls.Add(this.txt_SearchValue);
            this.groupBox1.Controls.Add(this.btn_GetPersonBy);
            this.groupBox1.Controls.Add(this.comBox_FilterItems);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btn_AddNewPerson
            // 
            this.btn_AddNewPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_AddNewPerson.FlatAppearance.BorderSize = 0;
            this.btn_AddNewPerson.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btn_AddNewPerson.Image = global::DVLD_System_Solution.Properties.Resources.Add_Person_32;
            this.btn_AddNewPerson.Location = new System.Drawing.Point(591, 30);
            this.btn_AddNewPerson.Name = "btn_AddNewPerson";
            this.btn_AddNewPerson.Size = new System.Drawing.Size(46, 44);
            this.btn_AddNewPerson.TabIndex = 240;
            this.btn_AddNewPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddNewPerson.UseVisualStyleBackColor = false;
            this.btn_AddNewPerson.Click += new System.EventHandler(this.btn_AddNewPerson_Click);
            // 
            // txt_SearchValue
            // 
            this.txt_SearchValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_SearchValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_SearchValue.Location = new System.Drawing.Point(338, 50);
            this.txt_SearchValue.Name = "txt_SearchValue";
            this.txt_SearchValue.Size = new System.Drawing.Size(180, 24);
            this.txt_SearchValue.TabIndex = 239;
            this.txt_SearchValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_SearchValue_MouseClick);
            this.txt_SearchValue.TextChanged += new System.EventHandler(this.txt_SearchValue_TextChanged);
            this.txt_SearchValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchValue_KeyPress);
            // 
            // btn_GetPersonBy
            // 
            this.btn_GetPersonBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_GetPersonBy.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GetPersonBy.FlatAppearance.BorderSize = 0;
            this.btn_GetPersonBy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btn_GetPersonBy.Image = global::DVLD_System_Solution.Properties.Resources.Search_Person;
            this.btn_GetPersonBy.Location = new System.Drawing.Point(539, 30);
            this.btn_GetPersonBy.Name = "btn_GetPersonBy";
            this.btn_GetPersonBy.Size = new System.Drawing.Size(46, 44);
            this.btn_GetPersonBy.TabIndex = 238;
            this.btn_GetPersonBy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_GetPersonBy.UseVisualStyleBackColor = false;
            this.btn_GetPersonBy.Click += new System.EventHandler(this.btn_GetPersonBy_Click);
            // 
            // comBox_FilterItems
            // 
            this.comBox_FilterItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comBox_FilterItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBox_FilterItems.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comBox_FilterItems.FormattingEnabled = true;
            this.comBox_FilterItems.Location = new System.Drawing.Point(131, 50);
            this.comBox_FilterItems.Name = "comBox_FilterItems";
            this.comBox_FilterItems.Size = new System.Drawing.Size(201, 24);
            this.comBox_FilterItems.TabIndex = 237;
            this.comBox_FilterItems.SelectedIndexChanged += new System.EventHandler(this.comBox_FilterItems_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 33);
            this.label2.TabIndex = 236;
            this.label2.Text = "Filter By:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // uconShowPersonInfo1
            // 
            this.uconShowPersonInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uconShowPersonInfo1.Location = new System.Drawing.Point(0, 94);
            this.uconShowPersonInfo1.MinimumSize = new System.Drawing.Size(865, 316);
            this.uconShowPersonInfo1.Name = "uconShowPersonInfo1";
            this.uconShowPersonInfo1.Size = new System.Drawing.Size(865, 316);
            this.uconShowPersonInfo1.TabIndex = 0;
            // 
            // uconPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uconShowPersonInfo1);
            this.Name = "uconPersonCardWithFilter";
            this.Size = new System.Drawing.Size(864, 410);
            this.Load += new System.EventHandler(this.uconPersonCardWithFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private uconShowPersonInfo uconShowPersonInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_SearchValue;
        private System.Windows.Forms.Button btn_GetPersonBy;
        private System.Windows.Forms.ComboBox comBox_FilterItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_AddNewPerson;
    }
}
