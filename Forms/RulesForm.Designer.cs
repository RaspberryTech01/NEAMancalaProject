namespace Mancala_NEA_Computer_Science_Project
{
    partial class RulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            this.rulesRTB = new System.Windows.Forms.RichTextBox();
            this.rulesPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rulesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // rulesRTB
            // 
            this.rulesRTB.BackColor = System.Drawing.Color.MistyRose;
            this.rulesRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rulesRTB.Location = new System.Drawing.Point(12, 12);
            this.rulesRTB.Name = "rulesRTB";
            this.rulesRTB.ReadOnly = true;
            this.rulesRTB.Size = new System.Drawing.Size(450, 425);
            this.rulesRTB.TabIndex = 0;
            this.rulesRTB.Text = resources.GetString("rulesRTB.Text");
            // 
            // rulesPictureBox
            // 
            this.rulesPictureBox.Image = global::Mancala_NEA_Computer_Science_Project.Properties.Resources.rulesGameForm;
            this.rulesPictureBox.Location = new System.Drawing.Point(531, 12);
            this.rulesPictureBox.Name = "rulesPictureBox";
            this.rulesPictureBox.Size = new System.Drawing.Size(700, 418);
            this.rulesPictureBox.TabIndex = 1;
            this.rulesPictureBox.TabStop = false;
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1316, 449);
            this.Controls.Add(this.rulesPictureBox);
            this.Controls.Add(this.rulesRTB);
            this.MaximumSize = new System.Drawing.Size(1332, 488);
            this.MinimumSize = new System.Drawing.Size(1332, 488);
            this.Name = "RulesForm";
            this.Text = "RulesForm";
            ((System.ComponentModel.ISupportInitialize)(this.rulesPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rulesRTB;
        private System.Windows.Forms.PictureBox rulesPictureBox;
    }
}