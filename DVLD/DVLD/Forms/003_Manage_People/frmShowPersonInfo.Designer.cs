namespace DVLD_System_Solution.Forms._003_Manage_People
{
    partial class frmShowPersonInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPersonInfo));
            this.lab_ModeStatue = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.uconShowPersonInfo1 = new DVLD_System_Solution.Forms._003_Manage_People.Controls.uconShowPersonInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_ModeStatue
            // 
            this.lab_ModeStatue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_ModeStatue.Font = new System.Drawing.Font("Sitka Small", 33F, System.Drawing.FontStyle.Bold);
            this.lab_ModeStatue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lab_ModeStatue.Location = new System.Drawing.Point(140, 57);
            this.lab_ModeStatue.Name = "lab_ModeStatue";
            this.lab_ModeStatue.Size = new System.Drawing.Size(632, 65);
            this.lab_ModeStatue.TabIndex = 219;
            this.lab_ModeStatue.Text = "PERSON INFORMATIONS";
            this.lab_ModeStatue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Close.Image = global::DVLD_System_Solution.Properties.Resources.Close1_28;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Close.Location = new System.Drawing.Point(12, 492);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(135, 39);
            this.btn_Close.TabIndex = 217;
            this.btn_Close.Text = "    Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::DVLD_System_Solution.Properties.Resources.DVLD_Logo2;
            this.pictureBox11.Location = new System.Drawing.Point(778, 12);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(116, 110);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 218;
            this.pictureBox11.TabStop = false;
            // 
            // uconShowPersonInfo1
            // 
            this.uconShowPersonInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uconShowPersonInfo1.Location = new System.Drawing.Point(13, 147);
            this.uconShowPersonInfo1.MinimumSize = new System.Drawing.Size(865, 316);
            this.uconShowPersonInfo1.Name = "uconShowPersonInfo1";
            this.uconShowPersonInfo1.Size = new System.Drawing.Size(881, 316);
            this.uconShowPersonInfo1.TabIndex = 220;
            // 
            // frmShowPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(906, 543);
            this.Controls.Add(this.uconShowPersonInfo1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lab_ModeStatue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(906, 582);
            this.Name = "frmShowPersonInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Person Info";
            this.Load += new System.EventHandler(this.frmShowPersonInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label lab_ModeStatue;
        private Controls.uconShowPersonInfo uconShowPersonInfo1;
    }
}