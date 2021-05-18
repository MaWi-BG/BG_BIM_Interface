using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;
using BG_BIM_Interface.Rhinoceros.Views;
using BG_BIM_Interface.ViewModels.Main;
using System.Runtime.InteropServices;



namespace BG_BIM_Interface.Rhinoceros
{
    [Guid("68F905EA-9BB8-4FA5-A701-8B56CE88E8D3")]
    public class BgBimInterfacePanelHost : RhinoWindows.Controls.WpfElementHost
    {        
        public BgBimInterfacePanelHost(uint docSn)
            : base(new BgBimInterfaceDocPanel(docSn), null)
        {
            //BgBimInterfaceCoreViewModel.Instance.BakeTriggered += CoreViewModel_BakeTriggered;
        }

        private void CoreViewModel_BakeTriggered(object sender, EventArgs e)
        {
            //BakeTriggeredEventArgs args = e as BakeTriggeredEventArgs;
            //this.Bake(args.Satellites);
        }

        private void Bake()
        {
            //Rhino.DocObjects.Tables.ObjectTable ot = Rhino.RhinoDoc.ActiveDoc.Objects;

            //// Bake Earth
            //double scale = SpaceMonkeyCoreViewModel.Instance.ScaleFactor;
            //Sphere earth = new Sphere(new Point3d(0, 0, 0), 6378.137 * scale);
            //ot.AddSphere(earth);

            //foreach (SmSatellite s in sats)
            //{
            //    Point3d pt = SatToPoint(s);
            //    ObjectAttributes attr = new ObjectAttributes();
            //    attr.SetUserString(nameof(SmSatellite.SatId), s.SatId.ToString());
            //    attr.SetUserString(nameof(SmSatellite.SatName), s.SatName);
            //    attr.SetUserString(nameof(SmSatellite.IntDesignator), s.IntDesignator);
            //    attr.SetUserString(nameof(SmSatellite.LaunchDate), s.LaunchDate);
            //    attr.SetUserString(nameof(SmSatellite.SatLat), s.SatLat.ToString());
            //    attr.SetUserString(nameof(SmSatellite.SatLng), s.SatLng.ToString());
            //    attr.SetUserString(nameof(SmSatellite.SatAlt), s.SatAlt.ToString());
            //    ot.AddPoint(pt, attr);
            //}

            //foreach (var view in Rhino.RhinoDoc.ActiveDoc.Views)
            //{
            //    view.Redraw();
            //}
        }

    }
    public class BgBimInterfaceRhinocerosCommand : Command
    {

        public BgBimInterfaceRhinocerosCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;           
            Rhino.UI.Panels.RegisterPanel(BgBimInterfaceRhinocerosPlugIn.Instance, typeof(BgBimInterfacePanelHost), "BgBimInterface", null);            
        }

        ///<summary>The only instance of this command.</summary>
        public static BgBimInterfaceRhinocerosCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "BgBimInterface"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {          
            RhinoApp.WriteLine("Launching BG BIM Interface");
            this.LaunchBimInterface();
            
            return Result.Success;
        }

        public void LaunchBimInterface()
        {
            var panelId = typeof(BgBimInterfacePanelHost).GUID;
            var panelVisible = Rhino.UI.Panels.IsPanelVisible(panelId);

            if (!panelVisible)
            {
                Rhino.UI.Panels.OpenPanel(panelId);
            }
        }
    }
}

