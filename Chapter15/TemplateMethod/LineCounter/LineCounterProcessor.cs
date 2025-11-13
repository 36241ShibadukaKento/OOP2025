using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;
        private string target = "sample";

        protected override void Initialize(string fname) {
            Console.Write("検索する文字 : ");
            target = Console.ReadLine();
            _count = 0;
        }

        protected override void Execute(string line) {
            if (line.Contains(target)) {
                _count++;
            }
        }

        protected override void Terminate() => Console.WriteLine("[{0}]は{1}個", target , _count);
    }
}