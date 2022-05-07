using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementCore.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            var list = serviceManager.GetList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Service service)
        {
            ServiceValidation validations = new ServiceValidation();
            ValidationResult result = validations.Validate(service);
            if (result.IsValid)
            {
                serviceManager.Add(service);
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
            Service status = serviceManager.GetById(id);
            serviceManager.Delete(status);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var status = serviceManager.GetById(id);
            return View(status);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            ServiceValidation validations = new ServiceValidation();
            ValidationResult result = validations.Validate(service);
            if (result.IsValid)
            {
                serviceManager.Update(service);
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
