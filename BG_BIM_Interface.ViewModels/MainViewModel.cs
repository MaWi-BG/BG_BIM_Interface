using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BG_BIM_Interface.MVVM;

namespace BG_BIM_Interface.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string MyText;
        private int _counter;
        public int Counter
        {
            get { return _counter; }
            set
            {
                this._counter = value;
                this.RaisePropertyChanged(nameof(this.Counter));
            }
        }
        public ICommand CountUpCommand { get; set; }
        public MainViewModel()
        {
            this.Counter = 0;
            this.CountUpCommand = new RelayCommand(this.CountUp);
        }
        public void CountUp()
        {
            this.Counter++;
        }
    }
}
