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
           // ViewBag.Categories = new MultiSelectList
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

            Course cc = new Course();
            cc.Code = "101";
            return PartialView("Courses",cc);
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
        public ActionResult SetTimeTable()
        {
            return PartialView("SetTimeTable");
        }
        public ActionResult ActiveTimeTable()
        {
            return PartialView("ActiveTimeTable");
        }
        public ActionResult Circular()
        {
            return PartialView("Circular");
        }
        public ActionResult Assignment()
        {
            return PartialView("Assignment");
        }
        public ActionResult Notes()
        {
            return PartialView("Notes");
        }
        public ActionResult UserType()
        {
            return PartialView("UserType");
        }
        public ActionResult Department()
        {
            return PartialView("Department");
        }
        public ActionResult Designation()
        {
            return PartialView("Designation");
        }
        public ActionResult Employee()
        {
            return PartialView("Employee");
        }
        public ActionResult EmployeeList()
        {
            return PartialView("EmployeeList");
        }
        public ActionResult Bank()
        {
            return PartialView("Bank");
        }
        public ActionResult Route()
        {
            return PartialView("Route");
        }
        public ActionResult Vehicle()
        {
            return PartialView("Vehicle");
        }
        public ActionResult Driver()
        {
            return PartialView("Driver");
        }
        public ActionResult Destination()
        {
            return PartialView("Destination");
        }
        public ActionResult TransportAllocation()
        {
            return PartialView("TransportAllocation");
        }
        public ActionResult BookCategory()
        {
            return PartialView("BookCategory");
        }
        public ActionResult Books()
        {
            return PartialView("Books");
        }
        public ActionResult IssueBooks()
        {
            return PartialView("IssueBooks");
        }
        public ActionResult RequestDetail()
        {
            return PartialView("RequestDetail");
        }
        public ActionResult BookReturn()
        {
            return PartialView("BookReturn");
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
        public JsonResult DeleteCourse(string Id)
        {
            Course c = new Course();
            c.Id = Convert.ToInt16(Id);
            Business bussiness = new Business();
            bussiness.Delete<Course>(c);
           // bussiness.Update<Course>(c);
            return Json("", JsonRequestBehavior.AllowGet);

        }

        #endregion Course

        #region Batch
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
        #endregion Batch
    }
}