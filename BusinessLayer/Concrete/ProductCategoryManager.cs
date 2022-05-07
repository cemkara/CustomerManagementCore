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
    public class ProductCategoryManager : IProductCategoryService
    {
        IProductCategoryDal _productCategoryDal;

        public ProductCategoryManager(IProductCategoryDal productCategoryDal)
        {
            _productCategoryDal = productCategoryDal;
        }

        public void Add(ProductCategory t)
        {
            _productCategoryDal.Add(t);
        }

        public void Delete(ProductCategory t)
        {
            _productCategoryDal.Delete(t);
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryDal.GetById(id);
        }

        public List<ProductCategory> GetList()
        {
            return _productCategoryDal.GetList();
        }

        public List<ProductCategory> GetListInclude(string include)
        {
            return _productCategoryDal.GetListInclude(include);
        }

       
        public void Update(ProductCategory t)
        {
            _productCategoryDal.Update(t);
        }
    }
}
