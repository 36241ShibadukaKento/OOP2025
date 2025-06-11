
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

            foreach (var i in text.ToUpper().OrderBy(s => s)) {
                if ('A' <= i && i <= 'Z') {
                    if (strDict.ContainsKey(i)) {
                        strDict[i]++; //同じ文字が出現した場合
                    } else {
                        strDict[i] = 1; //新しい文字が出現した場合
                    }
                }
            }
            foreach (var i in strDict) {
                Console.WriteLine(i);
            }
        }

        private static void Exercise2(string text) {
        }
    }
}
