using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Interfaces
{
    interface iDbProductRepository:IDbRepository<Entities.Product>
    {
        public List<Entities.Product> GetById(int id);
    }
}
