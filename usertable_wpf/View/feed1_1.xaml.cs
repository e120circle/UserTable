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
    /// feed1_1.xaml 的互動邏輯
    /// </summary>
    public partial class feed1_1 : UserControl
    {
        Viewmodel.feed1_1_viewmodel viewmodel;

        public feed1_1(NCLinker2.NCLinker2 NC)
        {
            InitializeComponent();
            viewmodel = new Viewmodel.feed1_1_viewmodel(NC);
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
