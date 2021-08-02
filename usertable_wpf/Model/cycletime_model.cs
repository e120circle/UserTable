using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCLinker2;
using System.Windows.Threading;

namespace usertable_wpf.Model
{
    class cycletime_model
    {
        public cycletime_model(NCLinker2.NCLinker2 NC)
        {
            NCLink = new NCLinker2.NCLinker2(NC.type);
            NCLink.IP = NC.IP;

            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Tick += timer1_Tick;
        }

        internal delegate void proper_change(string name);

        internal event proper_change change;

        private NCLinker2.NCLinker2 NCLink;

        private DispatcherTimer timer1;

        internal string time;

        public void Start()
        {
            NCLink.NCConnect();
            timer1.Start();
        }

        public void Stop()
        {
            timer1.Stop();
            NCLink.NCDisConnect();
        }

        private void timer1_Tick(Object sender, EventArgs e)
        {
            timer1.Stop();
            NCLink.DsGetCycleTime(out time);
            change("time");
            timer1.Start();
        }
    }
}
