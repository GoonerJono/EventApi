using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfServiceController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public TypeOfServiceController(EventManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<TypeOfService>> GetTypeOfServices()
        {
            var typeOfServices = await _context.TypeOfService.ToListAsync();
            return typeOfServices;
        }

        [HttpGet("GetTypeOfServiceById/{id}")]
        public async Task<TypeOfService> GetTypeOfServiceById(int id)
        {
            var typeOfServices = await _context.TypeOfService.Where(tos => tos.Id == id).SingleAsync();
            return typeOfServices;
        }
    }
}