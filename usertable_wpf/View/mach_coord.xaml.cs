using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace usertable_wpf.View
{
    /// <summary>
    /// mach_coord.xaml 的互動邏輯
    /// </summary>
    public partial class mach_coord : UserControl
    {
        Viewmodel.mach_viewmodel viewmodel;

        public mach_coord(NCLinker2.NCLinker2 NC)
        {
            InitializeComponent();
            viewmodel = new Viewmodel.mach_viewmodel(NC);
            this.DataContext = viewmodel;
        }

        public void start()
        {
            viewmodel.Start();
        }

        public void stop()
        {
            viewmodel.Stop();
        }
    }
}
