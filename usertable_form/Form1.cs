using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace usertable_form
{
    public partial class Form1 : Form
    {
        NCLinker2.NCLinker2 NCLinker;

        public Form1()
        {
            NCLinker = new NCLinker2.NCLinker2("M");
            NCLinker.IP = "192.168.11.163";
            InitializeComponent();
            usertable1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usertable1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usertable1.Stop();
        }
    }
}
