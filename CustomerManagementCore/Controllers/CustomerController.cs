using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementCore.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        MailManager mailManager = new MailManager(new EfMailDal());
        PhoneManager phoneManager = new PhoneManager(new EfPhoneDal());

        public IActionResult Index()
        {
            var list = customerManager.GetListWithIncludes();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            CustomerValidation validations = new CustomerValidation();
            ValidationResult result = validations.Validate(customer);
            if (result.IsValid)
            {

                customer.Status = true;
                customerManager.Add(customer);

                phoneManager.Add(new Phone { Number = customer.Phone, CustomerId = customer.CustomerId });
                mailManager.Add(new Mail { Address = customer.Mail, CustomerId = customer.CustomerId });
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = customerManager.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            CustomerValidation validations = new CustomerValidation();
            ValidationResult result = validations.Validate(customer);
            if (result.IsValid)
            {
                customerManager.Update(customer);
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

        public IActionResult Phones(int id)
        {
            var list = customerManager.GetPhones(id);
            ViewBag.customerId = id;
            return View(list);
        }

        [HttpGet]
        public IActionResult PhoneAdd(int id)
        {
            Customer customer = customerManager.GetById(id);
            Phone phone = new Phone();
            phone.CustomerId = customer.CustomerId;
            phone.Status = true;
            ViewBag.customerName = customer.Name + " " + customer.Surname;
            return View(phone);
        }

        [HttpPost]
        public IActionResult PhoneAdd(Phone phone)
        {
            PhoneValidation validations = new PhoneValidation();
            ValidationResult result = validations.Validate(phone);
            if (result.IsValid)
            {
                phoneManager.Add(phone);
                return RedirectToAction("Phones", new { id = phone.CustomerId });
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

        public IActionResult PhoneStatusChange(int id)
        {
            Phone phone = phoneManager.GetById(id);
            phone.Status = !phone.Status;
            phoneManager.Update(phone);
            return RedirectToAction("Phones", new { id = phone.CustomerId });
        }

        public IActionResult Mails(int id)
        {
            var list = customerManager.GetMails(id);
            ViewBag.customerId = id;
            return View(list);
        }

        [HttpGet]
        public IActionResult MailAdd(int id)
        {
            Customer customer = customerManager.GetById(id);
            Mail mail = new Mail();
            mail.CustomerId = customer.CustomerId;
            mail.Status = true;
            ViewBag.customerName = customer.Name + " " + customer.Surname;
            return View(mail);
        }

        [HttpPost]
        public IActionResult MailAdd(Mail mail)
        {
            MailValidation validations = new MailValidation();
            ValidationResult result = validations.Validate(mail);
            if (result.IsValid)
            {
                mailManager.Add(mail);
                return RedirectToAction("Mails", new { id = mail.CustomerId });
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

        public IActionResult MailStatusChange(int id)
        {
            Mail mail = mailManager.GetById(id);
            mail.Status = !mail.Status;
            mailManager.Update(mail);
            return RedirectToAction("Mails", new { id = mail.CustomerId });
        }
    }
}
