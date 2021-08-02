using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace usertable_wpf.Model
{
    class feed1_1_model
    {
        internal feed1_1_model(NCLinker2.NCLinker2 L)
        {
            NCLink = new NCLinker2.NCLinker2(L.type);
            NCLink.IP = L.IP;

            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(500);
            timer1.Tick += timer1_Tick;
        }

        internal delegate void proper_change(string name);

        internal event proper_change change;

        private NCLinker2.NCLinker2 NCLink;

        private DispatcherTimer timer1;

        private int temp_unit, rpm;

        private double feed;

        private string rpm_p;
        public string Rpm
        {
            get { return rpm_p; }
            set { rpm_p = value; change("Rpm"); }
        }

        private string sunit_p;
        public string Sunit
        {
            get { return sunit_p; }
            set { sunit_p = value; change("Sunit"); }
        }

        private string feed_p;
        public string Feed
        {
            get { return feed_p; }
            set { feed_p = value; change("Feed"); }
        }

        private string funit_p;
        public string Funit
        {
            get { return funit_p; }
            set { funit_p = value; change("Funit"); }
        }

        public void Start()
        {
            ds_API_SqlClass.ds_config_api main = new ds_API_SqlClass.ds_config_api();
            temp_unit = Convert.ToInt32(main.getSpecConfig("IsInch"));

            if (temp_unit == 1)
            {
                Sunit = "RPM";
                Funit = "inch/min";
            }
            else
            {
                Sunit = "RPM";
                Funit = "mm/min";
            }

            NCLink.NCConnect();
            timer1.Start();
        }

        public void Stop()
        {
            timer1.Stop();
            NCLink.NCDisConnect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            NCLink.DsGetSpindleSpeed(ref rpm);
            NCLink.DsGetCombinedFeed_DISP(ref feed);

            if (temp_unit == 1)
            {
                Rpm = rpm.ToString("0.0000");
                Feed = feed.ToString("0.0000");
            }
            else
            {
                Rpm = rpm.ToString("0.000");
                Feed = feed.ToString("0.000");
            }

            timer1.Start();
        }
    }
}
