using static System.Net.Mime.MediaTypeNames;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("text1:");
            var text1 = Console.ReadLine();
            //C://Users//infosys//source//repos//OOP2025//Chapter10//演習問題//Exercise03//text1.txt

            Console.Write("text2:");
            var text2 = File.ReadAllLines(Console.ReadLine());
            //C://Users//infosys//source//repos//OOP2025//Chapter10//演習問題//Exercise03//text2.txt

            using (var writer = new StreamWriter(text1, append: true)) {
                foreach (var line in text2) {
                    writer.WriteLine(line);
                }
            }

        }
    }
}
