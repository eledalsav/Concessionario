using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_week6
{
    internal class ImpegniListRepository : IImpegnoRepository
    {
        static List<Impegno> impegni = new List<Impegno>()
        {
            new Impegno("Ado","Academy", new DateTime(2021,09,27), EnumImportance.Alta, false, null),
            new Impegno("Dr. Rossi", "Visita", new DateTime(2021, 10, 5), EnumImportance.Media, false, null),
            new Impegno("Report", "Compito", new DateTime(2021, 12, 03), EnumImportance.Bassa, true, null)
        };
        public void Delete(Impegno impegno)
        {
            impegni.Remove(impegno);
        }

        public List<Impegno> Fetch()
        {
            return impegni;
        }


        public void Insert(Impegno impegno)
        {
            impegni.Add(impegno);
        }

        public List<Impegno> GetByDueDate(DateTime duedate)
        {
            return impegni.Where(i => DateTime.Compare(i.DueDate, duedate) >= 0).ToList();
        }

        public void Update(Impegno impegno)
        {
            Insert(impegno);
        }

        public List<Impegno> GetByIsCompleted()
        {
            return impegni.Where(i => i.IsCompleted == true).ToList();
        }

        public List<Impegno> GetByImportance(EnumImportance importance)
        {
            return impegni.Where(i => i.Importance == importance).ToList();
        }
    }
}
