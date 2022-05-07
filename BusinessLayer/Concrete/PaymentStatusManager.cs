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
    public class PaymentStatusManager : IPaymentStatusService
    {
        IPaymentStatusDal _paymentStatusDal;

        public PaymentStatusManager(IPaymentStatusDal caymentStatusDal)
        {
            _paymentStatusDal = caymentStatusDal;
        }

        public void Add(PaymentStatus t)
        {
            _paymentStatusDal.Add(t);
        }

        public void Delete(PaymentStatus t)
        {
            _paymentStatusDal.Delete(t);
        }

        public PaymentStatus GetById(int id)
        {
            return _paymentStatusDal.GetById(id);
        }

        public List<PaymentStatus> GetList()
        {
            return _paymentStatusDal.GetList();
        }

        public List<PaymentStatus> GetListInclude(string include)
        {
            return _paymentStatusDal.GetListInclude(include);
        }

       

        public void Update(PaymentStatus t)
        {
            _paymentStatusDal.Update(t);
        }
    }
}
