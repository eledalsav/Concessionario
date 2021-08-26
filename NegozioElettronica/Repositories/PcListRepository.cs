using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Repositories
{
    internal class PcListRepository : Interfaces.IDbPcRepository
    {
        public static List<Entities.Pc> pcs = new List<Entities.Pc>()
        {
            new Entities.Pc("Samsung", "So", 16, Entities.EnumSystem.Windows, false),
            new Entities.Pc("Lenovo", "IdeaPad", 2, Entities.EnumSystem.Linux, true),
        };
        public void Delete(Entities.Pc t)
        {
            pcs.Remove(t);
        }

        public List<Entities.Pc> Fetch()
        {
            //if (phones.Count > 0)
            //{
            //    phones.Clear();
            //}
            return pcs;
        }

        public void Insert(Entities.Pc t)
        {
            pcs.Add(t);
        }

        public void Update(Entities.Pc t)
        {
            Insert(t);
        }
        public Entities.Pc GetById(int? id)
        {
            return pcs.Find(m => m.Id == id);

        }
    }
}
