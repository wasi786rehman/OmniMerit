using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmniMerit.Models.CustomModel;
namespace OmniMerit.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ShowResult()
        {
            //double number = Convert.ToDouble(Request.QueryString["number"].ToString());
            double number = 7618028191;
            double nn = Convert.ToDouble(TempData["number"].ToString());
            Result result = new Result();
            TempData.Keep();
            return Json(result.ShowResultModel(number), JsonRequestBehavior.AllowGet);
        }
    }
}