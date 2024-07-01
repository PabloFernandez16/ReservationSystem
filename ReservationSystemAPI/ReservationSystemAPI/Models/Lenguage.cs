using System;
using System.Collections.Generic;

namespace ReservationSystemAPI.Models
{
    public partial class Lenguage
    {
        public Lenguage()
        {
            Guides = new HashSet<Guide>();
        }

        public int Id { get; set; }
        public string LenguageDescription { get; set; } = null!;

        public virtual ICollection<Guide> Guides { get; set; }
    }
}
