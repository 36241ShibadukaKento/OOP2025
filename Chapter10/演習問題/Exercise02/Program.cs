using static System.Net.Mime.MediaTypeNames;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var text = "C://Users//infosys//source//repos//OOP2025//Chapter10//演習問題//Exercise02//selfIntroduction.txt";
            var newFilePath = "C://Users//infosys//source//repos//OOP2025//Chapter10//演習問題//Exercise02//newfile.txt";
            using (StreamReader reader = new StreamReader(text)) {
                var lines = File.ReadLines(text).Select((s, ix) => $"{ix + 1,4}:{s}");
                foreach (var line in lines) {
                    Console.WriteLine(line);
                }
                File.WriteAllLines(newFilePath, lines);
            }
        }
    }
}
