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
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        //
        // GET: /Tickets/

        public ViewResult Index()
        {
            return View(_ticketRepository.FindAll());
        }
        //
        // GET: /Tickets/Details/5

        public ViewResult Details(int id)
        {
            return View(_ticketRepository.Find(id));
        }

        //
        // GET: /Tickets/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tickets/Create

        [HttpPost]
        public ActionResult Create(TicketDB ticketdb)
        {
            return View(_ticketRepository.Create(ticketdb));
        }

        //
        // GET: /Tickets/Edit/5

        public ActionResult Edit(int id)
        {
            return View(_ticketRepository.EditGet(id));
        }

        //
        // POST: /Tickets/Edit/5

        [HttpPost]
        public ActionResult Edit(TicketDB ticketdb)
        {
            return View(_ticketRepository.EditPost(ticketdb));
        }

        //
        // GET: /Tickets/Delete/5

        public ActionResult Delete(int id)
        {
            return View(_ticketRepository.DeleteGet(id));
        }

        //
        // POST: /Tickets/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _ticketRepository.DeletePost(id);
            return RedirectToAction("Index");
        }      
    }
}