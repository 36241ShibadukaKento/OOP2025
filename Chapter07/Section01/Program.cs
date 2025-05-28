using System.Data.SqlTypes;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //本の平均金額を表示
            Console.WriteLine("平均金額");
            Console.WriteLine((int)books.Average(b=> b.Price));
            Console.WriteLine("-----------");

            //本のページ合計を表示
            Console.WriteLine("ページ合計");
            Console.WriteLine(books.Sum(b=>b.Pages));
            Console.WriteLine("-----------");

            //金額の安い書籍名と金額を表示
            Console.WriteLine("金額の安い書籍名と金額");
            foreach (var i in books.Where(s => s.Price == books.Min(b => b.Price))) {
                Console.WriteLine(i.Title + " : " + i.Price);

            }

            //自力でやった時のやり方（昇順に並べて先頭を出力）
            //var min = books.OrderBy(b => b.Price).ToList();
            //Console.Write(min[0].Title + " " + min[0].Price);

            Console.WriteLine("-----------");


            //ページ数が多い書籍名とページ数を表示
            Console.WriteLine("ページ数が多い書籍名とページ数");
            foreach (var i in books.Where(s => s.Pages == books.Max(b => b.Pages))) {
                Console.WriteLine(i.Title + " : " + i.Pages);

            }
            Console.WriteLine("-----------");

            //タイトルに「物語」が含まれている書籍名を表示
            Console.WriteLine("タイトルに「物語」が含まれている書籍名");
            foreach(var i in books.Where(b=>b.Title.Contains("物語"))) {
                Console.WriteLine(i.Title);
            }
            Console.WriteLine("-----------");
        }
    }
}
