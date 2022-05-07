using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerManagementCore.Controllers
{
    public class IssueController : Controller
    {
        IssueManager issueManager = new IssueManager(new EfIssueDal());
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        ProductManager productManager = new ProductManager(new EfProductDal());
        PaymentStatusManager statusManager = new PaymentStatusManager(new EfPaymentStatusDal());
        EmployeManager employeManager = new EmployeManager(new EfEmployeDal());

        public IActionResult Index()
        {
            var list = issueManager.GetListWithIncludes();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["customerList"] = new SelectList(customerManager.GetList(), "CustomerId", "Name");
            ViewData["productList"] = new SelectList(productManager.GetList(), "ProductId", "Name");
            ViewData["paymentStatusList"] = new SelectList(statusManager.GetList(), "PaymentStatusId", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Add(Issue issue)
        {
            IssueValidation validations = new IssueValidation();
            ValidationResult result = validations.Validate(issue);
            if (result.IsValid)
            {
                issue.Status = true;
                issue.ArrivalDate = DateTime.Now;
                issueManager.Add(issue);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["customerList"] = new SelectList(customerManager.GetList(), "CustomerId", "Name");
                ViewData["productList"] = new SelectList(productManager.GetList(), "ProductId", "Name");
                ViewData["paymentStatusList"] = new SelectList(statusManager.GetList(), "PaymentStatusId", "Name");

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult StatusChange(int id)
        {
            Issue issue = issueManager.GetById(id);
            issue.Status = !issue.Status;
            issueManager.Update(issue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["customerList"] = new SelectList(customerManager.GetList(), "CustomerId", "Name");
            ViewData["productList"] = new SelectList(productManager.GetList(), "ProductId", "Name");
            ViewData["paymentStatusList"] = new SelectList(statusManager.GetList(), "PaymentStatusId", "Name");
            ViewData["employeList"] = new SelectList(employeManager.GetList(), "EmployeId", "Name");

            Issue issue = issueManager.GetById(id);
            return View(issue);
        }

        [HttpPost]
        public IActionResult Edit(Issue issue)
        {
            IssueValidation validations = new IssueValidation();
            ValidationResult result = validations.Validate(issue);
            if (result.IsValid)
            {
                issueManager.Update(issue);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["customerList"] = new SelectList(customerManager.GetList(), "CustomerId", "Name");
                ViewData["productList"] = new SelectList(productManager.GetList(), "ProductId", "Name");
                ViewData["paymentStatusList"] = new SelectList(statusManager.GetList(), "PaymentStatusId", "Name");
                ViewData["employeList"] = new SelectList(employeManager.GetList(), "EmployeId", "Name");


                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
