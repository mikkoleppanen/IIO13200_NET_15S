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

namespace Tehtava8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BLXmlData data = new BLXmlData();
        public MainWindow()
        {
            InitializeComponent();
            data.setFilePath();

            dgFeedback.ItemsSource = data.getDataFromXml();

            lblDate.Content = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            data.writeDataToXml(txtName.Text, txtLearned.Text, txtWantToLearn.Text, txtGood.Text, txtBad.Text, txtOther.Text);
            dgFeedback.ItemsSource = data.getDataFromXml();
            txtBad.Text = "";
            txtGood.Text = "";
            txtLearned.Text = "";
            txtName.Text = "";
            txtOther.Text = "";
            txtWantToLearn.Text = "";
            tabControl.SelectedIndex = tabControl.SelectedIndex + 1;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = tabControl.SelectedIndex + 1;
        }
    }
}
