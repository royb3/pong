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
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        #region Field Region

        int totalPlayers;

        #endregion

        #region Constructor Region

        public Lobby()
        {
            InitializeComponent();
            btnCreate.Click += btnCreate_Click;
        }  

        #endregion

        #region Method region

        void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (rbPlayers2.IsChecked == true)
                totalPlayers = 2;
            else if (rbPlayers3.IsChecked == true)
                totalPlayers = 3;
            else if (rbPlayers4.IsChecked == true)
                totalPlayers = 4;
            if(tbRoomName.Text.Length <= 3)
                MessageBox.Show("Gameroom name is too short!", "Notification");
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to make a room?\nName: " + tbRoomName.Text + "\nPlayers: " + totalPlayers + "", "Notification", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Game game = new Game(/*aantal players, naam*/);
                    this.Close();
                    game.Show();
                }
            }
        }

        #endregion
    }
}
