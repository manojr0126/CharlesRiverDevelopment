using myrentals.entities;
using myrentals.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myrentals.service
{
    public static class Factory
    {
        private static IDatabase _dbContext;
        private static IServiceController _serviceController;

        static Factory()
        {
            _dbContext = new DBContext();
            _serviceController = new ServiceController(_dbContext);
        }

        public static entities.Vehicle Create(string carType)
        {
            switch (carType)
            {
                case "Compact":
                    return new CompactCar();
                case "Standard":
                    return new StandardCar();
                case "Intermediate":
                    return new IntermediateCar();
                case "Full Size":
                    return new FullSizeCar();
                default:
                    return null;
            }
        }

        public static IDatabase DBContext
        {
            get
            {
                return _dbContext;
            }
        }

        public static IServiceController ServiceController
        {
            get
            {
                return _serviceController;
            }
        }
    }
}