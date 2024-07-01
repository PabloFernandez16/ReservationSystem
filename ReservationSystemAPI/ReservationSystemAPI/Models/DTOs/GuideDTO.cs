namespace ReservationSystemAPI.Models.DTOs
{
    public class GuideDTO
    {
        public string GuideName { get; set; } = null!;
        public string GuideLastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int LenguagesId { get; set; }
    }
}
