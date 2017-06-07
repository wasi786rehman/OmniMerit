using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omnimerit.Data.Model.Database;
using Omnimerit.Data.BussinessLayer;
using Newtonsoft.Json;

namespace Omnimerit_Portal.Admin
{
    public class AdminController : Controller
    {
        Business bussiness = new Business();
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
            ViewBag.Course = bussiness.Retrieve<Course>();

            return PartialView("Batch");
        }
        public ActionResult ClassTeacherAllocation()
        {
            ViewBag.Course = bussiness.Retrieve<Course>();
            ViewBag.Batch = bussiness.Retrieve<Batch>();
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

            try
            {
                if(course.Id==0)
                bussiness.Add<Course>(course);
                else
                bussiness.Update<Course>(course);
                return View("Courses");
            }
            catch (Exception e)
            {
                return View("Index");
            }
            
        }

        
        public JsonResult GetCourse()
        {
            Business bussiness = new Business();

            return Json(bussiness.Retrieve<Course>(), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Delete(string Id)
        {
            Course c = new Course();
            c.Id = Convert.ToInt16(Id);
            Business bussiness = new Business();
            bussiness.Delete<Course>(c);
           // bussiness.Update<Course>(c);
            return Json("", JsonRequestBehavior.AllowGet);

        }

        #endregion Course


        public ActionResult AddBatch(Batch batch)
        {
           
            try
            {
                if (batch.Id == 0)
                    bussiness.Add<Batch>(batch);
                else
                    bussiness.Update<Batch>(batch);
                return RedirectToAction("Batch");
            }
            catch (Exception e)
            {
                return View("Index");
            }

        }
        public JsonResult GetBatch()
        {
            Business bussiness = new Business();

            var list = JsonConvert.SerializeObject(bussiness.Retrieve<Batch>(),Formatting.None,new JsonSerializerSettings(){
                DateFormatString = "yyyy-MM-dd",
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            return Json(list, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult DeleteBatch(string Id)
        {   Batch c = new Batch();
            c.Id = Convert.ToInt16(Id);
            Business bussiness = new Business();
            bussiness.Delete<Batch>(c);
            
            return Json("", JsonRequestBehavior.AllowGet);

        }

    }
}