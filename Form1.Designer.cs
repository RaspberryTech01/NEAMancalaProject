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
            this.usernameInputField.BackColor = System.Drawing.Color.Snow;
            this.usernameInputField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameInputField.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameInputField.Location = new System.Drawing.Point(102, 49);
            this.usernameInputField.Name = "usernameInputField";
            this.usernameInputField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usernameInputField.Size = new System.Drawing.Size(275, 50);
            this.usernameInputField.TabIndex = 0;
            this.usernameInputField.Text = "Username";
            // 
            // passwordInputField
            // 
            this.passwordInputField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordInputField.BackColor = System.Drawing.Color.Snow;
            this.passwordInputField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordInputField.DetectUrls = false;
            this.passwordInputField.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordInputField.Location = new System.Drawing.Point(102, 105);
            this.passwordInputField.Name = "passwordInputField";
            this.passwordInputField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passwordInputField.Size = new System.Drawing.Size(275, 50);
            this.passwordInputField.TabIndex = 1;
            this.passwordInputField.Text = "Password";
            // 
            // loginBtn
            // 
            this.loginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginBtn.Location = new System.Drawing.Point(170, 161);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(140, 30);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registerBtn.Location = new System.Drawing.Point(170, 197);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(140, 30);
            this.registerBtn.TabIndex = 3;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // responseField
            // 
            this.responseField.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.responseField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.responseField.DetectUrls = false;
            this.responseField.Enabled = false;
            this.responseField.Location = new System.Drawing.Point(102, 233);
            this.responseField.Name = "responseField";
            this.responseField.Size = new System.Drawing.Size(275, 186);
            this.responseField.TabIndex = 4;
            this.responseField.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(479, 431);
            this.Controls.Add(this.responseField);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordInputField);
            this.Controls.Add(this.usernameInputField);
            this.MaximumSize = new System.Drawing.Size(495, 470);
            this.MinimumSize = new System.Drawing.Size(495, 470);
            this.Name = "Form1";
            this.Text = "Form1";
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

