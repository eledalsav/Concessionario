using NegozioElettronica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Repositories
{
    internal class PhoneListRepository : Interfaces.IdbPhoneRepository
    {
        public static List<Phone> phones = new List<Phone>()
        {
            new Phone("Samsung", "Galaxy", 6, 128),
            new Phone("Apple", "iPhone", 4, 64),
        };
        public void Delete(Phone t)
        {
            phones.Remove(t);
        }

        public List<Phone> Fetch()
        {
            //if (phones.Count > 0)
            //{
            //    phones.Clear();
            //}
            return phones;
        }

        public void Insert(Phone t)
        {
            phones.Add(t);
        }

        public void Update(Phone t)
        {
            Insert(t);
        }

        public Entities.Phone GetById(int? id)
        {
            return phones.Find(m => m.Id == id);

        }
    }
}
