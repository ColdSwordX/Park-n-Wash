using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public class Kunde
    {
        private static int counter;
        public int KundeID { get; }
        public int PladsID { get; set; }
        public DateTime Tid { get; }
        public IBillet BilletType { get; set; }
        public Kunde(int _PladsID)
        {
            KundeID = ++counter;
            Tid = DateTime.Now;
            PladsID = _PladsID;
            BilletType = new BronceBillet();
        }
        public Kunde(int _PladsID, IBillet _billet)
        {
            KundeID = ++counter;
            Tid = DateTime.Now;
            PladsID = _PladsID;
            BilletType = _billet;

        }
        public void SkiftBilletType(IBillet nyBillet)
        {
            BilletType = nyBillet;
        }
        /// <summary>
        /// Opretter en ny kunde og senden kunden tilbage.
        /// </summary>
        /// <returns> Kunde object</returns>
        public static Kunde OpretKunde(int pladsID)
        {
            Kunde kunde = new Kunde(pladsID);
            return kunde;
        }
        public void frigivPlads()
        {
            PladsID = 0;
        }
    }
}
