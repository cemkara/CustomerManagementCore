using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfIssueDal : GenericRepository<Issue>, IIssueDal
    {
        public List<Issue> GetListWithIncludes()
        {
            using var c = new Context();
            return c.Issues.Include(x => x.Customer).Include(x => x.Employe).Include(x => x.PaymentStatus).Include(x => x.Product).ToList();
        }
    }
}
