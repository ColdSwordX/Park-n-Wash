using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class Kunde
    {
        private static int counter;
        public int kundeID { get; }
        public int plads { get; set; }
        public DateTime tid { get; }
        public Kunde(int PladsID)
        {
            kundeID = ++counter;
            tid = DateTime.Now;
            plads = PladsID;
        }
    }
}
