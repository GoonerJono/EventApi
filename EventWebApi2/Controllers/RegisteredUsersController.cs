﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventWebApi2.Models;

namespace EventWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredUsersController : ControllerBase
    {
        private readonly EventManagerContext _context;

        public RegisteredUsersController(EventManagerContext context)
        {
            _context = context;
        }

        // GET: api/RegisteredUsers
        [HttpGet]
        public IEnumerable<RegisteredUser> GetRegisteredUser()
        {
            return _context.RegisteredUser;
        }

        // GET: api/RegisteredUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegisteredUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registeredUser = await _context.RegisteredUser.FindAsync(Convert.ToInt32(id));

            if (registeredUser == null)
            {
                return NotFound();
            }

            return Ok(registeredUser);
        }

        // PUT: api/RegisteredUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisteredUser([FromRoute] int id, [FromBody] RegisteredUser registeredUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registeredUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(registeredUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisteredUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RegisteredUsers
        [HttpPost]
        public async Task<IActionResult> PostRegisteredUser([FromBody] RegisteredUser registeredUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RegisteredUser.Add(registeredUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisteredUser", new { id = registeredUser.Id }, registeredUser);
        }

        // DELETE: api/RegisteredUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisteredUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registeredUser = await _context.RegisteredUser.FindAsync(id);
            if (registeredUser == null)
            {
                return NotFound();
            }

            _context.RegisteredUser.Remove(registeredUser);
            await _context.SaveChangesAsync();

            return Ok(registeredUser);
        }

        private bool RegisteredUserExists(int id)
        {
            return _context.RegisteredUser.Any(e => e.Id == id);
        }
    }
}