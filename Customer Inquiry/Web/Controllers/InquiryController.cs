using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Contracts.IRepository;
using Entities.Commons.Enums;
using Repository.Repository;
using Web.Models;

namespace Web.Controllers
{
    public class InquiryController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;


        // GET
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private InquiryController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        private InquiryController()
        {
            _customerRepository = new CustomerRepository();
            _transactionRepository = new TransactionRepository();
        }

        // GET api/Inquiry/5
        [ValidateModel]
        public ActionResult Get([FromUri] InquiryCriteria inquiryCriteria)
        {
            if (ModelState.IsValid)
            {
                var result = _customerRepository.GetAll().Where(data =>
                        inquiryCriteria.Email == data.Email || inquiryCriteria.CustomerId == data.CustomerId).ToList()
                    .Select(customerInformation => new
                    {
                        customerInformation.CustomerId,
                        customerInformation.Name,
                        customerInformation.Email,
                        customerInformation.Mobile,
                        transactions = _transactionRepository.GetAll().Where(transactionData =>
                                transactionData.CustomerId == customerInformation.CustomerId).ToList()
                            .Select(transactions => new
                            {
                                transactions.Id,
                                date = transactions.DateAdded.ToString("dd/MM/yyyy HH:mm"),
                                amount = Math.Round(transactions.Amount, 2),
                                currency = Enum.GetName(typeof(CurrencyCode), transactions.CurrencyCode),
                                status = Enum.GetName(typeof(TransactionStatus), transactions.TransactionStatus)
                            }).ToList()
                    })
                    .ToList();


                if (result.Count > 0)
                    return new JsonResult
                    {
                        Data = result,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                return new JsonResult
                {
                    Data = "Not Found",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return null;
        }
    }
}