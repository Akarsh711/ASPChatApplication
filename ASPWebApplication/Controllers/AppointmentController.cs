using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPWebApplication.Data;
using ASPWebApplication.Models;

namespace ASPWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentViewModel>>> GetAppointmentViewModel()
        {
          if (_context.AppointmentViewModel == null)
          {
              return NotFound();
          }
            return await _context.AppointmentViewModel.ToListAsync();
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentViewModel>> GetAppointmentViewModel(int id)
        {
          if (_context.AppointmentViewModel == null)
          {
              return NotFound();
          }
            var appointmentViewModel = await _context.AppointmentViewModel.FindAsync(id);

            if (appointmentViewModel == null)
            {
                return NotFound();
            }

            return appointmentViewModel;
        }

        // PUT: api/Appointment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentViewModel(int id, AppointmentViewModel appointmentViewModel)
        {
            if (id != appointmentViewModel.ID)
            {
                return BadRequest();
            }

            //_context.Entry(appointmentViewModel).State = EntityState.Modified;
            try
            {

                AppointmentViewModel entry = await _context.AppointmentViewModel.FindAsync(appointmentViewModel.ID);
                if(entry.Title != appointmentViewModel.Title)
                {
                    entry.Title = appointmentViewModel.Title;
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentViewModelExists(id))
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

        // POST: api/Appointment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentViewModel>> PostAppointmentViewModel(AppointmentViewModel appointmentViewModel)
        {
          if (_context.AppointmentViewModel == null)
          {
              return Problem("Entity set 'ApplicationDbContext.AppointmentViewModel'  is null.");
          }
            _context.AppointmentViewModel.Add(appointmentViewModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentViewModel", new { id = appointmentViewModel.ID }, appointmentViewModel);
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentViewModel(int id)
        {
            if (_context.AppointmentViewModel == null)
            {
                return NotFound();
            }
            var appointmentViewModel = await _context.AppointmentViewModel.FindAsync(id);
            if (appointmentViewModel == null)
            {
                return NotFound();
            }

            _context.AppointmentViewModel.Remove(appointmentViewModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentViewModelExists(int id)
        {
            return (_context.AppointmentViewModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
