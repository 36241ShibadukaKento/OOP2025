namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {

            var sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            Console.WriteLine("計測開始");

            Thread.Sleep(10000);

            sw.Stop();
            Console.WriteLine("計測終了");

            TimeSpan ts = sw.Elapsed;
            Console.WriteLine($"{sw.ElapsedMilliseconds}ミリ秒");



            //var tw = new TimeWatch();


            //tw.Start();
            //// スリープする
            //Thread.Sleep(1000);
            //TimeSpan duration = tw.Stop();
            //Console.WriteLine("処理時間は{0}ミリ秒でした", duration.TotalMilliseconds);

        }
    }

    class TimeWatch {
        private DateTime _time;
        
        public void Start() {
            //現在の時間を_timeに設定
            _time = DateTime.Now;
        }

        public TimeSpan Stop() {
            //経過時間を返却する
            var time = DateTime.Now - _time;

            return time;
        }
    }
}
