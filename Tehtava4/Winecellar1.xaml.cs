using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Xml.Linq;

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for Winecellar1.xaml
    /// </summary>
    public partial class Winecellar1 : Window
    {
        public String User = "";
        public ObservableCollection<string> list = new ObservableCollection<string>();
        public Winecellar1()
        {
            InitializeComponent();

            var xmlDoc = XDocument.Load("E:/Github/IIO13200_NET_15S/Tehtava4/Viinit1.xml").Root;
            dgWines.DataContext = xmlDoc;

            var countries = from s in xmlDoc.Descendants("wine") select s.Element("maa").Value;

            foreach (String country in countries)
            {
                if(!list.Contains(country))
                {
                    list.Add(country);
                }
            }

            this.cmbCountry.ItemsSource = list;
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            var xmlDoc = XDocument.Load("E:/Github/IIO13200_NET_15S/Tehtava4/Viinit1.xml").Root;
           /* var query = from p in xmlDoc.Descendants("wine")
                        where p.Element("maa").Value == this.cmbCountry.Text
                        group p by p.Element("maa");*/

            var query = from p in xmlDoc.Descendants("wine")
                          where p.Element("maa").Value == this.cmbCountry.Text
                          select p;

            this.dgWines.DataContext = query;
            this.dgWines.Items.Refresh();
        }
    }
}
