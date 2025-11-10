using System.Reflection.PortableExecutable;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "C://Users//infosys//source//repos//OOP2025//Chapter10//演習問題//Exercise01//source.txt";
            var target = " class ";
            using (StreamReader reader = new StreamReader(text)) {
                var count = File.ReadAllLines(text).Count(s => s.Contains(target));
                Console.WriteLine(count);
            }
        }
    }
}
