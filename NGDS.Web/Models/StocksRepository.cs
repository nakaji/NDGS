using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NGDS.Web.DataContexts;

namespace NGDS.Web.Models
{
    public class StocksRepository:IDisposable
    {
        private DrinksDb _db = new DrinksDb();

        public async Task<IEnumerable<Stock>> AllStocks()
        {
            return await _db.Stocks.Include("Drink").ToListAsync();
        }

        public async Task Add(Stock stock)
        {
            _db.Stocks.Add(stock);
            await _db.SaveChangesAsync();
        }

        public async Task<Stock> FindById(int? id)
        {
            return await _db.Stocks.FindAsync(id);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Edit(Stock stock)
        {
            _db.Entry(stock).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}