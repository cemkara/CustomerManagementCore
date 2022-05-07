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
    public class MailManager : IMailService
    {
        IMailDal _mailDal;

        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public void Add(Mail t)
        {
            _mailDal.Add(t);
        }

        public void Delete(Mail t)
        {
            _mailDal.Delete(t);
        }

        public Mail GetById(int id)
        {
            return _mailDal.GetById(id);
        }

        public List<Mail> GetList()
        {
            return _mailDal.GetList();
        }

        public List<Mail> GetListInclude(string include)
        {
            return _mailDal.GetListInclude(include);
        }

       
        public void Update(Mail t)
        {
            _mailDal.Update(t);
        }
    }
}
