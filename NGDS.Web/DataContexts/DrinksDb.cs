using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NGDS.Web.Models;

namespace NGDS.Web.DataContexts
{
    public class DrinksDb : DbContext
    {
        public DrinksDb() : base("DefaultConnection") { }

        public DbSet<Drink> Drinks { get; set; }

        public System.Data.Entity.DbSet<NGDS.Web.Models.Stock> Stocks { get; set; }

        public override int SaveChanges()
        {
            SetUpdateInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            SetUpdateInfo();
            return await base.SaveChangesAsync();
        }

        private void SetUpdateInfo()
        {
            var now = DateTime.Now;
            SetCreateDateTime(now);
            SetUpdateDateTime(now);
        }

        private void SetCreateDateTime(DateTime now)
        {
            var entities = ChangeTracker.Entries()
                 .Where(e => e.State == EntityState.Added &&
                     e.CurrentValues.PropertyNames.Contains("CreateDateTime"))
                 .Select(e => e.Entity);

            foreach (dynamic entity in entities)
            {
                entity.CreateDateTime = now;
            }
        }

        private void SetUpdateDateTime(DateTime now)
        {
            var entities = ChangeTracker.Entries()
                      .Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified) &&
                          e.CurrentValues.PropertyNames.Contains("UpdateDateTime"))
                      .Select(e => e.Entity);

            foreach (dynamic entity in entities)
            {
                entity.UpdateDateTime = now;
            }
        }
    }
}