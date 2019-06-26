using API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Areas.Admin.Controllers
{
    public class NguoiDungAdminController : ApiController
    {
        private Modelapi db = new Modelapi();

        // GET: api/NguoiDungAdmin
        public IQueryable<NguoiDung> GetNguoiDungs()
        {
            return db.NguoiDungs;
        }

        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult GetNguoiDung(string txtTen, string txtMK)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Where(s => s.Username == txtTen && s.Password == txtMK).FirstOrDefault();
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return Ok(nguoiDung);
        }
        // GET: api/NguoiDungAdmin/5
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult GetNguoiDung(int id)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (id != nguoiDung.Id)
            {
                return NotFound();
            }

            return Ok(nguoiDung);
        }

        // PUT: api/NguoiDungAdmin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNguoiDung(int id, NguoiDung nguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiDung.Id)
            {
                return BadRequest();
            }

            db.Entry(nguoiDung).State = EntityState.Modified; 
             db.SaveChanges();
         

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NguoiDungAdmin
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult PostNguoiDung(NguoiDung nguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NguoiDungs.Add(nguoiDung);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NguoiDungExists(nguoiDung.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nguoiDung.Id }, nguoiDung);
        }
      

        // DELETE: api/NguoiDungAdmin/5
        [ResponseType(typeof(NguoiDung))]
        public IHttpActionResult DeleteNguoiDung(int id)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            db.NguoiDungs.Remove(nguoiDung);
            db.SaveChanges();

            return Ok(nguoiDung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoiDungExists(int id)
        {
            return db.NguoiDungs.Count(e => e.Id == id) > 0;
        }
    }
}