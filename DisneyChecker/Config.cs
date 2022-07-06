using Colorful;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Threading;


namespace DisneyChecker
{
    internal class Config
    {
        public static Config.configObject config = new Config.configObject();
        public static Config.configObject renew(bool AskToSave)
        {
            Program.Design();
            Console.Write(" [", Color.MidnightBlue);
            Console.Write("?", Color.GhostWhite);
            Console.WriteLine("] UI Type?", Color.MidnightBlue);
            Console.Write(" [", Color.MidnightBlue);
            Console.Write("1", Color.GhostWhite);
            Console.WriteLine("] CUI", Color.MidnightBlue);
            Console.Write(" [", Color.MidnightBlue);
            Console.Write("2", Color.GhostWhite);
            Console.WriteLine("] Log", Color.MidnightBlue);
            Console.Write(" » ", Color.GhostWhite);
            Config.config.uitype = Console.ReadLine();
            Console.WriteLine();
            Console.Write(" [", Color.MidnightBlue);
            Console.Write("?", Color.GhostWhite);
            Console.WriteLine("] Refresh Rate? *In ms* (Recommended  1000)", Color.MidnightBlue);
            Console.Write(" » ", Color.GhostWhite);
            Config.config.refreshrate = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" [", Color.MidnightBlue);
            Console.Write("?", Color.GhostWhite);
            Console.WriteLine("] How Many Retries? (Recommended  3)", Color.MidnightBlue);
            Console.Write(" » ", Color.GhostWhite);
            Config.config.retries = int.Parse(Console.ReadLine());
            File.WriteAllText("config.json", JsonConvert.SerializeObject((object)Config.config));
            Console.WriteLine();
            Console.Write(" [", Color.MidnightBlue);
            Console.Write("+", Color.GhostWhite);
            Console.WriteLine("] Config Saved!", Color.MidnightBlue);
            Thread.Sleep(300);
            Program.menu();
            return Config.config;
        }
        public class configObject
        {
            public string uitype { get; set; }
            public int refreshrate { get; set; }
            public int retries { get; set; }
        }
    }
}
