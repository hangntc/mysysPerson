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
using System.Web.Mvc;

namespace API.Controllers
{
    public class SanphamsController : ApiController
    {
        private Modelapi db = new Modelapi();


        // GET: api/Sanphams
        public IHttpActionResult GetSanphams()
        {
            var sanpham = db.Sanphams.OrderByDescending(i => i.id).ToList();

            return Ok(sanpham);
        }

        // GET: api/Sanphams/5
        [ResponseType(typeof(Sanpham))]
        public IHttpActionResult GetSanpham(int id)
        {
            var chitiet = db.Sanphams.Where(s => s.id == id).ToList().FirstOrDefault();
            var splq = db.Sanphams.Where(s => s.IdLoai == chitiet.IdLoai && s.id != chitiet.id).ToList();
            if (chitiet == null)
            {
                return NotFound();
            }
            return Ok(chitiet);
        }
        [ResponseType(typeof(Sanpham))]
        //public IHttpActionResult FindSanpham(string txtTimKiem)
        //{
        //    List<Sanpham> kqtk = db.Sanphams.Where(s => s.Tukhoa.Contains(txtTimKiem)).ToList();
        //    if (kqtk == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(kqtk);
        //}
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