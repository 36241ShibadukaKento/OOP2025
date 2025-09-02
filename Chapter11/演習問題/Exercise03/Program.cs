using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            string[] texts = [
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            ];
            foreach(var line in texts){
                var match = Regex.Matches(line, @"\btime\b", RegexOptions.IgnoreCase);
                foreach (Match item in match) {
                    Console.WriteLine($"{line},{item.Index}");
                }
            }
        }
    }
}
