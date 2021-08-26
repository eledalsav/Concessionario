using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Entities
{
    class Tv : Product
    {
        public int Inch { get; set; }

        public Tv()
        {

        }
        public Tv(string brand, string model, int quantity, int inch)
            : base(brand, model, quantity)
        {
            Inch = inch;
        }
        public override string Print()
        {
            return $"{base.Print()} - {Inch}";
        }
    }
}
