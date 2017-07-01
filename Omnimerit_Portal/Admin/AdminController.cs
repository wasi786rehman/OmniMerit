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
        #region View
        public ActionResult Index(Login log)
        {

            Session["user"] = log.User_Id;
            Session["Institution_Code"]= log.Institution_Code;
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
            
            return PartialView("Courses");
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
            
            ViewBag.Course = bussiness.Retrieve<Course>();
            ViewBag.Batch = bussiness.Retrieve<Batch>();
            ViewBag.Subject = bussiness.Retrieve<Subject>();
            
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

        #endregion View

        #region Course
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            
            
            try
            {

                if (course.Id == 0)
                {
                   
                    course.Created_By = Session["user"].ToString();
                    course.Institution_Code = Session["Institution_Code"].ToString();
                    course.Created_On = DateTime.Now;
                    bussiness.Add<Course>(course);
                }
                else
                {
                    course.Modified_By = Session["user"].ToString();
                    course.Modified_On = DateTime.Now;
                    bussiness.Update<Course>(course);
                }

                ModelState.Clear();
                return View("Courses");
            }
            catch (Exception e)
            {
                return View("Index");
            }
            
        }

        
        public JsonResult GetCourse()
        {

            try
            {
                string Institution_Code = Session["Institution_Code"].ToString();
                var course = (from f in bussiness.Retrieve<Course>()
                        where f.Institution_Code == Institution_Code
                        select f).ToList();

                return Json(course, JsonRequestBehavior.AllowGet);
            } catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult DeleteCourse(string Id)
        {

            Course c = new Course();
            c.Id = Convert.ToInt16(Id);
            Business bussiness = new Business();
            bussiness.Delete<Course>(c);
           
            return Json("", JsonRequestBehavior.AllowGet);

        }

        #endregion Course

        #region Batch
        public ActionResult AddBatch(Batch batch)
        {
           
            try
            {
                if (batch.Id == 0)
                {
                    batch.Created_By = Session["user"].ToString();
                    batch.Institution_Code = Session["Institution_Code"].ToString();

                    bussiness.Add<Batch>(batch);
                }
                else
                {
                    batch.Modified_By = Session["user"].ToString();
                    batch.Modified_On = DateTime.Now;
                    bussiness.Update<Batch>(batch);
                }

                return RedirectToAction("Batch");
            }
            catch (Exception e)
            {
                return View("Index");
            }

        }
        public JsonResult GetBatch()
        {
            try { 

            var list = JsonConvert.SerializeObject(bussiness.Retrieve<Batch>(), Formatting.None, new JsonSerializerSettings() {
                DateFormatString = "yyyy-MM-dd",
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            

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

        #region UserType
        public ActionResult AddUserType(User_Type userType)
        {
            try
            {
                if (userType.Id == 0)
                {
                    userType.Created_By = Session["user"].ToString();
                    userType.Institution_Code = Session["Institution_Code"].ToString();
                
                    bussiness.Add<User_Type>(userType);
                }
                 else
                {
                    userType.Modified_By = Session["user"].ToString();
                    userType.Modified_On = DateTime.Now;
                    bussiness.Update<User_Type>(userType);
                }

                ModelState.Clear();
                return View("UserType");
            }
            catch (Exception e)
            {
                return View("Index");
            }
        }
        public JsonResult GetUserType()
        {
            try
            {

                return Json(bussiness.Retrieve<User_Type>(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult DeleteUserType(string Id)
        {
            try
            {
                User_Type c = new User_Type();
                c.Id = Convert.ToInt16(Id);
                bussiness.Delete<User_Type>(c);
                return Json("", JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        #endregion UserType

        #region Subject
        public ActionResult AddSubject(Subject subject)
        {
            try
            {
                if (subject.Id == 0)
                {
                    subject.Created_By = Session["user"].ToString();
                    subject.Institution_Code = Session["Institution_Code"].ToString();

                    bussiness.Add<Subject>(subject);
                }
                 else
                {
                    subject.Modified_By = Session["user"].ToString();
                    subject.Modified_On = DateTime.Now;
                    bussiness.Update<Subject>(subject);
                }

                ModelState.Clear();
                return View("Subject");
            }
            catch (Exception e)
            {
                return View("Index");
            }
        }
        public JsonResult GetSubject()
        {
            try
            {

                return Json(bussiness.Retrieve<Subject>(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult DeleteSubject(string Id)
        {
            try
            {
                Subject c = new Subject();
                c.Id = Convert.ToInt16(Id);
                bussiness.Delete<Subject>(c);
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        #endregion Subject

        #region Department
        public ActionResult AddDepartment(Department department)
        {
            try
            {
                if (department.Id == 0)
                {
                    department.Created_By = Session["user"].ToString();
                    department.Institution_Code = Session["Institution_Code"].ToString();

                    bussiness.Add<Department>(department);
                }else
                {
                    department.Modified_By = Session["user"].ToString();
                    department.Modified_On = DateTime.Now;
                    bussiness.Update<Department>(department);
                }

                ModelState.Clear();
                return View("Department");
            }
            catch (Exception e)
            {
                return View("Index");
            }
        }
        public JsonResult GetDepartment()
        {
            try
            {

                return Json(bussiness.Retrieve<Department>(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult DeleteDepartment(string Id)
        {
            try
            {
                Department c = new Department();
                c.Id = Convert.ToInt16(Id);
                bussiness.Delete<Department>(c);
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        #endregion Department

        #region Designation
        public ActionResult AddDesignation(Designation designation)
        {
            try
            {
                if (designation.Id == 0)
                {
                    designation.Created_By = Session["user"].ToString();
                    designation.Institution_Code = Session["Institution_Code"].ToString();

                    bussiness.Add<Designation>(designation);
                }else
                {
                    designation.Modified_By = Session["user"].ToString();
                    designation.Modified_On = DateTime.Now;
                    bussiness.Update<Designation>(designation);
                }

                ModelState.Clear();
                return View("Designation");
            }
            catch (Exception e)
            {
                return View("Index");
            }
        }
        public JsonResult GetDesignation()
        {
            try
            {

                return Json(bussiness.Retrieve<Designation>(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult DeleteDesignation(string Id)
        {
            try
            {
                Designation c = new Designation();
                c.Id = Convert.ToInt16(Id);
                bussiness.Delete<Designation>(c);
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        #endregion UserType

        #region BankDetail
        public ActionResult AddBankDetail(Bank_Detail bankDetail)
        {
            try
            {
                if (bankDetail.Id == 0)
                {
                    bankDetail.Created_By = Session["user"].ToString();
                    bankDetail.Institution_Code = Session["Institution_Code"].ToString();

                    bussiness.Add<Bank_Detail>(bankDetail);
                } else
                {
                    bankDetail.Modified_By = Session["user"].ToString();
                    bankDetail.Modified_On = DateTime.Now;
                    bussiness.Update<Bank_Detail>(bankDetail);
                }

                ModelState.Clear();
                return View("Bank");
            }
            catch (Exception e)
            {
                return View("Index");
            }
        }
        public JsonResult GetBankDetail()
        {
            try
            {

                return Json(bussiness.Retrieve<Bank_Detail>(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult DeleteBankDetail(string Id)
        {
            try
            {
                Bank_Detail c = new Bank_Detail();
                c.Id = Convert.ToInt16(Id);
                bussiness.Delete<Bank_Detail>(c);
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        #endregion BankDetail
    }
}