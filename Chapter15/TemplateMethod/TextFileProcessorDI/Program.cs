namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            var service = new LineToHalfNumberService();
            var prcessor = new TextFileProcessor(service);
            Console.Write("パスの入力 : ");

            prcessor.Run(Console.ReadLine());
        }
    }
}
//<実行用> このファイルのパス C:\Users\infosys\source\repos\OOP2025\Chapter15\TemplateMethod\TextFileProcessorDI\Program.cs
// 13行 １ ２ ３ >>もとは全角 
// 14行 1 2 3 >>もとは半角
// 15行
// 16行
// 17行
// 18行
// 19行
// 20行
// 21行