using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Tehtava7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BLTrain trains;
        public MainWindow()
        {
            InitializeComponent();
            trains = new BLTrain();

            //Threadi asemien hakuun
            //Haetaan webistä dataa omassa threadissä
            new Thread(() =>
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    cbCity.DisplayMemberPath = "stationName";
                    cbCity.SelectedValuePath = "stationShortCode";
                    cbCity.DataContext = trains.GetStations();
                    txtUrl.Text = "Valmista!";
                }));
            }).Start();
            txtUrl.Text = "Haetaan asemia webistä...";

        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            //Haetaan webistä dataa omassa threadissä
            new Thread(() =>
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    dgTrains.DataContext = trains.GetTrains(cbCity.SelectedValue.ToString());
                    txtUrl.Text = "Valmista!";
                }));
            }).Start();
            txtUrl.Text = "Haetaan data webistä...";
        }
    }
}
