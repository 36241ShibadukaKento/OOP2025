using System.Globalization;

namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            SalesCounter sales = new SalesCounter(ReadSales(@"data\sales.csv"));
            Dictionary<string,int> amountsPerStre = sales.GetPerStoreSales();
            foreach(KeyValuePair<string,int> obj in amountsPerStre) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }

        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        static List<Sale>ReadSales (string fileRath) {
            //売り上げデータを入れるリストオブジェクトを生成
            List<Sale> sales = new List<Sale>();
            //ファイルを一気に読み込み
            string[] lines = File.ReadAllLines(fileRath);
            //読み込んだ行数分繰り返し
            foreach(var line in lines) {
                String[] items = line.Split(',');
                //Saleオブジェクトを生成
                Sale sale = new Sale() {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };
                sales.Add(sale);
            }
            return sales;

        }
    }
}
