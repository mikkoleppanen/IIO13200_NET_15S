using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tehtava3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Player> playerList = new ObservableCollection<Player>();

        ObservableCollection<string> list = new ObservableCollection<string>(new String[]
        { "TPS", "Lukko", "Ässät", "HIFK", "Blues", "HPK", "Tappara",
            "Ilves", "Sport", "Pelicans", "KooKoo", "SaiPa", "Kärpät",
            "JYP", "KalPa" });

        public MainWindow()
        {
            InitializeComponent();

            lsbPlayers.ItemsSource = playerList;
            lsbPlayers.DisplayMemberPath = "fullName";

            cmbTeam.ItemsSource = list;
            cmbTeam.SelectedItem = list.First();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z ]*$");
            String firstName = txtFirstName.Text;
            String lastName = txtLastName.Text;
            String team = cmbTeam.Text;
            int price = 0;

            if (regexItem.IsMatch(firstName) && regexItem.IsMatch(lastName) && Int32.TryParse(txtPrice.Text, out price))
            {
                if(!playerList.Any())
                {
                    playerList.Add(new Player(firstName, lastName, team, price));
                }
                else if(!Exists(firstName, lastName))
                {
                    playerList.Add(new Player(firstName, lastName, team, price));
                }
                else
                {
                    //Virheilmoitus!
                }

            }
            
        }

        private bool Exists(String firstName, String lastName)
        {
            for(int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i].NameExists(firstName, lastName))
                {
                    return true;
                }
            }
            return false;
        }

        private void lsbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Player temp = (Player)lsbPlayers.SelectedItem;
                txtFirstName.Text = temp.firstName;
                txtLastName.Text = temp.lastName;
                txtPrice.Text = temp.price.ToString();
                cmbTeam.Text = temp.team;
            }
            catch
            {
                emptyTxt();
                
            }

        }
        //cmbTeam.Items.Refresh();

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = cmbTeam.SelectedIndex;
            emptyTxt();
            playerList.RemoveAt(index);
        }

        private void emptyTxt()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPrice.Text = "";
        }
    }
}
