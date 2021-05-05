using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG_BIM_Interface.UI;

namespace BG_BIM_Interface.Desktop
{
    class Programm
    {
        [STAThread]
        static void Main(string[] args)
        {
            var MainWindow = new MainView();
            MainWindow.ShowDialog();
        }
    }
}
