using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcProject_Moin.Models;
using MvcProject_Moin.ViewModels;
using AutoMapper;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;

namespace MvcProject_Moin.Controllers
{
    [RoutePrefix("StuffInfo")]
    public class StuffController : Controller
    {
        private Entities db = new Entities();
        // GET: Stuff
        [Route("Home")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var stuffs = from t in db.Stuffs
                           select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                stuffs = stuffs.Where(t => t.StuffName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    stuffs = stuffs.OrderByDescending(t => t.StuffName);
                    break;
                default:
                    stuffs = stuffs.OrderBy(t => t.StuffName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(stuffs.ToPagedList(pageNumber, pageSize));
        }

        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = db.Stuffs.Single(t => t.StuffID == id);
            var stuff = Mapper.Map<Stuff, StuffVM>(query);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            return View(stuff);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StuffVM stuffVM)
        {
            if (ModelState.IsValid)
            {
                var trainee = Mapper.Map<Stuff>(stuffVM);
                db.Stuffs.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stuffVM);
        }

        // GET: Edit
        public ActionResult Edit(int? id)
        {
            var query = db.Stuffs.Single(t => t.StuffID == id);
            var stuff = Mapper.Map<Stuff, StuffVM>(query);
            return View(stuff);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StuffVM stuffVM)
        {
            if (ModelState.IsValid)
            {
                var stuff = Mapper.Map<Stuff>(stuffVM);
                db.Entry(stuff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stuffVM);
        }

        // GET: Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            var query = db.Stuffs.Single(t => t.StuffID == id);
            var stuff = Mapper.Map<Stuff, StuffVM>(query);
            return View(stuff);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, StuffVM stuffVM)
        {
            var query = db.Stuffs.Single(t => t.StuffID == id);
            var stuff = Mapper.Map<Stuff, StuffVM>(query);
            db.Stuffs.Remove(query);  // 
            db.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public ActionResult Partial_View()
        {
            return View(db.Stuffs.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}