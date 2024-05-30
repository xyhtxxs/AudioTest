using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X.Music
{
    public class Player
    {
        private ProgressBar ProgressBar1 = null;
        private Graphics Graphics = null;

        public Player(ProgressBar progress1, Graphics graphics)
        {
            this.ProgressBar1 = progress1;
            this.Graphics = graphics;
        }

        // 播放进度更新的事件
        public event EventHandler<PlaybackProgressEventArgs> PlaybackProgress;

        // 触发播放进度更新的方法
        public void OnPlaybackProgress(int currentTime)
        {
            PlaybackProgress?.Invoke(this, new PlaybackProgressEventArgs(currentTime));
        }

        // 设置进度的方法
        public void SetProgress(int progress)
        {
            // 假设这是设置歌曲进度的代码
            if (progress > ProgressBar1.Maximum) return;
            //ProgressBar1.PerformStep();
            ProgressBar1.Value = progress;
            string str = Math.Round((100 * progress / (double)ProgressBar1.Maximum), 2).ToString("#0.00 ") + "%";
            Font font = new Font("Times New Roman", (float)10, FontStyle.Regular);
            PointF pt = new PointF(this.ProgressBar1.Width / 2 - 17, this.ProgressBar1.Height / 2 - 7);
            Graphics.DrawString(str, font, Brushes.Blue, pt);
        }

    }

    public class PlaybackProgressEventArgs : EventArgs
    {
        public int CurrentTime { get; }

        public PlaybackProgressEventArgs(int currentTime)
        {
            CurrentTime = currentTime;
        }
    }
}
