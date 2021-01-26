using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public class ParkNWash
    {
        List<Plads> allePladser = new List<Plads>();
        List<Kunde> alleKunder = new List<Kunde>();
        public ParkNWash()
        {
            bool live = true;
            do
            {
                intialice();
                SkrivMenu();
                live = MenuValg();
                Console.ReadLine();

            } while (live);

        }
        /// <summary>
        /// Opretter alle de nødvendige elementer inden programmet køre
        /// </summary>
        void intialice()
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
        void SkrivMenu()
        {
            Console.WriteLine("----- Park'n'Wash -----");
            Console.WriteLine("1: Få plads");
            Console.WriteLine("2: Betal for tid");
            Console.WriteLine("10: Exit program");
        }
        bool MenuValg()
        {
            bool returnThis = true;
            int menuValg = ErDetEtTal(Console.ReadLine());
            switch (menuValg)
            {
                case 1:
                    
                    break;
                case 2:
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
    }
}
