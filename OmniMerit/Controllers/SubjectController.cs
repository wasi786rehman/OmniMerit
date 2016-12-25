using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OmniMerit.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject



        [HttpPost]
        public JsonResult GetData()
        {
            string file = Server.MapPath(@"../../Scripts/Json/classXII.json");
            string filecontent = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            object jsonobject = ser.DeserializeObject(filecontent);
            return Json(jsonobject, JsonRequestBehavior.AllowGet);
        }
    }
}