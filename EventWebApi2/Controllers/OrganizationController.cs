using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

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

        [HttpGet("GetOrganizationDetails/{id}")]
        public async Task<OrganizationDetails> GetOrganizationDetails(int id)
        {

            var organizationDetail = await _context.RegisteredOrganization.Where(o => o.Id == id).Select(a => new OrganizationDetails
            {
               OrganizationId = a.Id,
               OrganizationEndDay = a.OrganizationTimes.Where(o=> o.Id == a.Id).Select(t => t.OrganizationEndDay).First(),
               OrganizationStartDay = a.OrganizationTimes.Where(o => o.Id == a.Id).Select(t => t.OrganizationStartDay).First(),
               Name = a.Name,
               Address = a.Address,
               City = a.City,
               CloseTime = a.OrganizationTimes.Where(o => o.Id == a.Id).Select(t => t.CloseTime).First(),
               OpenTime = a.OrganizationTimes.Where(o => o.Id == a.Id).Select(t => t.OpenTime).First(),
               Province = a.Province.ProvinceName,
               TypeOfServiceId = a.TypeOfServiceId,
               Email = a.Email,
               IsVerified = a.IsVerified,
               Latitude = a.Latitude,
               Longitude = a.Longitude,
               PhoneNumber = a.PhoneNumber,
               RegisteredDate = a.RegisteredDate,
               Suburb = a.Suburb
            }
            ).FirstAsync();
            return organizationDetail == null ? null : organizationDetail;
        }

        [HttpGet("GetOrganizationsByProvince/{id}")]
        public async Task<List<RegisteredOrganization>> GetOrganizationsByProvince(int id)
        {
            var registeredOrganization = await _context.RegisteredOrganization.Where(o=> o.ProvinceId == id).ToListAsync();
            return registeredOrganization == null ? null : registeredOrganization;
        }

        [HttpGet("GetOrganizationsByTypeofService/{id}")]
        public async Task<List<RegisteredOrganization>> GetOrganizationsByTypeofService(int id)
        {
            var registeredOrganization = await _context.RegisteredOrganization.Where(o => o.TypeOfServiceId == id).ToListAsync();
            return registeredOrganization == null ? null : registeredOrganization;
        }


        [HttpPost("CreateNewOrganization/")]
        public async Task<int> CreateNewOrganization(RegisteredOrganization registeredOrganization)
        {

            _context.RegisteredOrganization.Add(registeredOrganization);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }

        [HttpPost("CreateOrganizationTime/")]
        public async Task<int> CreateOrganizationTime(OrganizationTimes organizationTimes)
        {
            _context.OrganizationTimes.Add(organizationTimes);
            if (await _context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }


        [HttpPut("UpdateOrganization/")]
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