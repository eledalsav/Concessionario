using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario
{
    class Menu
    {
        public static void Start()
        {
            int scelta;
            do
            {
                Console.WriteLine("Benvenuto, ecco cosa puoi fare:");
                Console.WriteLine("1. Visualizzare tutti i veicoli");
                Console.WriteLine("2. Visualizzare tutte le moto");
                Console.WriteLine("3. Visualizzare tutte le auto");
                Console.WriteLine("4. Visualizzare tutti i pulmini");
                Console.WriteLine("5. Inserire un nuovo veicolo(moto/auto/pulmino)");
                Console.WriteLine("5. Eliminare un veicolo");
                Console.WriteLine("Fai la tua scelta");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 5);
            switch (scelta)
            {
                case '1':
                    Manager.ShowVehicles();
                    break;
                case '2':
                    Manager.ShowMotocycles();
                    break;

                case '3':
                    Manager.ShowCars();
                    break;
                case '4':
                    Manager.ShowBuses();
                    break;
                case '5':
                    Manager.InsertVehicles();
                    break;
                case '6':
                    Manager.SellVehicle();
                    break;
                default:
                    break;
            }
        }
    }
}
