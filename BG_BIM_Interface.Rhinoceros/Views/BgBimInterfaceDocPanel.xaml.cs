using System.Windows.Controls;
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
            InitializeComponent();
            Instance = this;
        }       
    }
}
