using System;
using System.Diagnostics;

namespace Simple_HWID_Grabber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HWID Grabber";
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("wmic csproduct get uuid");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.Clear();
            string[] dates = cmd.StandardOutput.ReadToEnd().Split('\n');
            string hwid = dates[5];
            Console.WriteLine("Grabbed HWID: " + hwid);
            Console.ReadLine();
        }
    }
}
