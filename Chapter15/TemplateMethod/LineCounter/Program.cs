using TextFileProcessor;
namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("ファイルのパスを入力 : ");
            var filePath = Console.ReadLine();

            try {
                TextProcessor.Run<LineCounterProcessor>(filePath);

            }

            catch (Exception) {
                Console.WriteLine("パスが不正です");
            }
        }
    }
}
