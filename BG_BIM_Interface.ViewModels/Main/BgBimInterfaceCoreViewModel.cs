using System;
using System.Windows.Input;
using BG_BIM_Interface.MVVM;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;


namespace BG_BIM_Interface.ViewModels.Main
{
    public class BgBimInterfaceCoreViewModel : BaseViewModel
    {
        private readonly GH_Document GH_doc;
        private Guid _panelGuid;
        private GH_Panel _panel;
        private string _panelName;
        private string _userText;
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

        private string _toggleName;
        private GH_BooleanToggle _GH_Toggle;
        private bool _toggle;
        public string ToggleName
        {
            get { return _toggleName; }
            set
            {
                this._toggleName = value;
                this.RaisePropertyChanged(nameof(this.ToggleName));
            }
        }
        public bool Toggle
        {
            get { return _toggle; }
            set
            { 
                _toggle = value;
                RaisePropertyChanged(nameof(this.Toggle));
            }
        }
       

        private string _numberName;
        private Param_Number _GH_NumberParam;
        private double _number;
        public double Number
        {
            get { return this._number; }
            set
            {
                _number = value;
                RaisePropertyChanged(nameof(this.Number));
            }
        }

        public static BgBimInterfaceCoreViewModel Instance;
        public ICommand SetPanelCommand { get; set; }
        public ICommand SetToggleCommand { get; set; }
        public ICommand SetNumberCommand { get; set; }


        public BgBimInterfaceCoreViewModel(string panel_name,string toggle_name,string number_name)
        {            
            Instance = this;
            GH_doc = Grasshopper.Instances.ActiveCanvas.Document;
            //GH_doc.AssociateWithRhinoDocument();
            _panelName = panel_name;
            _toggleName = toggle_name;
            _numberName = number_name;
            GetPanel();
            GetToggle();
            GetNumber();
            SetPanelCommand = new RelayCommand(this.SetPanel);
            SetToggleCommand = new RelayCommand(this.SetToggle);
            SetNumberCommand = new RelayCommand(this.SetNumber);
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
                        _panel = _panel_tmp;
                    }
                }
            }
        }
        public void GetToggle()
        {
            foreach (IGH_DocumentObject obj in GH_doc.Objects)
            {
                if (obj.GetType().ToString() == "Grasshopper.Kernel.Special.GH_BooleanToggle")
                {
                    GH_BooleanToggle _toggle_tmp = obj as GH_BooleanToggle;
                    if (_toggle_tmp.NickName == _toggleName)
                    {
                        _GH_Toggle = _toggle_tmp;
                        _toggle = _GH_Toggle.Value;                        
                    }
                }
            }
        }
        public void GetNumber()
        {
            foreach (IGH_DocumentObject obj in GH_doc.Objects)
            {
                if (obj.GetType().ToString() == "Grasshopper.Kernel.Parameters.Param_Number")
                {
                    Param_Number _numberParam_tmp = obj as Param_Number;
                    if (_numberParam_tmp.NickName == _numberName)
                    {
                        System.Diagnostics.Debug.WriteLine("TEST");
                        _GH_NumberParam = _numberParam_tmp;                        
                    }
                }
            }
        }
        public void SetPanel()
        {                    
            _panel.UserText = this._userText;
            _panel.ExpireSolution(true);           
        }
        public void SetToggle()
        {
            _toggle = !_toggle;
            _GH_Toggle.Value = _toggle;
            _GH_Toggle.ExpireSolution(true);
        }
        public void SetNumber()
        {
            _GH_NumberParam.Access = GH_ParamAccess.item;
            _GH_NumberParam.PersistentData.Clear();
            _GH_NumberParam.SetPersistentData(new GH_Number(_number));
            //numberParam.AddVolatileData(new GH_Path(0), 0, new GH_Number(val));
            _GH_NumberParam.ExpireSolution(true);
        }
    }
}
