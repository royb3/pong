using System;
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

        public static event EventHandler GotMessage;

        Thread Tloop;
        Thread RecentMessageT;

        private static string tmp = "";
        public static string LobbyMessage
        {
            get { return Lobby.tmp; }
            set
            {
                Lobby.tmp = value;
                if (Lobby.GotMessage != null)
                    Lobby.GotMessage(Lobby.tmp, new EventArgs());
            }
        }
        
        
        bool superBreak = false;

        #endregion

        #region Constructor Region

        public Lobby()
        {
            InitializeComponent();

            btnCreate.Click += btnCreate_Click;
            this.Closing += Lobby_Closing;
            this.Loaded += Lobby_Loaded;
            tbChat.KeyUp += tbChat_KeyUp;

            GotMessage += Lobby_GotMessage;

            lbChat.Items.Add("U can talk with other online people.");

            Refresh();     
        }

        void Lobby_GotMessage(object sender, EventArgs e)
        {
            lbChat.Dispatcher.Invoke(new Action(() =>
                   {
                       lbChat.Items.Add(sender);
                       
                   }));
        }

        

        void loop()
        {
            if (!App.noServer)
            {
                RecentMessageT = new Thread(new ThreadStart(RecentMessage));
                RecentMessageT.Start();
                while (true)
                {
                    lblUsername.Dispatcher.Invoke(new Action(() =>
                    {
                        lblUsername.Content = "There are " + Socket.playerlist.Count() + " players online.";
                        
                    }));
                    Thread.Sleep(1000);
                    if (superBreak)
                        break;
                }
            }
        }

        void RecentMessage()
        {
            string tmp = "";
            while (true)
            {             
                lblRecentMessage.Dispatcher.Invoke(new Action(() =>
                    {
                        if (tmp != Socket.RecentMessage)
                        {
                            tmp = Socket.RecentMessage;
                            lblRecentMessage.Content = Socket.RecentMessage;
                        }
                        else
                        {
                            lblRecentMessage.Content = "";
                        }
                    }));
                Thread.Sleep(2500);
                if (superBreak)
                    break;
            }
        }

        #endregion

        #region Event Region

        void tbChat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string tmp = tbChat.Text;
                if (tmp != "")
                {
                    SendMessage(tmp);
                    tbChat.Text = "";
                }
            }
        }

        void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            GameRoom gr = new GameRoom();
            gr.Show();
            this.Hide();
            /*if (rbPlayers2.IsChecked == true)
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
                    //GameRoom groom = new GameRoom();
                    //this.Close();
                    //groom.Show();
                }
            }*/
        }
        
        void Lobby_Loaded(object sender, RoutedEventArgs e)
        {
            Tloop = new Thread(new ThreadStart(loop));
            Tloop.Start();
        }

        void Lobby_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RecentMessageT.Abort();
            Tloop.Abort();
            superBreak = true;
            Environment.Exit(1);
        }

        #endregion

        #region Method region

        void Refresh()
        {
            GRoomNotification.Visibility = System.Windows.Visibility.Visible;
            if (lvRooms.HasItems)
                GRoomNotification.Visibility = System.Windows.Visibility.Hidden;
            
        }

        void SendMessage(string message)
        {
            Socket.client.Emit("chatLobbyMessage", message);
        }

        public void addMessage(string message)
        {
            lbChat.Items.Add(message);
        }


        #endregion
    }
}
