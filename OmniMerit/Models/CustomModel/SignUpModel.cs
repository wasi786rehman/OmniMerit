using OmniMerit.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniMerit.Models.CustomModel
{
    public class SignUpModel
    {
        
        public bool Signup(StudentInfo studentinfomodel)
        {
            OmniMerit.Models.DataBase.StudentInfo studentinfo = new DataBase.StudentInfo();

            int ui = Convert.ToInt32(DateTime.Now.ToString("MdHms"));
            int uid = Convert.ToInt32(ui);
            studentinfo.Uid =uid;

            studentinfo.Name = studentinfomodel.Name;
            studentinfo.Password = studentinfomodel.Password;
            studentinfo.Email = studentinfomodel.Email;
            studentinfo.Board = studentinfomodel.Board;
            studentinfo.Class = studentinfomodel.Class;
            studentinfo.Phone = studentinfomodel.Phone;

            try
            {
                using (OmnimeritEntities modelentity = new OmnimeritEntities())
                {

                    modelentity.StudentInfoes.Add(studentinfo);
                    modelentity.SaveChanges();
                    return true;
                    
                }
            }catch(Exception e)
            {
                return false;
            }

               
        }

    }
    public class StudentInfo
    {
        
        [Required(ErrorMessage = "Please provide Name .", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide Email Id.", AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide Phone.", AllowEmptyStrings = false)]
        public Nullable<int> Phone { get; set; }
        [Required(ErrorMessage = "Please provide Password.", AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please provide Class.", AllowEmptyStrings = false)]
        public string Class { get; set; }
        [Required(ErrorMessage = "Please provide Board.", AllowEmptyStrings = false)]
        public string Board { get; set; }

    }
}