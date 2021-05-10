using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BG_BIM_Interface.MVVM;

namespace BG_BIM_Interface.ViewModels.Main
{
    public class BgBimInterfaceCoreViewModel : BaseViewModel
    {     
        public static BgBimInterfaceCoreViewModel Instance;
        public BgBimInterfaceCoreViewModel()
        {            
            Instance = this;
        }
    }
}
