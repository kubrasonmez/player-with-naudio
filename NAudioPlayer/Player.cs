using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NAudioPlayer
{
    public class Player
    {
        public WaveOutEvent output;
        public string Path { get; }
        public Player(string path)
        {
            Path = path;
            output = new WaveOutEvent();
        }
        public void PlayWav()
        {
            if (output.PlaybackState == PlaybackState.Stopped)
            {
                Play();
            }
            else if (output.PlaybackState == PlaybackState.Paused)
            {
                Resume();
            }
            else
            {
                return;
            }
        }
        private void Play()
        {
            FileStream wav_file_stream = File.OpenRead(Path);

            // Reset the stream to the beginning
            wav_file_stream.Seek(0, SeekOrigin.Begin);

            WaveStream ws_raw = new WaveFileReader(wav_file_stream);
            ws_raw = WaveFormatConversionStream.CreatePcmStream(ws_raw);
            output.Init(ws_raw);
            output.Play();
        }

        private void Resume() => output.Play();
        public void Pause() => output.Pause();
        public void Stop() => output.Stop();
        public PlaybackState GetStatus() => output.PlaybackState;



    }
}
