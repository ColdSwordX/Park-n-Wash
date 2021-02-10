using System;
using System.Collections.Generic;
using ParkNWash.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public class ParkNWash
    {
        public List<IPlads> allePladser = new List<IPlads>();
        public List<Kunde> alleKunder = new List<Kunde>();
        PladsRepository pladsRepository = new PladsRepository();
        public ParkNWash()
        {
            bool live;
            do
            {
                SkrivMenu();
                live = MenuValg();
                Console.ReadLine();
            } while (live);
        }
        void SkrivMenu()            //Udskriver menuen.
        {
            Console.Clear();
            Console.WriteLine("----- Park'n'Wash -----");
            Console.WriteLine("1: Få plads");
            Console.WriteLine("2: Betal for tid");
            Console.WriteLine("3: Skift Billet type");
            Console.WriteLine("4: Få vask");
            Console.WriteLine("10: Exit program");
        }
        /// <summary>
        /// Hver gang bruges skal finde ud af hvad brugeren gern vil.
        /// </summary>
        /// <returns>Sender en bool tilbage som fortæller om løkken skal fortsætte eller ej.</returns>
        bool MenuValg()
        {
            bool returnThis = true;
            int menuValg = Console.ReadLine().ErDetEtTal(); 
            Console.WriteLine("Hvad er deres ID.");
            switch (menuValg)
            {
                case 1:
                    pladsRepository.HvilkenPlads(ref allePladser, ref alleKunder, Console.ReadLine().ErDetEtTal());
                    break;
                case 2:
                    double pris = FrigivPlads(Console.ReadLine().ErDetEtTal());
                    Console.WriteLine($"Der skal betales: {pris}kr.");
                    Console.ReadLine();
                    break;
                case 3:
                    foreach (Kunde _kunde in alleKunder)
                    {
                        if (_kunde.KundeID == Console.ReadLine().ErDetEtTal())
                        {
                            _kunde.SkiftBilletType(ValgAfBillet());
                        }
                    }
                    break;
                case 4:
                    foreach (Kunde _kunde in alleKunder)
                    {
                        if (_kunde.KundeID == Console.ReadLine().ErDetEtTal())
                        {
                            Task.Run(() => RunCarWashAsync(_kunde.BilletType));
                        }
                    }
                    break;
                case 10:
                    returnThis = false;
                    break;
            }
            return returnThis;
        }
        /// <summary>
        /// Finder ud af hvilken billet brugerns vil have.
        /// </summary>
        /// <returns>Billet af type Ibillet(bronce, Silver, Gold)</returns>
        IBillet ValgAfBillet()
        {
            IBillet billetten;
            Console.WriteLine("Hvilken Billet vil du gerne købe?");
            Console.WriteLine("1: Bronce - 200kr");
            Console.WriteLine("2: Silver - 400kr");
            Console.WriteLine("3: Gold - 500kr");
            switch (Console.ReadLine().ErDetEtTal())
            {
                case 1:
                    billetten = new BronceBillet();
                    break;
                case 2:
                    billetten = new SilverBillet();
                    break;
                case 3:
                    billetten = new GoldBillet();
                    break;
                default:
                    billetten = new BronceBillet();
                    break;
                    
            }
            Console.WriteLine($"Der skal betales: {billetten.Pris}kr.");
            Console.ReadLine();
            return billetten;
        }
        /// <summary>
        /// Finder ud af hvor meget der skal betales.
        /// </summary>
        /// <param name="plads">Pladsen man gerne vil have Finde ud af hvor lange en kunde har holdt der</param>
        /// <param name="kunde">Den kunde som holder på pladsen.</param>
        /// <returns>Sender prisen der skal betales i Double</returns>
        public static double HvorMegetSkalDerBetales(IPlads plads, Kunde kunde)
        {
            double beloeb = 0;
            double p = plads.Pris;
            int rabat = kunde.BilletType.Rabat;
            TimeSpan span = kunde.Tid - DateTime.Now;
            if (kunde.BilletType.Rabat == 0)
            {
                beloeb = (p * (double)span.TotalSeconds);
            }
            else
            {
                beloeb = (p * (double)span.TotalSeconds) * (100 / rabat);
            }
            return beloeb;
        }
        /// <summary>
        /// Frigiver pladsen og kunden
        /// </summary>
        /// <param name="KundeID">ID på den kunde der skal til at betale</param>
        /// <returns>Prisen der skal betales.</returns>
        double FrigivPlads(int KundeID)
        {
            Kunde kunde = alleKunder.Find(Kunde => Kunde.KundeID == KundeID);

            IPlads plads = allePladser.Find(IPlads => IPlads.ID == kunde.PladsID);

            plads.FrigivPlads();
            kunde.frigivPlads();
            return HvorMegetSkalDerBetales(plads, kunde);
        }
        /// <summary>
        /// Vaske hallen køre andre ting alt efter hvad der bliver send in.
        /// </summary>
        /// <param name="billet">Den billet type som skal igennem vaske processen</param>
        void RunCarWashAsync(IBillet billet)
        {
            new CarWash.Wash(billet);
        }
    }
}
