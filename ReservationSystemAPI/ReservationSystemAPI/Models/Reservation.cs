using System;
using System.Collections.Generic;

namespace ReservationSystemAPI.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int TotalPax { get; set; }
        public int TourTypeId { get; set; }
        public string CustomerName { get; set; } = null!;
        public int? GuideId { get; set; }
        public DateTime ActivityDate { get; set; }
        public int SupplierId { get; set; }
        public string SellerName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
        public decimal? Total { get; set; }
        public TimeSpan? ActivityTime { get; set; }
        public string? PickUpLocation { get; set; }
        public string? DropOffLocation { get; set; }

        public virtual Guide? Guide { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual TourType TourType { get; set; } = null!;
    }
}
