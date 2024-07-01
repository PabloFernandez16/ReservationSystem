

using Microsoft.AspNetCore.Mvc;
using ReservationSystemAPI.Models;
using ReservationSystemAPI.Models.DTOs;
using ReservationSystemAPI.Models.Response;
using System.Xml;

namespace ReservationSystemAPI.Repositories
{
    public interface IGuideService
    {
        Task<List<Guide>> GetAllAsync();
        Task<Guide> AddAsync(GuideDTO model);
    }
}
