
using System.Runtime.InteropServices;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            var includeS = langs.Where(i => i.Contains("S")).ToList();
            foreach (var cnt in includeS) {
                Console.WriteLine(cnt);
            }

            for (int cnt = 0; cnt < includeS.Count; cnt++) {
                Console.WriteLine(includeS[cnt]);
            }

            int whileCnt = 0;
            while (true) {
                Console.WriteLine(includeS[whileCnt]);
                whileCnt++;
                if (whileCnt >= includeS.Count) {
                    break;
                }
            }
        }

        private static void Exercise2(List<string> langs) {

        }

        private static void Exercise3(List<string> langs) {

        }
    }
}
