﻿using System;
using System.Windows.Input;
using BG_BIM_Interface.MVVM;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;

namespace BG_BIM_Interface.ViewModels.Main
{
    public class BgBimInterfaceCoreViewModel : BaseViewModel
    {
        private readonly GH_Document GH_doc;
        private Guid _panelGuid;
        private GH_Panel _panel;
        private string _panelName;
        private string _userText;
        public static BgBimInterfaceCoreViewModel Instance;
        public bool test { get; set; }

        public ICommand SetPanelCommand { get; set; }
        public string PanelName
        {
            get { return _panelName; }
            set
            {
                this._panelName = value;
                this.RaisePropertyChanged(nameof(this.PanelName));
            }
        }

        public string UserText
        {
            get { return _userText; }
            set
            {
                this._userText = value;
                this.RaisePropertyChanged(nameof(this.UserText));
            }
        }
        public GH_Panel Panel
        {
            get { return _panel; }
            set
            {
                this._panel = value;
                this.RaisePropertyChanged(nameof(this.Panel));
            }
        }
        
        public BgBimInterfaceCoreViewModel(string name)
        {            
            Instance = this;
            GH_doc = Grasshopper.Instances.ActiveCanvas.Document;
            //GH_doc.AssociateWithRhinoDocument();
            this._panelName = name;
            GetPanel();
            this._userText = "Default";
            this.test = false;
            SetPanelCommand = new RelayCommand(this.SetPanel);
        }

        public void GetPanel()
        {
            foreach (IGH_DocumentObject obj in GH_doc.Objects)
            {
                if (obj.GetType().ToString() == "Grasshopper.Kernel.Special.GH_Panel")
                {
                    GH_Panel _panel_tmp = obj as GH_Panel;
                    if (_panel_tmp.NickName == this._panelName)
                    {
                        _panelGuid = _panel_tmp.ComponentGuid;
                        this._panel = _panel_tmp;
                    }
                }
            }
        }
        public void SetPanel()
        {            
            this.test = true;
            
            this._panel.UserText = this._userText;
            this._panel.ExpireSolution(true);           
        }
    }
}
