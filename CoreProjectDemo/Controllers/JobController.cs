using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectDemo.Controllers
{
    public class JobController : Controller
    {
        private JobManager jobManager = new JobManager(new EFJobDAL());

        public IActionResult Index()
        {
            var jobs = jobManager.GetAll();

            return View(jobs);
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            jobManager.Add(job);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteJob(int id)
        {
            var deletedJob = jobManager.GetByID(id);

            jobManager.Delete(deletedJob);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var updatedJob = jobManager.GetByID(id);

            return View(updatedJob);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {
            jobManager.Update(job);

            return RedirectToAction("Index");
        }

    }
}