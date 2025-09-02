using System.Text.RegularExpressions;

namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var strings = new[] {
                "Microsoft Windows",
                "windows",
                "Windows Server",
                "Windows"
            };

            var regex = new Regex(@"^(W|w)indows$");
            
            //一致した文字列の個数をカウント
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine($"{count}行と一致");

            //一致した文字列を出力
            foreach (var item in strings) {
               if(regex.IsMatch(item))
                Console.WriteLine(item);
            }
        }
    }
}
