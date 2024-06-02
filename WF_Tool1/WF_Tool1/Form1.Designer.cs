namespace WF_Tool1
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb1 = new System.Windows.Forms.TextBox();
            this.txb2 = new System.Windows.Forms.TextBox();
            this.txb3 = new System.Windows.Forms.TextBox();
            this.t_txb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.zd_btn = new System.Windows.Forms.Button();
            this.tz_btn = new System.Windows.Forms.Button();
            this.bf_btn = new System.Windows.Forms.Button();
            this.hf_btn = new System.Windows.Forms.Button();
            this.t_lab = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(618, 84);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(189, 40);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "选择存档文件夹";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(618, 169);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(189, 40);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "选择备份目录";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "存档文件夹";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "备份目录";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "备份压缩文件名";
            // 
            // txb1
            // 
            this.txb1.Location = new System.Drawing.Point(198, 87);
            this.txb1.Name = "txb1";
            this.txb1.ReadOnly = true;
            this.txb1.Size = new System.Drawing.Size(402, 31);
            this.txb1.TabIndex = 5;
            // 
            // txb2
            // 
            this.txb2.Location = new System.Drawing.Point(198, 174);
            this.txb2.Name = "txb2";
            this.txb2.ReadOnly = true;
            this.txb2.Size = new System.Drawing.Size(402, 31);
            this.txb2.TabIndex = 6;
            // 
            // txb3
            // 
            this.txb3.Location = new System.Drawing.Point(198, 271);
            this.txb3.Name = "txb3";
            this.txb3.ReadOnly = true;
            this.txb3.Size = new System.Drawing.Size(177, 31);
            this.txb3.TabIndex = 7;
            // 
            // t_txb
            // 
            this.t_txb.Location = new System.Drawing.Point(512, 271);
            this.t_txb.Name = "t_txb";
            this.t_txb.Size = new System.Drawing.Size(88, 31);
            this.t_txb.TabIndex = 8;
            this.t_txb.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "几秒一次";
            // 
            // zd_btn
            // 
            this.zd_btn.Location = new System.Drawing.Point(618, 267);
            this.zd_btn.Name = "zd_btn";
            this.zd_btn.Size = new System.Drawing.Size(116, 40);
            this.zd_btn.TabIndex = 10;
            this.zd_btn.Text = "自动备份";
            this.zd_btn.UseVisualStyleBackColor = true;
            this.zd_btn.Click += new System.EventHandler(this.zd_btn_Click);
            // 
            // tz_btn
            // 
            this.tz_btn.Enabled = false;
            this.tz_btn.Location = new System.Drawing.Point(740, 267);
            this.tz_btn.Name = "tz_btn";
            this.tz_btn.Size = new System.Drawing.Size(67, 40);
            this.tz_btn.TabIndex = 11;
            this.tz_btn.Text = "停止";
            this.tz_btn.UseVisualStyleBackColor = true;
            this.tz_btn.Click += new System.EventHandler(this.tz_btn_Click);
            // 
            // bf_btn
            // 
            this.bf_btn.Location = new System.Drawing.Point(198, 374);
            this.bf_btn.Name = "bf_btn";
            this.bf_btn.Size = new System.Drawing.Size(131, 40);
            this.bf_btn.TabIndex = 12;
            this.bf_btn.Text = "存档备份";
            this.bf_btn.UseVisualStyleBackColor = true;
            this.bf_btn.Click += new System.EventHandler(this.bf_btn_Click);
            // 
            // hf_btn
            // 
            this.hf_btn.Location = new System.Drawing.Point(469, 374);
            this.hf_btn.Name = "hf_btn";
            this.hf_btn.Size = new System.Drawing.Size(131, 40);
            this.hf_btn.TabIndex = 13;
            this.hf_btn.Text = "存档恢复";
            this.hf_btn.UseVisualStyleBackColor = true;
            this.hf_btn.Click += new System.EventHandler(this.hf_btn_Click);
            // 
            // t_lab
            // 
            this.t_lab.AutoSize = true;
            this.t_lab.Location = new System.Drawing.Point(626, 322);
            this.t_lab.Name = "t_lab";
            this.t_lab.Size = new System.Drawing.Size(94, 21);
            this.t_lab.TabIndex = 14;
            this.t_lab.Text = "几秒一次";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 495);
            this.Controls.Add(this.t_lab);
            this.Controls.Add(this.hf_btn);
            this.Controls.Add(this.bf_btn);
            this.Controls.Add(this.tz_btn);
            this.Controls.Add(this.zd_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.t_txb);
            this.Controls.Add(this.txb3);
            this.Controls.Add(this.txb2);
            this.Controls.Add(this.txb1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Name = "Form1";
            this.Text = "存档备份和恢复";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb1;
        private System.Windows.Forms.TextBox txb2;
        private System.Windows.Forms.TextBox txb3;
        private System.Windows.Forms.TextBox t_txb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button zd_btn;
        private System.Windows.Forms.Button tz_btn;
        private System.Windows.Forms.Button bf_btn;
        private System.Windows.Forms.Button hf_btn;
        private System.Windows.Forms.Label t_lab;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

