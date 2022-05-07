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
    public class IssueManager : IIssueService
    {
        IIssueDal _issueDal;

        public IssueManager(IIssueDal issueDal)
        {
            _issueDal = issueDal;
        }

        public void Add(Issue t)
        {
            _issueDal.Add(t);
        }

        public void Delete(Issue t)
        {
            _issueDal.Delete(t);
        }

        public Issue GetById(int id)
        {
            return _issueDal.GetById(id);
        }

        public List<Issue> GetList()
        {
            return _issueDal.GetList();
        }

        public List<Issue> GetListInclude(string include)
        {
            return _issueDal.GetListInclude(include);
        }

        public List<Issue> GetListWithIncludes()
        {
            return _issueDal.GetListWithIncludes();
        }

        public void Update(Issue t)
        {
            _issueDal.Update(t);
        }
    }
}
