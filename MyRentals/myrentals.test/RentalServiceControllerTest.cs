using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using myrentals.service;
using System.Collections.Generic;

namespace myrentals.test
{
    [TestClass]
    public class RentalServiceControllerTest
    {
        DateTime startDate = Convert.ToDateTime("1/31/2019 4:00 PM");

        private IServiceController ServiceController
        {
            get { return Factory.ServiceController; }
        }

        [TestMethod]
        public void Test_Compact_Car_Search_For_Two_Days()
        {
            DateTime from = startDate;
            int days = 2;
            string type = "Compact";

            List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);

            List<Vehicle> lstVehicleExpected = new List<Vehicle>();

            lstVehicleExpected.Add(new Vehicle() { ID = 1, CarType = "Compact", Model = "Nissan Versa", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });
            lstVehicleExpected.Add(new Vehicle() { ID = 2, CarType = "Compact", Model = "Ford Focus", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });
            lstVehicleExpected.Add(new Vehicle() { ID = 3, CarType = "Compact", Model = "Honda Civic", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });

            CollectionAssert.AreEqual(lstVehicleExpected, lstVehicleActuals, new VehicleComparer(), "Wrong set of results!");
        }

        [TestMethod]
        public void Test_Compact_Car_Reserve_For_TwoDays()
        {
            DateTime from = startDate;
            int days = 2;

            bool blnActual = ServiceController.ReserveVehicle(1, from, days);

            Assert.IsTrue(blnActual, "Reservation failed");
        }

        [TestMethod]
        public void Test_Compact_Car_Search_For_One_Day()
        {
            DateTime from = startDate.AddDays(1);
            int days = 1;
            string type = "Compact";

            List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);

            List<Vehicle> lstVehicleExpected = new List<Vehicle>();
            
            lstVehicleExpected.Add(new Vehicle() { ID = 2, CarType = "Compact", Model = "Ford Focus", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });
            lstVehicleExpected.Add(new Vehicle() { ID = 3, CarType = "Compact", Model = "Honda Civic", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });

            CollectionAssert.AreEqual(lstVehicleExpected, lstVehicleActuals, new VehicleComparer(), "Wrong set of results!");
        }

        [TestMethod]
        public void Test_Compact_Car_Reserve_For_OneDay()
        {
            DateTime from = startDate.AddDays(1);
            int days = 1;

            bool blnActual = ServiceController.ReserveVehicle(2, from, days);

            Assert.IsTrue(blnActual, "Reservation failed");
        }

        [TestMethod]
        public void Test_Compact_Car_Search_For_Three_Days()
        {
            DateTime from = startDate;
            int days = 3;
            string type = "Compact";

            List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);

            List<Vehicle> lstVehicleExpected = new List<Vehicle>();

            lstVehicleExpected.Add(new Vehicle() { ID = 3, CarType = "Compact", Model = "Honda Civic", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });

            CollectionAssert.AreEqual(lstVehicleExpected, lstVehicleActuals, new VehicleComparer(), "Wrong set of results!");
        }

        [TestMethod]
        public void Test_Compact_Car_Reserve_For_Three_Days()
        {
            DateTime from = startDate;
            int days = 3;

            bool blnActual = ServiceController.ReserveVehicle(3, from, days);

            Assert.IsTrue(blnActual, "Reservation failed");
        }

        [TestMethod]
        public void Test_Compact_Car_Search_For_Previous_Day()
        {
            DateTime from = DateTime.Now.AddDays(-1);
            int days = 1;
            string type = "Compact";
            string strActual = string.Empty;

            try
            {
                List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);
            }
            catch (Exception ex)
            {
                strActual = ex.Message;
            }
            finally
            {
                Assert.AreEqual("Invalid date!", strActual, "Unexpected result!");
            }
        }

        [TestMethod]
        public void Test_Compact_Car_Search_For_Future_Three_Days()
        {
            DateTime from = startDate.AddDays(4);
            int days = 3;
            string type = "Compact";

            List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);

            List<Vehicle> lstVehicleExpected = new List<Vehicle>();

            lstVehicleExpected.Add(new Vehicle() { ID = 1, CarType = "Compact", Model = "Nissan Versa", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });
            lstVehicleExpected.Add(new Vehicle() { ID = 2, CarType = "Compact", Model = "Ford Focus", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });
            lstVehicleExpected.Add(new Vehicle() { ID = 3, CarType = "Compact", Model = "Honda Civic", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (41.99 * days) });

            CollectionAssert.AreEqual(lstVehicleExpected, lstVehicleActuals, new VehicleComparer(), "Wrong set of results!");
        }

        [TestMethod]
        public void Test_Compact_Car_Reserve_For_Future_Three_Days()
        {
            DateTime from = startDate.AddDays(4); 
            int days = 3;

            bool blnActual = ServiceController.ReserveVehicle(1, from, days);

            Assert.IsTrue(blnActual, "Reservation failed");
        }

        [TestMethod]
        public void Test_Standard_Car_Search_For_Four_Days()
        {
            DateTime from = startDate.AddDays(2);
            int days = 4;
            string type = "Standard";

            List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);

            List<Vehicle> lstVehicleExpected = new List<Vehicle>();

            lstVehicleExpected.Add(new Vehicle() { ID = 4, CarType = "Standard", Model = "Volkswagen Jetta", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (48.99 * days) });
            lstVehicleExpected.Add(new Vehicle() { ID = 5, CarType = "Standard", Model = "Kia Soul", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (48.99 * days) });
            
            CollectionAssert.AreEqual(lstVehicleExpected, lstVehicleActuals, new VehicleComparer(), "Wrong set of results!");
        }

        [TestMethod]
        public void Test_Standard_Car_Reserve_For_Four_Days()
        {
            DateTime from = startDate.AddDays(2);
            int days = 4;

            bool blnActual = ServiceController.ReserveVehicle(4, from, days);

            Assert.IsTrue(blnActual, "Reservation failed");
        }

        [TestMethod]
        public void Test_Standard_Car_Search_For_One_Day()
        {
            DateTime from = startDate.AddDays(3);
            int days = 1;
            string type = "Standard";

            List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);

            List<Vehicle> lstVehicleExpected = new List<Vehicle>();

            lstVehicleExpected.Add(new Vehicle() { ID = 5, CarType = "Standard", Model = "Kia Soul", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (48.99 * days) });

            CollectionAssert.AreEqual(lstVehicleExpected, lstVehicleActuals, new VehicleComparer(), "Wrong set of results!");
        }

        [TestMethod]
        public void Test_Standard_Car_Reserve_For_One_Day()
        {
            DateTime from = startDate.AddDays(3);
            int days = 1;

            bool blnActual = ServiceController.ReserveVehicle(5, from, days);

            Assert.IsTrue(blnActual, "Reservation failed");
        }

        [TestMethod]
        public void Test_Standard_Car_Search_For_Future_One_Day()
        {
            DateTime from = startDate.AddDays(4);
            int days = 1;
            string type = "Standard";

            List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);

            List<Vehicle> lstVehicleExpected = new List<Vehicle>();

            lstVehicleExpected.Add(new Vehicle() { ID = 5, CarType = "Standard", Model = "Kia Soul", PassengerCapacity = 5, Doors = 4, ReservationFromDate = from, ReservationToDate = from.AddDays(days), NumberOfDays = days, Price = (48.99 * days) });

            CollectionAssert.AreEqual(lstVehicleExpected, lstVehicleActuals, new VehicleComparer(), "Wrong set of results!");
        }

        [TestMethod]
        public void Test_Standard_Car_Reserve_For_Future_One_Day()
        {
            DateTime from = startDate.AddDays(4);
            int days = 1;

            bool blnActual = ServiceController.ReserveVehicle(5, from, days);

            Assert.IsTrue(blnActual, "Reservation failed");
        }

        [TestMethod]
        public void Test_Standard_Car_Search_For_Next_One_Day()
        {
            DateTime from = startDate.AddDays(3);
            int days = 1;
            string type = "Standard";

            List<Vehicle> lstVehicleActuals = ServiceController.GetVehicles(from, days, type);

            List<Vehicle> lstVehicleExpected = new List<Vehicle>();

            CollectionAssert.AreEqual(lstVehicleExpected, lstVehicleActuals, new VehicleComparer(), "Wrong set of results!");
        }

        [TestMethod]
        public void Test_Standard_Car_Reserve_For_Next_One_Day()
        {
            DateTime from = startDate.AddDays(3);
            int days = 1;

            bool blnActual = ServiceController.ReserveVehicle(5, from, days);

            Assert.IsTrue(blnActual, "Reservation failed");
        }

    }

    public class VehicleComparer : Comparer<Vehicle>
    {
        public override int Compare(Vehicle x, Vehicle y)
        {
            if (x.ID.CompareTo(y.ID) == 0 && x.CarType.CompareTo(y.CarType) == 0 && x.Doors.CompareTo(y.Doors) == 0 && x.Model.CompareTo(y.Model) == 0 && 
                x.NumberOfDays.CompareTo(y.NumberOfDays) == 0 && x.PassengerCapacity.CompareTo(y.PassengerCapacity) == 0 && x.Price.CompareTo(y.Price) == 0 && 
                x.ReservationFromDate.CompareTo(y.ReservationFromDate) == 0 && x.ReservationToDate.CompareTo(y.ReservationToDate) == 0)
                return 0;
            else
                return -1;
        }
    }
}
