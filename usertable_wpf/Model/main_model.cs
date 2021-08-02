using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using ds_API_SqlClass;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace usertable_wpf.Model
{
    class main_model
    {
        internal main_model ()
        {
            Loadapp = new loadapp[16] 
            {
                new loadapp() {assembly = "./DsCalendar.dll", type = "DsCalendar.DsCalender_Control_2_5", y = 5, x = 2, nc = false},
                new loadapp() {assembly = "./HP_ToolShow_UserControl.dll", type = "HP_ToolShow_UserControl.simple_control", y = 1, x = 1, nc = true},
                new loadapp() {assembly = "./usertable_wpf.dll", type = "usertable_wpf.coord1_3", y = 3, x = 1, nc = true},
                new loadapp() {assembly = "./usertable_wpf.dll", type = "usertable_wpf.prog1_3", y = 3, x = 1, nc = true},
                new loadapp() {assembly = "./DS_SpindleLog.dll", type = "DS_SpindleLog.DS_SpindleLogControl_mini", y = 2, x = 3, nc = true},
                new loadapp() {assembly = "./Hartnet_Control_Remaintime.dll", type = "Hartnet_Control_Remaintime.Hartnet_Remaintime_2x2", y = 2, x = 2, nc = false},
                new loadapp() {assembly = "./usertable_wpf.dll", type = "usertable_wpf.feed1_1", y = 1, x = 1, nc = true},
                new loadapp() {assembly = "./DsCalc.dll", type = "DsCalc.DsCalc_1_3", y = 3, x = 1, nc = false},
                new loadapp() {assembly = "./ZDT.dll", type = "ZDT.ZDT_Control3_3", y = 3, x = 3, nc = false},
                new loadapp() {assembly = "./usertable_wpf.dll", type = "usertable_wpf.time_1_1", y = 1, x = 1, nc = false},
                new loadapp() {assembly = "./usertable_wpf.dll", type = "usertable_wpf.cycletime_1_1", y = 1, x = 1, nc = true},
                new loadapp() {assembly = "./Hartnet_Control_Daystatus.dll", type = "Hartnet_Control_Daystatus.MiniBarUserControl", y = 1, x = 5, nc = false},
                new loadapp() {assembly = "./Hartnet_Control_Daystatus.dll", type = "Hartnet_Control_Daystatus.MiniPieUserControl", y = 2, x = 2, nc = false},
                new loadapp() {assembly = "./ds_paint.dll", type = "ds_paint.ImageViewer_3x3", y = 3, x = 3, nc = false},
                new loadapp() {assembly = "../DLL/Pool/MCodeList.dll", type = "MCodeList.MCodeList3_2_userControl", y = 2, x = 2, nc = true},
                new loadapp() {assembly = "./usertable_wpf.dll", type = "usertable_wpf.ACHead_1_1", y = 1, x = 1, nc = true},
            };            
        }

        internal delegate void proper_change(string name);

        internal event proper_change change;

        internal loadapp[] Loadapp;

        private string sqlconnection = "server = 127.0.0.1 ; port =3306 ; uid = root ; pwd = aaaa999999;";

        private string Now_language;

        private FontFamily font_p;
        public FontFamily Font
        {
            get { return font_p; }
            set { font_p = value; change("Font"); }
        }

        private string tool_title_p;
        public string Tool_title
        {
            get { return tool_title_p; }
            set { tool_title_p = value; change("Tool_title"); }
        }

        private string contdown_title_p;
        public string Contdown_title
        {
            get { return contdown_title_p; }
            set { contdown_title_p = value; change("Contdown_title"); }
        }

        private string mach_rela_p;
        public string Mach_rela
        {
            get { return mach_rela_p; }
            set { mach_rela_p = value; change("Mach_rela"); }
        }

        private string rela_rema_p;
        public string Rela_rema
        {
            get { return rela_rema_p; }
            set { rela_rema_p = value; change("Rela_rema"); }
        }

        private string spin_title_p;
        public string Spin_title
        {
            get { return spin_title_p; }
            set { spin_title_p = value; change("Spin_title"); }
        }

        private string calen_title_p;
        public string Calen_title
        {
            get { return calen_title_p; }
            set { calen_title_p = value; change("Calen_title"); }
        }

        private string zdt_title_p;
        public string Zdt_title
        {
            get { return zdt_title_p; }
            set { zdt_title_p = value; change("Zdt_title"); }
        }

        private string calu_title_p;
        public string Calu_title
        {
            get { return calu_title_p; }
            set { calu_title_p = value; change("Calu_title"); }
        }

        private string time_title_p;
        public string Time_title
        {
            get { return time_title_p; }
            set { time_title_p = value; change("Time_title"); }

        }

        private string day_title_p;
        public string Day_title
        {
            get { return day_title_p; }
            set { day_title_p = value; change("Day_title"); }

        }

        private string msg_title_p;
        public string Msg_title
        {
            get { return msg_title_p; }
            set { msg_title_p = value; change("Msg_title"); }

        }

        private string mcode_title_p;
        public string Mcode_title
        {
            get { return mcode_title_p; }
            set { mcode_title_p = value; change("Mcode_title"); }

        }

        private string nospace_p;
        public string Nospace
        {
            get { return nospace_p; }
            set { nospace_p = value; change("Nospace"); }
        }

        private string already_p;
        public string Already
        {
            get { return already_p; }
            set { already_p = value; change("Already"); }
        }

        private Brush Back0_p = Brushes.Transparent;
        public Brush Back0
        {
            get { return Back0_p; }
            set { Back0_p = value; change("Back0"); }
        }

        private Brush Back1_p = Brushes.Transparent;
        public Brush Back1
        {
            get { return Back1_p; }
            set { Back1_p = value; change("Back1"); }
        }

        private Brush Back2_p = Brushes.Transparent;
        public Brush Back2
        {
            get { return Back2_p; }
            set { Back2_p = value; change("Back2"); }
        }

        private Brush Back3_p = Brushes.Transparent;
        public Brush Back3
        {
            get { return Back3_p; }
            set { Back3_p = value; change("Back3"); }
        }

        private Brush Back4_p = Brushes.Transparent;
        public Brush Back4
        {
            get { return Back4_p; }
            set { Back4_p = value; change("Back4"); }
        }

        private Brush Back5_p = Brushes.Transparent;
        public Brush Back5
        {
            get { return Back5_p; }
            set { Back5_p = value; change("Back5"); }
        }

        private Brush Back6_p = Brushes.Transparent;
        public Brush Back6
        {
            get { return Back6_p; }
            set { Back6_p = value; change("Back6"); }
        }

        private Brush Back7_p = Brushes.Transparent;
        public Brush Back7
        {
            get { return Back7_p; }
            set { Back7_p = value; change("Back7"); }
        }

        private Brush Back8_p = Brushes.Transparent;
        public Brush Back8
        {
            get { return Back8_p; }
            set { Back8_p = value; change("Back8"); }
        }

        private Brush Back9_p = Brushes.Transparent;
        public Brush Back9
        {
            get { return Back9_p; }
            set { Back9_p = value; change("Back9"); }
        }

        private Brush Back10_p = Brushes.Transparent;
        public Brush Back10
        {
            get { return Back10_p; }
            set { Back10_p = value; change("Back10"); }
        }

        private Brush Back11_p = Brushes.Transparent;
        public Brush Back11
        {
            get { return Back11_p; }
            set { Back11_p = value; change("Back11"); }
        }

        private Brush Back12_p = Brushes.Transparent;
        public Brush Back12
        {
            get { return Back12_p; }
            set { Back12_p = value; change("Back12"); }
        }

        private Brush Back13_p = Brushes.Transparent;
        public Brush Back13
        {
            get { return Back13_p; }
            set { Back13_p = value; change("Back13"); }
        }

        private Brush Back14_p = Brushes.Transparent;
        public Brush Back14
        {
            get { return Back14_p; }
            set { Back14_p = value; change("Back14"); }
        }

        private Brush Back15_p = Brushes.Transparent;
        public Brush Back15
        {
            get { return Back15_p; }
            set { Back15_p = value; change("Back15"); }
        }

        internal class loadapp
        {
            internal string assembly {get; set;}                //實例
            internal string type { get; set; }                  //實例
            internal int y { get; set; }                        //高
            internal int x { get; set; }                        //寬
            internal bool nc { get; set; }                      //需不需要nclinker
            internal string title { get; set; }                 //標題
        }

        public void Start()
        {
            RenewLanguage();
            Loadapp[0].title = Calen_title;
            Loadapp[1].title = Tool_title;
            Loadapp[2].title = Mach_rela;
            Loadapp[3].title = Rela_rema;
            Loadapp[4].title = Spin_title;
            Loadapp[5].title = Contdown_title;
            Loadapp[6].title = "S & F";
            Loadapp[7].title = Calu_title;
            Loadapp[8].title = Zdt_title;
            Loadapp[9].title = Time_title;
            Loadapp[10].title = "Cycle Time";
            Loadapp[11].title = Day_title;
            Loadapp[12].title = Day_title;
            Loadapp[13].title = Msg_title;
            Loadapp[14].title = Mcode_title;
            Loadapp[15].title = "A,C Head";

            using (ds_version_api sql_ver = new ds_version_api())
            {
                sql_ver.set_function_version("user_table", "HPA053-A01");               //寫入版本資訊
            }
        }

        public void Stop()
        {

        }

        private void RenewLanguage()
        {
            ds_config_api main_language = new ds_config_api();
            string temp_language = main_language.getSpecConfig("language_set");

            if (temp_language != Now_language)
            {
                using (ds_language_api lan = new ds_language_api("Htdl_9001"))
                {
                    Tool_title = lan.TextString("H9001STR008");
                    Contdown_title = lan.TextString("H9001STRA17");
                    Spin_title = lan.TextString("H9001STR009");
                    Calen_title = lan.TextString("H9001STRA51");
                    Zdt_title = lan.TextString("H9001STRA33");
                    Calu_title = lan.TextString("H9001STR005");
                    Day_title = lan.TextString("H9001STRA13");
                    Msg_title = lan.TextString("H9001STRA31");
                    Mcode_title = lan.TextString("H9001STR004");                    
                }

                using (ds_language_api lan = new ds_language_api("user_table"))
                {
                    Mach_rela = lan.TextString("mach_title");
                    Rela_rema = lan.TextString("rela_title");
                    Time_title = lan.TextString("time_title");
                    Nospace = lan.TextString("nospace");
                    Already = lan.TextString("already");
                }

                Now_language = temp_language;
                Font = (Now_language == "15") ? new FontFamily("Microsoft JhengHei Ui") : new FontFamily("Century Gothic");
            }
        }

        internal void write_table(int load_idx, int location_x, int location_y)
        {
            using (MySqlConnection sconn = new MySqlConnection(sqlconnection))
            {
                sconn.Open();
                String sql_Command = "INSERT INTO `ds`.`user_table` (`load_idx`, `location_x`, `location_y`) VALUES ('";
                sql_Command += load_idx + "', '" + location_x + "', '" + location_y + "');";
                using (MySqlCommand scmd = new MySqlCommand(sql_Command, sconn))
                {
                    scmd.ExecuteNonQuery();
                }
                sconn.Close();
            }
        }

        internal void read_table(List<int> app, List<int> x, List<int> y)
        {
            try
            {
                using (MySqlConnection sconn = new MySqlConnection(sqlconnection))
                {
                    sconn.Open();

                    String sql_Command = "select `load_idx` From `ds`.`user_table`;";
                    using (MySqlCommand scmd = new MySqlCommand(sql_Command, sconn))
                    {
                        MySqlDataReader sdr = scmd.ExecuteReader();
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(sdr);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                app.Add(Convert.ToInt16(dt.Rows[i][0]));
                            }
                        }
                    }

                    sql_Command = "select `location_x` From `ds`.`user_table`;";
                    using (MySqlCommand scmd = new MySqlCommand(sql_Command, sconn))
                    {
                        MySqlDataReader sdr = scmd.ExecuteReader();
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(sdr);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                x.Add(Convert.ToInt16(dt.Rows[i][0]));
                            }
                        }
                    }

                    sql_Command = "select `location_y` From `ds`.`user_table`;";
                    using (MySqlCommand scmd = new MySqlCommand(sql_Command, sconn))
                    {
                        MySqlDataReader sdr = scmd.ExecuteReader();
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(sdr);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                y.Add(Convert.ToInt16(dt.Rows[i][0]));
                            }
                        }
                    }
                    sconn.Close();
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }
        }

        internal void delete(int idx)
        {
            using (MySqlConnection sconn = new MySqlConnection(sqlconnection))
            {
                sconn.Open();
                String sql_Command = "DELETE FROM `ds`.`user_table` WHERE `load_idx`='" + idx + "';";
                using (MySqlCommand scmd = new MySqlCommand(sql_Command, sconn))
                {
                    scmd.ExecuteNonQuery();
                }
                sconn.Close();
            }
        }

        internal void move_modify(string uid, int x, int y)
        {
            using (MySqlConnection sconn = new MySqlConnection(sqlconnection))
            {
                sconn.Open();
                String sql_Command = "UPDATE `ds`.`user_table` SET `location_x`='" + x + "',";
                sql_Command += "`location_y`='" + y + "' WHERE `load_idx`='" + uid + "';";
                using (MySqlCommand scmd = new MySqlCommand(sql_Command, sconn))
                {
                    scmd.ExecuteNonQuery();
                }
                sconn.Close();
            }
        }
    }
}
