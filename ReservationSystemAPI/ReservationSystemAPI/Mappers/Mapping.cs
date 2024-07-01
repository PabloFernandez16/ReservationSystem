using AutoMapper;
using ReservationSystemAPI.Models.DTOs;
using ReservationSystemAPI.Models;

namespace ReservationSystemAPI.Mappers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GuideDTO, Guide>();

            CreateMap<SupplierDTO, Supplier>();

        }


    }
}
