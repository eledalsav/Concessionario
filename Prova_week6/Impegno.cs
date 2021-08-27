using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_week6
{
    class Impegno
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public EnumImportance Importance { get; set; }
        public bool IsCompleted { get; set; }
        public int? Id { get; set; }

        public Impegno()
        {

        }
        public Impegno(string title, string description, DateTime duedate, EnumImportance importance, bool isCompleted, int? id)
        {
            Title = title;
            Description = description;
            DueDate = duedate;
            Importance = importance;
            IsCompleted = isCompleted;
            Id = id;
        }
        public string Print()
        {
            var completed = IsCompleted? "Completato" : "Non completato";
            return $"{Title} - {Description} - {DueDate.ToShortDateString()} - {Importance} - {completed}";
        }
    }
    enum EnumImportance
    {
        Bassa=1,
        Media=2,
        Alta=3
    }
}
