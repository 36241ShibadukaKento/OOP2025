using System.Globalization;

namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"data\sales.csv");
            var amountsPerStre = sales.GetPerStoreSales();
            foreach (var obj in amountsPerStre) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }
    }
}
