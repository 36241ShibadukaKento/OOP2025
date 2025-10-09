using SampleUnitConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SamoleUnitConverter
{
     internal class MainWindowViewModel : ViewModel
    {
        //フィールド
        private double metricValue;
        private double imperialValue;

        //▲で呼ばれるコマンド
        public ICommand ImperialUnitToMetric { get; private set; }
        //▼で呼ばれるコマンド
        public ICommand MetricToImperialUnit { get; private set; }

        //上のコンボボックスで選択されている値を保存
        public MetricUnit CurrentMetricUnit { get; set; }
        //下のコンボボックスで選択されている値を保存
        public ImperialUnit CurrentImperialUnit { get; set; }

        //プロパティ
        public double MetricValue {
            get => metricValue; 
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }
        public double ImperialValue {
            get => imperialValue;
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }
        }

        public MainWindowViewModel() {
            ImperialUnitToMetric = new DelegateCommand(
                () =>MetricValue = 
                CurrentMetricUnit.FromImperialUnit(CurrentImperialUnit,ImperialValue));
            MetricToImperialUnit = new DelegateCommand(
                () => ImperialValue = 
                CurrentImperialUnit.FromMetricUnit(CurrentMetricUnit, metricValue));
        }
    }
}
