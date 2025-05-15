using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum specialite
    {
        Hematologie,
        Biochimie,
        Autre
    }
    public class Infirmier
    {
       

        public int InfirmierId { get; set; }
        public string NomComplet { get; set; }
        public specialite Specialite { get; set; }

        public Laboratoire Laboratoire { get; set; }

        [ForeignKey("Laboratoire")]
        public int LaboratoireFK { get; set; }


        public ICollection<Bilan> Bilans { get; set; }




    }
}
