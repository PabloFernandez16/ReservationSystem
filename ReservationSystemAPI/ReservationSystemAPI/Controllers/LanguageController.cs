using Microsoft.AspNetCore.Mvc;
using ReservationSystemAPI.Models;
using ReservationSystemAPI.Models.DTOs;
using ReservationSystemAPI.Repositories;
using ReservationSystemAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private IBaseRepository<Lenguage, LanguageDTO> _service;

        public LanguageController(IBaseRepository<Lenguage, LanguageDTO> service)
        {
            _service = service;
        }


        // GET: api/<LanguageController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LanguageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
