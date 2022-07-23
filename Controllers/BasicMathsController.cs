using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicMath.Models;

namespace BasicMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicMathsController : ControllerBase
    {
        private readonly MathContext _context;

        public BasicMathsController(MathContext context)
        {
            _context = context;
        }

        // GET: api/BasicsMath
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicsMath>>> GetBasicMaths()
        {
          if (_context.BasicMaths == null)
          {
              return NotFound();
          }
            return await _context.BasicMaths.ToListAsync();
        }

        // GET: api/BasicsMath/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicsMath>> GetBasicsMath(long id)
        {
          if (_context.BasicMaths == null)
          {
              return NotFound();
          }
            var basicsMath = await _context.BasicMaths.FindAsync(id);

            if (basicsMath == null)
            {
                return NotFound();
            }

            return basicsMath;
        }

        // PUT: api/BasicsMath/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasicsMath(long id, BasicsMath basicsMath)
        {
            if (id != basicsMath.Id)
            {
                return BadRequest();
            }

            _context.Entry(basicsMath).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasicsMathExists(id))
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

        // POST: api/BasicsMath
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasicsMath>> PostBasicsMath(BasicsMath basicsMath)
        {
          if (_context.BasicMaths == null)
          {
              return Problem("Entity set 'MathContext.BasicMaths'  is null.");
          }
            _context.BasicMaths.Add(basicsMath);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBasicsMath", new { id = basicsMath.Id }, basicsMath);
            return CreatedAtAction(nameof(GetBasicMaths), new { id = basicsMath.Id }, basicsMath);
        }

        // DELETE: api/BasicsMath/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasicsMath(long id)
        {
            if (_context.BasicMaths == null)
            {
                return NotFound();
            }
            var basicsMath = await _context.BasicMaths.FindAsync(id);
            if (basicsMath == null)
            {
                return NotFound();
            }

            _context.BasicMaths.Remove(basicsMath);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("getFunctionExpression/{expression}")]
        public ActionResult<BasicsMath> GetFunctionExpression(string expression)
        {
            var functions = new Functions();

            var nameExpression = expression.ToLower();
            
            if (nameExpression.Equals("baskara"))
            {
                return Ok(functions.ShowFunction("bhaskara")); 

            } else if(nameExpression.Equals("pitagoras"))
            {
                return Ok(functions.ShowFunction("pitagoras"));

            } else {

                return NotFound(functions.ShowFunction("nada"));

            }
        }

        private bool BasicsMathExists(long id)
        {
            return (_context.BasicMaths?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
