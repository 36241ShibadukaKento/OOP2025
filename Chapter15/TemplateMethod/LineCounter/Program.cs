using TextFileProcessor;
namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            //コメントが異なっていたため念のため再提出（templateMethod指定したパスの読み込み完成）
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
