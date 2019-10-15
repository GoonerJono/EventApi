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
            var registeredOrganization = await _context.RegisteredOrganization.FindAsync(id);
            var organizationTimes = await _context.OrganizationTimes.Where(o => o.OrganizationId == id).FirstAsync();
            var province = await _context.Province.FindAsync(registeredOrganization.ProvinceId);
            var organizationDetail = new OrganizationDetails()
            {
                OrganizationId = registeredOrganization.Id,
                OrganizationEndDay = organizationTimes.OrganizationEndDay,
                Name = registeredOrganization.Name,
                OpenTime = organizationTimes.OpenTime,
                OrganizationStartDay = organizationTimes.OrganizationStartDay,
                Province = province.ProvinceName,
                CloseTime = organizationTimes.CloseTime,
                TypeOfServiceId = registeredOrganization.TypeOfServiceId,
                Address = registeredOrganization.Address,
                City = registeredOrganization.City,
                Email = registeredOrganization.Email,
                IsVerified = registeredOrganization.IsVerified,
                Latitude = registeredOrganization.Latitude,
                Longitude = registeredOrganization.Longitude,
                PhoneNumber = registeredOrganization.PhoneNumber,
                RegisteredDate = registeredOrganization.RegisteredDate,
                Suburb = registeredOrganization.Suburb,
            };
            return organizationDetail == null ? null : organizationDetail;
        }

        [HttpGet("GetOrganizationsByTypeofService/{id}")]
        public async Task<List<RegisteredOrganization>> GetOrganizationsByTypeofService(int id)
        {
            var registeredOrganization = await _context.RegisteredOrganization.Where(o=> o.TypeOfServiceId == id).ToListAsync();
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