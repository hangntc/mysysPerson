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
    public class ChitietdonhangAdminController : ApiController
    {
        private Modelapi db = new Modelapi();

        // GET: api/ChitietdonhangAdmin
        public IQueryable<Chitietdonhang> GetChitietdonhangs()
        {
            return db.Chitietdonhangs;
        }

        // GET: api/ChitietdonhangAdmin/5
        [ResponseType(typeof(Chitietdonhang))]
        public IHttpActionResult GetChitietdonhang(int id)
        {
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            return Ok(chitietdonhang);
        }
        // DELETE: api/ChitietdonhangAdmin/5
        [ResponseType(typeof(Chitietdonhang))]
        public IHttpActionResult DeleteChitietdonhang(int id)
        {
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            db.Chitietdonhangs.Remove(chitietdonhang);
            db.SaveChanges();

            return Ok(chitietdonhang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChitietdonhangExists(int id)
        {
            return db.Chitietdonhangs.Count(e => e.Id == id) > 0;
        }
    }
}