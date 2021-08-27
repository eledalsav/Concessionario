using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_week6
{
    class Menu
    {
        internal static void Start()
        {
            bool continuare = true;
            int scelta;

            while (continuare)
            {
                Console.WriteLine();
                Console.WriteLine("Premi 1 per vedere tutti gli impegni");
                Console.WriteLine("Premi 2 per modificare un impegno");
                Console.WriteLine("Premi 3 per eliminare un impegno");
                Console.WriteLine("Premi 4 per inserire un nuovo impegno");
                Console.WriteLine("Premi 5 per visualizzare gli impegni per data maggiore o uguale a una data inserita");
                Console.WriteLine("Premi 6 per visualizzare gli impegni per il livello di importanza");
                Console.WriteLine("Premi 7 per visualizzare gli impegni portati a termine");
                Console.WriteLine("Premi 0 per uscire");

                do
                {
                    Console.WriteLine("Fai la tua scelta");
                } while (!int.TryParse(Console.ReadLine(), out scelta));

                switch (scelta)
                {
                    case 1:
                        {
                            Console.WriteLine();
                            ImpegniManager.ShowImpegni();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine();
                            ImpegniManager.UpdateImpegno();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine();
                            ImpegniManager.DeleteImpegno();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine();
                            ImpegniManager.InsertImpegno();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine();
                            ImpegniManager.FilterDueDate();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine();
                            ImpegniManager.FilterImportance();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine();
                            ImpegniManager.FilterIsCompleted();
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
