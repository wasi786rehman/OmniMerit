using OmniMerit.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniMerit.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult SignUp(StudentInfo studentInfo)
        {
            return View();
        }


    }
}