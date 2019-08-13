using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public ConsultantController(EventManagerContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<RegisteredConsultant> GetConsultantDetails(int id)
        {
            var consultant = await _context.RegisteredConsultant.FindAsync(id);
            return consultant == null ? null : consultant;
        }

        [HttpPost]
        public async Task<int> CreateNewConsultant(RegisteredConsultant registeredConsultant)
        {

            _context.RegisteredConsultant.Add(registeredConsultant);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }

        [HttpPut]
        public async Task<int> UpdateConsultant(RegisteredConsultant registeredConsultant)
        {

            _context.RegisteredConsultant.Update(registeredConsultant);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}