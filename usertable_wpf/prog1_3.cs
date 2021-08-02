using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace usertable_wpf
{
    public partial class prog1_3 : UserControl
    {
        public NCLinker2.NCLinker2 NCLinker2;  // 控制器

        public prog1_3()
        {
            InitializeComponent();
        }
        public prog1_3(NCLinker2.NCLinker2 NCLinkerr)
        {
            NCLinker2 = NCLinkerr;
            InitializeComponent();
        }
        public void start()
        {
            userControl11.start();
        }
        public void stop()
        {
            userControl11.stop();
        }
    }
}
