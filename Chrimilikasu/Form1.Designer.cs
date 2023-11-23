namespace Chrimilikasu
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtStartNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtReadTextNo = new System.Windows.Forms.TextBox();
            this.CheckResume = new System.Windows.Forms.CheckBox();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtStartNo
            // 
            this.TxtStartNo.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.TxtStartNo.Location = new System.Drawing.Point(161, 48);
            this.TxtStartNo.Name = "TxtStartNo";
            this.TxtStartNo.Size = new System.Drawing.Size(70, 22);
            this.TxtStartNo.TabIndex = 0;
            this.TxtStartNo.TextChanged += new System.EventHandler(this.TxtStartNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label1.Location = new System.Drawing.Point(52, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "開始ページ番号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label2.Location = new System.Drawing.Point(246, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "終了ページ数";
            // 
            // TxtReadTextNo
            // 
            this.TxtReadTextNo.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.TxtReadTextNo.Location = new System.Drawing.Point(340, 48);
            this.TxtReadTextNo.Name = "TxtReadTextNo";
            this.TxtReadTextNo.Size = new System.Drawing.Size(70, 22);
            this.TxtReadTextNo.TabIndex = 3;
            this.TxtReadTextNo.TextChanged += new System.EventHandler(this.TxtReadTextNo_TextChanged);
            // 
            // CheckResume
            // 
            this.CheckResume.AutoSize = true;
            this.CheckResume.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.CheckResume.Location = new System.Drawing.Point(24, 12);
            this.CheckResume.Name = "CheckResume";
            this.CheckResume.Size = new System.Drawing.Size(156, 19);
            this.CheckResume.TabIndex = 6;
            this.CheckResume.Text = "前回のページから再開";
            this.CheckResume.UseVisualStyleBackColor = true;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Enabled = false;
            this.BtnSubmit.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.BtnSubmit.Location = new System.Drawing.Point(176, 84);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(119, 39);
            this.BtnSubmit.TabIndex = 5;
            this.BtnSubmit.Text = "実行";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 19);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 145);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.CheckResume);
            this.Controls.Add(this.TxtReadTextNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtStartNo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtStartNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtReadTextNo;
        private System.Windows.Forms.CheckBox CheckResume;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}

