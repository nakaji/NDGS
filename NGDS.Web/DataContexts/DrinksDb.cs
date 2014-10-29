using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NGDS.Web.Models;

namespace NGDS.Web.DataContexts
{
    public class DrinksDb : DbContext
    {
        public DrinksDb() : base("DefaultConnection") { }

        public DbSet<Drink> Drinks { get; set; }
    }
}