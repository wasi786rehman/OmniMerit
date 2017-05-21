using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
        #region Course
        public bool AddCourse(Course entity)
        {
            try
            {

                using (OmnimeritEntities modelEntity = new OmnimeritEntities())
                {

                    modelEntity.Courses.Add(entity);
                    modelEntity.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex) { throw ex; }
    

       }

        public List<Course> GetCourse(int id)
        {
            List<Course> courseList;
            
                try
                {
                    using (OmnimeritEntities modelEntity = new OmnimeritEntities())
                    {

                    if(id==0)
                    {
                        courseList = (from course in modelEntity.Courses
                                      select course).ToList();
                    }
                    else
                    {
                        courseList = (from course in modelEntity.Courses
                                      select course).Where(x=>x.Id==id).ToList();
                    }
                       
                        return courseList;
                    }
                }
                catch (Exception ex) {

                throw ex;
            }
            
        }

        #endregion Course
    }
}
