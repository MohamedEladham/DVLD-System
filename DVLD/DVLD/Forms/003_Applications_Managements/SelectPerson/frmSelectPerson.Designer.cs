using DVLD_System_Solution.Forms._003_Manage_People.Controls;

namespace DVLD_System_Solution.Forms._003_Applications_Managements._002_FirstTimeDrivingLicense_Screens
{
    partial class frmSelectPerson
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
            uconShowPersonInfo.SendPersonID -= _UpdateAddNewApplicationButtonState;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectPerson));
            this.uconPersonCardWithFilter1 = new DVLD_System_Solution.Forms._003_Manage_People.Controls.uconPersonCardWithFilter();
            this.btn_AddNewApplication = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uconPersonCardWithFilter1
            // 
            this.uconPersonCardWithFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uconPersonCardWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.uconPersonCardWithFilter1.Name = "uconPersonCardWithFilter1";
            this.uconPersonCardWithFilter1.Size = new System.Drawing.Size(960, 406);
            this.uconPersonCardWithFilter1.TabIndex = 0;
            // 
            // btn_AddNewApplication
            // 
            this.btn_AddNewApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewApplication.Enabled = false;
            this.btn_AddNewApplication.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.btn_AddNewApplication.ForeColor = System.Drawing.Color.SteelBlue;
            this.btn_AddNewApplication.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddNewApplication.Image")));
            this.btn_AddNewApplication.Location = new System.Drawing.Point(850, 445);
            this.btn_AddNewApplication.Name = "btn_AddNewApplication";
            this.btn_AddNewApplication.Size = new System.Drawing.Size(122, 104);
            this.btn_AddNewApplication.TabIndex = 257;
            this.btn_AddNewApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddNewApplication.UseVisualStyleBackColor = false;
            this.btn_AddNewApplication.Click += new System.EventHandler(this.btn_AddNewApplication_Click);
            // 
            // frmSelectPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btn_AddNewApplication);
            this.Controls.Add(this.uconPersonCardWithFilter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmSelectPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Person";
            this.Load += new System.EventHandler(this.frmSelectPerson_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private _003_Manage_People.Controls.uconPersonCardWithFilter uconPersonCardWithFilter1;
        private System.Windows.Forms.Button btn_AddNewApplication;
    }
}