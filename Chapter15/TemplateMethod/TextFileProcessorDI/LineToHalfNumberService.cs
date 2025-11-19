using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    internal class LineToHalfNumberService : ITextFileService {

        public void Initialize(string fname) {
        }

        public void Excute(string line) {
            var sb = new StringBuilder();
            foreach (char c in line) {
                if (c >= '０' && c <= '９') {
                    sb.Append((char)(c - 65248));
                } else {
                    sb.Append(c);
                }
            }
            Console.WriteLine(sb.ToString());
        }

        public void Terminate() {
        }
    }
}
