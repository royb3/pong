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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();

            this.Closing += Game_Closing;
            
        }

        

        void Game_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("You're leaving the room!\nAre you sure?", "Notification", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.OK)
            {
                Lobby lob = new Lobby();
                lob.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
