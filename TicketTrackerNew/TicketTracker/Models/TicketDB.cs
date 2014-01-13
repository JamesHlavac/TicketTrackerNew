using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicketTracker.Models
{
    public class TicketDB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }

    public class TicketDBContext : DbContext
    {
        public DbSet<TicketDB> Tickets { get; set; }
    }

    //This is the interface for all Ticket Repositories, whether they're dynamic or static.

    public interface ITicketRepository
    {
        IList<TicketDB> FindAll();
        TicketDB Find(int id);
        TicketDB Create(TicketDB ticket);
        TicketDB EditGet(int id);
        TicketDB EditPost(TicketDB ticket);
        TicketDB DeleteGet(int id);
        void DeletePost(int id);

    }

       
    public class TicketEFRepository : ITicketRepository
    {
        public IList<TicketDB> FindAll()
        {
            var db = new TicketDBContext();
            return db.Tickets.ToList();
        }

        public TicketDB Find(int id)
        {
            var db = new TicketDBContext();
            return db.Tickets.Find(id);
        }

        public TicketDB Create(TicketDB ticket)
        {
            var db = new TicketDBContext();
             
            db.Tickets.Add(ticket);
            db.SaveChanges();
                
            return ticket;
        }

        public TicketDB EditGet(int id)
        {
            var db = new TicketDBContext();
            TicketDB ticket = db.Tickets.Find(id);
            return ticket;
        }
        public TicketDB EditPost(TicketDB ticket)
        {
            var db = new TicketDBContext();

            db.Entry(ticket).State = EntityState.Modified;
            db.SaveChanges();

            return ticket;
        }

        public TicketDB DeleteGet(int id)
        {
            var db = new TicketDBContext();
            TicketDB ticket = db.Tickets.Find(id);
            return ticket;
        }

        public void DeletePost(int id)
        {
            var db = new TicketDBContext();
            TicketDB ticketdb = db.Tickets.Find(id);
            db.Tickets.Remove(ticketdb);
            db.SaveChanges();
        }
        
    }
}

