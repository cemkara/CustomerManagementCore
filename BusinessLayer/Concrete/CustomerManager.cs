using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer t)
        {
            _customerDal.Add(t);
        }

        public void Delete(Customer t)
        {
            _customerDal.Delete(t);
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> GetList()
        {
            return _customerDal.GetList();
        }

        public List<Customer> GetListInclude(string include)
        {
            return _customerDal.GetListInclude(include);
        }

        public void Update(Customer t)
        {
            _customerDal.Update(t);
        }

        public List<Customer> GetListWithIncludes()
        {
            return _customerDal.GetListWithIncludes();
        }

        public List<Phone> GetPhones(int id)
        {
            return _customerDal.GetPhones(id);
        }
        public List<Mail> GetMails(int id)
        {
            return _customerDal.GetMails(id);
        }
    }
}
