using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myrentals.repository;

namespace myrentals.service
{
    public class ServiceController : IServiceController
    {
        private IDatabase _dbContext;

        public ServiceController(IDatabase dbContext)
        { 
            _dbContext = dbContext;
        }

        private IDatabase DBContext
        {
            get
            {
                return _dbContext;
            }
        }

        /// <summary>
        /// Method to pull vehicles
        /// </summary>
        public List<service.Vehicle> GetVehicles(DateTime from, int days, string type)
        {
            if (DateTime.Compare(from, DateTime.Now) < 0)
                throw new Exception("Invalid date!");

            if (days <= 0)
                throw new Exception("Invalid days!");

            if (string.IsNullOrEmpty(type))
                throw new Exception("Invalid car type!");

            List<service.Vehicle> lstVehicles = new List<service.Vehicle>();

            List<entities.IVehicle> vehicles = DBContext.GetVehicles.Where(x => x.CarType.ToLower() == type.ToLower() && 
                (x.Reservations == null || x.Reservations.Where(y => DateBetween(from, from.AddDays(days), y.ReservationToDate) == false).Count() == 0)).ToList();

            foreach (var item in vehicles)
            {
                service.Vehicle vehicleViewModal = new service.Vehicle();

                entities.IVehicle vehicle = Factory.Create(item.CarType);
                
                vehicleViewModal.CarType = item.CarType;
                vehicleViewModal.Doors = item.Doors;
                vehicleViewModal.ID = item.ID;
                vehicleViewModal.Model = item.Model;
                vehicleViewModal.PassengerCapacity = item.PassengerCapacity;
                vehicleViewModal.ReservationFromDate = from;
                vehicleViewModal.ReservationToDate = from.AddDays(days);
                vehicleViewModal.NumberOfDays = days;
                vehicleViewModal.Price = vehicle.GetPrice(days);

                lstVehicles.Add(vehicleViewModal);
            }

            return lstVehicles;
        }

        /// <summary>
        /// Method to save vehicle reservation
        /// </summary>
        public bool ReserveVehicle(int ID, DateTime from, int days)
        {
            if (ID <= 0)
                throw new Exception("Invalid ID!");

            if (DateTime.Compare(from, DateTime.Now) < 0)
                throw new Exception("Invalid date!");

            if (days <= 0)
                throw new Exception("Invalid days!");

            entities.IVehicle vehicle = DBContext.GetVehicles.Where(x => x.ID == ID).FirstOrDefault();

            if (vehicle.Reservations == null)
                vehicle.Reservations = new List<entities.IReservation>();

            vehicle.Reservations.Add(new entities.Reservation() { ReservationFromDate = from, ReservationToDate = from.AddDays(days) });

            return DBContext.ReserveVehicle(vehicle);
        }

        public bool DateBetween(IComparable valueFrom, IComparable valueTo, IComparable comparator)
        {
            return (valueFrom.CompareTo(comparator) >= 0 && valueTo.CompareTo(comparator) >= 0);
        }
    }
}