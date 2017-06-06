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

       
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(login login)
        //{
           

        //    var errors = ModelState.Values.SelectMany(v => v.Errors);

        //    if (ModelState.IsValid)
        //    {
        //        Business business = new Business();
        //        if (business.Login(login))
        //        {
        //            TempData["number"] = login.Id;
        //            return RedirectToAction("../default/profile");
        //        }
        //        else
        //            return RedirectToAction("../Default/invalidcredential");
        //    }

        //    ViewBag.Message = "Invalid Login Details";
        //    return RedirectToAction("../Default/invalidcredential");
        //}

    }
}