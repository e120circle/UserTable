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
    public partial class usertable : UserControl
    {
        public NCLinker2.NCLinker2 NCLinker2;  // 控制器

        public usertable()
        {
            InitializeComponent();
        }

        public usertable(NCLinker2.NCLinker2 NCLinkerr)
        {
            NCLinker2 = NCLinkerr;
            InitializeComponent();
        }

        public void Start()
        {
            table_control.start();
        }
        public void Stop()
        {
            table_control.stop();
        }
    }
}
