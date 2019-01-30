using myrentals.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myrentals.service
{
    public interface IServiceController
    {
        List<Vehicle> GetVehicles(DateTime from, int days, string type);
        bool ReserveVehicle(int ID, DateTime from, int days);
    }
}
