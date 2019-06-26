using API.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Areas.Admin.Controllers
{
    public class BaiVietHeThongAdminController : ApiController
    {
        private Modelapi db = new Modelapi();

        // GET: api/BaiVietHeThongAdmin
        public IQueryable<BaiVietHeThong> GetBaiVietHeThongs()
        {
            return db.BaiVietHeThongs;
        }

        // GET: api/BaiVietHeThongAdmin/5
        [ResponseType(typeof(BaiVietHeThong))]
        public IHttpActionResult GetBaiVietHeThong(int id)
        {
            BaiVietHeThong baiVietHeThong = db.BaiVietHeThongs.Find(id);
            if (baiVietHeThong == null)
            {
                return NotFound();
            }

            return Ok(baiVietHeThong);
        }

        // PUT: api/BaiVietHeThongAdmin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBaiVietHeThong(int id, BaiVietHeThong baiVietHeThong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != baiVietHeThong.ID)
            {
                return BadRequest();
            }

            db.Entry(baiVietHeThong).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BaiVietHeThongAdmin
        [ResponseType(typeof(BaiVietHeThong))]
        public IHttpActionResult PostBaiVietHeThong(BaiVietHeThong baiVietHeThong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BaiVietHeThongs.Add(baiVietHeThong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = baiVietHeThong.ID }, baiVietHeThong);
        }

        // DELETE: api/BaiVietHeThongAdmin/5
        [ResponseType(typeof(BaiVietHeThong))]
        public IHttpActionResult DeleteBaiVietHeThong(int id)
        {
            BaiVietHeThong baiVietHeThong = db.BaiVietHeThongs.Find(id);
            if (baiVietHeThong == null)
            {
                return NotFound();
            }

            db.BaiVietHeThongs.Remove(baiVietHeThong);
            db.SaveChanges();

            return Ok(baiVietHeThong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BaiVietHeThongExists(int id)
        {
            return db.BaiVietHeThongs.Count(e => e.ID == id) > 0;
        }
    }
}