using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Bilan
    {
         public DateTime DatePrelevement  { get; set; }
         public string EmailMedecin { get; set; }
          
        public bool Paye { get; set; }

        public ICollection<Analyse> Analyses { get; set; }

        [ForeignKey("CodePatient")]
        public Patient Patient { get; set; }

    
        public int CodePatient { get; set; }

        [ForeignKey("CodeInfirmier")]
        public Infirmier Infirmier { get; set; }
       
        public int CodeInfirmier { get; set; }

    }
}
