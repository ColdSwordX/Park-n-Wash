using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class SilverBillet : Billet, IBillet
    {
        public SilverBillet()
        {
            Navn = "SilverBillet";
            Rabat = 10;
            Pris = 400;
        }
    }
}
