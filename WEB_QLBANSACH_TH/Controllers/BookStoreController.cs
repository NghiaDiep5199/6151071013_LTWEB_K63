using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WEB_QLBANSACH_TH.Models;

namespace WEB_QLBANSACH_TH.Controllers
{
    public class BookStoreController : Controller
    {
        QLBANSACHEntities data = new QLBANSACHEntities();
        // GET: BookStore
        private List<SACH> Laysachmoi(int count)
        {
            // Sap xep sach giam dan theo ngay cap nhat
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        // GET: BookStore
        public ActionResult Index(int? page)
        {
            int pageSize = 4;   
            int pageNum = (page ?? 1);
           
            var sachmoi = Laysachmoi(15);
            return View(sachmoi.ToPagedList(pageNum, pageSize));
        }

        public ActionResult ChuDe()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }

        public ActionResult NhaXuatBan()
        {
            var nhaxb = from cd in data.NHAXUATBANs select cd;
            return PartialView(nhaxb);
        }

        public ActionResult SPTheoChuDe(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }

        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }

        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes where s.Masach == id select s;
            return View(sach.Single());
        }
    }
}