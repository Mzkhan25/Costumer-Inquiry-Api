using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Contracts.IRepository;
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

        // GET api/Inquiry/5
        public string Get([FromUri] InquiryCriteria inquiryCriteria)
        {
            if (ModelState.IsValid)
            {
                // Do something with the product (not shown).

                return "Done";
            }
            else
            {
                return "Unable";
            }
        }
    }
}