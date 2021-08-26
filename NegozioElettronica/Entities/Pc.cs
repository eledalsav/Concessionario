using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Entities
{
    class Pc:Product
    {
        public EnumSystem System { get; set; }
        public bool IsTouch { get; set; } //TODO converti in numero

        public Pc()
        {

        }
        public Pc(string brand, string model, int quantity, EnumSystem system, bool isTouch)
            :base(model, brand, quantity)
        {
            System = system;
            IsTouch = isTouch;
        }
        public override string Print()
        {
            return $"{base.Print()} - {System} - {IsTouch}";
        }
    }
    enum EnumSystem
    {
        Windows,
        Mac,
        Linux
    }
}
