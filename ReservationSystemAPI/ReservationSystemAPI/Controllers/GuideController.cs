using Microsoft.AspNetCore.Mvc;
using ReservationSystemAPI.Models;
using ReservationSystemAPI.Models.DTOs;
using ReservationSystemAPI.Repositories;
using System.Xml;
using WSVenta.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private IBaseRepository<Guide, GuideDTO> _service;

        public GuideController(IBaseRepository<Guide, GuideDTO> service)
        {
            _service = service;
        }


        // GET: api/<GuideController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();

            return Ok(entities);
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var guide = await _service.GetById(id);
                if (guide != null)
                {
                    return Ok(guide);
                }
                else
                {
                    return NotFound($"Guide with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<GuideController>
        [HttpPost]
        public async Task<ActionResult<Guide>> Post(GuideDTO model)
        {
            var entity = await _service.AddAsync(model);

            return CreatedAtAction(nameof(GetAll), new { id = entity.Id }, entity);
        }

        // PUT api/<GuideController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GuideDTO oGuide)
        {
            try
            {
                bool edited = await _service.Update(id, oGuide);

                if (edited)
                {
                    return Ok("Edited");
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // DELETE api/<GuideController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var guide = await _service.GetById(id);

            if (guide.Active == false)
            {
                return Ok("No eli");
            }
            else
            {

                _service.SoftDelete(id);
            }


            return Ok(guide);
        }
    }
}
