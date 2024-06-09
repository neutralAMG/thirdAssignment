using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace thirdAssignment.Presentation.Controllers
{
    public class LabTestController : Controller
    {
        // GET: LabTestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LabTestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LabTestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabTestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LabTestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LabTestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LabTestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LabTestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
