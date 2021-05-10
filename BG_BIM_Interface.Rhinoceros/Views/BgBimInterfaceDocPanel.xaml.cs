using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BG_BIM_Interface.Rhinoceros.ViewModels;

namespace BG_BIM_Interface.Rhinoceros.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class BgBimInterfaceDocPanel : UserControl
    {
        public static BgBimInterfaceDocPanel Instance;
        public BgBimInterfaceDocPanel(uint documentSerialNumber)
        {
            DataContext = new BgBimInterfaceDocPanelViewModel(documentSerialNumber);
            //InitializeComponent();
            Instance = this;
        }       
    }
}
