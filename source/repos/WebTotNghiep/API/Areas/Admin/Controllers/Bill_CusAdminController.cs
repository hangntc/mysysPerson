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
    public class Bill_CusAdminController : ApiController
    {
        private Modelapi db = new Modelapi();

        // GET: api/Bill_CusAdmin
        public IQueryable<Donhang_KhachHang> GetDonhang_KhachHang()
        {
            return db.Donhang_KhachHang;
        }

        // GET: api/Bill_CusAdmin/5
        [ResponseType(typeof(Donhang_KhachHang))]
        public IHttpActionResult GetDonhang_KhachHang(int id)
        {
            Donhang_KhachHang donhang_KhachHang = db.Donhang_KhachHang.Find(id);
            if (donhang_KhachHang == null)
            {
                return NotFound();
            }

            return Ok(donhang_KhachHang);
        }


        // DELETE: api/Bill_CusAdmin/5
        [ResponseType(typeof(Donhang_KhachHang))]
        public IHttpActionResult DeleteDonhang_KhachHang(int id)
        {
            Donhang_KhachHang donhang_KhachHang = db.Donhang_KhachHang.Find(id);
            if (donhang_KhachHang == null)
            {
                return NotFound();
            }

            db.Donhang_KhachHang.Remove(donhang_KhachHang);
            db.SaveChanges();

            return Ok(donhang_KhachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Donhang_KhachHangExists(int id)
        {
            return db.Donhang_KhachHang.Count(e => e.IdDonHang == id) > 0;
        }
    }
}