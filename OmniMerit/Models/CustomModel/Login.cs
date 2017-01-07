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
        
    }
}