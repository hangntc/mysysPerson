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


namespace API.Controllers
{
    public class KhachHangsController : ApiController
    {
        private Modelapi db = new Modelapi();

        // GET: api/KhachHangs
        public IQueryable<KhachHang> GetKhachHangs()
        {
            return db.KhachHangs;
        }

        // GET: api/KhachHangs/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult GetKhachHang(string txtTen, string txtMK)
        {


            KhachHang khachHang = db.KhachHangs.Where(s => s.Tentruynhap == txtTen && s.Matkhau == txtMK).FirstOrDefault();
            if (khachHang == null)
            {
                return NotFound();
            }

            return Ok(khachHang);
        }
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult GetKhachHang(int id)
        {

            KhachHang khachHang = db.KhachHangs.Find(id);
            if (id != khachHang.IdKhachhang)
            {
                return NotFound();
            }
            return Ok(khachHang);
        }

        
        // POST: api/KhachHangs
        [ResponseType(typeof(KhachHang))] 
        public IHttpActionResult PostKhachHang(KhachHang khachHang)
        {
           
            if (!ModelState.IsValid)
            {
                    return BadRequest(ModelState);        
            }         
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = khachHang.IdKhachhang }, khachHang);
        }

        // DELETE: api/KhachHangs/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult DeleteKhachHang(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();

            return Ok(khachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhachHangExists(int id)
        {
            return db.KhachHangs.Count(e => e.IdKhachhang == id) > 0;
        }
    }
}