using System;

namespace ParkNWash.Common
{
    public static class ValidationHandler
    {
        /// <summary>
        /// Finder ud af om det er et int tal. Hvis det IKKE er, tvinges brugeren til at skrive et.
        /// </summary>
        /// <param name="indtastet">den string som der skal findes ud af om er et int tal</param>
        /// <returns>sender en int værdi tilbage</returns>
        public static int ErDetEtTal(this string indtastet)
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
