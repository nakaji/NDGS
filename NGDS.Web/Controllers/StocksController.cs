using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NGDS.Web.Models;
using NGDS.Web.ViewModels;
using WebGrease.Css.Extensions;

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

        public async Task<ActionResult> Add()
        {
            var repo = new DrinksRepository();

            var drinks = await repo.AllDrinks();

            var model = new StocksAddViewModel();
            drinks.ForEach(x => model.Drinks.Add(
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = string.Format("{0} {1}ml", x.Name, x.Volume),
                }));
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add([Bind(Include = "DrinkId,Amount")]StocksAddViewModel model)
        {
            var repo = new StocksRepository();

            await repo.Add(new Stock() { DrinkId = model.DrinkId, Amount = model.Amount, Consumption = 0 });

            return RedirectToAction("Index");
        }

    }
}