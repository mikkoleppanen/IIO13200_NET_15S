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
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace demoJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String json = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Methods
        private void Demo1()
        {
            //Haetaan Json
            json = GetSimpleJson();
            //Muunnetaan se olioksi
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);
            //Näytetään UI:ssa
            txtJSON.Text = json;
            dgData.DataContext = people;
        }

        private void Demo2()
        {
            //Haetaan Json
            json = GetJsonFromWeb();
            //Muunnetaan se olioksi
            List<Politic> people = JsonConvert.DeserializeObject<List<Politic>>(json);
            //Näytetään UI:ssa
            txtJSON.Text = json;
            dgData.DataContext = people;
        }

        private void Demo2Async()
        {
            //Haetaan webistä dataa omassa threadissä
            new Thread(() =>
            {
                String result = GetJsonFromWeb();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    //Muutetaan poliitikoiksi
                    txtJSON.Text = result;
                    List<Politic> people = JsonConvert.DeserializeObject<List<Politic>>(result);
                    dgData.DataContext = people;
                }));
            }).Start();
            txtJSON.Text = "Haetaan data webistä...";
        }

        private String GetSimpleJson()
        {
            return @"[{'Name':'Olli Opiskelija','Gender':'Male','Birthday':'1995-12-24'},{'Name':'Matti Mieskolainen','Gender':'Male','Birthday':'1985-12-25'}]";
        }

        private String GetJsonFromWeb()
        {
            try
            {
                String url = "http://student.labranet.jamk.fi/~salesa/mat/JsonTest";
                //using vapauttaa muistin sulkeiden lopussa
                using (WebClient wc = new WebClient())
                {
                    return wc.DownloadString(url);
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return "Homo";
        }
        #endregion



        private void btnGetJSON_Click(object sender, RoutedEventArgs e)
        {
            //Vaihda tänne mitä funktiota käytetään
            Demo2Async();
        }
    }
}
