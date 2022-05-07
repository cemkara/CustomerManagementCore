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
    public class EmployeManager : IEmployeService
    {
        IEmployeDal _employeDal;

        public EmployeManager(IEmployeDal employeDal)
        {
            this._employeDal = employeDal;
        }

        public void Add(Employe t)
        {
            _employeDal.Add(t);
        }

        public void Delete(Employe t)
        {
            _employeDal.Delete(t);
        }

        public Employe GetById(int id)
        {
            return _employeDal.GetById(id);
        }

        public List<Employe> GetList()
        {
            return _employeDal.GetList();
        }

        public List<Employe> GetListInclude(string include)
        {
            return _employeDal.GetListInclude(include);
        }


        public void Update(Employe t)
        {
            _employeDal.Update(t);
        }
    }
}
