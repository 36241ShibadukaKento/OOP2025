
using System.Diagnostics.Tracing;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> names) {
            Console.Write("都市名を入力 : ");
            while (true) {
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) {
                    Console.WriteLine("終了");
                    break;
                } else {
                    var index = names.FindIndex(i => i == name);
                    Console.WriteLine(index);
                }
            }
        }

        private static void Exercise2_2(List<string> names) {
            string word = "o";
            int countWord = names.Count(i => i.Contains(word));
            Console.WriteLine(countWord);
        }

        private static void Exercise2_3(List<string> names) {
            string word = "o";
            var includeWord = names.Where(i => i.Contains(word)).ToArray();
            foreach (var cnt in includeWord) {
                Console.WriteLine(cnt);
            }
        }

        private static void Exercise2_4(List<string> names) {
            string word = "B";
            var obj = names.Where(i => i.StartsWith(word))
               .Select(s => new { s, s.Length });
            foreach (var cnt in obj) {
                Console.WriteLine(cnt.s + ":" + cnt.Length);
            }
        }
    }
}
