using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

using OmniMerit.Models.CustomModel;
using OmniMerit.Models.DataBase;

namespace OmniMerit.Controllers
{
   
   
    public class LoginController : Controller
    {
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                using (OmnimeritEntities modelentity = new OmnimeritEntities())
                {
                    var v = modelentity.logins.Where(model => model.Name.Equals(login.ID) && model.Password.Equals(login.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        
                        Session["LoggedUsername"] = v.Name.ToString();
                        return RedirectToAction("../Default/Profile");

                    }
                    else
                    {
                        ViewBag.Message = "Username or Password not correct!";

                        return RedirectToAction("../Default/Index");
                    }
                }
            }

            ViewBag.Message = "Invalid Login Details";
            return RedirectToAction("../Default/Index");
        }
    }
}
