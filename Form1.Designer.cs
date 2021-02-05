namespace Mancala_NEA_Computer_Science_Project
{
    partial class Form1
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
            this.usernameInputField = new System.Windows.Forms.RichTextBox();
            this.passwordInputField = new System.Windows.Forms.RichTextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.responseField = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // usernameInputField
            // 
            this.usernameInputField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameInputField.BackColor = System.Drawing.Color.LightCyan;
            this.usernameInputField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameInputField.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameInputField.Location = new System.Drawing.Point(183, 226);
            this.usernameInputField.Name = "usernameInputField";
            this.usernameInputField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usernameInputField.Size = new System.Drawing.Size(256, 29);
            this.usernameInputField.TabIndex = 0;
            this.usernameInputField.Text = "Username";
            // 
            // passwordInputField
            // 
            this.passwordInputField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordInputField.BackColor = System.Drawing.Color.LightCyan;
            this.passwordInputField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordInputField.DetectUrls = false;
            this.passwordInputField.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordInputField.Location = new System.Drawing.Point(183, 309);
            this.passwordInputField.Name = "passwordInputField";
            this.passwordInputField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passwordInputField.Size = new System.Drawing.Size(256, 27);
            this.passwordInputField.TabIndex = 1;
            this.passwordInputField.Text = "Password";
            // 
            // loginBtn
            // 
            this.loginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginBtn.BackColor = System.Drawing.Color.Transparent;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginBtn.ForeColor = System.Drawing.Color.Transparent;
            this.loginBtn.Location = new System.Drawing.Point(164, 369);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(275, 29);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registerBtn.BackColor = System.Drawing.Color.Transparent;
            this.registerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.registerBtn.ForeColor = System.Drawing.Color.Transparent;
            this.registerBtn.Location = new System.Drawing.Point(164, 414);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(275, 31);
            this.registerBtn.TabIndex = 3;
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // responseField
            // 
            this.responseField.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.responseField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.responseField.DetectUrls = false;
            this.responseField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.responseField.ForeColor = System.Drawing.Color.Red;
            this.responseField.Location = new System.Drawing.Point(164, 479);
            this.responseField.Name = "responseField";
            this.responseField.Size = new System.Drawing.Size(275, 104);
            this.responseField.TabIndex = 4;
            this.responseField.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = global::Mancala_NEA_Computer_Science_Project.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(584, 690);
            this.Controls.Add(this.responseField);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordInputField);
            this.Controls.Add(this.usernameInputField);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 729);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 729);
            this.Name = "Form1";
            this.Text = "Congkak  Login";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox usernameInputField;
        private System.Windows.Forms.RichTextBox passwordInputField;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.RichTextBox responseField;
    }
}

