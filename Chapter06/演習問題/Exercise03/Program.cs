
using System.Globalization;
using System.Security.Authentication;
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);

        }

        private static void Exercise1(string text) {
            // Console.WriteLine("空白数:" + text.Count(Char.IsWhiteSpace));
            Console.WriteLine("空白数:" + text.Count(s => s == ' '));
        }

        private static void Exercise2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3(string text) {
            string[] array = text.Split(' ');
            var sb = new StringBuilder();
            foreach (var i in array) {
                sb.Append(i + " ");
            }
            var ReText = sb.ToString().TrimEnd();

            Console.WriteLine(ReText + ".");
        }

        private static void Exercise4(string text) {
            string[] words = text.Split(' ');
            Console.WriteLine("単語数:" + words.Length);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var i in words) {
                Console.WriteLine(i);

            }
        }

        private static void Exercise6(string text) {

            var str = text.ToLower().Replace(" ","");
            for (char C = 'a';  C <= 'z'; C++) {
                Console.WriteLine(C + " : " + str.Count(c => c == C));
            }
            
            /*  配列を使ったやり方 
            var array = Enumerable.Repeat(0, 26).ToArray();
            foreach (var alph in str) {
                array[alph - 'a']++;
            }
            for (char ch = 'a'; ch < 'z'; ch++) {
                Console.WriteLine($"{ch}:{ array[ch -'a']}");
            }


                辞書を使ったやり方
            var alphDicCount = Enumerable.Range('a', 26).ToDictionary(num =>((char)num).ToString() ,num => 0 );
            //foreach (var alph in str) {
            //    alphDicCount[alph.ToString()]++; 
            //}
            //foreach (var item in alphDicCount) {
            //    Console.WriteLine($"{item.Key} : {item.Value}");
            }                          */

        }
    }
}

