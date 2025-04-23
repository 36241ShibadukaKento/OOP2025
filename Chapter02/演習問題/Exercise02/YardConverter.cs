using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class YardConverter {
        //ヤード <=> メートル
        private const double ratio = 0.9144;
        public static double MeterToYard(double meter) {
            return meter * ratio;
        }
        public static double YardToMeter(double yard) {
            return yard / ratio;
        }
    }
}
