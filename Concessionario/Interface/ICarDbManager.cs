using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.Interface
{
    interface ICarDbManager
    {
        interface ICarDbManager : IDbManager<Entities.Car>
        {

        }
    }
}
