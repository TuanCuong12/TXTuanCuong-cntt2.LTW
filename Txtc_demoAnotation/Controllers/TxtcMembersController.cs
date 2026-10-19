using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Txtc_demoAnotation.Controllers
{
    public class TxtcMembers : Controller
    {
        // GET: TxtcMembers
        public ActionResult Index()
        {
            return View();
        }

        // GET: TxtcMembers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TxtcMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TxtcMembers/Create
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

        // GET: TxtcMembers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TxtcMembers/Edit/5
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

        // GET: TxtcMembers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TxtcMembers/Delete/5
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
