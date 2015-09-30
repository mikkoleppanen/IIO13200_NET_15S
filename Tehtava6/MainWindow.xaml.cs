//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JAMK.ICT.ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public String connStr;
    public String tableStr;
    public String msg;

    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
      //TODO täytetään combobox asiakkaitten maitten nimillä
      //esimerkki kuinka App.Configissa oleva connectionstring luetaan
      lbMessages.Content = JAMK.ICT.Properties.Settings.Default.Tietokanta;
      connStr = ConfigurationManager.ConnectionStrings["JAMK.ICT.Properties.Settings.Tietokanta"].ConnectionString.ToString();
      tableStr = JAMK.ICT.Properties.Settings.Default.Taulu;
      msg = "Paskaa";
      String query = "SELECT City FROM " + tableStr + " GROUP BY City";
      DataTable td = JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(connStr, tableStr, out msg, query);

      cbCountries.ItemsSource = td.DefaultView;
    }

    private void btnGet3_Click(object sender, RoutedEventArgs e)
    {
      dgCustomers.DataContext = JAMK.ICT.Data.DBPlacebo.GetTestCustomers();
    }

    private void btnGetAll_Click(object sender, RoutedEventArgs e)
    {
      String query = "SELECT * FROM " + tableStr;
      dgCustomers.DataContext = JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(connStr, tableStr, out msg, query);
    }

    private void btnGetFrom_Click(object sender, RoutedEventArgs e)
    {
      String query = "SELECT * FROM " + tableStr + " WHERE City='" + cbCountries.Text + "'";
      dgCustomers.DataContext = JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(connStr, tableStr, out msg, query);
    }

        private void btnYield_Click(object sender, RoutedEventArgs e)
        {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }
    }
}
