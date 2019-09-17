using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventWebApi2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public ProvinceController(EventManagerContext context)
        {
            _context = context;
        }

        [HttpGet("GetProvinceById/{id}")]
        public async Task<Province> GetUserDetails(int id)
        {
            var province = await _context.Province.FindAsync(id);
            return province == null ? null : province;
        }

        [HttpGet("GetProvinces")]
        public async Task<List<Province>> GetProvinces()
        {
            var province = await _context.Province.ToListAsync();
            return province == null ? null : province;
        }
    }
}