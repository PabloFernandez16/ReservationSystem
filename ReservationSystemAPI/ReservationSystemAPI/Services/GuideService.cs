using System;
using System.Collections.Generic;
using System.Xml;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystemAPI.Models;
using ReservationSystemAPI.Models.DTOs;
using ReservationSystemAPI.Models.Response;
using ReservationSystemAPI.Repositories;

namespace WSVenta.Servicios
{
    public class GuideService : IBaseRepository<Guide, GuideDTO>
    {
        private readonly DBReservationSystemContext _context;
        private IBaseRepository<Lenguage, LanguageDTO> _serviceLanguage;
        private readonly IMapper _mapper;

        public GuideService(
            DBReservationSystemContext context, 
            IBaseRepository<Lenguage, LanguageDTO> serviceLanguage,
            IMapper mapper
            )
        {
            _context = context;
            _serviceLanguage = serviceLanguage;
            _mapper = mapper;
        }

        public async Task<Guide> AddAsync(GuideDTO model)
        {

            using (var db = _context)
            {
                var entity = _mapper.Map<Guide>(model);
                

                db.Guides.Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            /* var entity = Activator.CreateInstance<E>();
        // Map model to entity here using AutoMapper or manually
        // Example: AutoMapper.Mapper.Map(model, entity);
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;*/


        }

        public async Task<List<Guide>> GetAllAsync()
        {
            var guidesList = await _context.Guides.ToListAsync();
            var languagesList = await _context.Lenguages.ToListAsync();
            var languageDict = languagesList.ToDictionary(l => l.Id);

            foreach (var item in guidesList)
            {
                if (languageDict.TryGetValue(item.LenguagesId, out var languageSelected))
                {
                    item.Lenguages = new Lenguage
                    {
                        Id = languageSelected.Id,
                        LenguageDescription = languageSelected.LenguageDescription
                    };
                }
            }
            return guidesList;
        }


        public async Task<Guide> GetById(int id)
        {
            return await _context.Guides.FindAsync(id);
        }

        //public async Task<bool> Update(int id, GuideDTO oGuide)
        public async Task<bool> Update(int id, GuideDTO oModel)
        {
            var entity = await _context.Guides.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _mapper.Map(oModel, entity);

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var entity = await _context.Guides.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            entity.Active = false;

            _context.SaveChangesAsync();
            return true;
        }
    }


}
