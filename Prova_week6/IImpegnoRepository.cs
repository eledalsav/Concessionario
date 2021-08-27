using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_week6
{
    interface IImpegnoRepository: IDbRepository
    {
       public List<Impegno> GetByImportance(EnumImportance importance);

        public List<Impegno> GetByDueDate(DateTime duedate);

    }
}
