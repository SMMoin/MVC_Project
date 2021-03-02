using MvcProject_Moin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject_Moin.Controllers
{
    public class CommitteMemberController : Controller
    {
        // GET: CommitteMember
        public ActionResult Index()
        {
            return View();
        }

        private Entities _db;
        public CommitteMemberController()
        {
            _db = new Entities();
        }
        
        public JsonResult List()
        {
            return Json(_db.CommitteMembers.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(CommitteMember committeMember)
        {
            _db.CommitteMembers.Add(committeMember);
            _db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_db.CommitteMembers.FirstOrDefault(x => x.MemberID == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(CommitteMember committeMember)
        {
            var data = _db.CommitteMembers.FirstOrDefault(x => x.MemberID == committeMember.MemberID);
            if (data != null)
            {
                data.Name = committeMember.Name;
                data.Address = committeMember.Address;
                data.ContactNo = committeMember.ContactNo;
                data.Age = committeMember.Age;
                _db.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _db.CommitteMembers.FirstOrDefault(x => x.MemberID == ID);
            _db.CommitteMembers.Remove(data);
            _db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}