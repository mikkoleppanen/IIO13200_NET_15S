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
        List<Player> playerList = new List<Player>();

        public ObservableCollection<string> list = new ObservableCollection<string>(new String[]
        { "TPS", "Lukko", "Ässät", "HIFK", "Blues", "HPK", "Tappara",
            "Ilves", "Sport", "Pelicans", "KooKoo", "SaiPa", "Kärpät",
            "JYP", "KalPa" });

        public MainWindow()
        {
            InitializeComponent();

            this.cmbTeam.ItemsSource = list;

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z -]*$");
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

    }
}
