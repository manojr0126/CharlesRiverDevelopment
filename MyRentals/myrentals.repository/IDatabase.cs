using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myrentals.entities;

namespace myrentals.repository
{
    public interface IDatabase
    {
        List<IVehicle> GetVehicles { get; }
        bool ReserveVehicle(IVehicle vehicle);
    }
}
