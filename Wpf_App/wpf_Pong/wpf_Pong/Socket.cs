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
        public static Client client;

        public static string recentPlayerOnline;
        public static string recentPlayerOffline;
        public static string recentMessage;

        public static List<string> playerlist;

        public static Boolean StartConnection(string Ip)
        {
            client = new Client(Ip);
            // maak de on receive handlers
            client.On("send_broadcast", (data) =>
            {
                MessageBox.Show(data.ToString());
            });


            client.On("delplayer", (data) =>
                {
                    recentPlayerOffline = data.Json.Args[1];
                    recentMessage = recentPlayerOffline + " went offline.";
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
                    recentMessage = recentPlayerOnline + " is online.";
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
    }
}
