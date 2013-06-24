using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_Pong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Field region

        Lobby lob;
        PropertiesFile pf = new PropertiesFile(Environment.SpecialFolder.ApplicationData + "\\Pong\\", "Pong.config");
      
        #endregion

        #region Constructor Region

        public MainWindow()
        {
            InitializeComponent();

            lob = new Lobby();

            #region Create Events

            btnLogin.Click += btnLogin_Click;

            tbName.Focus();
            
            #endregion
            
            #region debug check

            if (App.quickLogin)
            {
                tbName.Text = "Debug User";
                btnLogin_Click(null, null);
            }

            #endregion

        }

        
 
        #endregion

        #region Event region

        void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length >= 3)
            {
                Socket.client.Emit("playerlist", null);
                while (!Socket.playerListIsBuild)
                {
                    tbName.Visibility = System.Windows.Visibility.Hidden;
                    btnLogin.Visibility = System.Windows.Visibility.Hidden;
                    lblUsername.Visibility = System.Windows.Visibility.Hidden;
                    lblNotification.Visibility = System.Windows.Visibility.Visible;
                    lblNotification.Content = "Fetching playerlist.";
                    
                }
                if (!Socket.playerlist.Contains(tbName.Text.ToString()))
                {
                    Socket.client.Emit("initializeplayer", tbName.Text);
                    this.Close();
                    MessageBox.Show("Welcome " + tbName.Text + "!", "Welcome");
                    lob.Show();
                }
                else
                {
                    MessageBox.Show("Playername already exists", "Error!");
                    lblNotification.Visibility = System.Windows.Visibility.Hidden;
                    tbName.Visibility = System.Windows.Visibility.Visible;
                    btnLogin.Visibility = System.Windows.Visibility.Visible;
                    lblUsername.Visibility = System.Windows.Visibility.Visible;
                }
                
            }
            else
            {
                MessageBox.Show("Username " + tbName.Text + " is to short", "Error!");
            }

        }

        #endregion

        #region Method Region

        #endregion
    }
}
