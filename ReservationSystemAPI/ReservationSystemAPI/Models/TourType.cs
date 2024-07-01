using System;
using System.Collections.Generic;

namespace ReservationSystemAPI.Models
{
    public partial class TourType
    {
        public TourType()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string TourName { get; set; } = null!;
        public string TourDescription { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
