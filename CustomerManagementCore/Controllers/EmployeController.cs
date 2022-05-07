using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerManagementCore.Controllers
{
    public class EmployeController : Controller
    {
        EmployeManager employeManager = new EmployeManager(new EfEmployeDal());
        EmployeTypeManager employeTypeManager = new EmployeTypeManager(new EfEmployeTypeDal());

        public IActionResult Index()
        {
            var list = employeManager.GetListInclude("EmployeType");
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Types"] = new SelectList(employeTypeManager.GetList(), "EmployeTypeId", "Type");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employe employe)
        {
            EmployeValidation validations = new EmployeValidation();
            ValidationResult result = validations.Validate(employe);
            if (result.IsValid)
            {
                employe.Status = true;
                employeManager.Add(employe);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Types"] = new SelectList(employeTypeManager.GetList(), "EmployeTypeId", "Type");
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult StatusChange(int id)
        {
            Employe employe = employeManager.GetById(id);
            employe.Status = !employe.Status;
            employeManager.Update(employe);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Types"] = new SelectList(employeTypeManager.GetList(), "EmployeTypeId", "Type");

            var type = employeManager.GetById(id);
            return View(type);
        }

        [HttpPost]
        public IActionResult Edit(Employe employe)
        {
            EmployeValidation validations = new EmployeValidation();
            ValidationResult result = validations.Validate(employe);
            if (result.IsValid)
            {
                employeManager.Update(employe);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Types"] = new SelectList(employeTypeManager.GetList(), "EmployeTypeId", "Type");

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
