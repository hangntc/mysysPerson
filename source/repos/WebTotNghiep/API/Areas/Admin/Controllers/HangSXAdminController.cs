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
    public class HangSXAdminController : ApiController
    {
        private Modelapi db = new Modelapi();

        // GET: api/HangSXAdmiin
        public IQueryable<HangSX> GetHangSXes()
        {
            return db.HangSXes;
        }

        // GET: api/HangSXAdmiin/5
        [ResponseType(typeof(HangSX))]
        public IHttpActionResult GetHangSX(int id)
        {
            HangSX hangSX = db.HangSXes.Find(id);
            if (hangSX == null)
            {
                return NotFound();
            }

            return Ok(hangSX);
        }

        // PUT: api/HangSXAdmiin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHangSX(int id, HangSX hangSX)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hangSX.IdHang)
            {
                return BadRequest();
            }

            db.Entry(hangSX).State = EntityState.Modified;

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HangSXAdmiin
        [ResponseType(typeof(HangSX))]
        public IHttpActionResult PostHangSX(HangSX hangSX)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HangSXes.Add(hangSX);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hangSX.IdHang }, hangSX);
        }

        // DELETE: api/HangSXAdmiin/5
        [ResponseType(typeof(HangSX))]
        public IHttpActionResult DeleteHangSX(int id)
        {
            HangSX hangSX = db.HangSXes.Find(id);
            if (hangSX == null)
            {
                return NotFound();
            }

            db.HangSXes.Remove(hangSX);
            db.SaveChanges();

            return Ok(hangSX);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HangSXExists(int id)
        {
            return db.HangSXes.Count(e => e.IdHang == id) > 0;
        }
    }
}