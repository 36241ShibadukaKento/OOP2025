using System.Security.Cryptography.X509Certificates;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("***変換アプリ***");
            Console.WriteLine("1 : インチ から メートル");
            Console.WriteLine("2 : メートル から インチ");
            Console.Write(">");
            int rule = int.Parse(Console.ReadLine());

            Console.Write("はじめ : ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("おわり : ");
            int end = int.Parse(Console.ReadLine());
            if (rule == 1) {
                for (int inch = start; inch <= end; inch++) {
                    double meter = InchConverter.InchToMeter(inch);
                    Console.WriteLine($"{inch}inch = {meter:0.0000}m");

                }
            } else if (rule == 2) {
                for (int meter = start; meter <= end; meter++) {
                    double inch = InchConverter.MeterToInch(meter);
                    Console.WriteLine($"{meter}m = {inch:0.0000}inch");

                }
            }
        }
    }
}



