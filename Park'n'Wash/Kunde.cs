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
        public int kundeID { get; }
        public DateTime tid { get; }
        public Kunde()
        {
            kundeID = ++counter;
            tid = DateTime.Now;
        }
    }
}
