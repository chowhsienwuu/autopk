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
            this.SuspendLayout();
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(237, 25);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(479, 21);
            this.urlText.TabIndex = 1;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(738, 25);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // browerpanel
            // 
            this.browerpanel.Location = new System.Drawing.Point(256, 91);
            this.browerpanel.Name = "browerpanel";
            this.browerpanel.Size = new System.Drawing.Size(710, 535);
            this.browerpanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 630);
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
    }
}