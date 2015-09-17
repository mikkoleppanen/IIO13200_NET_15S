using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Configuration;

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

            String fileName = ConfigurationManager.AppSettings["DataFile"];

            if(fileName != "")
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    playerList.Add(new Player(line));
                }
            }
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
                    lblStatusBox.Text = "Pelaaja lisätty.";
                }
                else if(!Exists(firstName, lastName))
                {
                    playerList.Add(new Player(firstName, lastName, team, price));
                    lblStatusBox.Text = "Pelaaja lisätty.";
                }
                else
                {
                    lblStatusBox.Text = "Virhe: Pelaaja löytyy jo luettelosta.";
                }

            }
            else
            {
                lblStatusBox.Text = "Virhe: Kentissä käytetty vääriä merkkejä!";
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
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lsbPlayers.SelectedIndex;
            emptyTxt();
            playerList.RemoveAt(index);
            lblStatusBox.Text = "Pelaaja poistettu.";
        }

        private void emptyTxt()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPrice.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z ]*$");
            String firstName = txtFirstName.Text;
            String lastName = txtLastName.Text;
            String team = cmbTeam.Text;
            int price = 0;

            if (regexItem.IsMatch(firstName) && regexItem.IsMatch(lastName) && Int32.TryParse(txtPrice.Text, out price))
            {
                playerList[lsbPlayers.SelectedIndex].ChangePlayer(firstName, lastName, team, price);
                lsbPlayers.Items.Refresh();
                lblStatusBox.Text = "Pelaajan tietoja muutettu.";
            }
            else
            {
                lblStatusBox.Text = "Virhe: Kentissä käytetty vääriä merkkejä!";
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Save a Txt File";
            saveFileDialog1.ShowDialog();
            String temp = "";

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();

                foreach (Player player in playerList)
                {
                    temp += player.Print();
                }

                byte[] tempBytes = new UTF8Encoding(true).GetBytes(temp);
                fs.Write(tempBytes, 0, tempBytes.Length);

                fs.Close();
                UpdateConfig(saveFileDialog1.FileName);
                lblStatusBox.Text = "Pelaajien tiedot kirjoitettu tiedostoon.";
            }
            else
            {
                lblStatusBox.Text = "Tiedostoa ei voitu tallentaa. Anna tiedostolle kunnollinen nimi.";
            }
        }

        private void UpdateConfig(String fileName)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            settings["DataFile"].Value = fileName;
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
