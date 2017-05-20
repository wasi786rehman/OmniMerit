using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnimerit.Data.Model.Database;

namespace Omnimerit.Data.BussinessLayer
{
    public class Business
    {
        
        public bool Login(login login)
        {
            try
            {
                double number = Convert.ToDouble(login.Id);
                double password = Convert.ToDouble(login.Password);
                using (OmnimeritEntities modelentity = new OmnimeritEntities())
                {
                    var v = modelentity.AirResults.Where(model => model.Mobile_No == number && model.Mobile_No == password).Count();

                    if (v == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e) { return false; }
        }


    }
}
