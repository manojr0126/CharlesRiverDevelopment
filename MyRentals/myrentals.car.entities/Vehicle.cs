using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace myrentals.entities
{
    public abstract class Vehicle : IVehicle
    {
        public int ID { get; set; }
        public string CarType { get; set; }
        public string Model { get; set; }
        public int PassengerCapacity { get; set; }
        public int Doors { get; set; }
        public List<IReservation> Reservations { get; set; }

        public abstract double GetPrice(int NumberOfDays);
    }
}
