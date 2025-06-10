using Exercise01;

namespace Exercise02 {
    public class Program {
        static void Main(string[] args) {
            // 5.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2000, 9),
                new YearMonth(2000, 12),
            };

            Console.WriteLine("5.2.2");
            Exercise2(ymCollection);

            Console.WriteLine("5.2.4");
            Exercise4(ymCollection);


            Console.WriteLine("5.2.5");
            Exercise5(ymCollection);
        }

        private static void Exercise2(YearMonth[] ymCollection) {
            foreach (var i in ymCollection) {
                Console.WriteLine(i);
            }
        }
        
        //5.2.3
        public static YearMonth? FindFirst21C(YearMonth[] ymCollection) {
            foreach (var i in ymCollection) {
                if(i.Is21Century ) {
                    return i ;
                }   
            }
            return null;

        }

        private static void Exercise4(YearMonth[] ymCollection) {
            if(FindFirst21C(ymCollection) == null) {
                Console.WriteLine("21世紀のデータはありません");
            } else {
                Console.WriteLine(FindFirst21C(ymCollection).Year);
            }
        }

        private static void Exercise5(YearMonth[] ymCollection) {
            var nexYearManth = ymCollection.Select(s=>s.AddOneMonth());
            foreach (var i in nexYearManth) {
                Console.WriteLine(i);
            }
        }
    }
}
