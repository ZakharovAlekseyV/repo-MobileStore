using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController (MobileContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy (int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy (Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибо," + order.User + ", за покупку!";
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
    }
}
