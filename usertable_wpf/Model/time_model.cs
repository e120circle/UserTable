using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using ds_API_SqlClass;
using System.Windows.Threading;

namespace usertable_wpf.Model
{
    class time_model
    {
        public time_model()
        {
            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Tick += timer1_Tick;
        }

        internal delegate void proper_change (string name);

        internal event proper_change change;

        private DispatcherTimer timer1;

        internal string time;

        public void Start()
        {
            timer1.Start();
        }

        public void Stop()
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            time = DateTime.Now.ToString("hh:mm:ss") + ":" + DateTime.Now.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);
            change("time");
            timer1.Start();
        }
    }
}
