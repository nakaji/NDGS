using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using NGDS.Web.DataContexts;

namespace NGDS.Web.Models
{
    public class DrinksRepository : IDisposable
    {
        private DrinksDb _db = new DrinksDb();

        public async Task<Drink> FindById(int? id)
        {
            return await _db.Drinks.FindAsync(id);
        }

        public async Task<IEnumerable<Drink>> AllDrinks()
        {
            return await _db.Drinks.ToListAsync();
        }

        public async Task Add(Drink drink)
        {
            _db.Drinks.Add(drink);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Drink drink)
        {
            _db.Entry(drink).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            Drink drink = await _db.Drinks.FindAsync(id);
            _db.Drinks.Remove(drink);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}