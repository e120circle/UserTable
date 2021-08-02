using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace usertable_wpf.Viewmodel
{
    class ACHead_viewmodel : INotifyPropertyChanged
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        internal ACHead_viewmodel(NCLinker2.NCLinker2 NC)
        {
            model = new Model.ACHead_model(NC);
            model.change += model_change;
        }

        private Model.ACHead_model model;

        public string Ahead { get { return model.Ahead; } }
        public string Chead { get { return model.Chead; } }

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
