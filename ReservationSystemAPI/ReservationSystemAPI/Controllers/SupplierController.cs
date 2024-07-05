using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystemAPI.Models;
using ReservationSystemAPI.Models.DTOs;
using ReservationSystemAPI.Models.Response;

namespace ReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly DBReservationSystemContext _dbReservationSystemContext;

        public SupplierController(DBReservationSystemContext dbReservationSystemContext)
        {
            _dbReservationSystemContext = dbReservationSystemContext;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _dbReservationSystemContext.Suppliers.ToListAsync();

            return Ok(entities);
        }

        [HttpPost("create")]
        public  ActionResult<Respuesta> Create(SupplierDTO supplier)
        {
            var r = new Respuesta();
            try
            {
                Supplier sup = new Supplier();
                sup.SupplierName = supplier.SupplierName;
                sup.Phone = supplier.Phone;
                sup.Email = supplier.Email;

                r.Exito = 1;
                 _dbReservationSystemContext.Suppliers.Add(sup);
                 _dbReservationSystemContext.SaveChanges();
                r.Mensaje = "Cliente agregado exitosamente";
            }
            catch (Exception ex)
            {
                r.Exito = 0;
                r.Mensaje = ex.Message;
            }

            return Ok(r);
        }
    }
}

