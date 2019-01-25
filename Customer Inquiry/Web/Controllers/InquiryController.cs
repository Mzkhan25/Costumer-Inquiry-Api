using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Contracts;
using Contracts.IRepository;
using Entities.Commons.Enums;
using Newtonsoft.Json;
using Repository.Repository;
using Web.Models;

namespace Web.Controllers
{
    public class InquiryController : ApiController
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerRepository _customerRepository;


        // GET
        //public ActionResult Index()
        //{
        //    return View();
        //}
        InquiryController(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }
        InquiryController()
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
                var result = _customerRepository.GetAll().
                    Where(data => inquiryCriteria.Email == data.Email || inquiryCriteria.CustomerId == data.CustomerId).ToList()
                    .Select(customerInformation => new
                    {
                        customerInformation.CustomerId,
                        customerInformation.Name,
                        customerInformation.Email,
                        customerInformation.Mobile,
                        transactions = _transactionRepository.GetAll().
                            Where(transactiondata => transactiondata.CustomerId == customerInformation.CustomerId).ToList()
                            .Select(transactions => new
                            {
                                transactions.Id,
                                date = transactions.DateAdded.ToString("dd/MM/yyyy HH:mm"),
                                amount = System.Math.Round(transactions.Amount, 2),
                                currency = CurrencyCode.GetName(typeof(CurrencyCode), transactions.CurrencyCode),
                                status = TransactionStatus.GetName(typeof(TransactionStatus), transactions.TransactionStatus),
                            }).ToList()

                    })
                    .ToList();


                if (result.Count > 0)
                {
                    return new JsonResult()
                    {
                        Data = result,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else {
                    return new JsonResult()
                    {
                        Data = "Not Found",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };

                }


            }
            else
                return null;
          
        }
    }
}