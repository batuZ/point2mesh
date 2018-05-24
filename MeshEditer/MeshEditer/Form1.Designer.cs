namespace MeshEditer
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.but_txt = new System.Windows.Forms.Button();
            this.but_dom = new System.Windows.Forms.Button();
            this.but_dem = new System.Windows.Forms.Button();
            this.open_txt = new System.Windows.Forms.OpenFileDialog();
            this.open_dem = new System.Windows.Forms.OpenFileDialog();
            this.open_dom = new System.Windows.Forms.OpenFileDialog();
            this.but_run = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // but_txt
            // 
            this.but_txt.Location = new System.Drawing.Point(12, 68);
            this.but_txt.Name = "but_txt";
            this.but_txt.Size = new System.Drawing.Size(314, 23);
            this.but_txt.TabIndex = 0;
            this.but_txt.Text = "Open txtFromMAX";
            this.but_txt.UseVisualStyleBackColor = true;
            this.but_txt.Click += new System.EventHandler(this.but_txt_Click);
            // 
            // but_dom
            // 
            this.but_dom.Location = new System.Drawing.Point(12, 10);
            this.but_dom.Name = "but_dom";
            this.but_dom.Size = new System.Drawing.Size(314, 23);
            this.but_dom.TabIndex = 1;
            this.but_dom.Text = "Open DOM";
            this.but_dom.UseVisualStyleBackColor = true;
            this.but_dom.Click += new System.EventHandler(this.but_dom_Click);
            // 
            // but_dem
            // 
            this.but_dem.Location = new System.Drawing.Point(12, 39);
            this.but_dem.Name = "but_dem";
            this.but_dem.Size = new System.Drawing.Size(314, 23);
            this.but_dem.TabIndex = 2;
            this.but_dem.Text = "Open DEM";
            this.but_dem.UseVisualStyleBackColor = true;
            this.but_dem.Click += new System.EventHandler(this.but_dem_Click);
            // 
            // open_txt
            // 
            this.open_txt.Filter = "文本文档|*.txt";
            this.open_txt.FileOk += new System.ComponentModel.CancelEventHandler(this.open_txt_FileOk);
            // 
            // open_dem
            // 
            this.open_dem.Filter = "img|*.img";
            this.open_dem.FileOk += new System.ComponentModel.CancelEventHandler(this.open_dem_FileOk);
            // 
            // open_dom
            // 
            this.open_dom.Filter = "img|*.img";
            this.open_dom.FileOk += new System.ComponentModel.CancelEventHandler(this.open_dom_FileOk);
            // 
            // but_run
            // 
            this.but_run.Enabled = false;
            this.but_run.Location = new System.Drawing.Point(146, 97);
            this.but_run.Name = "but_run";
            this.but_run.Size = new System.Drawing.Size(180, 23);
            this.but_run.TabIndex = 3;
            this.but_run.Text = "get!";
            this.but_run.UseVisualStyleBackColor = true;
            this.but_run.Click += new System.EventHandler(this.but_run_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "3";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "网格间距：        米";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 132);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.but_run);
            this.Controls.Add(this.but_dem);
            this.Controls.Add(this.but_dom);
            this.Controls.Add(this.but_txt);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "MeshEditer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_txt;
        private System.Windows.Forms.Button but_dom;
        private System.Windows.Forms.Button but_dem;
        private System.Windows.Forms.OpenFileDialog open_txt;
        private System.Windows.Forms.OpenFileDialog open_dem;
        private System.Windows.Forms.OpenFileDialog open_dom;
        private System.Windows.Forms.Button but_run;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

