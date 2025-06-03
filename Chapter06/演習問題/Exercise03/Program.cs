
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



        }

        private static void Exercise1(string text) {
            // Console.WriteLine("空白数:" + text.Count(Char.IsWhiteSpace));
            Console.WriteLine("空白数:" + text.Count(s => s == ' '));
        }

        private static void Exercise2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3(string text) {         // やらなくていい
            string[] array = text.Split(' ');
             var sb =new StringBuilder();
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
    }
}
