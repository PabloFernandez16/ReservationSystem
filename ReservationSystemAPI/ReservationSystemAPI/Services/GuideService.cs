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
            var entity = _mapper.Map<Guide>(model);
            /*var entity = new Guide
            {
                GuideName = model.GuideName,
                GuideLastName = model.GuideLastName,
                Phone=model.Phone,
                Email = model.Email,
                LenguagesId = model.LenguagesId
            };*/

            _context.Guides.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
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
            var guideSelected = new Guide();
            try
            {
                var guides =  await _context.Guides.ToListAsync();
                guideSelected = guides.FirstOrDefault(g => g.Id == id); 
            }
            catch (Exception ex)
            {
                guideSelected = null;
            }

            return guideSelected;
        }

        public async Task<bool> Update(int id, GuideDTO oGuide)
        {
            bool updated = false;
            var guideInDB = await _context.Guides.FirstOrDefaultAsync(d => d.Id == id);

            try
            {
                if (guideInDB != null)
                {
                    _mapper.Map(oGuide, guideInDB);
                    /*guideInDB.Email = oGuide.Email;
                    guideInDB.GuideName = oGuide.GuideName;
                    guideInDB.GuideLastName = oGuide.GuideLastName;
                    guideInDB.Phone = oGuide.Phone;
                    guideInDB.LenguagesId = oGuide.LenguagesId;*/

                    _context.Guides.Update(guideInDB);
                    _context.SaveChangesAsync();

                    updated = true;
                }
                else
                {
                    updated = false;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return updated;

        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }


}
