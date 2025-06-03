using System.Text;

namespace Section03 {
    internal class Program {
        static void Main(string[] args) {
            //stringBuilder を使用
            var sb =new StringBuilder();
            foreach (var word in GetWords()) {
                sb.Append(word);
            }
            var text = sb.ToString();
            Console.WriteLine(text);

            //文字列連結
            string str = "";
            foreach (var word in GetWords()) {
                str += word;
            }
            Console.WriteLine(str);
        }

        private static IEnumerable<object> GetWords() {
            return ["Orange", "Lemon", "Apple"];
        }
    }
}
