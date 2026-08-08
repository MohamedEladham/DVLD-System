using DVLD_System_Solution.Forms._003_Manage_People.Controls;

namespace DVLD_System_Solution.Forms._004_Manage_Users.Controls
{
    partial class uconPersonCardWithUserFilter
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
            frmCreateLoginInfo.CreatedLoginInfo -= _ResetLabelIsUser;
            uconShowPersonInfo.SendPersonID -= _GetPersonIDAndCheckIsUser;

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
            this.uconPersonCardWithFilter1 = new DVLD_System_Solution.Forms._003_Manage_People.Controls.uconPersonCardWithFilter();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_IsUserToText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uconPersonCardWithFilter1
            // 
            this.uconPersonCardWithFilter1.AutoSize = true;
            this.uconPersonCardWithFilter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uconPersonCardWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.uconPersonCardWithFilter1.Name = "uconPersonCardWithFilter1";
            this.uconPersonCardWithFilter1.Size = new System.Drawing.Size(884, 396);
            this.uconPersonCardWithFilter1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 239;
            this.label2.Text = "Is User: ";
            // 
            // lab_IsUserToText
            // 
            this.lab_IsUserToText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_IsUserToText.AutoSize = true;
            this.lab_IsUserToText.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lab_IsUserToText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lab_IsUserToText.Location = new System.Drawing.Point(91, 413);
            this.lab_IsUserToText.Name = "lab_IsUserToText";
            this.lab_IsUserToText.Size = new System.Drawing.Size(44, 17);
            this.lab_IsUserToText.TabIndex = 241;
            this.lab_IsUserToText.Text = "[???]";
            // 
            // uconPersonCardWithUserFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lab_IsUserToText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uconPersonCardWithFilter1);
            this.Name = "uconPersonCardWithUserFilter";
            this.Size = new System.Drawing.Size(884, 448);
            this.Load += new System.EventHandler(this.uconPersonCardWithUserFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _003_Manage_People.Controls.uconPersonCardWithFilter uconPersonCardWithFilter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_IsUserToText;
    }
}
