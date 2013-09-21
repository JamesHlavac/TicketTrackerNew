using System;
using System.Collections.Generic;
using System.Web;
using NinjectMvc.Abstract;


/// <summary>
/// This is an implementation for the ITicket interface
/// </summary>

namespace NinjectMvc.Concrete
{
    public class TicketImp : ITicket
    {     
         public int ID { get; set; }
         public string Name { get; set; }
         public string Type { get; set; }    
     }       
}

