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

            client.On("ifUsernameExist", (data) =>
                {

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
