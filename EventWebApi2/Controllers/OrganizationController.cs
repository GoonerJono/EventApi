using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public OrganizationController(EventManagerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<RegisteredOrganization> GetOrganizationDetails(int id)
        {
            var registeredOrganization = await _context.RegisteredOrganization.FindAsync(id);
            return registeredOrganization == null ? null : registeredOrganization;
        }

        [HttpPost]
        public async Task<int> CreateNewOrganization(RegisteredOrganization registeredOrganization)
        {

            _context.RegisteredOrganization.Add(registeredOrganization);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }

        [HttpPut]
        public async Task<int> UpdateOrganization(RegisteredOrganization registeredOrganization)
        {

            _context.RegisteredOrganization.Update(registeredOrganization);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}