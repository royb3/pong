﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf_Pong
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        #region Field Region

        int totalPlayers;
        Thread Tloop;

        #endregion

        #region Constructor Region

        public Lobby()
        {
            InitializeComponent();

            btnCreate.Click += btnCreate_Click;
            this.Closing += Lobby_Closing;
            this.Loaded += Lobby_Loaded;

            
            Refresh();     
        }

        void Lobby_Loaded(object sender, RoutedEventArgs e)
        {
            Tloop = new Thread(new ThreadStart(loop));
            Tloop.Start();
        }

        void Lobby_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Tloop.Abort();
        }

        void loop()
        {
            while (true)
            {
                lblUsername.Dispatcher.Invoke(new Action(() =>
                {
                    lblUsername.Content = "There are " + Socket.playerlist.Count() + " players connected.";
                    lblRecentMessage.Content = Socket.recentMessage;
                }));
                Thread.Sleep(1000);
            }
        }

        #endregion

        #region Event Region

        void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (rbPlayers2.IsChecked == true)
                totalPlayers = 2;
            else if (rbPlayers3.IsChecked == true)
                totalPlayers = 3;
            else if (rbPlayers4.IsChecked == true)
                totalPlayers = 4;
            if (tbRoomName.Text.Length <= 3)
                MessageBox.Show("Gameroom name is too short!", "Notification");
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to make a room?\nName: " + tbRoomName.Text + "\nPlayers: " + totalPlayers + "", "Notification", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    GameRoom groom = new GameRoom(/*aantal players, naam*/);
                    this.Close();
                    groom.Show();
                }
            }
        }

        #endregion

        #region Method region

        void Refresh()
        {
            GRoomNotification.Visibility = System.Windows.Visibility.Visible;
            if (lvRooms.HasItems)
                GRoomNotification.Visibility = System.Windows.Visibility.Hidden;
            
        }

        #endregion
    }
}
