﻿namespace DW.UI
{
    partial class AuthForm
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
            this.Okbutton = new System.Windows.Forms.Button();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.auth = new System.Windows.Forms.Label();
            this.RegistrationLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Okbutton
            // 
            this.Okbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Okbutton.Location = new System.Drawing.Point(114, 136);
            this.Okbutton.Name = "Okbutton";
            this.Okbutton.Size = new System.Drawing.Size(111, 21);
            this.Okbutton.TabIndex = 0;
            this.Okbutton.Text = "Ок";
            this.Okbutton.UseVisualStyleBackColor = true;
            this.Okbutton.Click += new System.EventHandler(this.Okbutton_Click);
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(111, 65);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(114, 20);
            this.LoginBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(111, 92);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(114, 20);
            this.PasswordBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // auth
            // 
            this.auth.AutoSize = true;
            this.auth.Location = new System.Drawing.Point(131, 28);
            this.auth.Name = "auth";
            this.auth.Size = new System.Drawing.Size(73, 13);
            this.auth.TabIndex = 6;
            this.auth.Text = "Авторизация";
            // 
            // RegistrationLink
            // 
            this.RegistrationLink.AutoSize = true;
            this.RegistrationLink.Location = new System.Drawing.Point(112, 115);
            this.RegistrationLink.Name = "RegistrationLink";
            this.RegistrationLink.Size = new System.Drawing.Size(113, 13);
            this.RegistrationLink.TabIndex = 7;
            this.RegistrationLink.TabStop = true;
            this.RegistrationLink.Text = "Зарегистрироваться";
            this.RegistrationLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegistrationLink_LinkClicked);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 166);
            this.Controls.Add(this.RegistrationLink);
            this.Controls.Add(this.auth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.Okbutton);
            this.Name = "AuthForm";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Okbutton;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label auth;
        private System.Windows.Forms.LinkLabel RegistrationLink;
    }
}