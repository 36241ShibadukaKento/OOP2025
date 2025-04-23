using System.Security.Cryptography.X509Certificates;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("***変換アプリ***");
            Console.WriteLine("1 : ヤード から メートル");
            Console.WriteLine("2 : メートル から ヤード");

            Console.Write(">");
            int rule = int.Parse(Console.ReadLine());

            if (rule == 1) {
                Console.Write("変換前 ( ヤード ) : ");
                double num = double.Parse(Console.ReadLine());
                double meter = YardConverter.YardToMeter(num);
                Console.WriteLine($"変換後 ( メートル ) : {meter:0.0000}");

            } else if (rule == 2) {
                Console.Write("変換前 ( メートル ) : ");
                double num = double.Parse(Console.ReadLine());
                double yard = YardConverter.MeterToYard(num);
                Console.WriteLine($"変換後( ヤード ) : {yard:0.0000}");

            }
        }
    }
}



