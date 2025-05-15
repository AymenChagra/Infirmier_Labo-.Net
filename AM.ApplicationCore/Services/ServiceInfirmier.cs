using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;


namespace AM.ApplicationCore.Services
{
    public class ServiceInfirmier : Service<Infirmier>, IServiceInfirmier
    {
        public ServiceInfirmier(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double CalculerPourcentageInfirmiersParSpecialite(specialite specialite)

        {
            var infirmiers = GetMany().ToList();
            int nbrInfavecSpecialite = infirmiers.Count(i => i.Specialite == specialite);
            double pourcentage = nbrInfavecSpecialite / infirmiers.Count() * 100;
            return pourcentage;

        }
    }
}
