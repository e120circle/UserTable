using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace usertable_wpf.Viewmodel
{
    class feed1_1_viewmodel : INotifyPropertyChanged
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        internal feed1_1_viewmodel(NCLinker2.NCLinker2 NC)
        {
            model = new Model.feed1_1_model(NC);
            model.change += model_change;
        }
        
        private Model.feed1_1_model model;

        public string Rpm { get { return model.Rpm; } }
        public string Sunit { get { return model.Sunit; } }
        public string Feed { get { return model.Feed; } }
        public string Funit { get { return model.Funit; } }

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
            NotifyPropertyChanged(name);
        }
    }    
}
