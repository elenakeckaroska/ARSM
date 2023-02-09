using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARSM___Avtobusi_R.S.Makedonija.Models;
using Rotativa.MVC;

namespace ARSM___Avtobusi_R.S.Makedonija.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Route);
            return View(tickets.ToList());
        }
        
        public ActionResult Print(int id)
        {
            
                Ticket ticket = db.Tickets.FirstOrDefault(t => t.Id == id);
                ticket.Route = db.Routes.Find(ticket.RouteId);
                ticket.Company = db.Companies.Find(ticket.CompanyId);
                var report = new PartialViewAsPdf("~/Views/Tickets/Details.cshtml", ticket);
                return report;
            
        }
        // GET: Tickets/Details/5
        public ActionResult Details(int? id, int? companyId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            Route r = db.Routes.Find(ticket.RouteId);
            ticket.Route = r;
            Company c = db.Companies.Find(ticket.CompanyId);
            ticket.Company = c;
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create(int routeId, int companyId)
        {
            Ticket ticket = new Ticket();
            ticket.RouteId = routeId;
            Route r = db.Routes.Find(ticket.RouteId);
            ticket.Route = r;
            ticket.CompanyId = companyId;
            Company c = db.Companies.Find(ticket.CompanyId);
            ticket.Company = c;
            db.SaveChanges();
            return View(ticket);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,RouteId,CompanyId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                Route r = db.Routes.Find(ticket.RouteId);
                ticket.Route = r;
                Company company = db.Companies.Find(ticket.CompanyId);
                ticket.Company = company;
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return View("~/Views/Tickets/Payment.cshtml", ticket);
            }

            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Relation", ticket.RouteId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,RouteId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routes, "Id", "Relation", ticket.RouteId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
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
