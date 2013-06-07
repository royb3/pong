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


        #endregion

        #region Constructor Region

        public MainWindow()
        {
            InitializeComponent();

            #region Create Events

            btnLogin.Click += btnLogin_Click;

            #endregion

        }
 
        #endregion

        #region Event region

        void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (/*ifUsernameExist(tbName.Text)*/true)
            {
                MessageBox.Show("Welcome " + tbName.Text + "!", "Welcome");
            }
            else
            {
                MessageBox.Show("Username " + tbName.Text + " already exist", "Error!");
            }
        }

        #endregion

        #region Method Region

        #endregion
    }
}
