using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmniMerit.Models.DataBase;
namespace OmniMerit.Models.CustomModel
{
    public class Result
    {
        public result ShowResultModel(double number)
        {
            try
            {
                using (omnimeritLocalEntities modelentity = new omnimeritLocalEntities())
                {
                    var v = modelentity.results.Where(model => model.Mobile_No==number);
                    return v.FirstOrDefault();

                    
                }
            }
            catch (Exception e) {
            return new result();}

        }
    }
}