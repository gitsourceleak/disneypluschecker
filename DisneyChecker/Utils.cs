using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyChecker
{
    internal class Utils
    {
        public static List<Func<string[], string, bool>> pickedModules = new List<Func<string[], string, bool>>();
        public static string Module = "";
        public static string options = "";
        public static int globalThreads = -1;
        public static int globalRetries = -1;
        public static string proxyProtocol = "";
        public static int hits = 0;
        public static int frees = 0;
        public static int errors = 0;
        public static int cpm = 0;
        public static int checks = 0;
        public static int twofa = 0;
        public static int retries = 0;
        public static IEnumerable<string> combos;
        public static int comboTotal = 0;
        public static IEnumerable<string> proxies;
        public static int proxiesCount = 0;
        public static int comboIndex = 0;
        public static int Modules = 0;
        public static string p1 = "";
        public static string pa = "";
        public static string datetime;
        private static Random random = new Random();

        public static string UUIDGen() => Utils.RandomString(8) + "-" + Utils.RandomString(4) + "-4" + Utils.RandomString(3) + "-" + Utils.RandomString(4) + "-" + Utils.RandomString(12);

        public static string RandomString(int length) => new string(Enumerable.Repeat<string>("abcdefhijklmnopqrstuvwxyz0123456789", length).Select<string, char>((Func<string, char>)(s => s[Utils.random.Next(s.Length)])).ToArray<char>());

        public static string RandomDigit(int length) => new string(Enumerable.Repeat<string>("0123456789", length).Select<string, char>((Func<string, char>)(s => s[Utils.random.Next(s.Length)])).ToArray<char>());

        public static string RandomChar(int length) => new string(Enumerable.Repeat<string>("abcdefhijklmnopqrstuvwxyz", length).Select<string, char>((Func<string, char>)(s => s[Utils.random.Next(s.Length)])).ToArray<char>());

        public static string Base64Encode(string plainText) => Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

        public static string Parse(string source, string left, string right) => source.Split(new string[1]
        {
      left
        }, StringSplitOptions.None)[1].Split(new string[1]
        {
      right
        }, StringSplitOptions.None)[0];
    }
}
