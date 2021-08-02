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
    /// digital.xaml 的互動邏輯
    /// </summary>
    public partial class digital : UserControl
    {
        Viewmodel.digital_viewmodel viewmodel;

        public digital()
        {
            InitializeComponent();
            viewmodel = new Viewmodel.digital_viewmodel();
            this.DataContext = viewmodel;
        }

        public void show(int n)
        {
            viewmodel.show(n);
        }
    }
}
