using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcProject_Moin.Models;

namespace MvcProject_Moin.Controllers
{
    public class ExamDetailController : Controller
    {
        private Entities db = new Entities();

        // GET: ExamDetail
        public ActionResult Index()
        {
            var examDetails = db.ExamDetails.Include(e => e.Student);
            return View(examDetails.ToList());
        }

        //// GET: ExamDetail/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ExamDetail examDetail = db.ExamDetails.Find(id);
        //    if (examDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(examDetail);
        //}

        // GET: ExamDetail/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        // POST: ExamDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamDetailsID,ExamName,StudentID,ExamDate,ResultPublishDate,MCQ,Descriptive,Evidence,Total")] ExamDetail examDetail)
        {
            if (ModelState.IsValid)
            {
                db.ExamDetails.Add(examDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", examDetail.StudentID);
            return View(examDetail);
        }

        // GET: ExamDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", examDetail.StudentID);
            return View(examDetail);
        }

        // POST: ExamDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamDetailsID,ExamName,StudentID,ExamDate,ResultPublishDate,MCQ,Descriptive,Evidence,Total")] ExamDetail examDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", examDetail.StudentID);
            return View(examDetail);
        }

        // GET: ExamDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            return View(examDetail);
        }

        // POST: ExamDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamDetail examDetail = db.ExamDetails.Find(id);
            db.ExamDetails.Remove(examDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
