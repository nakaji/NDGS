using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using NGDS.Web.Models;
using NGDS.Web.ViewModels;

namespace NGDS.Web.Controllers
{
    public class StocksController : Controller
    {
        StocksRepository repo = new StocksRepository();

        // GET: Stocks
        public async Task<ActionResult> Index()
        {
            var stocks = await repo.AllStocks();

            return View(stocks);
        }

        public async Task<ActionResult> Add()
        {
            var model = new StocksAddViewModel();

            model.Drinks = (await GetDrinkListItem()).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add([Bind(Include = "DrinkId,Amount")]StocksAddViewModel model)
        {
            await repo.Add(new Stock() { DrinkId = model.DrinkId, Amount = model.Amount, Consumption = 0 });

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stock = await repo.FindById(id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            var model = new StocksEditViewModel()
            {
                Stock = stock,
                Drinks = (await GetDrinkListItem()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DrinkId,Amount,Consumption,CreateDateTime,UpdateDateTime")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                await repo.Edit(stock);
                return RedirectToAction("Index");
            }

            var model = new StocksEditViewModel()
            {
                Stock = stock,
                Drinks = (await GetDrinkListItem()).ToList()
            };

            return View(model);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stock = await repo.FindById(id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            return View(stock);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await repo.Delete(id);
            return RedirectToAction("Index");
        }

        private async Task<IEnumerable<SelectListItem>> GetDrinkListItem()
        {
            var drinksRepository = new DrinksRepository();

            var drinks = await drinksRepository.AllDrinks();

            return drinks.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = string.Format("{0} {1}ml", x.Name, x.Volume),
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}