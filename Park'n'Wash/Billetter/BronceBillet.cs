using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class BronceBillet : Billet, IBillet
    {
        public BronceBillet()
        {
            Navn = "BronceBillet";
            Pris = 200;
        }
    }
}
