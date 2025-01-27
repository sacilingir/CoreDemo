using DataAccess.Abstract;
using DataAccess.Repository;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfCommentRepository:GenericRepository<Comment>,ICommentDal
    {
    }
}
