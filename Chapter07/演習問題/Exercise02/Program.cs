
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
                new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
                new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
                new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
                new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
                new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
                new Book { Title = "私でも分かったASP.NET Core", Price = 3200, Pages = 453 },
                new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            #region
            Console.WriteLine("7.2.1");
            Exercise1(books);

            Console.WriteLine("7.2.2");
            Exercise2(books);

            Console.WriteLine("7.2.3");
            Exercise3(books);

            Console.WriteLine("7.2.4");
            Exercise4(books);

            Console.WriteLine("7.2.5");
            Exercise5(books);

            Console.WriteLine("7.2.6");
            Exercise6(books);

            Console.WriteLine("7.2.7");
            Exercise7(books);
        }
        #endregion 
        private static void Exercise1(List<Book> books) {
            var book = books.FirstOrDefault(s => s.Title == "ワンダフル・C#ライフ");
            if (book is not null) {
                Console.WriteLine("{0} {1}", book.Price, book.Pages);
            }
        }

        private static void Exercise2(List<Book> books) {
            Console.WriteLine((int)books.Count(s => s.Title.Contains("C#")));
        }

        private static void Exercise3(List<Book> books) {
            Console.WriteLine((int)books.Where(s => s.Title.Contains("C#")).Average(s => s.Pages));
        }

        private static void Exercise4(List<Book> books) {
            var over4000yen = books.FirstOrDefault(s => s.Price >= 4000);
            Console.WriteLine(over4000yen?.Title);
        }

        private static void Exercise5(List<Book> books) {
            var under4000yen = books.Where(s => 4000 >= s.Price).MaxBy(s => s.Pages);
            Console.WriteLine(under4000yen?.Pages);
        }

        private static void Exercise6(List<Book> books) {
            var descPriceOver400p = books.Where(s => s.Pages >= 400).OrderByDescending(s => s.Price);
            foreach (var i in descPriceOver400p) {
                Console.WriteLine(i.Title + " : " + i.Price);
            }
        }

        private static void Exercise7(List<Book> books) {
            var containWardUnder500p = books.Where(s => s.Pages <= 500 && s.Title.Contains("C#"));
            foreach (var i in containWardUnder500p) {
                Console.WriteLine(i.Title);
            }
        }
    }
}