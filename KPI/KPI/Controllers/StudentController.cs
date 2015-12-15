using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Entity;
using DataAccess.Repository;

namespace KPI.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        private IRepository studentRepository;

        public StudentController()
        {
            this.studentRepository = new StudentRepository();
        }

        public StudentController(IRepository _studentRepository)
        {
            this.studentRepository = _studentRepository;
        }

        public ActionResult Index()
        {
            return View(studentRepository.GetStudents());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id)
        {
            var student = studentRepository.GetStudentById(id);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName, FirstName, EnrollmentDate")]Student student)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    studentRepository.InsertStudent(student);
                    studentRepository.Save();
                    return RedirectToAction("Index");
                }
                
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                
            }
            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id)
        {
            var student = studentRepository.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId, LastName, FirstName, EnrollmentDate")] Student student)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    studentRepository.UpdateStudent(student);
                    studentRepository.Save();

                    return RedirectToAction("Index");
                }

            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id, bool? saveChangesError=false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed.";
            }
            Student student = studentRepository.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                studentRepository.DeleteStudent(id);
                studentRepository.Save();
            }
            catch (DataException/* dex */)
            {
                // uncomment dex and log error. 
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            studentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
