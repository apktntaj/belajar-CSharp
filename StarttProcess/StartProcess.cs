using System;
using System.Diagnostics;

namespace StartProcess
{
    class StartProcess
    {
        public void Run()
        {
            Console.WriteLine("Starting Process!");
            Process process = new();
            process.StartInfo.FileName = "notepad.exe";
            process.StartInfo.Arguments = @"C:\Users\maiae\CsharpProjects\simple-project\tes.txt";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.Start();
            Console.WriteLine("Process Started!");
            // process.WaitForExit();
        }
    }
}