using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyChecker
{
    internal class Save
    {
        private static object resultLock = new object();

        public static void AsResult(string module, string fileName, string content)
        {
            lock (Save.resultLock)
                File.AppendAllText("Results/" + module + "/" + Utils.datetime + "/" + fileName + ".txt", content + Environment.NewLine);
        }
    }
}
