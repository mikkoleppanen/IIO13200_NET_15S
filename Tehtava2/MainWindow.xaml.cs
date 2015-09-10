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

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BLLotto lottoKone = new BLLotto();

        public MainWindow()
        {
            InitializeComponent();
            cmbType.Text = "Suomi";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Clear();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            int drawNum = 0;
            List<int> lottoRivi = new List<int>();

            if (Int32.TryParse(txtDrawNum.Text, out drawNum))
            {
                for (int i = 0; i < drawNum; i++)
                {
                    lottoRivi = lottoKone.ArvoRivi(cmbType.Text);
                    lottoRivi.Sort();
                    lottoRivi.ForEach(Tulosta);
                    lottoRivi.Clear();
                    txtResult.Text += Environment.NewLine;
                }
            }
        }

        private void Tulosta(int luku)
        {
            txtResult.Text += luku.ToString() + " ";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
