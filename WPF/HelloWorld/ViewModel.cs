using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel() {
            ChangeMassageCommand = new DelegateCommand(
                ()=> GreetingMassage = "Bye-Bye World"
                );
        }

        private string _greetingMassage = "Hello World!";
        public string GreetingMassage {
            get => _greetingMassage;
            set {
                if (_greetingMassage != value) {
                    _greetingMassage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GreetingMassage)));
                }
            }
        }

        public DelegateCommand ChangeMassageCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
