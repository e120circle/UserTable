using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace usertable_wpf.Model
{
    class ACHead_model
    {
        internal ACHead_model(NCLinker2.NCLinker2 L)
        {
            NCLink = new NCLinker2.NCLinker2(L.type);
            NCLink.IP = L.IP;
            type = L.type;

            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(500);
            timer1.Tick += timer1_Tick;
        }

        internal delegate void proper_change(string name);

        internal event proper_change change;

        private NCLinker2.NCLinker2 NCLink;

        private DispatcherTimer timer1;

        private string type;

        private short fora, forc;

        private int unit, ahead, chead;

        private string ahead_p;
        public string Ahead
        {
            get { return ahead_p; }
            set { ahead_p = value; change("Ahead"); }
        }

        private string chead_p;
        public string Chead
        {
            get { return chead_p; }
            set { chead_p = value; change("Chead"); }
        }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if(type == "F")
            {
                NCLink.DsGetDAddress(62, out unit, 1);         //D62==10 /10 D62!=10 *1
                NCLink.DsGetDAddress(72, out ahead, 1);
                NCLink.DsGetDAddress(44, out chead, 1);

                if((unit == 1) || (unit == 5) || (unit == 15))
                {
                    Ahead = ahead.ToString();
                    Chead = chead.ToString();
                }
                else
                {
                    Ahead = (ahead / 10).ToString();
                    Chead = (chead / 10).ToString();
                }
            }
            else
            {
                NCLink.DsGetRWord(7602, ref fora);
                NCLink.DsGetRWord(7598, ref forc);

                Ahead = (fora / 10).ToString();
                Chead = (forc / 10).ToString();
            }

            timer1.Start();
        }
    }
}
