﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myrentals.entities
{
    public class IntermediateCar : Vehicle
    {
        public override double GetPrice(int NumberOfDays)
        {
            return NumberOfDays * 45.99;
        }
    }
}
