using System.Windows.Controls;
using BG_BIM_Interface.ViewModels.Main;


namespace BG_BIM_Interface.UI.Main
{
    /// <summary>
    /// Interaction logic for BgBimInterfaceMain.xaml
    /// </summary>
    public partial class BgBimInterfaceMain : UserControl
    {
        public BgBimInterfaceMain()
        {
            InitializeComponent();
            this.DataContext = new BgBimInterfaceCoreViewModel(GH_SetPanel.Content.ToString(),
                                                               GH_SetToggle.Content.ToString(),
                                                               GH_SetNumber.Content.ToString());
        }
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }        
    }
}
