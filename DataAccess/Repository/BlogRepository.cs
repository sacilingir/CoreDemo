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
    public class BlogRepository : IBlogDal
    {
        Context c = new Context();
        
        public void AddBlog(Blog blog)
        {
            c.Add(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            c.Remove(blog);
        }

        public Blog GetById(int id)
        {
            return c.Blogs.Find(id);
        }

        public List<Blog> ListAllBlog()
        {
            return c.Blogs.ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            c.Update(blog);
        }
    }
}
