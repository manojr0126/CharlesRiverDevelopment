using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myrentals.entities
{
    public interface IVehicle
    {
        int ID { get; set; }
        string CarType { get; set; }
        string Model { get; set; }
        int PassengerCapacity { get; set; }
        int Doors { get; set; }
        List<IReservation> Reservations { get; set; }
        double GetPrice(int NumberOfDays);
    }
}
