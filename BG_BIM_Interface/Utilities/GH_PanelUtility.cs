using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Special;
using Grasshopper.Kernel.Types;

namespace BG_BIM_Interface.Utilities
{
    public class GH_PanelUtility
    {
        private GH_Document GH_doc;
        private GH_Panel _panel;
        public GH_Panel Panel {
            get{ return _panel; }            
        }
        public GH_PanelUtility()
        {
            GH_doc = Grasshopper.Instances.ActiveCanvas.Document;
        }
        public void Find(string nickName)
        {
            foreach (IGH_DocumentObject obj in GH_doc.Objects)
            {
                
                if (obj.GetType().ToString() == "Grasshopper.Kernel.Special.GH_Panel")
                {
                    GH_Panel panelObj = obj as GH_Panel;
                    if (panelObj.NickName == nickName)
                    {
                        _panel = panelObj;                       
                    }
                }
            }
        }
        public void Set(string txt)
        {
            _panel.UserText = txt;
            _panel.ExpireSolution(true);
        }
        public GH_Structure<GH_String> Get()
        {
            return _panel.VolatileData as GH_Structure<GH_String>;
        }
    }
}
