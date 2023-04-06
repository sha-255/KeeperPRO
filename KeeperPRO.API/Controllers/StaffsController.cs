using KeeperPRO.Api.Domain.Context.Staff;
using KeeperPRO.Domain.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeeperPRO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly StaffContext _context;

        public StaffsController(StaffContext context)
            => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Staff>> Get()
            => await _context.Staffs.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            return staff == null ? NotFound() : Ok(staff);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Staff staff)
        {
            if (id != staff.Id) 
                return BadRequest();
            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var staffToDelete = await _context.Staffs.FindAsync(id);
            if (staffToDelete == null) 
                return NotFound();
            _context.Staffs.Remove(staffToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}