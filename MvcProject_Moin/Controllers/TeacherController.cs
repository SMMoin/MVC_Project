using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using MvcProject_Moin.Models;
using System.Data.Entity;

namespace MvcProject_Moin.Controllers
{
    public class TeacherController : Controller
    {

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllTeacher());
        }

        IEnumerable<Teacher> GetAllTeacher()
        {
            using (Entities db = new Entities())
            {
                return db.Teachers.ToList<Teacher>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Teacher teach = new Teacher();
            if (id != 0)
            {
                using (Entities db = new Entities())
                {
                    teach = db.Teachers.Where(x => x.TeacherID == id).FirstOrDefault<Teacher>();
                }
            }
            return View(teach);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Teacher teach)
        {
            try
            {
                if (teach.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(teach.ImageUpload.FileName);
                    string extension = Path.GetExtension(teach.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    teach.ImagePath = "~/AppFiles/Images/" + fileName;
                    teach.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (Entities db = new Entities())
                {
                    if (teach.TeacherID == 0)
                    {
                        db.Teachers.Add(teach);
                        db.SaveChanges();

                    }
                    else
                    {
                        db.Entry(teach).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    Teacher teach = db.Teachers.Where(x => x.TeacherID == id).FirstOrDefault<Teacher>();
                    db.Teachers.Remove(teach);
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}