
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SamoleUnitConverter
{
     internal class MainWindowViewModel : BindableBase
    {
        //フィールド
        private double metricValue;
        private double imperialValue;

        //▲で呼ばれるコマンド
        public DelegateCommand ImperialUnitToMetric { get; private set; }
        //▼で呼ばれるコマンド
        public DelegateCommand MetricToImperialUnit { get; private set; }

        //上のコンボボックスで選択されている値を保存
        public MetricUnit CurrentMetricUnit { get; set; }
        //下のコンボボックスで選択されている値を保存
        public ImperialUnit CurrentImperialUnit { get; set; }

        //プロパティ
        public double MetricValue {
  
            get => metricValue;
            set => SetProperty(ref metricValue, value);
        
        }
        public double ImperialValue {
            get => imperialValue;
            set => SetProperty(ref imperialValue, value);
        }

        public MainWindowViewModel() {
            CurrentImperialUnit = ImperialUnit.Units.First();
            CurrentMetricUnit = MetricUnit.Units.First();

            ImperialUnitToMetric = new DelegateCommand(
                () =>MetricValue = 
                CurrentMetricUnit.FromImperialUnit(CurrentImperialUnit,ImperialValue));
            MetricToImperialUnit = new DelegateCommand(
                () => ImperialValue = 
                CurrentImperialUnit.FromMetricUnit(CurrentMetricUnit, metricValue));
        }
    }
}
