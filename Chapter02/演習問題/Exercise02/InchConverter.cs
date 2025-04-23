using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class InchConverter {
        public static double InchToMeter(double inch) {
            return inch * 0.0254;
        }
        public static double MeterToInch(double meter) {
            return meter / 0.0254;
        }
    }
}
