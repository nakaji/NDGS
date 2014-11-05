using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NGDS.Web.Models;

namespace NGDS.Web.Controllers
{
    public class StocksController : Controller
    {
        // GET: Stocks
        public async Task<ActionResult> Index()
        {
            var repo = new StocksRepository();

            var stocks = await repo.AllStocks();

            return View(stocks);
        }
    }
}