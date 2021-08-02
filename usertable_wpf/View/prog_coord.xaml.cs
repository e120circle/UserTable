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
using System.Windows.Threading;

namespace usertable_wpf.View
{
    /// <summary>
    /// prog_coord.xaml 的互動邏輯
    /// </summary>
    public partial class prog_coord : UserControl
    {
        Viewmodel.prog_viewmodel viewmodel;

        public prog_coord(NCLinker2.NCLinker2 NC)
        {
            InitializeComponent();
            viewmodel = new Viewmodel.prog_viewmodel(NC);
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
