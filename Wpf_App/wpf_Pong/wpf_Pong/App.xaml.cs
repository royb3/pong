﻿using System;
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
<<<<<<< HEAD
        public static Boolean noServer = false;
=======
        public static Boolean noServer = true;
>>>>>>> Added gameroom
        public static Boolean quickLogin = true;

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
