namespace Main_Screen.Forms._004_Users.Controls
{
    partial class frmCheckCurrentUserPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckCurrentUserPassword));
            this.txt_CurrentPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_CurrentPasswordResult = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btn_CheckPassword = new System.Windows.Forms.Button();
            this.picB_ShowHidePassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_ShowHidePassword)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_CurrentPassword
            // 
            this.txt_CurrentPassword.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_CurrentPassword.Location = new System.Drawing.Point(169, 246);
            this.txt_CurrentPassword.Name = "txt_CurrentPassword";
            this.txt_CurrentPassword.Size = new System.Drawing.Size(362, 24);
            this.txt_CurrentPassword.TabIndex = 302;
            this.txt_CurrentPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_CurrentPassword.UseSystemPasswordChar = true;
            this.txt_CurrentPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_CurrentPassword_MouseClick);
            this.txt_CurrentPassword.TextChanged += new System.EventHandler(this.txt_CurrentPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Rockwell", 33F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(186, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 112);
            this.label1.TabIndex = 306;
            this.label1.Text = "Enter Current Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lab_CurrentPasswordResult
            // 
            this.lab_CurrentPasswordResult.AutoSize = true;
            this.lab_CurrentPasswordResult.BackColor = System.Drawing.Color.Transparent;
            this.lab_CurrentPasswordResult.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lab_CurrentPasswordResult.Location = new System.Drawing.Point(166, 273);
            this.lab_CurrentPasswordResult.Name = "lab_CurrentPasswordResult";
            this.lab_CurrentPasswordResult.Size = new System.Drawing.Size(33, 19);
            this.lab_CurrentPasswordResult.TabIndex = 308;
            this.lab_CurrentPasswordResult.Text = "???";
            this.lab_CurrentPasswordResult.Visible = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.Visibility_512;
            this.pictureBox11.Location = new System.Drawing.Point(243, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(214, 116);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 307;
            this.pictureBox11.TabStop = false;
            // 
            // btn_CheckPassword
            // 
            this.btn_CheckPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btn_CheckPassword.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_CheckPassword.Image = global::DVLD_System_Solution.Properties.Resources.Check_Password__24;
            this.btn_CheckPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CheckPassword.Location = new System.Drawing.Point(265, 309);
            this.btn_CheckPassword.Name = "btn_CheckPassword";
            this.btn_CheckPassword.Size = new System.Drawing.Size(170, 37);
            this.btn_CheckPassword.TabIndex = 304;
            this.btn_CheckPassword.Text = "  Check Password";
            this.btn_CheckPassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CheckPassword.UseVisualStyleBackColor = false;
            this.btn_CheckPassword.Click += new System.EventHandler(this.btn_CheckPassword_Click);
            // 
            // picB_ShowHidePassword
            // 
            this.picB_ShowHidePassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picB_ShowHidePassword.Image = global::DVLD_System_Solution.Properties.Resources.Hide_Passowrd_32;
            this.picB_ShowHidePassword.Location = new System.Drawing.Point(537, 242);
            this.picB_ShowHidePassword.Name = "picB_ShowHidePassword";
            this.picB_ShowHidePassword.Size = new System.Drawing.Size(32, 32);
            this.picB_ShowHidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picB_ShowHidePassword.TabIndex = 309;
            this.picB_ShowHidePassword.TabStop = false;
            this.picB_ShowHidePassword.Click += new System.EventHandler(this.picB_ShowHidePassword_Click);
            // 
            // frmCheckCurrentUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(752, 358);
            this.Controls.Add(this.picB_ShowHidePassword);
            this.Controls.Add(this.lab_CurrentPasswordResult);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_CheckPassword);
            this.Controls.Add(this.txt_CurrentPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(768, 397);
            this.MinimumSize = new System.Drawing.Size(768, 397);
            this.Name = "frmCheckCurrentUserPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Current Password";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_ShowHidePassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CheckPassword;
        private System.Windows.Forms.TextBox txt_CurrentPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_CurrentPasswordResult;
        private System.Windows.Forms.PictureBox picB_ShowHidePassword;
    }
}