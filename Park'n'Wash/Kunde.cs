using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class Kunde
    {
        private static int KundeID { get; set; }
        public string nanv { get; set; }
        public int tid { get; set; }
        public Kunde()
        {
            ++KundeID;
        }
    }
}
