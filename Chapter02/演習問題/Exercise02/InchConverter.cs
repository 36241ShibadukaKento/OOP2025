using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class InchConverter {
        //インチ <=> メートル
        private const double ratio = 0.0254;
        public static double InchToMeter(double inch) {
            return inch * ratio;
        }
        public static double MeterToInch(double meter) {
            return meter / ratio;
        }
    }
}
