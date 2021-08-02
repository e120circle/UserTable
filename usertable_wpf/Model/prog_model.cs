using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ds_API_SqlClass;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading;

namespace usertable_wpf.Model
{
    class prog_model
    {
        internal prog_model(NCLinker2.NCLinker2 L)
        {
            NCLink = new NCLinker2.NCLinker2(L.type);
            NCLink.IP = L.IP;

            ost = new double[] { 0, 0, 0, 0, 0 };
            ost1 = new double[] {0, 0, 0, 0, 0};
            axis_name = new string[5];

            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(100);
            timer1.Tick += timer1_Tick;
        }

        internal delegate void proper_change(string name);

        internal event proper_change change;

        private NCLinker2.NCLinker2 NCLink;

        private DispatcherTimer timer1;

        private string Now_language;

        internal string[] axis_name;

        private int temp_unit = 0, axis_no = 0;                           //目前顯示單位 0:公制 1:英制

        internal int err1 = -1, err2 = -1;

        private double[] ost, ost1;

        private FontFamily font_p;
        public FontFamily Font
        {
            get { return font_p; }
            set { font_p = value; change("Font"); }
        }

        private string rela_coor_p;
        public string Rela_coor
        {
            get { return rela_coor_p; }
            set { rela_coor_p = value; change("Rela_coor"); } 
        }

        private string rema_coor_p;
        public string Rema_coor
        {
            get { return rema_coor_p; }
            set { rema_coor_p = value; change("Rema_coor"); }
        }      

        private string rela_x_p;
        public string Rela_x
        {
            get { return rela_x_p; }
            set { rela_x_p = value; change("Rela_x"); }
        }

        private string rela_y_p;
        public string Rela_y
        {
            get { return rela_y_p; }
            set { rela_y_p = value; change("Rela_y"); }
        }

        private string rela_z_p;
        public string Rela_z
        {
            get { return rela_z_p; }
            set { rela_z_p = value; change("Rela_z"); }
        }

        private string rela_a_p;
        public string Rela_a
        {
            get { return rela_a_p; }
            set { rela_a_p = value; change("Rela_a"); }
        }

        private string rela_c_p;
        public string Rela_c
        {
            get { return rela_c_p; }
            set { rela_c_p = value; change("Rela_c"); }
        }

        private string rema_x_p;
        public string Rema_x
        {
            get { return rema_x_p; }
            set { rema_x_p = value; change("Rema_x"); }
        }

        private string rema_y_p;
        public string Rema_y
        {
            get { return rema_y_p; }
            set { rema_y_p = value; change("Rema_y"); }
        }

        private string rema_z_p;
        public string Rema_z
        {
            get { return rema_z_p; }
            set { rema_z_p = value; change("Rema_z"); }
        }

        private string rema_a_p;
        public string Rema_a
        {
            get { return rema_a_p; }
            set { rema_a_p = value; change("Rema_a"); }
        }

        private string rema_c_p;
        public string Rema_c
        {
            get { return rema_c_p; }
            set { rema_c_p = value; change("Rema_c"); }
        }

        public void Start()
        {
            string na;

            RenewLanguage();
            NCLink.NCConnect();
            axis_no = NCLink.AxinNum;
            axis_name = new string[axis_no];

            for (int i = 1; i <= axis_no; i++)
            {
                NCLink.DsGetAxisNameDsp(i, out na);
                axis_name[i - 1] = na;
            }

            timer1.Start();
        }

        public void Stop()
        {
            timer1.Stop();
            NCLink.NCDisConnect();
        }

        private void RenewLanguage()
        {
            ds_config_api main_config = new ds_config_api();
            string temp_language = main_config.getSpecConfig("language_set");

            temp_unit = Convert.ToInt32(main_config.getSpecConfig("IsInch"));

            if (temp_language != Now_language)
            {
                using (ds_language_api lan = new ds_language_api("Wkbystep"))
                {
                    Rela_coor = lan.TextString("group_RP");
                }    
            
                using (ds_language_api lan = new ds_language_api("user_table"))
                {
                    Rema_coor = lan.TextString("rema_title");
                }

                Now_language = temp_language;
                Font = (Now_language == "15") ? new FontFamily("Microsoft JhengHei Ui") : new FontFamily("Century Gothic");
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            err1 = NCLink.DsGetRelatvLoc(axis_no, ref ost);
            err2 = NCLink.DsGetRemainLoc(axis_no, ref ost1);

            if (err1 == 0)
            {
                if (temp_unit == 1)
                {
                    Rela_x = ost[0].ToString("0.0000");
                    Rela_y = ost[1].ToString("0.0000");
                    Rela_z = ost[2].ToString("0.0000");
                    Rela_a = ost[3].ToString("0.0000");
                    Rela_c = ost[4].ToString("0.0000");
                }
                else
                {
                    Rela_x = ost[0].ToString("0.000");
                    Rela_y = ost[1].ToString("0.000");
                    Rela_z = ost[2].ToString("0.000");
                    Rela_a = ost[3].ToString("0.000");
                    Rela_c = ost[4].ToString("0.000");
                }
            }
            else
            {
                Rela_x = "##ERROR##";
                Rela_y = "##ERROR##";
                Rela_z = "##ERROR##";
                Rela_a = "##ERROR##";
                Rela_c = "##ERROR##";
            }

            if (err2 == 0)
            {
                if (temp_unit == 1)
                {
                    Rema_x = ost1[0].ToString("0.0000");
                    Rema_y = ost1[1].ToString("0.0000");
                    Rema_z = ost1[2].ToString("0.0000");
                    Rema_a = ost1[3].ToString("0.0000");
                    Rema_c = ost1[4].ToString("0.0000");
                }
                else
                {
                    Rema_x = ost1[0].ToString("0.000");
                    Rema_y = ost1[1].ToString("0.000");
                    Rema_z = ost1[2].ToString("0.000");
                    Rema_a = ost1[3].ToString("0.000");
                    Rema_c = ost1[4].ToString("0.000");
                }
            }
            else
            {
                Rema_x = "##ERROR##";
                Rema_y = "##ERROR##";
                Rema_z = "##ERROR##";
                Rema_a = "##ERROR##";
                Rema_c = "##ERROR##";
            }

            timer1.Start();
        }
    }
}
