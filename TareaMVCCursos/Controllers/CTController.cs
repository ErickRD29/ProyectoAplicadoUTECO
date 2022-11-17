using Microsoft.AspNetCore.Mvc;

namespace TareaMVCCursos.Controllers
{
    public class CTController : Controller
    {
        // GET: CTController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CTController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CTController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CTController/Create
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

        // GET: CTController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CTController/Edit/5
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

        // GET: CTController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CTController/Delete/5
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
