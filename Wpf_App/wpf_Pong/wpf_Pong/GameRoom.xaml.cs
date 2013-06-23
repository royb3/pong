using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for GameRoom.xaml
    /// </summary>
    public partial class GameRoom : Window
    {
        public GameRoom()
        {
            InitializeComponent();

            this.Closing += GameRoom_Closing;
            this.BTN_Cancel.Click += Cancel;
            this.BTN_CreateRoom.Click += CreateRoom;

            this.TB_GameRoomName.Focus();
        }

        void GameRoom_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Lobby lob = new Lobby();
            lob.Show();
        }

        void Cancel(object s, EventArgs e)
        {
            this.Close();
        }

        void CreateRoom(object s, EventArgs e)
        {
            string roomname = this.TB_GameRoomName.Text;
            int players = 0;

            if (this.RB_Players_2.IsChecked == true)
                players = 2;
            if (this.RB_Players_3.IsChecked == true)
                players = 3;
            if (this.RB_Players_4.IsChecked == true)
                players = 4;

            Game g = new Game();
            g.Show();
        }
    }
}
