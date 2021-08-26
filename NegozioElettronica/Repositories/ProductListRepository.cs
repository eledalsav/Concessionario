using NegozioElettronica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Repositories
{
    internal class ProductListRepository : Interfaces.iDbProductRepository
    {
        public static PhoneListRepository phonelistrep = new PhoneListRepository();
        public static PcListRepository pclistrep = new PcListRepository();
        public static TvListRepository tvlistrep = new TvListRepository();

        static List<Entities.Product> products = new List<Product>();
        public void Delete(Product t)
        {
            throw new NotImplementedException();
        }

        public List<Product> Fetch()
        {
            products.Clear();
            products.AddRange(phonelistrep.Fetch());
            products.AddRange(pclistrep.Fetch());
            products.AddRange(tvlistrep.Fetch());
            return products;
        }

        public List<Product> GetById(int id)
        {
            return products.Where(p => p.Id==id).ToList();
        }

        public void Insert(Product t)
        {
            throw new NotImplementedException();
        }

        public void Update(Product t)
        {
            throw new NotImplementedException();
        }
    }
}
