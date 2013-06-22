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
        }

        void GameRoom_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Lobby lob = new Lobby();
            lob.Show();
        }
    }
}
