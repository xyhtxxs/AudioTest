
namespace X.Music
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btPlay = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btPause = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbOpenFolder = new System.Windows.Forms.Label();
            this.lbPlayLocation = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.BtLoop = new System.Windows.Forms.Button();
            this.BtPrev = new System.Windows.Forms.Button();
            this.BtNext = new System.Windows.Forms.Button();
            this.TbVolume = new System.Windows.Forms.TrackBar();
            this.LbVolume = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TbVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // btPlay
            // 
            this.btPlay.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPlay.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.btPlay.Location = new System.Drawing.Point(12, 12);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(45, 23);
            this.btPlay.TabIndex = 0;
            this.btPlay.Text = "播放";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // btPause
            // 
            this.btPause.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPause.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.btPause.Location = new System.Drawing.Point(195, 12);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(39, 23);
            this.btPause.TabIndex = 1;
            this.btPause.Text = "暂停";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.BtPause_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 64);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 328);
            this.listBox1.TabIndex = 2;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // lbOpenFolder
            // 
            this.lbOpenFolder.AutoSize = true;
            this.lbOpenFolder.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbOpenFolder.Font = new System.Drawing.Font("华文楷体", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOpenFolder.ForeColor = System.Drawing.Color.DimGray;
            this.lbOpenFolder.Location = new System.Drawing.Point(12, 48);
            this.lbOpenFolder.Name = "lbOpenFolder";
            this.lbOpenFolder.Size = new System.Drawing.Size(39, 13);
            this.lbOpenFolder.TabIndex = 3;
            this.lbOpenFolder.Text = "☷列表";
            this.lbOpenFolder.DoubleClick += new System.EventHandler(this.lbOpenFolder_DoubleClick);
            // 
            // lbPlayLocation
            // 
            this.lbPlayLocation.AutoSize = true;
            this.lbPlayLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbPlayLocation.Location = new System.Drawing.Point(52, 49);
            this.lbPlayLocation.Name = "lbPlayLocation";
            this.lbPlayLocation.Size = new System.Drawing.Size(0, 12);
            this.lbPlayLocation.TabIndex = 5;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(-1, 392);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(293, 10);
            this.ProgressBar1.TabIndex = 6;
            this.ProgressBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgressBar1_MouseDown);
            this.ProgressBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ProgressBar1_MouseUp);
            // 
            // BtLoop
            // 
            this.BtLoop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtLoop.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.BtLoop.Location = new System.Drawing.Point(240, 12);
            this.BtLoop.Name = "BtLoop";
            this.BtLoop.Size = new System.Drawing.Size(52, 23);
            this.BtLoop.TabIndex = 7;
            this.BtLoop.Text = "全循环";
            this.BtLoop.UseVisualStyleBackColor = true;
            this.BtLoop.Click += new System.EventHandler(this.BtLoop_Click_1);
            // 
            // BtPrev
            // 
            this.BtPrev.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtPrev.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.BtPrev.Location = new System.Drawing.Point(63, 13);
            this.BtPrev.Name = "BtPrev";
            this.BtPrev.Size = new System.Drawing.Size(61, 23);
            this.BtPrev.TabIndex = 8;
            this.BtPrev.Text = "上一曲";
            this.BtPrev.UseVisualStyleBackColor = true;
            this.BtPrev.Click += new System.EventHandler(this.BtPrev_Click);
            // 
            // BtNext
            // 
            this.BtNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtNext.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.BtNext.Location = new System.Drawing.Point(130, 12);
            this.BtNext.Name = "BtNext";
            this.BtNext.Size = new System.Drawing.Size(59, 23);
            this.BtNext.TabIndex = 9;
            this.BtNext.Text = "下一曲";
            this.BtNext.UseVisualStyleBackColor = true;
            this.BtNext.Click += new System.EventHandler(this.BtNext_Click);
            // 
            // TbVolume
            // 
            this.TbVolume.Location = new System.Drawing.Point(298, 83);
            this.TbVolume.Name = "TbVolume";
            this.TbVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TbVolume.Size = new System.Drawing.Size(45, 319);
            this.TbVolume.TabIndex = 10;
            this.TbVolume.Value = 10;
            this.TbVolume.ValueChanged += new System.EventHandler(this.TbVolume_ValueChanged);
            this.TbVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TbVolume_MouseDown);
            this.TbVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TbVolume_MouseUp);
            // 
            // LbVolume
            // 
            this.LbVolume.AutoSize = true;
            this.LbVolume.Location = new System.Drawing.Point(299, 64);
            this.LbVolume.Name = "LbVolume";
            this.LbVolume.Size = new System.Drawing.Size(29, 12);
            this.LbVolume.TabIndex = 11;
            this.LbVolume.Text = "音量";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(347, 402);
            this.Controls.Add(this.LbVolume);
            this.Controls.Add(this.TbVolume);
            this.Controls.Add(this.BtNext);
            this.Controls.Add(this.BtPrev);
            this.Controls.Add(this.BtLoop);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.lbPlayLocation);
            this.Controls.Add(this.lbOpenFolder);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "本音";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            ((System.ComponentModel.ISupportInitialize)(this.TbVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbOpenFolder;
        private System.Windows.Forms.Label lbPlayLocation;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Button BtLoop;
        private System.Windows.Forms.Button BtPrev;
        private System.Windows.Forms.Button BtNext;
        private System.Windows.Forms.TrackBar TbVolume;
        private System.Windows.Forms.Label LbVolume;
    }
}

