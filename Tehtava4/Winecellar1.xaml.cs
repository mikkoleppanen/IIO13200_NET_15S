using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
        public XElement xmlDoc;
        public String User = "";
        public ObservableCollection<string> list = new ObservableCollection<string>();
        public String xmlDocName = "";
        public Winecellar1()
        {
            InitializeComponent();
            xmlDocName = ConfigurationManager.AppSettings["DataFile"];

            xmlDoc = new XElement(XDocument.Load(xmlDocName).Root);

            doLinqQuery();

            var countries = from s in xmlDoc.Descendants("wine") select s.Element("maa").Value;

            list.Add("Kaikki");
            foreach (String country in countries)
            {
                if(!list.Contains(country))
                {
                    list.Add(country);
                }
            }

            this.cmbCountry.ItemsSource = list;
        }

        private void doLinqQuery()
        {
            String strCountry = this.cmbCountry.Text;
            if (strCountry == "" || strCountry == "Kaikki")
            {
                var query = (from el in xmlDoc.Descendants("wine")
                             select new
                             {
                                 Nimi = el.Element("nimi").Value,
                                 Maa = el.Element("maa").Value,
                                 Arvio = el.Element("arvio").Value
                             }).ToList();
                this.dgWines.ItemsSource = "";
                this.dgWines.ItemsSource = query;
            }
            else
            {
                var query = (from el in xmlDoc.Descendants("wine")
                             where (el.Element("maa").Value == this.cmbCountry.Text)
                             select new
                             {
                                 Nimi = el.Element("nimi").Value,
                                 Maa = el.Element("maa").Value,
                                 Arvio = el.Element("arvio").Value
                             }).ToList();
                this.dgWines.ItemsSource = "";
                this.dgWines.ItemsSource = query;
            }
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {

            doLinqQuery();
        }
    }
}
