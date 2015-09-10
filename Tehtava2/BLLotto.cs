using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava2
{
    class BLLotto
    {
        public string tyyppi;
        private int pieninNumero;
        private int suurinNumero;
        private int lkmNumero;
        private Random random = new Random();

        public BLLotto()
        {
            tyyppi = "";
            pieninNumero = 0;
            suurinNumero = 0;
            lkmNumero = 0;
        }

        public List<int> ArvoRivi()
        {
            this.tyyppi = "Suomi";
            return Arvonta();
        }

        public List<int> ArvoRivi(string tyyppi)
        {
            this.tyyppi = tyyppi;
            return Arvonta();
        }

        private List<int> Arvonta()
        {
            MikaLotto();

            int seuraavaNro = 0;
            
            List<int> rndList = new List<int>();

            for (int i = 0; i < lkmNumero; i++)
            {
                if (tyyppi == "Eurojackpot" && i >= 5)
                {
                    suurinNumero = 10;
                }

                do
                {
                    seuraavaNro = random.Next(pieninNumero, suurinNumero);
                } while (rndList.Exists(x => x == seuraavaNro));

                rndList.Add(seuraavaNro);
            }

            return rndList;
        }

        private void MikaLotto()
        {
            switch (tyyppi)
            {
                case "Suomi":
                    pieninNumero = 1;
                    suurinNumero = 39;
                    lkmNumero = 7;
                    break;
                case "VikingLotto":
                    pieninNumero = 1;
                    suurinNumero = 48;
                    lkmNumero = 6;
                    break;
                case "Eurojackpot":
                    pieninNumero = 1;
                    suurinNumero = 50;
                    lkmNumero = 7;
                    break;
                default:
                    pieninNumero = 1;
                    suurinNumero = 39;
                    lkmNumero = 7;
                    break;
            }
        }

    }
}
