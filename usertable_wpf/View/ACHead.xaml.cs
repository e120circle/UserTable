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
    /// Interaction logic for ACHead.xaml
    /// </summary>
    public partial class ACHead : UserControl
    {
        Viewmodel.ACHead_viewmodel viewmodel;

        public ACHead(NCLinker2.NCLinker2 NC)
        {
            InitializeComponent();
            viewmodel = new Viewmodel.ACHead_viewmodel(NC);
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
