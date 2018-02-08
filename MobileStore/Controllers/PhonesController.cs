using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;
using Microsoft.EntityFrameworkCore;

namespace MobileStore.Controllers
{
    public class PhonesController : Controller
    {
        MobileContext db;
        public PhonesController(MobileContext context)
        {
            db = context;
        }

        public IActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMobile()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult AddMobile(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
            return RedirectPermanent("/Home/Index");
        }

        [HttpGet]
        public IActionResult DeletePhone(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Phone p = db.Phones.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpPost, ActionName("DeletePhone")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Phone p = db.Phones.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            db.Phones.Remove(p);
            db.SaveChanges();
            return RedirectPermanent("/Home/Index");            
        }

        [HttpGet]
        public IActionResult EditPhone(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        [HttpPost]
        public RedirectResult EditPhone(Phone phone)
        {
            db.Entry(phone).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectPermanent("/Home/Index");
        }

        public IActionResult EditPage()
        {
            return View(db.Phones.ToList());
        }
    }
}
