using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myrentals.entities
{
    public class Reservation : IReservation
    {
        public DateTime ReservationFromDate { get; set; }
        public DateTime ReservationToDate { get; set; }
    }
}
