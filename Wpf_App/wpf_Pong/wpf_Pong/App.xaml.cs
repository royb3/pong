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
            Boolean debug = true;
            Boolean canConnect = Socket.StartConnection("http://vincentict.mine.nu:2525");
            if (!canConnect && !debug)
            {
                MessageBox.Show("connection error");
                Environment.Exit(1);
            }

        }
    }
}
