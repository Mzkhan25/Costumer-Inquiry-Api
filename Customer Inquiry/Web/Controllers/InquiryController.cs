using System.Web.Mvc;

namespace Web.Controllers
{
    public class InquiryController : Controller
    {

        // GET
        public ActionResult Index()
        {
            return
            View();
        }
        // GET api/Inquiry/5
        public string Get(int id)
        {
            return "value";
        }
    }
}