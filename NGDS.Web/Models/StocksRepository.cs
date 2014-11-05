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

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}