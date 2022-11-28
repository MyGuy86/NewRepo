#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly DataContext _context;

        public LeadController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Lead
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
            return await _context.Leads.ToListAsync();
        }

        // GET: api/Lead/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> GetLead(long id)
        {
            var lead = await _context.Leads.FindAsync(id);
            return lead;
        }

        [HttpGet("last30")]
        public async Task<ActionResult<IEnumerable<Lead>>> GetOnlyLead()
        {
            var ld = _context.Leads.Where(l => l.CreationDate >= DateTime.Now.AddDays(-30)).ToList();

            
            var customers = _context.Customers.Select(c => c.FullNameOfCompanyContact).ToList();
            var list = ld.ExceptBy(customers, leadName => leadName.FullNameOfTheContact).ToList();
            // var list = (
            //     from lt in _context.Leads
            //     from cs in _context.Customers
            //     where  lt.FullNameOfTheContact == cs.FullNameOfCompanyContact
            //     select lt
            // ).Distinct();       
            // var ls = list.Where(l => l.CreationDate >= DateTime.Now.AddDays(-100)).ToList();
            // if (ls == null)
            // {
            // return NotFound();
            // }

            return  list;
        }        

        // PUT: api/Lead/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead(long id, Lead lead)
        {
            if (id != lead.Id)
            {
                return BadRequest();
            }

            _context.Entry(lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
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

        // POST: api/Lead
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lead>> PostLead(Lead lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLead", new { id = lead.Id }, lead);
        }

        // DELETE: api/Lead/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(long id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
            {
                return NotFound();
            }

            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeadExists(long id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
