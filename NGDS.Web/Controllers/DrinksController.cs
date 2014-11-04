using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NGDS.Web.DataContexts;
using NGDS.Web.Models;

namespace NGDS.Web.Controllers
{
    public class DrinksController : Controller
    {
        private DrinksRepository repository = new DrinksRepository();

        // GET: Drinks
        public async Task<ActionResult> Index()
        {
            return View(await repository.AllDrinks());
        }

        // GET: Drinks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = await repository.FindById(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // GET: Drinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drinks/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Volume")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                repository.Add(drink);
                return RedirectToAction("Index");
            }

            return View(drink);
        }

        // GET: Drinks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = await repository.FindById(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Volume")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                await repository.Edit(drink);
                return RedirectToAction("Index");
            }
            return View(drink);
        }

        // GET: Drinks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = await repository.FindById(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await repository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
