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
            Boolean debug = false;
            Boolean canConnect = Socket.StartConnection("http://127.0.0.1:2525");
            if (!canConnect && !debug)
            {
                MessageBox.Show("Server is offline", "Connection error.", MessageBoxButton.OK,MessageBoxImage.Information);
                Environment.Exit(1);
            }

        }
    }
}
