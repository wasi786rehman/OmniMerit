using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omnimerit.Data.Model.Database;
using Omnimerit.Data.BussinessLayer;

namespace Omnimerit_Portal.Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
           
            ViewBag.user = "Username";
            return View();
        }
        public ActionResult Admin()
        {

            ViewBag.user = "Username";
            return View();
        }
        public ActionResult MemberNotification()
        {
            return PartialView("MemberNotification");
        }
        public ActionResult Courses()
        {
            return PartialView("Courses",new Course());
        }
        public ActionResult Batch()
        {
            return PartialView("Batch");
        }
        public ActionResult ClassTeacherAllocation()
        {
            return PartialView("ClassTeacherAllocation");
        }
        public ActionResult Subject()
        {
            return PartialView("Subject");
        }
        public ActionResult SubjectAllocation()
        {
            return PartialView("SubjectAllocation");
        }
        public ActionResult AssignSubject()
        {
            return PartialView("AssignSubject");
        }
        public ActionResult LessonPlanning()
        {
            return PartialView("LessonPlanning");
        }


        #region Course
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {

            Business bussiness = new Business();
            bussiness.AddCourse(course);
           // return Json(, JsonRequestBehavior.AllowGet);
            return View("Index");
        }

        
        public JsonResult GetCourse()
        {
            Business bussiness = new Business();

            return Json(bussiness.GetCourse(0), JsonRequestBehavior.AllowGet);

        }
        
        #endregion Course

    }
}