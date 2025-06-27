using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplyDatePattern1(dateTime);
            DisplyDatePattern2(dateTime);
            DisplyDatePattern3(dateTime);


        }

        private static void DisplyDatePattern1(DateTime dateTime) {
            // 2024/03/09 19:03
            // string.Format
            var format =  string.Format($"{dateTime:yyyy/MM/dd HH:mm}");
            Console.WriteLine(format);
        }

        private static void DisplyDatePattern2(DateTime dateTime) {
            // 2024年03月09日 19時03分09秒
            // DateTime.ToString を使った例
            var format1 = dateTime.ToString($"{dateTime:yyyy年MM月dd日 HH時mm分ss秒}");
            Console.WriteLine(format1);
        }

        private static void DisplyDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            var format2 = dateTime.ToString("ggy", culture);
            Console.WriteLine($"{format2}年{dateTime.Month,2}月{dateTime.Day,2}日 {dateTime.Hour,2}時 {dateTime.Minute,2}分({dayOfWeek})");

            var format3 = dateTime.ToString("gg", culture);
            var year = int.Parse(dateTime.ToString("yy", culture));

            

        }
    }
}
