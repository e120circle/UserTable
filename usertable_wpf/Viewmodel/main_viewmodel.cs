using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Reflection;
using System.Windows.Input;

namespace usertable_wpf.Viewmodel
{
    class main_viewmodel : INotifyPropertyChanged
    {        
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        internal main_viewmodel(NCLinker2.NCLinker2 NC)
        {
            model = new Model.main_model();
            model.change += model_change;

            Table = new List<item_data>();
            have_item = new bool[5, 5];
            NCLink = NC;
            ip = NC.IP;
        }

        public Bugatti.MessageBoxView.View.MessageBox messageview;

        private Model.main_model model;

        private NCLinker2.NCLinker2 NCLink;

        private bool down_flag = false;

        private bool[,] have_item;

        private string ip;

        private int move_index = 0;

        private List<item_data> table_p;
        public List<item_data> Table
        {
            get { return table_p; }
            set { table_p = value; NotifyPropertyChanged("Table"); }
        }

        private Visibility scr_vis_p = Visibility.Visible;
        public Visibility Scr_vis
        {
            get { return scr_vis_p; }
            set { scr_vis_p = value; NotifyPropertyChanged("Scr_vis"); }
        }

        private Visibility set_scr_vis_p = Visibility.Collapsed;
        public Visibility Set_scr_vis
        {
            get { return set_scr_vis_p; }
            set { set_scr_vis_p = value; NotifyPropertyChanged("Set_scr_vis"); }
        }

        private Visibility mouse_vis_p = Visibility.Collapsed;
        public Visibility Mouse_vis
        {
            get { return mouse_vis_p; }
            set { mouse_vis_p = value; NotifyPropertyChanged("Mouse_vis"); }
        }

        private int mouse_wi_p;
        public int Mouse_wi
        {
            get { return mouse_wi_p; }
            set { mouse_wi_p = value; NotifyPropertyChanged("Mouse_wi"); }
        }

        private int mouse_he_p;
        public int Mouse_he
        {
            get { return mouse_he_p; }
            set { mouse_he_p = value; NotifyPropertyChanged("Mouse_he"); }
        }

        private int mouse_col_p;
        public int Mouse_col
        {
            get { return mouse_col_p; }
            set { mouse_col_p = value; NotifyPropertyChanged("Mouse_col"); }
        }

        private int mouse_row_p;
        public int Mouse_row
        {
            get { return mouse_row_p; }
            set { mouse_row_p = value; NotifyPropertyChanged("Mouse_row"); }
        }

        private int mouse_colspan_p;
        public int Mouse_colspan
        {
            get { return mouse_colspan_p; }
            set { mouse_colspan_p = value; NotifyPropertyChanged("Mouse_colspan"); }
        }

        private int mouse_rowspan_p;
        public int Mouse_rowspan
        {
            get { return mouse_rowspan_p; }
            set { mouse_rowspan_p = value; NotifyPropertyChanged("Mouse_rowspan"); }
        }

        private Brush mouse_color_p;
        public Brush Mouse_color
        {
            get { return mouse_color_p; }
            set { mouse_color_p = value; NotifyPropertyChanged("Mouse_color"); }
        }

        private bool selectitem_p = false;
        public bool Selectitem
        {
            get { return selectitem_p; }
            set { selectitem_p = value; NotifyPropertyChanged("Selectitem"); }
        }

        internal FontFamily Font { get { return model.Font; } }
        public string Calen_title { get { return model.Calen_title; } }
        public string Mach_rela { get { return model.Mach_rela; } }
        public string Rela_rema { get { return model.Rela_rema; } }
        public string Spin_title { get { return model.Spin_title; } }
        public string Contdown_title { get { return model.Contdown_title; } }
        public string Zdt_title { get { return model.Zdt_title; } }
        public string Tool_title { get { return model.Tool_title; } }
        public string Calu_title { get { return model.Calu_title; } }
        public string Time_title { get { return model.Time_title; } }
        public string Day_title { get { return model.Day_title; } }
        public string Msg_title { get { return model.Msg_title; } }
        public string Mcode_title { get { return model.Mcode_title; } }
        public Brush Back0 { get { return model.Back0; } }
        public Brush Back1 { get { return model.Back1; } }
        public Brush Back2 { get { return model.Back2; } }
        public Brush Back3 { get { return model.Back3; } }
        public Brush Back4 { get { return model.Back4; } }
        public Brush Back5 { get { return model.Back5; } }
        public Brush Back6 { get { return model.Back6; } }
        public Brush Back7 { get { return model.Back7; } }
        public Brush Back8 { get { return model.Back8; } }
        public Brush Back9 { get { return model.Back9; } }
        public Brush Back10 { get { return model.Back10; } }
        public Brush Back11 { get { return model.Back11; } }
        public Brush Back12 { get { return model.Back12; } }
        public Brush Back13 { get { return model.Back13; } }
        public Brush Back14 { get { return model.Back14; } }
        public Brush Back15 { get { return model.Back15; } }

        public class item_data 
        {
            public Canvas Scr { get; set; }                                 //放FormsHost
            public string item_uid { get; set; }                            //記錄各個項目的uid
            public string item_title { get; set; }                          //APP標題
            public int title_width { get; set; }                            //app寬度
            public int title_height { get; set; }                           //app高度
            public int border_height { get; set; }                          //app畫面的高度
            public int row { get; set; }                                    //y的位置
            public int col { get; set; }                                    //x的位置
            public int colspan { get; set; }                                //x用了幾的單位
            public int rowspan { get; set; }                                //y用了幾的單位
            public Visibility Set_vis { get; set; }                         //顯示右上角的X符號
            public MethodInfo stop_method { get; set; }                     //放app 的 stop finction
            public MethodInfo start_method { get; set; }                    //放app 的 start finction
            public System.Windows.Forms.UserControl instance { get; set; }  //new 出來的app

            public delegate void closeclick(object sender, EventArgs e);    //關閉程式的委派

            public event closeclick close_click;

            public void click_in_item (object sender, EventArgs e)
            {
                close_click(sender, e);
            }

            public delegate void mousedown(object sender, EventArgs e);     //移動前按下滑鼠的委派

            public event mousedown mousemovedown;

            public void mouse_down(object sender, EventArgs e)
            {
                mousemovedown(sender, e);
            }

            public delegate void mouseup(object sender, EventArgs e);       //移動後滑鼠起來的委派

            public event mouseup mousemoveup;

            public void mouse_up(object sender, EventArgs e)
            {
                mousemoveup(sender, e);
            }
        }

        public void Start()
        {
            List<item_data> temp = new List<item_data>();   

            model.Start();
            Scr_vis = Visibility.Visible;
            Set_scr_vis = Visibility.Collapsed;

            if (Table.Count != 0)
            {
                for (int i = 0; i < Table.Count; i++)
                {
                    temp.Add(Table[i]);
                    temp[temp.Count - 1].item_title = model.Loadapp[i].title;
                    temp[temp.Count - 1].start_method.Invoke(temp[temp.Count - 1].instance, new object[] { });
                }
            }
            else if ((Table.Count == 0) || (ip != NCLink.IP))
            {
                List<int> app = new List<int>();
                List<int> x = new List<int>();
                List<int> y = new List<int>();             

                model.read_table(app, x, y);                
                System.Windows.Forms.UserControl instan;

                for (int i = 0; i < app.Count; i++)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(model.Loadapp[app[i]].assembly);
                        Type type = assembly.GetType(model.Loadapp[app[i]].type);

                        if (model.Loadapp[app[i]].nc) instan = Activator.CreateInstance(type, new object[] { NCLink }) as System.Windows.Forms.UserControl;
                        else instan = Activator.CreateInstance(type) as System.Windows.Forms.UserControl;

                        var ff = new System.Windows.Forms.Integration.WindowsFormsHost()
                        {
                            Width = get_wid(model.Loadapp[app[i]].x),
                            Height = get_hei(model.Loadapp[app[i]].y),
                            Child = instan
                        };

                        var ttt = type.GetMethods();
                        temp.Add(new item_data()
                        {
                            row = y[i],
                            rowspan = model.Loadapp[app[i]].y,
                            col = x[i],
                            colspan = model.Loadapp[app[i]].x,
                            Scr = new Canvas() { Margin = new Thickness(0, 3, 0, 0) },
                            item_uid = app[i].ToString(),
                            item_title = model.Loadapp[app[i]].title,
                            title_width = get_wid(model.Loadapp[app[i]].x),
                            title_height = get_hei(model.Loadapp[app[i]].y),
                            border_height = get_hei(model.Loadapp[app[i]].y) - 3,
                            start_method = type.GetMethods()[0],
                            stop_method = type.GetMethods()[1],
                            instance = instan
                        });

                        temp[temp.Count - 1].Scr.Children.Add(ff);
                        temp[temp.Count - 1].Scr.MouseUp += move_up;
                        temp[temp.Count - 1].close_click += close_in_viewmodel;
                        temp[temp.Count - 1].mousemovedown += move_down;
                        temp[temp.Count - 1].mousemoveup += move_up;
                        temp[temp.Count - 1].Set_vis = Visibility.Collapsed;
                        temp[temp.Count - 1].start_method.Invoke(temp[temp.Count - 1].instance, new object[] { });

                        for (int ii = y[i]; ii < model.Loadapp[app[i]].y + y[i]; ii++)
                        {
                            for (int jj = x[i]; jj < model.Loadapp[app[i]].x + x[i]; jj++)
                            {
                                have_item[ii, jj] = true;
                            }
                        }                        
                    }
                    catch (Exception ee) { MessageBox.Show(ee.ToString()); }
                }
            }

            ip = NCLink.IP;
            Table = temp;
        }

        public void Stop()
        {
            model.Stop();
            Selectitem = false;
            
            foreach (item_data a in Table)
            {
                a.stop_method.Invoke(a.instance, new object[] { });
            }
        }

        private void model_change(string name)
        {
            NotifyPropertyChanged(name);
        }

        private int[] check_location(int x, int y)
        {
            bool flag = false;
            int x_start = 0, y_start = 0, x_ind = 0, y_ind = 0, size = 0;

            while (!flag)
            {
                if (((x_start + x_ind) < 5) && ((y_start + y_ind) < 5))
                {
                    if(have_item[(y_start + y_ind), (x_start + x_ind)] == false)
                    {
                        if(x_ind < x)
                        {
                            x_ind++;
                            size++;
                        }
                        
                        if (x_ind == x)
                        {
                            y_ind++;

                            if (size == x * y) flag = true;

                            x_ind = 0;
                        }  
                    }
                    else
                    {
                        size = 0;
                        x_ind = y_ind = 0;

                        if ((x_start >= 4) && (y_start >= 4))
                        {
                            return new int[2] { 99, 99 };
                        }
                        else if(x_start != 4)
                        {
                            x_start++;
                        }
                        else
                        {
                            x_start = 0;
                            y_start++;
                        }
                    }
                }
                else if ((x_start >= 4) && (y_start >= 4))
                {
                    return new int[2] { 99, 99 };
                }
                else if ((x_start + x_ind) >= 5)
                {
                    x_ind = y_ind = 0;
                    if (size == 0) x_start = 0;
                    else size = 0;
                    y_start++;
                }
                else if ((y_start + y_ind) >= 5)
                {
                    if (y_start > 4) return new int[2] { 99, 99 };
                    x_ind = y_ind = 0;
                    if(size == 0) y_start = 0;
                    else size = 0;
                    x_start++;
                }
            }

            for (int i = y_start; i < y + y_start; i++)
            {
                for (int j = x_start; j < x + x_start; j++)
                {
                    have_item[i, j] = true;
                }
            }
            
            return new int[2] { x_start, y_start };
        }        

        public void add_click()
        {
            try
            {
                Selectitem = !selectitem_p;
                down_flag = false;
                Mouse_vis = Visibility.Collapsed;

                var temp = new List<item_data>();
                for (int i = 0; i < Table.Count; i++)
                {
                    temp.Add(Table[i]);
                }

                model.Back0 = Brushes.Transparent;
                model.Back1 = Brushes.Transparent;
                model.Back2 = Brushes.Transparent;
                model.Back3 = Brushes.Transparent;
                model.Back4 = Brushes.Transparent;
                model.Back5 = Brushes.Transparent;
                model.Back6 = Brushes.Transparent;
                model.Back7 = Brushes.Transparent;
                model.Back8 = Brushes.Transparent;
                model.Back9 = Brushes.Transparent;
                model.Back10 = Brushes.Transparent;
                model.Back11 = Brushes.Transparent;
                model.Back12 = Brushes.Transparent;
                model.Back13 = Brushes.Transparent;
                model.Back14 = Brushes.Transparent;
                model.Back15 = Brushes.Transparent;

                if (Selectitem)
                {
                    Scr_vis = Visibility.Collapsed;
                    Set_scr_vis = Visibility.Visible;
                    foreach (item_data a in temp)
                    {
                        a.Set_vis = Visibility.Visible;
                        a.stop_method.Invoke(a.instance, new object[] { });

                        switch (a.item_uid)
                        {
                            case "0":
                                model.Back0 = new SolidColorBrush(Color.FromArgb(0x7F,0xC0, 0x7A, 0xB8));
                                break;
                            case "1":
                                model.Back1 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "2":
                                model.Back2 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "3":
                                model.Back3 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "4":
                                model.Back4 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "5":
                                model.Back5 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "6":
                                model.Back6 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "7":
                                model.Back7 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "8":
                                model.Back8 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "9":
                                model.Back9 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "10":
                                model.Back10 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "11":
                                model.Back11 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "12":
                                model.Back12 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "13":
                                model.Back13 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "14":
                                model.Back14 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                            case "15":
                                model.Back15 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                                break;
                        }
                    }
                }
                else
                {
                    Scr_vis = Visibility.Visible;
                    Set_scr_vis = Visibility.Collapsed;
                    foreach (item_data a in temp)
                    {
                        a.Set_vis = Visibility.Collapsed;
                        a.start_method.Invoke(a.instance, new object[] { });
                    }
                }

                Table = temp;
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }
        }

        private int get_wid(int x)
        {
            return (int)Math.Round((204.8 * x) - 6);
        }

        private int get_hei(int y)
        {
            return (int)Math.Round((126.8 * y) - 31.36);
        }

        public void mouseup(object sender, EventArgs e)
        {
            foreach(item_data a in Table)
            {
                if (a.item_uid == (sender as UIElement).Uid)
                {
                    messageview.Show(model.Already);
                    return;
                }
            }

            int load_idx = Convert.ToInt16((sender as UIElement).Uid);
            System.Windows.Forms.UserControl instan;
            var temp = new List<item_data>();

            for (int i = 0; i < Table.Count; i++ )
            {
                temp.Add(Table[i]);
            }

            int[] location = check_location(model.Loadapp[load_idx].x, model.Loadapp[load_idx].y);

            if (location[0] == 99)
            {
                messageview.Show(model.Nospace);
                return;
            }
            try
            {
                Assembly assembly = Assembly.LoadFrom(model.Loadapp[load_idx].assembly);
                Type type = assembly.GetType(model.Loadapp[load_idx].type);

                if (model.Loadapp[load_idx].nc) instan = Activator.CreateInstance(type, new object[] { NCLink }) as System.Windows.Forms.UserControl;
                else instan = Activator.CreateInstance(type) as System.Windows.Forms.UserControl;
                
                var ff = new System.Windows.Forms.Integration.WindowsFormsHost()
                {
                    Width = get_wid(model.Loadapp[load_idx].x),
                    Height = get_hei(model.Loadapp[load_idx].y),
                    Child = instan
                };

                var tey = type.GetMethods();
                temp.Add(new item_data()
                {
                    row = location[1],rowspan = model.Loadapp[load_idx].y,
                    col = location[0],colspan = model.Loadapp[load_idx].x,
                    Scr = new Canvas() { Margin = new Thickness(0, 3, 0, 0) },
                    item_uid = (sender as UIElement).Uid,
                    item_title = model.Loadapp[load_idx].title,
                    title_width = get_wid(model.Loadapp[load_idx].x),
                    title_height = get_hei(model.Loadapp[load_idx].y),
                    border_height = get_hei(model.Loadapp[load_idx].y) - 3,
                    start_method = type.GetMethods()[0],stop_method = type.GetMethods()[1],instance = instan
                });

                temp[temp.Count - 1].Scr.Children.Add(ff);
                temp[temp.Count - 1].Scr.MouseUp += move_up;
                temp[temp.Count - 1].close_click += close_in_viewmodel;
                temp[temp.Count - 1].mousemovedown += move_down;
                temp[temp.Count - 1].mousemoveup += move_up;

                switch ((sender as UIElement).Uid)
                {	
                    case "0":
                        model.Back0 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "1":
                        model.Back1 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "2":
                        model.Back2 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "3":
                        model.Back3 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "4":
                        model.Back4 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "5":
                        model.Back5 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "6":
                        model.Back6 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "7":
                        model.Back7 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "8":
                        model.Back8 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "9":
                        model.Back9 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "10":
                        model.Back10 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "11":
                        model.Back11 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "12":
                        model.Back12 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "13":
                        model.Back13 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "14":
                        model.Back14 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                    case "15":
                        model.Back15 = new SolidColorBrush(Color.FromArgb(0x7F, 0xC0, 0x7A, 0xB8));
                        break;
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }

            model.write_table(load_idx, location[0], location[1]);
            Table = temp;
        }

        public void close_in_viewmodel(object sender, EventArgs e)
        {
            down_flag = false;
            Mouse_vis = Visibility.Collapsed;
            try
            {
                List<item_data> temp = new List<item_data>();                

                foreach (item_data da in Table)
                {
                    temp.Add(da);
                }

                for (int i = 0; i < Table.Count; i++)
                {
                    if (temp[i].item_uid == (sender as UIElement).Uid)
                    {
                        model.delete(Convert.ToInt16(temp[i].item_uid));
                        temp[i].instance = null;

                        for (int ii = temp[i].row; ii < temp[i].rowspan + temp[i].row; ii++)
                        {
                            for (int jj = temp[i].col; jj < temp[i].colspan + temp[i].col; jj++)
                            {
                                have_item[ii, jj] = false;
                            }
                        }

                        temp.RemoveAt(i); 
                        Table = temp;

                        switch ((sender as UIElement).Uid)
                        {
                            case "0":
                                model.Back0 = Brushes.Transparent;
                                break;
                            case "1":
                                model.Back1 = Brushes.Transparent;
                                break;
                            case "2":
                                model.Back2 = Brushes.Transparent;
                                break;
                            case "3":
                                model.Back3 = Brushes.Transparent;
                                break;
                            case "4":
                                model.Back4 = Brushes.Transparent;
                                break;
                            case "5":
                                model.Back5 = Brushes.Transparent;
                                break;
                            case "6":
                                model.Back6 = Brushes.Transparent;
                                break;
                            case "7":
                                model.Back7 = Brushes.Transparent;
                                break;
                            case "8":
                                model.Back8 = Brushes.Transparent;
                                break;
                            case "9":
                                model.Back9 = Brushes.Transparent;
                                break;
                            case "10":
                                model.Back10 = Brushes.Transparent;
                                break;
                            case "11":
                                model.Back11 = Brushes.Transparent;
                                break;
                            case "12":
                                model.Back12 = Brushes.Transparent;
                                break;
                            case "13":
                                model.Back13 = Brushes.Transparent;
                                break;
                            case "14":
                                model.Back14 = Brushes.Transparent;
                                break;
                            case "15":
                                model.Back15 = Brushes.Transparent;
                                break;
                        }
                        break;
                    }
                }                
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }
        }

        public void move_down(object sender, EventArgs e)
        {
            down_flag = true;    

            for (int i = 0; i < Table.Count; i++)
            {
                if (Table[i].item_uid == (sender as UIElement).Uid)
                {
                    move_index = i;
                    Mouse_vis = Visibility.Visible;
                    Mouse_he = Table[i].title_height - 10;
                    Mouse_wi = Table[i].title_width - 20;
                    Mouse_row = Table[i].row;
                    Mouse_col = Table[i].col;
                    Mouse_colspan = Table[i].colspan;
                    Mouse_rowspan = Table[i].rowspan;
                    break;
                }
            }

            for (int i = Table[move_index].row; i < Table[move_index].rowspan + Table[move_index].row; i++)
            {
                for (int j = Table[move_index].col; j < Table[move_index].colspan + Table[move_index].col; j++)
                {
                    have_item[i, j] = false;
                }
            }
        }

        public void move_up(object sender, EventArgs e)
        {
            if (Table.Count == 0) return;
            if (down_flag == false) return;

            Mouse_vis = Visibility.Collapsed;
            down_flag = false;
            model.move_modify(Table[move_index].item_uid, Table[move_index].col, Table[move_index].row);

            for (int i = Table[move_index].row; i < Table[move_index].rowspan + Table[move_index].row; i++)
            {
                for (int j = Table[move_index].col; j < Table[move_index].colspan + Table[move_index].col; j++)
                {
                    have_item[i, j] = true;
                }
            }
        }

        public void move_move(object sender, EventArgs e)
        {
            if (!down_flag) return;

            if(down_flag)
            {
                Point p = Mouse.GetPosition((UIElement)sender);
                List<item_data> temp = new List<item_data>();
                int check_x, check_y;

                foreach (item_data da in Table)
                {
                    temp.Add(da);
                }

                double temp_x = p.X;
                temp_x = (int)(temp_x / 204.8);
                if (temp_x > 4) temp_x = 4;
                if (temp_x + temp[move_index].colspan <= 4)
                {
                    check_x = (int)temp_x;
                }
                else
                {
                    check_x = 5 - temp[move_index].colspan;
                }

                double temp_y = p.Y;
                temp_y = (int)(temp_y / 126.8);
                if (temp_y > 4) temp_y = 4;
                if (temp_y + temp[move_index].rowspan <= 4)
                {
                    check_y = (int)temp_y;
                }
                else
                {
                    check_y = 5 - temp[move_index].rowspan;
                }

                Mouse_col = check_x;
                Mouse_row = check_y;

                if(can_move(check_x, check_y, temp[move_index]))
                {
                    temp[move_index].col = check_x;
                    temp[move_index].row = check_y;
                    Mouse_color = new SolidColorBrush(Color.FromArgb(128, 143, 195, 31));
                }
                else
                {
                    Mouse_color = new SolidColorBrush(Color.FromArgb(128, 176, 53, 4));
                }

                Table = temp;
            }
        }

        private bool can_move(int check_x, int check_y, item_data item)
        {
            for (int x_ind = 0; x_ind < item.colspan; x_ind++)
            {
                for (int y_ind = 0; y_ind < item.rowspan; y_ind++)
                {
                    if (have_item[check_y + y_ind, check_x + x_ind] == true) return false;
                }
            }

            return true;
        }    
    }
}
