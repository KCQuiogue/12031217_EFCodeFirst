using Microsoft.AspNetCore.Mvc;
using EFCode_First.DataModel;

namespace EFCode_First.App.Controllers
{
    public class SupplierController : Controller
    {
        private readonly AppDbContext context;
        public SupplierController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Suppliers.ToList());
        }

        public IActionResult Add()
        {
            return View(new Supplier());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var supplier = context.Suppliers.Find(id);
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Supplier model)
        {
            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier model)
        {
            context.Set<Supplier>().Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var supplier = context.Suppliers.Find(id);
            context.Set<Supplier>().Remove(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
