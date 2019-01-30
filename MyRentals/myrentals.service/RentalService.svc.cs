using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace myrentals.service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RentalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RentalService.svc or RentalService.svc.cs at the Solution Explorer and start debugging.
    public class RentalService : IRentalService
    {
        public List<Vehicle> GetVehicles(DateTime from, int days, string type)
        {
            return ServiceController.GetVehicles(from, days, type);
        }

        public bool ReserveVehicle(int ID, DateTime from, int days)
        {
            return ServiceController.ReserveVehicle(ID, from, days);
        }

        private IServiceController ServiceController
        {
            get { return Factory.ServiceController; }
        }
    }
}
