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
    public class PhoneManager : IPhoneService
    {
        IPhoneDal _phoneDal;

        public PhoneManager(IPhoneDal phoneDal)
        {
            _phoneDal = phoneDal;
        }

        public void Add(Phone t)
        {
            _phoneDal.Add(t);
        }

        public void Delete(Phone t)
        {
            _phoneDal.Delete(t);
        }

        public Phone GetById(int id)
        {
            return _phoneDal.GetById(id);
        }

        public List<Phone> GetList()
        {
            return _phoneDal.GetList();
        }

        public List<Phone> GetListInclude(string include)
        {
            return _phoneDal.GetListInclude(include);
        }

        

        public void Update(Phone t)
        {
            _phoneDal.Update(t);
        }
    }
}
