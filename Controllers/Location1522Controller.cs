using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TSQL_WEB_API.Models;

namespace TSQL_WEB_API.Controllers
{
    [Route("location")]
    [ApiController]
    public class Location1522Controller : ControllerBase
    {
        private readonly _102661522Context _context;

        public Location1522Controller(_102661522Context context)
        {
            _context = context;
        }

        // GET: api/Location1522
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location1522>>> GetLocation1522()
        {
            return await _context.Location1522.ToListAsync();
        }

        // GET: api/Location1522/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Location1522>>> GetLocation1522(string id)
        {
            try
            {
                SqlParameter p1 = new SqlParameter("@PLOCID", id);

                return await _context.Location1522.FromSqlRaw("EXEC GET_LOCATION_BY_ID @PLOCID", p1).ToListAsync();

            }
            catch
            {
                return NotFound("LOCATION DOES NOT EXIST");
            }
        }

        // POST: api/Location1522
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Location1522>> PostLocation1522(Location1522 l)
        {
            try
            {

                //SqlParameter p1 = new SqlParameter("@PLOCID", l.Locationid);
                //SqlParameter p2 = new SqlParameter("@PLOCNAME", l.Locname);
                //SqlParameter p3 = new SqlParameter("@PLOCADDRESS", l.Address);
                //SqlParameter p4 = new SqlParameter("@PMANAGER", l.Manager);
                //await _context.Database.ExecuteSqlRawAsync($"ADD_LOCATION @PLOCID ,@PLOCNAME ,@PLOCADDRESS ,@PMANAGER", p1, p2, p3, p4);

                //await _context.Database.ExecuteSqlRawAsync($"ADD_LOCATION @PLOCID =" + l.Locationid + ",@PLOCNAME = " + l.Locname + ",@PLOCADDRESS =" + l.Address + ",@PMANAGER =" + l.Manager);

                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC ADD_LOCATION @PLOCID = {l.Locationid}, @PLOCNAME = {l.Locname}, @PLOCADDRESS = {l.Address},@PMANAGER = {l.Manager}");
            }
            catch (DbUpdateException)
            {
                if (Location1522Exists(l.Locationid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocation1522", new { id = l.Locationid }, l);
        }



        private bool Location1522Exists(string id)
        {
            return _context.Location1522.Any(e => e.Locationid == id);
        }
    }
}
