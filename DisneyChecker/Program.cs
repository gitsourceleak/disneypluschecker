using CrackedAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DisneyChecker
{

    internal class Program
    {
        internal const string version = "v1.0.0";
        [STAThread]

        
        static void Main(string[] args)
        {
            // login options
            Design();
            Colorful.Console.Write(" [", Color.MidnightBlue);
            Colorful.Console.Write("1", Color.GhostWhite);
            Colorful.Console.Write("] ", Color.MidnightBlue);
            Colorful.Console.Write("Authorize", Color.GhostWhite);
            Console.WriteLine();
            Colorful.Console.Write(" [", Color.MidnightBlue);
            Colorful.Console.Write("X", Color.GhostWhite);
            Colorful.Console.Write("] ", Color.MidnightBlue);
            Colorful.Console.Write("Exit", Color.GhostWhite);
            Console.WriteLine();
            Colorful.Console.Write(" ~ ", Color.MidnightBlue);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                Login();
            }
            else if (key.Key == ConsoleKey.X)
            {
                Console.WriteLine();
                Colorful.Console.Write(" [Dixney] ", Color.MidnightBlue);
                Colorful.Console.Write("Closing Now (fuck you)", Color.GhostWhite);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
        }
        public static void menu()
        {
            string path = "config.json";
            Config.config = File.Exists(path) ? JsonConvert.DeserializeObject<Config.configObject>(File.ReadAllText(path)) : Config.renew(true);
            Design();
            Colorful.Console.Write(" [", Color.MidnightBlue);
            Colorful.Console.Write("1", Color.GhostWhite);
            Colorful.Console.Write("] ", Color.MidnightBlue);
            Colorful.Console.Write("Check", Color.GhostWhite);
            Console.WriteLine();
            Colorful.Console.Write(" [", Color.MidnightBlue);
            Colorful.Console.Write("X", Color.GhostWhite);
            Colorful.Console.Write("] ", Color.MidnightBlue);
            Colorful.Console.Write("Exit", Color.GhostWhite);
            Console.WriteLine();
            Colorful.Console.Write(" ~ ", Color.MidnightBlue);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                Utils.p1 = Config.config.uitype;
                Utils.pickedModules.Add(new Func<string[], string, bool>(Disney.check));
                Utils.Module = "Disney";
                startchecker();
            }
            else if (key.Key == ConsoleKey.X)
            {
                Console.WriteLine();
                Colorful.Console.Write(" [Dixney] ", Color.MidnightBlue);
                Colorful.Console.Write("Closing Now (fuck you)", Color.GhostWhite);
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
        }

        public static void startchecker()
        {
            while (true)
            {


                Design();
                Colorful.Console.Write(" [Input] ", Color.MidnightBlue);
                Colorful.Console.Write("Enter a ", Color.GhostWhite);
                Colorful.Console.Write("Thread ", Color.MidnightBlue);
                Colorful.Console.Write("Amount: ", Color.GhostWhite);
                try
                {
                    Utils.globalThreads = int.Parse(Console.ReadLine());
                    if (0 >= Utils.globalThreads)
                    {
                        Console.WriteLine();
                        Colorful.Console.Write(" [Error] ", Color.MidnightBlue);
                        Colorful.Console.Write("Please Try Again..", Color.GhostWhite);
                        Thread.Sleep(1500);
                        startchecker();
                    }
                    else if (Utils.globalThreads > 2500)
                    {
                        Console.WriteLine();
                        Colorful.Console.Write(" [Error] ", Color.MidnightBlue);
                        Colorful.Console.Write("Please Try Again..", Color.GhostWhite);
                        Thread.Sleep(1500);
                        startchecker();
                    }
                    else
                        break;
                }
                catch
                {
                    Console.WriteLine();
                    Colorful.Console.Write(" [Error] ", Color.MidnightBlue);
                    Colorful.Console.Write("Please Try Again..", Color.GhostWhite);
                    Thread.Sleep(1500);
                    startchecker();
                }
            }
            while (true)
            {
                Design();
                Colorful.Console.Write(" [Input] ", Color.MidnightBlue);
                Colorful.Console.Write("Pick Proxy Type: ", Color.GhostWhite);
                Colorful.Console.Write("(1) ", Color.MidnightBlue);
                Colorful.Console.Write("HTTP", Color.GhostWhite);
                Console.WriteLine();
                Colorful.Console.Write("                          ", Color.GhostWhite);
                Colorful.Console.Write("(2) ", Color.MidnightBlue);
                Colorful.Console.Write("SOCKS4", Color.GhostWhite);
                Console.WriteLine();
                Colorful.Console.Write("                          ", Color.GhostWhite);
                Colorful.Console.Write("(3) ", Color.MidnightBlue);
                Colorful.Console.Write("SOCKS5", Color.GhostWhite);
                Console.WriteLine();
                string proxy = Console.ReadLine();
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        goto label_9;
                    case '2':
                        goto label_10;
                    case '3':
                        goto label_11;
                    default:
                        Console.WriteLine();
                        Colorful.Console.Write(" [Error] ", Color.MidnightBlue);
                        Colorful.Console.Write("Please Try Again..", Color.GhostWhite);
                        Thread.Sleep(1500);
                        startchecker();
                        continue;
                }
            }
        label_9:
            Design();
            Write("\n HTTP Selected!", Color.MidnightBlue, 35);
            Console.WriteLine();
            goto label_12;
        label_10:
            Design();
            Write("\n SOCKS4 Selected!", Color.MidnightBlue, 35);
            goto label_12;
        label_11:
            Design();
            Write("\n SOCKS5 Selected!", Color.MidnightBlue, 35);
            goto label_12;
        label_12:
            Thread.Sleep(1500);
            Design();
            Colorful.Console.Write(" [Input] ", Color.MidnightBlue);
            Colorful.Console.Write("Please Load ", Color.GhostWhite);
            Colorful.Console.Write("Combos", Color.MidnightBlue);
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string fileName1;
            do
            {
                openFileDialog1.Title = "Load Combos";
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Text Files|*.txt";
                openFileDialog1.RestoreDirectory = true;
                int num = (int)openFileDialog1.ShowDialog();
                fileName1 = openFileDialog1.FileName;
            }
            while (!File.Exists(fileName1));
            try
            {
                Utils.combos = (IEnumerable<string>)File.ReadAllLines(fileName1);
            }
            catch
            {
                Console.WriteLine();
                Colorful.Console.Write(" [Error] ", Color.MidnightBlue);
                Colorful.Console.Write("Please Try Again..", Color.GhostWhite);
                Thread.Sleep(1500);
                startchecker();
            }
            Design();
            Colorful.Console.Write(" [Input] ", Color.MidnightBlue);
            Colorful.Console.Write("Please Load ", Color.GhostWhite);
            Colorful.Console.Write("Proxies", Color.MidnightBlue);
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            string fileName2;
            do
            {
                openFileDialog2.Title = "Load Combos";
                openFileDialog2.DefaultExt = "txt";
                openFileDialog2.Filter = "Text Files|*.txt";
                openFileDialog2.RestoreDirectory = true;
                int num = (int)openFileDialog2.ShowDialog();
                fileName2 = openFileDialog2.FileName;
            }
            while (!File.Exists(fileName2));
            try
            {
                Utils.proxies = (IEnumerable<string>)File.ReadAllLines(fileName2);
            }
            catch
            {
                Console.WriteLine();
                Colorful.Console.Write(" [Error] ", Color.MidnightBlue);
                Colorful.Console.Write("Please Try Again..", Color.GhostWhite);
                Thread.Sleep(1500);
                startchecker();
            }
            if (Utils.p1 == "2")
            {
                Utils.proxiesCount = Utils.proxies.Count<string>();
                Utils.comboTotal = Utils.combos.Count<string>();
                Design();
                Colorful.Console.WriteLine();
                Colorful.Console.Write(" [", Color.MidnightBlue);
                Colorful.Console.Write("!", Color.GhostWhite);
                Colorful.Console.WriteLine("] Configuration", Color.MidnightBlue);
                Colorful.Console.Write(" [", Color.MidnightBlue);
                Colorful.Console.Write(">", Color.GhostWhite);
                Colorful.Console.Write("] Proxies Loaded [", Color.MidnightBlue);
                Colorful.Console.Write(Utils.proxiesCount.ToString(), Color.GhostWhite);
                Colorful.Console.WriteLine("]", Color.MidnightBlue);
                Colorful.Console.Write(" [", Color.MidnightBlue);
                Colorful.Console.Write(">", Color.GhostWhite);
                Colorful.Console.Write("] Proxy Type [", Color.MidnightBlue);
                Colorful.Console.Write(Utils.proxyProtocol, Color.GhostWhite);
                Colorful.Console.WriteLine("]", Color.MidnightBlue);
                Colorful.Console.Write(" [", Color.MidnightBlue);
                Colorful.Console.Write(">", Color.GhostWhite);
                Colorful.Console.Write("] Lines Loaded [", Color.MidnightBlue);
                Colorful.Console.Write(Utils.comboTotal.ToString(), Color.GhostWhite);
                Colorful.Console.WriteLine("]", Color.MidnightBlue);
                Colorful.Console.Write(" [", Color.MidnightBlue);
                Colorful.Console.Write(">", Color.GhostWhite);
                Colorful.Console.Write("] Retries [", Color.MidnightBlue);
                Colorful.Console.Write(Config.config.retries.ToString(), Color.GhostWhite);
                Colorful.Console.WriteLine("]", Color.MidnightBlue);
                Colorful.Console.Write(" [", Color.MidnightBlue);
                Colorful.Console.Write(">", Color.GhostWhite);
                Colorful.Console.Write("] Thread Count [", Color.MidnightBlue);
                Colorful.Console.Write(Utils.globalThreads.ToString(), Color.GhostWhite);
                Colorful.Console.WriteLine("]", Color.MidnightBlue);
                Colorful.Console.WriteLine();
                Thread.Sleep(20);
            }
            Thread.Sleep(100);
            for (int index = 1; index <= Utils.globalThreads; ++index)
                new Thread((ThreadStart)(() =>
                {
                    Random random = new Random();
                    while (Utils.comboIndex < Utils.combos.Count<string>())
                    {
                        int comboIndex = Utils.comboIndex;
                        Interlocked.Increment(ref comboIndex);
                        string[] strArray = Utils.combos.ElementAt<string>(comboIndex).Split(':');
                        string str = Utils.proxies.ElementAt<string>(random.Next(Utils.proxiesCount));
                        foreach (Func<string[], string, bool> func in Utils.pickedModules.Distinct<Func<string[], string, bool>>())
                        {
                            int num = func(strArray, str) ? 1 : 0;
                        }
                        ++Utils.checks;
                    }
                })).Start();
            if (Utils.p1 == "1")
            {
                updateTitleCUI();
            }
            else
            {
                if (!(Utils.p1 == "2"))
                    return;
                updateTitleLOG();
            }
        }

        public static void updateTitleLOG()
        {
            int checks = Utils.checks;
            while (true)
            {
                do
                {
                    Utils.cpm = checks - checks;
                    checks = Utils.checks;
                    Colorful.Console.Title = "Dixney ~ SexyAzure | Module: " + Utils.Module + " | Hits - " + Utils.hits.ToString() + " | Frees - " + Utils.frees.ToString() + " | Bads - " + (Utils.checks - Utils.hits - Utils.frees).ToString() + " | Checked - " + Utils.checks.ToString() + "/" + Utils.comboTotal.ToString() + " | Errors - " + Utils.errors.ToString() + " | Cpm - " + (Utils.cpm * 60).ToString();
                    Thread.Sleep(Config.config.refreshrate);
                }
                while (checks < Utils.comboTotal);
                Colorful.Console.Title = "Dixney ~ SexyAzure | Module: " + Utils.Module + " | Hits ~ " + Utils.hits.ToString() + " | Leave A +Rep ;)";
                Colorful.Console.Write(" [", Color.MidnightBlue);
                Colorful.Console.Write("!", Color.GhostWhite);
                Colorful.Console.Write("] ", Color.MidnightBlue);
                Colorful.Console.WriteLine("Finished Checking... Press Any Key to Exit", Color.MidnightBlue);
                Colorful.Console.ReadLine();
                Environment.Exit(0);
            }
        }
        public static void updateTitleCUI()
        {
            int checks = Utils.checks;
            while (true)
            {
                do
                {
                    Utils.cpm = Utils.checks - checks;
                    checks = Utils.checks;
                    Colorful.Console.Clear();
                    Design();
                    Colorful.Console.Title = "Dixney ~ SexyAzure | Module: " + Utils.Module + " | Hits - " + Utils.hits.ToString() + " | Frees - " + Utils.frees.ToString() + " | Bads - " + (Utils.checks - Utils.hits - Utils.frees).ToString() + " | Remaining - " + (Utils.comboTotal - Utils.checks).ToString() + " | Errors - " + Utils.errors.ToString() + " | Cpm - " + (Utils.cpm * 60).ToString();
                    Colorful.Console.WriteLine();
                    Colorful.Console.WriteLine();
                    Colorful.Console.WriteLineFormatted(" [{0}] Hits ~ {1}", Color.Green, Color.White, (object)">", (object)string.Format("{0}", (object)Utils.hits));
                    Colorful.Console.WriteLineFormatted(" [{0}] 2FA ~ {1}", Color.Aquamarine, Color.White, (object)">", (object)string.Format("{0}", (object)Utils.twofa));
                    Colorful.Console.WriteLineFormatted(" [{0}] Frees ~ {1}", Color.Yellow, Color.White, (object)">", (object)string.Format("{0}", (object)Utils.frees));
                    Colorful.Console.WriteLineFormatted(" [{0}] Bad ~ {1}", Color.Red, Color.White, (object)">", (object)string.Format("{0}", (object)(Utils.checks - Utils.hits - Utils.frees - Utils.twofa)));
                    Colorful.Console.WriteLineFormatted(" [{0}] Checked ~ {1}", Color.Orange, Color.White, (object)">", (object)string.Format("{0}", (object)Utils.checks));
                    Colorful.Console.WriteLineFormatted(" [{0}] Remaining ~ {1}", Color.Orange, Color.White, (object)">", (object)string.Format("{0}", (object)(Utils.comboTotal - Utils.checks)));
                    Colorful.Console.WriteLineFormatted(" [{0}] Threads ~ {1}", Color.Goldenrod, Color.White, (object)">", (object)string.Format("{0}", (object)Utils.globalThreads));
                    Colorful.Console.WriteLineFormatted(" [{0}] Errors ~ {1}", Color.Indigo, Color.White, (object)">", (object)string.Format("{0}", (object)Utils.errors));
                    Colorful.Console.WriteLineFormatted(" [{0}] Retries ~ {1}", Color.Lime, Color.White, (object)">", (object)string.Format("{0}", (object)Utils.retries));
                    Colorful.Console.WriteLineFormatted(" [{0}] CPM ~ {1}", Color.Aquamarine, Color.White, (object)">", (object)string.Format("{0}", (object)(Utils.cpm * 60)));
                    Thread.Sleep(Config.config.refreshrate);
                }
                while (Utils.checks < Utils.comboTotal);
                Colorful.Console.Title = "Dixney ~ SexyAzure | Module: " + Utils.Module + " | Hits ~ " + Utils.hits.ToString() + " | Leave A +Rep ;)";
                Colorful.Console.Write(" [", Color.MidnightBlue);
                Colorful.Console.Write("!", Color.GhostWhite);
                Colorful.Console.Write("] ", Color.MidnightBlue);
                Colorful.Console.WriteLine("Finished Checking... Press Any Key to Exit", Color.GhostWhite);
                Colorful.Console.ReadLine();
                Environment.Exit(0);
            }
        }
        public static void Login()
        {
            string KEY;
            Design();
            Colorful.Console.Write(" [Input] ", Color.MidnightBlue);
            Colorful.Console.Write("Enter your ", Color.GhostWhite);
            Colorful.Console.Write("Cracked.io ", Color.MidnightBlue);
            Colorful.Console.Write("Auth Key", Color.GhostWhite);
            Colorful.Console.Write(": ", Color.Silver);
            KEY = Console.ReadLine();
            if (KEY == "")
            {
                menu();
            }
        }
        public static void Write(string m, Color c, int t)
        {
            foreach (char ch in m)
            {
                Colorful.Console.Write(ch, c);
                Thread.Sleep(t);
            }
        }
        public static void Design()
        {
            Console.Clear();
            Console.Title = $"Dixney (Disney Checker) ~ SexyAzure | {version}";
            Console.WriteLine();
            Colorful.Console.WriteLine("                                   █████▄  ██  ██   ██  ███▄    █  █████ ██   ██", Color.MidnightBlue);
            Colorful.Console.WriteLine("                                   ██▀ ██▌ ██    █ █    ██ ▀█   █  █   ▀  ██  ██", Color.MidnightBlue);
            Colorful.Console.WriteLine("                                   ██   █▌ ██     █     ██  ▀█ ██  ███     ██ ██", Color.MidnightBlue);
            Colorful.Console.WriteLine("                                    █▄   ▌ ██    █ █    ██   ▐▌██   █  ▄    ▐██", Color.MidnightBlue);
            Colorful.Console.WriteLine("                                    ████   ██  ██   ██  ██     ██   ████    ██", Color.MidnightBlue);
            Colorful.Console.WriteLine("                                                                           ██ ", Color.MidnightBlue);
            Colorful.Console.WriteLine("                                                                          ██", Color.MidnightBlue);
            Colorful.Console.Write("                                            [ ", Color.MidnightBlue);
            Colorful.Console.Write($"Disney Checker - {version}", Color.GhostWhite);
            Colorful.Console.Write(" ]", Color.MidnightBlue);
            Console.WriteLine();
            Colorful.Console.Write("                                              SexyAzure {", Color.MidnightBlue);
            Colorful.Console.Write($"Cracked.io", Color.GhostWhite);
            Colorful.Console.Write("}", Color.MidnightBlue);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
