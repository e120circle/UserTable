using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace usertable_form
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }
              
        }
    }
}
