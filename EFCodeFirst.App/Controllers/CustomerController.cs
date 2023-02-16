using Microsoft.AspNetCore.Mvc;
using EFCode_First.DataModel;

namespace EFCode_First.App.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext context;
        public CustomerController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Customers.ToList());
        }

        public IActionResult Add()
        {
            return View(new Customer());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Customer model)
        {
            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer model)
        {
            context.Set<Customer>().Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            context.Set<Customer>().Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
