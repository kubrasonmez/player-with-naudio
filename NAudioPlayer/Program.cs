using System;
using System.Threading;
using NAudio.Wave;
namespace NAudioPlayer
{
    class Program
    {
        private static string wav_file_path = @"D:\sound.wav";
        private static string wav_file_path2 = @"D:\sound2.wav";

        static void Main(string[] args)
        {
            Player player1 = new Player(wav_file_path);
            Player player2 = new Player(wav_file_path2);
            player1.output.PlaybackStopped += new EventHandler<StoppedEventArgs>(audioOutput_Playback1Stopped);
            player2.output.PlaybackStopped += new EventHandler<StoppedEventArgs>(audioOutput_Playback2Stopped);
            player1.PlayWav();
            Thread.Sleep(3000);
            player2.PlayWav();
            Thread.Sleep(7000);
            player2.Pause();
            Thread.Sleep(3000);
            Console.WriteLine($"Player1 : {player1.GetStatus()}");
            player1.Stop();
            Console.WriteLine($"Player 2 : {player2.GetStatus()}");
            player2.PlayWav();
            Console.WriteLine($"Player 1 : {player1.GetStatus()}");
            Console.WriteLine($"Player 2 : {player2.GetStatus()}");
            Console.Write("Press any key to exit");
            Console.ReadKey();
        }

        private static void audioOutput_Playback1Stopped(object sender, StoppedEventArgs e)
        {
            Console.WriteLine($"Player1 durdu.");
        }
        private static void audioOutput_Playback2Stopped(object sender, StoppedEventArgs e)
        {
            Console.WriteLine($"Player1 durdu.");
        }
    }
}
