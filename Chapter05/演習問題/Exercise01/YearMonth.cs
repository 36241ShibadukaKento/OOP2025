using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public class YearMonth {
        //5.1.1
        public int Year { get; init; }
        public int Month { get; init; }
        public  YearMonth(int y ,int m) {
             Year = y;
             Month = m;
        }
        //5.1.2
        public bool Is21Century {
            get{
                return 2000 < Year && Year < 2100;
            }
        }
    }
}
