namespace Autopk.Ui
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
            this.button1 = new System.Windows.Forms.Button();
            this.clearbutton = new System.Windows.Forms.Button();
            this.tackorder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(310, 10);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(386, 21);
            this.urlText.TabIndex = 1;
            this.urlText.Text = "http://n668.cc282.com/";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(702, 12);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // jspinput
            // 
            this.jspinput.Location = new System.Drawing.Point(1065, 600);
            this.jspinput.Name = "jspinput";
            this.jspinput.Size = new System.Drawing.Size(75, 23);
            this.jspinput.TabIndex = 11;
            this.jspinput.Text = "jsprun";
            this.jspinput.UseVisualStyleBackColor = true;
            this.jspinput.Click += new System.EventHandler(this.jspinput_Click);
            // 
            // jsptext
            // 
            this.jsptext.Location = new System.Drawing.Point(782, 502);
            this.jsptext.Multiline = true;
            this.jsptext.Name = "jsptext";
            this.jsptext.Size = new System.Drawing.Size(279, 132);
            this.jsptext.TabIndex = 12;
            // 
            // browerpanel
            // 
            this.browerpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browerpanel.Location = new System.Drawing.Point(302, 42);
            this.browerpanel.Name = "browerpanel";
            this.browerpanel.Size = new System.Drawing.Size(812, 440);
            this.browerpanel.TabIndex = 15;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(979, 5);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(80, 30);
            this.login.TabIndex = 16;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // imagebutton
            // 
            this.imagebutton.Location = new System.Drawing.Point(810, 5);
            this.imagebutton.Name = "imagebutton";
            this.imagebutton.Size = new System.Drawing.Size(75, 30);
            this.imagebutton.TabIndex = 13;
            this.imagebutton.UseVisualStyleBackColor = true;
            // 
            // checksum
            // 
            this.checksum.Location = new System.Drawing.Point(891, 10);
            this.checksum.Name = "checksum";
            this.checksum.Size = new System.Drawing.Size(75, 21);
            this.checksum.TabIndex = 17;
            // 
            // framecheckboxlist
            // 
            this.framecheckboxlist.FormattingEnabled = true;
            this.framecheckboxlist.Location = new System.Drawing.Point(310, 502);
            this.framecheckboxlist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.framecheckboxlist.Name = "framecheckboxlist";
            this.framecheckboxlist.Size = new System.Drawing.Size(458, 132);
            this.framecheckboxlist.TabIndex = 18;
            // 
            // debugsaveCheckbox
            // 
            this.debugsaveCheckbox.AutoSize = true;
            this.debugsaveCheckbox.Location = new System.Drawing.Point(9, 20);
            this.debugsaveCheckbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.debugsaveCheckbox.Name = "debugsaveCheckbox";
            this.debugsaveCheckbox.Size = new System.Drawing.Size(102, 16);
            this.debugsaveCheckbox.TabIndex = 19;
            this.debugsaveCheckbox.Text = "debugsavepage";
            this.debugsaveCheckbox.UseVisualStyleBackColor = true;
            this.debugsaveCheckbox.CheckedChanged += new System.EventHandler(this.debugsaveCheckbox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 589);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "test_order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clearbutton
            // 
            this.clearbutton.Location = new System.Drawing.Point(94, 589);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(75, 23);
            this.clearbutton.TabIndex = 21;
            this.clearbutton.Text = "清除";
            this.clearbutton.UseVisualStyleBackColor = true;
            this.clearbutton.Click += new System.EventHandler(this.clearbutton_Click);
            // 
            // tackorder
            // 
            this.tackorder.Location = new System.Drawing.Point(174, 589);
            this.tackorder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tackorder.Name = "tackorder";
            this.tackorder.Size = new System.Drawing.Size(68, 23);
            this.tackorder.TabIndex = 22;
            this.tackorder.Text = "下注";
            this.tackorder.UseVisualStyleBackColor = true;
            this.tackorder.Click += new System.EventHandler(this.tackorder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 643);
            this.Controls.Add(this.tackorder);
            this.Controls.Add(this.clearbutton);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button clearbutton;
        private System.Windows.Forms.Button tackorder;
        private autopk.Ui.Memberinfo memberinfo;
    }
}