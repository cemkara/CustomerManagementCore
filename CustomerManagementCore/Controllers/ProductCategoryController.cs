using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementCore.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryManager productCategoryManager = new ProductCategoryManager(new EfProductCategoryDal());

        public IActionResult Index()
        {
            var list = productCategoryManager.GetList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductCategory productCategory)
        {
            ProductCategoryValidation validations = new ProductCategoryValidation();
            ValidationResult result = validations.Validate(productCategory);
            if (result.IsValid)
            {
                productCategoryManager.Add(productCategory);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult Remove(int id)
        {
            ProductCategory status = productCategoryManager.GetById(id);
            status.Status = false;
            productCategoryManager.Update(status);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var status = productCategoryManager.GetById(id);
            return View(status);
        }

        [HttpPost]
        public IActionResult Edit(ProductCategory productCategory)
        {
            ProductCategoryValidation validations = new ProductCategoryValidation();
            ValidationResult result = validations.Validate(productCategory);
            if (result.IsValid)
            {
                productCategoryManager.Update(productCategory);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
