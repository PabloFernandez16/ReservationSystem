using System;
using System.Collections.Generic;

namespace ReservationSystemAPI.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string SupplierName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
