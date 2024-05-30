using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Music
{
    class NAudioRecordHelper
    {
        public enum RecordType
        {
            loudspeaker = 0, // 扬声器
            microphone = 1, //麦克风
            interSoundTrack = 2 //内部音轨
        }

        //录制的类型
        RecordType t = RecordType.microphone;

        //录制麦克风的声音
        WaveInEvent waveIn = null; //new WaveInEvent();
        //录制扬声器的声音
        WasapiLoopbackCapture capture = null; //new WasapiLoopbackCapture();
        //生成音频文件的对象
        WaveFileWriter writer = null;

        string audioFile = "";

        public NAudioRecordHelper(RecordType x, string filePath)
        {
            t = x;
            audioFile = filePath;
        }

        /// <summary>
        /// 开始录制
        /// </summary>
        public void StartRecordAudio()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(audioFile))
                {
                    System.Windows.Forms.MessageBox.Show("请设置录制文件的路径！");
                    return;
                }

                if (t == RecordType.microphone)
                {
                    waveIn = new WaveInEvent();
                    writer = new WaveFileWriter(audioFile, waveIn.WaveFormat);
                    //开始录音，写数据
                    waveIn.DataAvailable += (s, a) =>
                    {
                        writer.Write(a.Buffer, 0, a.BytesRecorded);
                    };

                    //结束录音
                    waveIn.RecordingStopped += (s, a) =>
                    {
                        writer.Dispose();
                        writer = null;
                        waveIn.Dispose();

                    };


                    waveIn.StartRecording();
                }
                else
                {
                    capture = new WasapiLoopbackCapture();
                    writer = new WaveFileWriter(audioFile, capture.WaveFormat);

                    capture.DataAvailable += (s, a) =>
                    {
                        writer.Write(a.Buffer, 0, a.BytesRecorded);
                    };
                    //结束录音
                    capture.RecordingStopped += (s, a) =>
                    {
                        writer.Dispose();
                        writer = null;
                        capture.Dispose();
                    };


                    capture.StartRecording();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //结束录制
        public void StopRecordAudio()
        {
            if (t == RecordType.microphone)
                waveIn.StopRecording();
            else
                capture.StopRecording();
        }
    }
}
