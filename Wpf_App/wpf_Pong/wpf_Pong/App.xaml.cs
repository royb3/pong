using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace wpf_Pong
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Boolean canConnect = Socket.StartConnection("http://127.0.0.1:2525");
            if (!canConnect)
            {
                MessageBox.Show("connection error");
            }

        }
    }
}
