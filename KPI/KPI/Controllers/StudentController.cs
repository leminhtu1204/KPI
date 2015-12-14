using System.Linq;
using System.Web.Mvc;
using DataAccess;

namespace KPI.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        UniversityContext context = new UniversityContext();

        public ActionResult Index()
        {
            return View(context.Students.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
