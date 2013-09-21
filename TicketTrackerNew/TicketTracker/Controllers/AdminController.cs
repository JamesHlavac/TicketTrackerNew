using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketTracker.Models;

namespace TicketTracker.Controllers
{ 
    public class AdminController : Controller
    {
        private TicketDBContext db = new TicketDBContext();

        //
        // GET: /Admin/

        public ViewResult Index()
        {
            return View(db.Tickets.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ViewResult Details(int id)
        {
            TicketDB ticketdb = db.Tickets.Find(id);
            return View(ticketdb);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(TicketDB ticketdb)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticketdb);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(ticketdb);
        }
        
        //
        // GET: /Admin/Edit/5
 
        public ActionResult Edit(int id)
        {
            TicketDB ticketdb = db.Tickets.Find(id);
            return View(ticketdb);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(TicketDB ticketdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketdb);
        }

        //
        // GET: /Admin/Delete/5
 
        public ActionResult Delete(int id)
        {
            TicketDB ticketdb = db.Tickets.Find(id);
            return View(ticketdb);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TicketDB ticketdb = db.Tickets.Find(id);
            db.Tickets.Remove(ticketdb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}