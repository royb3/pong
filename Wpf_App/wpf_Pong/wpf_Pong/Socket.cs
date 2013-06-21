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

        public static string Username;
        public static string[] playerlist;
         /* zo verzend je iets 
            socket.client.Emit("naam van item", "item");
        */

        public static Boolean StartConnection(string Ip)
        {
            client = new Client(Ip);
            // maak de on receve handlers
            client.On("send_broadcast", (data) =>
            {
                MessageBox.Show(data.ToString());
            });

            // on receave somthing
            client.On("somthing", (data) =>
            {
                
            });

            client.On("addplayer", (data) =>
                {
                    playerlist = data.Json.Args[0];

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
