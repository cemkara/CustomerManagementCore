using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementCore.Controllers
{
    public class PaymentStatusController : Controller
    {
        PaymentStatusManager paymentStatusManager = new PaymentStatusManager(new EfPaymentStatusDal());

        public IActionResult Index()
        {
            var list = paymentStatusManager.GetList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PaymentStatus paymentStatus)
        {
            PaymentStatusValidation validations = new PaymentStatusValidation();
            ValidationResult result = validations.Validate(paymentStatus);
            if (result.IsValid)
            {
                paymentStatusManager.Add(paymentStatus);
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
            PaymentStatus status = paymentStatusManager.GetById(id);
            paymentStatusManager.Delete(status);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var status = paymentStatusManager.GetById(id);
            return View(status);
        }

        [HttpPost]
        public IActionResult Edit(PaymentStatus paymentStatus)
        {
            PaymentStatusValidation validations = new PaymentStatusValidation();
            ValidationResult result = validations.Validate(paymentStatus);
            if (result.IsValid)
            {
                paymentStatusManager.Update(paymentStatus);
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
