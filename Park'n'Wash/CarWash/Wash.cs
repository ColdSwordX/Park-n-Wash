using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.CarWash
{
    class Wash
    {
        public int Completion;
        public Wash(IBillet billet)
        {
            Task task;
            switch (billet.Navn)
            {
                case "BronceBillet":
                    task = WashCar();
                    task.Wait();
                    task = DryCar();
                    task.Wait();
                    task = VaxCar();
                    task.Wait();
                    break;
                case "SilverBillet":
                    task = WashCar();
                    task.Wait();
                    task = DryCar();
                    task.Wait();
                    task = VaxCar();
                    task.Wait();
                    task = CareCar();
                    task.Wait();
                    break;
                case "GoldBillet":
                    task = WashCar();
                    task.Wait();
                    task = DryCar();
                    task.Wait();
                    task = VaxCar();
                    task.Wait();
                    task = CareCar();
                    task.Wait();
                    task = UnderCarCare();
                    task.Wait();
                    break;
                default:
                    break;
            }
        }
        async Task WashCar()
        {
            Console.WriteLine("Begynder Vaskning");
            Completion = 0;
            while (Completion < 50)
            {
                await Task.Delay(50);
                Completion++;
            }
            Console.WriteLine("Afslutter Vaskning");
        }
        async Task DryCar()
        {
            Console.WriteLine("Påbegynder Tøring");
            Completion = 0;
            while (Completion < 30)
            {
                await Task.Delay(50);
                Completion++;
            }
            Console.WriteLine("Afslutter Tøring");
        }
        async Task VaxCar()
        {
            Console.WriteLine("Lægger voks på bilen");
            Completion = 0;
            while (Completion < 20)
            {
                await Task.Delay(50);
                Completion++;
            }
            Console.WriteLine("Afslutter voksning");
        }
        async Task CareCar()
        {
            Console.WriteLine("Begynder plege af bilen");
            Completion = 0;
            while (Completion < 20)
            {
                await Task.Delay(50);
                Completion++;
            }
            Console.WriteLine("Afslutter plege");
        }
        async Task UnderCarCare()
        {
            Console.WriteLine("Begynder undervogns behandling");
            Completion = 0;
            while (Completion < 20)
            {
                await Task.Delay(50);
                Completion++;
            }
            Console.WriteLine("Afslutter behandling");
        }
    }
}
