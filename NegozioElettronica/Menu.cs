using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    class Menu
    {
        internal static void Start()
        {
            bool continuare = true;
            int scelta;

            while (continuare)
            {
                Console.WriteLine("Premi 1 per vedere tutti i prodotti");
                Console.WriteLine("Premi 2 per vedere tutti i cellulari");
                Console.WriteLine("Premi 3 per vedere tutti i pc");
                Console.WriteLine("Premi 4 per vedere tutte le tv");
                Console.WriteLine("Premi 5 per inserire un nuovo prodotto");
                Console.WriteLine("Premi 6 per modificare un prodotto");
                Console.WriteLine("Premi 7 per eliminare un prodotto");
                Console.WriteLine("Premi 0 per uscire");

                do
                {
                    Console.WriteLine("Fai la tua scelta");
                } while (!int.TryParse(Console.ReadLine(), out scelta));

                switch (scelta)
                {
                    case 1:
                        {
                            NegozioManager.ShowProduct();
                            break;
                        }
                    case 2:
                        {
                            NegozioManager.ShowPhone();
                            break;
                        }
                    case 3:
                        {
                            NegozioManager.ShowPc();
                            break;
                        }
                    case 4:
                        {
                            NegozioManager.ShowTv();
                            break;
                        }
                    case 5:
                        {
                            NegozioManager.InsertProduct();
                            break;
                        }
                    case 6:
                        {
                            NegozioManager.UpdateProduct();
                            break;
                        }
                    case 7:
                        {
                            NegozioManager.DeleteProduct();
                            break;
                        }
                    case 0:
                        {
                            continuare = false;
                            break;
                        }
                }
            }
        }
    }
}
