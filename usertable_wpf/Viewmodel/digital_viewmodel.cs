using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;

namespace usertable_wpf.Viewmodel
{
    class digital_viewmodel : INotifyPropertyChanged
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        private Visibility a_p = Visibility.Collapsed;
        public Visibility A
        {
            get { return a_p; }
            set { a_p = value; NotifyPropertyChanged("A"); }
        }

        private Visibility b_p = Visibility.Collapsed;
        public Visibility B
        {
            get { return b_p; }
            set { b_p = value; NotifyPropertyChanged("B"); }
        }

        private Visibility c_p = Visibility.Collapsed;
        public Visibility C
        {
            get { return c_p; }
            set { c_p = value; NotifyPropertyChanged("C"); }
        }

        private Visibility d_p = Visibility.Collapsed;
        public Visibility D
        {
            get { return d_p; }
            set { d_p = value; NotifyPropertyChanged("D"); }
        }

        private Visibility e_p = Visibility.Collapsed;
        public Visibility E
        {
            get { return e_p; }
            set { e_p = value; NotifyPropertyChanged("E"); }
        }

        private Visibility f_p = Visibility.Collapsed;
        public Visibility F
        {
            get { return f_p; }
            set { f_p = value; NotifyPropertyChanged("F"); }
        }

        private Visibility g_p = Visibility.Collapsed;
        public Visibility G
        {
            get { return g_p; }
            set { g_p = value; NotifyPropertyChanged("G"); }
        }

        private Visibility h_p = Visibility.Collapsed;
        public Visibility H
        {
            get { return h_p; }
            set { h_p = value; NotifyPropertyChanged("H"); }
        }

        internal void show(int n)
        {
            switch (n)
            {
                case 0:
                    A = Visibility.Visible;
                    B = Visibility.Visible;
                    C = Visibility.Visible;
                    D = Visibility.Visible;
                    E = Visibility.Visible;
                    F = Visibility.Visible;
                    G = Visibility.Collapsed;
                    H = Visibility.Collapsed;
                    break;
                case 1:
                    A = Visibility.Collapsed;
                    B = Visibility.Visible;
                    C = Visibility.Visible;
                    D = Visibility.Collapsed;
                    E = Visibility.Collapsed;
                    F = Visibility.Collapsed;
                    G = Visibility.Collapsed;
                    H = Visibility.Collapsed;
                    break;
                case 2:
                    A = Visibility.Visible;
                    B = Visibility.Visible;
                    C = Visibility.Collapsed;
                    D = Visibility.Visible;
                    E = Visibility.Visible;
                    F = Visibility.Collapsed;
                    G = Visibility.Visible;
                    H = Visibility.Collapsed;
                    break;
                case 3:
                    A = Visibility.Visible;
                    B = Visibility.Visible;
                    C = Visibility.Visible;
                    D = Visibility.Visible;
                    E = Visibility.Collapsed;
                    F = Visibility.Collapsed;
                    G = Visibility.Visible;
                    H = Visibility.Collapsed;
                    break;
                case 4:
                    A = Visibility.Collapsed;
                    B = Visibility.Visible;
                    C = Visibility.Visible;
                    D = Visibility.Collapsed;
                    E = Visibility.Collapsed;
                    F = Visibility.Visible;
                    G = Visibility.Visible;
                    H = Visibility.Collapsed;
                    break;
                case 5:
                    A = Visibility.Visible;
                    B = Visibility.Collapsed;
                    C = Visibility.Visible;
                    D = Visibility.Visible;
                    E = Visibility.Collapsed;
                    F = Visibility.Visible;
                    G = Visibility.Visible;
                    H = Visibility.Collapsed;
                    break;
                case 6:
                    A = Visibility.Visible;
                    B = Visibility.Collapsed;
                    C = Visibility.Visible;
                    D = Visibility.Visible;
                    E = Visibility.Visible;
                    F = Visibility.Visible;
                    G = Visibility.Visible;
                    H = Visibility.Collapsed;
                    break;
                case 7:
                    A = Visibility.Visible;
                    B = Visibility.Visible;
                    C = Visibility.Visible;
                    D = Visibility.Collapsed;
                    E = Visibility.Collapsed;
                    F = Visibility.Collapsed;
                    G = Visibility.Collapsed;
                    H = Visibility.Collapsed;
                    break;
                case 8:
                    A = Visibility.Visible;
                    B = Visibility.Visible;
                    C = Visibility.Visible;
                    D = Visibility.Visible;
                    E = Visibility.Visible;
                    F = Visibility.Visible;
                    G = Visibility.Visible;
                    H = Visibility.Collapsed;
                    break;
                case 9:
                    A = Visibility.Visible;
                    B = Visibility.Visible;
                    C = Visibility.Visible;
                    D = Visibility.Visible;
                    E = Visibility.Collapsed;
                    F = Visibility.Visible;
                    G = Visibility.Visible;
                    H = Visibility.Collapsed;
                    break;
            }
        }
    }
}
