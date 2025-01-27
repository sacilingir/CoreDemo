using DataAccess.Abstract;
using DataAccess.Concrete;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
       

        public void Delete(Category t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

      

        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public List<Category> GetListAll()
        {
            return c.Categories.ToList();
        }

        public void Insert(Category t)
        {
            c.Add(t);
            c.SaveChanges();
        }

      

        public void Update(Category t)
        {
            c.Update(t);
            c.SaveChanges();
        }

     
    }
}
