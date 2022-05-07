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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product t)
        {
            _productDal.Add(t);
        }

        public void Delete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public List<Product> GetListInclude(string include)
        {
            return _productDal.GetListInclude(include);
        }

        public void Update(Product t)
        {
            _productDal.Update(t);
        }
    }
}
