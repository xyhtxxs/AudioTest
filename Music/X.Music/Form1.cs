using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Security.Cryptography;

namespace X.Music
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource TokenSource = null;
        private CancellationToken Token = new CancellationToken();
        private WaveOutEvent Wave = null;
        private string CurMP3Path = "";
        private bool IsManualOperation = false;
        private int LoopType = 2;
        private Stopwatch SW = new Stopwatch();
        private List<string> MusicPathList = new List<string>();
        private Graphics Graphics = null;
        private Player Player = null;
        private List<Music> MusicList = new List<Music>();
        private TimeSpan TimeSpaned = new TimeSpan();
        private int PlayStatus = 1;//正常=1；暂停=2；继续=3；
        private bool UiBarLock = false;
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            //当在子线程访问主线程创建的页面控件时，
            //报：线程间操作无效: 从不是创建控件“ProgressBar1”的线程访问它。
            //加上此句则不会捕获对错误线程的调用
            //但是应用此功能后，如果在子线程中持续对UI控件监控，然后又回头再主线程中访问UI控件，
            //则UI会卡死等待=死循环，此时的解决办法：
            //在主线程访问UI控件时用Invoke(new MethodInvoker(() => {}));即可
            CheckForIllegalCrossThreadCalls = false;
            LoadMusic();
            Graphics = this.ProgressBar1.CreateGraphics();
            //string TOKEN_VALUE = Encode(string.Format("TOSRSCWebService|{0}",DateTime.Now.ToString("yyyy-MM-dd")));
        }

        private static readonly byte[] _key = { 23, 45, 62, 52, 21, 38, 66, 39 };
        private static readonly byte[] _iv = { 60, 59, 23, 41, 68, 43, 33, 20 };
        public static string Encode(string data)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            string result = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

            ms.Dispose();
            cst.Dispose();
            sw.Dispose();
            return result;

        }
        private void LoadMusic(List<string> musicPathList = null)
        {
            if (musicPathList == null)
            {
                MusicPathList = Directory.GetFiles("D:\\Study\\0\\MP3").ToList();
            }
            else
            {
                MusicPathList.AddRange(musicPathList);
            }
            MusicList.Clear();
            foreach (var item in MusicPathList.Distinct())
            {
                var name = Path.GetFileName(item);
                MusicList.Add(new Music(name, item));

            }
            listBox1.DataSource = MusicList;
            listBox1.DisplayMember = "MusicName";
            listBox1.ValueMember = "MusicUri";
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            if (MusicPathList != null && MusicPathList.Count > 0)
            {
                Task.Run(() =>
                {
                    CurMP3Path = MusicPathList[0].ToString();
                    Invoke(new MethodInvoker(() =>
                    {
                        listBox1.SelectedIndex = 0;
                    }));
                    Launch(CurMP3Path);
                });
            }
        }

        private void lbOpenFolder_DoubleClick(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.listBox1.DataSource = openFileDialog1.FileNames.ToList();
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //if (Wave != null && Wave.PlaybackState != PlaybackState.Stopped)
            //{
            //    IsManualOperation = true;
            //}
            IsManualOperation = true;
            if (listBox1.SelectedItem != null)
            {
                Invoke(new MethodInvoker(() => { CurMP3Path = ((Music)listBox1.SelectedItem).MusicUri; }));
                ClickPlay();
            }
        }

        /// <summary>
        /// async Task
        /// </summary>
        /// <param name="path"></param>
        /// <param name="time"></param>
        private void Launch(string path, double time = 0)
        {
            if (string.IsNullOrWhiteSpace(path)) return;
            Mp3File mp3 = new Mp3File(path);
            using (var reader = new MediaFoundationReader(path))
            {
                var readerProvider = new SmbPitchShiftingSampleProvider(reader.ToSampleProvider());
                using (Wave = new WaveOutEvent())
                {
                    Wave.PlaybackStopped += Wave_PlaybackStopped;
                    Invoke(new MethodInvoker(() =>
                    {
                        this.ProgressBar1.Maximum = int.Parse(Math.Floor(mp3.Duration.TotalMilliseconds).ToString());
                        ProgressBar1.Visible = true;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Value = 1;
                        Player = new Player(ProgressBar1, Graphics);
                        Player.PlaybackProgress += OnPlaybackProgress;
                    }));

                    try
                    {
                        double time2 = 0;
                        if (time != 0) time2 = (int)Math.Floor(time / 1000);
                        else time2 = TimeSpaned.TotalSeconds;
                        Wave.Init(readerProvider.Take(mp3.Duration - TimeSpan.FromSeconds(time2)).Skip(TimeSpan.FromSeconds(time2)));
                        Wave.Play();
                    }
                    catch (Exception e1)
                    {
                        var x = e1.Message;
                    }
                    SW.Restart();
                    while ( Wave.PlaybackState == PlaybackState.Playing)
                    {
                        try
                        {
                            if (!UiBarLock)
                            {
                                var ts = SW.Elapsed;
                                double time3 = 0;
                                if (time != 0) time3 = time;
                                else time3 = TimeSpaned.TotalMilliseconds;
                                //Invoke(new MethodInvoker(() =>
                                //{
                                    var h = ts.Hours + TimeSpaned.Hours;
                                    var m = ts.Minutes + TimeSpaned.Minutes;
                                    var s = ts.Seconds + TimeSpaned.Seconds;
                                    var ms = ts.Milliseconds + TimeSpaned.Milliseconds;
                                    SetProgress((int)Math.Floor(ts.TotalMilliseconds + time));
                                    lbPlayLocation.Text = string.Format("{0}:{1}:{2}:{3} [{4}]", h, m, s, ms / 10, mp3.Name);
                                //}));
                            }
                        }
                        catch(Exception e)
                        {
                            Wave.Stop();
                            Wave.Dispose();
                            reader.Dispose();
                        }
                    }
                }
            }
        }

        private void Wave_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (UiBarLock)
            {
                return;
            }
            if (IsManualOperation)
            {
                IsManualOperation = false;
                return;
            }
            if (Wave.PlaybackState == PlaybackState.Stopped)
            {
                int listCurIndex = 0;
                if (LoopType == 1)
                {
                    //单循当前
                }
                else if (LoopType == 2)
                {
                    var i = MusicPathList.IndexOf(CurMP3Path);
                    if (i < MusicPathList.Count - 1)
                    {
                        listCurIndex = i + 1;
                        CurMP3Path = MusicPathList[listCurIndex].ToString();
                    }
                    else CurMP3Path = MusicPathList[listCurIndex].ToString();
                }
                else if (LoopType == 3)
                {
                    Random random = new Random();
                    listCurIndex = random.Next(0, MusicPathList.Count - 1);
                    CurMP3Path = MusicPathList[listCurIndex].ToString();
                }
                else if (LoopType == 4)
                {
                    CurMP3Path = "";
                }
                else if (PlayStatus == 3)
                {
                    PlayStatus = 1;//状态回复正常
                    TimeSpaned = new TimeSpan();
                }

                Invoke(new MethodInvoker(() =>
                {
                    listBox1.SelectedIndex = listCurIndex;
                }));
                Launch(CurMP3Path);
            }
            SW.Stop();
        }

        private void OnPlaybackProgress(object sender, PlaybackProgressEventArgs e)
        {
            Invoke(new MethodInvoker(() => { this.ProgressBar1.Value = e.CurrentTime; }));
        }
        public void SetProgress(int progress)
        {
            if (progress > ProgressBar1.Maximum) return;
            ProgressBar1.Value = progress;
            string str = Math.Round((100 * progress / (double)ProgressBar1.Maximum), 2).ToString("#0.00 ") + "%";
            Font font = new Font("Times New Roman", (float)10, FontStyle.Regular);
            PointF pt = new PointF(this.ProgressBar1.Width / 2 - 17, this.ProgressBar1.Height / 2 - 7);
            Graphics.DrawString(str, font, Brushes.Blue, pt);
        }
        private void ClearPlayer()
        {
            if (Wave != null)
            {
                if (Wave.PlaybackState != PlaybackState.Stopped) Wave.Stop();
                Wave.Dispose();
            }
            if (TokenSource != null && !TokenSource.IsCancellationRequested)
            {
                TokenSource.Cancel();
            }
        }

        private void ProgressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Wave != null && Wave.PlaybackState == PlaybackState.Playing)
            {
                UiBarLock = true;
            }
        }

        private void ProgressBar1_MouseUp(object sender, MouseEventArgs e)
        {
            // 假设这是设置歌曲到指定进度的方法                
            Invoke(new MethodInvoker(() =>
            {
                int newProgress = (int)Math.Floor((float)ProgressBar1.Maximum * ((float)e.X / (float)ProgressBar1.Width));
                ProgressBar1.Value = newProgress;
                ClickPlay(newProgress);//毫秒
            }));
            UiBarLock = false;
        }

        private void Exit(object sender, EventArgs e)
        {
            IsManualOperation = true;
            if (this.Wave != null)
            {
                this.Wave.Stop();
                this.Wave.Dispose();
            }
            if (this.TokenSource != null)
            {
                this.TokenSource.Cancel();
            }
            this.Close();
        }

        private void BtPrev_Click(object sender, EventArgs e)
        {
            IsManualOperation = true;
            TimeSpaned = new TimeSpan();
            var i = MusicPathList.IndexOf(CurMP3Path);

            if (i > 0)
            {
                CurMP3Path = MusicPathList[i - 1];
                Invoke(new MethodInvoker(() =>
                {
                    listBox1.SelectedIndex = i - 1;
                }));
            }
            else Invoke(new MethodInvoker(() =>
            {
                listBox1.SelectedIndex = i;
            }));
            ClickPlay();
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            IsManualOperation = true;
            TimeSpaned = new TimeSpan();
            var i = MusicPathList.IndexOf(CurMP3Path);
            listBox1.SelectedIndex = i;
            if (i < MusicPathList.Count - 1)
            {
                CurMP3Path = MusicPathList[i + 1];
                Invoke(new MethodInvoker(() =>
                {
                    listBox1.SelectedIndex = i + 1;
                }));
            }
            else Invoke(new MethodInvoker(() =>
            {
                listBox1.SelectedIndex = i;
            }));
            ClickPlay();
        }

        private void BtLoop_Click_1(object sender, EventArgs e)
        {
            if (LoopType == 4)
            {
                LoopType = 1;
                BtLoop.Text = "单循环";
            }
            else if (LoopType == 1)
            {
                LoopType = 2;
                BtLoop.Text = "全循环";
            }
            else if (LoopType == 2)
            {
                LoopType = 3;
                BtLoop.Text = "随机播";
            }
            else if (LoopType == 3)
            {
                LoopType = 4;
                BtLoop.Text = "不循环";
            }

        }

        private void BtPause_Click(object sender, EventArgs e)
        {
            IsManualOperation = true;
            if (Wave != null)
            {
                if (Wave.PlaybackState != PlaybackState.Stopped)
                {
                    PlayStatus = 2;
                    this.btPause.Text = "继续";
                    Wave.Pause();
                    SW.Stop();
                    TimeSpaned = SW.Elapsed;
                }
                else if (Wave.PlaybackState != PlaybackState.Paused)
                {
                    PlayStatus = 3;
                    this.btPause.Text = "暂停";
                    ClickPlay();
                }

            }
        }

        private void ClickPlay(double time = 0)
        {
            if (TokenSource != null && !TokenSource.IsCancellationRequested)
            {
                TokenSource.Cancel();
            }
            TokenSource = new CancellationTokenSource();
            Token = TokenSource.Token;
            Task.Run(() =>
            {
                Launch(CurMP3Path, time);
            }, Token);
        }

        private void TbVolume_MouseDown(object sender, MouseEventArgs e)
        {
            UiBarLock = true;
        }

        private void TbVolume_MouseUp(object sender, MouseEventArgs e)
        {
            if (Wave != null)
            {
                Wave.Volume = (float)TbVolume.Value/ (float)10;
            }
            UiBarLock = false;
        }

        private void TbVolume_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
