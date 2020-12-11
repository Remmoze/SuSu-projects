﻿
namespace WindowsFormsApp1 {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.AuthButton = new System.Windows.Forms.Button();
            this.MainScreen = new System.Windows.Forms.RichTextBox();
            this.TokenStatus = new System.Windows.Forms.Label();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Auth = new System.Windows.Forms.TabPage();
            this.Domains = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.UserId = new System.Windows.Forms.TextBox();
            this.Display2 = new System.Windows.Forms.RichTextBox();
            this.Tabs.SuspendLayout();
            this.Auth.SuspendLayout();
            this.Domains.SuspendLayout();
            this.SuspendLayout();
            // 
            // AuthButton
            // 
            this.AuthButton.Location = new System.Drawing.Point(6, 7);
            this.AuthButton.Name = "AuthButton";
            this.AuthButton.Size = new System.Drawing.Size(75, 23);
            this.AuthButton.TabIndex = 0;
            this.AuthButton.Text = "Auth";
            this.AuthButton.UseVisualStyleBackColor = true;
            this.AuthButton.Click += new System.EventHandler(this.AuthClick);
            // 
            // MainScreen
            // 
            this.MainScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainScreen.Location = new System.Drawing.Point(166, 6);
            this.MainScreen.Name = "MainScreen";
            this.MainScreen.Size = new System.Drawing.Size(530, 348);
            this.MainScreen.TabIndex = 1;
            this.MainScreen.Text = "";
            // 
            // TokenStatus
            // 
            this.TokenStatus.AutoSize = true;
            this.TokenStatus.Location = new System.Drawing.Point(87, 12);
            this.TokenStatus.Name = "TokenStatus";
            this.TokenStatus.Size = new System.Drawing.Size(73, 13);
            this.TokenStatus.TabIndex = 2;
            this.TokenStatus.Text = "Not logged in.";
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Auth);
            this.Tabs.Controls.Add(this.Domains);
            this.Tabs.Location = new System.Drawing.Point(12, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(710, 387);
            this.Tabs.TabIndex = 3;
            // 
            // Auth
            // 
            this.Auth.Controls.Add(this.AuthButton);
            this.Auth.Controls.Add(this.MainScreen);
            this.Auth.Controls.Add(this.TokenStatus);
            this.Auth.Location = new System.Drawing.Point(4, 22);
            this.Auth.Name = "Auth";
            this.Auth.Padding = new System.Windows.Forms.Padding(3);
            this.Auth.Size = new System.Drawing.Size(702, 361);
            this.Auth.TabIndex = 0;
            this.Auth.Text = "Auth";
            this.Auth.UseVisualStyleBackColor = true;
            // 
            // Domains
            // 
            this.Domains.Controls.Add(this.Display2);
            this.Domains.Controls.Add(this.UserId);
            this.Domains.Controls.Add(this.label1);
            this.Domains.Controls.Add(this.button1);
            this.Domains.Location = new System.Drawing.Point(4, 22);
            this.Domains.Name = "Domains";
            this.Domains.Padding = new System.Windows.Forms.Padding(3);
            this.Domains.Size = new System.Drawing.Size(702, 361);
            this.Domains.TabIndex = 1;
            this.Domains.Text = "Domain resolver";
            this.Domains.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Get user\'s domain from their Id:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GetDomainButtonClick);
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(23, 37);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(150, 20);
            this.UserId.TabIndex = 2;
            this.UserId.Text = "id1";
            this.UserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // Display2
            // 
            this.Display2.Location = new System.Drawing.Point(266, 6);
            this.Display2.Name = "Display2";
            this.Display2.Size = new System.Drawing.Size(430, 349);
            this.Display2.TabIndex = 3;
            this.Display2.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.Tabs);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Main";
            this.Text = "VKApi";
            this.Tabs.ResumeLayout(false);
            this.Auth.ResumeLayout(false);
            this.Auth.PerformLayout();
            this.Domains.ResumeLayout(false);
            this.Domains.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AuthButton;
        private System.Windows.Forms.RichTextBox MainScreen;
        private System.Windows.Forms.Label TokenStatus;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Auth;
        private System.Windows.Forms.TabPage Domains;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox Display2;
        private System.Windows.Forms.TextBox UserId;
    }
}

