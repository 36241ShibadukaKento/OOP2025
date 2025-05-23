
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
            Console.WriteLine();

            for (int cnt = 0; cnt < includeS.Count; cnt++) {
                Console.WriteLine(includeS[cnt]);
            }
            Console.WriteLine();

            int whileCnt = 0;
            while (whileCnt < includeS.Count) {
                Console.WriteLine(includeS[whileCnt]);
                whileCnt++;
            }
        }


        private static void Exercise2(List<string> langs) {
            foreach (var cnt in langs) {
                if (cnt.Contains("S"))
                    Console.WriteLine(cnt);
            }
            Console.WriteLine();
        }


        private static void Exercise3(List<string> langs) {
            //2行で完成させる
            Console.WriteLine(langs.Find(s => s.Length == 10) ?? ("unknown"));
        }
    }
}
