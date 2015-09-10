using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3
{
    class Player
    {
        private String firstName;
        private String lastName;
        public String fullName;
        private String team;
        private int price;

        public Player(String firstName, String lastName, String team, int price)
        {
            this.ChangePlayer(firstName, lastName, team, price);
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

            this.fullName = firstName + " " + lastName + ", " + team;
        }
    }
}
