using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    class Plads
    {
        private static int counter;
        public int ID { get; }
        public double Pris { get; set; }
        public int AntalPladser { get; set; }
        public int BrugtePladser { get; set; }
        public Plads()
        {
            ID = ++counter;
            BrugtePladser++;
        }
    }
}
