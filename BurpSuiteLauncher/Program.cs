using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace BurpSuiteLauncher
{
    static class Program
    {
        private static void Exec_burp(string loadername, string programname)
        {
            string args = $"-Xmx8G -XX:-UseParallelGC -noverify -javaagent:{loadername.Trim()} -Dfile.encoding=utf-8 -jar {programname.Trim()}";
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "java.exe";
            p.Arguments = args;
            p.UseShellExecute = false;
            p.CreateNoWindow = true;
            Process.Start(p);

            Thread.Sleep(2000);
            Environment.Exit(0);
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-gui":
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Launcher());
                        break;
                }
            }
            Exec_burp(@"BurpSuiteLoader_v2021.12.1.jar", @"burpsuite_pro_v2021.12.1.jar");
        }
    }
}
