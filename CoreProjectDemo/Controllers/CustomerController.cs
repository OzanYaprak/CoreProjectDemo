using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CoreProjectDemo.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EFCustomerDAL());
        JobManager jobManager = new JobManager(new EFJobDAL());


        public IActionResult Index()
        {
            var customers = customerManager.GetCustomerListIncludeJobs();

            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            //DROPDOWN LİST YAZILIMASI BAŞLANGIÇ

            List<SelectListItem> jobListForDropdown = (from x in jobManager.GetAll()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.JobName,
                                                           Value = x.JobID.ToString()
                                                       }).ToList();

            if (!ModelState.IsValid)
            {
                ViewBag.seçimhatası = "Lütfen bir meslek seçiniz";

                return View();
            }

            ViewBag.jobList = jobListForDropdown;
            
            //DROPDOWN LİST YAZILIMASI BİTİŞ

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
            //DROPDOWN LİST YAZILIMASI BAŞLANGIÇ

            List<SelectListItem> jobListForDropdown = (from x in jobManager.GetAll()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.JobName,
                                                           Value = x.JobID.ToString()
                                                       }).ToList();

            ViewBag.jobList = jobListForDropdown;

            //DROPDOWN LİST YAZILIMASI BİTİŞ








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



