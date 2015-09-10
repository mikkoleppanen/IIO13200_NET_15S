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

namespace Tehtava1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int ikkunanLeveys = 0;
            int ikkunanKorkeus = 0;
            int karminLeveys = 0;
            bool virheTilanne = false;

            try
            {
                ikkunanLeveys = Int32.Parse(txtIkkunanLeveys.Text);
                ikkunanKorkeus = Int32.Parse(txtIkkunanKorkeus.Text);
                karminLeveys = Int32.Parse(txtKarminLeveys.Text); 
            }
            catch (FormatException)
            {
                virheTilanne = true;
                MessageBox.Show("Tulosta ei voitu laskea. Kentissä muita merkkejä kuin numeroita.");
            }

            if(ikkunanLeveys < 0 || ikkunanKorkeus < 0 || karminLeveys < 0 )
            {
                virheTilanne = true;
                MessageBox.Show("Jokin luvuista on alle 0!");
            }


            if(!virheTilanne)
            {
                float ikkunanAla = ikkunanLeveys * ikkunanKorkeus;
                float kokoAla = (ikkunanLeveys + 2 * karminLeveys) * (ikkunanKorkeus + 2 * karminLeveys);
                float karminAla = kokoAla - ikkunanAla;
                float karminPiiri = 2 * (ikkunanLeveys + 2 * karminLeveys) + 2 * (ikkunanKorkeus + 2 * karminLeveys);

                txtIkkunanAla.Text = ikkunanAla.ToString();
                txtKarminPiiri.Text = karminPiiri.ToString();
                txtKarminAla.Text = karminAla.ToString();
            }
            else
            {
                txtIkkunanAla.Text = "";
                txtKarminPiiri.Text = "";
                txtKarminAla.Text = "";
            }
            

        }

    }
}
