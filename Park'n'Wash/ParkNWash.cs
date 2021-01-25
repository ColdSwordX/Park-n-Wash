using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public class ParkNWash
    {
        List<Plads> allePladser = new List<Plads>();
        List<Kunde> alleKunder = new List<Kunde>();
        public ParkNWash()
        {
            for (int i = 0; i < 50; i++)
            {
                allePladser.Add(new PersonBil());
            }
            for (int i = 0; i < 10; i++)
            {
                allePladser.Add(new Trailer());
            }
            for (int i = 0; i < 12; i++)
            {
                allePladser.Add(new LastbilOgBusser());
            }
            for (int i = 0; i < 5; i++)
            {
                allePladser.Add(new Handicap());
            }
        }
        void menu()
        {
            Console.WriteLine("");
        }


    }
}
