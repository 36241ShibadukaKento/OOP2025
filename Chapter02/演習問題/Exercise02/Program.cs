using System.Security.Cryptography.X509Certificates;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            for (int inch = 1; inch <= 10; inch++) {
                double meter = InchConverter.InchToMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");

            }
          
        }
    }
}



