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
        OmnimeritEntities db = new OmnimeritEntities();
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


        #region Generic
        public void Add<T>(T newItem) where T : class
        {
            try
            {
                db.Set<T>().Add(newItem);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
       }
        public void Delete<T>(T newItem) where T : class
        {
            try { 
            db.Entry(newItem).State = EntityState.Deleted;
            db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public List<T> Retrieve<T>() where T : class
        {
            try {

                return db.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public void Update<T>(T entity, Expression<Func<T, object>>[] properties) where T:class
        //{
        //    db.Entry(entity).State = EntityState.Unchanged;
        //    //foreach (var property in properties)
        //    //{, Expression<Func<T, object>>[] properties
        //    //    var propertyName = ExpressionHelper.GetExpressionText(property);
        //    //    DatabaseContext.Entry(entity).Property(propertyName).IsModified = true;
        //    //}
        //    //return DatabaseContext.SaveChangesWithoutValidation();
        //}
        //public virtual bool Exists(Guid id)
        //{
        //    return db.Set<T>().Any(t => t.Id == id);
        //}

        public  void Update<T>(T entity) where T:Course 
        {



            bool ifExist = db.Set<T>().Any(t => t.Id == entity.Id);
            if (ifExist)
            {


                // db.Set<T>().Where(t => t.Id == entity.Id);
                var oldEntity = db.Set<T>().Where(t => t.Id == entity.Id).FirstOrDefault();
                db.Entry(oldEntity).CurrentValues.SetValues(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                // Update(oldEntity);
            }

        }
       
        #endregion
    }
}
