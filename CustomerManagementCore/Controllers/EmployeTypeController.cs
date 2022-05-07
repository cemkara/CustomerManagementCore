using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementCore.Controllers
{
    public class EmployeTypeController : Controller
    {
        EmployeTypeManager employeTypeManager = new EmployeTypeManager(new EfEmployeTypeDal());
        public IActionResult Index()
        {
            var list = employeTypeManager.GetList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeType employeType)
        {
            EmployeTypeValidation validations = new EmployeTypeValidation();
            ValidationResult result = validations.Validate(employeType);
            if (result.IsValid)
            {
                employeType.Status = true;
                employeTypeManager.Add(employeType);
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
            EmployeType type = employeTypeManager.GetById(id);
            employeTypeManager.Delete(type);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var type = employeTypeManager.GetById(id);
            return View(type);
        }

        [HttpPost]
        public IActionResult Edit(EmployeType employeType)
        {
            EmployeTypeValidation validations = new EmployeTypeValidation();
            ValidationResult result = validations.Validate(employeType);
            if (result.IsValid)
            {
                employeTypeManager.Update(employeType);
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
