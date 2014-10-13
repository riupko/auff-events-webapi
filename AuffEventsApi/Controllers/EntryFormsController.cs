using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AuffEventsApi.Models;

namespace AuffEventsApi.Controllers
{
    public class EntryFormsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EntryForms
        public IQueryable<EntryForm> GetEntryForms()
        {
            return db.EntryForms;
        }

        // GET: api/EntryForms/5
        [ResponseType(typeof(EntryForm))]
        public async Task<IHttpActionResult> GetEntryForm(int id)
        {
            EntryForm entryForm = await db.EntryForms.FindAsync(id);
            if (entryForm == null)
            {
                return NotFound();
            }

            return Ok(entryForm);
        }

        // PUT: api/EntryForms/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntryForm(int id, EntryForm entryForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entryForm.Id)
            {
                return BadRequest();
            }

            db.Entry(entryForm).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryFormExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EntryForms
        [ResponseType(typeof(EntryForm))]
        public async Task<IHttpActionResult> PostEntryForm(EntryForm entryForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EntryForms.Add(entryForm);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entryForm.Id }, entryForm);
        }

        // DELETE: api/EntryForms/5
        [ResponseType(typeof(EntryForm))]
        public async Task<IHttpActionResult> DeleteEntryForm(int id)
        {
            EntryForm entryForm = await db.EntryForms.FindAsync(id);
            if (entryForm == null)
            {
                return NotFound();
            }

            db.EntryForms.Remove(entryForm);
            await db.SaveChangesAsync();

            return Ok(entryForm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntryFormExists(int id)
        {
            return db.EntryForms.Count(e => e.Id == id) > 0;
        }
    }
}