using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace BurpSuiteLauncher
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string args = $"-Xmx8G -XX:-UseParallelGC -noverify -javaagent:{Loader_Name.Text.Trim()} -Dfile.encoding=utf-8 -jar {Program_Name.Text.Trim()}";
            Process p = new Process();
            p.StartInfo.FileName = "java.exe";
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            
            p.StartInfo.ErrorDialog = true;
            p.Start();

            Thread.Sleep(2000);
            Application.Exit();
        }

        public static void BindAllFiles(string path, ComboBox comboxlist)
        {
            List<string> list = new List<string>();
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            FileInfo[] finfo = dirinfo.GetFiles("*.jar", SearchOption.TopDirectoryOnly);

            foreach (FileInfo NextFile in finfo)
            {
                list.Add(NextFile.Name);
            }
            comboxlist.DataSource = list;
            comboxlist.SelectedIndex = -1;
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            BindAllFiles(Directory.GetCurrentDirectory(), Program_Name);
            BindAllFiles(Directory.GetCurrentDirectory(), Loader_Name);
        }
    }
}
