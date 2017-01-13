﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

using OmniMerit.Models.CustomModel;


namespace OmniMerit.Controllers
{
   
   
    public class LoginController : Controller
    {
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            OmniMerit.Models.CustomModel.Login loginmodel = new Models.CustomModel.Login();

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
               if(loginmodel.LoginModel(login))
                return RedirectToAction("../default/profile");
               else
                return RedirectToAction("../Default/Index");
            }

            ViewBag.Message = "Invalid Login Details";
            return RedirectToAction("../Default/Index");
        }
    }
}
