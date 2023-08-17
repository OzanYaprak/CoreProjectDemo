using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectDemo.Controllers
{
    public class JopController : Controller
    {
        JopManager jopManager = new JopManager(new EFJopDAL());

        public IActionResult Index()
        {
            var jops = jopManager.GetAll();

            return View(jops);
        }

        [HttpGet]
        public IActionResult AddJop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJop(Jop jop)
        {
                jopManager.Add(jop);

                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteJop(int id)
        {
            var deletedJop = jopManager.GetByID(id);

            jopManager.Delete(deletedJop);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateJop(int id)
        {
            var updatedJop = jopManager.GetByID(id);

            return View(updatedJop);
        }
        [HttpPost]
        public IActionResult UpdateJop(Jop jop)
        {
            jopManager.Update(jop);

            return RedirectToAction("Index");
        }

    }
}
