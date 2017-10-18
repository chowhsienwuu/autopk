namespace autopk.Ui
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
            this.browerpanel = new System.Windows.Forms.Panel();
            this.clickem = new System.Windows.Forms.TextBox();
            this.ClickButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputID = new System.Windows.Forms.TextBox();
            this.inputval = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.Button();
            this.jspinput = new System.Windows.Forms.Button();
            this.jsptext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(374, 25);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(479, 21);
            this.urlText.TabIndex = 1;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(899, 23);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // browerpanel
            // 
            this.browerpanel.Location = new System.Drawing.Point(303, 83);
            this.browerpanel.Name = "browerpanel";
            this.browerpanel.Size = new System.Drawing.Size(710, 535);
            this.browerpanel.TabIndex = 3;
            // 
            // clickem
            // 
            this.clickem.Location = new System.Drawing.Point(86, 52);
            this.clickem.Name = "clickem";
            this.clickem.Size = new System.Drawing.Size(100, 21);
            this.clickem.TabIndex = 4;
            // 
            // ClickButton
            // 
            this.ClickButton.Location = new System.Drawing.Point(192, 52);
            this.ClickButton.Name = "ClickButton";
            this.ClickButton.Size = new System.Drawing.Size(75, 23);
            this.ClickButton.TabIndex = 5;
            this.ClickButton.Text = "click";
            this.ClickButton.UseVisualStyleBackColor = true;
            this.ClickButton.Click += new System.EventHandler(this.ClickButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "click id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "input";
            // 
            // inputID
            // 
            this.inputID.Location = new System.Drawing.Point(86, 103);
            this.inputID.Name = "inputID";
            this.inputID.Size = new System.Drawing.Size(100, 21);
            this.inputID.TabIndex = 8;
            // 
            // inputval
            // 
            this.inputval.Location = new System.Drawing.Point(86, 148);
            this.inputval.Name = "inputval";
            this.inputval.Size = new System.Drawing.Size(100, 21);
            this.inputval.TabIndex = 9;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(204, 125);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(75, 23);
            this.input.TabIndex = 10;
            this.input.Text = "input";
            this.input.UseVisualStyleBackColor = true;
            this.input.Click += new System.EventHandler(this.input_Click);
            // 
            // jspinput
            // 
            this.jspinput.Location = new System.Drawing.Point(68, 446);
            this.jspinput.Name = "jspinput";
            this.jspinput.Size = new System.Drawing.Size(75, 23);
            this.jspinput.TabIndex = 11;
            this.jspinput.Text = "jsprun";
            this.jspinput.UseVisualStyleBackColor = true;
            this.jspinput.Click += new System.EventHandler(this.jspinput_Click);
            // 
            // jsptext
            // 
            this.jsptext.Location = new System.Drawing.Point(9, 199);
            this.jsptext.Multiline = true;
            this.jsptext.Name = "jsptext";
            this.jsptext.Size = new System.Drawing.Size(279, 241);
            this.jsptext.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 630);
            this.Controls.Add(this.jsptext);
            this.Controls.Add(this.jspinput);
            this.Controls.Add(this.input);
            this.Controls.Add(this.inputval);
            this.Controls.Add(this.inputID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClickButton);
            this.Controls.Add(this.clickem);
            this.Controls.Add(this.browerpanel);
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
        private System.Windows.Forms.Panel browerpanel;
        private System.Windows.Forms.TextBox clickem;
        private System.Windows.Forms.Button ClickButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputID;
        private System.Windows.Forms.TextBox inputval;
        private System.Windows.Forms.Button input;
        private System.Windows.Forms.Button jspinput;
        private System.Windows.Forms.TextBox jsptext;
    }
}