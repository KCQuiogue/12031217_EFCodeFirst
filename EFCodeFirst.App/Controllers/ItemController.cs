using Microsoft.AspNetCore.Mvc;
using EFCode_First.DataModel;

namespace EFCode_First.App.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext context;
        public ItemController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Items.ToList());
        }

        public IActionResult Add()
        {
            return View(new Item());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var item = context.Items.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Item model)
        {
            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item model)
        {
            context.Set<Item>().Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var Item = context.Items.Find(id);
            context.Set<Item>().Remove(Item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
