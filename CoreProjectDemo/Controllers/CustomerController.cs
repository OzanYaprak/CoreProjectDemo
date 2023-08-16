using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectDemo.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EFCustomerDAL());

        public IActionResult Index()
        {
            var customers = customerManager.GetAll();

            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult validationResult = validationRules.Validate(customer);

            if (validationResult.IsValid)
            {
                customerManager.Add(customer);

                return RedirectToAction("Index");
            }

            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            var deletedProduct = customerManager.GetByID(id);

            customerManager.Delete(deletedProduct);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var updatedCustomer = customerManager.GetByID(id);

            return View(updatedCustomer);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            customerManager.Update(customer);

            return RedirectToAction("Index");
        }
    }
}
