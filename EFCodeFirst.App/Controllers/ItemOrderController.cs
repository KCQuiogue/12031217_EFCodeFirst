using Microsoft.AspNetCore.Mvc;
using EFCode_First.DataModel;

namespace EFCode_First.App.Controllers
{
    public class ItemOrderController : Controller
    {
        private readonly AppDbContext context;
        public ItemOrderController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.ItemOrders.ToList());
        }

        public IActionResult Add()
        {
            
            return View(new ItemOrder());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var itemOrder = context.ItemOrders.Find(id);
            return View(itemOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ItemOrder model)
        {
            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemOrder model)
        {
            context.Set<ItemOrder>().Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var itemOrder = context.ItemOrders.Find(id);
            context.Set<ItemOrder>().Remove(itemOrder);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
