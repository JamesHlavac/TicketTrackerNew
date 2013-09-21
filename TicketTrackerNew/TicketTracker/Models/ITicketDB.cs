using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NinjectMvc.Abstract
{
    public interface iTicket
    {
       int getId();
       string getName();
       string getType; 
       void setId(int id);
       void setName(string name);
       void setType(string Type);
    }
}