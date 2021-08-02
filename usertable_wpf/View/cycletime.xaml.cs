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
    /// cycletime.xaml 的互動邏輯
    /// </summary>
    public partial class cycletime : UserControl
    {
        Viewmodel.cycletime_viewmodel viewmodel;

        public cycletime(NCLinker2.NCLinker2 NC)
        {

            InitializeComponent();
            viewmodel = new Viewmodel.cycletime_viewmodel(NC);
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

            if(ti[0].Length == 1)
            {
                H_A.show(0);
                H_B.show(Convert.ToInt16(ti[0].Substring(0, 1)));
            }
            else
            {
                H_A.show(Convert.ToInt16(ti[0].Substring(0, 1)));
                H_B.show(Convert.ToInt16(ti[0].Substring(1, 1)));
            }

            if (ti[1].Length == 1)
            {
                M_A.show(0);
                M_B.show(Convert.ToInt16(ti[1].Substring(0, 1)));
            }                               
            else                            
            {                               
                M_A.show(Convert.ToInt16(ti[1].Substring(0, 1)));
                M_B.show(Convert.ToInt16(ti[1].Substring(1, 1)));
            }

            if (ti[2].Length == 1)
            {
                S_A.show(0);
                S_B.show(Convert.ToInt16(ti[2].Substring(0, 1)));
            }                               
            else                            
            {                               
                S_A.show(Convert.ToInt16(ti[2].Substring(0, 1)));
                S_B.show(Convert.ToInt16(ti[2].Substring(1, 1)));
            }
        }
    }
}
