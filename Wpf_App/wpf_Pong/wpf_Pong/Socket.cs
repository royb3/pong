using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SocketIOClient;

namespace wpf_Pong
{
    class Socket
    {
        #region Evenhandler Region

        public static event EventHandler GotMessage;

        #endregion

        #region Field region
        public static Client client;

        private static string recentPlayerOnline;
        private static string recentPlayerOffline;
        private static string recentMessage;

        public static List<string> playerlist;


        public static string RecentMessage
        {
            get { return Socket.recentMessage; }
            set
            {
                Socket.recentMessage = value;
                if (Socket.GotMessage != null)
                    Socket.GotMessage(RecentMessage, new EventArgs());
            }
        }
        #endregion

        #region Socket region

        public Boolean StartConnection(string Ip)
        {
            Lobby lob = new Lobby();
            client = new Client(Ip);
            // maak de on receive handlers
            client.On("send_broadcast", (data) =>
            {
                MessageBox.Show(data.ToString());
            });

            client.On("newlobbymessage", (data) =>
                {
                    string tmpFrom = data.Json.Args[0];
                    string tmpMessage = data.Json.Args[1];
                    Lobby.LobbyMessage = tmpFrom + " - " + tmpMessage;
                });

            client.On("delplayer", (data) =>
                {
                    recentPlayerOffline = data.Json.Args[1];
                    RecentMessage = recentPlayerOffline + " went offline.";
                    playerlist = new List<string>();
                    for (int i = 0; i < data.Json.Args[0].Count; i++)
                    {
                        string tmp = data.Json.Args[0][i];
                        playerlist.Add(tmp);
                    }
                });

            client.On("addplayer", (data) =>
                {
                    recentPlayerOnline = data.Json.Args[1];
                    RecentMessage = recentPlayerOnline + " is online.";
                    playerlist = new List<string>();
                    for (int i = 0; i < data.Json.Args[0].Count; i++)
                    {
                        string tmp = data.Json.Args[0][i];
                        playerlist.Add(tmp);
                    }
                });

            //start de connectie
            client.Connect();

            for (int i = 0; i < 100; i++)
            {
                if (client.IsConnected)
                    return true;
                Thread.Sleep(10);
            }
            return false;
        }
        #endregion
    }
}
