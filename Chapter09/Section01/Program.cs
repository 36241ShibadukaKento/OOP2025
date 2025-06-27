using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            //var today = new DateTime(2025,7,12);     //日付
            //var now = DateTime.Now;  //日付と時刻

            //Console.WriteLine($"Today:{ today.Month }");
            //Console.WriteLine($"Now:{ now }");


            //自分の生まれた生年月日の曜日を求める
            Console.WriteLine("生年月日を入力");
            Console.Write("西暦:");
            string? year = Console.ReadLine();
            Console.Write("月:");
            string? month = Console.ReadLine();
            Console.Write("日:");
            string? day = Console.ReadLine();
            var birthday = DateTime.Parse(year + "," + month+ "," + day);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
     

            var str = birthday.ToString("ggyy年M月d日", culture);
            var dayofweek = culture.DateTimeFormat.GetDayName(birthday.DayOfWeek);

            Console.WriteLine(str + dayofweek);
            Console.WriteLine();

            //生まれてからの日数を求める
            TimeSpan diff = DateTime.Today - birthday;
            Console.WriteLine($"生まれてから{diff.TotalDays}日です");

            //年齢を求める
            int age = GetAge(birthday, DateTime.Today);
            Console.WriteLine();
    
            //1月1日からの経過日数
            TimeSpan diff1st = birthday - DateTime.Today;
            Console.WriteLine($"1月1日から{diff1st.TotalDays}日経過");
            Console.WriteLine();

            //うるう年の判定
            //西暦の入力
            var seireki = Console.Read();
            var LeapYear = DateTime.IsLeapYear(seireki);
            if (LeapYear) {
                Console.WriteLine("うるう年です");
            } else {
                Console.WriteLine("うるう年ではありません");
            }

            static int GetAge (DateTime birthday ,DateTime targetDay) {
                var age = targetDay.Year - birthday.Year;
                
                return age;
            }
        }
    }
}