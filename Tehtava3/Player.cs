using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3
{
    class Player
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String team { get; set; }
        public int price { get; set; }
        public String fullName
        {
            get { return firstName + " " + lastName + ", " + team; }
        }


        public Player(String firstName, String lastName, String team, int price)
        {
            this.ChangePlayer(firstName, lastName, team, price);
        }

        public Player(String line)
        {
            String[] oneWord = line.Split(',');
            this.firstName = oneWord[0];
            this.lastName = oneWord[1];
            this.team = oneWord[2];
            this.price = Int32.Parse(oneWord[3]);

        }

        public bool NameExists(String firstName, String lastName)
        {
            if (this.firstName == firstName && this.lastName == lastName)
                return true;
            else
                return false;
        }

        public void ChangePlayer(String firstName, String lastName, String team, int price)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.team = team;
            this.price = price;

        }

        public String Print()
        {
            return this.firstName + "," + this.lastName + "," + this.team + "," + this.price.ToString() + System.Environment.NewLine;
        }
    }
}
