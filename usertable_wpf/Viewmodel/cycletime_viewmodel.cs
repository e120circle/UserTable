using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace usertable_wpf.Viewmodel
{
    class cycletime_viewmodel: INotifyPropertyChanged
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        internal cycletime_viewmodel(NCLinker2.NCLinker2 NC)
        {
            model = new Model.cycletime_model(NC);

            model.change += model_change;
        }

        internal delegate void vm_change(string time);

        internal event vm_change change;

        private Model.cycletime_model model;

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
                change(model.time);
            }
            else
            {
                NotifyPropertyChanged(name);
            }
        }
    }
}
