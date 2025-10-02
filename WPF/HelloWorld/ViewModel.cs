using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class ViewModel : BindableBase
    {
        public ViewModel() {
            ChangeMassageCommand = new DelegateCommand(
                ()=> GreetingMassage = "Bye-Bye World"
                );
        }

        private string _greetingMassage = "Hello World!";
        public string GreetingMassage {
            get => _greetingMassage;
            set => SetProperty(ref _greetingMassage, value);
        }

        public DelegateCommand ChangeMassageCommand { get; }


    }
}
