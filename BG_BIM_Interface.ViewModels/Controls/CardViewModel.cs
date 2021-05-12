using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BG_BIM_Interface.MVVM;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;


namespace BG_BIM_Interface.ViewModels.Controls
{
    public class CardViewModel: BaseViewModel
    {
        private readonly GH_Document GH_doc;
        public GH_Panel Panel { get; set; }
        public string PanelName { get; set; }
        public string UserText { get; set; }

        ICommand SetPanelCommand { get; set; }

        public CardViewModel(string name)
        {
            GH_doc = Grasshopper.Instances.ActiveCanvas.Document;
            //GH_doc.AssociateWithRhinoDocument();
            this.PanelName = name;
            GetPanel();
            UserText = "Default";
            SetPanelCommand = new RelayCommand(this.SetPanel);
        }       
        public void GetPanel()
        {
            foreach(IGH_DocumentObject obj in GH_doc.Objects)
            {
                if (obj.GetType().ToString() == "Grasshopper.Kernel.Special.GH_Panel")
                {
                    GH_Panel _panel = obj as GH_Panel;
                    if (_panel.NickName == PanelName)
                    {
                        Panel = _panel;
                    }
                }
            }
        }
        public void SetPanel()
        {
            Panel.UserText = this.UserText;
            Panel.ExpireSolution(true);
        }
    }
}
