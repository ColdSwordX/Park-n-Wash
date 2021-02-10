using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class GoldBillet : Billet , IBillet
    {
        public GoldBillet()
        {
            Navn = "GoldBillet";
            Rabat = 25;
            Pris = 500;
        }
    }
}
