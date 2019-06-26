using API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Areas.Admin.Controllers
{
    public class SanphamAdminController : ApiController
    {
        private Modelapi db = new Modelapi();

        // GET: api/Sanphams
        public IQueryable<Sanpham> GetSanphams()
        {
            return db.Sanphams;
        }

        // GET: api/Sanphams/5
        [ResponseType(typeof(Sanpham))]
        public IHttpActionResult GetSanpham(int id)
        {
            Sanpham sanpham = db.Sanphams.Find(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return Ok(sanpham);
        }

        // PUT: api/Sanphams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanPham(int id, Sanpham sanpham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanpham.id)
            {
                return BadRequest();
            }

            db.Entry(sanpham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanphamExists(id))
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

        // POST: api/Sanphams
        [ResponseType(typeof(Sanpham))]
        public IHttpActionResult PostSanpham(Sanpham sanpham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Sanphams.Add(sanpham);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanpham.id }, sanpham);
        }


        // DELETE: api/Sanphams/5
        [ResponseType(typeof(Sanpham))]
        public IHttpActionResult DeleteSanpham([FromUri] int[] ids)
        {

            foreach(var sp in ids)
            {
                Sanpham sp1 = db.Sanphams.Find(sp);
                db.Sanphams.Remove(sp1);
                db.SaveChanges();
                return Ok(sp);
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
       
        private bool SanphamExists(int id)
        {
            return db.Sanphams.Count(e => e.id == id) > 0;
        }

        

    }
}