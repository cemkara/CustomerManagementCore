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
    public class EmployeTypeManager : IEmployeTypeService
    {
        IEmployeTypeDal _employeTypeDal;

        public EmployeTypeManager(IEmployeTypeDal employeDal)
        {
            this._employeTypeDal = employeDal;
        }

        public void Add(EmployeType t)
        {
            _employeTypeDal.Add(t);
        }

        public void Delete(EmployeType t)
        {
            _employeTypeDal.Delete(t);
        }

        public EmployeType GetById(int id)
        {
            return _employeTypeDal.GetById(id);
        }

        public List<EmployeType> GetList()
        {
            return _employeTypeDal.GetList();
        }

        public List<EmployeType> GetListInclude(string include)
        {
            return _employeTypeDal.GetListInclude(include);
        }


        public void Update(EmployeType t)
        {
            _employeTypeDal.Update(t);
        }
    }
}
