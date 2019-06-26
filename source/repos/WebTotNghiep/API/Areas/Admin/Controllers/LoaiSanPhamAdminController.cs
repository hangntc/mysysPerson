using API.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : ApiController
    {
        private Modelapi db = new Modelapi();

        // GET: api/LoaiSanPhamAdmin
        public IQueryable<LoaiSanPham> GetLoaiSanPhams()
        {
            return db.LoaiSanPhams;
        }

        // GET: api/LoaiSanPhamAdmin/5
        [ResponseType(typeof(LoaiSanPham))]
        public IHttpActionResult GetLoaiSanPham(int id)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return Ok(loaiSanPham);
        }

        // PUT: api/LoaiSanPhamAdmin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoaiSanPham(int id, LoaiSanPham loaiSanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaiSanPham.IdLoai)
            {
                return BadRequest();
            }

            db.Entry(loaiSanPham).State = EntityState.Modified;

           
                db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LoaiSanPhamAdmin
        [ResponseType(typeof(LoaiSanPham))]
        public IHttpActionResult PostLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoaiSanPhams.Add(loaiSanPham);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loaiSanPham.IdLoai }, loaiSanPham);
        }

        // DELETE: api/LoaiSanPhamAdmin/5
        [ResponseType(typeof(LoaiSanPham))]
        public IHttpActionResult DeleteLoaiSanPham(int id)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            db.LoaiSanPhams.Remove(loaiSanPham);
            db.SaveChanges();

            return Ok(loaiSanPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoaiSanPhamExists(int id)
        {
            return db.LoaiSanPhams.Count(e => e.IdLoai == id) > 0;
        }
    }
}