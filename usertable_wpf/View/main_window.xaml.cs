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

namespace usertable_wpf
{
    /// <summary>
    /// UserControl1.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl1 : UserControl
    {        
        public UserControl1(NCLinker2.NCLinker2 NC)
        {
            InitializeComponent();

            viewmodel = new Viewmodel.main_viewmodel(NC);
            viewmodel.messageview = MyMessageBox;

            this.DataContext = viewmodel;
        }

        private Viewmodel.main_viewmodel viewmodel;

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
