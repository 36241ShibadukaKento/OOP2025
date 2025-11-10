using System.Reflection.PortableExecutable;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "C://Users//infosys//source//repos//OOP2025//Chapter10//演習問題//Exercise01//source.txt";
            using (StreamReader reader = new StreamReader(text)) {
                var cnt = 0;
                var target = "class";
                while(!reader.EndOfStream){
                    var line = reader.ReadLine() ;
                    List<string> wards = line.Split(' ').ToList();
                    foreach (var i in wards) {
                        if (i == target) {
                            cnt++;
                        }
                    }
                }
                Console.WriteLine(cnt);
            }
        }
    }
}
