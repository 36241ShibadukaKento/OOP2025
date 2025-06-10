using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth(int y, int m) {
        //5.1.1
        //プライマリーコンストラクタ
        public int Year { get; init; } = y;
        public int Month { get; init; } = m;

        //5.1.2
        public bool Is21Century => 2000 < Year && Year <= 2100;

        //5.1.3
        public YearMonth AddOneMonth() {
            if(Month == 12) {
                return new YearMonth(Year + 1 , 1);
            } else {
                return new YearMonth(Year, Month + 1);
            }
        }
        //5.1.4
        public override string ToString() => $"<< { Year }年 { Month }月 >>";
    }
}
