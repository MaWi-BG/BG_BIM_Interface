﻿using System;
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
        }
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

            //if (e.ExtentHeight != 0 && e.VerticalChange > 0 && (e.VerticalOffset + e.ViewportHeight >= 0.99 * e.ExtentHeight))
            //{
            //    SpaceMonkeyCoreViewModel vmodel = this.DataContext as SpaceMonkeyCoreViewModel;
            //    if (!vmodel.ScrollFreeze)
            //    {
            //        vmodel.ShowSatellites();
            //    }
            //}
        }
    }
}
