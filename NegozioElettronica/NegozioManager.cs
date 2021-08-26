using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
    class NegozioManager
    {
        static Repositories.ProductListRepository prodlistrep = new Repositories.ProductListRepository();
        static Repositories.PhoneListRepository phonelistrepo = new Repositories.PhoneListRepository();
        static Repositories.PcListRepository pclistrepo = new Repositories.PcListRepository();
        static Repositories.TvListRepository tvlistrepo = new Repositories.TvListRepository();

        internal static void ShowProduct()
        {
            List<Entities.Product> prods = prodlistrep.Fetch();
            foreach (var p in prods)
            {
                Console.WriteLine(p.Print());
            }
        }


        internal static void ShowPhone()
        {
            List<Entities.Phone> phones = phonelistrepo.Fetch();
            foreach (var p in phones)
            {
                Console.WriteLine(p.Print());
            }
        }


        internal static void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        internal static void DeleteProduct()
        {
            int ProdottoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Che prodotto vuoi eliminare?");
                Console.WriteLine("Premi 1 per eliminare un telefono");
                Console.WriteLine("Premi 2 per eliminare un pc");
                Console.WriteLine("Premi 3 per eliminare una tv");
                isInt = int.TryParse(Console.ReadLine(), out ProdottoScelto);
            } while (!isInt || ProdottoScelto <= 0 || ProdottoScelto >= 4);
            switch (ProdottoScelto)
            {
                case '1':
                    int id;
                    bool check;
                    do
                    {
                        Console.WriteLine("Inserisci l'id:");
                        check = int.TryParse(Console.ReadLine(), out id);
                        
                    } while (!check || phonelistrepo.GetById(id) == null);

                    Entities.Phone phone = phonelistrepo.GetById(id);
                    phonelistrepo.Delete(phone);
                    break;
                case '2':
                    int id2;
                    bool check2;
                    do
                    {
                        Console.WriteLine("Inserisci l'id:");
                        check2 = int.TryParse(Console.ReadLine(), out id2);

                    } while (!check2 || phonelistrepo.GetById(id2) == null);

                    Entities.Pc pc = pclistrepo.GetById(id2);
                    pclistrepo.Delete(pc);
                    break;
                case '3':
                    int id3;
                    bool check3;
                    do
                    {
                        Console.WriteLine("Inserisci l'id:");
                        check3 = int.TryParse(Console.ReadLine(), out id3);

                    } while (!check3 || phonelistrepo.GetById(id3) == null);

                    Entities.Tv tv= tvlistrepo.GetById(id3);
                    tvlistrepo.Delete(tv);
                    break;
                default:
                    break;

            };

        }

        internal static void InsertProduct()
        {
            int ProdottoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Che prodotto vuoi inserire?");
                Console.WriteLine("Premi 1 per inserire un nuovo telefono");
                Console.WriteLine("Premi 2 per inserire un nuov pc");
                Console.WriteLine("Premi 3 per inserire una nuova tv");

                isInt = int.TryParse(Console.ReadLine(), out ProdottoScelto);

            } while (!isInt || ProdottoScelto <= 0 || ProdottoScelto >= 4);

            switch (ProdottoScelto)
            {
                case 1:
                    Entities.Phone phone = ChiediDatiPhone();
                    phonelistrepo.Insert(phone);
                    break;
                case 2:
                    Entities.Pc pc = ChiediDatiPc();
                    pclistrepo.Insert(pc);
                    break;
                case 3:
                    Entities.Tv tv = ChiediDatiTv();
                    tvlistrepo.Insert(tv);
                    break;
            }
        }

        private static Entities.Product ChiediDatiProduct()
        {
            Entities.Product prod = new Entities.Product();
            Console.WriteLine("Inserisci la marca:");
            prod.Brand = Console.ReadLine();


            Console.WriteLine("Inserisci il modello:");
            prod.Model = Console.ReadLine();

            bool check = true;
            int quant;
            do
            {
                Console.WriteLine("Inserrisci la quantità:");
                check =int.TryParse(Console.ReadLine(), out quant);
            } while (!check||quant <=0);
            prod.Quantity = quant;

            return prod;
        }
        private static Entities.Tv ChiediDatiTv()
        {
            Entities.Product prod = ChiediDatiProduct();

            Entities.Tv tv = new Entities.Tv();
            tv.Brand = prod.Brand;
            tv.Model = prod.Model;
            tv.Quantity = prod.Quantity;

            bool check = true;
            int inch;
            do
            {
                Console.WriteLine("Inserrisci la lunghezza in pollici:");
                check = int.TryParse(Console.ReadLine(), out inch);
            } while (!check || inch <= 0);
            tv.Inch = inch;

            return tv;
        }

        private static Entities.Pc ChiediDatiPc()
        {
            Entities.Product prod = ChiediDatiProduct();

            Entities.Pc pc = new Entities.Pc();
            pc.Brand = prod.Brand;
            pc.Model = prod.Model;
            pc.Quantity = prod.Quantity;

            bool check = true;
            int system;
            do
            {
                Console.WriteLine("Scegli un sistema operativo:");
                foreach(var s in Enum.GetValues(typeof(Entities.EnumSystem)))
                {
                    Console.WriteLine($"Premi {(int)s + 1} per {(Entities.EnumSystem)s}");
                }
                check = int.TryParse(Console.ReadLine(), out system);
            } while (!check || system <= 0 || system>=4);
            pc.System = (Entities.EnumSystem)(system - 1);

            return pc;
        }

        private static Entities.Phone ChiediDatiPhone()
        {
            Entities.Product prod = ChiediDatiProduct();

            Entities.Phone p = new Entities.Phone();
            p.Brand = prod.Brand;
            p.Model = prod.Model; 
            p.Quantity = prod.Quantity;

            bool check = true;
            int memory;
            do
            {
                Console.WriteLine("Inserrisci la memoria del dispositivo:");
                check = int.TryParse(Console.ReadLine(), out memory);
            } while (!check || memory <= 0);
            p.Memory = memory;

            return p;
        }

        internal static void ShowTv()
        {
            List<Entities.Tv> tvs = tvlistrepo.Fetch();
            foreach (var p in tvs)
            {
                Console.WriteLine(p.Print());
            }
        }

        internal static void ShowPc()
        {
            List<Entities.Pc> pcs = pclistrepo.Fetch();
            foreach (var p in pcs)
            {
                Console.WriteLine(p.Print());
            }
        }
    }
}
