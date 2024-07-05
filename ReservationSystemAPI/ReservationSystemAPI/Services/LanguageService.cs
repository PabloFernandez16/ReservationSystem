using Microsoft.EntityFrameworkCore;
using ReservationSystemAPI.Models;
using ReservationSystemAPI.Models.DTOs;
using ReservationSystemAPI.Repositories;

namespace ReservationSystemAPI.Services
{
    public class LanguageService : IBaseRepository<Lenguage, LanguageDTO>
    {
        private readonly DBReservationSystemContext _context;

        public LanguageService(DBReservationSystemContext context)
        {
            _context = context;
        }
 

        public Task<Lenguage> AddAsync(LanguageDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Lenguage>> GetAllAsync()
        {
            return await _context.Lenguages.ToListAsync();
        }

        public Task<Lenguage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, LanguageDTO oModel)
        {
            throw new NotImplementedException();
        }
    }
}
