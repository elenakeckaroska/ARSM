using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARSM___Avtobusi_R.S.Makedonija.Models;

namespace ARSM___Avtobusi_R.S.Makedonija.Controllers
{
    public class RoutesController : Controller
    {


        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Routes
        public ActionResult Index()
        {
            return View(db.Routes.ToList());
        }

        // GET: Routes/Details/5
        public ActionResult Details(int? id, int? idCompany)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            var c = db.Companies.Find(idCompany);
            route.Company = c;
            return View(route);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Relation,TimePlace,Price")] Route route)
        {
            if (ModelState.IsValid)
            {
                
                db.Routes.Add(route);
                db.SaveChanges();
                string text = route.Id.ToString() + " ~ " + route.Relation.ToString();
                route.Text = text;
                db.SaveChanges();
                return View("DetailsWithoutCompanyInfo",route);
            }

            return View(route);
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(int? id, int? idCompany)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            var c = db.Companies.Find(idCompany);
            route.Company = c;
            db.SaveChanges();
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Relation,TimePlace,Price")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(route);
        }

        // GET: Routes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Routes.Find(id);
            db.Routes.Remove(route);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}


