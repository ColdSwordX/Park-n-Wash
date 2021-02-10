using System;
using System.Collections.Generic;
using System.Linq;
using ParkNWash.Common;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public class PladsRepository
    { 
        
        /// <summary>
      /// Finder ud af hvilken plads at brugeern gerne vil have.
      /// </summary>
      /// <returns>sender en string til hvor i navnet på typen af pladsen</returns>
        public void HvilkenPlads(ref List<IPlads> pladsList, ref List<Kunde> KundeList, int kundeID)
        {
            int nummer;
            string valg;
            bool Foundspot;
            do
            {
                Console.Clear();
                Console.WriteLine("Hvilken plads skal du bruge?");
                Console.WriteLine("1: Person bil");
                Console.WriteLine("2: Trailer");
                Console.WriteLine("3: lastbil eller bil");
                Console.WriteLine("4: Handicapvenlige");
                Console.WriteLine("5: Igen");
                nummer = Console.ReadLine().ErDetEtTal();
                switch (nummer)
                {
                    case 1:
                        valg = "PersonBil";
                        break;
                    case 2:
                        valg = "Trailer";
                        break;
                    case 3:
                        valg = "LastbilOgBusser";
                        break;
                    case 4:
                        valg = "Handicap";
                        break;
                    default:
                        valg = "";
                        break;
                }
                if (valg == "")
                {
                    Foundspot = false;
                }
                else
                {
                    Foundspot = FandtPlads(valg, ref pladsList);
                }
                if (!Foundspot)
                {
                    Console.WriteLine("Der er ikke plads til den type bil.");
                }
            } while (!Foundspot);
            if (valg != "")
            {
                GivPlads(valg, kundeID, ref pladsList,ref KundeList);
            }
        }
        /// <summary>
        /// Tilføjer en kunde til en plads ud fra givet parametor
        /// </summary>
        /// <param name="_kunde">den kunde der skal have en plads.</param>
        /// <param name="plads">Den plads type kunden gerne vil have. </param>
        public void GivPlads(string plads,int kundeID, ref List<IPlads> pladsList,ref List<Kunde> KundeList)
        {
            IPlads pladsValg;
            switch (plads)
            {
                case "PersonBil":
                    pladsValg = new PersonBil();
                    pladsList.Add(pladsValg);
                    break;
                case "Trailer":
                    pladsValg = new PersonBil();
                    pladsList.Add(pladsValg);
                    break;
                case "LastbilOgBusser":
                    pladsValg = new PersonBil();
                    pladsList.Add(pladsValg);
                    break;
                case "Handicap":
                default:
                    pladsValg = new PersonBil();
                    pladsList.Add(pladsValg);
                    break;
            }
            if (kundeID != 0)
            {
                foreach (Kunde _kunde in KundeList)
                {
                    if (_kunde.KundeID == kundeID)
                    {
                        _kunde.PladsID = pladsValg.ID;
                    }
                }
            }
            else
            {
                KundeList.Add(Kunde.OpretKunde(pladsValg.ID));
            }
        }
        /// <summary>
         /// Finder ud af om der er ledige pladser 
         /// </summary>
         /// <param name="lederEfter">Hvilken plads type der skal finde ud af om der er plads</param>
         /// <returns>TRUE hvis der er plads, FALSE hvis der ikke er plads. </returns>
        private bool FandtPlads(string lederEfter, ref List<IPlads> pladsList)
        {
            bool ledigPlads = true;
            foreach (IPlads item in pladsList)
            {
                if (item.BrugtePladser < item.AntalPladser && item.GetType().Name == lederEfter)
                {
                    ledigPlads = true;
                }
                else
                {
                    ledigPlads = false;
                }
            }
            return ledigPlads;
        }
    }
}
