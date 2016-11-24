using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace OmniMerit.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Career()
        {
            return View();
        }
        public ActionResult Career1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResumeUpload(FormCollection fc, HttpPostedFileBase file)
        {
            string name=string.Empty;
            string email=string.Empty;
            string path="";
            if (fc[0].ToString()!=null && fc[1].ToString()!=null)
            {
                 name = fc["name"].ToString();
                 email = fc["email"].ToString();
            }

            if (file != null && file.ContentLength > 0)
                try
                {
                     path = Path.Combine(Server.MapPath("~/Scripts/Images/resume"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
           


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("wasi786rehman@gmail.com");
            mail.To.Add("wasi_rehman@live.com");
            mail.Subject = "Resume: "+name+"-Email: "+email;
            mail.Body = "mail with attachment";

            if (path != "")
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(path);
                mail.Attachments.Add(attachment);
            }
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("wasi786rehman@gmail.com", "wasi_rehman@184");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return RedirectToAction("Career");
        }
    }
}