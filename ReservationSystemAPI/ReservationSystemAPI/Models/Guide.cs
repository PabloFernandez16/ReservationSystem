using System;
using System.Collections.Generic;

namespace ReservationSystemAPI.Models
{
    public class Guide
    {
        public Guide()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string GuideName { get; set; } = null!;
        public string GuideLastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int LenguagesId { get; set; }

        public virtual Lenguage Lenguages { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
