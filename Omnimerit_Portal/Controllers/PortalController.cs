using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omnimerit.Data.Model.Database;
using Omnimerit.Data.BussinessLayer;
namespace Omnimerit_Portal.Controllers
{
    public class PortalController : Controller
    {
        // GET: Portal
        public ActionResult Index()
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            
                Business business = new Business();
                Login log = business.Login(login);
                if (log.Id != 0)
                {
                   switch(log.User_Type)
                {
                    case "Admin": return RedirectToAction("../Admin/Index",log);
                    case "Employee": return RedirectToAction("../Employee/Index",log);
                    case "Student": return RedirectToAction("");
                    default: return RedirectToAction("Invalidcredential");

                }
                   return RedirectToAction("");
                }
                else
                {
                   return RedirectToAction("Invalidcredential");
                }
           

        }
        public ActionResult invalidcredential()
        {

            ViewBag.Message = "Invalid Login Details";
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            ViewBag.Message = "Successfully Logout";
            return View("Index");
        }

    }
}