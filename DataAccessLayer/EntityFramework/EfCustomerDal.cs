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
    public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        public List<Customer> GetListWithIncludes()
        {
            using var c = new Context();
            return c.Customers.Include(x => x.Phones).Include(x => x.Mails).ToList();
        }

        public List<Phone> GetPhones(int id)
        {
            using var c = new Context();
            return c.Phones.Where(x => x.CustomerId == id).ToList();
        }

        public List<Mail> GetMails(int id)
        {
            using var c = new Context();
            return c.Mails.Where(x => x.CustomerId == id).ToList();
        }
    }
}
