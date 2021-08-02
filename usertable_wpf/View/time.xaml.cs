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
    /// time.xaml 的互動邏輯
    /// </summary>
    public partial class time : UserControl
    {
        Viewmodel.time_viewmodel viewmodel;

        public time()
        {
            InitializeComponent();

            viewmodel = new Viewmodel.time_viewmodel();
            this.DataContext = viewmodel;

            viewmodel.change += viewmodel_change;
        }
        
        private string[] ti;
        
        public void start()
        {
            viewmodel.Start();
        }

        public void stop()
        {
            viewmodel.Stop();
        }

        private void viewmodel_change(string time)
        {
            ti = time.Split(':');
            H_A.show(Convert.ToInt16(ti[0].Substring(0,1)));
            H_B.show(Convert.ToInt16(ti[0].Substring(1,1)));
            M_A.show(Convert.ToInt16(ti[1].Substring(0,1)));
            M_B.show(Convert.ToInt16(ti[1].Substring(1,1)));
            S_A.show(Convert.ToInt16(ti[2].Substring(0,1)));
            S_B.show(Convert.ToInt16(ti[2].Substring(1,1)));
        }
    }
}
