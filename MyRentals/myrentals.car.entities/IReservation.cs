using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myrentals.entities
{
    public interface IReservation
    {
        DateTime ReservationFromDate { get; set; }
        DateTime ReservationToDate { get; set; }
    }
}
