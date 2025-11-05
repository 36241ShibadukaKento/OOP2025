using System.Threading.Tasks;

namespace Section04 {
    internal class Program {
        static async Task Main(string[] args) {
            HttpClient hC = new HttpClient();
            await GetHtmlExample(hC); 
        }
        static async Task GetHtmlExample(HttpClient httpClient) {
            var url = "https://baseball.yahoo.co.jp/mlb/player/2100825/rs";
            var text = await httpClient.GetStringAsync(url);
            Console.WriteLine(text);
        }
    }
}
