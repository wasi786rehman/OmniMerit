using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmniMerit.Models.DataBase;
namespace OmniMerit.Models.CustomModel
{
    public class ResultModel
    {
        public List<result> ShowResultModel(double number)
        {
            try
            {
                using (omnimeritLocalEntities modelentity = new omnimeritLocalEntities())
                {
                    var v = modelentity.results.Where(model => model.Mobile_No==number).FirstOrDefault();
                    List<result> list = new List<result>();
                    list.Add(v);
                    return list;
                    

                    
                }
            }
            catch (Exception e) {
            return new List<result>();}

        }
    }
}