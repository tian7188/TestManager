using System.Web.Mvc;
using TestManager.Models;

namespace TestManager.Controllers
{
    [HandleError]
    public class C4iTaskController : Controller
    {
        private readonly Repository _repo;

        public C4iTaskController()
        {
           _repo =  Repository.Instance;
        }

        // GET: C4iTask
        public ActionResult Index()
        {         
            return View(_repo.C4iTasks);
        }

       
        // GET: C4iTask/Create
        public ActionResult Create()
        {
            return View("CreateTask", new C4iTask());
        }

        // POST: C4iTask/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                C4iTask C4iTask = C4iTask.FromCollection(collection);
                _repo.AddC4iTask(C4iTask);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: C4iTask/Edit/5
        public ActionResult Edit(int id)
        {
            var C4iTask = _repo.GetC4iTask(id);
            return View("EditTask", C4iTask );
        }

        // POST: C4iTask/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                C4iTask C4iTask = C4iTask.FromCollection(collection);
                C4iTask.Id = id;

                _repo.UpdateC4iTask(C4iTask);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: C4iTask/Delete/5
        public ActionResult Delete(int id)
        {
            _repo.DeleteC4iTask(id);
            return RedirectToAction("Index");
        }

        // POST: C4iTask/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repo.DeleteC4iTask(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
