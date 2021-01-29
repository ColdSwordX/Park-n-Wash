using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class Handicap : Plads, IPlads
    {
        public Handicap()
        {
            Pris = 9.0;
            AntalPladser = 5;
        }
    }
}
