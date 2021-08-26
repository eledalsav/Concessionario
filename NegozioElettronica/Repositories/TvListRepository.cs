using NegozioElettronica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Repositories
{
   internal class TvListRepository : Interfaces.IDbTvRepository
    {
        public static List<Entities.Tv> tvs = new List<Tv>
        {
            new Tv("Philips", "KA65", 3, 54),
            new Tv("LG", "LM45678", 7, 32)
        };
        public void Delete(Tv t)
        {
            tvs.Remove(t);
        }

        public List<Tv> Fetch()
        {
            return tvs;
        }

        public void Insert(Tv t)
        {
            tvs.Add(t);
        }

        public void Update(Tv t)
        {
            Insert(t);
        }
        public Entities.Tv GetById(int? id)
        {
            return tvs.Find(m => m.Id == id);

        }
    }
}
