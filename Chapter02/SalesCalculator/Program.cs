using System.Globalization;

namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            SalesCounter sales = new SalesCounter(@"data\sales.csv");
            Dictionary<string, int> amountsPerStre = sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStre) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }
    }
}
