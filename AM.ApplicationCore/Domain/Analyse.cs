using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
   public class Analyse
    {
        public int AnalyseId { get; set; }
        public int DureeResultat { get; set; }
        public double PrixAnalyse { get; set; }
        public string TypeAnalyse { get; set; }
        public float ValeurAnalyse { get; set; }
        public float ValeurMaxNormale { get; set; }
        public float ValeurMinNormale { get; set; }

        public int CodeInfirmier { get; set; }
        public int CodePatient { get; set; }
        public DateTime DatePrelevement { get; set; }

        [ForeignKey(nameof(CodeInfirmier) + "," + nameof(CodePatient) + "," + nameof(DatePrelevement))]
        public Bilan Bilan { get; set; }

    }
}
