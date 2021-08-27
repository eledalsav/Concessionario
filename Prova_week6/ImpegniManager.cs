using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_week6
{
    class ImpegniManager
    {
        static ImpegniListRepository impegniRepo = new ImpegniListRepository();
        //static ImpegnoAdoRepository impegniRepo=new ImpegnoAdoRepository();
        internal static void ShowImpegni()
        {
            List<Impegno> impegni = impegniRepo.Fetch();
            foreach(var impegno in impegni)
            {
                Console.WriteLine(impegno.Print());
            }
            
        }

        internal static void FilterIsCompleted()
        {
            List<Impegno> impegni =   impegniRepo.GetByIsCompleted();
            foreach (var i in impegni)
                Console.WriteLine(i.Print());
        }

        internal static void FilterImportance()
        {
            EnumImportance importance = ChiediImportance();
            List<Impegno> impegni = impegniRepo.GetByImportance(importance);
            foreach (var i in impegni)
                Console.WriteLine(i.Print());
        }

        internal static void FilterDueDate()
        {
            DateTime duedate = ChiediDate();
            List<Impegno> impegni = impegniRepo.GetByDueDate(duedate);
            foreach (var i in impegni)
                Console.WriteLine(i.Print());
        }

        internal static void InsertImpegno()
        {
            Impegno impegno=new Impegno();
            impegno.Title = ChiediTitle();
            impegno.Description = ChiediDescription();
            impegno.DueDate = ChiediDate();
            impegno.Importance = ChiediImportance();
            impegno.IsCompleted=false;

            impegniRepo.Insert(impegno);
        }

        private static EnumImportance ChiediImportance()
        {
            bool isInt = false;
            int importance = 0;
            do
            {
                Console.WriteLine("Inserisci l'importanza");
                foreach (var type in Enum.GetValues(typeof(EnumImportance)))
                {
                    Console.WriteLine($"Premi {(int)type} per {(EnumImportance)type}");
                }

                isInt = int.TryParse(Console.ReadLine(), out importance);
            } while (!isInt || importance < 1 || importance > 4);
            return (EnumImportance)importance;
        }

        private static DateTime ChiediDate()
        {
            DateTime dt = new DateTime();
            DateTime today = DateTime.Today;
            today.ToShortDateString();
            bool isDate;
            do
            {
                Console.WriteLine("Inserisci la data di scadenza");

                isDate = DateTime.TryParse(Console.ReadLine(), out dt);

            } while (!isDate || DateTime.Compare(dt,today)<0);
            //||today<dt
            return dt;
        }

        private static string ChiediDescription()
        {
            string description = String.Empty;
            do
            {
                Console.WriteLine("Inserisci la descrizione");
                description = Console.ReadLine();

            } while (String.IsNullOrEmpty(description));
            return description;
        }

        
        private static string ChiediTitle()
        {
            string title = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il titolo:");
                title = Console.ReadLine();

            } while (String.IsNullOrEmpty(title));
            return title;
        }

        internal static void DeleteImpegno()
        {
            List<Impegno> impegni = impegniRepo.Fetch();
            int i = 1;
            foreach (var impe in impegni)
            {
                Console.WriteLine($"Premi {i} per eliminare l'impegno {impe.Print()}");
                i++;
            }

            bool isInt;
            int impegnoScelto;
            do
            {
                Console.WriteLine("Quale impegno?");

                isInt = int.TryParse(Console.ReadLine(), out impegnoScelto);

            } while (!isInt || impegnoScelto <= 0 || impegnoScelto > impegni.Count);

            impegniRepo.Delete(impegni.ElementAt(impegnoScelto - 1));
        }

        internal static void UpdateImpegno()
        {
            List<Impegno> impegni = impegniRepo.Fetch();
            int i = 1;
            foreach (var impe in impegni)
            {
                Console.WriteLine($"Premi {i} per modificare l'immpegno {impe.Print()}");
                i++;
            }
            bool isInt;
            int impegnoScelto;
            do
            {
                Console.WriteLine("Quale impegno?");

                isInt = int.TryParse(Console.ReadLine(), out impegnoScelto);

            } while (!isInt || impegnoScelto <= 0 || impegnoScelto > impegni.Count);

            Console.WriteLine("Hai scelto di modificare");
            Impegno impengo = impegni.ElementAt(impegnoScelto - 1);
            if (impengo.Id == null)
            {
                impegniRepo.Delete(impengo);
            }

            bool continuare = true;
            string risposta=string.Empty;
            do
            {
                do
                {
                    Console.WriteLine("Vuoi modificare il titolo? Scrivi si o no");
                    risposta = Console.ReadLine();

                } while (String.IsNullOrEmpty(risposta));

                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                impengo.Title = ChiediTitle();
            }

            do
            {
                do
                {
                    Console.WriteLine("Vuoi modificare la descrizione? Scrivi si o no");
                    risposta = Console.ReadLine();

                } while (String.IsNullOrEmpty(risposta));

                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                impengo.Description = ChiediDescription();
            }

            do
            {
                do
                {
                    Console.WriteLine("Vuoi modificare la data di scadenza? Scrivi si o no");
                    risposta = Console.ReadLine();

                } while (String.IsNullOrEmpty(risposta));

                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                impengo.DueDate=ChiediDate();
            }

            do
            {
                do
                {
                    Console.WriteLine("Vuoi modificare l'importanza? Scrivi si o no");

                    risposta = Console.ReadLine();

                } while (String.IsNullOrEmpty(risposta));

                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                impengo.Importance = ChiediImportance();
            }

            //Commento questo pezzo per impedire che IsCompleted possa essere modificato
            //do
            //{

            //    do
            //    {
            //    Console.WriteLine("Vuoi modificare se è o no completato?");
            //    //    
            //    risposta = Console.ReadLine();

            //} while (String.IsNullOrEmpty(risposta));

            //if (risposta == "si" || risposta == "no")
            //    continuare = false;
            //} while (continuare);
            //if (risposta == "si")
            //{
            //    impengo.IsCompleted=ChiediCompletato();
            //}

            if (impengo.IsCompleted == false)
            {
                do { 
               
                    do
                    {
                        Console.WriteLine("L'impegno è stato portato a termine? Scrivi si o no");
                        risposta = Console.ReadLine();

                    } while (String.IsNullOrEmpty(risposta));

                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    impengo.IsCompleted = true;
                }

            }

            impegniRepo.Update(impengo);

        }

        private static bool ChiediCompletato()
        {
            bool continuare = true;
            string risposta;
            do
            {
                
                do
                {
                    Console.WriteLine("L'impegno è stato completato? Scrivi si o no");
                    risposta = Console.ReadLine();

                } while (String.IsNullOrEmpty(risposta));

                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);

            return risposta == "si" ? true : false;
        }
    }
}
