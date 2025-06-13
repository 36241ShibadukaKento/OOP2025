
using System.Runtime.Intrinsics.X86;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var strDict = new Dictionary<char, int>();

            foreach (var i in text.ToUpper()) {
                if ('A' <= i && i <= 'Z') {
                    if (strDict.ContainsKey(i)) {
                        strDict[i]++; 
                    } else {
                        strDict[i] = 1; 
                    }
                }
            }
            foreach (var i in strDict.OrderBy(s => s.Key)) {
                Console.WriteLine(i.Key + " : " + i.Value);
            }
        }

        private static void Exercise2(string text) {
            var strDict = new SortedDictionary<char, int>();

            foreach (var i in text.ToUpper()) {
                if ('A' <= i && i <= 'Z') {
                    if (strDict.ContainsKey(i)) {
                        strDict[i]++;
                    } else {
                        strDict[i] = 1;
                    }
                }
            }
            foreach (var (key, Value) in strDict) {
                Console.WriteLine(key + " : " + Value);
            }
        }
    }
}
