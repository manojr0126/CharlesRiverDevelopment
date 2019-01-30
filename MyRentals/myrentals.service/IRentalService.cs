using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace myrentals.service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRentalService" in both code and config file together.
    [ServiceContract]
    public interface IRentalService
    {
        [OperationContract]
        List<Vehicle> GetVehicles(DateTime from, int days, string type);

        [OperationContract]
        bool ReserveVehicle(int ID, DateTime from, int days);
    }

    [DataContract]
    public class Vehicle
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CarType { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public int PassengerCapacity { get; set; }
        [DataMember]
        public int Doors { get; set; }
        [DataMember]
        public DateTime ReservationFromDate { get; set; }
        [DataMember]
        public DateTime ReservationToDate { get; set; }
        [DataMember]
        public int NumberOfDays { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}
