﻿namespace Autopk.Ui
{
    partial class MainForm
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
            this.urlText = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.jspinput = new System.Windows.Forms.Button();
            this.jsptext = new System.Windows.Forms.TextBox();
            this.browerpanel = new System.Windows.Forms.Panel();
            this.login = new System.Windows.Forms.Button();
            this.imagebutton = new System.Windows.Forms.Button();
            this.checksum = new System.Windows.Forms.TextBox();
            this.framecheckboxlist = new System.Windows.Forms.CheckedListBox();
            this.debugsaveCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(414, 13);
            this.urlText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(514, 25);
            this.urlText.TabIndex = 1;
            this.urlText.Text = "http://n668.cc282.com/";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(936, 15);
            this.goButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(100, 29);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // jspinput
            // 
            this.jspinput.Location = new System.Drawing.Point(1420, 750);
            this.jspinput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jspinput.Name = "jspinput";
            this.jspinput.Size = new System.Drawing.Size(100, 29);
            this.jspinput.TabIndex = 11;
            this.jspinput.Text = "jsprun";
            this.jspinput.UseVisualStyleBackColor = true;
            this.jspinput.Click += new System.EventHandler(this.jspinput_Click);
            // 
            // jsptext
            // 
            this.jsptext.Location = new System.Drawing.Point(1043, 627);
            this.jsptext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jsptext.Multiline = true;
            this.jsptext.Name = "jsptext";
            this.jsptext.Size = new System.Drawing.Size(371, 164);
            this.jsptext.TabIndex = 12;
            // 
            // browerpanel
            // 
            this.browerpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browerpanel.Location = new System.Drawing.Point(403, 52);
            this.browerpanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.browerpanel.Name = "browerpanel";
            this.browerpanel.Size = new System.Drawing.Size(1083, 550);
            this.browerpanel.TabIndex = 15;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(1305, 6);
            this.login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(107, 38);
            this.login.TabIndex = 16;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // imagebutton
            // 
            this.imagebutton.Location = new System.Drawing.Point(1080, 6);
            this.imagebutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imagebutton.Name = "imagebutton";
            this.imagebutton.Size = new System.Drawing.Size(100, 38);
            this.imagebutton.TabIndex = 13;
            this.imagebutton.UseVisualStyleBackColor = true;
            // 
            // checksum
            // 
            this.checksum.Location = new System.Drawing.Point(1188, 13);
            this.checksum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checksum.Name = "checksum";
            this.checksum.Size = new System.Drawing.Size(99, 25);
            this.checksum.TabIndex = 17;
            // 
            // framecheckboxlist
            // 
            this.framecheckboxlist.FormattingEnabled = true;
            this.framecheckboxlist.Location = new System.Drawing.Point(414, 627);
            this.framecheckboxlist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.framecheckboxlist.Name = "framecheckboxlist";
            this.framecheckboxlist.Size = new System.Drawing.Size(609, 164);
            this.framecheckboxlist.TabIndex = 18;
            // 
            // debugsaveCheckbox
            // 
            this.debugsaveCheckbox.AutoSize = true;
            this.debugsaveCheckbox.Location = new System.Drawing.Point(12, 25);
            this.debugsaveCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.debugsaveCheckbox.Name = "debugsaveCheckbox";
            this.debugsaveCheckbox.Size = new System.Drawing.Size(133, 19);
            this.debugsaveCheckbox.TabIndex = 19;
            this.debugsaveCheckbox.Text = "debugsavepage";
            this.debugsaveCheckbox.UseVisualStyleBackColor = true;
            this.debugsaveCheckbox.CheckedChanged += new System.EventHandler(this.debugsaveCheckbox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 804);
            this.Controls.Add(this.debugsaveCheckbox);
            this.Controls.Add(this.framecheckboxlist);
            this.Controls.Add(this.checksum);
            this.Controls.Add(this.login);
            this.Controls.Add(this.browerpanel);
            this.Controls.Add(this.imagebutton);
            this.Controls.Add(this.jsptext);
            this.Controls.Add(this.jspinput);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.urlText);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button jspinput;
        private System.Windows.Forms.TextBox jsptext;
        private System.Windows.Forms.Panel browerpanel;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button imagebutton;
        private System.Windows.Forms.TextBox checksum;
        private System.Windows.Forms.CheckedListBox framecheckboxlist;
        private System.Windows.Forms.CheckBox debugsaveCheckbox;
    }
}