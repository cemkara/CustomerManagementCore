#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace CustomerManagementCore.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        ProductCategoryManager productCategoryManager = new ProductCategoryManager(new EfProductCategoryDal());
        public IActionResult Index()
        {
            var list = productManager.GetListInclude("ProductCategory");
            return View(list);
        }


        public IActionResult Add()
        {
            ViewData["ProductCategory"] = new SelectList(productCategoryManager.GetList(), "ProductCategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            ProductValidation validations = new ProductValidation();
            ValidationResult result = validations.Validate(product);
            if (result.IsValid)
            {
                product.Status = true;
                productManager.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ProductCategory"] = new SelectList(productCategoryManager.GetList(), "ProductCategoryId", "Name", product.ProductCategoryId);

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult StatusChange(int id)
        {
            Product product = productManager.GetById(id);
            product.Status = !product.Status;
            productManager.Update(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["ProductCategory"] = new SelectList(productCategoryManager.GetList(), "ProductCategoryId", "Name");

            var product = productManager.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductValidation validations = new ProductValidation();
            ValidationResult result = validations.Validate(product);
            if (result.IsValid)
            {
                productManager.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ProductCategory"] = new SelectList(productCategoryManager.GetList(), "ProductCategoryId", "Name", product.ProductCategoryId);

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
