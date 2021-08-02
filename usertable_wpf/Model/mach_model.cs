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
    class mach_model
    {
        internal mach_model(NCLinker2.NCLinker2 L)
        {
            type = L.type;
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

        private string Now_language, wktitle, type, temp_unit = "0";

        internal string[] axis_name;

        private int axis_no = 0;                           //目前顯示單位 0:公制 1:英制

        internal int err1 = -1, err2 = -1;

        private double[] ost, ost1;

        private FontFamily font_p;
        public FontFamily Font
        {
            get { return font_p; }
            set { font_p = value; change("Font"); }
        }

        private string mach_coor_p;
        public string Mach_coor
        {
            get { return mach_coor_p; }
            set { mach_coor_p = value; change("Mach_coor"); } 
        }

        private string work_coor_p;
        public string Work_coor
        {
            get { return work_coor_p; }
            set { work_coor_p = value; change("Work_coor"); }
        }

        private string mach_x_p;
        public string Mach_x
        {
            get { return mach_x_p; }
            set { mach_x_p = value; change("Mach_x"); }
        }

        private string mach_y_p;
        public string Mach_y
        {
            get { return mach_y_p; }
            set { mach_y_p = value; change("Mach_y"); }
        }

        private string mach_z_p;
        public string Mach_z
        {
            get { return mach_z_p; }
            set { mach_z_p = value; change("Mach_z"); }
        }

        private string mach_a_p;
        public string Mach_a
        {
            get { return mach_a_p; }
            set { mach_a_p = value; change("Mach_a"); }
        }

        private string mach_c_p;
        public string Mach_c
        {
            get { return mach_c_p; }
            set { mach_c_p = value; change("Mach_c"); }
        }

        private string work_x_p;
        public string Work_x
        {
            get { return work_x_p; }
            set { work_x_p = value; change("Work_x"); }
        }

        private string work_y_p;
        public string Work_y
        {
            get { return work_y_p; }
            set { work_y_p = value; change("Work_y"); }
        }

        private string work_z_p;
        public string Work_z
        {
            get { return work_z_p; }
            set { work_z_p = value; change("Work_z"); }
        }

        private string work_a_p;
        public string Work_a
        {
            get { return work_a_p; }
            set { work_a_p = value; change("Work_a"); }
        }

        private string work_c_p;
        public string Work_c
        {
            get { return work_c_p; }
            set { work_c_p = value; change("Work_c"); }
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

            temp_unit = main_config.getSpecConfig("IsInch");

            if (temp_language != Now_language)
            {
                using (ds_language_api lan = new ds_language_api("Wkbystep"))
                {
                    Mach_coor = lan.TextString("group_MP");
                }

                using (ds_language_api lan = new ds_language_api("user_table"))
                {
                    wktitle = lan.TextString("work_title");
                }

                Now_language = temp_language;
                Font = (Now_language == "15") ? new FontFamily("Microsoft JhengHei Ui") : new FontFamily("Century Gothic");
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            double gcode = 0;

            timer1.Stop();

            err1 = NCLink.DsGetMchLoc(axis_no, ref ost);
            err2 = NCLink.DsGetWorkLoc(axis_no, ref ost1);

            if (type == "F")
            {
                int temp = 0;

                NCLink.DsGetGModel(13, ref temp);

                if ((temp >= 0) && (temp <= 5))
                {
                    gcode = temp + 54;
                }
            }
            else
            {
                NCLink.DsGetCurrentGcode(12, out gcode);
            }

            Work_coor = wktitle + "  G" + gcode.ToString();

            if (err1 == 0)
            {
                if (temp_unit == "1")
                {
                    Mach_x = ost[0].ToString("0.0000");
                    Mach_y = ost[1].ToString("0.0000");
                    Mach_z = ost[2].ToString("0.0000");
                    Mach_a = ost[3].ToString("0.0000");
                    Mach_c = ost[4].ToString("0.0000");
                }
                else
                {
                    Mach_x = ost[0].ToString("0.000");
                    Mach_y = ost[1].ToString("0.000");
                    Mach_z = ost[2].ToString("0.000");
                    Mach_a = ost[3].ToString("0.000");
                    Mach_c = ost[4].ToString("0.000");
                }
            }
            else
            {
                Mach_x = "##ERROR##";
                Mach_y = "##ERROR##";
                Mach_z = "##ERROR##";
                Mach_a = "##ERROR##";
                Mach_c = "##ERROR##";
            }

            if (err2 == 0)
            {
                if (temp_unit == "1")
                {
                    Work_x = ost1[0].ToString("0.0000");
                    Work_y = ost1[1].ToString("0.0000");
                    Work_z = ost1[2].ToString("0.0000");
                    Work_a = ost1[3].ToString("0.0000");
                    Work_c = ost1[4].ToString("0.0000");
                }
                else
                {
                    Work_x = ost1[0].ToString("0.000");
                    Work_y = ost1[1].ToString("0.000");
                    Work_z = ost1[2].ToString("0.000");
                    Work_a = ost1[3].ToString("0.000");
                    Work_c = ost1[4].ToString("0.000");
                }
            }
            else
            {
                Work_x = "##ERROR##";
                Work_y = "##ERROR##";
                Work_z = "##ERROR##";
                Work_a = "##ERROR##";
                Work_c = "##ERROR##";
            }

            timer1.Start();
        }
    }
}
