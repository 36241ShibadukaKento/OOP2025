
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            Console.WriteLine("(2)");
            var book = Library.Books.MaxBy(b => b.Price);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            Console.WriteLine("(3)");
            var selected = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(x => new {
                    year = x.Key,
                    count = x.Count()
                });
            foreach (var book in selected) {
                Console.WriteLine($"{book.year}年 : {book.count}");
            }

        }

        private static void Exercise1_4() {
            Console.WriteLine("(4)");
            var books = Library.Books
                .OrderByDescending(b => b.PublishedYear)
                .ThenByDescending(b => b.Price)
                .ThenByDescending(b => b.Title);
            foreach (var book in books) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title}");
            }
        }

        private static void Exercise1_5() {
            Console.WriteLine("(5)");
            var books = Library.Books
                .Where(b => b.PublishedYear == 2022)
                .Join(Library.Categories
                , Book => Book.CategoryId
                , Category => Category.Id
                , (book, Category) => Category.Name).Distinct();
            foreach (var name in books) {
                Console.WriteLine(name);
            }

        }

        private static void Exercise1_6() {
            Console.WriteLine("(6)");
            var groups = Library.Categories
                .OrderBy(n => n.Name)
                .GroupJoin(Library.Books
                   , c => c.Id
                   , b => b.CategoryId
                   , (c, books) => new {
                       Category = c.Name
                       ,
                       Books = books
                   });
            foreach (var group in groups) {
                Console.WriteLine($"# {group.Category}");
                foreach (var book in group.Books) {
                    Console.WriteLine($"  {book.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            Console.WriteLine("(7)");
            var groups = Library.Categories
                .Where(x => x.Name == "Development")
                .Join(Library.Books
                   , c => c.Id
                   , b => b.CategoryId
                   , (c, b) => new {
                       b.Title
                      ,
                       b.PublishedYear
                   })
                .GroupBy(x => x.PublishedYear)
                .OrderBy(x => x.Key);
            foreach (var year in groups) {
                Console.WriteLine($"# {year.Key}");
                foreach (var book in year) {
                    Console.WriteLine($"  {book.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            Console.WriteLine("(8)");
            var Categories = Library.Categories
               .GroupJoin(Library.Books
               , c => c.Id
               , b => b.CategoryId
               , (c, books) => new {
                   Category = c.Name,
                   count = books.Count()
               })
               .Where(x=>x.count >=4)
               .Select(x=>x.Category);          
            foreach (var name in Categories) {
                Console.WriteLine($"{name}");
            }
        }
    }
}
