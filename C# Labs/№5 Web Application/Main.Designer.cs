
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
            this.LogOut = new System.Windows.Forms.Button();
            this.Domains = new System.Windows.Forms.TabPage();
            this.Domain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Display2 = new System.Windows.Forms.RichTextBox();
            this.UserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GetById = new System.Windows.Forms.Button();
            this.URLTab = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ResolveButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ShortenButton = new System.Windows.Forms.Button();
            this.Tabs.SuspendLayout();
            this.Auth.SuspendLayout();
            this.Domains.SuspendLayout();
            this.URLTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // AuthButton
            // 
            this.AuthButton.Location = new System.Drawing.Point(6, 6);
            this.AuthButton.Name = "AuthButton";
            this.AuthButton.Size = new System.Drawing.Size(107, 37);
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
            this.MainScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainScreen.Location = new System.Drawing.Point(6, 46);
            this.MainScreen.Name = "MainScreen";
            this.MainScreen.Size = new System.Drawing.Size(690, 308);
            this.MainScreen.TabIndex = 1;
            this.MainScreen.Text = "";
            // 
            // TokenStatus
            // 
            this.TokenStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenStatus.AutoSize = true;
            this.TokenStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TokenStatus.Location = new System.Drawing.Point(402, 12);
            this.TokenStatus.Name = "TokenStatus";
            this.TokenStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TokenStatus.Size = new System.Drawing.Size(181, 31);
            this.TokenStatus.TabIndex = 2;
            this.TokenStatus.Text = "Not logged in.";
            this.TokenStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.Auth);
            this.Tabs.Controls.Add(this.Domains);
            this.Tabs.Controls.Add(this.URLTab);
            this.Tabs.Location = new System.Drawing.Point(12, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(710, 387);
            this.Tabs.TabIndex = 3;
            this.Tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.ChangedTab);
            // 
            // Auth
            // 
            this.Auth.Controls.Add(this.LogOut);
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
            // LogOut
            // 
            this.LogOut.Enabled = false;
            this.LogOut.Location = new System.Drawing.Point(589, 6);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(107, 37);
            this.LogOut.TabIndex = 3;
            this.LogOut.Text = "Logout";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogoutClick);
            // 
            // Domains
            // 
            this.Domains.Controls.Add(this.Domain);
            this.Domains.Controls.Add(this.label2);
            this.Domains.Controls.Add(this.button2);
            this.Domains.Controls.Add(this.Display2);
            this.Domains.Controls.Add(this.UserId);
            this.Domains.Controls.Add(this.label1);
            this.Domains.Controls.Add(this.GetById);
            this.Domains.Location = new System.Drawing.Point(4, 22);
            this.Domains.Name = "Domains";
            this.Domains.Padding = new System.Windows.Forms.Padding(3);
            this.Domains.Size = new System.Drawing.Size(702, 361);
            this.Domains.TabIndex = 1;
            this.Domains.Text = "Domain resolver";
            this.Domains.UseVisualStyleBackColor = true;
            // 
            // Domain
            // 
            this.Domain.Location = new System.Drawing.Point(9, 79);
            this.Domain.Name = "Domain";
            this.Domain.Size = new System.Drawing.Size(150, 20);
            this.Domain.TabIndex = 6;
            this.Domain.Text = "durov";
            this.Domain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Get user from their domain:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Get";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.GetUserByDomainButtonClick);
            // 
            // Display2
            // 
            this.Display2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Display2.Location = new System.Drawing.Point(205, 6);
            this.Display2.Name = "Display2";
            this.Display2.Size = new System.Drawing.Size(491, 349);
            this.Display2.TabIndex = 3;
            this.Display2.Text = "";
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(9, 25);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(150, 20);
            this.UserId.TabIndex = 2;
            this.UserId.Text = "id1";
            this.UserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Get user from their id:";
            // 
            // GetById
            // 
            this.GetById.Location = new System.Drawing.Point(165, 25);
            this.GetById.Name = "GetById";
            this.GetById.Size = new System.Drawing.Size(34, 23);
            this.GetById.TabIndex = 0;
            this.GetById.Text = "Get";
            this.GetById.UseVisualStyleBackColor = true;
            this.GetById.Click += new System.EventHandler(this.GetUserByIdButtonClick);
            // 
            // URLTab
            // 
            this.URLTab.Controls.Add(this.textBox1);
            this.URLTab.Controls.Add(this.label3);
            this.URLTab.Controls.Add(this.ResolveButton);
            this.URLTab.Controls.Add(this.richTextBox1);
            this.URLTab.Controls.Add(this.textBox2);
            this.URLTab.Controls.Add(this.label4);
            this.URLTab.Controls.Add(this.ShortenButton);
            this.URLTab.Location = new System.Drawing.Point(4, 22);
            this.URLTab.Name = "URLTab";
            this.URLTab.Padding = new System.Windows.Forms.Padding(3);
            this.URLTab.Size = new System.Drawing.Size(702, 361);
            this.URLTab.TabIndex = 2;
            this.URLTab.Text = "Url Shortener";
            this.URLTab.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "https://vk.cc/2csqpF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Get original URL from shorten URL:";
            // 
            // ResolveButton
            // 
            this.ResolveButton.Location = new System.Drawing.Point(186, 71);
            this.ResolveButton.Name = "ResolveButton";
            this.ResolveButton.Size = new System.Drawing.Size(56, 23);
            this.ResolveButton.TabIndex = 11;
            this.ResolveButton.Text = "Resolve";
            this.ResolveButton.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 108);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(687, 247);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(401, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "https://google.com/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Original URL to shorten:";
            // 
            // ShortenButton
            // 
            this.ShortenButton.Location = new System.Drawing.Point(416, 22);
            this.ShortenButton.Name = "ShortenButton";
            this.ShortenButton.Size = new System.Drawing.Size(59, 23);
            this.ShortenButton.TabIndex = 7;
            this.ShortenButton.Text = "Shorten!";
            this.ShortenButton.UseVisualStyleBackColor = true;
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
            this.URLTab.ResumeLayout(false);
            this.URLTab.PerformLayout();
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
        private System.Windows.Forms.Button GetById;
        private System.Windows.Forms.RichTextBox Display2;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.TextBox Domain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.TabPage URLTab;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ResolveButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ShortenButton;
    }
}

