using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class Plads
    {
        public static int ID { get; set; }
        public double Pris { get; set; }
        public int Tid { get; set; }
        public Kunde kunde { get; set; }

        public Plads()
        {
            ++ID;
        }
        public int HentPladsID()
        {
            return ID;
        }
    }
}
