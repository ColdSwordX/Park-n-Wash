using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public class ParkNWash
    {
        List<IPlads> allePladser = new List<IPlads>();
        List<Kunde> alleKunder = new List<Kunde>();
        
        public ParkNWash()
        {
            Intialice();
            bool live;
            do
            {
                SkrivMenu();
                live = MenuValg();
                Console.ReadLine();
            } while (live);
        }
        /// <summary>
        /// Opretter alle de nødvendige elementer inden programmet køre
        /// </summary>
        void Intialice()
        {
            for (int i = 0; i < 50; i++)
            {
                allePladser.Add(new PersonBil());
            }
            for (int i = 0; i < 10; i++)
            {
                allePladser.Add(new Trailer());
            }
            for (int i = 0; i < 12; i++)
            {
                allePladser.Add(new LastbilOgBusser());
            }
            for (int i = 0; i < 5; i++)
            {
                allePladser.Add(new Handicap());
            }
        }
        void SkrivMenu()            //Udskriver menuen.
        {
            Console.WriteLine("----- Park'n'Wash -----");
            Console.WriteLine("1: Få plads");
            Console.WriteLine("2: Betal for tid");
            Console.WriteLine("10: Exit program");
        }
        /// <summary>
        /// Hver gang bruges skal finde ud af hvad brugeren gern vil.
        /// </summary>
        /// <returns>Sender en bool tilbage som fortæller om løkken skal fortsætte eller ej.</returns>
        bool MenuValg()
        {
            bool returnThis = true;
            int menuValg = ErDetEtTal(Console.ReadLine());
            switch (menuValg)
            {
                case 1:
                    GivPlads(OpretKunde(), HvilkenPlads());
                    break;
                case 2:
                    Console.WriteLine("Hvad er deres id?");
                    frigivPlads(ErDetEtTal(Console.ReadLine()));
                    break;
                case 10:
                    returnThis = false;
                    break;
            }
            return returnThis;
        }
        /// <summary>
        /// Finder ud af om det er et int tal. Hvis det IKKE er, tvinges brugeren til at skrive et.
        /// </summary>
        /// <param name="indtastet">den string som der skal findes ud af om er et int tal</param>
        /// <returns>sender en int værdi tilbage</returns>
        int ErDetEtTal(string indtastet)
        {
            bool erNummer = int.TryParse(indtastet, out int nummer);
            while (!erNummer)
            {
                Console.WriteLine("Du skal intaste et nummer!");
                Console.WriteLine("Prøv igen");
                erNummer = int.TryParse(Console.ReadLine(), out nummer);
            }
            return nummer;
        }
        /// <summary>
        /// Finder ud af hvilken plads at brugeern gerne vil have.
        /// </summary>
        /// <returns>sender en string til hvor i navnet på typen af pladsen</returns>
        private string HvilkenPlads()
        {
            Console.Clear();
            Console.WriteLine("Hvilken plads skal du bruge?");
            Console.WriteLine($"1: Person bil --- ");
            Console.WriteLine("2: Trailer");
            Console.WriteLine("3: lastbil eller bil");
            Console.WriteLine("4: Handicapvenlige");
            Console.WriteLine("5: Igen");
            int nummer = ErDetEtTal(Console.ReadLine());
            string valg;
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
            return valg;
        }
        /// <summary>
        /// Tilføjer en kunde til en plads ud fra givet parametor
        /// </summary>
        /// <param name="_kunde">den kunde der skal have en plads.</param>
        /// <param name="plads">Den plads type kunden gerne vil have. </param>
        private void GivPlads(Kunde _kunde, string plads)
        {
            bool fandLedig = false;
            foreach (IPlads item in allePladser)
            {
                if (item.GetType().Name == plads )
                {
                    Console.WriteLine("--- Udskriver billet ---");
                    Console.WriteLine($"Her der deres billet nummer: --- {_kunde.kundeID} ---");
                    Console.WriteLine("Udskriver mere bla bla bla");
                    fandLedig = true;
                    break;
                }
            }
            if (!fandLedig)
            {
                Console.WriteLine("beklagere vi fandt ikke nogle ledig plads.");
            }
        }
        /// <summary>
        /// Opretter en ny kunde og senden kunden tilbage.
        /// </summary>
        /// <returns> Kunde object</returns>
        private Kunde OpretKunde()
        {
            alleKunder.Add(new Kunde());
            return alleKunder.Last<Kunde>();
        }
        /// <summary>
        /// Fjeren 
        /// </summary>
        /// <param name="id">ID på den plads som skal have fjerner sin kunde fra sig.</param>
        private void frigivPlads(int kundeId)
        {
            foreach (Plads item in allePladser)
            {
                if (item.kunde.kundeID == kundeId)
                {
                    item.FjernEjer();
                    break;
                }
            }
        }
    }
}
