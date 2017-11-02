namespace Autopk.Ui
{
    partial class Memberinfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.creditquota = new System.Windows.Forms.Label();
            this.memberno = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.allowcrediaquota = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员帐号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "帐户余额";
            // 
            // creditquota
            // 
            this.creditquota.AutoSize = true;
            this.creditquota.Location = new System.Drawing.Point(97, 47);
            this.creditquota.Name = "creditquota";
            this.creditquota.Size = new System.Drawing.Size(55, 15);
            this.creditquota.TabIndex = 2;
            this.creditquota.Text = "--------";
            // 
            // memberno
            // 
            this.memberno.AutoSize = true;
            this.memberno.Location = new System.Drawing.Point(97, 19);
            this.memberno.Name = "memberno";
            this.memberno.Size = new System.Drawing.Size(47, 15);
            this.memberno.TabIndex = 3;
            this.memberno.Text = "--------";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "可用金额";
            // 
            // allowcrediaquota
            // 
            this.allowcrediaquota.AutoSize = true;
            this.allowcrediaquota.Location = new System.Drawing.Point(97, 68);
            this.allowcrediaquota.Name = "allowcrediaquota";
            this.allowcrediaquota.Size = new System.Drawing.Size(31, 15);
            this.allowcrediaquota.TabIndex = 5;
            this.allowcrediaquota.Text = "--------";
            // 
            // Memberinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.allowcrediaquota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.memberno);
            this.Controls.Add(this.creditquota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Memberinfo";
            this.Size = new System.Drawing.Size(182, 104);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label creditquota;
        private System.Windows.Forms.Label memberno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label allowcrediaquota;
    }
}
