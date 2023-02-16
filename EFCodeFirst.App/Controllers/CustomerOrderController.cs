using Microsoft.AspNetCore.Mvc;
using EFCode_First.DataModel;

namespace EFCode_First.App.Controllers
{
    public class CustomerOrderController : Controller
    {
        private readonly AppDbContext context;
        public CustomerOrderController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.CustomerOrders.ToList());
        }

        public IActionResult Add()
        {

            return View(new CustomerOrder());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var customerOrder = context.CustomerOrders.Find(id);
            return View(customerOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CustomerOrder model)
        {
            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerOrder model)
        {
            context.Set<CustomerOrder>().Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var customerOrder = context.CustomerOrders.Find(id);
            context.Set<CustomerOrder>().Remove(customerOrder);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
