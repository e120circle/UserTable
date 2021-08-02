using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows;

namespace usertable_wpf.Viewmodel
{
    class mach_viewmodel : INotifyPropertyChanged
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        internal mach_viewmodel(NCLinker2.NCLinker2 NC)
        {
            model = new Model.mach_model(NC);     
            model.change += model_change;

            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(100);
            timer1.Tick += timer1_Tick;
        }
        
        private Model.mach_model model;

        private DispatcherTimer timer1;

        public FontFamily Font { get { return model.Font; } }
        public string Mach_x { get { return model.Mach_x; } }
        public string Mach_y { get { return model.Mach_y; } }
        public string Mach_z { get { return model.Mach_z; } }
        public string Mach_a { get { return model.Mach_a; } }
        public string Mach_c { get { return model.Mach_c; } }        
        public string Work_x { get { return model.Work_x; } }
        public string Work_y { get { return model.Work_y; } }
        public string Work_z { get { return model.Work_z; } }
        public string Work_a { get { return model.Work_a; } }
        public string Work_c { get { return model.Work_c; } }        
        public string Mach_coor { get { return model.Mach_coor; } }
        public string Work_coor { get { return model.Work_coor; } }
        public string A1 { get { if (model.axis_name.Length >= 1) return model.axis_name[0]; else return "??"; } }
        public string A2 { get { if (model.axis_name.Length >= 2) return model.axis_name[1]; else return "??"; } }
        public string A3 { get { if (model.axis_name.Length >= 3) return model.axis_name[2]; else return "??"; } }
        public string A4 { get { if (model.axis_name.Length >= 4) return model.axis_name[3]; else return "??"; } }
        public string A5 { get { if (model.axis_name.Length >= 5) return model.axis_name[4]; else return "??"; } }
        public string B1 { get { if (model.axis_name.Length >= 1) return model.axis_name[0]; else return "??"; } }
        public string B2 { get { if (model.axis_name.Length >= 2) return model.axis_name[1]; else return "??"; } }
        public string B3 { get { if (model.axis_name.Length >= 3) return model.axis_name[2]; else return "??"; } }
        public string B4 { get { if (model.axis_name.Length >= 4) return model.axis_name[3]; else return "??"; } }
        public string B5 { get { if (model.axis_name.Length >= 5) return model.axis_name[4]; else return "??"; } }

        private Brush mach_color_p;
        public Brush Mach_color 
        {
            get { return mach_color_p; }
            set { mach_color_p = value; NotifyPropertyChanged("Mach_color"); } 
        }

        private Brush work_color_p;
        public Brush Work_color 
        {
            get { return work_color_p; }
            set { work_color_p = value; NotifyPropertyChanged("Work_color"); }
        }

        private Visibility a4_vis_p = Visibility.Collapsed;
        public Visibility A4_vis
        {
            get { return a4_vis_p; }
            set { a4_vis_p = value; NotifyPropertyChanged("A4_vis"); }
        }

        private Visibility a5_vis_p = Visibility.Collapsed;
        public Visibility A5_vis
        {
            get { return a5_vis_p; }
            set { a5_vis_p = value; NotifyPropertyChanged("A5_vis"); }
        }

        private Visibility b4_vis_p = Visibility.Collapsed;
        public Visibility B4_vis
        {
            get { return b4_vis_p; }
            set { b4_vis_p = value; NotifyPropertyChanged("B4_vis"); }
        }

        private Visibility b5_vis_p = Visibility.Collapsed;
        public Visibility B5_vis
        {
            get { return b5_vis_p; }
            set { b5_vis_p = value; NotifyPropertyChanged("B5_vis"); }
        }

        public void Start()
        {
            model.Start();
            A4_vis = (model.axis_name.Length >= 4) ? Visibility.Visible : Visibility.Collapsed;
            A5_vis = (model.axis_name.Length == 5) ? Visibility.Visible : Visibility.Collapsed;
            B4_vis = (model.axis_name.Length >= 4) ? Visibility.Visible : Visibility.Collapsed;
            B5_vis = (model.axis_name.Length == 5) ? Visibility.Visible : Visibility.Collapsed;
            timer1.Start();
        }

        public void Stop()
        {
            model.Stop();
            timer1.Stop();
        }

        private void model_change(string name)
        {
            NotifyPropertyChanged(name);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (model.err1 == 0) Mach_color = new SolidColorBrush(Color.FromRgb(49,49,49));
            else Mach_color = new SolidColorBrush(Color.FromRgb(176, 53, 47));

            if (model.err2 == 0) Work_color = new SolidColorBrush(Color.FromRgb(49, 49, 49));
            else Work_color = new SolidColorBrush(Color.FromRgb(176, 53, 47));

            timer1.Start();
        }
    }   
}
