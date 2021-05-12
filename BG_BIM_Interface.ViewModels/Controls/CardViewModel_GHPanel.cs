using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG_BIM_Interface.MVVM;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;

namespace BG_BIM_Interface.ViewModels.Controls
{
    public class CardViewModel_GHPanel : BaseViewModel
    {
        private readonly GH_Document doc;
        public string PanelName { get; set; }
        public GH_Panel Panel { get; set; }
        public string Content { get; set; }

        public CardViewModel_GHPanel()
        {            
        }
        private void GetPanel()
        {
            foreach (IGH_DocumentObject obj in doc.Objects)
            {
                if (obj.GetType().ToString() == "Grasshopper.Kernel.Special.GH_Panel")
                {
                    GH_Panel gh_panel = obj as GH_Panel;
                    if (gh_panel.NickName == PanelName)
                    {
                        Panel = gh_panel;
                    }
                }
            }
        }
        public void SetString(string str)
        {
            Panel.UserText = Content;
            Panel.ExpireSolution(true);
        }
        public void GetString()
        {
            Content = Panel.UserText;
        }
    }
}
