using myrentals.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace myrentals.repository
{
    public class DBContext : IDatabase
    {
        private List<IVehicle> lstVehicles = null;

        public DBContext()
        {
            lstVehicles = new List<IVehicle>();

            lstVehicles.Add(new CompactCar() { ID = 1, CarType = "Compact", Model = "Nissan Versa", Doors = 4, PassengerCapacity = 5 });
            lstVehicles.Add(new CompactCar() { ID = 2, CarType = "Compact", Model = "Ford Focus", Doors = 4, PassengerCapacity = 5 });
            lstVehicles.Add(new CompactCar() { ID = 3, CarType = "Compact", Model = "Honda Civic", Doors = 4, PassengerCapacity = 5 });

            lstVehicles.Add(new StandardCar() { ID = 4, CarType = "Standard", Model = "Volkswagen Jetta", Doors = 4, PassengerCapacity = 5 });
            lstVehicles.Add(new StandardCar() { ID = 5, CarType = "Standard", Model = "Kia Soul", Doors = 4, PassengerCapacity = 5 });

            lstVehicles.Add(new IntermediateCar() { ID = 6, CarType = "Intermediate", Model = "Hyundai Elantra", Doors = 4, PassengerCapacity = 5 });
            lstVehicles.Add(new IntermediateCar() { ID = 7, CarType = "Intermediate", Model = "Nissan Altima", Doors = 4, PassengerCapacity = 5 });
            lstVehicles.Add(new IntermediateCar() { ID = 8, CarType = "Intermediate", Model = "Ford Fusion", Doors = 4, PassengerCapacity = 5 });

            lstVehicles.Add(new FullSizeCar() { ID = 9, CarType = "Full Size", Model = "Ford Fusion", Doors = 4, PassengerCapacity = 5 });
            lstVehicles.Add(new FullSizeCar() { ID = 10, CarType = "Full Size", Model = "Nissan Maxima", Doors = 4, PassengerCapacity = 5 });
        }

        public List<IVehicle> GetVehicles
        {
            get 
            {
                return lstVehicles;
            }
        }

        public bool ReserveVehicle(IVehicle vehicle)
        {
            if (GetVehicles.Remove(vehicle))
                GetVehicles.Add(vehicle);
            else
                return false;

            return true;
        }
    }
}
