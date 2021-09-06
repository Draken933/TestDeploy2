using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleAppApi.Models;

namespace SampleAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryItemsController : ControllerBase
    {
        private readonly EntryContext _context;

        public EntryItemsController(EntryContext context)
        {
            _context = context;
        }

        // GET: api/EntryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryItem>>> GetEntryItems()
        {
            return await _context.EntryItems.ToListAsync();
        }

        // GET: api/EntryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntryItem>> GetEntryItem(long id)
        {
            var entryItem = await _context.EntryItems.FindAsync(id);

            if (entryItem == null)
            {
                return NotFound();
            }

            return entryItem;
        }

        // PUT: api/EntryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntryItem(long id, EntryItem entryItem)
        {
            if (id != entryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(entryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryItemExists(id))
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

        // POST: api/EntryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntryItem>> PostEntryItem(EntryItem entryItem)
        {
            _context.EntryItems.Add(entryItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetEntryItem", new { id = entryItem.Id }, entryItem);
            return CreatedAtAction(nameof(GetEntryItem), new { id = entryItem.Id }, entryItem);
        }

        // DELETE: api/EntryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntryItem(long id)
        {
            var entryItem = await _context.EntryItems.FindAsync(id);
            if (entryItem == null)
            {
                return NotFound();
            }

            _context.EntryItems.Remove(entryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntryItemExists(long id)
        {
            return _context.EntryItems.Any(e => e.Id == id);
        }
    }
}
