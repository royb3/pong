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
        public static Boolean noServer = true;
        public static Boolean quickLogin = false;

        public App()
        {
            Socket sock = new Socket();
            Boolean canConnect = sock.StartConnection("http://127.0.0.1:2525");
            if (!canConnect && !noServer)
            {
                MessageBox.Show("Server is offline", "Connection error.", MessageBoxButton.OK,MessageBoxImage.Information);
                Environment.Exit(1);
            }
            this.Exit += App_Exit;

        }

        void App_Exit(object sender, ExitEventArgs e)
        {
            Socket.client.Emit("dc", "dc");
            Socket.client.Close();
        }
    }
}
