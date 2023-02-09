using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARSM___Avtobusi_R.S.Makedonija.Models;

namespace ARSM___Avtobusi_R.S.Makedonija.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
             return View(db.Companies.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Help()
        {
            

            return View();
        }
        public ActionResult ZaKlienti()
        {


            return View();
        }
        public ActionResult ZaKompanii()
        {

            return View();
        }
    }
}