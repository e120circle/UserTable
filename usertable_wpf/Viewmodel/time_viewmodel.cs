using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows.Media;

namespace usertable_wpf.Viewmodel
{
    class time_viewmodel : INotifyPropertyChanged
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        internal time_viewmodel()
        {
            model = new Model.time_model();

            model.change += model_change;
        }

        internal delegate void vm_change(string time);

        internal vm_change change;

        private Model.time_model model;

        private Brush am_p = new SolidColorBrush(Color.FromArgb(64, 147, 20, 115));
        public Brush Am
        {
            get { return am_p; }
            set { am_p = value; NotifyPropertyChanged("Am"); }
        }

        private Brush pm_p = new SolidColorBrush(Color.FromArgb(64, 147, 20, 115));
        public Brush Pm
        {
            get { return pm_p; }
            set { pm_p = value; NotifyPropertyChanged("Pm"); }
        }
        
        public void Start()
        {
            model.Start();
        }

        public void Stop()
        {
            model.Stop();
        }

        private void model_change(string name)
        {
            if (name == "time")
            {
                if (model.time.Split(':')[3] == "AM")
                {
                    Am = new SolidColorBrush(Color.FromArgb(255, 147, 20, 115));
                    Pm = new SolidColorBrush(Color.FromArgb(64, 147, 20, 115));
                }
                else
                {
                    Am = new SolidColorBrush(Color.FromArgb(64, 147, 20, 115));
                    Pm = new SolidColorBrush(Color.FromArgb(255, 147, 20, 115));
                }

                change(model.time);
            }
            else
            {
                NotifyPropertyChanged(name);
            }
        }
    }
}
