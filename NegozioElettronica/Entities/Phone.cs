using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Entities
{
    class Phone:Product
    {
        public int Memory { get; set; }

        public Phone()
        {

        }
        public Phone(string brand, string model, int quantity, int memory)
            :base(brand, model, quantity)
        {
            Memory = memory;
        }
        public override string Print()
        {
            return $"{base.Print()} - {Memory}";
        }
    }
}
