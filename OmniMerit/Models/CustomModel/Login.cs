using OmniMerit.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmniMerit.Models.CustomModel
{
    public class Login
    {
        [Required(ErrorMessage = "Please provide username.", AllowEmptyStrings = false)]
        public string ID { get; set; }
        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        public bool LoginModel(Login login)
        {
            try
            {
                using (OmnimeritEntities modelentity = new OmnimeritEntities())
                {
                    var v = modelentity.logins.Where(model => model.Name.Equals(login.ID) && model.Password.Equals(login.Password)).Count();

                    if (v == 1)
                        return true;
                    else
                        return false;
                }
            }catch(Exception e) { return false; }
        }
    }
   
}