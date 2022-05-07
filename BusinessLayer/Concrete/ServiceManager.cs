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
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Add(Service t)
        {
            _serviceDal.Add(t);
        }

        public void Delete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetById(id);
        }

        public List<Service> GetList()
        {
            return _serviceDal.GetList();
        }

        public List<Service> GetListInclude(string include)
        {
            return _serviceDal.GetListInclude(include);
        }

        public void Update(Service t)
        {
            _serviceDal.Update(t);
        }
    }
}
