using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class Kunde
    {
        private int counter;
        private int kundeID { get; set; }
        public string nanv { get; set; }
        public int tid { get; set; }
        public Kunde()
        {
            kundeID = ++counter;
        }
    }
}
